using Restory.Data.SaveLoad.FullSerializerWrappers;
using Restory.Data.SaveLoad.FullSerializerWrappers.GameScenesPresets;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class CommonFullSerializerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindFactory<GameScenesPresetCustomConverter, GameScenesPresetCustomConverter.Factory>();
			base.Container.BindFactory<GameScenesPresetProcessor, GameScenesPresetProcessor.Factory>();
			base.Container.BindFactory<CommonFullSerializer, CommonFullSerializer.Factory>();
		}
	}
}
