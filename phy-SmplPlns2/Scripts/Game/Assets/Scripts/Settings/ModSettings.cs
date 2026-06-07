using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Jundroo.Common.Settings;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class ModSettings : IModSettings
	{
		private List<SettingsCategory> _categories;

		private string _filePath;

		private XDocument _xml;

		public IReadOnlyList<SettingsCategory> Categories => _categories;

		private ModSettings()
		{
		}

		public static ModSettings Create(string filePath)
		{
			ModSettings modSettings = new ModSettings();
			modSettings.Initialize(filePath);
			return modSettings;
		}

		public T GetCategory<T>() where T : SettingsCategory<T>
		{
			foreach (SettingsCategory category in _categories)
			{
				if (category is T result)
				{
					return result;
				}
			}
			return null;
		}

		public SettingsCategory GetCategoryByName(string categoryName)
		{
			return _categories.FirstOrDefault((SettingsCategory x) => x.CategoryName == categoryName);
		}

		public bool HasAnyUnsavedChanges()
		{
			return Categories.HasUnsavedChanges();
		}

		public void RegisterCategory(SettingsCategory category)
		{
			string name = category.CategoryName;
			string xmlName = category.CategoryXmlName;
			if (_categories.FirstOrDefault((SettingsCategory x) => x.CategoryName == name) != null)
			{
				Debug.LogError("A mod settings category with name '" + name + "' has already been registered. The category name must be unique.");
				return;
			}
			if (_categories.FirstOrDefault((SettingsCategory x) => x.CategoryXmlName == xmlName) != null)
			{
				Debug.LogError("A mod settings category with XML name '" + xmlName + "' has already been registered. The category XML name must be unique.");
				return;
			}
			SettingsCategory.InitializeCategoryProperties(new List<SettingsCategory> { category }, _xml.Root);
			if (category.Settings.Count > 0)
			{
				_categories.Add(category);
				_categories.Sort((SettingsCategory x, SettingsCategory y) => x.Order.CompareTo(y.Order));
			}
		}

		public void Save()
		{
			XDocument xml = _xml;
			if (xml != null && xml.Root?.Elements().Count() <= 0)
			{
				return;
			}
			try
			{
				foreach (SettingsCategory category in _categories)
				{
					try
					{
						category.SaveToXml(_xml.Root);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Debug.LogError("An error occurred trying to save mod settings category '" + category.CategoryName + "'.");
					}
				}
				_xml.Save(_filePath);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				Debug.LogError("An error occurred trying to save mod settings.");
			}
		}

		public void SaveIfNecessary()
		{
			if (HasAnyUnsavedChanges())
			{
				Save();
			}
		}

		private void Initialize(string filePath)
		{
			_filePath = filePath;
			_categories = new List<SettingsCategory>();
			if (_xml != null)
			{
				Debug.LogError("Mod settings have already been loaded.");
				return;
			}
			if (File.Exists(filePath))
			{
				try
				{
					_xml = XDocument.Load(_filePath);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occurred trying to load the mod settings file: " + _filePath);
				}
			}
			if (_xml == null)
			{
				_xml = new XDocument(new XElement("ModSettings"));
			}
		}
	}
}
