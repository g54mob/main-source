using System.Collections.Generic;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public interface IAlbum
	{
		bool HasThumbnail { get; }

		string Name { get; set; }

		IReadOnlyCollection<IPhoto> Photos { get; }

		IPhoto ThumbnailPhoto { get; }

		void AddPhoto(IPhoto photo);

		void RemovePhoto(IPhoto photo);

		void SetThumbnailPhoto(IPhoto photo);
	}
}
