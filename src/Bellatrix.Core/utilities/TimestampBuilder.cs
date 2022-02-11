﻿// <copyright file="TimestampBuilder.cs" company="Automate The Planet Ltd.">
// Copyright 2021 Automate The Planet Ltd.
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
using System.Linq;

namespace Bellatrix.Utilities
{
    public class TimestampBuilder
    {
        public static string BuildUniqueText(string text)
        {
            var newTimestamp = GenerateUniqueText();
            var result = string.Concat(text, newTimestamp);
            return result;
        }

        public static string GenerateUniqueText()
        {
            var newTimestamp = DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss-ffff");
            return newTimestamp;
        }

        public static string GenerateUniqueUrl()
        {
            var newTimestamp = "https://demos.bellatrix.solutions/" + DateTime.Now.ToString("MMMMddyyyyhhmmss");
            return newTimestamp;
        }
        public static string GenerateUniqueTextMonthNameOneWord()
        {
            var newTimestamp = DateTime.Now.ToString("MMMMddyyyyhhmmss");
            return newTimestamp;
        }
    }
}