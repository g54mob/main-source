using Restory.Gameplay.InteractiveObjects;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DragObjectRegistratorInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallDragObjectRegistrator();
		}

		private void InstallDragObjectRegistrator()
		{
			base.Container.BindInterfacesAndSelfTo<DragObjectRegistrator>().AsSingle();
		}
	}
}
