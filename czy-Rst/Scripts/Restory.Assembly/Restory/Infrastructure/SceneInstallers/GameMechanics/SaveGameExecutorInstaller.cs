using Restory.Gameplay.SaveLoad.Services;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class SaveGameExecutorInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallSaveGameExecutor();
		}

		private void InstallSaveGameExecutor()
		{
			base.Container.BindInterfacesAndSelfTo<SaveGameExecutor>().FromNew().AsSingle();
		}
	}
}
