using System;
using Restory.UI.Presenters.DevicePaintingTool;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public sealed class DevicePainterPanelInstaller : Installer
	{
		[SerializeField]
		private GUI_DevicePainterPanel devicePainterPanelPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<GUI_DevicePainterPanel>().FromComponentInNewPrefab(devicePainterPanelPrefab).UnderTransform(GetCanvas)
				.AsSingle()
				.OnInstantiated(delegate(InjectContext context, GUI_DevicePainterPanel instance)
				{
					instance.Hide();
				});
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
