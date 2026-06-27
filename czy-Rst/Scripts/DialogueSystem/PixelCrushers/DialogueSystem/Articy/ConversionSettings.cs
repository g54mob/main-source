using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy
{
	public class ConversionSettings
	{
		public enum DropdownOverrideMode
		{
			UseGlobalSetting = 0,
			Int = 1,
			TechnicalName = 2,
			DisplayName = 3
		}

		[Serializable]
		public class DropdownOverrideSetting
		{
			public string id = string.Empty;

			public DropdownOverrideMode mode;

			public DropdownOverrideSetting()
			{
			}

			public DropdownOverrideSetting(string id, DropdownOverrideMode mode = DropdownOverrideMode.UseGlobalSetting)
			{
				this.id = id;
				this.mode = mode;
			}
		}

		private Dictionary<string, ConversionSetting> dict = new Dictionary<string, ConversionSetting>();

		public List<ConversionSetting> list = new List<ConversionSetting>();

		private Dictionary<string, DropdownOverrideSetting> dropdownOverrideDict = new Dictionary<string, DropdownOverrideSetting>();

		public List<DropdownOverrideSetting> dropdownOverrideList = new List<DropdownOverrideSetting>();

		public static ConversionSettings FromXml(string xml)
		{
			ConversionSettings conversionSettings = null;
			if (string.IsNullOrEmpty(xml))
			{
				conversionSettings = new ConversionSettings();
			}
			else
			{
				conversionSettings = new XmlSerializer(typeof(ConversionSettings)).Deserialize(new StringReader(xml)) as ConversionSettings;
				conversionSettings?.AfterDeserialization();
			}
			return conversionSettings;
		}

		public string ToXml()
		{
			BeforeSerialization();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConversionSettings));
			StringWriter stringWriter = new StringWriter();
			xmlSerializer.Serialize(stringWriter, this);
			return stringWriter.ToString();
		}

		private void BeforeSerialization()
		{
			list.Clear();
			foreach (KeyValuePair<string, ConversionSetting> item in dict)
			{
				list.Add(item.Value);
			}
			dropdownOverrideList.Clear();
			foreach (KeyValuePair<string, DropdownOverrideSetting> item2 in dropdownOverrideDict)
			{
				dropdownOverrideList.Add(item2.Value);
			}
		}

		private void AfterDeserialization()
		{
			dict.Clear();
			foreach (ConversionSetting item in list)
			{
				dict.Add(item.Id, item);
			}
			dropdownOverrideDict.Clear();
			foreach (DropdownOverrideSetting dropdownOverride in dropdownOverrideList)
			{
				dropdownOverrideDict.Add(dropdownOverride.id, dropdownOverride);
			}
		}

		public void Clear()
		{
			dict.Clear();
			list.Clear();
			dropdownOverrideDict.Clear();
			dropdownOverrideList.Clear();
		}

		public ConversionSetting GetConversionSetting(string Id)
		{
			if (string.IsNullOrEmpty(Id))
			{
				return null;
			}
			if (!dict.ContainsKey(Id))
			{
				dict[Id] = new ConversionSetting(Id);
			}
			return dict[Id];
		}

		public bool ConversionSettingExists(string Id)
		{
			if (!string.IsNullOrEmpty(Id))
			{
				return dict.ContainsKey(Id);
			}
			return false;
		}

		public DropdownOverrideSetting GetDropdownOverrideSetting(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return null;
			}
			if (!dropdownOverrideDict.ContainsKey(id))
			{
				DropdownOverrideSetting dropdownOverrideSetting = new DropdownOverrideSetting(id);
				dropdownOverrideDict.Add(id, dropdownOverrideSetting);
				dropdownOverrideList.Add(dropdownOverrideSetting);
			}
			return dropdownOverrideDict[id];
		}

		public void AllDropdownOverrides(DropdownOverrideMode mode)
		{
			foreach (DropdownOverrideSetting dropdownOverride in dropdownOverrideList)
			{
				dropdownOverride.mode = mode;
			}
		}
	}
}
