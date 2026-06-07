using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight;
using ModApi;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class PhotoLibraryData : IPhotoLibrary
	{
		public const int ThumbnailSize = 150;

		private const int JpegQuality = 75;

		private const string PhotoLibraryFileName = "PhotoLibrary.xml";

		private static string _lastSelectedAlbumName = "Camera Roll";

		private List<AlbumData> _albums = new List<AlbumData>();

		private string _imageFolderPath;

		private string _thumbnailFolderPath;

		private string _xmlPath;

		public IReadOnlyList<IAlbum> Albums => _albums;

		public string LastSelectedAlbumName
		{
			get
			{
				return _lastSelectedAlbumName;
			}
			set
			{
				_lastSelectedAlbumName = value;
			}
		}

		public PhotoLibraryFeature SupportedFeatures { get; set; } = (PhotoLibraryFeature)3;

		public PhotoLibraryData(string rootFolderPath)
		{
			_imageFolderPath = Utilities.CombinePaths(rootFolderPath, "Images");
			_thumbnailFolderPath = Utilities.CombinePaths(rootFolderPath, "Thumbnails");
			CreateDirectoryIfNotExist(rootFolderPath);
			CreateDirectoryIfNotExist(_imageFolderPath);
			CreateDirectoryIfNotExist(_thumbnailFolderPath);
			_xmlPath = Utilities.CombinePaths(rootFolderPath, "PhotoLibrary.xml");
			if (File.Exists(_xmlPath))
			{
				foreach (XElement item in XDocument.Load(_xmlPath).Element("PhotoLibrary").Elements("Album"))
				{
					string stringAttribute = item.GetStringAttribute("name");
					IAlbum album = CreateAlbum(stringAttribute);
					foreach (XElement item2 in item.Elements("Photo"))
					{
						PhotoData photoData = PhotoData.CreateFromXml(item2, album, this);
						if (photoData.IsAlbumCover)
						{
							album.SetThumbnailPhoto(photoData);
						}
					}
				}
				return;
			}
			CreateAlbum("Camera Roll");
		}

		public IPhoto AddFileToAlbum(string path, IAlbum album)
		{
			throw new NotImplementedException("The photo library does not support adding files.");
		}

		public IAlbum CreateAlbum(string albumName)
		{
			AlbumData albumData = new AlbumData(albumName);
			_albums.Add(albumData);
			return albumData;
		}

		public IPhoto CreateNewPhoto(Texture2D screenshot, IAlbum album)
		{
			string imageFileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + ".png";
			string photoImagePath = GetPhotoImagePath(imageFileName);
			string photoThumbnailPath = GetPhotoThumbnailPath(imageFileName);
			Texture2D texture2D = Utilities.Texture.CreateSquareThumbnail(screenshot, 150);
			byte[] array = texture2D.EncodeToJPG(75);
			File.WriteAllBytes(photoThumbnailPath, array);
			byte[] array2 = screenshot.EncodeToPNG();
			File.WriteAllBytes(photoImagePath, array2);
			PhotoData photoData = new PhotoData(photoImagePath, photoThumbnailPath, album);
			album.AddPhoto(photoData);
			photoData.DateTaken = DateTime.UtcNow;
			photoData.Dimensions = $"{screenshot.width}x{screenshot.height}";
			photoData.SizeInBytes = array2.Length + array.Length;
			photoData.Checksum = Utilities.ComputeHash(array2);
			photoData.GameStateId = Game.Instance.GameState.Id;
			photoData.Location = GetPlayerLocation();
			UnityEngine.Object.Destroy(texture2D);
			return photoData;
		}

		public void DeleteAlbum(IAlbum album)
		{
			AlbumData albumData = album as AlbumData;
			IPhoto[] array = albumData.Photos.ToArray();
			foreach (IPhoto photo in array)
			{
				DeletePhoto(photo);
			}
			_albums.Remove(albumData);
		}

		public void DeletePhoto(IPhoto photo)
		{
			photo.Delete();
			photo.Album.RemovePhoto(photo);
		}

		public string GetPhotoImagePath(string imageFileName)
		{
			return Utilities.CombinePaths(_imageFolderPath, imageFileName);
		}

		public string GetPhotoThumbnailPath(string imageFileName)
		{
			return Utilities.CombinePaths(_thumbnailFolderPath, "thumb-" + imageFileName);
		}

		public void Save()
		{
			XElement xElement = new XElement("PhotoLibrary");
			foreach (IAlbum album in Albums)
			{
				XElement xElement2 = new XElement("Album");
				xElement2.SetAttributeValue("name", album.Name);
				xElement.Add(xElement2);
				foreach (IPhoto photo in album.Photos)
				{
					XElement content = (photo as PhotoData).GenerateXml();
					xElement2.Add(content);
				}
			}
			new XDocument(xElement).Save(_xmlPath);
		}

		private static void CreateDirectoryIfNotExist(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}

		private static string GetPlayerLocation()
		{
			string empty = string.Empty;
			if (Game.InFlightScene)
			{
				string text = FlightSceneScript.Instance?.CraftNode?.Parent?.PlanetData?.Name;
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text;
				}
				return "Flight";
			}
			if (Game.InDesignerScene)
			{
				return "Designer";
			}
			return "Menu";
		}
	}
}
