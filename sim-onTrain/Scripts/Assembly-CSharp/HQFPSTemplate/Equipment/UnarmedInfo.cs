using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Unarmed Info", menuName = "HQ FPS Template/Equipment/Unarmed")]
	public class UnarmedInfo : MeleeWeaponInfo
	{
		[Serializable]
		public class UnarmedSettingsInfo
		{
			[BHeader("( Arm Show )")]
			public bool AlwaysShowArms;

			[EnableIf("AlwaysShowArms", false, 10f)]
			[Tooltip("How much time the arms will be on the screen if the Player punches")]
			public float ArmsShowDuration = 3f;

			public DelayedSound ShowArmsAudio;

			[BHeader("( Running )")]
			public float RunAnimSpeed = 1f;

			public float RunAnimStartTime = 0.5f;
		}

		[Group("5: ", true)]
		public UnarmedSettingsInfo UnarmedSettings;
	}
}
