using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.DreamOS
{
	[CreateAssetMenu(fileName = "New App Library", menuName = "DreamOS/New App Library")]
	public class AppLibrary : ScriptableObject
	{
		[Serializable]
		public class AppItem
		{
			public string appTitle = "App Name";

			public string localizationKey;

			public Texture2D appIconPreview;

			public Sprite appIconBig;

			public Sprite appIconMedium;

			public Sprite appIconSmall;

			public Color gradientLeft = new Color32(215, 215, 215, byte.MaxValue);

			public Color gradientRight = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}

		public bool alwaysUpdate;

		public bool optimizeUpdates = true;

		public List<AppItem> apps = new List<AppItem>();
	}
}
