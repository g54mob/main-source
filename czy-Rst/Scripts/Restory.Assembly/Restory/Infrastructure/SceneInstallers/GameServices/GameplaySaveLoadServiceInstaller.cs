using Restory.Gameplay.SaveLoad;
using Restory.Gameplay.SaveLoad.Services;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class GameplaySaveLoadServiceInstaller : MonoInstaller
	{
		public sealed override void InstallBindings()
		{
			InstallGameplaySaveLoadService();
			InstallGameplaySaveLoadRegistry();
		}

		private void InstallGameplaySaveLoadRegistry()
		{
			base.Container.BindInterfacesAndSelfTo<GameplaySaveLoadRegistry>().FromNewComponentOnNewGameObject().AsSingle();
		}

		private void InstallGameplaySaveLoadService()
		{
			base.Container.BindInterfacesAndSelfTo<GameplaySaveLoadService>().FromNewComponentOnNewGameObject().AsSingle();
		}
	}
}
