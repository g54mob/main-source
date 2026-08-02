using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Compass Info", menuName = "HQ FPS Template/Equipment/Compass")]
	public class CompassInfo : EquipmentItemInfo
	{
		[Serializable]
		public class CompassSettingsInfo
		{
			public Vector3 CompassRoseRotationAxis = new Vector3(0f, 0f, 1f);
		}

		[Group("5: ", true)]
		public CompassSettingsInfo CompassSettings;
	}
}
