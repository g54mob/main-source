using System;
using System.Collections.Generic;
using System.IO;

namespace TH20.ExtContent
{
	public class WorkshopItemMetaData
	{
		public const string cWorkshopMetaDataFileName = "WorkshopMetaData.json";

		public const int cExpectedNumJsonItems = 2;

		public const string cKey_VersionNumber = "VersionNumber";

		public const string cKey_PublishedFileId = "PublishedFileId";

		public const string cKey_ContentType = "ContentType";

		public const string cKey_Title = "Title";

		public const string cKey_Description = "Description";

		public const string cKey_PreviewFileName = "PreviewFileName";

		public const string cKey_SourcePreviewFileSpecHash = "SourcePreviewFileSpecHash";

		public const string cKey_Visibility = "Visibility";

		public const string cKey_GameItemUpdateTime = "GameItemUpdateTime";

		public const string cKey_FirstItemContentType = "FirstItemContentType";

		public const string cKey_FirstItemContentSubType = "FirstItemContentSubType";

		public const string cKey_NumGameItems = "NumGameItems";

		private int _versionNumberOnDisk = -1;

		private string _publishedFileId;

		private EContentType _contentType;

		private string _title;

		private string _description;

		private string _previewFileName;

		private EItemVisibility _visibility;

		private long _gameItemUpdateTime;

		private uint _sourcePreviewFileSpecHash;

		private EContentType _firstItemContentType;

		private string _firstItemContentSubType;

		private int _numGameItems;

		public int VersionNumberOnDisk
		{
			get
			{
				return _versionNumberOnDisk;
			}
			set
			{
				_versionNumberOnDisk = value;
			}
		}

		public string PublishedFileId
		{
			get
			{
				return _publishedFileId;
			}
			set
			{
				_publishedFileId = value;
			}
		}

		public EContentType ContentType
		{
			get
			{
				return _contentType;
			}
			set
			{
				_contentType = value;
			}
		}

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public string PreviewFileName
		{
			get
			{
				return _previewFileName;
			}
			set
			{
				_previewFileName = value;
			}
		}

		public EItemVisibility Visibility
		{
			get
			{
				return _visibility;
			}
			set
			{
				_visibility = value;
			}
		}

		public long GameItemUpdateTime
		{
			get
			{
				return _gameItemUpdateTime;
			}
			set
			{
				_gameItemUpdateTime = value;
			}
		}

		public uint SourcePreviewFileSpecHash
		{
			get
			{
				return _sourcePreviewFileSpecHash;
			}
			set
			{
				_sourcePreviewFileSpecHash = value;
			}
		}

		public EContentType FirstItemContentType
		{
			get
			{
				return _firstItemContentType;
			}
			set
			{
				_firstItemContentType = value;
			}
		}

		public string FirstItemContentSubType
		{
			get
			{
				return _firstItemContentSubType;
			}
			set
			{
				_firstItemContentSubType = value;
			}
		}

		public int NumGameItems
		{
			get
			{
				return _numGameItems;
			}
			set
			{
				_numGameItems = value;
			}
		}

		public WorkshopItemMetaData()
		{
			Reset();
		}

		public void Reset()
		{
			_versionNumberOnDisk = -1;
			_publishedFileId = string.Empty;
			_contentType = EContentType.None;
			_title = string.Empty;
			_description = string.Empty;
			_previewFileName = string.Empty;
			_visibility = EItemVisibility.Public;
			_gameItemUpdateTime = 0L;
			_firstItemContentType = EContentType.None;
			_firstItemContentSubType = string.Empty;
			_numGameItems = 0;
		}

		public WorkshopItemMetaData(int versionNumberOnDisk)
		{
			_versionNumberOnDisk = versionNumberOnDisk;
		}

		public bool IsValid()
		{
			return _versionNumberOnDisk >= 0;
		}

		public static string GetMetaDataFileSpec(string assetFolderPathSpec, string fileName = "WorkshopMetaData.json")
		{
			return ExtContentUtils.GetPathSpec(assetFolderPathSpec, fileName);
		}

		public bool WriteToMetaDataFile(string folderPathSpec)
		{
			bool flag = false;
			bool flag2 = false;
			if (IsValid())
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("VersionNumber", $"{_versionNumberOnDisk}");
				dictionary.Add("PublishedFileId", _publishedFileId);
				dictionary.Add("ContentType", ExtContentType.ContentTypeToString(_contentType));
				dictionary.Add("Title", _title);
				dictionary.Add("Description", _description);
				dictionary.Add("PreviewFileName", _previewFileName);
				dictionary.Add("SourcePreviewFileSpecHash", _sourcePreviewFileSpecHash.ToString());
				dictionary.Add("Visibility", _visibility.ToString());
				dictionary.Add("GameItemUpdateTime", $"{_gameItemUpdateTime}");
				dictionary.Add("FirstItemContentType", ExtContentType.ContentTypeToString(_firstItemContentType));
				dictionary.Add("FirstItemContentSubType", _firstItemContentSubType);
				dictionary.Add("NumGameItems", _numGameItems.ToString());
				if (ExtContentUtils.WriteJSONFile(folderPathSpec, "WorkshopMetaData.json", dictionary))
				{
					flag = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (!flag && flag2)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopMetaDataFileWriteErrorGeneral), _versionNumberOnDisk, folderPathSpec));
			}
			return flag;
		}

		public static bool DoesMetaDataFileExist(string folderPathSpec)
		{
			return File.Exists(GetMetaDataFileSpec(folderPathSpec));
		}

		public bool ReadFromMetaDataFile(string folderPathSpec)
		{
			bool result = false;
			Dictionary<string, string> values = new Dictionary<string, string>();
			string metaDataFileSpec = GetMetaDataFileSpec(folderPathSpec);
			if (ExtContentUtils.ReadJSONFile(folderPathSpec, "WorkshopMetaData.json", ref values))
			{
				string retValue = string.Empty;
				string retValue2 = string.Empty;
				string retValue3 = string.Empty;
				string retValue4 = string.Empty;
				string retValue5 = string.Empty;
				string retValue6 = string.Empty;
				string retValue7 = string.Empty;
				string retValue8 = string.Empty;
				string retValue9 = string.Empty;
				string retValue10 = string.Empty;
				string retValue11 = string.Empty;
				string retValue12 = string.Empty;
				bool num = true && ExtContentUtils.GetDictionaryValue(values, "VersionNumber", ref retValue) && ExtContentUtils.GetDictionaryValue(values, "PublishedFileId", ref retValue2) && ExtContentUtils.GetDictionaryValue(values, "ContentType", ref retValue3);
				ExtContentUtils.GetDictionaryValue(values, "Title", ref retValue4);
				ExtContentUtils.GetDictionaryValue(values, "Description", ref retValue5);
				ExtContentUtils.GetDictionaryValue(values, "PreviewFileName", ref retValue6);
				ExtContentUtils.GetDictionaryValue(values, "SourcePreviewFileSpecHash", ref retValue7);
				ExtContentUtils.GetDictionaryValue(values, "Visibility", ref retValue8);
				ExtContentUtils.GetDictionaryValue(values, "GameItemUpdateTime", ref retValue9);
				ExtContentUtils.GetDictionaryValue(values, "FirstItemContentType", ref retValue10);
				ExtContentUtils.GetDictionaryValue(values, "FirstItemContentSubType", ref retValue11);
				ExtContentUtils.GetDictionaryValue(values, "NumGameItems", ref retValue12);
				if (retValue9.IsNullOrEmpty())
				{
					retValue9 = "0";
				}
				if (num)
				{
					_versionNumberOnDisk = ((!retValue.IsNullOrEmpty()) ? Convert.ToInt32(retValue) : 0);
					_publishedFileId = retValue2;
					_contentType = ExtContentType.StringToContentType(retValue3);
					_title = retValue4;
					_description = retValue5;
					_previewFileName = retValue6;
					_sourcePreviewFileSpecHash = ((!retValue7.IsNullOrEmpty()) ? Convert.ToUInt32(retValue7) : 0u);
					_visibility = WorkshopUtils.StringToVisibilityType(retValue8);
					_gameItemUpdateTime = ((!retValue9.IsNullOrEmpty()) ? Convert.ToInt64(retValue9) : 0);
					_firstItemContentType = ExtContentType.StringToContentType(retValue10);
					_firstItemContentSubType = retValue11;
					_numGameItems = ((!retValue12.IsNullOrEmpty()) ? Convert.ToInt32(retValue12) : 0);
					result = true;
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopMetaDataFileReadErrorExtractingValues), metaDataFileSpec));
				}
			}
			return result;
		}
	}
}
