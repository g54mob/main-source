using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Ionic.Zip;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class DroneData
	{
		public static Version CurrentVersion = new Version(1, 20, 0);

		public static Version LastCompatibleVersion = new Version(1, 0, 0);

		private Texture2D _image;

		[XmlIgnore]
		public byte[] ImageBytes;

		internal bool DownloadedFromSteam;

		internal bool IsOpponentDrone;

		public string Version { get; set; }

		public bool WasShared { get; set; }

		public ulong UserId { get; set; }

		public DateTime LastEditTime { get; set; }

		public DateTime LastUseTime { get; set; }

		public string DroneName { get; set; }

		public string Description { get; set; }

		public string UniqueId { get; set; }

		public NimbatusItemData RootDronePart { get; set; }

		public int NumberOfParts { get; set; }

		public int NumberOfWeapons { get; set; }

		public float Diameter { get; set; }

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

		public DroneData()
		{
			Version = CurrentVersion.ToString();
			DownloadedFromSteam = false;
			LastEditTime = DateTime.MinValue.ToUniversalTime();
			LastUseTime = DateTime.MinValue.ToUniversalTime();
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
				zipFile.AddEntry("DroneData", memoryStream.ToArray());
				if (Image != null)
				{
					zipFile.AddEntry("Image.png", Image.EncodeToPNG());
				}
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
				zipFile.AddEntry("DroneData", memoryStream2.ToArray());
				if (!withoutImages)
				{
					zipFile.AddEntry("Image.png", Image.EncodeToPNG());
				}
				zipFile.Save(memoryStream);
			}
			return memoryStream.ToArray();
		}

		public static DroneData LoadFromBytes(byte[] bytes, bool withoutImages = false)
		{
			return ExtractFromZip(ZipFile.Read(new MemoryStream(bytes)), withoutImages);
		}

		public static DroneData Load(string fileName)
		{
			if (!File.Exists(fileName))
			{
				return null;
			}
			return ExtractFromZip(ZipFile.Read(fileName));
		}

		private static DroneData ExtractFromZip(ZipFile zip, bool withoutImages = false)
		{
			using (zip)
			{
				ZipEntry zipEntry = zip["DroneData"];
				if (zipEntry != null)
				{
					MemoryStream memoryStream = new MemoryStream();
					zipEntry.Extract(memoryStream);
					memoryStream.Position = 0L;
					DroneData droneData = new XmlSerializer(typeof(DroneData)).Deserialize(memoryStream) as DroneData;
					if (droneData == null)
					{
						return null;
					}
					if (!withoutImages)
					{
						ZipEntry zipEntry2 = zip["Image.png"];
						if (zipEntry2 != null)
						{
							MemoryStream memoryStream2 = new MemoryStream();
							zipEntry2.Extract(memoryStream2);
							droneData.ImageBytes = memoryStream2.ToArray();
						}
						droneData._image = null;
					}
					return droneData;
				}
			}
			return null;
		}

		public DroneData Clone()
		{
			string tempFileName = Path.GetTempFileName();
			Save(tempFileName);
			DroneData result = Load(tempFileName);
			File.Delete(tempFileName);
			return result;
		}

		public string SaveToTempPath()
		{
			string tempFileName = Path.GetTempFileName();
			Save(tempFileName);
			return tempFileName;
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
			DronePartData dronePartData;
			if ((dronePartData = RootDronePart as DronePartData) != null)
			{
				dronePartData.ReplaceId(oldWeaponId, newWeapon);
			}
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
	}
}
