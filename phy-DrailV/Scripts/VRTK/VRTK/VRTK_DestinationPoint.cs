using System.Collections;
using UnityEngine;

namespace VRTK
{
	public class VRTK_DestinationPoint : VRTK_DestinationMarker
	{
		public enum RotationTypes
		{
			NoRotation = 0,
			RotateWithNoHeadsetOffset = 1,
			RotateWithHeadsetOffset = 2
		}

		[Header("Destination Point Settings")]
		[Tooltip("The GameObject to use to represent the default cursor state.")]
		public GameObject defaultCursorObject;

		[Tooltip("The GameObject to use to represent the hover cursor state.")]
		public GameObject hoverCursorObject;

		[Tooltip("The GameObject to use to represent the locked cursor state.")]
		public GameObject lockedCursorObject;

		[Tooltip("An optional transform to determine the destination location for the destination marker. This can be useful to offset the destination location from the destination point. If this is left empty then the destiantion point transform will be used.")]
		public Transform destinationLocation;

		[Tooltip("If this is checked then after teleporting, the play area will be snapped to the origin of the destination point. If this is false then it's possible to teleport to anywhere within the destination point collider.")]
		public bool snapToPoint = true;

		[Tooltip("If this is checked, then the pointer cursor will be hidden when a valid destination point is hovered over.")]
		public bool hidePointerCursorOnHover = true;

		[Tooltip("If this is checked, then the pointer direction indicator will be hidden when a valid destination point is hovered over. A pointer direction indicator will always be hidden if snap to rotation is set.")]
		public bool hideDirectionIndicatorOnHover;

		[Tooltip("Determines if the play area will be rotated to the rotation of the destination point upon the destination marker being set.")]
		public RotationTypes snapToRotation;

		[Header("Custom Settings")]
		[Tooltip("The scene teleporter that is used. If this is not specified then it will be auto looked up in the scene.")]
		public VRTK_BasicTeleport teleporter;

		public static VRTK_DestinationPoint currentDestinationPoint;

		protected Collider pointCollider;

		protected bool createdCollider;

		protected Rigidbody pointRigidbody;

		protected bool createdRigidbody;

		protected Coroutine initaliseListeners;

		protected bool isActive;

		protected VRTK_BasePointerRenderer.VisibilityStates storedCursorState;

		protected bool storedDirectionIndicatorState;

		protected bool currentTeleportState;

		protected bool customTeleporter;

		protected Transform playArea;

		protected Transform headset;

		public event DestinationPointEventHandler DestinationPointEnabled;

		public event DestinationPointEventHandler DestinationPointDisabled;

		public event DestinationPointEventHandler DestinationPointLocked;

		public event DestinationPointEventHandler DestinationPointUnlocked;

		public event DestinationPointEventHandler DestinationPointReset;

		public virtual void OnDestinationPointEnabled()
		{
			if (this.DestinationPointEnabled != null)
			{
				this.DestinationPointEnabled(this);
			}
		}

		public virtual void OnDestinationPointDisabled()
		{
			if (this.DestinationPointDisabled != null)
			{
				this.DestinationPointDisabled(this);
			}
		}

		public virtual void OnDestinationPointLocked()
		{
			if (this.DestinationPointLocked != null)
			{
				this.DestinationPointLocked(this);
			}
		}

		public virtual void OnDestinationPointUnlocked()
		{
			if (this.DestinationPointUnlocked != null)
			{
				this.DestinationPointUnlocked(this);
			}
		}

		public virtual void OnDestinationPointReset()
		{
			if (this.DestinationPointReset != null)
			{
				this.DestinationPointReset(this);
			}
		}

		public virtual void ResetDestinationPoint()
		{
			ResetPoint();
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			customTeleporter = teleporter != null;
			CreateColliderIfRequired();
			SetupRigidbody();
			initaliseListeners = StartCoroutine(ManageDestinationMarkersAtEndOfFrame());
			ResetPoint();
			currentTeleportState = enableTeleport;
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			headset = VRTK_DeviceFinder.HeadsetTransform();
			destinationLocation = ((destinationLocation != null) ? destinationLocation : base.transform);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (initaliseListeners != null)
			{
				StopCoroutine(initaliseListeners);
			}
			ManageDestinationMarkers(state: false);
			if (createdCollider)
			{
				Object.Destroy(pointCollider);
				pointCollider = null;
			}
			if (createdRigidbody)
			{
				Object.Destroy(pointRigidbody);
				pointRigidbody = null;
			}
			if (!customTeleporter)
			{
				teleporter = null;
			}
		}

		protected virtual void OnDestroy()
		{
			ManageDestinationMarkers(state: false);
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			if (enableTeleport != currentTeleportState)
			{
				ResetPoint();
			}
			currentTeleportState = enableTeleport;
		}

		protected virtual void CreateColliderIfRequired()
		{
			pointCollider = GetComponentInChildren<Collider>();
			createdCollider = false;
			if (pointCollider == null)
			{
				pointCollider = base.gameObject.AddComponent<SphereCollider>();
				createdCollider = true;
			}
			pointCollider.isTrigger = true;
		}

		protected virtual void SetupRigidbody()
		{
			pointRigidbody = GetComponent<Rigidbody>();
			createdRigidbody = false;
			if (pointRigidbody == null)
			{
				pointRigidbody = base.gameObject.AddComponent<Rigidbody>();
				createdRigidbody = true;
			}
			pointRigidbody.isKinematic = true;
			pointRigidbody.useGravity = false;
		}

		protected virtual IEnumerator ManageDestinationMarkersAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			if (base.enabled)
			{
				ManageDestinationMarkers(state: true);
			}
			teleporter = ((teleporter == null && VRTK_ObjectCache.registeredTeleporters.Count > 0) ? VRTK_ObjectCache.registeredTeleporters[0] : teleporter);
		}

		protected virtual void ManageDestinationMarkers(bool state)
		{
			ManageDestinationMarkerListeners(VRTK_DeviceFinder.GetControllerLeftHand(), state);
			ManageDestinationMarkerListeners(VRTK_DeviceFinder.GetControllerRightHand(), state);
		}

		protected virtual void ManageDestinationMarkerListeners(GameObject markerMaker, bool register)
		{
			if (!(markerMaker != null))
			{
				return;
			}
			VRTK_DestinationMarker[] componentsInChildren = markerMaker.GetComponentsInChildren<VRTK_DestinationMarker>();
			foreach (VRTK_DestinationMarker vRTK_DestinationMarker in componentsInChildren)
			{
				if (!(vRTK_DestinationMarker == this))
				{
					if (register)
					{
						vRTK_DestinationMarker.DestinationMarkerEnter += DoDestinationMarkerEnter;
						vRTK_DestinationMarker.DestinationMarkerExit += DoDestinationMarkerExit;
						vRTK_DestinationMarker.DestinationMarkerSet += DoDestinationMarkerSet;
					}
					else
					{
						vRTK_DestinationMarker.DestinationMarkerEnter -= DoDestinationMarkerEnter;
						vRTK_DestinationMarker.DestinationMarkerExit -= DoDestinationMarkerExit;
						vRTK_DestinationMarker.DestinationMarkerSet -= DoDestinationMarkerSet;
					}
				}
			}
		}

		protected virtual void DoDestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
		{
			if (!(this == null) && !isActive && e.raycastHit.transform == base.transform)
			{
				isActive = true;
				ToggleCursor(sender, state: false);
				EnablePoint();
				if (snapToPoint && teleporter != null)
				{
					teleporter.SetActualTeleportDestination(destinationLocation.position, GetRotation());
				}
				OnDestinationMarkerEnter(SetDestinationMarkerEvent(0f, e.raycastHit.transform, e.raycastHit, e.raycastHit.transform.position, e.controllerReference, forceDestinationPosition: false, GetRotation()));
			}
		}

		protected virtual void DoDestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
		{
			if (!(this == null) && isActive && e.raycastHit.transform == base.transform)
			{
				isActive = false;
				ToggleCursor(sender, state: true);
				ResetPoint();
				if (snapToPoint && teleporter != null)
				{
					teleporter.ResetActualTeleportDestination();
				}
				OnDestinationMarkerExit(SetDestinationMarkerEvent(0f, e.raycastHit.transform, e.raycastHit, e.raycastHit.transform.position, e.controllerReference, forceDestinationPosition: false, GetRotation()));
			}
		}

		protected virtual void DoDestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
		{
			if (this == null)
			{
				return;
			}
			if (e.raycastHit.transform == base.transform)
			{
				currentDestinationPoint = this;
				if (snapToPoint)
				{
					if (teleporter != null)
					{
						teleporter.SetActualTeleportDestination(destinationLocation.position, GetRotation());
					}
					DisablePoint();
				}
			}
			else if (currentDestinationPoint != this)
			{
				ResetPoint();
			}
			else if (currentDestinationPoint != null && e.raycastHit.transform != currentDestinationPoint.transform)
			{
				currentDestinationPoint = null;
				ResetPoint();
			}
		}

		protected virtual void ToggleCursor(object sender, bool state)
		{
			if ((hidePointerCursorOnHover || hideDirectionIndicatorOnHover) && sender.GetType() == typeof(VRTK_Pointer))
			{
				VRTK_Pointer vRTK_Pointer = (VRTK_Pointer)sender;
				if (vRTK_Pointer != null && vRTK_Pointer.pointerRenderer != null)
				{
					TogglePointerCursor(vRTK_Pointer.pointerRenderer, state);
					ToggleDirectionIndicator(vRTK_Pointer.pointerRenderer, state);
				}
			}
		}

		protected virtual void TogglePointerCursor(VRTK_BasePointerRenderer pointerRenderer, bool state)
		{
			if (hidePointerCursorOnHover)
			{
				if (!state)
				{
					storedCursorState = pointerRenderer.cursorVisibility;
					pointerRenderer.cursorVisibility = VRTK_BasePointerRenderer.VisibilityStates.AlwaysOff;
				}
				else
				{
					pointerRenderer.cursorVisibility = storedCursorState;
				}
			}
		}

		protected virtual void ToggleDirectionIndicator(VRTK_BasePointerRenderer pointerRenderer, bool state)
		{
			if (pointerRenderer.directionIndicator != null && hideDirectionIndicatorOnHover)
			{
				if (!state)
				{
					storedDirectionIndicatorState = pointerRenderer.directionIndicator.isActive;
					pointerRenderer.directionIndicator.isActive = false;
				}
				else
				{
					pointerRenderer.directionIndicator.isActive = storedDirectionIndicatorState;
				}
			}
		}

		protected virtual void EnablePoint()
		{
			ToggleObject(lockedCursorObject, state: false);
			ToggleObject(defaultCursorObject, state: false);
			ToggleObject(hoverCursorObject, state: true);
			OnDestinationPointEnabled();
		}

		protected virtual void SetColliderState(bool state)
		{
			if (pointCollider != null)
			{
				pointCollider.enabled = state;
			}
		}

		protected virtual void DisablePoint()
		{
			SetColliderState(state: false);
			ToggleObject(lockedCursorObject, state: false);
			ToggleObject(defaultCursorObject, state: false);
			ToggleObject(hoverCursorObject, state: false);
			OnDestinationPointDisabled();
		}

		protected virtual void ResetPoint()
		{
			if (!snapToPoint || !(currentDestinationPoint == this))
			{
				ToggleObject(hoverCursorObject, state: false);
				if (enableTeleport)
				{
					SetColliderState(state: true);
					ToggleObject(defaultCursorObject, state: true);
					ToggleObject(lockedCursorObject, state: false);
					OnDestinationPointUnlocked();
				}
				else
				{
					SetColliderState(state: false);
					ToggleObject(lockedCursorObject, state: true);
					ToggleObject(defaultCursorObject, state: false);
					OnDestinationPointLocked();
				}
				OnDestinationPointReset();
			}
		}

		protected virtual void ToggleObject(GameObject givenObject, bool state)
		{
			if (givenObject != null)
			{
				givenObject.SetActive(state);
			}
		}

		protected virtual Quaternion? GetRotation()
		{
			if (snapToRotation == RotationTypes.NoRotation)
			{
				return null;
			}
			float num = ((snapToRotation == RotationTypes.RotateWithHeadsetOffset && playArea != null && headset != null) ? (playArea.eulerAngles.y - headset.eulerAngles.y) : 0f);
			return Quaternion.Euler(0f, destinationLocation.eulerAngles.y + num, 0f);
		}
	}
}
