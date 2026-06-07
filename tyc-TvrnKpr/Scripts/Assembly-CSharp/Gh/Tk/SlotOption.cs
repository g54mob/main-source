using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	[Serializable]
	public class SlotOption
	{
		public string id;

		public string iconOverride;

		public bool isLocked;

		public bool isLockedWhenHourSlotLocked;

		[FormerlySerializedAs("isVisible")]
		public bool isAvailable;

		public Color color;

		public string label;

		public string labelKey;

		public string group;

		public Dictionary<SlotOption, bool> ownedOptions;

		public bool allowMultipleOptions;

		[FormerlySerializedAs("hidesOthers")]
		public bool hideOthersInSlot;

		public bool hideVisual;

		private static Dictionary<string, GameObject> _iconPrefabs;

		public Color DisabledColor => default(Color);

		public Color SelectedColor => default(Color);

		public Color HoverColor => default(Color);

		public string CodexKey => null;

		public bool IsVisible()
		{
			return false;
		}

		public string GetLabelKey()
		{
			return null;
		}

		public SlotOption()
		{
		}

		public SlotOption(SlotOption option)
		{
		}

		public GameObject GetIconPrefab()
		{
			return null;
		}
	}
}
