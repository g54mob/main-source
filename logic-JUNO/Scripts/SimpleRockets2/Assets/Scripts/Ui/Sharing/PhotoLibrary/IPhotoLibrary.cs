using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public interface IPhotoLibrary
	{
		IReadOnlyList<IAlbum> Albums { get; }

		string LastSelectedAlbumName { get; set; }

		PhotoLibraryFeature SupportedFeatures { get; }

		IPhoto AddFileToAlbum(string path, IAlbum album);

		IAlbum CreateAlbum(string albumName);

		IPhoto CreateNewPhoto(Texture2D screenshot, IAlbum album);

		void DeleteAlbum(IAlbum album);

		void DeletePhoto(IPhoto photo);

		void Save();
	}
}
