using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.CelestialData
{
	public class CelestialFile
	{
		private static MD5CryptoServiceProvider _md5;

		public bool Exists => File.Exists(Path.FullPath);

		public Guid Id { get; }

		public DateTime LastModified { get; }

		public CelestialFilePath Path { get; }

		public CelestialFileType Type { get; }

		static CelestialFile()
		{
			_md5 = new MD5CryptoServiceProvider();
		}

		public CelestialFile(CelestialFilePath path, Guid id, DateTime lastModified, CelestialFileType type)
		{
			Path = path;
			Id = id;
			LastModified = lastModified;
			Type = type;
		}

		public static CelestialFile Create(CelestialFilePath path, Guid? id = null)
		{
			DateTime lastWriteTime = File.GetLastWriteTime(path.FullPath);
			CelestialFileType type = DetectFileType(path);
			Guid id2 = id ?? CelestialFileIdGenerator.GenerateId(path, type);
			return new CelestialFile(path, id2, lastWriteTime, type);
		}

		public static CelestialFileType DetectFileType(CelestialFilePath path)
		{
			string fullPath = path.FullPath;
			if (fullPath.EndsWith("xml", StringComparison.OrdinalIgnoreCase))
			{
				try
				{
					using FileStream input = File.Open(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
					using XmlReader xmlReader = XmlReader.Create(input);
					if (xmlReader.MoveToContent() == XmlNodeType.Element)
					{
						string name = xmlReader.Name;
						if (name == "PlanetarySystem")
						{
							return CelestialFileType.PlanetarySystem;
						}
						if (name == "CelestialBody")
						{
							return CelestialFileType.CelestialBody;
						}
					}
				}
				catch (Exception exception)
				{
					CelestialDatabase.LogError("Error detecting celestial file type: " + fullPath, exception);
					return CelestialFileType.Unknown;
				}
			}
			return CelestialFileType.SupportFile;
		}

		public static CelestialFile LoadFromXml(XElement element)
		{
			return new CelestialFile(CelestialFilePath.FromRelativePath(element.GetStringAttribute("path")), element.GetGuidAttributeOrNull("id") ?? Guid.Empty, element.GetDateTimeAttributeOrNull("lastModified") ?? DateTime.MinValue, element.GetEnumAttribute("type", CelestialFileType.Unknown));
		}

		public byte[] LoadFile()
		{
			return File.ReadAllBytes(Path.FullPath);
		}

		public Stream LoadFileAsStream()
		{
			return File.OpenRead(Path.FullPath);
		}

		public string LoadFileAsText()
		{
			return File.ReadAllText(Path.FullPath);
		}

		public XDocument LoadFileAsXml()
		{
			return XDocument.Load(Path.FullPath);
		}

		public Texture2D LoadTexture(bool mipmaps, bool linear, bool markNonReadable)
		{
			Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, mipmaps, linear);
			byte[] data = File.ReadAllBytes(Path.FullPath);
			if (texture2D.LoadImage(data, markNonReadable))
			{
				return texture2D;
			}
			Debug.LogError("Could not load texture '" + Path.FullPath + "'. The file existed but could not be loaded as a texture.");
			return null;
		}

		public XElement SaveToXml(string elementName)
		{
			return new XElement(elementName, new XAttribute("id", Id), new XAttribute("path", Path.RelativePath), new XAttribute("lastModified", LastModified), new XAttribute("type", Type));
		}
	}
}
