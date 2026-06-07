using System;
using System.Collections.Generic;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public abstract class AbstractUIMenuData
	{
		[Flags]
		public enum ToggleTypes
		{
			HideHUD = 2,
			ShowHUD = 4,
			EnableFactoryActions = 8,
			DisableFactoryActions = 0x10,
			ShowOperatorView = 0x20,
			HideOperatorView = 0x40,
			ShowTopHUD = 0x80,
			HideTopHUD = 0x100,
			EnableUIActions = 0x200,
			DisableUIActions = 0x400
		}

		public enum UIMenuState
		{
			ConfigureMode = 0,
			InfoMode = 1
		}

		public enum UIDomain
		{
			Factory = 0,
			Page = 1,
			Menu = 2
		}

		public readonly UIMenu UIMenu;

		public readonly List<GoBackSourceSO> IgnoredSources;

		public readonly ToggleTypes Toggles;

		public readonly UIMenuState State;

		public readonly UIDomain Domain;

		protected AbstractUIMenuData(UIMenu uiMenu, UIDomain domain, ToggleTypes toggles, List<GoBackSourceSO> ignoredSources = null)
		{
			UIMenu = uiMenu;
			Domain = domain;
			Toggles = toggles;
			IgnoredSources = ignoredSources ?? new List<GoBackSourceSO>();
		}

		protected AbstractUIMenuData(UIMenu uiMenu, UIDomain domain, UIMenuState state)
		{
			UIMenu = uiMenu;
			Domain = domain;
			State = state;
		}
	}
}
