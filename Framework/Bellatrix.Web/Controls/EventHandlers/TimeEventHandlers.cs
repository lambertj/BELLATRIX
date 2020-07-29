﻿// <copyright file="TimeEventHandlers.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Web.Events;

namespace Bellatrix.Web.Controls.EventHandlers
{
    public class TimeEventHandlers : ElementEventHandlers
    {
        public override void SubscribeToAll()
        {
            base.SubscribeToAll();
            Time.Hovering += HoveringEventHandler;
            Time.Hovered += HoveredEventHandler;
            Time.Focusing += FocusingEventHandler;
            Time.Focused += FocusedEventHandler;
            Time.SettingTime += SettingTimeEventHandler;
            Time.TimeSet += TimeSetEventHandler;
        }

        public override void UnsubscribeToAll()
        {
            base.UnsubscribeToAll();
            Time.Hovering -= HoveringEventHandler;
            Time.Hovered -= HoveredEventHandler;
            Time.Focusing -= FocusingEventHandler;
            Time.Focused -= FocusedEventHandler;
            Time.SettingTime -= SettingTimeEventHandler;
            Time.TimeSet -= TimeSetEventHandler;
        }

        protected virtual void SettingTimeEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void TimeSetEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void HoveringEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void HoveredEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void FocusingEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void FocusedEventHandler(object sender, ElementActionEventArgs arg)
        {
        }
    }
}