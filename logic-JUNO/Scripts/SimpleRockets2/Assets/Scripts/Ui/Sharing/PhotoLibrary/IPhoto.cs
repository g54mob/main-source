using System;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public interface IPhoto
	{
		IAlbum Album { get; }

		string Checksum { get; }

		DateTime DateTaken { get; }

		string Description { get; set; }

		string Dimensions { get; }

		string FileName { get; }

		bool IsAlbumCover { get; set; }

		string Location { get; }

		string Path { get; }

		int SizeInBytes { get; }

		string ThumbnailPath { get; }

		void Delete();

		void Move(IAlbum newAlbum);
	}
}
