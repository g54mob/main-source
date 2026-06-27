using System;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.ObjectPools;
using UnityEngine;

namespace Restory.Gameplay.SaveLoad
{
	[DisallowMultipleComponent]
	public class SaveableEntity : MonoBehaviour, ICleanableComponent
	{
		[Serializable]
		private class SaveableComponentCache
		{
			public string ID;

			public ISaveableComponentWriter Writer;
		}

		[Header("General settings")]
		[SerializeField]
		private SaveableAssetType assetType;

		[SerializeField]
		private SaveContextType contextType = SaveContextType.SceneContext;

		[SerializeField]
		private SaveModeType saveMode = SaveModeType.Individual;

		private IPreCaptureComponent[] preCaptureComponents = Array.Empty<IPreCaptureComponent>();

		private SaveableComponentCache[] captureComponents = Array.Empty<SaveableComponentCache>();

		private IPostCaptureComponent[] postCaptureComponents = Array.Empty<IPostCaptureComponent>();

		private IPreRestoreComponent[] preRestoreComponents = Array.Empty<IPreRestoreComponent>();

		private ISaveableComponentReader[] restoreComponents = Array.Empty<ISaveableComponentReader>();

		private IPostRestoreComponent[] postRestoreComponents = Array.Empty<IPostRestoreComponent>();

		private Dictionary<string, object> snapshot = new Dictionary<string, object>();

		public SaveModeType SaveMode
		{
			get
			{
				return saveMode;
			}
			set
			{
				saveMode = value;
			}
		}

		public bool Common => contextType == SaveContextType.Common;

		public SaveableAssetType AssetType
		{
			get
			{
				return assetType;
			}
			set
			{
				assetType = value;
			}
		}

		public bool IsInitialized { get; private set; }

		public void Initialize()
		{
			if (!IsInitialized)
			{
				preCaptureComponents = GetComponents<IPreCaptureComponent>();
				ISaveableComponentWriter[] components = GetComponents<ISaveableComponentWriter>();
				captureComponents = new SaveableComponentCache[components.Length];
				for (int i = 0; i < components.Length; i++)
				{
					ISaveableComponentWriter saveableComponentWriter = components[i];
					captureComponents[i] = new SaveableComponentCache
					{
						ID = GetSaveableID(saveableComponentWriter),
						Writer = saveableComponentWriter
					};
				}
				postCaptureComponents = GetComponents<IPostCaptureComponent>();
				preRestoreComponents = GetComponents<IPreRestoreComponent>();
				restoreComponents = GetComponents<ISaveableComponentReader>();
				postRestoreComponents = GetComponents<IPostRestoreComponent>();
				snapshot.EnsureCapacity(captureComponents.Length);
				IsInitialized = true;
			}
		}

		private void OnDestroy()
		{
			preCaptureComponents = Array.Empty<IPreCaptureComponent>();
			captureComponents = Array.Empty<SaveableComponentCache>();
			postCaptureComponents = Array.Empty<IPostCaptureComponent>();
			preRestoreComponents = Array.Empty<IPreRestoreComponent>();
			restoreComponents = Array.Empty<ISaveableComponentReader>();
			postRestoreComponents = Array.Empty<IPostRestoreComponent>();
			snapshot.Clear();
		}

		public void PreCapture()
		{
			Initialize();
			for (int i = 0; i < preCaptureComponents.Length; i++)
			{
				preCaptureComponents[i].PreCapture();
			}
		}

		public Dictionary<string, object> CombineStates(Dictionary<string, object> capturedObject)
		{
			foreach (KeyValuePair<string, object> item in capturedObject)
			{
				snapshot.TryAdd(item.Key, item.Value);
			}
			return snapshot;
		}

		public Dictionary<string, object> MakeSnapshot()
		{
			return CapturedState(captureComponents, snapshot);
		}

		public Dictionary<string, object> GetSnapshot()
		{
			return snapshot;
		}

		public void PostCapture()
		{
			for (int i = 0; i < postCaptureComponents.Length; i++)
			{
				postCaptureComponents[i].PostCapture();
			}
		}

		private static Dictionary<string, object> CapturedState(SaveableComponentCache[] savableComponents, Dictionary<string, object> capturedState)
		{
			foreach (SaveableComponentCache saveableComponentCache in savableComponents)
			{
				if (!(saveableComponentCache.Writer is IDirtyComponent { IsDirty: false }) || capturedState.ContainsKey(saveableComponentCache.ID))
				{
					capturedState[saveableComponentCache.ID] = saveableComponentCache.Writer.CaptureState();
				}
			}
			return capturedState;
		}

		public void PreRestore()
		{
			Initialize();
			for (int i = 0; i < preRestoreComponents.Length; i++)
			{
				preRestoreComponents[i].PreRestore();
			}
		}

		public void RestoreState(object capturedObject)
		{
			Dictionary<string, object> obj = (Dictionary<string, object>)capturedObject;
			snapshot.Clear();
			foreach (KeyValuePair<string, object> item in obj)
			{
				string key = item.Key;
				object value = item.Value;
				snapshot[key] = value;
			}
			for (int i = 0; i < restoreComponents.Length; i++)
			{
				ISaveableComponentReader saveableComponentReader = restoreComponents[i];
				string saveableID = GetSaveableID(saveableComponentReader);
				if (snapshot.TryGetValue(saveableID, out var value2))
				{
					saveableComponentReader.RestoreState(value2);
				}
			}
		}

		public void PostRestore()
		{
			Initialize();
			for (int i = 0; i < postRestoreComponents.Length; i++)
			{
				postRestoreComponents[i].PostRestore();
			}
		}

		private static string GetSaveableID(object saveable)
		{
			return saveable.GetType().ToString();
		}

		public void Clean()
		{
			snapshot.Clear();
		}
	}
}
