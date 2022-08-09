﻿// <copyright file="UntilNotExist.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Mobile.Configuration;
using Bellatrix.Mobile.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Bellatrix.Mobile.Untils
{
    public class WaitNotExistStrategy<TDriver, TDriverElement> : WaitStrategy<TDriver, TDriverElement>
       where TDriver : AppiumDriver<TDriverElement>
       where TDriverElement : AppiumWebElement
    {
        public WaitNotExistStrategy(int? timeoutInterval = null, int? sleepInterval = null)
            : base(timeoutInterval, sleepInterval)
        {
            TimeoutInterval = timeoutInterval ?? ConfigurationService.GetSection<MobileSettings>().TimeoutSettings.ElementToNotExistTimeout;
        }

        public override void WaitUntil<TBy>(TBy by)
        {
            WaitUntil(d => ElementNotExists(WrappedWebDriver, by), TimeoutInterval, SleepInterval);
        }

        private bool ElementNotExists<TBy>(TDriver searchContext, TBy by)
            where TBy : FindStrategy<TDriver, TDriverElement>
        {
            try
            {
                var element = by.FindElement(searchContext);
                return element == null;
            }
            catch (InvalidOperationException)
            {
                return true;
            }
            catch (TimeoutException)
            {
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }
}
