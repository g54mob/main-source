using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PWCommon5.Localization
{
	public class LanguagePack
	{
		private static IDictionary<string, LanguagePack> ms_loadedPacks = new Dictionary<string, LanguagePack>();

		public const string VERSION = "3";

		public string Version;

		public double LastUpdated;

		public List<LocalizationCategory> Categories;

		public IDictionary<string, LocalizationItem> Items;

		private string m_path;

		private event Action OnChange;

		public LanguagePack()
		{
			Version = "3";
			LastUpdated = Utils.GetFrapoch();
			Categories = new List<LocalizationCategory>();
			Items = new Dictionary<string, LocalizationItem>();
		}

		public LanguagePack(LocalizationItem[] items)
		{
			Version = "3";
			LastUpdated = Utils.GetFrapoch();
			Categories = new List<LocalizationCategory>();
			LocalizationCategory item = new LocalizationCategory("Main")
			{
				Items = new List<LocalizationItem>(items)
			};
			Categories.Add(item);
			Items = new Dictionary<string, LocalizationItem>();
			foreach (LocalizationCategory category in Categories)
			{
				for (int i = 0; i < category.Items.Count; i++)
				{
					if (category.Items[i] != null)
					{
						Items[category.Items[i].Key] = category.Items[i];
					}
				}
			}
		}

		public LanguagePack(LocalizationCategory[] categories)
		{
			Version = "3";
			LastUpdated = Utils.GetFrapoch();
			Categories = new List<LocalizationCategory>(categories);
			Items = new Dictionary<string, LocalizationItem>();
			foreach (LocalizationCategory category in Categories)
			{
				if (category == null)
				{
					continue;
				}
				for (int i = 0; i < category.Items.Count; i++)
				{
					if (category.Items[i] != null)
					{
						Items[category.Items[i].Key] = category.Items[i];
					}
				}
			}
		}

		public static LanguagePack Load(string path)
		{
			if (ms_loadedPacks.ContainsKey(path) && ms_loadedPacks[path] != null)
			{
				return ms_loadedPacks[path];
			}
			LanguagePack languagePack = new LanguagePack();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				languagePack.Version = (string)binaryFormatter.Deserialize(stream);
				switch (languagePack.Version)
				{
				case "1":
					languagePack.LoadV1(binaryFormatter, stream);
					ms_loadedPacks[path] = languagePack;
					break;
				case "3":
					languagePack.LoadV3(binaryFormatter, stream);
					ms_loadedPacks[path] = languagePack;
					break;
				default:
					throw new ApplicationException("Unknown language pack v" + languagePack.Version);
				}
			}
			languagePack.m_path = path;
			return ms_loadedPacks[path];
		}

		public void ReLoad()
		{
			if (string.IsNullOrEmpty(m_path))
			{
				Debug.LogWarning("Can only reload language packs that were loaded from file.");
				return;
			}
			Categories = new List<LocalizationCategory>();
			Items = new Dictionary<string, LocalizationItem>();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using Stream stream = new FileStream(m_path, FileMode.Open, FileAccess.Read, FileShare.Read);
			Version = (string)binaryFormatter.Deserialize(stream);
			Debug.Log("Version: " + Version);
			switch (Version)
			{
			case "1":
				LoadV1(binaryFormatter, stream);
				break;
			case "3":
				LoadV3(binaryFormatter, stream);
				break;
			default:
				throw new ApplicationException("Unknown language pack v" + Version);
			}
		}

		private void LoadV1(BinaryFormatter formatter, Stream stream)
		{
			LastUpdated = (double)formatter.Deserialize(stream);
			int num = (int)formatter.Deserialize(stream);
			for (int i = 0; i < num; i++)
			{
				LocalizationCategory localizationCategory = new LocalizationCategory((string)formatter.Deserialize(stream));
				int num2 = (int)formatter.Deserialize(stream);
				for (int j = 0; j < num2; j++)
				{
					LocalizationItem localizationItem = new LocalizationItem();
					localizationItem.Key = (string)formatter.Deserialize(stream);
					localizationItem.Val = (string)formatter.Deserialize(stream);
					localizationItem.Tooltip = (string)formatter.Deserialize(stream);
					localizationItem.Help = (string)formatter.Deserialize(stream);
					localizationItem.Context = (string)formatter.Deserialize(stream);
					localizationCategory.Items.Add(localizationItem);
					Items[localizationItem.Key] = localizationItem;
				}
				Categories.Add(localizationCategory);
			}
		}

		private void LoadV3(BinaryFormatter formatter, Stream stream)
		{
			LastUpdated = (double)formatter.Deserialize(stream);
			int num = (int)formatter.Deserialize(stream);
			for (int i = 0; i < num; i++)
			{
				LocalizationCategory localizationCategory = new LocalizationCategory((string)formatter.Deserialize(stream));
				int num2 = (int)formatter.Deserialize(stream);
				for (int j = 0; j < num2; j++)
				{
					LocalizationItem localizationItem = new LocalizationItem();
					localizationItem.Key = (string)formatter.Deserialize(stream);
					localizationItem.Val = (string)formatter.Deserialize(stream);
					localizationItem.Tooltip = (string)formatter.Deserialize(stream);
					localizationItem.Help = (string)formatter.Deserialize(stream);
					localizationItem.Context = (string)formatter.Deserialize(stream);
					int num3 = (int)formatter.Deserialize(stream);
					for (int k = 0; k < num3; k++)
					{
						OnlineHelpItem onlineHelpItem = new OnlineHelpItem();
						onlineHelpItem.URL = (string)formatter.Deserialize(stream);
						onlineHelpItem.Val = (string)formatter.Deserialize(stream);
						onlineHelpItem.OnlineHelpType = (OnlineHelpType)formatter.Deserialize(stream);
						localizationItem.OnlineHelpItems.Add(onlineHelpItem);
					}
					localizationCategory.Items.Add(localizationItem);
					Items[localizationItem.Key] = localizationItem;
				}
				Categories.Add(localizationCategory);
			}
		}

		[Conditional("UNITY_EDITOR")]
		public void Validate()
		{
			if (this.OnChange != null)
			{
				this.OnChange();
			}
		}

		[Conditional("UNITY_EDITOR")]
		public void AddOnChangeAction(Action action)
		{
			OnChange += action;
		}

		[Conditional("UNITY_EDITOR")]
		public void RemoveOnChangeAction(Action action)
		{
			OnChange -= action;
		}
	}
}
