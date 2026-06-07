using System;
using DV.CabControls;
using DV.Interaction.Inputs;
using DV.Localization;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	[RequireComponent(typeof(InventoryItemSpec))]
	public abstract class GadgetInteractor : MonoBehaviour
	{
		protected internal enum HighlightMode : byte
		{
			None = 0,
			Bad = 1,
			Maybe = 2,
			Good = 3,
			Done = 4,
			Wiring = 5
		}

		public const float VR_PLACE_RADIUS = 0.1f;

		public const float VR_INTERACT_RADIUS = 0.01f;

		public const float REACH = 3f;

		public const float REACH_SQR = 9f;

		[SerializeField]
		protected bool vrUseOverlapInsteadOfRaycast = true;

		[SerializeField]
		protected Transform vrInteractionPoint;

		private bool use;

		private GadgetBase target;

		public ItemBase ItemBase { get; private set; }

		protected GadgetBase Target => target;

		public bool IsPressed { get; private set; }

		public bool IsGrabbed { get; private set; }

		protected float HighlightFill { get; set; }

		protected RaycastHitDV RaycastHit { get; private set; }

		protected Ray Ray { get; private set; }

		public virtual bool CallRegularUpdateWhenNull => false;

		protected virtual bool DisableWhenNotGrabbed => true;

		protected virtual Predicate<RaycastHitDV> QueryPredicate => null;

		public static bool TryGetTarget(RaycastHitDV hit, out GadgetBase result)
		{
			result = hit.collider.GetComponentInParent<GadgetBase>();
			return result != null;
		}

		protected virtual void Start()
		{
			ItemBase = GetComponent<ItemBase>();
			ItemBase.Used += Used;
			ItemBase.UnUsed += Unused;
			ItemBase.Grabbed += Grabbed;
			ItemBase.Ungrabbed += Ungrabbed;
			bool flag = DisableWhenNotGrabbed && !ItemBase.IsGrabbed();
			base.enabled = !flag;
		}

		protected void ShowWire(Vector3 a, Vector3 b, WireHighlightMode highlight)
		{
			GadgetSystemUtility.ScheduleWireDraw(a, b, highlight);
		}

		protected void ShowWire(Component a, Component b, WireHighlightMode highlight)
		{
			ShowWire(a.transform.position, b.transform.position, highlight);
		}

		protected void ShowWire(Component to, WireHighlightMode highlight)
		{
			ShowWire(target.transform.position, to.transform.position, highlight);
		}

		protected void ShowWire(Vector3 to, WireHighlightMode highlight)
		{
			ShowWire(target.transform.position, to, highlight);
		}

		public static void ShowInteractionTextLMB(string text, bool localize = true)
		{
			ShowInteractionText(text, localize, GetLocalizedUseKey());
		}

		protected static void ShowInteractionText(string text, bool localize, string paramValue)
		{
			if (!VRManager.IsVREnabled())
			{
				if (localize)
				{
					text = LocalizationAPI.L(text, paramValue);
				}
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(text);
			}
		}

		protected static string GetLocalizedUseKey()
		{
			return InputManager.Actions.InteractionPrimary.LocalizeInput();
		}

		protected abstract HighlightMode OnUpdate(GadgetBase target, bool use);

		protected virtual void OnUpdateNull(bool use)
		{
		}

		protected virtual bool TryGetQueryPose(out Vector3 pos, out Quaternion rot)
		{
			Transform transform;
			if (VRManager.IsVREnabled())
			{
				transform = vrInteractionPoint;
				if (transform == null)
				{
					transform = base.transform;
				}
			}
			else
			{
				transform = PlayerManager.ActiveCamera.transform;
			}
			if (transform == null)
			{
				pos = default(Vector3);
				rot = default(Quaternion);
				return false;
			}
			pos = transform.position;
			rot = transform.rotation;
			return true;
		}

		protected virtual void Update()
		{
			bool flag = use;
			use = false;
			target = null;
			if (!TryGetQueryPose(out var pos, out var rot))
			{
				return;
			}
			Ray = new Ray(pos, rot * Vector3.forward);
			RaycastHitDV hit;
			if (VRManager.IsVREnabled() && vrUseOverlapInsteadOfRaycast)
			{
				if (PhysicsQueryBuilder.OverlapSphere(Ray.origin, 0.01f, Layers.DVLayerMask.Interactable.ToLayerMask()).Where(QueryPredicate).TryGetFirst(out hit))
				{
					TryGetTarget(hit, out target);
				}
			}
			else if (PhysicsQueryBuilder.Raycast(Ray.origin, Ray.direction, 3f, Layers.DVLayerMask.Interactable.ToLayerMask()).Where(QueryPredicate).TryGetFirst(out hit))
			{
				TryGetTarget(hit, out target);
			}
			if (target == null)
			{
				OnUpdateNull(flag);
				if (!CallRegularUpdateWhenNull)
				{
					return;
				}
			}
			HighlightFill = 0f;
			RaycastHit = hit;
			HighlightMode highlightMode = OnUpdate(target, flag);
			Color color = default(Color);
			switch (highlightMode)
			{
			case HighlightMode.Bad:
				color = GadgetSystemUtility.COLOR_HIGHLIGHT_BAD;
				break;
			case HighlightMode.Maybe:
				color = GadgetSystemUtility.COLOR_HIGHLIGHT_MAYBE;
				break;
			case HighlightMode.Good:
				color = GadgetSystemUtility.COLOR_HIGHLIGHT_GOOD;
				break;
			case HighlightMode.Done:
				color = GadgetSystemUtility.COLOR_HIGHLIGHT_NOT_YET;
				break;
			case HighlightMode.Wiring:
				color = GadgetSystemUtility.COLOR_HIGHLIGHT_WIRING;
				break;
			}
			if (color.a > 0f)
			{
				target?.DrawHighlight(color, doLateUpdateOffset: true);
			}
		}

		private void Used()
		{
			if (SingletonBehaviour<GadgetSystemUtility>.Instance.CheckGadgetAgainstRestrictions(ItemBase))
			{
				use = true;
				IsPressed = true;
				OnUsed();
			}
		}

		private void Unused()
		{
			IsPressed = false;
			OnUnused();
		}

		private void Grabbed(object _)
		{
			use = false;
			if (DisableWhenNotGrabbed)
			{
				base.enabled = true;
			}
			IsGrabbed = true;
			OnGrabbed();
		}

		private void Ungrabbed(object _)
		{
			use = false;
			IsGrabbed = false;
			OnUpdateNull(use: false);
			OnUngrabbed();
			if (DisableWhenNotGrabbed)
			{
				base.enabled = false;
			}
		}

		protected virtual void OnUsed()
		{
		}

		protected virtual void OnUnused()
		{
		}

		protected virtual void OnGrabbed()
		{
		}

		protected virtual void OnUngrabbed()
		{
		}

		public static bool IsCameraInInteractionRange(Vector3 target)
		{
			return PlayerManager.IsCameraWithinRangeOf(target, 9f);
		}
	}
}
