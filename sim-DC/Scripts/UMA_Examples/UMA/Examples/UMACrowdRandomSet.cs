using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.Examples
{
	public class UMACrowdRandomSet : ScriptableObject
	{
		[Serializable]
		public class CrowdRaceData
		{
			public string raceID;

			public CrowdSlotElement[] slotElements;
		}

		[Serializable]
		public class CrowdSlotElement
		{
			public string Info;

			public CrowdSlotData[] possibleSlots;

			public string requirement;

			public string condition;
		}

		[Serializable]
		public class CrowdSlotData
		{
			public string slotID;

			public bool useSharedOverlayList;

			public int overlayListSource;

			public CrowdOverlayElement[] overlayElements;
		}

		[Serializable]
		public class CrowdOverlayElement
		{
			public CrowdOverlayData[] possibleOverlays;
		}

		public enum OverlayType
		{
			Unknown = 0,
			Random = 1,
			Texture = 2,
			Color = 3,
			Skin = 4,
			Hair = 5
		}

		public enum ChannelUse
		{
			None = 0,
			Color = 1,
			InverseColor = 2
		}

		[Serializable]
		public class CrowdOverlayData
		{
			public string overlayID;

			public Color maxRGB;

			public Color minRGB;

			public bool useSkinColor;

			public bool useHairColor;

			public float hairColorMultiplier;

			public ChannelUse colorChannelUse;

			public int colorChannel;

			public OverlayType overlayType;

			public void UpdateVersion()
			{
			}
		}

		public CrowdRaceData data;

		public static void Apply(UMAData umaData, CrowdRaceData race, Color skinColor, Color HairColor, Color Shine, HashSet<string> Keywords, UMAContextBase context)
		{
		}
	}
}
