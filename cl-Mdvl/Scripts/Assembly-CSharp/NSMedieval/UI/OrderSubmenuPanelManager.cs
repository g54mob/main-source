using System.Collections;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Managers.Selection;
using NSMedieval.Model;
using NSMedieval.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class OrderSubmenuPanelManager : PanelBase
	{
		[SerializeField]
		private LayoutGroupView itemsPrent;

		[SerializeField]
		private TextMeshProUGUI orderTitle;

		private readonly Dictionary<OrderType, OrderSubmenuLayoutItemView> allowForbidToggles = new Dictionary<OrderType, OrderSubmenuLayoutItemView>();

		private readonly Dictionary<OrderDeconstructType, BuildingType> deconstructBuildingTypes = new Dictionary<OrderDeconstructType, BuildingType>();

		private readonly Dictionary<OrderDeconstructType, OrderSubmenuLayoutItemView> deconstructToggles = new Dictionary<OrderDeconstructType, OrderSubmenuLayoutItemView>();

		private readonly Dictionary<OrderLayerSelectionType, OrderSubmenuLayoutItemView> layerSelectionToggles = new Dictionary<OrderLayerSelectionType, OrderSubmenuLayoutItemView>();

		private readonly Dictionary<PlantLifePhaseType, OrderSubmenuLayoutItemView> phaseSelectionToggles = new Dictionary<PlantLifePhaseType, OrderSubmenuLayoutItemView>();

		private readonly Dictionary<OrderAllowType, OrderSubmenuLayoutItemView> allowTypeToggles = new Dictionary<OrderAllowType, OrderSubmenuLayoutItemView>();

		private OrdersPanelView ordersPanelView;

		private readonly List<OrderSubmenuLayoutItemView> submenuItems = new List<OrderSubmenuLayoutItemView>();

		protected override bool SubscribeToEscapeKey => false;

		public void SetParent(OrdersPanelView ordersPanelView)
		{
			this.ordersPanelView = ordersPanelView;
		}

		public OrderType GetAllowOrForbid()
		{
			if (allowForbidToggles[OrderType.Allow].Toggle.isOn)
			{
				return OrderType.Allow;
			}
			return OrderType.Forbid;
		}

		public void ShowPanel(OrderType orderType)
		{
			foreach (OrderSubmenuLayoutItemView submenuItem in submenuItems)
			{
				submenuItem.gameObject.SetActive(value: false);
			}
			orderTitle.text = MonoSingleton<LocalizationController>.Instance.GetText("hud_lb_order_" + orderType.ToString().ToLower());
			switch (orderType)
			{
			case OrderType.Deconstructing:
				SetupDeconstruct();
				break;
			case OrderType.Cancel:
				SetupCancel();
				break;
			case OrderType.Allow:
				SetupAllow();
				break;
			case OrderType.Hunting:
				SetupHunting();
				break;
			case OrderType.Chopping:
				SetupChop();
				break;
			case OrderType.CutAllVegetation:
				SetupCutPlants();
				break;
			case OrderType.Harvesting:
				SetupHarvest();
				break;
			case OrderType.UrgentHaul:
				SetupAllLayersToggle();
				break;
			default:
				return;
			}
			Show();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				LayoutRebuilder.MarkLayoutForRebuild(itemsPrent.GetComponent<RectTransform>());
			});
		}

		public override void Hide()
		{
			base.Hide();
			foreach (OrderSubmenuLayoutItemView submenuItem in submenuItems)
			{
				submenuItem.gameObject.SetActive(value: false);
			}
		}

		public void SetupDeconstructBuildingTypes()
		{
			deconstructBuildingTypes.Add(OrderDeconstructType.AllBuildings, BuildingType.AllBuildings);
			deconstructBuildingTypes.Add(OrderDeconstructType.Floors, BuildingType.Floor);
			deconstructBuildingTypes.Add(OrderDeconstructType.Walls, BuildingType.Wall | BuildingType.Beam | BuildingType.Stairs | BuildingType.Window | BuildingType.Door | BuildingType.Merlon);
			deconstructBuildingTypes.Add(OrderDeconstructType.Roofs, BuildingType.Roof);
			deconstructBuildingTypes.Add(OrderDeconstructType.WorkbenchFurniture, BuildingType.ProductionBuilding | BuildingType.Chair | BuildingType.Table | BuildingType.Bed | BuildingType.Decoration | BuildingType.Shrine | BuildingType.Grave);
		}

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.LowerRight;
		}

		protected override void UpdatePanel()
		{
		}

		protected override void OnOtherPanelOpened(string panelName, PanelGroupType panelGroup)
		{
			if (GetGroupType() != panelGroup || !(panelName == ordersPanelView.gameObject.name))
			{
				ordersPanelView.TurnOffAllButtonHighlights();
				base.OnOtherPanelOpened(panelName, panelGroup);
			}
		}

		protected override IEnumerator InitializeContent()
		{
			Show();
			yield return null;
		}

		private void SetupAllLayersToggle()
		{
			OrderLayerSelectionType[] orderLayerSelectionTypes = EnumValues.OrderLayerSelectionTypes;
			for (int i = 0; i < orderLayerSelectionTypes.Length; i++)
			{
				OrderLayerSelectionType layerSelectionType = orderLayerSelectionTypes[i];
				if (layerSelectionToggles.TryGetValue(layerSelectionType, out var value))
				{
					value.gameObject.SetActive(value: true);
					continue;
				}
				OrderSubmenuLayoutItemView item = Object.Instantiate(itemsPrent.Prefab, itemsPrent.transform).GetComponent<OrderSubmenuLayoutItemView>();
				submenuItems.Add(item);
				item.SetData(layerSelectionType.ToString() + "_apply_order", layerSelectionType == OrderLayerSelectionType.AllLayers);
				layerSelectionToggles.Add(layerSelectionType, item);
				item.Toggle.onValueChanged.AddListener(delegate
				{
					item.SetToggleWithoutNotify(value: true);
					MonoSingleton<SelectionManager>.Instance.SetOrderDeconstructLayers(layerSelectionType);
					foreach (OrderLayerSelectionType key in layerSelectionToggles.Keys)
					{
						if (key != layerSelectionType)
						{
							layerSelectionToggles[key].SetToggleWithoutNotify(value: false);
						}
					}
				});
			}
		}

		private void SetupPlantMaturityToggle()
		{
			PlantLifePhaseType[] plantLifePhaseTypes = EnumValues.PlantLifePhaseTypes;
			for (int i = 0; i < plantLifePhaseTypes.Length; i++)
			{
				PlantLifePhaseType phaseType = plantLifePhaseTypes[i];
				if (phaseSelectionToggles.TryGetValue(phaseType, out var value))
				{
					value.gameObject.SetActive(value: true);
					continue;
				}
				OrderSubmenuLayoutItemView item = Object.Instantiate(itemsPrent.Prefab, itemsPrent.transform).GetComponent<OrderSubmenuLayoutItemView>();
				submenuItems.Add(item);
				if (phaseType == PlantLifePhaseType.None)
				{
					item.SetData("menu_allow_all", selected: true);
				}
				else
				{
					item.SetData("resource_phase_" + phaseType.ToString().ToLower(), selected: false);
				}
				phaseSelectionToggles.Add(phaseType, item);
				item.Toggle.onValueChanged.AddListener(delegate
				{
					item.SetToggleWithoutNotify(value: true);
					MonoSingleton<SelectionManager>.Instance.SetChopPhaseType(phaseType);
					foreach (PlantLifePhaseType key in phaseSelectionToggles.Keys)
					{
						if (key != phaseType)
						{
							phaseSelectionToggles[key].SetToggleWithoutNotify(value: false);
						}
					}
				});
			}
		}

		private void SetupAllowTypeToggle()
		{
			OrderAllowType[] orderAllowTypes = EnumValues.OrderAllowTypes;
			for (int i = 0; i < orderAllowTypes.Length; i++)
			{
				OrderAllowType orderAllowType = orderAllowTypes[i];
				if (allowTypeToggles.TryGetValue(orderAllowType, out var value))
				{
					value.gameObject.SetActive(value: true);
					continue;
				}
				OrderSubmenuLayoutItemView item = Object.Instantiate(itemsPrent.Prefab, itemsPrent.transform).GetComponent<OrderSubmenuLayoutItemView>();
				submenuItems.Add(item);
				item.SetData(orderAllowType.ToString() + "_apply_order", orderAllowType == OrderAllowType.All);
				allowTypeToggles.Add(orderAllowType, item);
				item.Toggle.onValueChanged.AddListener(delegate
				{
					item.SetToggleWithoutNotify(value: true);
					MonoSingleton<SelectionManager>.Instance.SetOrderAllowType(orderAllowType);
					foreach (OrderAllowType key in allowTypeToggles.Keys)
					{
						if (key != orderAllowType)
						{
							allowTypeToggles[key].SetToggleWithoutNotify(value: false);
						}
					}
				});
			}
		}

		private void SetupCancel()
		{
			SetupAllLayersToggle();
		}

		private void SetupDeconstruct()
		{
			SetupAllLayersToggle();
			OrderDeconstructType[] orderDeconstructTypes = EnumValues.OrderDeconstructTypes;
			for (int i = 0; i < orderDeconstructTypes.Length; i++)
			{
				OrderDeconstructType orderDeconstructType = orderDeconstructTypes[i];
				if (deconstructToggles.TryGetValue(orderDeconstructType, out var value))
				{
					value.gameObject.SetActive(value: true);
					continue;
				}
				OrderSubmenuLayoutItemView item = Object.Instantiate(itemsPrent.Prefab, itemsPrent.transform).GetComponent<OrderSubmenuLayoutItemView>();
				submenuItems.Add(item);
				deconstructToggles.Add(orderDeconstructType, item);
				item.SetData(orderDeconstructType.ToString().ToLower() + "_deconstruct", orderDeconstructType == OrderDeconstructType.AllBuildings);
				item.Toggle.onValueChanged.AddListener(delegate
				{
					item.SetToggleWithoutNotify(value: true);
					MonoSingleton<SelectionManager>.Instance.SetOrderDeconstructType(deconstructBuildingTypes[orderDeconstructType]);
					foreach (OrderDeconstructType key in deconstructToggles.Keys)
					{
						if (key != orderDeconstructType)
						{
							deconstructToggles[key].SetToggleWithoutNotify(value: false);
						}
					}
				});
			}
		}

		private void SetupAllow()
		{
			SetupAllLayersToggle();
			SetupAllowTypeToggle();
			if (allowForbidToggles.TryGetValue(OrderType.Allow, out var value))
			{
				value.gameObject.SetActive(value: true);
			}
			else
			{
				OrderSubmenuLayoutItemView component = Object.Instantiate(itemsPrent.Prefab, itemsPrent.transform).GetComponent<OrderSubmenuLayoutItemView>();
				submenuItems.Add(component);
				allowForbidToggles.Add(OrderType.Allow, component);
				component.SetData(MonoSingleton<LocalizationController>.Instance.GetText("action_allow"), selected: true);
				component.Toggle.onValueChanged.AddListener(delegate
				{
					allowForbidToggles[OrderType.Allow].SetToggleWithoutNotify(value: true);
					allowForbidToggles[OrderType.Forbid].SetToggleWithoutNotify(value: false);
					MonoSingleton<SelectionManager>.Instance.SetupAllowAndForbid(OrderType.Allow);
					MonoSingleton<SelectionManager>.Instance.OnClickAssignInfoCursor("order_" + "Allow".ToLower());
				});
			}
			if (allowForbidToggles.TryGetValue(OrderType.Forbid, out var value2))
			{
				value2.gameObject.SetActive(value: true);
				return;
			}
			OrderSubmenuLayoutItemView component2 = Object.Instantiate(itemsPrent.Prefab, itemsPrent.transform).GetComponent<OrderSubmenuLayoutItemView>();
			submenuItems.Add(component2);
			allowForbidToggles.Add(OrderType.Forbid, component2);
			component2.SetData(MonoSingleton<LocalizationController>.Instance.GetText("action_forbid"), selected: false);
			component2.Toggle.onValueChanged.AddListener(delegate
			{
				allowForbidToggles[OrderType.Forbid].SetToggleWithoutNotify(value: true);
				allowForbidToggles[OrderType.Allow].SetToggleWithoutNotify(value: false);
				MonoSingleton<SelectionManager>.Instance.SetupAllowAndForbid(OrderType.Forbid);
				MonoSingleton<SelectionManager>.Instance.OnClickAssignInfoCursor("order_" + "Forbid".ToLower());
			});
		}

		private void SetupHunting()
		{
			SetupAllLayersToggle();
		}

		private void SetupChop()
		{
			SetupAllLayersToggle();
			SetupPlantMaturityToggle();
		}

		private void SetupCutPlants()
		{
			SetupAllLayersToggle();
		}

		private void SetupHarvest()
		{
			SetupAllLayersToggle();
		}
	}
}
