﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace BikeSharing.AutomatedTests.Pages
{
    public class DeleteFoodPage : BasePage
    {
        public DeleteFoodPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        public RentABikePage ClickDeleteButton()
        {
            try
            {
                var deleteButton = _driver.FindElement(By.ClassName("btn"));
                deleteButton.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("Delete food failed: " + e.Message);
            }
            return new RentABikePage(_driver);
        }
        #endregion
        
        #region Verification
        public DeleteFoodPage VerifyDeleteFoodPageReached()
        {
            try
            {
                var deleteHeader = _driver.FindElement(By.XPath("/html/body/div[2]/h2"));
            }
            catch(Exception e)
            {
                Assert.Fail("Delete page is not reached: " + e.Message);
            }
            return this;
        }
        #endregion
    }
}