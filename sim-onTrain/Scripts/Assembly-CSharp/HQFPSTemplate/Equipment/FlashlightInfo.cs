using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Flashlight Info", menuName = "HQ FPS Template/Equipment/Flashlight")]
	public class FlashlightInfo : EquipmentItemInfo
	{
		[Serializable]
		public class FlashlightSettingsInfo
		{
			[Range(0.1f, 2f)]
			public float SwitchDuration = 0.5f;

			[BHeader("( Animation )")]
			public float AnimSwitchSpeed = 1f;

			[BHeader("( Audio )")]
			public DelayedSound SwitchOnClip;

			public DelayedSound SwitchOffClip;

			[BHeader("( Camera )")]
			public DelayedCameraForce SwitchPressCamForce;
		}

		[Space]
		[Group("5: ", true)]
		public FlashlightSettingsInfo FlashlightSettings;
	}
}
