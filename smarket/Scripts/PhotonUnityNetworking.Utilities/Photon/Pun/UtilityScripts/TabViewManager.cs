using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.UtilityScripts
{
	public class TabViewManager : MonoBehaviour
	{
		[Serializable]
		public class TabChangeEvent : UnityEvent<string>
		{
		}

		[Serializable]
		public class Tab
		{
			public string ID;

			public Toggle Toggle;

			public RectTransform View;
		}

		public ToggleGroup ToggleGroup;

		public Tab[] Tabs;

		public TabChangeEvent OnTabChanged;

		protected Tab CurrentTab;

		private Dictionary<Toggle, Tab> Tab_lut;

		private void Start()
		{
		}

		public void SelectTab(string id)
		{
		}

		private void OnTabSelected(Tab tab)
		{
		}
	}
}
