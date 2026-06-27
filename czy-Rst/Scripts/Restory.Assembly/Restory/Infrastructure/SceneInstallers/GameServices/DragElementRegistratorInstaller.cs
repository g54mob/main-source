using Restory.Gameplay.Elements;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DragElementRegistratorInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallDragElementRegistrator();
		}

		private void InstallDragElementRegistrator()
		{
			base.Container.BindInterfacesAndSelfTo<DragElementRegistrator>().AsSingle();
		}
	}
}
