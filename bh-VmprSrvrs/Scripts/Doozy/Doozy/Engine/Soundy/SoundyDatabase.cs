using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Soundy
{
	[Serializable]
	public class SoundyDatabase : ScriptableObject
	{
		public List<string> DatabaseNames;

		public List<SoundDatabase> SoundDatabases;

		private static UILanguagePack UILabels => null;

		public bool AddSoundDatabase(SoundDatabase database, bool saveAssets)
		{
			return false;
		}

		public bool Contains(string databaseName)
		{
			return false;
		}

		public bool Contains(string databaseName, string soundName)
		{
			return false;
		}

		public bool CreateSoundDatabase(string databaseName, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public bool CreateSoundDatabase(string relativePath, string databaseName, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public bool DeleteDatabase(SoundDatabase database)
		{
			return false;
		}

		public SoundGroupData GetAudioData(string databaseName, string soundName)
		{
			return null;
		}

		public SoundDatabase GetSoundDatabase(string databaseName)
		{
			return null;
		}

		public void Initialize()
		{
		}

		public void InitializeSoundDatabases()
		{
		}

		public void RefreshDatabase(bool performUndo = true, bool saveAssets = false)
		{
		}

		public void RemoveNullDatabases(bool saveAssets = false)
		{
		}

		public bool RenameSoundDatabase(SoundDatabase soundDatabase, string newDatabaseName)
		{
			return false;
		}

		public void SearchForUnregisteredDatabases(bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}

		public void UpdateDatabaseNames(bool saveAssets = false)
		{
		}
	}
}
