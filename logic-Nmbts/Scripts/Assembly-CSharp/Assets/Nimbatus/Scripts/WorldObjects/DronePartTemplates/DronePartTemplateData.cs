using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Ionic.Zip;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePartTemplates
{
	[Serializable]
	public class DronePartTemplateData
	{
		public static Version CurrentVersion = new Version(0, 0, 1);

		public static Version LastCompatibleVersion = new Version(0, 0, 1);

		private Texture2D _image;

		[XmlIgnore]
		public byte[] ImageBytes;

		public string Version { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string UniqueId { get; set; }

		public NimbatusItemData RootDronePart { get; set; }

		public List<WeaponPresetData> WeaponPresets { get; set; }

		[XmlIgnore]
		public Texture2D Image
		{
			get
			{
				if (_image != null)
				{
					return _image;
				}
				if (ImageBytes != null)
				{
					_image = new Texture2D(1, 1, TextureFormat.ARGB32, false, true);
					_image.LoadImage(ImageBytes);
					_image.wrapMode = TextureWrapMode.Clamp;
				}
				return _image;
			}
			set
			{
				_image = value;
				ImageBytes = _image.EncodeToPNG();
			}
		}

		public static bool IsCompatible(Version version)
		{
			if (CurrentVersion < version)
			{
				return false;
			}
			if (LastCompatibleVersion > version)
			{
				return false;
			}
			return true;
		}

		public bool IsCompatible()
		{
			try
			{
				return IsCompatible(new Version(Version));
			}
			catch
			{
				return false;
			}
		}

		public DronePartTemplateData()
		{
			Version = CurrentVersion.ToString();
		}

		public void Save(string fileName)
		{
			Version = CurrentVersion.ToString();
			using (ZipFile zipFile = new ZipFile())
			{
				MemoryStream memoryStream = new MemoryStream();
				using (StreamWriter textWriter = new StreamWriter(memoryStream))
				{
					new XmlSerializer(GetType()).Serialize(textWriter, this);
				}
				zipFile.AddEntry("DroneTemplateData", memoryStream.ToArray());
				zipFile.AddEntry("Image.png", Image.EncodeToPNG());
				zipFile.Save(fileName);
			}
		}

		public byte[] SaveToBytes(bool withoutImages = false)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (ZipFile zipFile = new ZipFile())
			{
				MemoryStream memoryStream2 = new MemoryStream();
				using (StreamWriter textWriter = new StreamWriter(memoryStream2))
				{
					new XmlSerializer(GetType()).Serialize(textWriter, this);
				}
				zipFile.AddEntry("DroneTemplateData", memoryStream2.ToArray());
				if (!withoutImages)
				{
					zipFile.AddEntry("Image.png", Image.EncodeToPNG());
				}
				zipFile.Save(memoryStream);
			}
			return memoryStream.ToArray();
		}

		public static DronePartTemplateData LoadFromBytes(byte[] bytes, bool withoutImages = false)
		{
			return ExtractFromZip(ZipFile.Read(new MemoryStream(bytes)), withoutImages);
		}

		public static DronePartTemplateData Load(string fileName)
		{
			if (!File.Exists(fileName))
			{
				return null;
			}
			return ExtractFromZip(ZipFile.Read(fileName));
		}

		private static DronePartTemplateData ExtractFromZip(ZipFile zip, bool withoutImages = false)
		{
			using (zip)
			{
				ZipEntry zipEntry = zip["DroneTemplateData"];
				if (zipEntry != null)
				{
					MemoryStream memoryStream = new MemoryStream();
					zipEntry.Extract(memoryStream);
					memoryStream.Position = 0L;
					DronePartTemplateData dronePartTemplateData = new XmlSerializer(typeof(DronePartTemplateData)).Deserialize(memoryStream) as DronePartTemplateData;
					if (dronePartTemplateData == null)
					{
						return null;
					}
					if (!withoutImages)
					{
						ZipEntry zipEntry2 = zip["Image.png"];
						MemoryStream memoryStream2 = new MemoryStream();
						zipEntry2.Extract(memoryStream2);
						dronePartTemplateData.ImageBytes = memoryStream2.ToArray();
						dronePartTemplateData._image = null;
					}
					return dronePartTemplateData;
				}
			}
			return null;
		}

		public DronePartTemplateData Clone()
		{
			string tempFileName = Path.GetTempFileName();
			Save(tempFileName);
			DronePartTemplateData result = Load(tempFileName);
			File.Delete(tempFileName);
			return result;
		}

		public void SaveImage(string imagePath)
		{
			Color[] pixels = Image.GetPixels();
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i].r = ColorHelper.ConvertToGamma(pixels[i].r);
				pixels[i].g = ColorHelper.ConvertToGamma(pixels[i].g);
				pixels[i].b = ColorHelper.ConvertToGamma(pixels[i].b);
			}
			Texture2D texture2D = new Texture2D(Image.width, Image.height, TextureFormat.ARGB32, false, true);
			texture2D.SetPixels(pixels);
			File.WriteAllBytes(imagePath, texture2D.EncodeToPNG());
		}

		public int GetNumberOfParts(string prefabId)
		{
			DronePartData dronePartData;
			if ((dronePartData = RootDronePart as DronePartData) != null)
			{
				return dronePartData.GetNumberOfParts(prefabId);
			}
			return 0;
		}

		public int GetNumberOfParts<T>() where T : DronePartData
		{
			DronePartData dronePartData;
			if ((dronePartData = RootDronePart as DronePartData) != null)
			{
				return dronePartData.GetNumberOfParts<T>();
			}
			return 0;
		}

		public void ReplaceWeapons(string oldWeaponId, string newWeapon)
		{
			(RootDronePart as DronePartData).ReplaceId(oldWeaponId, newWeapon);
		}

		public List<string> GetAllWeapons()
		{
			List<string> retval = new List<string>();
			DronePartData dronePartData;
			if ((dronePartData = RootDronePart as DronePartData) != null)
			{
				dronePartData.FillUsedWeapons(ref retval);
			}
			return retval;
		}

		public Dictionary<string, int> GetAllUsedParts()
		{
			Dictionary<string, int> retval = new Dictionary<string, int>();
			DronePartData dronePartData;
			if ((dronePartData = RootDronePart as DronePartData) != null)
			{
				dronePartData.FillUsedParts(ref retval);
			}
			return retval;
		}

		public DronePart InstantiateDronePart()
		{
			if (WeaponPresets != null)
			{
				foreach (WeaponPresetData weaponPreset2 in WeaponPresets)
				{
					WeaponPreset weaponPreset = new WeaponPreset();
					weaponPreset.Load(weaponPreset2);
					if (!SaveManager.LoadedSave.Settings.HasPartUnlocking)
					{
						SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GenerateAndAddWeapon(weaponPreset, SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponTemplate, true);
					}
				}
			}
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.InstantiateItemFromData(RootDronePart) as DronePart;
		}
	}
}
