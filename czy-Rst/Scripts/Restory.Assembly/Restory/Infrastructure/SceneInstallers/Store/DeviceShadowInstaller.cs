using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.Store
{
	public class DeviceShadowInstaller : MonoInstaller
	{
		[SerializeField]
		private DeviceShadow deviceShadow;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<DeviceShadow>().FromInstance(deviceShadow);
		}
	}
}
