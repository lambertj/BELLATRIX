﻿// <copyright file="EnsureControlExtensions.IsOn.cs" company="Automate The Planet Ltd.">
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
using System;
using Bellatrix.Mobile.Contracts;
using Bellatrix.Mobile.Events;
using OpenQA.Selenium.Appium.Android;

namespace Bellatrix.Mobile.Android
{
    public static partial class EnsureControlExtensions
    {
        public static void EnsureIsOn<T>(this T control, int? timeout = null, int? sleepInterval = null)
            where T : IElementOn, IElement<AndroidElement>
        {
            EnsureControlWaitService.WaitUntil<AndroidDriver<AndroidElement>, AndroidElement>(() => control.IsOn.Equals(true), "The control should be ON but was OFF.", timeout, sleepInterval);
            EnsuredIsOnEvent?.Invoke(control, new ElementActionEventArgs<AndroidElement>(control));
        }

        public static void EnsureIsOff<T>(this T control, int? timeout = null, int? sleepInterval = null)
            where T : IElementOn, IElement<AndroidElement>
        {
            EnsureControlWaitService.WaitUntil<AndroidDriver<AndroidElement>, AndroidElement>(() => control.IsOn.Equals(false), "The control should be OFF but it was ON.", timeout, sleepInterval);
            EnsuredIsOffEvent?.Invoke(control, new ElementActionEventArgs<AndroidElement>(control));
        }

        public static event EventHandler<ElementActionEventArgs<AndroidElement>> EnsuredIsOnEvent;
        public static event EventHandler<ElementActionEventArgs<AndroidElement>> EnsuredIsOffEvent;
    }
}