using Restory.Gameplay.GameDialogues;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class GameDialogueServicesInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallConfirmationService();
			InstallExplanationService();
			InstallGameWarningService();
		}

		private void InstallConfirmationService()
		{
			base.Container.BindInterfacesAndSelfTo<ConfirmationService>().FromNew().AsSingle();
		}

		private void InstallExplanationService()
		{
			base.Container.BindInterfacesAndSelfTo<ExplanationService>().FromNew().AsSingle();
		}

		private void InstallGameWarningService()
		{
			base.Container.BindInterfacesAndSelfTo<GameWarningService>().FromNew().AsSingle();
		}
	}
}
