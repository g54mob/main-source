using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters
{
	public class MazerellaDancerMagnet : MonoBehaviour
	{
		private struct VacuumedPickup
		{
			public Pickup Pickup;

			public float Speed;

			public bool Collected;

			public void SetSpeed(float speed)
			{
			}

			public void SetCollected(bool isCollected)
			{
			}
		}

		private class ValuePickupSpawner
		{
			private readonly int _maxPickupsToSpawn;

			private readonly Action<Vector2, float, Action<Pickup>> _spawnPickupAction;

			private readonly Action<Pickup> _startPickupSpawnTweenAction;

			private float _valueCollected;

			private float _valuePerPickupSpawned;

			public ValuePickupSpawner(int maxPickupsToSpawn, Action<Vector2, float, Action<Pickup>> spawnPickupAction, Action<Pickup> startPickupSpawnTweenAction)
			{
			}

			public void IncreaseValueCollected(int amount)
			{
			}

			public int CalculateNumberOfPickupsToSpawn()
			{
				return 0;
			}

			private int CountPickupsToSpawnBasedOnValueCollected()
			{
				return 0;
			}

			public bool SpawnPickup(Vector3 spawnPosition)
			{
				return false;
			}
		}

		[Space]
		[SerializeField]
		private ArcadeSprite _magnet;

		[SerializeField]
		private float _magnetRadius;

		[SerializeField]
		private float _maxPickupVacuumSpeed;

		[SerializeField]
		private float _pickupVacuumAcceleration;

		[Space]
		[SerializeField]
		private float _pickupSpawnRadius;

		[SerializeField]
		private float _maxExtraPickupSpawnDistance;

		[SerializeField]
		private float _spawnTweenDuration;

		[Space]
		[SerializeField]
		private int _maxGemsToSpawn;

		[SerializeField]
		private int _maxCoinsToSpawn;

		[SerializeField]
		private int _maxFrozenSoulsToSpawn;

		private bool _isEnabled;

		private int _numberOfPickupsToSpawn;

		private int _spawningPickupIndex;

		private ValuePickupSpawner _gemSpawner;

		private ValuePickupSpawner _coinsSpawner;

		private ValuePickupSpawner _frozenSoulSpawner;

		private readonly List<Pickup> _collectedPickups;

		private readonly List<VacuumedPickup> _vacuumedPickups;

		private float _deltaTimeCounter;

		private SfxType[] stealSounds;

		public event Action OnAllPickupsSpawned
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private bool IsPickupMoney(ItemType itemType)
		{
			return false;
		}

		private bool IsIgnoredItemType(ItemType pickupType)
		{
			return false;
		}

		public void InitMagnet(Transform enemyTransform)
		{
		}

		public void DisableMagnet()
		{
		}

		public void Cleanup()
		{
		}

		private bool OnDancerMagnetOverlapsPickup(CallbackContext context, ArcadeColliderType magnet, ArcadeColliderType pickup)
		{
			return false;
		}

		public void UpdateVacuumedPickups()
		{
		}

		public void UpdatePickUpLocations()
		{
		}

		public void SetupPickupsToSpawnOnDeath()
		{
		}

		public void SpawnPickups()
		{
		}

		private void StartPickupSpawnTween(Pickup pickup)
		{
		}

		private void SetPickupInteractionsActive(Pickup pickup, bool active)
		{
		}
	}
}
