using Services.Save.Settings;
using Zenject;

namespace Infrastructure.Installers
{
	public class ControlsSettingsSaveInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<SceneControlsSettingsRegistry>().AsSingle().NonLazy();
		}
	}
}
