using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyBikes.DomainLogic.Tests
{
    [TestClass()]
    public class TrainerTests
    {
        Trainer StubTrainer;
        [TestMethod()]
        [TestCategory("Unit")]
        public void EmptyTrainerMustHaveCurrentMilesToZero()
        {
            var trainer = new Trainer(100);
            Assert.AreEqual(0, trainer.MilesTravelled);

        }

        [TestMethod]
        [TestCategory("Unit")]
        public void AddingWorkoutAddsMilesTravelled()
        {
            var trainer = new Trainer(100);
            trainer.RegisterWorkout(10, TimeSpan.FromMinutes(20));
            Assert.AreEqual(10, trainer.MilesTravelled);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void GetBestWorkoutSpeedNoWorkouts()
        {
            var trainer = new Trainer(10);
            var expectedWorkout = trainer.GetWorkoutWithBestSpeed();
            Assert.AreEqual(null, expectedWorkout);
        }
        [TestMethod]
        [TestCategory("Unit")]
        public void GetBestWorkoutSpeedOneWorkouts()
        {
            var trainer = new Trainer(10);
            trainer.RegisterWorkout(10, TimeSpan.FromMinutes(20));
            var expectedWorkout = trainer.GetWorkoutWithBestSpeed();
            Assert.AreEqual("Workout: 10 Miles, 20 Minutes", expectedWorkout.ToString());
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void GetBestWorkoutSpeedTwoWorkouts()
        {
            var trainer = new Trainer(10);
            trainer.RegisterWorkout(10, TimeSpan.FromMinutes(20));
            trainer.RegisterWorkout(5, TimeSpan.FromMinutes(20));
            var expectedWorkout = trainer.GetWorkoutWithBestSpeed();
            Assert.AreEqual("Workout: 10 Miles, 20 Minutes", expectedWorkout.ToString());
        }

        //[TestMethod]
        //public void GetWorkoutWithMostMilesTraveled()
        //{
        //    var trainer = new Trainer(10);
        //    trainer.RegisterWorkout(10, TimeSpan.FromMinutes(20));
        //    trainer.RegisterWorkout(5, TimeSpan.FromMinutes(20));
        //    var expectedWorkout = trainer.GetMostMilesTraveled();
        //    Assert.AreEqual("Workout: 10 Miles, 20 Minutes", expectedWorkout.ToString());
        //}

        private void CreateTrainerWith3Workouts()
        {
            StubTrainer = new Trainer(100);
            StubTrainer.RegisterWorkout(15, TimeSpan.FromMinutes(60));
            StubTrainer.RegisterWorkout(1, TimeSpan.FromMinutes(10));
            StubTrainer.RegisterWorkout(10, TimeSpan.FromMinutes(30));

        }

        [TestMethod]
	[TestCategory("Unit")]
        public void GettingWorkoutIntensityForEasyWorkouts()
        {
            CreateTrainerWith3Workouts();
            int intensity = StubTrainer.GetWorkoutIntensityCount("Easy");
            Assert.AreEqual(1, intensity);
        }

        [TestMethod]
	[TestCategory("Unit")]
        public void GettingWorkoutIntensityForHardWorkouts()
        {
            CreateTrainerWith3Workouts();
            int intensity = StubTrainer.GetWorkoutIntensityCount("Hard");
            Assert.AreEqual(1, intensity);
        }

        [TestMethod]
	[TestCategory("Unit")]
        public void GettingWorkoutIntensityForMediumWorkouts()
        {
            CreateTrainerWith3Workouts();
            int intensity = StubTrainer.GetWorkoutIntensityCount("Medium");
            Assert.AreEqual(1, intensity);
        }

    }
}
