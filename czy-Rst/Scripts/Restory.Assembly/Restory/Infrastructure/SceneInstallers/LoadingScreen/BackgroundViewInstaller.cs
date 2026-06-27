using Restory.Gameplay.Background;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.LoadingScreen
{
	public class BackgroundViewInstaller : MonoInstaller
	{
		[SerializeField]
		private BackgroundTimeView backgroundView;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<BackgroundTimeView>().FromInstance(backgroundView);
			base.Container.QueueForInject(backgroundView);
		}
	}
}
