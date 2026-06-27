using Restory.Utils;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class MaterialsPoolInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<MaterialsPool>().AsSingle().CopyIntoAllSubContainers();
		}
	}
}
