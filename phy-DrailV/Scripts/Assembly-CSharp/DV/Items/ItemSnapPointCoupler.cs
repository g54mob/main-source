using System.Collections.Generic;
using DV.CabControls;
using DV.CabControls.VRTK;
using DV.Interaction;
using DV.Items.Snapping;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Items
{
	public class ItemSnapPointCoupler : ItemSnapPointBase
	{
		private const InteractionInfoType NOT_PARKED_HOVER = InteractionInfoType.CouplerNotParked;

		private ChainCouplerCouplerAdapter adapter;

		private bool isParked;

		private bool initialized;

		private bool isVR;

		private (SnappableItem snappable, ControllerTooltip showingTooltip) showingTooltipRight;

		private (SnappableItem snappable, ControllerTooltip showingTooltip) showingTooltipLeft;

		private HashSet<SnappableItem> currentHovers = new HashSet<SnappableItem>();

		public TrainCar Car { get; private set; }

		public bool IsFront { get; private set; }

		protected override bool DisallowInteractionOnSnap { get; }

		public void Initialize()
		{
			if (!initialized)
			{
				isVR = VRManager.IsVREnabled();
				if (!isVR)
				{
					base.gameObject.AddComponent<ItemUseTarget>().targetColliders = new Collider[1] { GetComponent<SphereCollider>() };
				}
				Car = TrainCar.Resolve(base.gameObject);
				adapter = base.gameObject.GetComponentInParentIncludingInactive<ChainCouplerCouplerAdapter>();
				IsFront = adapter.coupler.isFrontCoupler;
				isParked = adapter.chainScript.IsParked;
				base.transform.parent = Car.interior;
				SetupListeners(on: true);
				initialized = true;
			}
		}

		private void SetupListeners(bool on)
		{
			ChainCouplerInteraction chainCouplerInteraction = ((adapter != null) ? adapter.chainScript : null);
			if (!(chainCouplerInteraction == null))
			{
				if (on)
				{
					chainCouplerInteraction.StateChanged += OnChainStateChanged;
					chainCouplerInteraction.couplerAdapter.coupler.Coupled += OnCoupled;
				}
				else
				{
					chainCouplerInteraction.StateChanged -= OnChainStateChanged;
					chainCouplerInteraction.couplerAdapter.coupler.Coupled -= OnCoupled;
				}
			}
		}

		private void OnCoupled(object sender, CoupleEventArgs e)
		{
			if (base.SnappedItem != null)
			{
				UnsnapItem(forced: true);
			}
		}

		private void OnChainStateChanged(ChainCouplerInteraction.State state)
		{
			switch (state)
			{
			case ChainCouplerInteraction.State.Disabled:
			case ChainCouplerInteraction.State.Enabled:
			case ChainCouplerInteraction.State.Determine_Next_State:
				return;
			case ChainCouplerInteraction.State.Parked:
				isParked = true;
				if (isVR)
				{
					if (showingTooltipRight.showingTooltip != null)
					{
						UpdateHoverTooltip(isRight: true, showingTooltipRight.snappable, show: false);
					}
					if (showingTooltipLeft.showingTooltip != null)
					{
						UpdateHoverTooltip(isRight: false, showingTooltipLeft.snappable, show: false);
					}
				}
				return;
			}
			isParked = false;
			if (base.SnappedItem != null)
			{
				UnsnapItem(forced: true);
			}
			if (!isVR)
			{
				return;
			}
			foreach (SnappableItem currentHover in currentHovers)
			{
				HoverVR(currentHover, hovered: true);
			}
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		public override bool CanSnapCheck(SnappableItem snappableItem, bool forced)
		{
			var (flag, flag2) = CanSnapCheckDetailed(snappableItem, forced);
			if (!flag)
			{
				return false;
			}
			if (flag2)
			{
				return true;
			}
			if (!isVR)
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.CouplerNotParked);
			}
			return false;
		}

		private (bool canSnapBase, bool canSnapDetailed) CanSnapCheckDetailed(SnappableItem snappableItem, bool forced)
		{
			bool num = base.CanSnapCheck(snappableItem, forced);
			bool item = num && isParked;
			return (canSnapBase: num, canSnapDetailed: item);
		}

		public override void HoverVR(SnappableItem hoveredBy, bool hovered)
		{
			base.HoverVR(hoveredBy, hovered);
			if (hoveredBy == null)
			{
				return;
			}
			var (flag, flag2) = CanSnapCheckDetailed(hoveredBy, forced: false);
			if (flag)
			{
				if (hovered)
				{
					currentHovers.Add(hoveredBy);
				}
				else
				{
					currentHovers.Remove(hoveredBy);
				}
			}
			if (flag2)
			{
				return;
			}
			ItemVRTK itemVRTK = (ItemVRTK)hoveredBy.Item;
			if (hovered)
			{
				if (flag)
				{
					GameObject grabbingObject = itemVRTK.Interactable.GetGrabbingObject();
					if (!(grabbingObject == null))
					{
						bool isRight = VRTK_DeviceFinder.IsControllerRightHand(grabbingObject);
						UpdateHoverTooltip(isRight, hoveredBy, show: true);
						SetupHoverListeners(itemVRTK, subscribe: true);
					}
				}
			}
			else
			{
				UpdateHoverTooltip(isRight: false, hoveredBy, show: false);
				SetupHoverListeners(itemVRTK, subscribe: false);
			}
		}

		private void UpdateHoverTooltip(bool isRight, SnappableItem hoveredBy, bool show)
		{
			if (show)
			{
				if (isRight)
				{
					ControllerTooltip item = showingTooltipRight.showingTooltip;
					if (item != null)
					{
						item.HideTooltip();
					}
					ControllerTooltip controllerTooltipRight = VRTK_ControllerUtils_DV.ControllerTooltipRight;
					controllerTooltipRight.ShowTooltip(SingletonBehaviour<InteractionText>.Instance.GetText(InteractionInfoType.CouplerNotParked), showBackground: true);
					showingTooltipRight = (snappable: hoveredBy, showingTooltip: controllerTooltipRight);
				}
				else
				{
					ControllerTooltip item2 = showingTooltipLeft.showingTooltip;
					if (item2 != null)
					{
						item2.HideTooltip();
					}
					ControllerTooltip controllerTooltipLeft = VRTK_ControllerUtils_DV.ControllerTooltipLeft;
					controllerTooltipLeft.ShowTooltip(SingletonBehaviour<InteractionText>.Instance.GetText(InteractionInfoType.CouplerNotParked), showBackground: true);
					showingTooltipLeft = (snappable: hoveredBy, showingTooltip: controllerTooltipLeft);
				}
			}
			else if (showingTooltipRight.snappable == hoveredBy)
			{
				ControllerTooltip item3 = showingTooltipRight.showingTooltip;
				if (item3 != null)
				{
					item3.HideTooltip();
				}
				showingTooltipRight = default((SnappableItem, ControllerTooltip));
			}
			else if (showingTooltipLeft.snappable == hoveredBy)
			{
				ControllerTooltip item4 = showingTooltipLeft.showingTooltip;
				if (item4 != null)
				{
					item4.HideTooltip();
				}
				showingTooltipLeft = default((SnappableItem, ControllerTooltip));
			}
		}

		private void SetupHoverListeners(ItemVRTK item, bool subscribe)
		{
			if (!(item == null))
			{
				item.Ungrabbed -= TryCloseTooltipForItem;
				item.AboutToBeDestroyed -= TryCloseTooltipForItem;
				if (subscribe)
				{
					item.Ungrabbed += TryCloseTooltipForItem;
					item.AboutToBeDestroyed += TryCloseTooltipForItem;
				}
			}
		}

		private void TryCloseTooltipForItem(ControlImplBase ctrlBase)
		{
			ItemVRTK itemVRTK = ctrlBase as ItemVRTK;
			if (itemVRTK == null)
			{
				return;
			}
			SnappableItem snappableItem = itemVRTK.SnappableItem;
			if (!(snappableItem == null))
			{
				bool flag = false;
				if (showingTooltipRight.snappable == snappableItem)
				{
					showingTooltipRight.showingTooltip.HideTooltip();
					showingTooltipRight = default((SnappableItem, ControllerTooltip));
					flag = true;
				}
				else if (showingTooltipLeft.snappable == snappableItem)
				{
					showingTooltipLeft.showingTooltip.HideTooltip();
					showingTooltipLeft = default((SnappableItem, ControllerTooltip));
					flag = true;
				}
				if (flag)
				{
					SetupHoverListeners(itemVRTK, subscribe: false);
				}
			}
		}
	}
}
