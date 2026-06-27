using Restory.Data.SaveLoad.FullSerializerWrappers.GameEntities;
using Restory.Data.SaveLoad.FullSerializerWrappers.GameScenesPresets;
using Zenject;

namespace Restory.Data.SaveLoad.FullSerializerWrappers
{
	public class GameEntityFullSerializer : FullSerializerWrapperBase
	{
		public class Factory : PlaceholderFactory<GameEntityFullSerializer>
		{
		}

		[Inject]
		public GameEntityFullSerializer(GameEntityCustomConverter.Factory gameEntityCustomConverterFactory, GameplayProgressSaveDataProcessor.Factory gameplayProgressSaveDataProcessorFactory, GameScenesPresetCustomConverter.Factory gameScenesPresetCustomConverterFactory, GameScenesPresetProcessor.Factory gameScenesPresetProcessorFactory)
		{
			GameEntityCustomConverter converter = gameEntityCustomConverterFactory.Create();
			FsSerializer.AddConverter(converter);
			GameScenesPresetCustomConverter converter2 = gameScenesPresetCustomConverterFactory.Create();
			FsSerializer.AddConverter(converter2);
			GameEntityProcessor processor = new GameEntityProcessor();
			FsSerializer.AddProcessor(processor);
			GameplayProgressSaveDataProcessor processor2 = gameplayProgressSaveDataProcessorFactory.Create();
			FsSerializer.AddProcessor(processor2);
			GameScenesPresetProcessor processor3 = gameScenesPresetProcessorFactory.Create();
			FsSerializer.AddProcessor(processor3);
		}
	}
}
