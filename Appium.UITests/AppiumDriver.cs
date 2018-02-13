﻿using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Appium.UITests
{
    public class AppiumDriver
    {
        string PlatformName;
        public AppiumDriver<AppiumWebElement> Driver;

        public AppiumDriver(string platform)
        {
            PlatformName = platform;
            if (PlatformName.CompareTo("Android") != 0)
            {
                Driver = CreateTizenDriver();
            }
            else
            {
                Driver = CreateAndroidDriver();
            }
        }

        public void Quit()
        {
            Driver.Quit();
        }

        public AppiumWebElement GetWebElement(string id)
        {
            return Driver.FindElementByAccessibilityId(id);
        }

        public AppiumDriver<AppiumWebElement> CreateTizenDriver()
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();
            if (PlatformName.Equals("Tizen"))
            {
                capabillities.SetCapability("deviceName", "0000d84200006200");
            }
            else
            {
                capabillities.SetCapability("deviceName", "emulator-26101");
            }

            capabillities.SetCapability("platformName", "Tizen");
            //capabillities.SetCapability("appPackage", "org.tizen.example.Calculator.Tizen.Mobile");
            capabillities.SetCapability("appPackage", "org.tizen.example.FormsTizenGallery.Tizen");
            var driver = new TizenDriver<AppiumWebElement>(new Uri("http://10.113.62.173:8080/wd/hub"), capabillities);
            return driver;
        }

        public AppiumDriver<AppiumWebElement> CreateAndroidDriver()
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();
            capabillities.SetCapability("deviceName", "emulator-5554");
            capabillities.SetCapability("platformName", "Android");
            capabillities.SetCapability("appPackage", "AppiumTest.Android");
            //capabillities.SetCapability("appActivity", "md570202206b1642cdde93943af1490fb24.MainActivity");
            capabillities.SetCapability("appActivity", "md5fb91949aa2c8850087e612420184ba95.MainActivity");

            var driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabillities, TimeSpan.FromMinutes(5));
            return driver;
        }
    }
}