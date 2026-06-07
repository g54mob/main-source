using System;
using JetBrains.Annotations;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework
{
	[UsedImplicitly]
	public class AccessoriesFacade : IInitializable, IDisposable
	{
		[Inject]
		private AccessoriesFactory _accessoriesFactory;

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

		public void AddAccessory(WeaponType accessoryType, CharacterController characterController, bool removeFromStore = true)
		{
		}

		public void RemoveAccessory(WeaponType accessoryType, CharacterController characterController, bool notifyRemove = true)
		{
		}
	}
}
