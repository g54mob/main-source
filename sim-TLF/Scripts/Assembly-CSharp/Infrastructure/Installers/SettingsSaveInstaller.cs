using Services.Save.Settings;
using Zenject;

namespace Infrastructure.Installers
{
	public class SettingsSaveInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<SceneGraphicsSettingsRegistry>().AsSingle();
		}
	}
}
