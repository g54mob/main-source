using System;
using System.Collections;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Layers;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.OcclusionCulling;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.View;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Stockpiles
{
	public class StockpileView : SelectableObject, IOcclusionObject
	{
		private readonly LayerObjectHide layerObjectHide = new LayerObjectHide();

		private Mesh mesh;

		private MeshCollider meshCollider;

		private MeshFilter meshFilter;

		private MeshRenderer meshRenderer;

		private MaterialPropertyBlock propertyBlock;

		private IEnumerator outlineDelayCoroutine;

		[field: NonSerialized]
		public StockpileInstance StockpileInstance { get; private set; }

		public OcclusionCullingMode OcclusionCullingMode => OcclusionCullingMode.CanBeOccludedOnly;

		public bool IsOcclusionCulled
		{
			get
			{
				return layerObjectHide.IsOcclusionCulled;
			}
			set
			{
				layerObjectHide.IsOcclusionCulled = value;
			}
		}

		public Bounds OcclusionLocalSpaceBoundingBox => new Bounds(meshCollider.bounds.center - WorldPosition, meshCollider.bounds.size);

		public Vector3 WorldPosition => StockpileInstance.GetPosition();

		public override bool Visible => layerObjectHide.Visible;

		protected override void Awake()
		{
			base.Awake();
			meshFilter = base.gameObject.GetComponent<MeshFilter>();
			meshCollider = base.gameObject.GetComponent<MeshCollider>();
		}

		public override WorldObject GetAsWorldObject()
		{
			return StockpileInstance;
		}

		protected override bool IsSelectionNull()
		{
			if (StockpileInstance != null)
			{
				return StockpileInstance.HasDisposed;
			}
			return true;
		}

		private void SetColor(Color color)
		{
			if (propertyBlock == null)
			{
				propertyBlock = new MaterialPropertyBlock();
			}
			if (meshRenderer == null)
			{
				meshRenderer = GetComponent<MeshRenderer>();
			}
			propertyBlock.SetColor("_StockpileColor", color);
			meshRenderer.SetPropertyBlock(propertyBlock);
		}

		public void Setup(StockpileInstance stockpileInstance, Color color)
		{
			StockpileInstance = stockpileInstance;
			layerObjectHide.SetupColliders(meshCollider);
			layerObjectHide.SetupMeshRenderers(meshRenderer);
			layerObjectHide.Setup(StockpileInstance.GridDataPosition.y, StockpileInstance.Blueprint.LayerHideOffset, StockpileInstance.Blueprint.LayerShadowOffset, LayerHideType.Stockpile);
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += layerObjectHide.RefreshVisibility;
			MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent += layerObjectHide.RefreshVisibility;
			layerObjectHide.RefreshVisibility(MonoSingleton<World>.Instance.ElevationLevel);
			SetColor(color);
			MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Blueprint);
		}

		public void Setup(Mesh mesh)
		{
			meshFilter = GetComponent<MeshFilter>();
			this.mesh = meshFilter.mesh;
			meshCollider = GetComponentInChildren<MeshCollider>();
			meshRenderer = GetComponent<MeshRenderer>();
			LoadMesh(mesh);
		}

		public void Destroy()
		{
			if (!(this == null))
			{
				DestroySelectableObject();
				if (MonoSingleton<LayerHidingManager>.IsInstantiated() && layerObjectHide != null)
				{
					MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= layerObjectHide.RefreshVisibility;
					MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= layerObjectHide.RefreshVisibility;
				}
				StockpileInstance?.Dispose();
				StockpileInstance = null;
				if (base.gameObject != null)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}

		public override InfoPanelData GetInfoPanelData()
		{
			if (StockpileInstance == null || StockpileInstance.HasDisposed)
			{
				return null;
			}
			InfoPanelHeader header = new InfoPanelHeader(StockpileInstance.ObjectId, StockpileInstance.StorageName, string.Empty);
			InfoPanelBody panelBody = GetPanelBody();
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions());
			return new InfoPanelData(InfoPanelDataType.General, header, panelBody, footer, new InfoPanelStockpile(StockpileInstance));
		}

		public override string GetMultiselectName()
		{
			return "stockpile";
		}

		public override string GetSimpleName()
		{
			return MonoSingleton<LocalizationController>.Instance.GetText("ctrl_Stockpile");
		}

		public override InfoPanelData UpdateCallback()
		{
			return GetInfoPanelData();
		}

		protected virtual InfoPanelBody GetPanelBody()
		{
			return new InfoPanelBody(StockpileInstance.ObjectId, StockpileInstance.StorageName, string.Empty, GetInfoStats(), null, null, null, GetInfos(), StockpileInstance.BuildingSubcategoryUI);
		}

		protected virtual List<InfoPanelAction> GetInfoPanelActions()
		{
			if (StockpileInstance == null || StockpileInstance.HasDisposed || !StockpileInstance.OwnedByPlayer())
			{
				return null;
			}
			if (TutorialManager.IsTutorialActive)
			{
				return new List<InfoPanelAction>();
			}
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Deconstructing"), Destroy)
			};
			KeyValuePair<SelectionInputActionData, Action>[] objectActions2 = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("CopyBuilding"), CopyBuilding)
			};
			KeyValuePair<SelectionInputActionData, Action>[] objectActions3 = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ExpandZone"), ExpandStockpile)
			};
			KeyValuePair<SelectionInputActionData, Action>[] objectActions4 = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ShrinkZone"), ShrinkStockpile)
			};
			return new List<InfoPanelAction>
			{
				new InfoPanelAction(objectActions),
				new InfoPanelAction(objectActions2),
				new InfoPanelAction(objectActions3),
				new InfoPanelAction(objectActions4)
			};
		}

		private void CopyBuilding()
		{
			Deselect();
			MonoSingleton<StorageCommonManager>.Instance.OnCopyStorage(StockpileInstance);
			MonoSingleton<UIController>.Instance.CopyBuilding(StockpileInstance.Blueprint.GetID(), StockpileInstance.Blueprint.BuildingCategoryUI, StockpileInstance.Blueprint.BuildingSubCategoryUI);
		}

		private void ExpandStockpile()
		{
			if (MonoSingleton<SelectionManager>.Instance.OrderType != OrderType.ExpandZone)
			{
				MonoSingleton<StockpileManager>.Instance.SetStockpileToModify(StockpileInstance);
				MonoSingleton<SelectionManager>.Instance.ExpandZone(StockpileInstance.Blueprint.GetID());
				MonoSingleton<UIController>.Instance.ModifyZoneButtonClicked();
			}
		}

		private void ShrinkStockpile()
		{
			if (MonoSingleton<SelectionManager>.Instance.OrderType != OrderType.ShrinkZone)
			{
				MonoSingleton<StockpileManager>.Instance.SetStockpileToModify(StockpileInstance);
				MonoSingleton<SelectionManager>.Instance.ShrinkZone(StockpileInstance.Blueprint.GetID());
				MonoSingleton<UIController>.Instance.ModifyZoneButtonClicked();
			}
		}

		private List<InfoPanelStat> GetInfoStats()
		{
			return new List<InfoPanelStat>
			{
				new InfoPanelStat("menu_stockplie_size", "/", new IntRange(StockpileInstance.StoredResourcesCount, StockpileInstance.Positions.Count))
			};
		}

		private List<string> GetInfos()
		{
			List<string> list = new List<string>();
			list.AddIfNotNull(string.Format("{0}: <color=#ffeca8>{1}, {2}, {3}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("start_position"), StockpileInstance.Start.x, StockpileInstance.Start.y, StockpileInstance.Start.z), StockpileInstance.Start);
			list.AddIfNotNull(string.Format("{0}: <color=#ffeca8>{1}, {2}, {3}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("end_position"), StockpileInstance.End.x, StockpileInstance.End.y, StockpileInstance.End.z), StockpileInstance.End);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <color=#ffeca8>{1}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("total_spaces"), StockpileInstance.Positions.Count), StockpileInstance.Positions.Count, -1f);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <color=#ffeca8>{1}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("used_spaces"), StockpileInstance.StoredResourcesCount), StockpileInstance.StoredResourcesCount, -1f);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <color=#ffeca8>{1}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("free_spaces"), StockpileInstance.Positions.Count - StockpileInstance.StoredResourcesCount), StockpileInstance.StoredResourcesCount, -1f);
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<Vec3Int, StockpileSpaceData> item in StockpileInstance.Grid)
			{
				StockpileSpaceData value = item.Value;
				if (value == null)
				{
					num2++;
					continue;
				}
				if (value.HasAnyReservations())
				{
					num++;
					continue;
				}
				ResourceInstance resourceInstance = value.Pile?.GetStoredResource();
				if (value.Pile == null || resourceInstance?.Amount <= resourceInstance?.Blueprint.StackingLimit)
				{
					num2++;
				}
			}
			list.AddIfNotNull(string.Format("{0}: <color=#ffeca8>{1}/{2}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("reserved_spaces"), num, num2), StockpileInstance);
			return list;
		}

		private void LoadMesh(Mesh mesh)
		{
			this.mesh.Clear();
			this.mesh.vertices = mesh.vertices;
			this.mesh.triangles = mesh.triangles;
			this.mesh.RecalculateBounds();
			this.mesh.RecalculateNormals();
			this.mesh.RecalculateTangents();
			meshCollider.sharedMesh = this.mesh;
		}

		protected override void OnPointerEnter(Vector3 pos)
		{
			if (MonoSingleton<SelectionManager>.Instance.OrderType == OrderType.None)
			{
				outlineDelayCoroutine = OutlineDelayCoroutine(pos);
				StartCoroutine(outlineDelayCoroutine);
			}
		}

		protected override void OnPointerExit(Vector3 pos)
		{
			base.OnPointerExit(pos);
			if (outlineDelayCoroutine != null)
			{
				StopCoroutine(outlineDelayCoroutine);
				outlineDelayCoroutine = null;
			}
		}

		private IEnumerator OutlineDelayCoroutine(Vector3 pos)
		{
			yield return new WaitForSecondsRealtime(0.25f);
			if (ShouldIgnoreHoverHighlight())
			{
				yield return null;
			}
			base.OnPointerEnter(pos);
		}

		private bool ShouldIgnoreHoverHighlight()
		{
			OrderType orderType = MonoSingleton<SelectionManager>.Instance.OrderType;
			if (orderType == OrderType.None || orderType == OrderType.ExpandZone || orderType == OrderType.ShrinkZone)
			{
				return false;
			}
			return true;
		}
	}
}
