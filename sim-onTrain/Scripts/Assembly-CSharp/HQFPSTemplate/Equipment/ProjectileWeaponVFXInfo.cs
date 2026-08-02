using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Weapon VFX Info", menuName = "HQ FPS Template/Equipment Component/Weapon VFX")]
	public class ProjectileWeaponVFXInfo : ScriptableObject
	{
		[Serializable]
		public class ParticleEffectsInfo
		{
			[BHeader("Particles")]
			public GameObject MuzzleFlashPrefab;

			[Space]
			public Vector3 MuzzleFlashOffset;

			public Vector2 MuzzleFlashRandomScale;

			public Vector3 MuzzleFlashRandomRot;

			[BHeader("Tracer")]
			public GameObject TracerPrefab;

			public Vector3 TracerOffset;
		}

		[Serializable]
		public class CasingEjectionInfo
		{
			public GameObject CasingPrefab;

			[Space]
			public float SpawnDelay;

			public float CasingScale = 1f;

			public float Spin;

			public Vector3 SpawnOffset;

			public Vector3 AimSpawnOffset;

			public Vector3 SpawnVelocity;
		}

		[Serializable]
		public class MagazineEjectionInfo
		{
			public GameObject MagazinePrefab;

			[Space]
			public float SpawnDelay;

			public Vector3 MagazineVelocity;

			public Vector3 MagazineAngularVelocity;
		}

		[Group]
		public ParticleEffectsInfo ParticleEffects = new ParticleEffectsInfo();

		[Group]
		public CasingEjectionInfo CasingEjection;

		[Group]
		public MagazineEjectionInfo MagazineEjection;
	}
}
