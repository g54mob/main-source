using Restory.Gameplay.Competitions;
using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.Workplace
{
	public class WorkSurfaceInstaller : MonoInstaller
	{
		[SerializeField]
		private WorkSurface workSurface;

		[SerializeField]
		private WorkplaceRugSwitcher workplaceRugSwitcher;

		[SerializeField]
		private CompetitionTimerView competitionTimer;

		public override void InstallBindings()
		{
			InstallWorkSurface();
			InstallRugSwitcher();
		}

		private void InstallWorkSurface()
		{
			base.Container.BindInterfacesAndSelfTo<WorkSurface>().FromComponentOn(workSurface.gameObject).AsSingle();
		}

		private void InstallRugSwitcher()
		{
			base.Container.Bind<WorkplaceRugSwitcher>().FromComponentOn(workplaceRugSwitcher.gameObject).AsSingle();
			base.Container.Bind<CompetitionTimerView>().FromComponentOn(competitionTimer.gameObject).AsSingle();
		}
	}
}
