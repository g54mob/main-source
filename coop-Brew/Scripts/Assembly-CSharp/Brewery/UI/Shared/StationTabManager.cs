using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.UI.Shared
{
	public class StationTabManager
	{
		private class TabDefinition
		{
			public string Name;

			public Button Button;

			public VisualElement Content;
		}

		private readonly Dictionary<string, TabDefinition> tabs;

		private readonly string stationName;

		private string activeTabName;

		public string ActiveTabName => null;

		public event Action<string> OnTabChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public StationTabManager(string stationName)
		{
		}

		public void RegisterTab(string tabName, Button button, VisualElement content)
		{
		}

		public void SwitchToTab(string tabName)
		{
		}

		public void ResetToDefaultTab(string defaultTabName = "input")
		{
		}

		public bool IsTabActive(string tabName)
		{
			return false;
		}

		public Button GetTabButton(string tabName)
		{
			return null;
		}

		public VisualElement GetTabContent(string tabName)
		{
			return null;
		}
	}
}
