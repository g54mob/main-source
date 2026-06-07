using System;
using System.IO;
using System.Xml.Linq;
using ModApi;
using ModApi.Common.Extensions;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class PhotoData : IPhoto
	{
		public IAlbum Album { get; private set; }

		public string Checksum { get; set; }

		public DateTime DateTaken { get; set; }

		public string Description { get; set; }

		public string Dimensions { get; set; }

		public string FileName => new FileInfo(Path).Name;

		public string GameStateId { get; set; }

		public bool IsAlbumCover { get; set; }

		public string Location { get; set; }

		public string Path { get; private set; }

		public string RelativeDate => Utilities.RelativeDate(DateTime.UtcNow, DateTaken);

		public int SizeInBytes { get; set; }

		public string ThumbnailPath { get; private set; }

		public PhotoData(string path, string thumbnailPath, IAlbum album)
		{
			Path = path;
			ThumbnailPath = thumbnailPath;
			Album = album;
		}

		public static PhotoData CreateFromXml(XElement xml, IAlbum album, PhotoLibraryData photoLibraryData)
		{
			string stringAttribute = xml.GetStringAttribute("name");
			PhotoData photoData = new PhotoData(photoLibraryData.GetPhotoImagePath(stringAttribute), photoLibraryData.GetPhotoThumbnailPath(stringAttribute), album);
			album.AddPhoto(photoData);
			photoData.Location = xml.GetStringAttribute("location", string.Empty);
			photoData.DateTaken = xml.GetDateTimeAttribute("dateTaken", DateTime.UtcNow);
			photoData.Dimensions = xml.GetStringAttribute("dimensions", string.Empty);
			photoData.SizeInBytes = xml.GetIntAttribute("size");
			photoData.IsAlbumCover = xml.GetBoolAttribute("albumCover");
			photoData.Checksum = xml.GetStringAttribute("cx", string.Empty);
			photoData.Description = xml.Value;
			photoData.GameStateId = xml.GetStringAttribute("gameState", string.Empty);
			return photoData;
		}

		public void Delete()
		{
			Utilities.Delete(Path);
			Utilities.Delete(ThumbnailPath);
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Photo");
			xElement.SetAttributeValue("name", FileName);
			xElement.SetAttributeValue("location", Location);
			xElement.SetAttributeValue("dateTaken", DateTaken);
			xElement.SetAttributeValue("dimensions", Dimensions);
			xElement.SetAttributeValue("size", SizeInBytes);
			xElement.SetAttributeValue("cx", Checksum);
			xElement.SetAttributeValue("gameState", GameStateId);
			if (IsAlbumCover)
			{
				xElement.SetAttributeValue("albumCover", IsAlbumCover);
			}
			if (!string.IsNullOrWhiteSpace(Description))
			{
				xElement.Value = Description;
			}
			return xElement;
		}

		public void Move(IAlbum newAlbum)
		{
			if (Album != newAlbum)
			{
				Album.RemovePhoto(this);
				newAlbum.AddPhoto(this);
				Album = newAlbum;
			}
		}
	}
}
