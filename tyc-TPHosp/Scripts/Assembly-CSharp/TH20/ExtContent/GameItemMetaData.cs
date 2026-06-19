using System.Collections.Generic;
using System.IO;

namespace TH20.ExtContent
{
	public class GameItemMetaData
	{
		public const string cGameItemMetaDataFileName = "GameItemMetaData.json";

		private Dictionary<string, string> _metaDataDictionary;

		private string _installedFolderPathSpec;

		public Dictionary<string, string> MetaDataDictionary => _metaDataDictionary;

		public string InstalledFolderPathSpec => _installedFolderPathSpec;

		public GameItemMetaData(string installedFolderPathSpec)
		{
			_metaDataDictionary = new Dictionary<string, string>();
			_installedFolderPathSpec = installedFolderPathSpec;
		}

		public void Clear()
		{
			_metaDataDictionary.Clear();
		}

		public static string GetMetaDataFileSpec(string folderSpec)
		{
			return ExtContentUtils.GetPathSpec(folderSpec, "GameItemMetaData.json");
		}

		public string GetMetaDataFileSpec()
		{
			return GetMetaDataFileSpec(_installedFolderPathSpec);
		}

		public bool DoesMetaDataFileExist()
		{
			return File.Exists(GetMetaDataFileSpec());
		}

		public bool WriteMetaDataFile()
		{
			return ExtContentUtils.WriteJSONFile(_installedFolderPathSpec, "GameItemMetaData.json", _metaDataDictionary);
		}

		public bool ReadMetaDataFile()
		{
			return ExtContentUtils.ReadJSONFile(_installedFolderPathSpec, "GameItemMetaData.json", ref _metaDataDictionary);
		}

		public void Add(string key, string value)
		{
			_metaDataDictionary.Add(key, value);
		}

		public bool Get(string key, ref string value)
		{
			return ExtContentUtils.GetDictionaryValue(_metaDataDictionary, key, ref value);
		}

		public bool Get(string key, ref int value)
		{
			return ExtContentUtils.GetDictionaryValue(_metaDataDictionary, key, ref value);
		}

		public bool Get(string key, ref long value)
		{
			return ExtContentUtils.GetDictionaryValue(_metaDataDictionary, key, ref value);
		}
	}
}
