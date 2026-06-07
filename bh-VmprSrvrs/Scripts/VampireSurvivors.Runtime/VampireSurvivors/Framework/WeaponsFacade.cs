using System;
using JetBrains.Annotations;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Framework
{
	[UsedImplicitly]
	public class WeaponsFacade : IInitializable, IDisposable
	{
		[Inject]
		private WeaponFactory _weaponFactory;

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private LevelUpFactory _levelUpFactory;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private ArcanaManager _arcanaManager;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public Weapon AddWeapon(WeaponType weaponType, CharacterController character, bool removeFromStore = true)
		{
			return null;
		}

		public Weapon CreateDetachedWeapon(WeaponType weaponType, CharacterController characterController)
		{
			return null;
		}

		public Weapon RemoveWeapon(WeaponType weaponType, CharacterController characterController, bool notifyRemove = true)
		{
			return null;
		}

		public Equipment RemoveEquipment(WeaponType weaponType, CharacterController characterController, bool notifyRemove = true)
		{
			return null;
		}

		public Weapon AddHiddenWeapon(WeaponType weaponType, CharacterController characterController, bool removeFromStore = true, bool allowDuplicates = false)
		{
			return null;
		}

		public void RemoveHiddenWeapon(WeaponType weaponType, CharacterController characterController)
		{
		}

		public void RemoveThisHiddenWeapon(Weapon weapon, CharacterController characterController)
		{
		}
	}
}
