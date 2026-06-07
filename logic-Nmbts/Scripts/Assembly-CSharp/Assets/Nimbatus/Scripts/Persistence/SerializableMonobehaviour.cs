using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public abstract class SerializableMonobehaviour<T, D> : SerializedMonoBehaviour where T : SerializableMonobehaviour<T, D> where D : class
	{
		public List<EGameMode> DeactivateIngameModes = new List<EGameMode>();

		public int CallPriority;

		public static T Instance { get; set; }

		internal abstract string Filename { get; }

		protected bool HasBeenLoaded { get; private set; }

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = GetComponent<T>();
				UnityEngine.Object.DontDestroyOnLoad(Instance);
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
			if (SaveManager.LoadedSave != null)
			{
				SaveGameManager_GameLoaded();
			}
		}

		public virtual void OnEnable()
		{
			SaveManager.GameSaved.Subscribe(SaveGameManager_GameSaved, CallPriority);
			SaveManager.GameLoaded.Subscribe(SaveGameManager_GameLoaded, CallPriority);
		}

		public virtual void OnDisable()
		{
			SaveManager.GameSaved.Unsubscribe(SaveGameManager_GameSaved);
			SaveManager.GameLoaded.Unsubscribe(SaveGameManager_GameLoaded);
		}

		public bool IsActiveInThisMode()
		{
			if (DeactivateIngameModes.Contains(SaveManager.LoadedSave.Mode))
			{
				return false;
			}
			return true;
		}

		private void SaveGameManager_GameSaved()
		{
			if (IsActiveInThisMode())
			{
				Save();
			}
		}

		private void SaveGameManager_GameLoaded()
		{
			if (!IsActiveInThisMode())
			{
				Reset();
				return;
			}
			HasBeenLoaded = false;
			PreLoad();
			Load();
			PostLoad();
		}

		public static void Save()
		{
			if (Instance == null || string.IsNullOrEmpty(Instance.Filename))
			{
				return;
			}
			using (FileStream stream = new FileStream(Path.Combine(SaveManager.ActiveDataFolderPath, Instance.Filename), FileMode.Create))
			{
				using (StreamWriter textWriter = new StreamWriter(stream))
				{
					new XmlSerializer(typeof(D)).Serialize(textWriter, Instance.SaveToFile());
				}
			}
		}

		public static void Load()
		{
			if (Instance == null || string.IsNullOrEmpty(Instance.Filename))
			{
				return;
			}
			string path = Path.Combine(SaveManager.ActiveDataFolderPath, Instance.Filename);
			try
			{
				if (File.Exists(path))
				{
					using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
					{
						D data = new XmlSerializer(typeof(D)).Deserialize(stream) as D;
						Instance.LoadFromFile(data);
						Instance.HasBeenLoaded = true;
						return;
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void PreLoad()
		{
		}

		protected virtual void PostLoad()
		{
		}

		protected virtual void Reset()
		{
		}

		protected abstract void LoadFromFile(D data);

		protected abstract D SaveToFile();
	}
}
