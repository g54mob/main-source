using Restory.Data.DaySwitching;
using Restory.Gameplay.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class TransitionToEndOfDayServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DaySwitchingSettings daySwitchingSettings;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<TransitionToEndOfDayService>().FromNew().AsSingle()
				.WithArguments(daySwitchingSettings.TransitionToEndOfDayScenes);
		}
	}
}
