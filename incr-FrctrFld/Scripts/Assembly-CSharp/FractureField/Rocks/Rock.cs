using System.Collections.Generic;
using FractureField.Drones;
using Reactivity;
using UnityEngine;

namespace FractureField.Rocks
{
	public class Rock : RockSaveData, ISaveData<Rock, RockSaveData>
	{
		public class ApplyDamageOptions
		{
			public float DamagePotential;

			public float PierceMultiplier;

			public float ResourceMultiplier;

			public RockHitType HitType;

			public DroneType DroneType;

			public List<RockLayerHitResult> Results;
		}

		public RockController Controller { get; set; }

		public Vector2 Position { get; set; }

		public bool IsDestroyed => false;

		public RTrigger OnRockHit { get; }

		public static RTrigger OnAnyRockHit { get; }

		public static List<RockLayerHitResult> LastLayerHitResults { get; private set; }

		public RTrigger OnRockDestroyed { get; }

		public Rock Load()
		{
			return null;
		}

		public RockSaveData Save()
		{
			return null;
		}

		public RockLayerData GetLayerData()
		{
			return null;
		}

		public void Initialize(long id, RockLayerType layerType, Vector2 position, bool isNewSpawn = false)
		{
		}

		public float CalculateLayerResources(RockLayerType layerType, float percentage = 1f)
		{
			return 0f;
		}

		public float CalculateDustRewardAmount(RockLayerType layerType)
		{
			return 0f;
		}

		private float CalculateDroneCoresDropChance(RockLayerType layerType)
		{
			return 0f;
		}

		private void AwardLayerResources(RockLayerHitResult options, float damagePercentage, string source, string detail)
		{
		}

		private void AwardPreviousLayerResources(RockLayerHitResult hitResult)
		{
		}

		public float CalculatePenetrationMultiplier(float pierceMultiplier = 1f)
		{
			return 0f;
		}

		public float CalculateDamageToLayer(float damagePotential, float pierceMultiplier)
		{
			return 0f;
		}

		private void ApplyDamageToLayer(ApplyDamageOptions options)
		{
		}

		private List<RockLayerHitResult> Hit(ApplyDamageOptions options)
		{
			return null;
		}

		public List<RockLayerHitResult> ManualHit()
		{
			return null;
		}

		public void DroneHit(DroneType droneType, float damagePotential, float pierceMultiplier = 1f, float resourceMultiplier = 1f)
		{
		}

		public List<RockLayerHitResult> BombHit(float damagePotential)
		{
			return null;
		}

		private void PlaySoundForHitResults(List<RockLayerHitResult> results)
		{
		}

		public void TransitionToNextLayer()
		{
		}

		public float GetHealthPercentage()
		{
			return 0f;
		}

		public float OuterDistanceTo(Vector2 position)
		{
			return 0f;
		}

		public void OnDestroy()
		{
		}
	}
}
