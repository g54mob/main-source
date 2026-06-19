using UnityEngine;
using WorldEnvironment.Islands;
using Zenject;

namespace Infrastructure.Installers
{
	public class WorldGridManagerInstaller : MonoInstaller
	{
		[SerializeField]
		private WorldParams _params;

		[SerializeField]
		private Transform _worldCenter;

		public override void InstallBindings()
		{
			base.Container.Bind<WorldParams>().FromInstance(_params).AsSingle();
			base.Container.Bind<WorldGridManager>().FromInstance(new WorldGridManager(_params, _params.GridParams, _worldCenter)).AsSingle();
		}
	}
}
