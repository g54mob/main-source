using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_SlingshotJump")]
	public class VRTK_SlingshotJump : MonoBehaviour
	{
		[Header("SlingshotJump Settings")]
		[Tooltip("How close together the button releases have to be to initiate a jump.")]
		public float releaseWindowTime = 0.5f;

		[Tooltip("Multiplier that increases the jump strength.")]
		public float velocityMultiplier = 5f;

		[Tooltip("The maximum velocity a jump can be.")]
		public float velocityMax = 8f;

		[Tooltip("The button that will initiate the slingshot move.")]
		[SerializeField]
		protected VRTK_ControllerEvents.ButtonAlias activationButton = VRTK_ControllerEvents.ButtonAlias.GripPress;

		[Tooltip("The button that will cancel an already tensioned sling shot.")]
		[SerializeField]
		protected VRTK_ControllerEvents.ButtonAlias cancelButton;

		[Tooltip("The Body Physics script to deal with the physics and gravity of the play area. If the script is being applied onto an object that already has a VRTK_BodyPhysics component, this parameter can be left blank as it will be auto populated by the script at runtime.")]
		[SerializeField]
		protected VRTK_BodyPhysics bodyPhysics;

		[Tooltip("The Player Climb script to deal ability to throw the play area. If the script is being applied onto an object that already has a VRTK_PlayerClimb component, this parameter can be left blank as it will be auto populated by the script at runtime.")]
		[SerializeField]
		protected VRTK_PlayerClimb playerClimb;

		[Tooltip("The Teleporter script to deal play area teleporting. If the script is being applied onto an object that already has a VRTK_BasicTeleport component, this parameter can be left blank as it will be auto populated by the script at runtime.")]
		[SerializeField]
		protected VRTK_BasicTeleport teleporter;

		protected Transform playArea;

		protected Vector3 leftStartAimPosition;

		protected Vector3 leftReleasePosition;

		protected bool leftIsAiming;

		protected Vector3 rightStartAimPosition;

		protected Vector3 rightReleasePosition;

		protected bool rightIsAiming;

		protected VRTK_ControllerEvents leftControllerEvents;

		protected VRTK_ControllerEvents rightControllerEvents;

		protected VRTK_InteractGrab leftControllerGrab;

		protected VRTK_InteractGrab rightControllerGrab;

		protected bool leftButtonReleased;

		protected bool rightButtonReleased;

		protected float countDownEndTime;

		public event SlingshotJumpEventHandler SlingshotJumped;

		public virtual VRTK_ControllerEvents.ButtonAlias GetActivationButton()
		{
			return activationButton;
		}

		public virtual void SetActivationButton(VRTK_ControllerEvents.ButtonAlias button)
		{
			InitControllerListeners(state: false);
			activationButton = button;
			InitControllerListeners(state: true);
		}

		public virtual VRTK_ControllerEvents.ButtonAlias GetCancelButton()
		{
			return cancelButton;
		}

		public virtual void SetCancelButton(VRTK_ControllerEvents.ButtonAlias button)
		{
			InitControllerListeners(state: false);
			cancelButton = button;
			InitControllerListeners(state: true);
		}

		protected virtual void Awake()
		{
			bodyPhysics = ((bodyPhysics != null) ? bodyPhysics : Object.FindObjectOfType<VRTK_BodyPhysics>());
			playerClimb = ((playerClimb != null) ? playerClimb : Object.FindObjectOfType<VRTK_PlayerClimb>());
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			InitListeners(state: true);
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
		}

		protected virtual void OnDisable()
		{
			UnAim();
			InitListeners(state: false);
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void LeftButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			if (!leftIsAiming && !IsClimbing())
			{
				leftIsAiming = true;
				leftStartAimPosition = playArea.InverseTransformPoint(leftControllerEvents.gameObject.transform.position);
			}
		}

		protected virtual void RightButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			if (!rightIsAiming && !IsClimbing())
			{
				rightIsAiming = true;
				rightStartAimPosition = playArea.InverseTransformPoint(rightControllerEvents.gameObject.transform.position);
			}
		}

		protected virtual void LeftButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			if (leftIsAiming)
			{
				leftReleasePosition = playArea.InverseTransformPoint(leftControllerEvents.gameObject.transform.position);
				if (!rightButtonReleased)
				{
					countDownEndTime = Time.time + releaseWindowTime;
				}
				leftButtonReleased = true;
			}
			CheckForReset();
			CheckForJump();
		}

		protected virtual void RightButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			if (rightIsAiming)
			{
				rightReleasePosition = playArea.InverseTransformPoint(rightControllerEvents.gameObject.transform.position);
				if (!leftButtonReleased)
				{
					countDownEndTime = Time.time + releaseWindowTime;
				}
				rightButtonReleased = true;
			}
			CheckForReset();
			CheckForJump();
		}

		protected virtual void CancelButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			UnAim();
		}

		protected virtual void CheckForReset()
		{
			if ((leftButtonReleased || rightButtonReleased) && Time.time > countDownEndTime)
			{
				UnAim();
			}
		}

		protected virtual void CheckForJump()
		{
			if (leftButtonReleased && rightButtonReleased && !bodyPhysics.IsFalling())
			{
				Vector3 vector = leftStartAimPosition - leftReleasePosition;
				Vector3 vector2 = rightStartAimPosition - rightReleasePosition;
				Vector3 vector3 = vector + vector2;
				Vector3 velocity = playArea.transform.TransformVector(vector3) * velocityMultiplier;
				if (velocity.magnitude > velocityMax)
				{
					velocity = velocity.normalized * velocityMax;
				}
				bodyPhysics.ApplyBodyVelocity(velocity, forcePhysicsOn: true, applyMomentum: true);
				UnAim();
				OnSlingshotJumped();
			}
		}

		protected void OnSlingshotJumped()
		{
			if (this.SlingshotJumped != null)
			{
				this.SlingshotJumped(this);
			}
		}

		protected void InitListeners(bool state)
		{
			InitTeleportListener(state);
			InitControllerListeners(state);
		}

		protected void InitTeleportListener(bool state)
		{
			teleporter = ((teleporter != null) ? teleporter : Object.FindObjectOfType<VRTK_BasicTeleport>());
			if (teleporter != null)
			{
				if (state)
				{
					teleporter.Teleporting += OnTeleport;
				}
				else
				{
					teleporter.Teleporting -= OnTeleport;
				}
			}
		}

		protected void InitControllerListeners(bool state)
		{
			InitControllerListener(state, VRTK_DeviceFinder.GetControllerLeftHand(), ref leftControllerEvents, ref leftControllerGrab, LeftButtonPressed, LeftButtonReleased);
			InitControllerListener(state, VRTK_DeviceFinder.GetControllerRightHand(), ref rightControllerEvents, ref rightControllerGrab, RightButtonPressed, RightButtonReleased);
		}

		protected void InitControllerListener(bool state, GameObject controller, ref VRTK_ControllerEvents events, ref VRTK_InteractGrab grab, ControllerInteractionEventHandler triggerPressed, ControllerInteractionEventHandler triggerReleased)
		{
			if (!(controller != null))
			{
				return;
			}
			events = controller.GetComponentInChildren<VRTK_ControllerEvents>();
			grab = controller.GetComponentInChildren<VRTK_InteractGrab>();
			if (!(events != null))
			{
				return;
			}
			if (state)
			{
				events.SubscribeToButtonAliasEvent(activationButton, startEvent: true, triggerPressed);
				events.SubscribeToButtonAliasEvent(activationButton, startEvent: false, triggerReleased);
				if (cancelButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					events.SubscribeToButtonAliasEvent(cancelButton, startEvent: true, CancelButtonPressed);
				}
			}
			else
			{
				events.UnsubscribeToButtonAliasEvent(activationButton, startEvent: true, triggerPressed);
				events.UnsubscribeToButtonAliasEvent(activationButton, startEvent: false, triggerReleased);
				if (cancelButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					events.UnsubscribeToButtonAliasEvent(cancelButton, startEvent: true, CancelButtonPressed);
				}
			}
		}

		protected void OnTeleport(object sender, DestinationMarkerEventArgs e)
		{
			UnAim();
		}

		protected void UnAim()
		{
			leftIsAiming = false;
			rightIsAiming = false;
			leftButtonReleased = false;
			rightButtonReleased = false;
		}

		protected bool IsClimbing()
		{
			if (playerClimb != null)
			{
				return playerClimb.IsClimbing();
			}
			return false;
		}
	}
}
