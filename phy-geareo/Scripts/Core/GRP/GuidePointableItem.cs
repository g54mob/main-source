using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	[Serializable]
	public struct GuidePointableItem
	{
		public uint order;

		public string key;

		public string text;

		public bool active;

		public GuideIcon[] icons;

		public Sprite[] sprites;

		public static GuidePointableItem FromKey(string guideKey, string text, SignalVisualConfig config, Key key)
		{
			return default(GuidePointableItem);
		}
	}
}
