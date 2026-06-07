using System;
using JetBrains.Annotations;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Framework
{
	[UsedImplicitly]
	public class PhysicsManager : IInitializable, IDisposable
	{
		public PhysicsGroup _playerGroup;

		public PhysicsGroup _playersWithWallCollisionGroup;

		public PhysicsGroup _enemyGroup;

		public PhysicsGroup _bulletGroup;

		public PhysicsGroup _pickupGroup;

		public PhysicsGroup _goToPlayerPickupGroup;

		public PhysicsGroup _destructiblesGroup;

		public PhysicsGroup _magnetGroup;

		public PhysicsGroup _doorGroup;

		private static PhysicsManager _sInstance;

		private GameManager _gameManager;

		private ItemType[] _goldItems;

		public bool PickupImmaterial;

		public static PhysicsManager Instance => null;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void InitPhysicsGroups(GameManager gameManager)
		{
		}

		public void InitPhysicsColliders()
		{
		}

		public static void TakePickup(Pickup pickupItem, CharacterController playerCharacter)
		{
		}

		private bool OnPlayerOverlapsEnemy(CallbackContext context, ArcadeColliderType first, ArcadeColliderType second)
		{
			return false;
		}

		private bool OnPlayerOverlapsPickup(CallbackContext context, ArcadeColliderType player, ArcadeColliderType pickup)
		{
			return false;
		}

		private bool OnMagnetOverlapsPickup(CallbackContext context, ArcadeColliderType magnet, ArcadeColliderType pickup)
		{
			return false;
		}

		private bool OnBulletOverlapsDoor(CallbackContext context, ArcadeColliderType bullet, ArcadeColliderType door)
		{
			return false;
		}
	}
}
