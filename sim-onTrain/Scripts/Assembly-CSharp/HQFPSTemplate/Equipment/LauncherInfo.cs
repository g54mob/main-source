using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Launcher Info", menuName = "HQ FPS Template/Equipment/Launcher")]
	public class LauncherInfo : ProjectileWeaponInfo
	{
		[Serializable]
		public class LaunchingInfo
		{
			public ShaftedProjectile Prefab;

			[Space]
			public Vector3 SpawnOffset = Vector3.zero;

			public Vector3 AngularVelocity = Vector3.zero;

			[Range(0.01f, 10f)]
			public float LaunchSpread = 1f;

			[Range(0f, 100f)]
			public float LaunchSpeed = 15f;

			[Range(0f, 5f)]
			public float LaunchDelay = 0.3f;
		}

		[Group("5: ", true)]
		public LaunchingInfo Launching;
	}
}
