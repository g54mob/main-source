using System.IO;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class PhotoItemModel
	{
		public IAlbum Album { get; set; }

		public bool? HasValidChecksum { get; private set; }

		public bool IsAlbum => Album != null;

		public IPhoto Photo { get; set; }

		public Texture2D LoadTexture(bool markNonReadable, bool validateChecksum = false)
		{
			Texture2D obj = new Texture2D(1, 1, TextureFormat.RGB24, mipChain: false, linear: false)
			{
				wrapMode = TextureWrapMode.Clamp
			};
			byte[] array = File.ReadAllBytes(Photo.Path);
			obj.LoadImage(array, markNonReadable);
			if (validateChecksum)
			{
				string text = Utilities.ComputeHash(array);
				HasValidChecksum = Photo.Checksum == text;
			}
			return obj;
		}

		public Texture2D LoadThumbnailTexture()
		{
			Texture2D result = null;
			if (Photo != null)
			{
				return LoadTexture(Photo);
			}
			if (Album?.ThumbnailPhoto != null)
			{
				return LoadTexture(Album.ThumbnailPhoto);
			}
			return result;
		}

		private Texture2D LoadTexture(IPhoto photo)
		{
			Texture2D texture2D = null;
			if (File.Exists(photo.ThumbnailPath))
			{
				texture2D = new Texture2D(1, 1, TextureFormat.RGB24, mipChain: false, linear: false);
				texture2D.LoadImage(File.ReadAllBytes(photo.ThumbnailPath), markNonReadable: true);
				texture2D.wrapMode = TextureWrapMode.Clamp;
			}
			return texture2D;
		}
	}
}
