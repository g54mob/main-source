using System;
using ModApi.CelestialData;
using UnityEngine;

namespace ModApi.PlanetStudio
{
	[Serializable]
	public class CelestialFileDesignerInfo
	{
		[SerializeField]
		private string _id;

		public CelestialFile File { get; }

		public string Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public Texture2D Thumbnail { get; }

		public CelestialFileDesignerInfo(CelestialFile file, string id)
		{
			File = file;
			Id = id;
			if (file.Type == CelestialFileType.SupportFile)
			{
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				if ((celestialDatabase.GetSupportFile(File.Id) ?? throw new Exception($"Unable to find support file with id '{File.Id}'")).Type == SupportFileType.Texture)
				{
					Thumbnail = celestialDatabase.GetGeneratedData(File.Id).LoadTexture("Thumbnail128.png", mipmaps: true, linear: false, markNonReadable: true);
				}
			}
		}
	}
}
