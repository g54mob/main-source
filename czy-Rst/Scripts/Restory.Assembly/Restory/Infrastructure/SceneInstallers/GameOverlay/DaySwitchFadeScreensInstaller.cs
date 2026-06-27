using System;
using Restory.Gameplay.TimeSystems;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	[Serializable]
	public sealed class DaySwitchFadeScreensInstaller : Installer
	{
		[SerializeField]
		private GUI_DaySwitchingFadeScreens prefab;

		public override void InstallBindings()
		{
			base.Container.Bind<GUI_DaySwitchingFadeScreens>().FromComponentInNewPrefab(prefab).UnderTransform(GetCanvas)
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
