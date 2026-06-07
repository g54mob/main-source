using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Common
{
	public interface IGameSession : IThing, IDisposable
	{
		string GameMode { get; }

		string World { get; }

		int SessionID { get; }

		JObject GameData { get; }

		IUserProfile Owner { get; }

		string BasePath { get; }

		ReadOnlyObservableCollection<ISaveGame> Saves { get; }

		ISaveGame LatestSave { get; }

		void Save();

		void MakeCurrent();

		ISaveGame SaveGame(SaveType type, JObject data, Texture2D thumbnail, List<(int Type, byte[] Data)> customChunks = null, ISaveGame overwrite = null);

		void DeleteSaveGame(ISaveGame save);

		int TrimSaves(SaveType type, int maxCount, ISaveGame excluded = null);

		int GetSavesCountByType(SaveType type);

		bool CanCreateNewSaves(SaveType saveType);
	}
}
