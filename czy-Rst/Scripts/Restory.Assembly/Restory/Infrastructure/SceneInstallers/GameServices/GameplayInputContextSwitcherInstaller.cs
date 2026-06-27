using Restory.Gameplay.PlayerInput;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class GameplayInputContextSwitcherInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallGameplayInputContextSwitcher();
		}

		private void InstallGameplayInputContextSwitcher()
		{
			base.Container.BindInterfacesAndSelfTo<GameplayRewiredContextSwitcher>().AsSingle();
		}
	}
}
