using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RTPrefabLib
	{
		[SerializeField]
		private string _name = string.Empty;

		[SerializeField]
		private List<RTPrefab> _prefabs = new List<RTPrefab>();

		public int NumPrefabs => _prefabs.Count;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public event PrefabCreatedInLibHandler PrefabCreated;

		public event PrefabRemovedFromLibHandler PrefabRemoved;

		public event PrefabLibClearedHandler Cleared;

		public RTPrefab CreatePrefab(GameObject unityPrefab, Texture2D prefabPreview)
		{
			if (Contains(unityPrefab) || unityPrefab == null)
			{
				return null;
			}
			RTPrefab rTPrefab = new RTPrefab();
			rTPrefab.UnityPrefab = unityPrefab;
			rTPrefab.PreviewTexture = prefabPreview;
			_prefabs.Add(rTPrefab);
			if (this.PrefabCreated != null)
			{
				this.PrefabCreated(this, rTPrefab);
			}
			return rTPrefab;
		}

		public RTPrefab CreatePrefabFromSceneObject(GameObject sceneObject)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(sceneObject);
			MonoSingleton<RTPrefabLibDb>.Get.EditorPrefabPreviewGen.BeginGenSession(MonoSingleton<RTPrefabLibDb>.Get.PrefabPreviewLookAndFeel);
			Texture2D previewTexture = MonoSingleton<RTPrefabLibDb>.Get.EditorPrefabPreviewGen.Generate(gameObject);
			MonoSingleton<RTPrefabLibDb>.Get.EditorPrefabPreviewGen.EndGenSession();
			gameObject.SetActive(value: false);
			RTPrefab rTPrefab = new RTPrefab();
			rTPrefab.UnityPrefab = gameObject;
			rTPrefab.PreviewTexture = previewTexture;
			_prefabs.Add(rTPrefab);
			if (this.PrefabCreated != null)
			{
				this.PrefabCreated(this, rTPrefab);
			}
			return rTPrefab;
		}

		public List<RTPrefab> CreatePrefabsFromSceneObjects(List<GameObject> sceneObjects)
		{
			MonoSingleton<RTPrefabLibDb>.Get.EditorPrefabPreviewGen.BeginGenSession(MonoSingleton<RTPrefabLibDb>.Get.PrefabPreviewLookAndFeel);
			List<RTPrefab> list = new List<RTPrefab>();
			foreach (GameObject sceneObject in sceneObjects)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(sceneObject);
				Texture2D previewTexture = MonoSingleton<RTPrefabLibDb>.Get.EditorPrefabPreviewGen.Generate(gameObject);
				gameObject.SetActive(value: false);
				RTPrefab rTPrefab = new RTPrefab();
				rTPrefab.UnityPrefab = gameObject;
				rTPrefab.PreviewTexture = previewTexture;
				_prefabs.Add(rTPrefab);
				list.Add(rTPrefab);
				if (this.PrefabCreated != null)
				{
					this.PrefabCreated(this, rTPrefab);
				}
			}
			MonoSingleton<RTPrefabLibDb>.Get.EditorPrefabPreviewGen.EndGenSession();
			return list;
		}

		public void Remove(int prefabIndex)
		{
			if (prefabIndex >= 0 && prefabIndex < NumPrefabs)
			{
				RTPrefab prefab = _prefabs[prefabIndex];
				_prefabs.RemoveAt(prefabIndex);
				if (this.PrefabRemoved != null)
				{
					this.PrefabRemoved(this, prefab);
				}
			}
		}

		public void Remove(RTPrefab prefab)
		{
			int prefabIndex = GetPrefabIndex(prefab);
			if (prefabIndex >= 0)
			{
				Remove(prefabIndex);
			}
		}

		public void Clear()
		{
			_prefabs.Clear();
			if (this.Cleared != null)
			{
				this.Cleared(this);
			}
		}

		public bool Contains(GameObject unityPrefab)
		{
			return _prefabs.FindAll((RTPrefab item) => item.UnityPrefab == unityPrefab).Count != 0;
		}

		public bool Contains(RTPrefab prefab)
		{
			return _prefabs.Contains(prefab);
		}

		public int GetPrefabIndex(RTPrefab prefab)
		{
			return _prefabs.IndexOf(prefab);
		}

		public RTPrefab GetPrefab(int prefabIndex)
		{
			return _prefabs[prefabIndex];
		}

		public RTPrefab GetPrefab(GameObject unityPrefab)
		{
			List<RTPrefab> list = _prefabs.FindAll((RTPrefab item) => item.UnityPrefab == unityPrefab);
			if (list.Count == 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
