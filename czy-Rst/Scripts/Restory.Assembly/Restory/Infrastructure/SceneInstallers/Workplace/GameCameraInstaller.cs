using Restory.Gameplay;
using Restory.Gameplay.GameView;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.Workplace
{
	public class GameCameraInstaller : MonoInstaller
	{
		[SerializeField]
		private Camera gameCamera;

		[SerializeField]
		private DeviceSpotLight deviceSpotLight;

		[SerializeField]
		private LightTimeView deviceSpotTimeView;

		[SerializeField]
		private GameViewController gameViewController;

		public override void InstallBindings()
		{
			BindCamera();
			BindDeviceSpotLight();
			BindGameViewController();
		}

		private void BindCamera()
		{
			base.Container.Bind<Camera>().WithId("GameCamera").FromInstance(gameCamera)
				.AsSingle();
		}

		private void BindDeviceSpotLight()
		{
			base.Container.BindInterfacesAndSelfTo<DeviceSpotLight>().FromInstance(deviceSpotLight).AsSingle();
			base.Container.Bind<LightTimeView>().WithId("DeviceSpotLightTimeView").FromInstance(deviceSpotTimeView)
				.AsCached();
		}

		private void BindGameViewController()
		{
			base.Container.BindInterfacesAndSelfTo<GameViewController>().FromInstance(gameViewController).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CameraDirectionSwitcher>().FromComponentOn(gameViewController.gameObject).AsSingle();
		}
	}
}
