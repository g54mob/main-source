using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Items
{
	public class Pickup_EME_Cat : NetworkPickup
	{
		[Serializable]
		private struct CatPickupReward
		{
			public WeaponType RewardType;

			[SerializeField]
			private float _minValue;

			[SerializeField]
			private float _maxValue;

			public float Value => 0f;
		}

		private enum CatBehaviourState
		{
			Idle = 0,
			Fleeing = 1,
			Taken = 2
		}

		private enum CatDespawnBehaviourType
		{
			None = 0,
			CheckDistanceWhenFleeing = 1,
			CheckDistanceAlways = 2
		}

		[SerializeField]
		private bool _randomiseColour;

		[SerializeField]
		private float _aggroRange;

		[SerializeField]
		private float _runSpeed;

		[Space]
		[SerializeField]
		private CatDespawnBehaviourType _despawnBehaviourType;

		[SerializeField]
		public float _maxDistanceFromPlayerBeforeDespawn;

		[Header("Pickup Rewards")]
		[SerializeField]
		private float _healthRecoveredOnPickup;

		[SerializeField]
		private bool _triggerVacuumOnPickup;

		[SerializeField]
		private bool _giveStatRewardOnPickup;

		[SerializeField]
		private CatPickupReward[] _pickupRewards;

		protected VampireSurvivors.Objects.Characters.CharacterController AmeyaPlayer;

		private CatBehaviourState _currentCatBehaviourState;

		private Vector2 _velocity;

		private uint _rewardSeed;

		private uint _catTypeSeed;

		protected Unity.Mathematics.Random _rewardRng;

		protected Unity.Mathematics.Random _catTypeRng;

		private static int _sfxIndex;

		private const string IdleAnimationName = "idle";

		private const string FleeAnimationName = "flee";

		private const string DraggedAnimationName = "dragged";

		protected const string EmeraldsTextureName = "character_eme_witch";

		private readonly float[] _detuneValues;

		public Action OnGoToPlayer;

		public Action OnDespawn;

		[Sync]
		public uint RewardSeed
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		[Sync]
		public uint CatTypeSeed
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public override bool CanCharacterCollectPickup(CharacterType characterType)
		{
			return false;
		}

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		private void OnRecycle()
		{
		}

		public override void GetTaken()
		{
		}

		protected virtual void OnCatPickedUp()
		{
		}

		private void SetVelocity(Vector2 velocity)
		{
		}

		public void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}

		[Command]
		public void TransitionToFlee(Vector2 velocity)
		{
		}

		protected override void GoToThePlayer()
		{
		}

		private void ConfigureAnimations()
		{
		}

		protected virtual void GetCatAnimations(out List<Sprite> idle, out List<Sprite> flee, out List<Sprite> dragged)
		{
			idle = null;
			flee = null;
			dragged = null;
		}

		protected virtual ItemType GetCatType()
		{
			return default(ItemType);
		}

		private float GetDetune()
		{
			return 0f;
		}

		private void AddAttribute(VampireSurvivors.Objects.Characters.CharacterController character, WeaponType weaponType, float value)
		{
		}
	}
}
