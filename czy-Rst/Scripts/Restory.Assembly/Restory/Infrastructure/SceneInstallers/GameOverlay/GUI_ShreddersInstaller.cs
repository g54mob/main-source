using Restory.ObjectPools;
using Restory.UI.Presenters.Shredders;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_ShreddersInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject shredderRewardsNotificationCanvasPrefab;

		[SerializeField]
		private GameObject shredderRewardsNotificationPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<ConcreteGameObjectPool>().FromNew().WithArguments(shredderRewardsNotificationPrefab)
				.WhenInjectedInto<GUI_ShredderRewardsNotificationCanvas>();
			base.Container.Bind<GUI_ShredderRewardsNotificationCanvas>().FromComponentInNewPrefab(shredderRewardsNotificationCanvasPrefab).UnderTransform(GetCanvas)
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
