using System;
using Restory.UI.Presenters.CleaningToolsSelectionWindow;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public sealed class CleaningToolsSelectionWindowInstaller : Installer
	{
		[SerializeField]
		private GUI_CleaningToolsSelectionWindow windowPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<GUI_CleaningToolsSelectionWindow>().FromComponentInNewPrefab(windowPrefab).UnderTransform(GetCanvas)
				.AsSingle()
				.OnInstantiated(delegate(InjectContext context, GUI_CleaningToolsSelectionWindow instance)
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
