using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RLD
{
	public class RTPrefabScrollView : MonoBehaviour
	{
		public delegate void PrefabPreviewClickedHandler(RTPrefab prefab);

		public delegate void PrefabPreviewHoverEnterHandler(RTPrefab prefab);

		public delegate void PrefabPreviewHoverExitHandler(RTPrefab prefab);

		private ObjectPool _previewButtonPool;

		private GameObject _gridObject;

		private GridLayoutGroup _gridLayoutGroup;

		public event PrefabPreviewClickedHandler PrefabPreviewClicked;

		public event PrefabPreviewHoverEnterHandler PrefabPreviewHoverEnter;

		public event PrefabPreviewHoverExitHandler PrefabPreviewHoverExit;

		public void AddPrefabPreview(RTPrefab prefab)
		{
			GameObject pooledObject = _previewButtonPool.GetPooledObject();
			pooledObject.name = "Preview_" + prefab.UnityPrefab.name;
			Image component = pooledObject.GetComponent<Image>();
			if (component != null)
			{
				component.sprite = prefab.PreviewSprite;
			}
			RTPrefabPreviewButton component2 = pooledObject.GetComponent<RTPrefabPreviewButton>();
			component2.Prefab = prefab;
			component2.Text = prefab.UnityPrefab.name;
			component2.HoverEnter -= OnPrefabPreviewHoverEnter;
			component2.HoverEnter += OnPrefabPreviewHoverEnter;
			component2.HoverExit -= OnPrefabPreviewHoverExit;
			component2.HoverExit += OnPrefabPreviewHoverExit;
			Button component3 = pooledObject.GetComponent<Button>();
			if (component3 != null)
			{
				component3.onClick.RemoveListener(OnPreviewButtonClicked);
				component3.onClick.AddListener(OnPreviewButtonClicked);
			}
		}

		public void ClearPreviews()
		{
			_previewButtonPool.MarkAllAsUnused();
		}

		public void SyncWithLib(RTPrefabLib prefabLib)
		{
			ClearPreviews();
			if (prefabLib != null)
			{
				for (int i = 0; i < prefabLib.NumPrefabs; i++)
				{
					RTPrefab prefab = prefabLib.GetPrefab(i);
					AddPrefabPreview(prefab);
				}
			}
		}

		private void Awake()
		{
			_gridLayoutGroup = base.gameObject.GetComponentInChildren<GridLayoutGroup>();
			_gridObject = _gridLayoutGroup.gameObject;
			GameObject sourceObject = Resources.Load("Prefabs/RTPrefabPreviewButton") as GameObject;
			_previewButtonPool = new ObjectPool(sourceObject, 100, ObjectPool.GrowMode.ByAmount);
			_previewButtonPool.GrowAmount = 30;
			_previewButtonPool.SetPooledObjectsParent(_gridObject.transform);
		}

		private void OnPreviewButtonClicked()
		{
			List<RaycastResult> hoveredUIElements = MonoSingleton<RTScene>.Get.GetHoveredUIElements();
			if (hoveredUIElements.Count == 0)
			{
				return;
			}
			foreach (RaycastResult item in hoveredUIElements)
			{
				RTPrefabPreviewButton component = item.gameObject.GetComponent<RTPrefabPreviewButton>();
				if (component != null)
				{
					if (this.PrefabPreviewClicked != null)
					{
						this.PrefabPreviewClicked(component.Prefab);
					}
					break;
				}
			}
		}

		private void OnPrefabPreviewHoverEnter(RTPrefab prefab)
		{
			if (this.PrefabPreviewHoverEnter != null)
			{
				this.PrefabPreviewHoverEnter(prefab);
			}
		}

		private void OnPrefabPreviewHoverExit(RTPrefab prefab)
		{
			if (this.PrefabPreviewHoverExit != null)
			{
				this.PrefabPreviewHoverExit(prefab);
			}
		}
	}
}
