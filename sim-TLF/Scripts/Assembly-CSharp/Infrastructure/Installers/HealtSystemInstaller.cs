using Services.Health;
using Zenject;

namespace Infrastructure.Installers
{
	public class HealtSystemInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			HealthService instance = new HealthService(100f);
			base.Container.Bind<IHealthService>().WithId("Player").To<HealthService>()
				.FromInstance(instance)
				.AsSingle();
			base.Container.BindFactory<float, HealthService, HealthService.Factory>().AsTransient();
		}
	}
}
