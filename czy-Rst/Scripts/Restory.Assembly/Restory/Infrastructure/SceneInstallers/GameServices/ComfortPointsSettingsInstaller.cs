using Restory.Data.WorkshopStatus;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class ComfortPointsSettingsInstaller : MonoInstaller
	{
		[SerializeField]
		private ComfortPointsSettings comfortPointsSettings;

		public override void InstallBindings()
		{
			base.Container.Bind<ComfortPointsSettings>().FromInstance(comfortPointsSettings).AsSingle();
		}
	}
}
