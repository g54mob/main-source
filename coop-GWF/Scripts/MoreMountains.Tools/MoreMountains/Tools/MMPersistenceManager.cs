using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreMountains.Tools
{
	public class MMPersistenceManager : MMPersistentSingleton<MMPersistenceManager>, MMEventListener<MMGameEvent>, MMEventListenerBase
	{
		[Header("Persistence")]
		[Tooltip("A persistence ID used to identify the data associated to this manager. Usually you'll want to leave this to its default value.")]
		public string PersistenceID = "MMPersistency";

		[Header("Events")]
		[Tooltip("whether or not this manager should listen for save events. If you set this to false, you'll have to call SaveToMemory or SaveFromMemoryToFile manually")]
		public bool ListenForSaveEvents = true;

		[Tooltip("whether or not this manager should listen for load events. If you set this to false, you'll have to call LoadFromMemory or LoadFromFileToMemory manually")]
		public bool ListenForLoadEvents = true;

		[Tooltip("whether or not this manager should listen for save to memory events. If you set this to false, you'll have to call SaveToMemory manually")]
		public bool ListenForSaveToMemoryEvents = true;

		[Tooltip("whether or not this manager should listen for load from memory events. If you set this to false, you'll have to call LoadFromMemory manually")]
		public bool ListenForLoadFromMemoryEvents = true;

		[Tooltip("whether or not this manager should listen for save to file events. If you set this to false, you'll have to call SaveFromMemoryToFile manually")]
		public bool ListenForSaveToFileEvents = true;

		[Tooltip("whether or not this manager should listen for load from file events. If you set this to false, you'll have to call LoadFromFileToMemory manually")]
		public bool ListenForLoadFromFileEvents = true;

		[Tooltip("whether or not this manager should save data to file on save events")]
		public bool SaveToFileOnSaveEvents = true;

		[Tooltip("whether or not this manager should load data from file on load events")]
		public bool LoadFromFileOnLoadEvents = true;

		[Header("Debug Buttons (Only at Runtime)")]
		[MMInspectorButton("SaveToMemory")]
		public bool SaveToMemoryButton;

		[MMInspectorButton("LoadFromMemory")]
		public bool LoadFromMemoryButton;

		[MMInspectorButton("SaveFromMemoryToFile")]
		public bool SaveToFileButton;

		[MMInspectorButton("LoadFromFileToMemory")]
		public bool LoadFromFileButton;

		[MMInspectorButton("DeletePersistenceFile")]
		public bool DeletePersistenceFileButton;

		public DictionaryStringSceneData SceneDatas;

		public static string _resourceItemPath = "Persistence/";

		public static string _saveFolderName = "MMTools/";

		public static string _saveFileExtension = ".persistence";

		protected string _currentSceneName;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		protected static void InitializeStatics()
		{
			MMPersistentSingleton<MMPersistenceManager>._instance = null;
		}

		protected override void Awake()
		{
			base.Awake();
			SceneDatas = new DictionaryStringSceneData();
		}

		public virtual void SaveToMemory()
		{
			ComputeCurrentSceneName();
			SceneDatas.Remove(_currentSceneName);
			MMPersistenceSceneData mMPersistenceSceneData = new MMPersistenceSceneData();
			mMPersistenceSceneData.ObjectDatas = new DictionaryStringString();
			IMMPersistent[] array = FindAllPersistentObjects();
			foreach (IMMPersistent iMMPersistent in array)
			{
				if (iMMPersistent.ShouldBeSaved())
				{
					mMPersistenceSceneData.ObjectDatas.Add(iMMPersistent.GetGuid(), iMMPersistent.OnSave());
				}
			}
			SceneDatas.Add(_currentSceneName, mMPersistenceSceneData);
			MMPersistenceEvent.Trigger(MMPersistenceEventType.DataSavedToMemory, PersistenceID);
		}

		public virtual void LoadFromMemory()
		{
			ComputeCurrentSceneName();
			if (!SceneDatas.TryGetValue(_currentSceneName, out var value) || value.ObjectDatas == null)
			{
				return;
			}
			IMMPersistent[] array = FindAllPersistentObjects();
			foreach (IMMPersistent iMMPersistent in array)
			{
				if (value.ObjectDatas.TryGetValue(iMMPersistent.GetGuid(), out var _))
				{
					iMMPersistent.OnLoad(value.ObjectDatas[iMMPersistent.GetGuid()]);
				}
			}
			MMPersistenceEvent.Trigger(MMPersistenceEventType.DataLoadedFromMemory, PersistenceID);
		}

		public virtual void SaveFromMemoryToFile()
		{
			MMSaveLoadManager.Save(new MMPersistenceManagerData
			{
				PersistenceID = PersistenceID,
				SaveDate = DateTime.Now.ToString(),
				SceneDatas = SceneDatas
			}, DetermineSaveName(), _saveFolderName);
			MMPersistenceEvent.Trigger(MMPersistenceEventType.DataSavedFromMemoryToFile, PersistenceID);
		}

		public virtual void LoadFromFileToMemory()
		{
			MMPersistenceManagerData mMPersistenceManagerData = (MMPersistenceManagerData)MMSaveLoadManager.Load(typeof(MMPersistenceManagerData), DetermineSaveName(), _saveFolderName);
			if (mMPersistenceManagerData != null && mMPersistenceManagerData.SceneDatas != null)
			{
				SceneDatas = new DictionaryStringSceneData();
				SceneDatas = mMPersistenceManagerData.SceneDatas;
			}
			MMPersistenceEvent.Trigger(MMPersistenceEventType.DataLoadedFromFileToMemory, PersistenceID);
		}

		public virtual void Save()
		{
			SaveToMemory();
			if (SaveToFileOnSaveEvents)
			{
				SaveFromMemoryToFile();
			}
		}

		public virtual void Load()
		{
			if (LoadFromFileOnLoadEvents)
			{
				LoadFromFileToMemory();
			}
			LoadFromMemory();
		}

		public virtual void DeletePersistencyMemoryForScene(string sceneName)
		{
			if (SceneDatas.TryGetValue(_currentSceneName, out var _))
			{
				SceneDatas.Remove(sceneName);
			}
		}

		public virtual void ResetPersistence()
		{
			DeletePersistenceMemory();
			DeletePersistenceFile();
		}

		public virtual void DeletePersistenceMemory()
		{
			SceneDatas = new DictionaryStringSceneData();
		}

		public virtual void DeletePersistenceFile()
		{
			MMSaveLoadManager.DeleteSave(DetermineSaveName(), _saveFolderName);
			Debug.LogFormat("Persistence save file deleted");
		}

		protected virtual IMMPersistent[] FindAllPersistentObjects()
		{
			return UnityEngine.Object.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None).OfType<IMMPersistent>().ToArray();
		}

		protected virtual void ComputeCurrentSceneName()
		{
			_currentSceneName = SceneManager.GetActiveScene().name;
		}

		protected virtual string DetermineSaveName()
		{
			return base.gameObject.name + "_" + PersistenceID + _saveFileExtension;
		}

		public virtual void OnMMEvent(MMGameEvent gameEvent)
		{
			if (gameEvent.EventName == "Save" && ListenForSaveEvents)
			{
				Save();
			}
			if (gameEvent.EventName == "Load" && ListenForLoadEvents)
			{
				Load();
			}
			if (gameEvent.EventName == "SaveToMemory" && ListenForSaveToMemoryEvents)
			{
				SaveToMemory();
			}
			if (gameEvent.EventName == "LoadFromMemory" && ListenForLoadFromMemoryEvents)
			{
				LoadFromMemory();
			}
			if (gameEvent.EventName == "SaveToFile" && ListenForSaveToFileEvents)
			{
				SaveFromMemoryToFile();
			}
			if (gameEvent.EventName == "LoadFromFile" && ListenForLoadFromFileEvents)
			{
				LoadFromFileToMemory();
			}
		}

		protected virtual void OnEnable()
		{
			this.MMEventStartListening();
		}

		protected virtual void OnDisable()
		{
			this.MMEventStopListening();
		}
	}
}
