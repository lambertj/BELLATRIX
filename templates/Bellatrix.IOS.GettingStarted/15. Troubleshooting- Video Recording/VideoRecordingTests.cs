﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Mobile.IOS.GettingStarted
{
    // If you open the testFrameworkSettings file, you find the videoRecordingSettings section that controls this lifecycle.
    //  "videoRecordingSettings": {
    //      "isEnabled": "true",
    //      "waitAfterFinishRecordingMilliseconds": "500",
    //      "filePath": "ApplicationData\\Troubleshooting\\Videos"
    //  }
    //
    // You can turn off the making of videos for all tests and specify where the videos to be saved.
    // waitAfterFinishRecordingMilliseconds adds some time to the end of the test, making the video not going black immediately.
    // In the extensibility chapters read more about how you can create custom video recorder or change the saving strategy.
    [TestClass]
    [IOS(Constants.IOSNativeAppPath,
        Constants.IOSDefaultVersion,
        Constants.IOSDefaultDeviceName,
        Lifecycle.RestartEveryTime)]
    public class VideoRecordingTests : MSTest.IOSTest
    {
        [TestMethod]
        [Timeout(180000)]
        [TestCategory(Categories.CI)]
        public void ButtonClicked_When_CallClickMethod()
        {
            var button = App.ElementCreateService.CreateByName<Button>("ComputeSumButton");

            button.Click();
        }
    }
}