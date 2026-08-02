using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Healing Item Info", menuName = "HQ FPS Template/Equipment/Healing Item")]
	public class HealingItemInfo : EquipmentItemInfo
	{
		[Serializable]
		public class HealingSettingsInfo
		{
			[Range(0.1f, 5f)]
			public float HealTime = 2f;

			[Range(0f, 10f)]
			public float UpdateHealthDelay = 1f;

			[Space(3f)]
			[MinMax(0f, 100f, true)]
			public Vector2 HealAmount = new Vector2(40f, 50f);

			[Space(3f)]
			[BHeader("( Animation )", order = 2)]
			public float HealAnimSpeed = 1f;

			[BHeader("( Audio )")]
			[Group]
			public DelayedSound[] HealingAudio;

			[BHeader("( Camera )")]
			[Group]
			public DelayedCameraForce[] HealingCameraForces;
		}

		[Group("5: ", true)]
		public HealingSettingsInfo HealingSettings;
	}
}
