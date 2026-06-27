using System;
using Restory.UI.Presenters.DayEndWindow;
using Restory.UI.Views.DayEndWindow;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	[Serializable]
	public sealed class DayEndWindowInstaller : Installer
	{
		[SerializeField]
		private GUI_DayEndWindow windowPrefab;

		[SerializeField]
		private GUI_SinglePayment singlePaymentPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<PaymentGuisPool>().FromNew().AsSingle()
				.WithArguments(singlePaymentPrefab.gameObject)
				.WhenInjectedInto<GUI_MoneyReceiptView>();
			base.Container.Bind<GUI_DayEndWindow>().FromComponentInNewPrefab(windowPrefab).UnderTransform(GetCanvas)
				.AsSingle()
				.OnInstantiated(delegate(InjectContext context, GUI_DayEndWindow presenter)
				{
					presenter.Hide();
				});
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
