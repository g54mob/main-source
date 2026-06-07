using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.PlanetStudio;
using ModApi;
using ModApi.CelestialData;
using ModApi.PlanetStudio;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class TexturePickerLibrary : IPhotoLibrary
	{
		public class TexturePhotoData : PhotoData
		{
			public SupportFileData SupportFile { get; set; }

			public TexturePhotoData(string path, string thumbnailPath, IAlbum album, SupportFileData supportFile)
				: base(path, thumbnailPath, album)
			{
				SupportFile = supportFile;
			}
		}

		private AlbumData _albumAll;

		private List<AlbumData> _albums = new List<AlbumData>();

		private CelestialBodyFileData _celestialBody;

		private CelestialDatabase _db;

		private Func<SupportFileData, bool> _filter;

		public IReadOnlyList<IAlbum> Albums => _albums;

		public string LastSelectedAlbumName { get; set; }

		public PhotoLibraryFeature SupportedFeatures { get; private set; }

		public TexturePickerLibrary(CelestialBodyFileData celestialBody, Func<SupportFileData, bool> filter = null)
		{
			if (Device.IsMobileBuild)
			{
				SupportedFeatures = PhotoLibraryFeature.SelectPhoto;
			}
			else
			{
				SupportedFeatures = (PhotoLibraryFeature)20;
			}
			_celestialBody = celestialBody;
			_filter = filter ?? ((Func<SupportFileData, bool>)((SupportFileData x) => true));
			RebuildAlbums();
		}

		public TexturePickerLibrary(List<CelestialFile> files, string albumName, Func<SupportFileData, bool> filter = null)
		{
			SupportedFeatures = PhotoLibraryFeature.SelectPhoto;
			_albums = new List<AlbumData>();
			_filter = filter ?? ((Func<SupportFileData, bool>)((SupportFileData x) => true));
			AlbumData albumData = new AlbumData(albumName);
			_albums.Add(albumData);
			LastSelectedAlbumName = albumData.Name;
			_db = Game.Instance.CelestialDatabase;
			foreach (CelestialFile file in files)
			{
				SupportFileData supportFile = _db.GetSupportFile(file.Id);
				if (_filter(supportFile))
				{
					IPhoto photo = CreatePhotoFromSupportFile(supportFile, albumData);
					if (photo != null)
					{
						albumData.AddPhoto(photo);
					}
				}
			}
		}

		public static bool FilterCubemap(SupportFileData supportFile)
		{
			if (supportFile != null && supportFile.TextureInfo != null)
			{
				return supportFile.TextureInfo.Width == supportFile.TextureInfo.Height * 6;
			}
			return false;
		}

		public static SupportFileData GetSupportFileFromPath(string path, CelestialDatabase db)
		{
			CelestialFile file = db.GetFile(CelestialFilePath.FromFullPath(path));
			return db.GetSupportFile(file.Id);
		}

		public IPhoto AddFileToAlbum(string path, IAlbum album)
		{
			Game.Instance.CelestialDatabase.AddSupportFile(path);
			RebuildAlbums();
			return _albumAll.Photos.First();
		}

		public IAlbum CreateAlbum(string albumName)
		{
			throw new NotImplementedException();
		}

		public IPhoto CreateNewPhoto(Texture2D screenshot, IAlbum album)
		{
			throw new NotImplementedException();
		}

		public void DeleteAlbum(IAlbum album)
		{
			throw new NotImplementedException();
		}

		public void DeletePhoto(IPhoto photo)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
		}

		private IPhoto CreatePhotoFromSupportFile(SupportFileData supportFile, IAlbum album)
		{
			if (supportFile.Type != SupportFileType.Texture || supportFile.TextureInfo == null)
			{
				return null;
			}
			CelestialDatabaseGeneratedData generatedData = _db.GetGeneratedData(supportFile.FileId);
			CelestialFile file = _db.GetFile(supportFile.FileId);
			FileInfo fileInfo = new FileInfo(file.Path.FullPath);
			int num = 128;
			string filePath = generatedData.GetFilePath($"Thumbnail{num}.png");
			return new TexturePhotoData(fileInfo.FullName, filePath, album, supportFile)
			{
				Dimensions = $"{supportFile.TextureInfo.Width}x{supportFile.TextureInfo.Height}",
				SizeInBytes = (int)fileInfo.Length,
				DateTaken = file.LastModified
			};
		}

		private void RebuildAlbums()
		{
			_albums = new List<AlbumData>();
			_albumAll = new AlbumData("All Textures");
			_albums.Add(_albumAll);
			_db = Game.Instance.CelestialDatabase;
			if (_celestialBody != null)
			{
				AlbumData albumData = new AlbumData(_celestialBody.Name);
				LastSelectedAlbumName = albumData.Name;
				_albums.Add(albumData);
				foreach (CelestialFileDesignerInfo supportFile2 in PlanetStudioScript.Instance.CelestialBodyDesignerScript.SupportFiles)
				{
					SupportFileData supportFile = _db.GetSupportFile(supportFile2.File.Id);
					if (_filter(supportFile))
					{
						IPhoto photo = CreatePhotoFromSupportFile(supportFile, albumData);
						if (photo != null)
						{
							albumData.AddPhoto(photo);
						}
					}
				}
			}
			foreach (SupportFileData supportFile3 in Game.Instance.CelestialDatabase.SupportFiles)
			{
				if (_filter(supportFile3))
				{
					IPhoto photo2 = CreatePhotoFromSupportFile(supportFile3, _albumAll);
					if (photo2 != null)
					{
						_albumAll.AddPhoto(photo2);
					}
				}
			}
		}
	}
}
