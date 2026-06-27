using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.MainMenu
{
	public class MainMenuCameraInstaller : MonoInstaller
	{
		[SerializeField]
		private Camera mainCameraInScene;

		public override void InstallBindings()
		{
			BindCamera();
		}

		private void BindCamera()
		{
			base.Container.Bind<Camera>().WithId("MainCamera").FromInstance(mainCameraInScene)
				.AsSingle();
		}
	}
}
