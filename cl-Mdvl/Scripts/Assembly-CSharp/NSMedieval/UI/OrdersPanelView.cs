using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Sound;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.WorldMap;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.UI
{
	public class OrdersPanelView : PanelBase
	{
		[SerializeField]
		private LayoutGroupView topRow;

		[SerializeField]
		private LayoutGroupView bottomRow;

		[SerializeField]
		private OrderType[] topRowOrders;

		[SerializeField]
		private OrderType[] bottomRowOrders;

		[FormerlySerializedAs("submenuManager")]
		[SerializeField]
		private OrderSubmenuPanelManager orderSubmenuPanel;

		private Dictionary<OrderType, ButtonLayoutItemView> orderTypeButton = new Dictionary<OrderType, ButtonLayoutItemView>();

		private bool ordersActive = true;

		protected override bool SubscribeToEscapeKey => false;

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.LowerRight;
		}

		protected override void UpdatePanel()
		{
		}

		public void SetCategoriesInteractable(HashSet<OrderType> orders, bool interactable)
		{
			foreach (KeyValuePair<OrderType, ButtonLayoutItemView> item in orderTypeButton)
			{
				if (orders.Contains(item.Key))
				{
					item.Value.Button.interactable = interactable;
				}
				else
				{
					item.Value.Button.interactable = !interactable;
				}
			}
		}

		public RectTransform GetCategoryTransform(OrderType order)
		{
			if (orderTypeButton.TryGetValue(order, out var value))
			{
				return value.gameObject.GetComponent<RectTransform>();
			}
			return null;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (MonoSingleton<UIPanelManager>.IsInstantiated())
			{
				MonoSingleton<UIPanelManager>.Instance.OnPanelHide(this);
			}
		}

		protected override void Start()
		{
			MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
			MonoSingleton<SelectionManager>.Instance.RightMouseUpResetOrderEvent += OnSelectionResetOrder;
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent += OnWorldMapVisibilitySet;
			Show();
			CreateCategoryButtons();
			orderSubmenuPanel.SetParent(this);
			orderSubmenuPanel.SetupDeconstructBuildingTypes();
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
			}
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.RightMouseUpResetOrderEvent -= OnSelectionResetOrder;
			}
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent -= OnWorldMapVisibilitySet;
			}
			base.OnDestroy();
		}

		public override void Show()
		{
			Log.Debug("Show", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\OrdersPanelView.cs");
			if (!TutorialManager.IsTutorialActive || MonoSingleton<TutorialManager>.Instance.AllowOrdersPanel)
			{
				base.Show();
			}
		}

		public override void Hide()
		{
			Log.Trace("Hide", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\OrdersPanelView.cs");
			if (MainPanel.activeInHierarchy)
			{
				Log.Debug("Hide", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\OrdersPanelView.cs");
				TurnOffAllButtonHighlights();
				base.Hide();
			}
		}

		protected override void OnOtherPanelOpened(string panelName, PanelGroupType panelGroup)
		{
			if (!panelName.Equals(orderSubmenuPanel.name) && !panelName.Equals(base.gameObject.name))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\OrdersPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("This group: ");
					messageBuilder.AppendFormatted(GetGroupType());
					messageBuilder.AppendLiteral(", other ");
					messageBuilder.AppendFormatted(panelName);
					messageBuilder.AppendLiteral(" group: ");
					messageBuilder.AppendFormatted(panelGroup);
					messageBuilder.AppendLiteral(" ");
				}
				Log.Trace(messageBuilder);
				if (GetGroupType() != panelGroup)
				{
					OnSelectionResetOrder();
				}
				else
				{
					base.OnOtherPanelOpened(panelName, panelGroup);
				}
			}
		}

		private void OnSelectionPanelToggle(bool selectionActive, int panelobjectid)
		{
			ordersActive = !selectionActive;
			if (ordersActive)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}

		private void CreateCategoryButtons()
		{
			OrderType[] array = topRowOrders;
			foreach (OrderType orderType in array)
			{
				CreateCategoryButton(orderType, topRow);
			}
			array = bottomRowOrders;
			foreach (OrderType orderType2 in array)
			{
				CreateCategoryButton(orderType2, bottomRow);
			}
		}

		private void CreateCategoryButton(OrderType orderType, LayoutGroupView group)
		{
			if (MonoSingleton<SelectionManager>.Instance.OrderType == orderType)
			{
				MonoSingleton<SelectionManager>.Instance.DeselectTool();
				return;
			}
			string text = orderType.ToString();
			KeyInputEvent keyInputEvent = (KeyInputEvent)Enum.Parse(typeof(KeyInputEvent), text);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(keyInputEvent, delegate
			{
				OnOrderKeyPressed(orderType);
			});
			ButtonLayoutItemView buttonLayoutItemView = UnityEngine.Object.Instantiate(group.Prefab, Vector3.zero, Quaternion.identity, group.gameObject.transform) as ButtonLayoutItemView;
			if (!(buttonLayoutItemView == null))
			{
				buttonLayoutItemView.SetButtonData(text, text, MonoSingleton<LocalizationController>.Instance.GetText("hud_lb_order_" + text.ToLower()));
				ButtonKeyCommandTooltipViewNew buttonKeyCommandTooltipViewNew = (ButtonKeyCommandTooltipViewNew)buttonLayoutItemView.TooltipNew;
				if (buttonKeyCommandTooltipViewNew != null)
				{
					buttonKeyCommandTooltipViewNew.Init(text, keyInputEvent);
				}
				buttonLayoutItemView.Button.onClick.AddListener(delegate
				{
					OnOrderButtonClick(orderType);
				});
				orderTypeButton.Add(orderType, buttonLayoutItemView);
			}
		}

		private void OnOrderKeyPressed(OrderType orderType)
		{
			OnOrderButtonClick(orderType);
		}

		private void SetHighlight(OrderType orderType, bool active)
		{
			foreach (OrderType key in orderTypeButton.Keys)
			{
				if (key == orderType)
				{
					orderTypeButton[key].Select(active);
					break;
				}
			}
		}

		public void TurnOffAllButtonHighlights()
		{
			foreach (OrderType key in orderTypeButton.Keys)
			{
				orderTypeButton[key].Select(select: false);
			}
		}

		private void OnOrderButtonClick(OrderType orderType)
		{
			MonoSingleton<SelectionManager>.Instance.ResetSelectionTool();
			if (!ordersActive)
			{
				return;
			}
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_SetOrder", new Dictionary<string, string> { 
			{
				"Orders",
				orderType.ToString()
			} });
			TurnOffAllButtonHighlights();
			if (MonoSingleton<SelectionManager>.Instance.OrderType == orderType)
			{
				MonoSingleton<SelectionManager>.Instance.DeselectTool();
				return;
			}
			if (!TutorialManager.IsTutorialActive)
			{
				if (orderSubmenuPanel != null)
				{
					orderSubmenuPanel.Hide();
					orderSubmenuPanel.ShowPanel(orderType);
				}
				if (orderType.Equals(OrderType.Allow) || orderType.Equals(OrderType.Forbid))
				{
					orderType = orderSubmenuPanel.GetAllowOrForbid();
				}
			}
			Show();
			SetHighlight(orderType, active: true);
			MonoSingleton<SelectionManager>.Instance.OnClickAssignOrder((int)orderType);
			MonoSingleton<SelectionManager>.Instance.OnClickAssignInfoCursor("order_" + orderType.ToString().ToLower());
		}

		private void OnSelectionResetOrder()
		{
			if (orderSubmenuPanel.gameObject.activeInHierarchy)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_AbortOrder");
				orderSubmenuPanel.Hide();
			}
			TurnOffAllButtonHighlights();
		}

		private void OnWorldMapVisibilitySet(bool visible)
		{
			ordersActive = true;
		}
	}
}
