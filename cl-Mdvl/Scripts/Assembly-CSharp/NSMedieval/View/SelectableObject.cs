using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers.Selection.EventData;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.View
{
	[RequireComponent(typeof(ClickDetection))]
	[SelectionBase]
	public abstract class SelectableObject : NSEipix.Base.View
	{
		private static int ignoreLayerIds;

		[NonSerialized]
		private readonly Dictionary<Renderer, int> meshLayers = new Dictionary<Renderer, int>();

		[NonSerialized]
		private readonly HashSet<Renderer> disabledRenderers = new HashSet<Renderer>();

		private ClickDetection clickDetection;

		private static readonly Dictionary<int, int> HierarchyCount = new Dictionary<int, int>(100000);

		private bool outlineShown;

		private bool isSelected;

		private bool isHoverActive;

		private Camera mainCamera;

		private int instanceId;

		private static readonly string[] IgnoreLayers = new string[5] { "IgnoreOutline", "TransparentFX", "Grid", "UIWorld", "UI" };

		private HashSet<Renderer> wasEnabled = new HashSet<Renderer>();

		public abstract bool Visible { get; }

		public bool IsDestroyed { get; private set; }

		public virtual bool IsBuilding => false;

		public bool Selected => isSelected;

		public Dictionary<Renderer, int> MeshLayers
		{
			get
			{
				if (IsDestroyed)
				{
					return null;
				}
				int value;
				bool flag = !HierarchyCount.TryGetValue(instanceId, out value);
				int hierarchyCount = base.transform.hierarchyCount;
				if (!flag)
				{
					if (value != hierarchyCount)
					{
						flag = true;
						HierarchyCount[instanceId] = hierarchyCount;
					}
				}
				else
				{
					HierarchyCount.Add(instanceId, hierarchyCount);
				}
				if (flag)
				{
					RefreshMeshLayers();
				}
				return meshLayers;
			}
		}

		private ClickDetection ClickDetection
		{
			get
			{
				if (!clickDetection)
				{
					if (this == null || base.gameObject == null)
					{
						return null;
					}
					clickDetection = GetComponent<ClickDetection>();
				}
				return clickDetection;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			ignoreLayerIds = 0;
			HierarchyCount.Clear();
		}

		protected void RefreshMeshLayers()
		{
			RevertMeshLayers(nullCheck: true);
			meshLayers.Clear();
			FillMeshLayers();
		}

		public abstract WorldObject GetAsWorldObject();

		public virtual bool IsInMeshFusion()
		{
			return false;
		}

		private void FillMeshLayers()
		{
			Renderer[] componentsInChildren = base.transform.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				meshLayers.Add(renderer, renderer.gameObject.layer);
			}
		}

		public bool IsOnScreen()
		{
			if (base.gameObject == null || base.transform == null || IsDestroyed)
			{
				return false;
			}
			if (mainCamera == null)
			{
				mainCamera = Camera.main;
				if (mainCamera == null)
				{
					return false;
				}
			}
			Vector3 vector = mainCamera.WorldToViewportPoint(base.transform.position);
			if (vector.z > 0f && vector.x > 0f && vector.x < 1f && vector.y > 0f)
			{
				return vector.y < 1f;
			}
			return false;
		}

		public void ShowSelectionOutline(string layer = "Outline")
		{
			if (outlineShown)
			{
				return;
			}
			ResetSelectionOutline();
			outlineShown = true;
			if (MeshLayers == null)
			{
				return;
			}
			int layer2 = LayerMask.NameToLayer(layer);
			foreach (Renderer key in meshLayers.Keys)
			{
				if (key == null)
				{
					continue;
				}
				GameObject gameObject = key.gameObject;
				if (CheckMeshRenderLayer(gameObject))
				{
					gameObject.layer = layer2;
					if (IsInMeshFusion() && !key.enabled)
					{
						key.enabled = true;
						disabledRenderers.Add(key);
					}
				}
			}
		}

		public void RevertDisabledRenderers()
		{
			if (disabledRenderers.Count == 0 || !IsInMeshFusion())
			{
				return;
			}
			foreach (Renderer disabledRenderer in disabledRenderers)
			{
				if (!(disabledRenderer == null))
				{
					disabledRenderer.enabled = false;
				}
			}
		}

		public void EnableDisabledRenderers()
		{
			if (disabledRenderers.Count == 0 || !IsInMeshFusion())
			{
				return;
			}
			foreach (Renderer disabledRenderer in disabledRenderers)
			{
				if (!(disabledRenderer == null))
				{
					disabledRenderer.enabled = true;
				}
			}
		}

		public virtual CreatureBase GetAsCreature()
		{
			return null;
		}

		public void ResetSelectionOutline()
		{
			if (outlineShown)
			{
				RevertMeshLayers(nullCheck: true);
				RevertDisabledRenderers();
				outlineShown = false;
			}
		}

		private void RevertMeshLayers(bool nullCheck = false)
		{
			if (IsDestroyed)
			{
				return;
			}
			foreach (KeyValuePair<Renderer, int> meshLayer in MeshLayers)
			{
				Renderer key = meshLayer.Key;
				if (!nullCheck || !(key == null))
				{
					key.gameObject.layer = meshLayer.Value;
				}
			}
		}

		public abstract string GetSimpleName();

		public abstract string GetMultiselectName();

		public abstract InfoPanelData GetInfoPanelData();

		public abstract InfoPanelData UpdateCallback();

		internal virtual void Deselect(bool isSilent = false)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Universal\\SelectableObject.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Deselect ");
				messageBuilder.AppendFormatted(GetType().Name);
				messageBuilder.AppendLiteral(" isSilent: ");
				messageBuilder.AppendFormatted(isSilent);
			}
			Log.Trace(messageBuilder);
			if (!isSilent && isSelected)
			{
				MonoSingleton<SelectableObjectController>.Instance.OnDeselected(this);
			}
			isSelected = false;
			RefreshOutlineSelect();
		}

		protected abstract bool IsSelectionNull();

		internal virtual void Select()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(7, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Universal\\SelectableObject.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Select ");
				messageBuilder.AppendFormatted(GetType().Name);
			}
			Log.Trace(messageBuilder);
			if (TutorialManager.IsTutorialActive && !MonoSingleton<TutorialManager>.Instance.CanSelect)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("tutorial_selection_forbidden".ToLocalized());
			}
			else if (Visible && !MonoSingleton<UIController>.Instance.HideUI)
			{
				if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
				{
					ClickedJumpToLowerLayer();
				}
				else if (!IsSelectionNull())
				{
					MonoSingleton<SelectableObjectController>.Instance.OnSelected(this);
					isSelected = true;
					RefreshOutlineSelect();
				}
			}
		}

		protected void ClickedJumpToLowerLayer()
		{
			Vector3 position = base.transform.position;
			MonoSingleton<World>.Instance.SwitchToLowerLayer(GridUtils.GetGridPosition(position));
		}

		protected void ClickedJumpToUpperLayer()
		{
			Vector3 position = base.transform.position;
			MonoSingleton<World>.Instance.SwitchToUpperLayer(GridUtils.GetGridPosition(position));
		}

		protected void DestroySelectableObject()
		{
			if (!(ClickDetection == null))
			{
				ClickDetection.OnEnter -= MouseEnterInternal;
				ClickDetection.OnExit -= MouseExitInternal;
				ClickDetection.OnEnter -= OnPointerEnter;
				ClickDetection.OnExit -= OnPointerExit;
			}
		}

		protected void ConstructSelectionErrorMessage(OrderType orderType)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("error_selection_order_" + orderType.ToString().ToLower());
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
		}

		protected virtual void Awake()
		{
			instanceId = GetInstanceID();
		}

		protected virtual void Start()
		{
			MonoSingleton<SelectableObjectManager>.Instance.RegisterObject(this);
			if (!(ClickDetection == null))
			{
				ClickDetection.OnEnter += MouseEnterInternal;
				ClickDetection.OnExit += MouseExitInternal;
				ClickDetection.OnEnter += OnPointerEnter;
				ClickDetection.OnExit += OnPointerExit;
			}
		}

		protected void OnDisable()
		{
			if (MonoSingleton<SelectableObjectManager>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectManager>.Instance.RemoveObject(this);
			}
		}

		protected virtual void MouseOnEnter()
		{
		}

		protected virtual void MouseOnExit()
		{
		}

		private void MouseEnterInternal(Vector3 pos)
		{
			if (Visible)
			{
				MonoSingleton<SelectableObjectManager>.Instance.SetHoverObject(this);
				MouseOnEnter();
			}
		}

		private void MouseExitInternal(Vector3 pos)
		{
			if (MonoSingleton<SelectableObjectManager>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectManager>.Instance.SetHoverObject(null);
			}
			MouseOnExit();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual bool CheckMeshRenderLayer(GameObject rendererGameObject)
		{
			if (ignoreLayerIds == 0)
			{
				string[] ignoreLayers = IgnoreLayers;
				foreach (string layerName in ignoreLayers)
				{
					ignoreLayerIds |= 1 << LayerMask.NameToLayer(layerName);
				}
			}
			return ((1 << rendererGameObject.layer) & ignoreLayerIds) == 0;
		}

		protected virtual void OnPointerEnter(Vector3 pos)
		{
			if (!MonoSingleton<SelectionManager>.Instance.Selecting && (!OutlinePostProcess.IsInstantiated() || OutlinePostProcess.Instance.IsHoverFillShowing) && Visible)
			{
				isHoverActive = true;
				RefreshOutlineSelect();
			}
		}

		protected virtual void OnPointerExit(Vector3 eventData)
		{
			isHoverActive = false;
			RefreshOutlineSelect();
		}

		public void ShowHighlight()
		{
			if (Visible && !isHoverActive)
			{
				isHoverActive = true;
				RefreshOutlineSelect();
			}
		}

		public void HideHighlight()
		{
			if (isHoverActive)
			{
				isHoverActive = false;
				RefreshOutlineSelect();
			}
		}

		private void RefreshOutlineSelect()
		{
			if (OutlinePostProcess.IsInstantiated())
			{
				OutlinePostProcess.Instance.SetOutlineOnObject(this, isSelected, isHoverActive);
			}
		}

		protected virtual void OnDestroy()
		{
			using (ProfilerSampleJanitor.Begin("SelectableObject.OnDestroy"))
			{
				if (MonoSingleton<MaterialPropertyBlockManager>.IsInstantiated())
				{
					MonoSingleton<MaterialPropertyBlockManager>.Instance.RemoveFromBlocks(base.transform);
				}
				if (clickDetection != null)
				{
					clickDetection.OnLeavingMainScene();
				}
				meshLayers.Clear();
				disabledRenderers.Clear();
				clickDetection = null;
				mainCamera = null;
				IsDestroyed = true;
			}
		}

		protected void UpdateViewImmediate()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnDataUpdated();
		}

		protected bool ObjectIsSelectedByOrder(OrderEventData eventData)
		{
			if ((int)(base.transform.position.y / (float)World.MapBlockHeight) > MonoSingleton<World>.Instance.ElevationLevel)
			{
				return false;
			}
			if (!SelectionManager.IsWithinSelectionBounds(base.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y, isTolerantSingleSelection: true))
			{
				return false;
			}
			if (eventData.AffectOnlyOneLayer && (int)base.transform.position.y != (int)eventData.Y)
			{
				return false;
			}
			return true;
		}

		public void OnSelectAllOfSameType()
		{
			if (OutlinePostProcess.IsInstantiated() && Visible)
			{
				isSelected = true;
				MonoSingleton<SelectableObjectController>.Instance.OnMultiSelected(this);
				OutlinePostProcess.Instance.SetOutlineOnObject(this, isSelected, isHoverActive);
			}
		}

		public virtual void OnLeavingMainScene()
		{
			if (clickDetection != null)
			{
				clickDetection.OnLeavingMainScene();
			}
			meshLayers.Clear();
			clickDetection = null;
			mainCamera = null;
		}

		public virtual void RefreshVisibility(float layerLevel = float.NaN)
		{
		}

		public virtual void SetMeshRenderersVisible(bool visible)
		{
		}
	}
}
