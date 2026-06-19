using UnityEngine;
using WorldEnvironment.Islands;
using Zenject;

namespace Infrastructure.Installers
{
	public class IslandsSpawnerInstaller : MonoInstaller
	{
		[SerializeField]
		private IslandWorldSpawner _islandSpawner;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<IslandWorldSpawner>().FromInstance(_islandSpawner).AsSingle();
		}
	}
}
