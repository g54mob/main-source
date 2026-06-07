using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Jundroo.Common.Settings;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class GameSettings : IGameSettings
	{
		private string _filePath;

		public AudioSettings Audio { get; private set; }

		public CameraSettings Camera { get; private set; }

		public IReadOnlyList<SettingsCategory> Categories { get; private set; }

		public CraftFilterSettings CraftFilters { get; private set; }

		public DesignerSettings Designer { get; private set; }

		public FlightSettings Flight { get; private set; }

		public GeneralSettings General { get; private set; }

		public MouseJoystickSettings MouseJoystick { get; private set; }

		private GameSettings()
		{
		}

		public static GameSettings Create(string filePath)
		{
			GameSettings gameSettings = new GameSettings();
			gameSettings.Initialize(filePath);
			return gameSettings;
		}

		public bool HasAnyUnsavedChanges()
		{
			return Categories.HasUnsavedChanges();
		}

		public void Save()
		{
			XDocument xDocument = new XDocument(new XElement("GameplaySettings"));
			foreach (SettingsCategory category in Categories)
			{
				category.SaveToXml(xDocument.Root);
			}
			xDocument.Save(_filePath);
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
			XElement xElement = null;
			if (File.Exists(filePath))
			{
				try
				{
					xElement = XDocument.Load(filePath)?.Root;
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occurred trying to load the gameplay settings file: " + filePath);
				}
			}
			Categories = SettingsCategory.InitializeCategoryProperties(this, xElement);
			if (xElement == null)
			{
				Save();
			}
		}
	}
}
