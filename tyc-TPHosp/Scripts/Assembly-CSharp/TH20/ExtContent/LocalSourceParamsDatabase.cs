using System;
using System.Collections.Generic;
using System.IO;
using FullSerializerSave;

namespace TH20.ExtContent
{
	public class LocalSourceParamsDatabase
	{
		private Dictionary<string, Dictionary<string, string>> _database;

		private string _localSourceParamsDBFolderSpec;

		private string _localSourceParamsDBFilename;

		private string _databaseJSONFileSpec;

		public Dictionary<string, Dictionary<string, string>> Database => _database;

		public void Init(string localSourceParamsDBFolderSpec, string localSourceParamsDBFilename)
		{
			_localSourceParamsDBFolderSpec = localSourceParamsDBFolderSpec;
			_localSourceParamsDBFilename = localSourceParamsDBFilename;
			_database = new Dictionary<string, Dictionary<string, string>>();
			_databaseJSONFileSpec = ExtContentUtils.GetPathSpec(_localSourceParamsDBFolderSpec, _localSourceParamsDBFilename);
			_databaseJSONFileSpec = ExtContentUtils.NormalisePathSpec(_databaseJSONFileSpec);
			ReadJSONFile();
			ValidateItemKeyPathSpecs();
		}

		public void DeInit()
		{
			_database.Clear();
			_database = null;
		}

		public void Clear(string itemPath)
		{
			Dictionary<string, string> retItemSourceParamsDictionary = null;
			if (Get(itemPath, ref retItemSourceParamsDictionary))
			{
				retItemSourceParamsDictionary.Clear();
			}
		}

		private string GroomItemPathKey(string itemPath)
		{
			return itemPath.Replace("\\", "/");
		}

		public void Set(string itemPath, Dictionary<string, string> itemSourceParamsDictionary)
		{
			_database.Add(GroomItemPathKey(itemPath), itemSourceParamsDictionary);
		}

		public bool Get(string itemPath, ref Dictionary<string, string> retItemSourceParamsDictionary, bool bCreateIfNotFound = true)
		{
			bool flag = false;
			retItemSourceParamsDictionary = null;
			Dictionary<string, string> value = null;
			itemPath = GroomItemPathKey(itemPath);
			if (_database.TryGetValue(itemPath, out value) && value != null)
			{
				flag = true;
				retItemSourceParamsDictionary = value;
			}
			if (!flag && bCreateIfNotFound)
			{
				retItemSourceParamsDictionary = new Dictionary<string, string>();
				_database.Add(itemPath, retItemSourceParamsDictionary);
				flag = true;
			}
			if (!flag)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorObtainingSourceParamsDatabaseItem), itemPath));
			}
			return flag;
		}

		public void UpdateToFile()
		{
			WriteJSONFile();
		}

		private bool ReadJSONFile()
		{
			bool result = false;
			if (!_databaseJSONFileSpec.IsNullOrEmpty())
			{
				if (File.Exists(_databaseJSONFileSpec))
				{
					try
					{
						_database.Clear();
						string text = File.ReadAllText(_databaseJSONFileSpec);
						if (!text.IsNullOrEmpty())
						{
							fsData data = fsJsonParser.Parse(text);
							new fsSerializer().TryDeserialize(data, ref _database);
							result = true;
							ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyReadSourceParamsJSONFile), _databaseJSONFileSpec, _database.Count));
						}
						else
						{
							ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.SourceParamsDatabaseErrorReadingJSON), _databaseJSONFileSpec));
						}
					}
					catch (Exception ex)
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.SourceParamsDatabaseJSONReadException), _databaseJSONFileSpec, ex.ToString()));
					}
				}
				else
				{
					ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(EMessageType.SourceParamsDBJSONFileDoesNotExist), _databaseJSONFileSpec));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileReadErrorInvalidFolder)));
			}
			return result;
		}

		private bool WriteJSONFile()
		{
			bool flag = false;
			bool flag2 = false;
			if (!_databaseJSONFileSpec.IsNullOrEmpty())
			{
				if (_database.Count > 0)
				{
					new fsSerializer().TrySerialize(_database, out var data);
					string text = fsJsonPrinter.PrettyJson(data);
					if (!text.IsNullOrEmpty())
					{
						try
						{
							File.WriteAllText(_databaseJSONFileSpec, text);
							flag = true;
							ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyWroteJSONFile), _databaseJSONFileSpec, _database.Count));
						}
						catch (Exception ex)
						{
							ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileWriteErrorWriteException), _databaseJSONFileSpec, ex.ToString()));
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileWriteErrorGeneratedEmptyJSON)));
					}
				}
				else
				{
					flag2 = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (!flag && flag2)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileWriteErrorGeneral), Path.GetDirectoryName(_databaseJSONFileSpec), Path.GetFileName(_databaseJSONFileSpec), _database.Count));
			}
			return flag;
		}

		public bool ValidateItems()
		{
			bool flag = false;
			bool flag2 = false;
			while (!flag2)
			{
				flag2 = true;
				foreach (KeyValuePair<string, Dictionary<string, string>> item in _database)
				{
					string key = item.Key;
					bool flag3 = false;
					if (!key.IsNullOrEmpty() && Directory.Exists(key))
					{
						flag3 = true;
					}
					if (!flag3)
					{
						flag2 = false;
						flag = true;
						_database.Remove(item.Key);
						ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidSourceParamsDatabaseItemFound), key));
						break;
					}
				}
			}
			if (flag)
			{
				ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidSourceParamsItemsFoundUpdatingFile), _databaseJSONFileSpec, _database.Count));
				WriteJSONFile();
			}
			return flag;
		}

		private void ValidateItemKeyPathSpecs()
		{
		}
	}
}
