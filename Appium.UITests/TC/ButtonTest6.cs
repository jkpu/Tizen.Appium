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
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ButtonTest6
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTest6(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ClickTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "_button", "BackgroundColor");
            Assert.AreEqual("[Color: A=1, R=0.576470613479614, G=0.439215689897537, B=0.858823537826538, Hue=0.721183776855469, Saturation=0.597765326499939, Luminosity=0.649019598960876]", result);
        }
    }
}
