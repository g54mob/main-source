using System;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class SaveManager : CTSBehaviour
	{
		public enum ESaveState
		{
			None = 0,
			Save = 1,
			LoadInit = 2,
			LoadPost = 3
		}

		private readonly List<SaveContainer> _saveContainers = new List<SaveContainer>();

		private readonly List<SaveContainer> _loadInitContainers = new List<SaveContainer>();

		private readonly List<SaveContainer> _loadPostContainers = new List<SaveContainer>();

		[SerializeField]
		private int _wipePoint;

		public static ESaveState CurrentSaveState { get; private set; }

		public static event Action OnLoadingFinished;

		protected override void OnAwake()
		{
			SaveContainer[] componentsInChildren = GetComponentsInChildren<SaveContainer>();
			_saveContainers.AddRange(componentsInChildren.OrderBy((SaveContainer c) => c.SaveOrder));
			_loadInitContainers.AddRange(componentsInChildren.OrderBy((SaveContainer c) => c.LoadInitOrder));
			_loadPostContainers.AddRange(componentsInChildren.OrderBy((SaveContainer c) => c.LoadPostOrder));
		}

		private void OnDestroy()
		{
			_saveContainers.Clear();
			_loadInitContainers.Clear();
			_loadPostContainers.Clear();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void Clear()
		{
			foreach (SaveContainer saveContainer in _saveContainers)
			{
				try
				{
					saveContainer.Clear();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void SaveTest()
		{
			Save("Test");
		}

		[Button(null, EButtonEnableMode.Always)]
		private void LoadTest()
		{
			Load("Test");
		}

		public void Save(string saveName)
		{
			ES3Settings globalFolderSettings = SaveSettings.GetGlobalFolderSettings(saveName);
			if (ES3.FileExists(globalFolderSettings))
			{
				ES3.CreateBackup(globalFolderSettings);
			}
			ES3Settings cache = SaveSettings.Cache;
			cache.path = globalFolderSettings.path;
			ES3.DeleteFile(cache);
			ClassReferenceManager.Clear();
			CurrentSaveState = ESaveState.Save;
			SaveVersion(cache);
			foreach (SaveContainer saveContainer in _saveContainers)
			{
				try
				{
					saveContainer.Save(cache);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			ClassReferenceManager.SaveValues(cache);
			CurrentSaveState = ESaveState.None;
			ClassReferenceManager.Clear();
			ES3.StoreCachedFile(globalFolderSettings);
			Resources.UnloadUnusedAssets();
			GC.Collect();
		}

		private void SaveVersion(ES3Settings settings)
		{
			string version = Application.version;
			int num = version.IndexOf('-', StringComparison.InvariantCultureIgnoreCase) + 1;
			string text = version;
			int num2 = num;
			if (int.TryParse(text.Substring(num2, text.Length - num2), out var result))
			{
				ES3.Save("Version", result, settings);
				return;
			}
			throw new Exception("Couldn't read the date");
		}

		public bool Load(string saveName)
		{
			ES3Settings globalFolderSettings = SaveSettings.GetGlobalFolderSettings(saveName);
			if (!ES3.FileExists(globalFolderSettings))
			{
				Debug.LogError("Couldn't load a save called " + saveName + ".sav");
				return false;
			}
			if (ES3.Load("Version", 0, globalFolderSettings) < _wipePoint)
			{
				return false;
			}
			SaveSettings.Cache.path = globalFolderSettings.path;
			ES3.CacheFile(SaveSettings.Cache);
			CurrentSaveState = ESaveState.LoadInit;
			foreach (SaveContainer loadInitContainer in _loadInitContainers)
			{
				try
				{
					loadInitContainer.LoadInit(SaveSettings.Cache);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			ClassReferenceManager.LoadValues(SaveSettings.Cache);
			CurrentSaveState = ESaveState.LoadPost;
			foreach (SaveContainer loadPostContainer in _loadPostContainers)
			{
				try
				{
					loadPostContainer.LoadPost(SaveSettings.Cache);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
			}
			CurrentSaveState = ESaveState.None;
			ClassReferenceManager.Clear();
			GC.Collect();
			Resources.UnloadUnusedAssets();
			SaveManager.OnLoadingFinished?.Invoke();
			return true;
		}
	}
}
