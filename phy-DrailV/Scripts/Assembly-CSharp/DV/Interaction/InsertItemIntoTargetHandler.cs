using System.Linq;
using DV.Highlighting;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.Items;
using DV.Player;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class InsertItemIntoTargetHandler : MonoBehaviour, ItemPositionController.IPositionProvider
	{
		public const string ANIMATION_POSE_TARGET = "[animation_pose_target]";

		public LayerMask layerMask;

		private Grabber grabber;

		private HighlightTag prevHighlight;

		private bool itemGrabbedThisFrame;

		private RaycastHit[] hits = new RaycastHit[16];

		public ItemWorkingAnimation itemWorkingAnimation;

		private IItemUseAnimated animatedUse;

		private ItemUseTarget animatedTarget;

		public int Priority => 1;

		private void Awake()
		{
			grabber = GetComponent<Grabber>();
			grabber.GrabStarted += OnGrabStarted;
			itemWorkingAnimation.AnimationStarted += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Add(this);
			};
			itemWorkingAnimation.AnimationStopped += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
			};
			itemWorkingAnimation.WorkStopped += delegate
			{
				animatedUse.HandleUse(animatedTarget);
			};
			itemWorkingAnimation.InputPressedCallback = () => true;
			itemWorkingAnimation.WorkDoneCallback = () => true;
		}

		private void OnDestroy()
		{
			if (grabber != null)
			{
				grabber.GrabStarted -= OnGrabStarted;
			}
		}

		private void OnGrabStarted(AGrabHandler grabHandler)
		{
			if (grabHandler.IsItem)
			{
				itemGrabbedThisFrame = true;
			}
		}

		private void Update()
		{
			HighlightTag desiredHighlight = null;
			if (itemWorkingAnimation.IsAnimating && animatedUse == null)
			{
				itemWorkingAnimation.StopAnimating();
			}
			if (RaycastAllowed())
			{
				DoRaycastLogic(ref desiredHighlight);
			}
			if (prevHighlight != desiredHighlight)
			{
				SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: false, prevHighlight, AGeneralHighlighter.HighlightType.Item, useObstructedMaterial: true);
				prevHighlight = desiredHighlight;
				SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: true, prevHighlight, AGeneralHighlighter.HighlightType.Item, useObstructedMaterial: true);
			}
		}

		private bool RaycastAllowed()
		{
			if (!itemGrabbedThisFrame)
			{
				if ((SingletonBehaviour<HotbarController>.Instance == null || !SingletonBehaviour<HotbarController>.Instance.IsOpen) && (SingletonBehaviour<InventoryViewBase>.Instance == null || !SingletonBehaviour<InventoryViewBase>.Instance.BigInventoryOpen))
				{
					return !SingletonBehaviour<AppUtil>.Instance.IsTimePaused;
				}
				return false;
			}
			itemGrabbedThisFrame = false;
			return false;
		}

		private void DoRaycastLogic(ref HighlightTag desiredHighlight)
		{
			AGrabHandler currentItemHeld = grabber.CurrentItemHeld;
			if (!currentItemHeld)
			{
				return;
			}
			IItemUse[] components = currentItemHeld.GetComponents<IItemUse>();
			if (components == null || components.Length == 0)
			{
				return;
			}
			int num = Physics.RaycastNonAlloc(grabber.Cursor.GetRay(), hits, 4f, layerMask, QueryTriggerInteraction.Collide);
			if (num <= 0)
			{
				return;
			}
			RaycastUtils.SortDistanceAndExpandCache(ref hits, num);
			bool flag = SingletonBehaviour<ScreenspaceMouse>.Instance.on;
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit = hits[i];
				Collider collider = raycastHit.collider;
				AGrabHandler componentInParent = collider.GetComponentInParent<AGrabHandler>();
				if (componentInParent != null && (componentInParent == currentItemHeld || componentInParent.ParentGrabHandler == currentItemHeld))
				{
					if (flag)
					{
						break;
					}
					continue;
				}
				ItemUseTarget itemUseTarget = collider.GetComponentInParent<ItemUseTarget>();
				if (!itemUseTarget)
				{
					ItemUseRedirect componentInParent2 = collider.GetComponentInParent<ItemUseRedirect>();
					if (componentInParent2 != null)
					{
						itemUseTarget = componentInParent2.Target;
					}
				}
				if (!itemUseTarget)
				{
					if (!collider.GetComponentInParent<StaticInteractionArea>())
					{
						break;
					}
					continue;
				}
				if (!itemUseTarget.targetColliders.Contains(raycastHit.collider))
				{
					break;
				}
				IItemUse[] array = components;
				foreach (IItemUse itemUse in array)
				{
					if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionPrimary) && itemUse.IsUseCompatible(itemUseTarget))
					{
						if (itemUse is IItemUseAnimated itemUseAnimated)
						{
							animatedUse = itemUseAnimated;
							animatedTarget = itemUseTarget;
							itemWorkingAnimation.StartAnimating();
							return;
						}
						if (itemUse.HandleUse(itemUseTarget))
						{
							return;
						}
					}
					else if (itemUse.IsHoverCompatible(itemUseTarget) && itemUse.HandleHover(itemUseTarget))
					{
						desiredHighlight = itemUseTarget.GetComponent<HighlightTag>();
						return;
					}
				}
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			(Vector3, Quaternion) tuple = ((animatedTarget != null && animatedTarget.gameObject.activeSelf && animatedUse != null && animatedUse.InteractionPoint != null && animatedUse.InteractionPoint.gameObject.activeSelf) ? animatedUse.TargetPoint(animatedTarget) : (default(Vector3), default(Quaternion)));
			(Vector3, Quaternion) tuple2 = tuple;
			if (tuple2.Item1 == default(Vector3) && tuple2.Item2 == default(Quaternion))
			{
				animatedUse = null;
				animatedTarget = null;
				return default((Vector3, Quaternion, float));
			}
			(Vector3, Quaternion) tuple3 = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, tuple.Item1, tuple.Item2, animatedUse.InteractionPoint);
			float item = ItemWorkingAnimation.EaseInCubic(itemWorkingAnimation.MoveToWorkProgress);
			return (pos: tuple3.Item1, rot: tuple3.Item2, overridePreviousPerc: item);
		}
	}
}
