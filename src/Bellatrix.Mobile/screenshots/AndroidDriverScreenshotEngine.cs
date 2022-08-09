﻿// <copyright file="AndroidDriverScreenshotEngine.cs" company="Automate The Planet Ltd.">
// Copyright 2022 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System;
using System.Drawing;
using System.IO;
using Bellatrix.Plugins.Screenshots.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace Bellatrix.Mobile.Screenshots
{
    public sealed class AndroidDriverScreenshotEngine : IScreenshotEngine
    {
        public string TakeScreenshot(ServicesCollection container) => TakeScreenshotAndroidDriver(container);

        public string TakeScreenshotAndroidDriver(ServicesCollection container)
        {
            var driver = container.Resolve<AndroidDriver<AndroidElement>>();
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}