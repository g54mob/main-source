using System;
using System.IO;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Packages;
using UnityEngine;

namespace ModApi.CelestialData
{
	public class SupportFileData
	{
		public Guid FileId { get; }

		public string FriendlyName { get; }

		public SupportFileDataTextureInfo TextureInfo { get; private set; }

		public SupportFileType Type { get; }

		public SupportFileData(CelestialFile file, CelestialDatabase database)
		{
			FileId = file.Id;
			FriendlyName = CelestialFileNameUtility.ToFriendlyFileName(file.Path, includeExtension: false);
			Type = DetectAndInitializeType(file, database);
		}

		public SupportFileData(XElement xml)
		{
			FileId = xml.GetGuidAttribute("fileId", Guid.Empty);
			Type = xml.GetEnumAttribute("type", SupportFileType.Unknown);
			FriendlyName = xml.GetStringAttribute("friendlyName");
			XElement xElement = xml.Element("TextureInfo");
			TextureInfo = ((xElement == null) ? null : new SupportFileDataTextureInfo(xElement));
		}

		public XElement SaveToXml(string elementName)
		{
			return new XElement(elementName, new XAttribute("fileId", FileId), new XAttribute("type", Type), new XAttribute("friendlyName", FriendlyName), (Type == SupportFileType.Texture && TextureInfo != null) ? TextureInfo.SaveToXml("TextureInfo") : null);
		}

		private static void GenerateThumbnail(Texture2D texture, int targetSize, CelestialDatabaseGeneratedData data)
		{
			try
			{
				(int, int) thumbnailSize = GetThumbnailSize(texture, targetSize);
				TextureScale.Bilinear(texture, thumbnailSize.Item1, thumbnailSize.Item2);
				data.SaveTextureAsPng($"Thumbnail{targetSize}.png", texture);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private static (int Width, int Height) GetThumbnailSize(Texture2D texture, int targetSize)
		{
			float num = targetSize;
			float num2 = texture.width;
			float num3 = texture.height;
			float num4 = ((num2 >= num3) ? num2 : num3);
			float num5 = num2 / num3;
			float num6 = num3 / num2;
			return (Width: System.Math.Max(1, (int)((!(num4 >= num)) ? num2 : ((num5 >= 1f) ? num : (num * num5)))), Height: System.Math.Max(1, (int)((!(num4 >= num)) ? num3 : ((num6 >= 1f) ? num : (num * num6)))));
		}

		private SupportFileType DetectAndInitializeType(CelestialFile file, CelestialDatabase database)
		{
			if (TryInitializeAsTexture(file, database))
			{
				return SupportFileType.Texture;
			}
			return SupportFileType.Unknown;
		}

		private bool TryInitializeAsTexture(CelestialFile file, CelestialDatabase database)
		{
			Texture2D texture2D = null;
			try
			{
				texture2D = new Texture2D(2, 2);
				if (!texture2D.LoadImage(File.ReadAllBytes(file.Path.FullPath), markNonReadable: false))
				{
					return false;
				}
				SupportFileDataTextureInfo textureInfo = new SupportFileDataTextureInfo(texture2D);
				CelestialDatabaseGeneratedData generatedData = database.GetGeneratedData(FileId);
				GenerateThumbnail(texture2D, 256, generatedData);
				GenerateThumbnail(texture2D, 128, generatedData);
				GenerateThumbnail(texture2D, 64, generatedData);
				TextureInfo = textureInfo;
				return true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				if (texture2D != null)
				{
					UnityEngine.Object.Destroy(texture2D);
					GC.Collect();
				}
			}
			return false;
		}
	}
}
