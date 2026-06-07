using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Input.Events;
using Assets.Scripts.Input.XR;
using Assets.Scripts.XR.HandPoses;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XR
{
	public class FlightHand : HandScriptBase
	{
		public const float InteractablePartTooltipDelay = 0.5f;

		[SerializeField]
		private XRControlGripType _airGripType;

		private IInteractablePartModifier _capturedInputModifier;

		private ControlBaseScript _currentControl;

		private ControlBaseScript.AttachedHand _currentGrip;

		private IGripTarget _currentGripTarget;

		private Pose _defaultFingertipOffset;

		private Pose _defaultHandOffset;

		private InputAction _fingerInteractionAction;

		[SerializeField]
		private SphereCollider _fingertipSphere;

		private bool _grippingAir;

		private bool _gripPressed;

		private InputAction _gripPressedInput;

		private InputAction _gripReleasedInput;

		private int _gripStateChangedFrameCount;

		private HandPoseManager _handPoseManager;

		private InteractableCollider _hovered;

		private IInteractablePartModifier _hoveredModifier;

		private float _hoveredModifierElapsedTime;

		private InputEventXR _inputEvent;

		private bool _isGripped;

		private bool _isPosed;

		private Camera _mainCamera;

		private PartTooltipScript _partTooltip;

		[SerializeField]
		private InteractableColliderDetectorScript[] fingertipInteractors;

		[SerializeField]
		private Transform fingertipTransform;

		[SerializeField]
		private CapsuleCollider[] gripCheckColliders;

		[SerializeField]
		private LayerMask gripLayerMask;

		[SerializeField]
		private Transform gripTransform;

		[SerializeField]
		private Transform pointerTransform;

		[SerializeField]
		private HandPoseManager poseManager;

		public override bool CanIdle
		{
			get
			{
				if (!_isPosed && !_isGripped && !GrippingAir)
				{
					return base.CanIdle;
				}
				return false;
			}
		}

		public bool GripPhysicallyPressed { get; private set; }

		public bool GrippingAir
		{
			get
			{
				return _grippingAir;
			}
			private set
			{
				_grippingAir = value;
			}
		}

		public bool GrippingAnything
		{
			get
			{
				if (!_isGripped)
				{
					return _grippingAir;
				}
				return true;
			}
		}

		public IGripTarget GripTarget => _currentGripTarget;

		public bool GripToggled
		{
			get
			{
				if ((bool)Game.Instance.Settings.Gameplay.Flight.XRGripToggleEnabled)
				{
					return GrippingAnything;
				}
				return false;
			}
		}

		public Transform GripTransform => gripTransform;

		public InteractableCollider Hovered
		{
			get
			{
				return _hovered;
			}
			private set
			{
				if (!(_hovered == value))
				{
					if (_hovered != null)
					{
						_hovered.InteractablePart.IsOutlined = false;
						_hovered.CurrentTriggerValue = 0f;
						_hovered.InteractionEnd();
					}
					_hovered = value;
					if (_hovered != null)
					{
						_hovered.InteractablePart.IsOutlined = true;
					}
				}
			}
		}

		public bool IsGripped => _isGripped;

		protected Pose CurrentPose => new Pose(gripTransform.position, gripTransform.rotation);

		public IInteractablePartModifier GetInteractablePart()
		{
			if (_hovered != null)
			{
				return _hovered.InteractablePart;
			}
			return null;
		}

		protected virtual void Awake()
		{
			_partTooltip = Object.Instantiate(Resources.Load<PartTooltipScript>("Flight/Gui/InteractablePartTooltip"));
			_partTooltip.name = "PartTooltip_" + (base.gameObject.name.StartsWith("Left") ? "LeftHandXR" : "RightHandXR");
			_partTooltip.Initialize(isXRTooltip: true);
		}

		protected virtual void FixedUpdate()
		{
			if (_isGripped)
			{
				if (_currentGrip == null || _currentGrip.Dead)
				{
					GripStop();
				}
				else
				{
					_currentControl.GripUpdate(_currentGrip, CurrentPose);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if (_gripPressedInput != null)
			{
				_gripPressedInput.performed -= OnGripPressed;
			}
			if (_gripReleasedInput != null)
			{
				_gripReleasedInput.performed -= OnGripReleased;
			}
		}

		protected override void Start()
		{
			base.Start();
			if (base.HandType == XRHandType.Left)
			{
				_fingerInteractionAction = XRInputs.Flight.InteractLeft;
				_gripPressedInput = XRInputs.Flight.GripPressedLeft;
				_gripReleasedInput = XRInputs.Flight.GripReleasedLeft;
			}
			else
			{
				_fingerInteractionAction = XRInputs.Flight.InteractRight;
				_gripPressedInput = XRInputs.Flight.GripPressedRight;
				_gripReleasedInput = XRInputs.Flight.GripReleasedRight;
			}
			_gripPressedInput.performed += OnGripPressed;
			_gripPressedInput.canceled += OnGripCanceled;
			_gripReleasedInput.performed += OnGripReleased;
			XRVirtualInputDevice.UpdateGrip(base.HandType, XRControlGripType.Default);
			_defaultHandOffset = new Pose(poseManager.transform.localPosition, poseManager.transform.localRotation);
			_defaultFingertipOffset = new Pose(base.transform.InverseTransformPoint(fingertipTransform.position), fingertipTransform.rotation * Quaternion.Inverse(base.transform.rotation));
			_mainCamera = CameraManagerScript.Instance.XRCameraManager.MainCamera;
			CameraManagerScript.Instance.SwitchingToNewViewMode += OnSwitchingToNewViewMode;
			_handPoseManager = base.gameObject.GetComponentInChildren<HandPoseManager>();
		}

		protected override void Update()
		{
			base.Update();
			if (_isPosed)
			{
				Pose currentGripOffset = poseManager.CurrentGripOffset;
				Transform targetTransform = _currentGripTarget.TargetTransform;
				Vector3 vector = (_currentGripTarget.SnapHandPositionToTarget ? targetTransform.TransformDirection(currentGripOffset.position) : Vector3.zero);
				poseManager.transform.position = targetTransform.position + vector;
				if (_currentGripTarget.SnapHandRotationToTarget)
				{
					poseManager.transform.rotation = targetTransform.rotation * currentGripOffset.rotation;
				}
			}
			else
			{
				poseManager.transform.localPosition = _defaultHandOffset.position;
				poseManager.transform.localRotation = _defaultHandOffset.rotation;
			}
			if (_currentGripTarget != null)
			{
				_currentGripTarget.OnGripUpdate(this);
			}
			if (!_isPosed && !_isGripped && !GrippingAir)
			{
				Pose transformedBy = _defaultFingertipOffset.GetTransformedBy(new Pose(base.transform.position, base.transform.rotation));
				List<InteractableCollider> list = new List<InteractableCollider>();
				float num = 0f;
				InteractableCollider interactableCollider = null;
				InteractableColliderDetectorScript[] array = fingertipInteractors;
				foreach (InteractableColliderDetectorScript interactableColliderDetectorScript in array)
				{
					for (int j = 0; j < interactableColliderDetectorScript.Count; j++)
					{
						InteractableCollider interactableCollider2 = interactableColliderDetectorScript[j];
						if (!list.Contains(interactableCollider2))
						{
							list.Add(interactableCollider2);
							float num2 = interactableCollider2.CalculateGripScore(this, transformedBy);
							if (num2 > num)
							{
								num = num2;
								interactableCollider = interactableCollider2;
							}
						}
					}
				}
				Hovered = interactableCollider;
				if (interactableCollider != null)
				{
					Pose fingertipPose = new Pose(_fingertipSphere.transform.position, _fingertipSphere.transform.rotation);
					Pose pose = fingertipPose;
					interactableCollider.InteractionUpdate(triggerPull: interactableCollider.CurrentTriggerValue = _fingerInteractionAction.ReadValue<float>(), fingertipPose: ref fingertipPose, fingertipRadius: _fingertipSphere.GetWorldRadius(), forcePoint: out var forcePoint, hand: this);
					poseManager.OverridePoint = forcePoint;
					Vector3 vector2 = fingertipPose.position - pose.position;
					Quaternion quaternion = fingertipPose.rotation * Quaternion.Inverse(pose.rotation);
					poseManager.transform.position += vector2;
					poseManager.transform.rotation *= quaternion;
				}
				else if (!GripToggled)
				{
					poseManager.OverridePoint = null;
				}
				UpdateTooltip();
			}
			else
			{
				SetHoveredModifier(null);
				if (!GripToggled)
				{
					poseManager.OverridePoint = null;
				}
			}
		}

		private void GripStart()
		{
			Dictionary<Rigidbody, ControlBaseScript> cockpitControls = FlightXRRigManager.Instance.CockpitControls;
			ControlBaseScript value = null;
			if (_currentGripTarget != null)
			{
				_currentGripTarget.OnGripDetached(this);
				_currentGripTarget = null;
			}
			Physics.SyncTransforms();
			for (int i = 0; i < gripCheckColliders.Length; i++)
			{
				CapsuleCollider capsuleCollider = gripCheckColliders[i];
				Vector3 vector = ((capsuleCollider.direction == 0) ? Vector3.right : ((capsuleCollider.direction == 1) ? Vector3.up : Vector3.forward)) * (capsuleCollider.height / 2f - capsuleCollider.radius);
				Vector3 lossyScale = capsuleCollider.transform.lossyScale;
				Vector3 normal = vector;
				Vector3 tangent = default(Vector3);
				Vector3 binormal = default(Vector3);
				Vector3.OrthoNormalize(ref normal, ref tangent, ref binormal);
				tangent.Scale(lossyScale);
				binormal.Scale(lossyScale);
				float radius = capsuleCollider.radius * ((tangent.sqrMagnitude > binormal.sqrMagnitude) ? tangent.magnitude : binormal.magnitude);
				Collider[] array = Physics.OverlapCapsule(capsuleCollider.transform.TransformPoint(capsuleCollider.center + vector), capsuleCollider.transform.TransformPoint(capsuleCollider.center - vector), radius, gripLayerMask, QueryTriggerInteraction.Collide);
				for (int j = 0; j < array.Length; j++)
				{
					Rigidbody attachedRigidbody;
					if (PosedGripScript.ColliderLookup.TryGetValue(array[j], out var value2))
					{
						_currentGripTarget = value2;
						_currentGripTarget.OnGripAttached(this);
						XRVirtualInputDevice.UpdateGrip(base.HandType, _currentGripTarget.GripType);
						if (value2 is PartModifierScript partModifierScript)
						{
							value = partModifierScript.PartScript.GetModifier<ControlBaseScript>();
						}
						if (value == null)
						{
							attachedRigidbody = array[j].attachedRigidbody;
							cockpitControls.TryGetValue(attachedRigidbody, out value);
						}
						break;
					}
					attachedRigidbody = array[j].attachedRigidbody;
					if (attachedRigidbody != null)
					{
						cockpitControls.TryGetValue(attachedRigidbody, out value);
					}
				}
				if (_currentGripTarget != null)
				{
					break;
				}
			}
			if (value != null)
			{
				_isGripped = true;
				_currentControl = value;
				_currentGrip = value.GripStart(CurrentPose, base.SendHaptic);
			}
			if (_currentGripTarget != null)
			{
				_isPosed = true;
				poseManager.SetCustomGripPose(_currentGripTarget.Pose);
			}
			if (!_isGripped && !_isPosed)
			{
				GrippingAir = true;
				XRVirtualInputDevice.UpdateGrip(base.HandType, _airGripType);
			}
		}

		private void GripStop()
		{
			if (_isGripped)
			{
				_isGripped = false;
				if (_currentControl != null)
				{
					_currentControl.GripEnd(_currentGrip);
				}
				_currentGrip = null;
				_currentControl = null;
			}
			if (_isPosed)
			{
				_isPosed = false;
				poseManager.SetCustomGripPose(null);
			}
			if (_currentGripTarget != null)
			{
				_currentGripTarget.OnGripDetached(this);
				_currentGripTarget = null;
			}
			GrippingAir = false;
			XRVirtualInputDevice.UpdateGrip(base.HandType, XRControlGripType.Default);
		}

		private void OnGripActionMethodEnd(bool previouslyGripToggled)
		{
			bool gripToggled = GripToggled;
			if (gripToggled != previouslyGripToggled)
			{
				_handPoseManager.GripOverride = (gripToggled ? new float?(1f) : ((float?)null));
				_handPoseManager.OverridePoint = (gripToggled ? new float?(0f) : ((float?)null));
			}
		}

		private bool OnGripActionMethodStart()
		{
			return GripToggled;
		}

		private void OnGripCanceled(InputAction.CallbackContext context)
		{
		}

		private void OnGripPressed(InputAction.CallbackContext context)
		{
			bool previouslyGripToggled = OnGripActionMethodStart();
			GripPhysicallyPressed = true;
			BoolSetting xRGripToggleEnabled = Game.Instance.Settings.Gameplay.Flight.XRGripToggleEnabled;
			if (!xRGripToggleEnabled || Time.frameCount - _gripStateChangedFrameCount > 2)
			{
				if (_gripPressed)
				{
					if ((bool)xRGripToggleEnabled)
					{
						_gripPressed = false;
						_gripStateChangedFrameCount = Time.frameCount;
						GripStop();
					}
				}
				else
				{
					_gripPressed = true;
					_gripStateChangedFrameCount = Time.frameCount;
					if (_isGripped || _isPosed)
					{
						GripStop();
					}
					else if (GrippingAir)
					{
						GrippingAir = false;
						XRVirtualInputDevice.UpdateGrip(base.HandType, XRControlGripType.Default);
					}
					else
					{
						GripStart();
					}
				}
			}
			OnGripActionMethodEnd(previouslyGripToggled);
		}

		private void OnGripReleased(InputAction.CallbackContext context)
		{
			bool previouslyGripToggled = OnGripActionMethodStart();
			GripPhysicallyPressed = false;
			if (!Game.Instance.Settings.Gameplay.Flight.XRGripToggleEnabled)
			{
				_gripPressed = false;
				_gripStateChangedFrameCount = Time.frameCount;
				if (_isGripped || _isPosed)
				{
					GripStop();
				}
				else if (GrippingAir)
				{
					GrippingAir = false;
					XRVirtualInputDevice.UpdateGrip(base.HandType, XRControlGripType.Default);
				}
			}
			OnGripActionMethodEnd(previouslyGripToggled);
		}

		private void OnSwitchingToNewViewMode(CameraController oldController, CameraController newController)
		{
			GripStop();
		}

		private void SetHoveredModifier(IInteractablePartModifier interactablePart)
		{
			if (_hoveredModifier != interactablePart)
			{
				if (_partTooltip.Visible)
				{
					_partTooltip.HideTooltip();
				}
				if (_hoveredModifier != null)
				{
					_hoveredModifier.IsOutlined = false;
				}
				if (interactablePart != null)
				{
					interactablePart.IsOutlined = true;
				}
			}
			_hoveredModifier = interactablePart;
		}

		private void UpdateTooltip()
		{
			if (_capturedInputModifier != null || _isGripped || GrippingAir)
			{
				SetHoveredModifier(null);
				return;
			}
			IInteractablePartModifier interactablePart = GetInteractablePart();
			if (interactablePart != null && interactablePart == _hoveredModifier)
			{
				_hoveredModifierElapsedTime += Time.unscaledDeltaTime;
			}
			else
			{
				_hoveredModifierElapsedTime = Mathf.Max(0f, Mathf.Min(0.5f, _hoveredModifierElapsedTime) - Time.unscaledDeltaTime);
			}
			SetHoveredModifier(interactablePart);
			if (_hoveredModifier == null || !(_hoveredModifierElapsedTime >= 0.5f))
			{
				return;
			}
			string text = _hoveredModifier.OnHover();
			if (!_partTooltip.Visible)
			{
				PartTooltipPosition tooltipPosition = interactablePart.GetTooltipPosition();
				if ((object)tooltipPosition.TargetRenderer == null)
				{
					_partTooltip.ShowTooltip(text, _mainCamera, tooltipPosition.TargetTransform, Vector3.up, tooltipPosition.OffsetDistance);
				}
				else
				{
					_partTooltip.ShowTooltip(text, _mainCamera, tooltipPosition.TargetRenderer, Vector3.up, tooltipPosition.OffsetDistance);
				}
			}
			else
			{
				_partTooltip.Text = text;
			}
		}
	}
}
