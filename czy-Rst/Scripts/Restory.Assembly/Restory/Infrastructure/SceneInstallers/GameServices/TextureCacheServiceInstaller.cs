using Restory.Gameplay.TextureMasks;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class TextureCacheServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<TextureCacheService>().AsSingle();
		}
	}
}
