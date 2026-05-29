using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Placemaker.Ui;
using UnityEngine;

namespace Placemaker
{
	public class StorageUtils : MonoBehaviour
	{
		public SettingsData settingsData;

		public bool settingsDataIsSet;

		public SaveCardsHandler saveCardsHandler;

		[SerializeField]
		private List<string> loadedFiles;

		[SerializeField]
		private int fileInfoFrame;

		public const string saveFileExtension = ".scape";

		private const string settingsFileName = "Sett.ings";

		private const string saveFilePrefix = "Town";

		private const string saveFileDirectoryName = "Saves";

		[SerializeField]
		private XmlSerializer settingsXmlSerializer;

		[SerializeField]
		private XmlSerializer saveXmlSerializer;

		[SerializeField]
		private char[] charArray;

		[SerializeField]
		private string saveChars;

		private const string containerID = "storage";

		public ReadOnlyCollection<string> files => null;

		public IEnumerator SaveSettings(Action callback = null)
		{
			return null;
		}

		public IEnumerator LoadSettingsData(Action callback = null)
		{
			return null;
		}

		public IEnumerator CreateAndSaveSettingsData(Action callback = null)
		{
			return null;
		}

		public IEnumerator SaveCurrent(WorldMaster worldMaster, Action callback = null)
		{
			return null;
		}

		public IEnumerator<byte[]> LoadSaveToByteArray(string filePath, Action callback = null)
		{
			return null;
		}

		public SaveData TryDeserilizeSaveData(byte[] data)
		{
			return null;
		}

		public IEnumerator FillSaveCard(SaveCard card)
		{
			return null;
		}

		private IEnumerator SaveToPath(string path, SaveData data)
		{
			return null;
		}

		public IEnumerator DeleteCard(SaveCard card)
		{
			return null;
		}

		private IEnumerator MoveAllSaves()
		{
			return null;
		}

		public IEnumerator<bool> FilesListChanged(Action callback = null)
		{
			return null;
		}

		public IEnumerator RefreshFilesList(Action callback = null)
		{
			return null;
		}

		public IEnumerator<string> GetUniqueSaveName()
		{
			return null;
		}

		public string GetFileNameFromAbsolutePath(string fullPath)
		{
			return null;
		}

		private string GetSettingsFilePath(string fileName)
		{
			return null;
		}

		private string GetSaveFilePath(string fileName)
		{
			return null;
		}

		public bool LastSaveIsEmpty()
		{
			return false;
		}
	}
}
