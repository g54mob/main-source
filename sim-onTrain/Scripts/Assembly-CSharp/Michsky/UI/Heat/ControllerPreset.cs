using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[CreateAssetMenu(fileName = "New Controller Preset", menuName = "Heat UI/Controller/New Controller Preset")]
	public class ControllerPreset : ScriptableObject
	{
		public enum ItemType
		{
			Icon = 0,
			Text = 1
		}

		[Serializable]
		public class ControllerItem
		{
			public string itemID;

			public ItemType itemType;

			public Sprite itemIcon;

			public string itemText;
		}

		[Header("Settings")]
		public string controllerName = "Controller Name";

		[Space(10f)]
		public List<ControllerItem> items = new List<ControllerItem>();
	}
}
