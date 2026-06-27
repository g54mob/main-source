using Restory.ObjectPools;
using Restory.UI.Presenters.WorkshopStatus;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	public class GUI_WorkshopStatusInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject statusNotificationCanvasPrefab;

		[SerializeField]
		private GameObject statusNotificationPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<ConcreteGameObjectPool>().FromNew().WithArguments(statusNotificationPrefab)
				.WhenInjectedInto<GUI_WorkshopStatusNotificationCanvas>();
			base.Container.BindInterfacesAndSelfTo<GUI_WorkshopStatusNotificationCanvas>().FromComponentInNewPrefab(statusNotificationCanvasPrefab).UnderTransform(GetCanvas)
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
