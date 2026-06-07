using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Installers
{
	public class FactoriesInstaller : MonoInstaller<FactoriesInstaller>
	{
		[SerializeField]
		private WeaponFactory _WeaponFactory;

		[SerializeField]
		private ProjectileFactory _ProjectileFactory;

		[SerializeField]
		private CharacterFactory _CharacterFactory;

		[SerializeField]
		private AccessoriesFactory _AccessoriesFactory;

		[SerializeField]
		private TilesetFactory _TilesetFactory;

		[SerializeField]
		private EnemyFactory _EnemyFactory;

		[SerializeField]
		private DestructibleFactory _DestructibleFactory;

		[SerializeField]
		private PickupFactory _PickupFactory;

		[SerializeField]
		private HeroVfxFactory _HeroVfxFactory;

		[SerializeField]
		private FontFactory _FontFactory;

		[SerializeField]
		private AssetReferenceLibrary _AssetReferenceLibrary;

		public override void InstallBindings()
		{
		}
	}
}
