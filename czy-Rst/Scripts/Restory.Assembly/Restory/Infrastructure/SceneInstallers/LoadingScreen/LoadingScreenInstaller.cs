using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.LoadingScreen
{
	public class LoadingScreenInstaller : MonoInstaller
	{
		[SerializeField]
		private ScreenLoader screenLoader;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<ScreenLoader>().FromInstance(screenLoader);
			base.Container.QueueForInject(screenLoader);
		}
	}
}
