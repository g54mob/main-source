using System.Collections;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

namespace DV.CabControls.VRTK
{
	[DisallowMultipleComponent]
	public class CarryItemAfterTeleportVRTK : MonoBehaviour
	{
		public bool overrideShouldAllowAdjustment;

		public bool overrideShouldAllowAdjustmentValue;

		protected VRTK_InteractableObject interactable;

		private Transform playArea;

		private Vector3 itemPositionRelativeToPlayArea;

		private float playAreaStartRotation;

		private bool adjustmentWasAllowed;

		private Rigidbody rb;

		private IEnumerator Start()
		{
			yield return WaitFor.EndOfFrame;
			Initialize();
		}

		protected virtual void Initialize()
		{
			interactable = GetComponent<VRTK_InteractableObject>();
			rb = GetComponent<Rigidbody>();
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				interactable.InteractableObjectGrabbed += OnGrabbed;
				interactable.InteractableObjectUngrabbed += OnUngrabbed;
				return;
			}
			if (interactable != null)
			{
				interactable.InteractableObjectGrabbed -= OnGrabbed;
				interactable.InteractableObjectUngrabbed -= OnUngrabbed;
			}
			ToggleTeleportAndRotationDependantListeners(on: false);
		}

		private void ToggleTeleportAndRotationDependantListeners(bool on)
		{
			PlayerManager.PlayerTeleportStarted -= OnTeleportStart;
			PlayerManager.PlayerTeleportFinished -= OnTeleportEnd;
			RotatePlayer.AboutToRotatePlayer -= OnRotateStart;
			RotatePlayer.RotatedPlayer -= OnRotateEnd;
			if (on)
			{
				PlayerManager.PlayerTeleportStarted += OnTeleportStart;
				PlayerManager.PlayerTeleportFinished += OnTeleportEnd;
				RotatePlayer.AboutToRotatePlayer += OnRotateStart;
				RotatePlayer.RotatedPlayer += OnRotateEnd;
			}
		}

		protected virtual void OnGrabbed(object sender, InteractableObjectEventArgs e)
		{
			ToggleTeleportAndRotationDependantListeners(on: true);
		}

		protected virtual void OnUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			ToggleTeleportAndRotationDependantListeners(on: false);
		}

		public void OnTeleportStart()
		{
			Before();
		}

		public void OnTeleportEnd()
		{
			After();
		}

		private void OnRotateStart()
		{
			Before();
		}

		private void OnRotateEnd()
		{
			After();
		}

		public virtual bool ShouldAllowAdjustment()
		{
			bool flag = GetComponent<VRTK_ChildOfControllerGrabAttach>() == null;
			if (overrideShouldAllowAdjustment)
			{
				return overrideShouldAllowAdjustmentValue && flag;
			}
			return flag;
		}

		protected virtual bool Before()
		{
			adjustmentWasAllowed = ShouldAllowAdjustment();
			if (!adjustmentWasAllowed)
			{
				return false;
			}
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			itemPositionRelativeToPlayArea = playArea.InverseTransformPoint(rb.position);
			playAreaStartRotation = playArea.rotation.eulerAngles.y;
			return true;
		}

		protected virtual bool After()
		{
			if (!adjustmentWasAllowed)
			{
				return false;
			}
			float num = playArea.rotation.eulerAngles.y - playAreaStartRotation;
			Vector3 position = playArea.TransformPoint(itemPositionRelativeToPlayArea);
			rb.position = position;
			Vector3 eulerAngles = base.transform.rotation.eulerAngles;
			rb.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y + num, eulerAngles.z);
			return true;
		}
	}
}
