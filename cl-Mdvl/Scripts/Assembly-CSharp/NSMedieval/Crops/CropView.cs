using System;
using System.Collections;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Goap;
using NSMedieval.Layers;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.OcclusionCulling;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Crops
{
	public class CropView : SelectableObject, IOcclusionObject, IAdditionalMenuOwner, IGameDisposable, IDisposable
	{
		[NonSerialized]
		private CropfieldInstance cropfieldInstance;

		[NonSerialized]
		private MeshFilter meshFilter;

		[NonSerialized]
		private Mesh mesh;

		[NonSerialized]
		private MeshCollider meshCollider;

		[NonSerialized]
		private MaterialPropertyBlock propertyBlock;

		[NonSerialized]
		private MeshRenderer meshRenderer;

		private IEnumerator outlineDelayCoroutine;

		private LayerObjectHide layerObjectHide = new LayerObjectHide();

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

		public Bounds OcclusionLocalSpaceBoundingBox => new Bounds(meshCollider.bounds.center - WorldPosition, meshCollider.bounds.size + Vector3.up * 0.1f);

		public Vector3 WorldPosition => cropfieldInstance.WorldPosition;

		public override bool Visible => layerObjectHide.Visible;

		public CropfieldInstance CropfieldInstance => cropfieldInstance;

		public bool HasDisposed { get; private set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public override WorldObject GetAsWorldObject()
		{
			return cropfieldInstance;
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
			propertyBlock.SetColor("_FieldMarkColor", color);
			meshRenderer.SetPropertyBlock(propertyBlock);
		}

		public void Setup(CropfieldInstance cropfieldInstance, Color color)
		{
			this.cropfieldInstance = cropfieldInstance;
			layerObjectHide.SetupColliders(meshCollider);
			layerObjectHide.SetupMeshRenderers(meshRenderer);
			layerObjectHide.Setup(this.cropfieldInstance.GridDataPosition.y, this.cropfieldInstance.Blueprint.LayerHideOffset, this.cropfieldInstance.Blueprint.LayerShadowOffset, LayerHideType.Crop);
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

		private void Destroy()
		{
			if (this == null || base.gameObject == null)
			{
				Log.Warning("Drop double destruction crop view", "C:\\GIT\\dev\\Assets\\Scripts\\Crops\\CropView.cs");
			}
			else if (cropfieldInstance != null && !cropfieldInstance.HasDisposed)
			{
				DestroySelectableObject();
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= layerObjectHide.RefreshVisibility;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= layerObjectHide.RefreshVisibility;
				cropfieldInstance?.Dispose();
				if (mesh != null)
				{
					mesh.Clear();
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public override InfoPanelData GetInfoPanelData()
		{
			if (cropfieldInstance == null || cropfieldInstance.HasDisposed)
			{
				return null;
			}
			InfoPanelHeader header = new InfoPanelHeader(cropfieldInstance.CultivablePlant.GetID(), MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(cropfieldInstance.Blueprint.LocKeys)), string.Empty);
			InfoPanelBody panelBody = GetPanelBody();
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions());
			return new InfoPanelData(InfoPanelDataType.General, header, panelBody, footer, new InfoPanelCropfield(cropfieldInstance));
		}

		public override InfoPanelData UpdateCallback()
		{
			return GetInfoPanelData();
		}

		public override string GetSimpleName()
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(cropfieldInstance.CultivablePlant.LocKeys));
		}

		public override string GetMultiselectName()
		{
			return cropfieldInstance.CultivablePlant.GetID();
		}

		protected virtual InfoPanelBody GetPanelBody()
		{
			return new InfoPanelBody(cropfieldInstance.CultivablePlant.GetID(), cropfieldInstance.CultivablePlant.GetID(), string.Empty, GetInfoStats(), GetModifiers(), null, null, GetInfos(), cropfieldInstance.BuildingSubcategoryUI);
		}

		protected virtual List<InfoPanelAction> GetInfoPanelActions()
		{
			if (cropfieldInstance == null || cropfieldInstance.HasDisposed || !cropfieldInstance.OwnedByPlayer())
			{
				return null;
			}
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Deconstructing"), Dispose)
			};
			KeyValuePair<SelectionInputActionData, Action>[] objectActions2 = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("CopyBuilding"), CopyBuilding)
			};
			KeyValuePair<SelectionInputActionData, Action>[] objectActions3 = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ExpandZone"), ExpandCropfield)
			};
			KeyValuePair<SelectionInputActionData, Action>[] objectActions4 = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ShrinkZone"), ShrinkCropfield)
			};
			return new List<InfoPanelAction>
			{
				new InfoPanelAction(objectActions),
				new InfoPanelAction(objectActions2),
				new InfoPanelAction(objectActions3),
				new InfoPanelAction(objectActions4)
			};
		}

		protected override bool IsSelectionNull()
		{
			if (cropfieldInstance != null)
			{
				return cropfieldInstance.HasDisposed;
			}
			return true;
		}

		private List<string> GetModifiers()
		{
			List<string> list = new List<string>();
			if (!WorkerManager.WorkerExistsCheckJobAndSkill(SkillType.Botanical, JobType.PlantCropfields, cropfieldInstance.Blueprint.DefaultPlant.MinBotanicalSkill))
			{
				list.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_skilled_botany_worker") + "</style>");
			}
			if (CropsManager.UseSeeds && cropfieldInstance.OwnedByPlayer())
			{
				int freeSpace = cropfieldInstance.GetFreeSpace();
				int allowedCount = MonoSingleton<ResourcePileTracker>.Instance.GetCount(cropfieldInstance.Blueprint.SeedBlueprint).AllowedCount;
				if (cropfieldInstance.HasFreeSpace() && allowedCount < freeSpace)
				{
					list.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("cropfield_error_no_seeds") + "</style>");
				}
			}
			return list;
		}

		private void CopyBuilding()
		{
			if (cropfieldInstance != null && !cropfieldInstance.HasDisposed)
			{
				Deselect();
				MonoSingleton<UIController>.Instance.CopyBuilding(cropfieldInstance.Blueprint.GetID(), cropfieldInstance.Blueprint.BuildingCategoryUI, cropfieldInstance.Blueprint.BuildingSubCategoryUI);
			}
		}

		private void ExpandCropfield()
		{
			if (cropfieldInstance != null && !cropfieldInstance.HasDisposed && MonoSingleton<SelectionManager>.Instance.OrderType != OrderType.ExpandZone)
			{
				MonoSingleton<CropsManager>.Instance.SetCropfieldToModify(cropfieldInstance);
				MonoSingleton<SelectionManager>.Instance.ExpandZone(cropfieldInstance.Blueprint.GetID());
				MonoSingleton<UIController>.Instance.ModifyZoneButtonClicked();
			}
		}

		private void ShrinkCropfield()
		{
			if (cropfieldInstance != null && !cropfieldInstance.HasDisposed && MonoSingleton<SelectionManager>.Instance.OrderType != OrderType.ShrinkZone)
			{
				MonoSingleton<CropsManager>.Instance.SetCropfieldToModify(cropfieldInstance);
				MonoSingleton<SelectionManager>.Instance.ShrinkZone(cropfieldInstance.Blueprint.GetID());
				MonoSingleton<UIController>.Instance.ModifyZoneButtonClicked();
			}
		}

		protected override void Awake()
		{
			base.Awake();
			meshFilter = base.gameObject.GetComponent<MeshFilter>();
			meshCollider = base.gameObject.GetComponent<MeshCollider>();
		}

		private List<InfoPanelStat> GetInfoStats()
		{
			return new List<InfoPanelStat>
			{
				new InfoPanelStat("menu_cropfield_size", "/", new IntRange(cropfieldInstance.CropsCount, cropfieldInstance.Positions.Count))
			};
		}

		private List<string> GetInfos()
		{
			List<string> list = new List<string>();
			list.AddIfNotNull(string.Format("{0}: <color=#ffeca8>{1}, {2}, {3}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("start_position"), cropfieldInstance.Start.x, cropfieldInstance.Start.y, cropfieldInstance.Start.z), cropfieldInstance.Start);
			list.AddIfNotNull(string.Format("{0}: <color=#ffeca8>{1}, {2}, {3}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("end_position"), cropfieldInstance.End.x, cropfieldInstance.End.y, cropfieldInstance.End.z), cropfieldInstance.End);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <color=#ffeca8>{1}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("total_spaces"), cropfieldInstance.Positions.Count), cropfieldInstance.Positions, -1f);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <color=#ffeca8>{1}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("used_spaces"), cropfieldInstance.CropsCount), cropfieldInstance.CropsCount, -1f);
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

		public void Dispose()
		{
			if (!HasDisposed && !MonoSingleton<SceneController>.IsApplicationIsQuitting())
			{
				HasDisposed = true;
				Destroy();
			}
		}

		public string GetAdditionalMenuId()
		{
			return "cropfield";
		}

		public IGoapTargetable GetAsTarget()
		{
			return cropfieldInstance;
		}

		public Transform GetGuiOverlayHookTransform()
		{
			return base.transform;
		}

		public bool ShouldMenuFollowHookTransform()
		{
			return true;
		}
	}
}
