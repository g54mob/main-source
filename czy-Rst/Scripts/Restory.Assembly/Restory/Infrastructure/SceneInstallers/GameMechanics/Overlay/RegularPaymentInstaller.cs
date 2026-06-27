using System;
using Restory.UI.Presenters.RegularPayment;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public sealed class RegularPaymentInstaller : Installer
	{
		[SerializeField]
		private GameObject guiRegularPaymentrefab;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_RegularPayment>().FromComponentInNewPrefab(guiRegularPaymentrefab).UnderTransform(GetCanvas)
				.AsSingle()
				.OnInstantiated(delegate(InjectContext c, GUI_RegularPayment i)
				{
					i.Hide(instant: true);
				});
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
