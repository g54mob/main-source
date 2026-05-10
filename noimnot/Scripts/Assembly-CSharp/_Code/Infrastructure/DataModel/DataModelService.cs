using _Code.Infrastructure.DataModel.Models.GameSave;
using _Code.Infrastructure.DataModel.Models.Meta;
using _Code.Infrastructure.DataModel.Models.Settings;
using _Scripts.Services.DataModel;
using _Scripts.Services.DataModel.DataStorages;

namespace _Code.Infrastructure.DataModel
{
	public sealed class DataModelService : IDataModelService
	{
		private readonly PrefsDataStorage _prefsDataStorage;

		private readonly EncryptedPrefsDataStorage _encryptedPrefsDataStorage;

		private readonly RamDataStorage _ramDataStorage;

		public IGameSaveDataHandler GameSaveDataHandler { get; private set; }

		public ISettingsPrefsDataHandler SettingsPrefsDataHandler { get; private set; }

		public IMetaPrefsDataHandler MetaPrefsDataHandler { get; private set; }

		private void Init()
		{
		}
	}
}
