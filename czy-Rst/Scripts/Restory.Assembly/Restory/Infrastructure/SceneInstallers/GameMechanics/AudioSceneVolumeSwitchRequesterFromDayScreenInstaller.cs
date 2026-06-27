using Restory.Audio;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class AudioSceneVolumeSwitchRequesterFromDayScreenInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesTo<AudioSceneVolumeSwitchRequesterFromDayScreen>().FromNew().AsSingle();
		}
	}
}
