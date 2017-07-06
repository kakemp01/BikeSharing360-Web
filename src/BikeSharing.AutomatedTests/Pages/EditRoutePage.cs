﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace BikeSharing.AutomatedTests.Pages
{
    public class EditRoutePage : BasePage
    {
        public EditRoutePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        public EditRoutePage SetCarbs(string carbs)
        {
            try
            {
                var carbTextbox = _driver.FindElement(By.Id("CarbohydratesInGrams"));
                carbTextbox.Clear();
                carbTextbox.SendKeys(carbs);
            }
            catch(Exception e)
            {
                Assert.Fail("Could not set carbs: " + e.Message);
            }
            
            return this;
        }

        public RentABikePage ClickSaveButton()
        {
            try
            {
                var saveButton = _driver.FindElement(By.ClassName("btn"));
                saveButton.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("Could not click save button: " + e.Message);
            }
            return new RentABikePage(_driver);
        }
        #endregion

        #region Verificiations
        public EditRoutePage VerifyEditFoodPageReached()
        {
            try
            {
                var editHeader = _driver.FindElement(By.TagName("h2"));
                Assert.AreEqual("Edit", editHeader.Text, "page header is not Edit");
            }
            catch(Exception e)
            {
                Assert.Fail("Could not verify edit food page reached: " + e.Message);
            }
            return this;
        }
        #endregion
    }
}