using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Common
{
	public interface ISaveGame : IDisposable
	{
		int UID { get; }

		DateTimeOffset Timestamp { get; }

		SaveType Type { get; }

		string Name { get; set; }

		string World { get; }

		string GameMode { get; }

		JObject Data { get; }

		Texture2D Thumbnail { get; }

		string BasePath { get; }

		bool IsDataLoaded { get; }

		bool IsThumbnailLoaded { get; }

		IGameSession ParentSession { get; }

		List<(int Type, byte[] Data)> CustomChunkData { get; }

		void FlushToDisk();

		void LoadThumbnail();

		void UnloadThumbnail();

		void LoadData();

		List<string> GetFiles(List<string> fileList);
	}
}
