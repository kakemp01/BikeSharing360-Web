using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeSharing.AutomatedTests.Pages;

namespace BikeSharing.AutomatedTests
{
    [TestClass]
    public class BikeRidingUITests
    { 
        private static string _homePageUrl;
        private static HomePage _homePage;
        private static string _browserType;
        
        #region Setup and teardown
        [ClassInitialize]

        public static void Initialize(TestContext context)
        {
            _browserType = context.Properties["browserType"].ToString();
            _homePageUrl = context.Properties["appUrl"].ToString();


            Console.WriteLine("Url: " + _homePageUrl);
            Console.WriteLine("Browser type: " + _browserType);

            _homePage = HomePage.Launch(_browserType);

        }

        [ClassCleanup]
        public static void Cleanup()
        {
            // close down browser and selenium driver
            _homePage.Close();
        }
        #endregion

        #region Tests
        [TestMethod]
        [TestCategory("UITests")]
        public void BrowseToHomePageTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        [Ignore]
        public void BrowseToRentABikeTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickRentABikeLink()
                .VerifyRentABikePageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        [Ignore]
        public void BrowseToCreateNewDestinationTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickRentABikeLink()
                .VerifyRentABikePageReached()
                .ClickCreateNewLink()
                .VerifyCreatePageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        [Ignore]
        public void Add1stRouteTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to rent a bike page
                .ClickRentABikeLink()
                .VerifyRentABikePageReached()

                // clean up and delete all routes 
                .RemoveAllRoutes("Rides")

                // click create new link to add new ride
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add Ride to Samammish as a ride item and click the add button
                .SetDescription("Ride to Samammish")
                .ClickCreateButton()
                .VerifyRentABikePageReached()
                .VerifyRideInTable("Ride to Samammish", 1)

                // clean up and delete all rides 
                .RemoveAllRoutes("Rides");

        }

        [TestMethod]
        [TestCategory("UITests")]
        [Ignore]
        public void DeleteRidesTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to rent a bike page
                .ClickRentABikeLink()
                .VerifyRentABikePageReached()

                // clean up and delete all routes to sammamish
                .RemoveAllRoutes("Sammamish")

                // click create new ride to add new route
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add sammash as a route and click the add button
                .SetDescription("Sammamish")
                .ClickCreateButton()
                .VerifyRentABikePageReached()
                .VerifyRideInTable("Sammamish", 1)

                // delete the donut
                .ClickDeleteRide("Sammamish")
                .VerifyDeleteFoodPageReached()
                .ClickDeleteButton()
                .VerifyRentABikePageReached()
                .VerifyRideNotInTable("Sammamish");
        }

        [TestMethod]
        [TestCategory("UITestsBroken")]
        [Ignore]
        public void Add2ndRouteTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to nutrition page
                .ClickRentABikeLink()
                .VerifyRentABikePageReached()

                // clean up and delete all donuts 
                .RemoveAllRoutes("Donut")

                // click create new link to add new food
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add donut as a food item and click the add button
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyRentABikePageReached()
                .VerifyRideInTable("Donut", 1)

                // add the second donut
                .ClickCreateNewLink()
                .VerifyCreatePageReached()
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyRentABikePageReached()
                .VerifyRideInTable("Donut", 2);

        }

        [TestMethod]
        [TestCategory("UITests")]
        [Ignore]
        public void EditRouteTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to nutrition page
                .ClickRentABikeLink()
                .VerifyRentABikePageReached()

                // clean up and delete all donuts 
                .RemoveAllRoutes("Donut")

                // click create new link to add new food
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add donut as a food item and click the add button
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyRentABikePageReached()
                .VerifyRideInTable("Donut", 1)

                // click on the edit for the donut
                .ClickEditRideLink("Donut")
                .VerifyEditFoodPageReached()
                .SetCarbs("999.99")
                .ClickSaveButton()
                .VerifyRentABikePageReached()
                .VerifyDistance("Donut", "999.99")

                // clean up and delete all donuts 
                .RemoveAllRoutes("Donut");

        }

        [TestMethod]
        [TestCategory("UITests")]
        [Ignore]
        public void BrowseToExercisePageTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickExercisesLink()
                .VerifyExercisePageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        [Ignore]
        public void BrowseToCreateExerciseEntryTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickExercisesLink()
                .VerifyExercisePageReached()
                .ClickCreateNewLink()
                .VerifyCreatePageReached();
        }


        [TestMethod]
        [TestCategory("UITestsBroken")]
        [Ignore]
        public void BrowseToMyMetricsPageTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickMyMetricsLink()
                .VerifyMyMeticsPageReached();

        }
        #endregion
    }
}
