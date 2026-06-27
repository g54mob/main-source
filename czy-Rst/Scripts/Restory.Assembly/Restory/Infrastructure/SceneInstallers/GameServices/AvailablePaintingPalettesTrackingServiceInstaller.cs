using Restory.Data.Equipment;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class AvailablePaintingPalettesTrackingServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private PaintingPaletteInfoDatabase paintingPaletteInfoDatabase;

		[SerializeField]
		private AvailablePaintingPalettesTrackingService prefab;

		public override void InstallBindings()
		{
			InstallDatabase();
			InstallTrackingService();
		}

		private void InstallDatabase()
		{
			base.Container.Bind<PaintingPaletteInfoDatabase>().FromInstance(paintingPaletteInfoDatabase).AsSingle();
		}

		private void InstallTrackingService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.Bind<AvailablePaintingPalettesTrackingService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
