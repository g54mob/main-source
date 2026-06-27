using Restory.TimeSystems;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DayEnderFromPlayerInteractionInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<DayEnderFromPlayerInteraction>().FromNew().AsSingle();
		}
	}
}
