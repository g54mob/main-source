using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class RoomZone
	{
		public string name;

		public string displayName;

		public float costPerTile;

		public bool staffAccessible;

		public bool patronAccessible;

		[Tooltip("if set to true, the regular feedback from patrons (re. temperature) etc. will not happen in this zone")]
		public bool disableAtmosphereFeedback;

		[Tooltip("if this zone should set a base value for an atmosphere type, set it here")]
		public ZoneEquilibriumSetting[] atmosphereEquilibriums;

		[HideInInspector]
		public GameObject wallTrimPrefab;

		public bool useColor;

		public Color color;

		public GameObject[,] floorTiles;

		[Header("Schedule")]
		public SlotOption[] allowedScheduleItems;

		public ScheduleTimeSlot[] defaultSchedule;

		[Header("Policies")]
		public ZonePolicy[] defaultPolicies;

		[Header("Walk speed")]
		[Tooltip("factor applied to walking speed in this zone.")]
		public float speedModifier;

		[DropDownChoice(typeof(AudioSwitch.FootstepMaterial), "GetAllMaterials")]
		public string floorSoundMaterial;

		public string GetDisplayNameKey()
		{
			return null;
		}

		public string GetDisplayName()
		{
			return null;
		}

		public TooltipData GetTooltipData()
		{
			return null;
		}
	}
}
