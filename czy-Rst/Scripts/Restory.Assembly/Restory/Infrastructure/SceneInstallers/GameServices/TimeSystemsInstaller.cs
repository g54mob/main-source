using Restory.Data.TimeSystems;
using Restory.Gameplay.TimeSystems;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class TimeSystemsInstaller : MonoInstaller
	{
		[SerializeField]
		private TimeSettings timeSettings;

		[SerializeField]
		private TickSystem tickSystemPrefab;

		[SerializeField]
		private GameCalendar gameCalendarPrefab;

		[SerializeField]
		private MainDayTimeSwitchingService mainDayTimeSwitchingServicePrefab;

		[SerializeField]
		private TimeSystemsTemporaryTestTool testToolPrefab;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<TimeSettingsProvidingService>().FromNew().AsSingle()
				.WithArguments(timeSettings);
			InstallTickSystem();
			InstallGameCalendar();
			InstallMainDayTimeSwitchingService();
			base.Container.BindInterfacesAndSelfTo<TimeSystem>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<CozyWeatherTimeAdapter>().FromNew().AsSingle();
			InstallTimeIntervalsTracker();
			InstallTestTool();
		}

		private void InstallTickSystem()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(tickSystemPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<TickSystem>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallGameCalendar()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(gameCalendarPrefab.gameObject);
			base.Container.Bind<GameCalendar>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallMainDayTimeSwitchingService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(mainDayTimeSwitchingServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<MainDayTimeSwitchingService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallTimeIntervalsTracker()
		{
			base.Container.BindInterfacesAndSelfTo<TimeIntervalsTracker>().FromNew().AsSingle();
		}

		private void InstallTestTool()
		{
			base.Container.InstantiateAndQueueForInject(testToolPrefab.gameObject);
		}
	}
}
