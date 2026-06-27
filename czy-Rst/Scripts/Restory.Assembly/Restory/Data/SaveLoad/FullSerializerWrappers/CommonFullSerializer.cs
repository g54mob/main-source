using Restory.Data.SaveLoad.FullSerializerWrappers.GameScenesPresets;
using Zenject;

namespace Restory.Data.SaveLoad.FullSerializerWrappers
{
	public class CommonFullSerializer : FullSerializerWrapperBase
	{
		public class Factory : PlaceholderFactory<CommonFullSerializer>
		{
		}

		[Inject]
		public CommonFullSerializer(GameScenesPresetCustomConverter.Factory gameScenesPresetCustomConverterFactory, GameScenesPresetProcessor.Factory gameScenesPresetProcessorFactory)
		{
			GameScenesPresetCustomConverter converter = gameScenesPresetCustomConverterFactory.Create();
			FsSerializer.AddConverter(converter);
			FsSerializer.AddConverter(new PartialGameplayProgressSaveDataV01Converter());
			FsSerializer.AddConverter(new PartialGameplayProgressSaveDataV02Converter());
			FsSerializer.AddConverter(new PartialGameplayProgressSaveDataV03Converter());
			FsSerializer.AddConverter(new PartialGameplayProgressSaveDataV04Converter());
			GameScenesPresetProcessor processor = gameScenesPresetProcessorFactory.Create();
			FsSerializer.AddProcessor(processor);
		}

		public CommonFullSerializer()
		{
		}
	}
}
