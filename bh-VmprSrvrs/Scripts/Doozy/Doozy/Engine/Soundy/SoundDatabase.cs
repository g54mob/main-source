using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy
{
	[Serializable]
	public class SoundDatabase : ScriptableObject
	{
		public string DatabaseName;

		public AudioMixerGroup OutputAudioMixerGroup;

		public List<string> SoundNames;

		public List<SoundGroupData> Database;

		private static UILanguagePack UILabels => null;

		public bool HasSoundsWithMissingAudioClips => false;

		public bool Add(SoundGroupData data, bool saveAssets)
		{
			return false;
		}

		public SoundGroupData Add(string soundName, bool performUndo, bool saveAssets)
		{
			return null;
		}

		public bool Contains(string soundName)
		{
			return false;
		}

		public bool Contains(SoundGroupData soundGroupData)
		{
			return false;
		}

		public SoundGroupData GetData(string soundName)
		{
			return null;
		}

		public void Initialize(bool saveAssets)
		{
		}

		public void RefreshDatabase(bool performUndo, bool saveAssets)
		{
		}

		public bool Remove(SoundGroupData data, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public void RemoveEntriesWithNoAudioClipsReferenced(bool performUndo, bool saveAssets = false)
		{
		}

		public void RemoveDuplicateEntries(bool performUndo, bool saveAssets = false)
		{
		}

		public void RemoveUnnamedEntries(bool performUndo, bool saveAssets = false)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void Sort(bool performUndo, bool saveAssets = false)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}

		public void UpdateSoundNames(bool saveAssets)
		{
		}

		private bool AddNoSound(bool saveAssets = false)
		{
			return false;
		}

		private void AddObjectToAsset(UnityEngine.Object objectToAdd)
		{
		}

		private bool CheckAllDataForCorrectDatabaseName(bool saveAssets)
		{
			return false;
		}

		private void RemoveUnreferencedData(bool saveAssets = false)
		{
		}
	}
}
