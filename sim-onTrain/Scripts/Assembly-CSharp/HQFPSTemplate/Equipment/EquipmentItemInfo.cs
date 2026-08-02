using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public abstract class EquipmentItemInfo : ScriptableObject
	{
		[Serializable]
		public class GeneralInfo
		{
			[BHeader("( Use Settings )")]
			public bool UseWhileAirborne;

			public bool UseWhileRunning;

			public bool CanStopReloading;

			[Space(3f)]
			[BHeader("( Others )", order = 2)]
			public int CrosshairID;

			[Range(0f, 100f)]
			public float StaminaTakePerUse;

			[Range(0.01f, 2f)]
			public float MovementSpeedMod = 1f;
		}

		[Serializable]
		public class AimingInfo
		{
			public bool Enabled;

			[Space]
			[EnableIf("Enabled", true, 0f)]
			public float AimThreshold;

			[EnableIf("Enabled", true, 0f)]
			public float AimCamHeadbobMod;

			[EnableIf("Enabled", true, 0f)]
			public float AimMovementSpeedMod;

			[EnableIf("Enabled", true, 0f)]
			public bool AimWhileAirborne;

			[EnableIf("Enabled", true, 0f)]
			public bool UseAimBlur;

			[EnableIf("Enabled", true, 0f)]
			public SoundPlayer AimSounds;
		}

		[Serializable]
		public class ToggleWeaponStateModule
		{
			[Range(0.1f, 5f)]
			public float Duration = 0.6f;

			[Space(4f)]
			public float AnimationSpeed = 1f;

			public DelayedSound[] Audio;

			public DelayedCameraForce[] CameraForces;
		}

		[Group("1: ", true)]
		public GeneralInfo General;

		[Space]
		[Group("2: ", true)]
		public ToggleWeaponStateModule Equipping;

		[Group("3: ", true)]
		public ToggleWeaponStateModule Unequipping;

		[Space]
		[Group("4: ", true)]
		public AimingInfo Aiming;
	}
}
