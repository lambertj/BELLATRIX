﻿// <copyright file="SauceLabsBrowserConfiguration.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
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
using Bellatrix.Mobile.Configuration;
using Bellatrix.Mobile.TestExecutionExtensions;
using OpenQA.Selenium.Appium;

namespace Bellatrix.SpecFlow.Mobile.TestExecutionExtensions
{
    public class SauceLabsAppConfiguration : AppConfiguration, IAppiumOptionsFactory
    {
        public string BrowserVersion { get; set; }

        public string Platform { get; set; }

        public bool RecordVideo { get; set; }

        public bool RecordScreenshots { get; set; }

        public string ScreenResolution { get; set; }

        public virtual void InitializeAppiumOptions(string classFullName)
        {
            AppiumOptions = AddAdditionalCapability(classFullName, new AppiumOptions());

            AppiumOptions.AddAdditionalCapability("browserName", string.Empty);
            AppiumOptions.AddAdditionalCapability("platform", Platform);
            AppiumOptions.AddAdditionalCapability("version", BrowserVersion);
            AppiumOptions.AddAdditionalCapability("screenResolution", ScreenResolution);
            AppiumOptions.AddAdditionalCapability("recordVideo", RecordVideo);
            AppiumOptions.AddAdditionalCapability("recordScreenshots", RecordScreenshots);

            var sauceLabsCredentialsResolver = new SauceLabsCredentialsResolver();
            var credentials = sauceLabsCredentialsResolver.GetCredentials();
            AppiumOptions.AddAdditionalCapability("username", credentials.Item1);
            AppiumOptions.AddAdditionalCapability("accessKey", credentials.Item2);
            AppiumOptions.AddAdditionalCapability("name", classFullName);
        }
    }
}