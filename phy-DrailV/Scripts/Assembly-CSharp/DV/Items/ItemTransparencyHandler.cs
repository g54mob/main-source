using System.Collections.Generic;
using DV.CabControls;
using DV.UI;
using DV.Utils;
using DV.VFX;
using UnityEngine;

namespace DV.Items
{
	public class ItemTransparencyHandler : MonoBehaviour
	{
		public delegate void TransparencyChangedDelegate(bool isTransparent);

		private Dictionary<Renderer, Material[]> transparentMaterialsArrayCache = new Dictionary<Renderer, Material[]>();

		private Queue<(Renderer renderer, Material[] materials, int originalLayer)> materialQueue = new Queue<(Renderer, Material[], int)>();

		protected ItemBase itemBase;

		private bool isTransparent;

		public static int TransparentLayer { get; private set; } = -1;

		public bool IsTransparent
		{
			get
			{
				return isTransparent;
			}
			private set
			{
				if (isTransparent != value)
				{
					isTransparent = value;
					this.TransparencyChanged?.Invoke(isTransparent);
				}
			}
		}

		public event TransparencyChangedDelegate TransparencyChanged;

		private void Start()
		{
			if (!VRManager.IsVREnabled())
			{
				Object.Destroy(this);
				return;
			}
			if (TransparentLayer < 0)
			{
				TransparentLayer = LayerMask.NameToLayer("Ignore Raycast");
			}
			itemBase = GetComponent<ItemBase>();
			itemBase.Grabbed += Grabbed;
			itemBase.Ungrabbed += Ungrabbed;
			base.enabled = false;
		}

		private void OnEnable()
		{
			if ((bool)itemBase)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += OnElementToggled;
				if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
				{
					TrySetTransparentAll();
				}
			}
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= OnElementToggled;
				TrySetOpaqueAll();
			}
		}

		private void OnElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
		{
			if (element.Type == CanvasController.ElementType.Inventory)
			{
				if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
				{
					TrySetTransparentAll();
				}
				else
				{
					TrySetOpaqueAll();
				}
			}
		}

		private void TrySetTransparentAll()
		{
			if (!IsTransparent)
			{
				SetTransparentAll();
				IsTransparent = true;
			}
		}

		protected virtual void SetTransparentAll()
		{
			Renderer[] renderers = itemBase.Renderers;
			foreach (Renderer renderer in renderers)
			{
				if (!ShouldHandleTransparency(renderer) || renderer.TryGetComponent<ItemRendererDynamic>(out var _))
				{
					continue;
				}
				Material[] sharedMaterials = renderer.sharedMaterials;
				if (!transparentMaterialsArrayCache.TryGetValue(renderer, out var value))
				{
					value = new Material[sharedMaterials.Length];
					transparentMaterialsArrayCache.Add(renderer, value);
				}
				var (flag, num) = SetTransparent(renderer, value);
				if (!flag)
				{
					if (num == -1)
					{
						Debug.LogError("Failed to set transparent for renderer " + renderer.name + " on item " + itemBase.name + " due to nulls.", this);
					}
				}
				else
				{
					materialQueue.Enqueue((renderer, sharedMaterials, num));
				}
			}
		}

		protected virtual bool ShouldHandleTransparency(Renderer renderer)
		{
			if (!renderer)
			{
				return false;
			}
			if (!renderer.enabled)
			{
				return false;
			}
			return true;
		}

		private void TrySetOpaqueAll()
		{
			if (IsTransparent)
			{
				SetOpaqueAll();
				IsTransparent = false;
			}
		}

		protected virtual void SetOpaqueAll()
		{
			while (materialQueue.Count > 0)
			{
				(Renderer, Material[], int) tuple = materialQueue.Dequeue();
				SetOpaque(tuple.Item1, tuple.Item2, tuple.Item3);
			}
			itemBase.RefreshLayersExternal();
		}

		private void Grabbed(ControlImplBase item)
		{
			base.enabled = true;
		}

		private void Ungrabbed(ControlImplBase item)
		{
			if (!item.IsGrabbed())
			{
				base.enabled = false;
			}
		}

		public static (bool success, int originalLayer) SetTransparent(Renderer renderer, Material[] materialCache)
		{
			if (renderer == null || materialCache == null)
			{
				Debug.LogError(string.Format("Either renderer or materialCache is null in {0}.{1}. Aborting. Renderer: {2}, materialCache: {3}", "ItemTransparencyHandler", "SetTransparent", renderer, materialCache));
				return (success: false, originalLayer: -1);
			}
			int layer = renderer.gameObject.layer;
			bool flag = false;
			Material[] sharedMaterials = renderer.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				Material material = sharedMaterials[i];
				if (!(material == null))
				{
					if (material.shader == SingletonBehaviour<MaterialUtils>.Instance.StandardShader)
					{
						materialCache[i] = SingletonBehaviour<MaterialUtils>.Instance.MakeTransparentCopy(material);
						flag = true;
					}
					else
					{
						materialCache[i] = material;
					}
				}
			}
			if (!flag)
			{
				return (success: false, originalLayer: layer);
			}
			renderer.gameObject.layer = TransparentLayer;
			renderer.materials = materialCache;
			return (success: true, originalLayer: layer);
		}

		public static void SetOpaque(Renderer renderer, Material[] originalMaterials, int originalLayer, ItemBase item = null)
		{
			if (renderer == null || originalMaterials == null)
			{
				Debug.LogError(string.Format("Either renderer or materialCache is null in {0}.{1}. Aborting.  Renderer: {2}, materialCache: {3}", "ItemTransparencyHandler", "SetOpaque", renderer, originalMaterials));
				return;
			}
			Material[] sharedMaterials = renderer.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				Object.Destroy(sharedMaterials[i]);
			}
			renderer.sharedMaterials = originalMaterials;
			renderer.gameObject.layer = originalLayer;
			if (item != null)
			{
				item.RefreshLayersExternal();
			}
		}
	}
}
