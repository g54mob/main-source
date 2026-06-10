using System;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Terrain;
using UnityEngine;

namespace NSMedieval.View.Slope
{
	[Serializable]
	public class SlopeView : MonoBehaviour, IDisposable
	{
		private static int outlineLayer;

		[NonSerialized]
		private SlopeInstance instance;

		[SerializeField]
		private GameObject selectedObject;

		[SerializeField]
		private GameObject orderGivenObject;

		[SerializeField]
		private GameObject colliderForSelection;

		[SerializeField]
		private GameObject selectionOutline;

		[SerializeField]
		private Material materialX;

		[SerializeField]
		private Material materialZ;

		[SerializeField]
		private MeshRenderer meshRendererSwapMaterial;

		private int selectedLayerOld = -1;

		private bool isMeshRotated90;

		private int SelectedLayerOld
		{
			get
			{
				if (selectedLayerOld == -1)
				{
					selectedLayerOld = selectionOutline.layer;
				}
				return selectedLayerOld;
			}
		}

		private int OutlineLayer
		{
			get
			{
				if (outlineLayer == -1)
				{
					outlineLayer = LayerMask.NameToLayer("Outline");
				}
				return outlineLayer;
			}
		}

		public SlopeInstance SlopeInstance => instance;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			outlineLayer = -1;
		}

		public void Setup(SlopeInstance instance)
		{
			this.instance = instance;
			if (instance != null)
			{
				base.gameObject.name = instance.BlueprintId + "_" + instance.Name;
			}
			int value = (int)instance.Angle;
			isMeshRotated90 = Math.Abs(value) % 180 == 90;
			if (isMeshRotated90)
			{
				Material material = meshRendererSwapMaterial.sharedMaterials[0];
				meshRendererSwapMaterial.sharedMaterials = new Material[3] { material, materialZ, materialX };
			}
			UpdateMapMaskMaterial();
		}

		public void Dispose()
		{
			if (!(base.gameObject == null))
			{
				instance = null;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public void SetSelectedObjectHoveringVisuals(bool hoverSelecting)
		{
			if ((bool)selectedObject)
			{
				selectedObject.SetActive(hoverSelecting);
			}
		}

		public void RefreshSelectionOutline()
		{
			if ((bool)selectionOutline)
			{
				selectionOutline.layer = (SlopeInstance.Selected ? OutlineLayer : SelectedLayerOld);
			}
		}

		public void MarkForDigging()
		{
			if ((bool)orderGivenObject)
			{
				orderGivenObject.SetActive(value: true);
			}
		}

		public void CancelDigging()
		{
			if ((bool)orderGivenObject)
			{
				orderGivenObject.SetActive(value: false);
			}
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.LayerChangeEvent += OnLayerChanged;
			if (selectedLayerOld == -1)
			{
				selectedLayerOld = selectionOutline.layer;
			}
		}

		private void OnDestroy()
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.LayerChangeEvent -= OnLayerChanged;
			}
		}

		private void OnLayerChanged(float elevation, int maxElevation)
		{
			if (instance != null && MonoSingleton<World>.IsInstantiated() && !(colliderForSelection == null))
			{
				bool active = elevation >= (float)instance.GridDataPosition.y;
				colliderForSelection.SetActive(active);
			}
		}

		private void UpdateMapMaskMaterial()
		{
			if (MonoSingleton<GroundManager>.IsInstantiated())
			{
				MonoSingleton<GroundManager>.Instance.MapGenerationTextures.SlopeAdded(instance);
			}
		}

		private void OnDrawGizmos()
		{
			if (instance == null || instance.Positions == null)
			{
				return;
			}
			foreach (Vec3Int position in instance.Positions)
			{
				Gizmos.DrawSphere(GridUtils.GetWorldPosition(position), 0.6f);
			}
		}
	}
}
