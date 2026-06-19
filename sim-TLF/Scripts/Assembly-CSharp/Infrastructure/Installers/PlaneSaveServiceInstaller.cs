using Services.Save.Plane;
using Zenject;

namespace Infrastructure.Installers
{
	public class PlaneSaveServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<PlaneSaveRegistry>().FromNew().AsSingle();
		}
	}
}
