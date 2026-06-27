using System;
using Restory.UI.Views.Tooltips;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public sealed class TooltipContainerInstaller : Installer
	{
		[SerializeField]
		private GameObject tooltipContainerPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<TooltipContainer>().FromComponentInNewPrefab(tooltipContainerPrefab).UnderTransform(GetCanvas)
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_TooltipsLayerCanvas>().transform;
		}
	}
}
