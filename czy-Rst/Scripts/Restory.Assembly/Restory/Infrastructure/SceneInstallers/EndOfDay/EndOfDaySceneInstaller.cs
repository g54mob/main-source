using Restory.Data.DaySwitching;
using Restory.Data.TimeSystems;
using Restory.Gameplay.TimeSystems;
using Restory.Infrastructure.SceneInstallers.GameOverlay;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.EndOfDay
{
	public class EndOfDaySceneInstaller : MonoInstaller
	{
		[SerializeField]
		private DayEndWindowInstaller dayEndWindowInstaller;

		[SerializeField]
		private DayEndCursorInstaller dayEndCursorInstaller;

		[SerializeField]
		private GameCalendar gameCalendarPrefab;

		[SerializeField]
		private DaySwitchingSettings daySwitchingSettings;

		[SerializeField]
		private TimeSettings timeSettings;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<TimeSettingsProvidingService>().FromNew().AsSingle()
				.WithArguments(timeSettings);
			InstallGameCalendar();
			base.Container.Inject(dayEndCursorInstaller);
			dayEndCursorInstaller.InstallBindings();
			base.Container.Inject(dayEndWindowInstaller);
			dayEndWindowInstaller.InstallBindings();
			base.Container.BindInterfacesAndSelfTo<EndOfDayMain>().FromNew().AsSingle()
				.WithArguments(daySwitchingSettings);
		}

		private void InstallGameCalendar()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(gameCalendarPrefab.gameObject);
			base.Container.Bind<GameCalendar>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
