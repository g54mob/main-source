using System;
using System.Collections.Generic;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class AlbumData : IAlbum
	{
		private List<IPhoto> _photos;

		public bool HasThumbnail => ThumbnailPhoto != null;

		public string Name { get; set; }

		public IReadOnlyCollection<IPhoto> Photos => _photos;

		public IPhoto ThumbnailPhoto { get; private set; }

		public AlbumData(string name)
		{
			Name = name;
			_photos = new List<IPhoto>();
		}

		public void AddPhoto(IPhoto photo)
		{
			if (!_photos.Contains(photo))
			{
				_photos.Add(photo);
				return;
			}
			throw new InvalidOperationException($"The album {Name} already contains the photo {photo.FileName}");
		}

		public void RemovePhoto(IPhoto photo)
		{
			if (ThumbnailPhoto == photo && ThumbnailPhoto != null)
			{
				ThumbnailPhoto.IsAlbumCover = false;
				ThumbnailPhoto = null;
			}
			_photos.Remove(photo);
		}

		public void SetThumbnailPhoto(IPhoto photo)
		{
			ThumbnailPhoto = photo;
			if (ThumbnailPhoto != null)
			{
				ThumbnailPhoto.IsAlbumCover = true;
			}
		}
	}
}
