using Restory.Data.GameWarnings;
using Restory.Gameplay.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class MainDayTimeSwitchingProcessingServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameWarning dayEndedWarning;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<MainDayTimesSwitchingProcessingService>().FromNew().AsSingle();
		}
	}
}
