using System;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "fileName", "lastAccessTime", "lastAccessTimeString" })]
	public class ES3UserType_SaveFileInfo : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_SaveFileInfo()
			: base(typeof(SaveFileInfo))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			SaveFileInfo saveFileInfo = (SaveFileInfo)obj;
			writer.WriteProperty("fileName", saveFileInfo.fileName, ES3Type_string.Instance);
			writer.WriteProperty("lastAccessTime", saveFileInfo.lastAccessTime, ES3Type_DateTime.Instance);
			writer.WriteProperty("lastAccessTimeString", saveFileInfo.lastAccessTimeString, ES3Type_string.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			SaveFileInfo saveFileInfo = (SaveFileInfo)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "fileName":
					saveFileInfo.fileName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "lastAccessTime":
					saveFileInfo.lastAccessTime = reader.Read<DateTime>(ES3Type_DateTime.Instance);
					break;
				case "lastAccessTimeString":
					saveFileInfo.lastAccessTimeString = reader.Read<string>(ES3Type_string.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			SaveFileInfo saveFileInfo = new SaveFileInfo();
			ReadObject<T>(reader, saveFileInfo);
			return saveFileInfo;
		}
	}
}
