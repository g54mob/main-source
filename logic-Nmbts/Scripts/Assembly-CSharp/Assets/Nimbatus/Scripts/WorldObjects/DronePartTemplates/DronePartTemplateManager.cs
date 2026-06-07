using System;
using System.Collections.Generic;
using System.IO;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePartTemplates
{
	public class DronePartTemplateManager : BaseSingleton<DronePartTemplateManager>
	{
		[HideInInspector]
		public List<DronePartTemplateData> Templates;

		private static string TemplateFilePath
		{
			get
			{
				return Application.persistentDataPath + "/Saves/Global/Templates";
			}
		}

		public DronePartTemplateData CreateTemplate(NimbatusItemData rootPart, List<WeaponPresetData> weapons, string templateName, string desc, Texture2D image)
		{
			DronePartTemplateData dronePartTemplateData = new DronePartTemplateData
			{
				Name = templateName,
				Image = image,
				Description = desc,
				WeaponPresets = weapons,
				RootDronePart = rootPart,
				UniqueId = Guid.NewGuid().ToString()
			};
			Templates.Add(dronePartTemplateData);
			SaveToFile();
			return dronePartTemplateData;
		}

		protected override void Awake()
		{
			base.Awake();
			LoadFromFile();
		}

		public void OnDestroy()
		{
			SaveToFile();
		}

		public void OnApplicationQuit()
		{
			SaveToFile();
		}

		public void DeleteTemplate(DronePartTemplateData template)
		{
			Templates.Remove(template);
			string filePath = GetFilePath(template);
			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected void LoadFromFile()
		{
			Templates = new List<DronePartTemplateData>();
			if (Directory.Exists(TemplateFilePath))
			{
				string[] files = Directory.GetFiles(TemplateFilePath, "*.drnt");
				for (int i = 0; i < files.Length; i++)
				{
					DronePartTemplateData item = DronePartTemplateData.Load(files[i]);
					Templates.Add(item);
				}
			}
			else
			{
				Directory.CreateDirectory(TemplateFilePath);
			}
		}

		protected void SaveToFile()
		{
			foreach (DronePartTemplateData template in Templates)
			{
				template.Save(GetFilePath(template));
			}
		}

		private string GetFilePath(DronePartTemplateData data)
		{
			return Path.Combine(TemplateFilePath, data.UniqueId + ".drnt");
		}
	}
}
