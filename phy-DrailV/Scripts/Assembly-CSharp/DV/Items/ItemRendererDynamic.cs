using DV.CabControls;
using UnityEngine;

namespace DV.Items
{
	public class ItemRendererDynamic : MonoBehaviour
	{
		protected ItemBase itemBase;

		protected ItemTransparencyHandler handler;

		protected Renderer dynamicRenderer;

		protected MeshFilter meshFilter;

		protected Material[] materialsCache;

		protected Material[] originalMaterials;

		protected int originalLayer;

		protected bool hasAnyTransparent;

		protected Material[] dynamicMaterialsCache;

		private bool initialized;

		protected virtual void Start()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (initialized)
			{
				return;
			}
			handler = base.gameObject.GetComponentInParentIncludingInactive<ItemTransparencyHandler>();
			itemBase = base.gameObject.GetComponentInParentIncludingInactive<ItemBase>();
			if (itemBase == null)
			{
				Debug.LogError("ItemRendererDynamic: Missing ItemBase component. Dynamic transparency will not work. Destroying self.", base.gameObject);
				Object.Destroy(this);
				return;
			}
			if (!TryGetComponent<Renderer>(out dynamicRenderer))
			{
				Debug.LogError("ItemRendererDynamic: Missing Renderer component. Dynamic transparency will not work. Destroying self.", this);
				Object.Destroy(this);
				return;
			}
			if (!TryGetComponent<MeshFilter>(out meshFilter))
			{
				Debug.LogError("ItemRendererDynamic: Missing MeshFilter component. Dynamic transparency will not work. Destroying self.", this);
				Object.Destroy(this);
				return;
			}
			originalMaterials = dynamicRenderer.sharedMaterials;
			materialsCache = new Material[originalMaterials.Length];
			originalLayer = dynamicRenderer.gameObject.layer;
			if (handler != null && handler.IsTransparent)
			{
				OnTransparencyChanged(isTransparent: true);
			}
			SetupListeners(on: true);
			initialized = true;
		}

		protected virtual void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (!(handler == null))
			{
				if (on)
				{
					handler.TransparencyChanged += OnTransparencyChanged;
				}
				else
				{
					handler.TransparencyChanged -= OnTransparencyChanged;
				}
			}
		}

		public void UpdateDynamicMaterialsCache(Material[] newMaterials)
		{
			dynamicMaterialsCache = newMaterials;
			if (handler != null)
			{
				OnTransparencyChanged(handler.IsTransparent);
			}
			else
			{
				dynamicRenderer.sharedMaterials = dynamicMaterialsCache;
			}
		}

		public void UpdateDynamicMesh(Mesh newMesh)
		{
			meshFilter.sharedMesh = newMesh;
		}

		protected virtual void OnTransparencyChanged(bool isTransparent)
		{
			bool flag = dynamicMaterialsCache != null && dynamicMaterialsCache.Length != 0;
			if (isTransparent)
			{
				if (flag)
				{
					dynamicRenderer.sharedMaterials = dynamicMaterialsCache;
				}
				originalMaterials = dynamicRenderer.sharedMaterials;
				(hasAnyTransparent, originalLayer) = ItemTransparencyHandler.SetTransparent(dynamicRenderer, materialsCache);
				return;
			}
			if (hasAnyTransparent)
			{
				ItemTransparencyHandler.SetOpaque(dynamicRenderer, originalMaterials, originalLayer, itemBase);
			}
			else if (flag)
			{
				dynamicRenderer.sharedMaterials = dynamicMaterialsCache;
				originalMaterials = dynamicMaterialsCache;
			}
			hasAnyTransparent = false;
		}
	}
}
