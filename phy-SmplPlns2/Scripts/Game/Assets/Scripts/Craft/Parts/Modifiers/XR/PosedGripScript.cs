using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Input.Events;
using Assets.Scripts.Input.XR;
using Assets.Scripts.XR;
using Assets.Scripts.XR.HandPoses;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.XR;

namespace Assets.Scripts.Craft.Parts.Modifiers.XR
{
	public class PosedGripScript : PartModifierScript, IGripTarget, IInteractablePartModifier
	{
		private struct BindingOverride
		{
			public int ControlBindingIndex { get; }

			public int ModifierBindingIndex { get; }

			public BindingOverride(int modifierBindingIndex, int controlBindingIndex)
			{
				ModifierBindingIndex = modifierBindingIndex;
				ControlBindingIndex = controlBindingIndex;
			}
		}

		public class BoundControl
		{
			private InputAction _action;

			private bool _activated;

			private PosedGripData.GripControlBinding _binding;

			private AircraftControls _controls;

			private bool _hasBinding;

			private AircraftControls.InputOverride _override;

			private PosedGripScript _script;

			public BoundControl(PosedGripData.GripControlBinding binding, PosedGripScript script)
			{
				_binding = binding;
				_controls = script.Controls;
				_script = script;
				_hasBinding = !_binding.IsDisabled;
				if (_hasBinding)
				{
					_action = new InputAction(null, InputActionType.Value, null, null, binding.Processor);
					_action.performed += ActionUpdate;
					_action.started += ActionUpdate;
					_action.canceled += ActionUpdate;
					_override = new AircraftControls.InputOverride
					{
						Active = false
					};
					_controls.AddRawOverrideInput(_binding.AircraftControl, _override);
				}
			}

			public void Activate(XRController controller)
			{
				if (!_activated)
				{
					_activated = true;
					InputControl inputControl = controller.TryGetChildControl(_binding.ControlPath);
					if (inputControl != null)
					{
						if (_hasBinding)
						{
							if (_action.bindings.Count == 0)
							{
								_action.AddBinding(new InputBinding(inputControl.path));
							}
							else
							{
								_action.ChangeBinding(0).To(new InputBinding(inputControl.path));
							}
							_action.Enable();
							_override.Value = _action.ReadValue<float>();
						}
						InputActionMap actionMap = XRInputs.Flight.ActionMap;
						ReadOnlyArray<InputBinding> bindings = actionMap.bindings;
						foreach (BindingOverride potentialBindingOverride in _script._potentialBindingOverrides)
						{
							if (InputControlPath.TryFindControl(controller, bindings[potentialBindingOverride.ControlBindingIndex].effectivePath) == inputControl)
							{
								InputBinding binding = bindings[potentialBindingOverride.ModifierBindingIndex];
								binding.overridePath = "Disabled";
								actionMap.ChangeBinding(potentialBindingOverride.ModifierBindingIndex).To(binding);
								_script._activeBindingOverrides.Add(potentialBindingOverride);
							}
						}
					}
				}
				if (_hasBinding)
				{
					_override.Active = !_binding.AsButton;
				}
			}

			public void Deactivate()
			{
				if (_activated)
				{
					_activated = false;
					if (_hasBinding)
					{
						_action?.Disable();
					}
				}
				if (_hasBinding)
				{
					_override.Active = false;
				}
			}

			public void Dispose()
			{
				Deactivate();
				if (_hasBinding)
				{
					_action.Dispose();
					_controls.RemoveRawOverrideInput(_binding.AircraftControl, _override);
				}
			}

			private void ActionUpdate(InputAction.CallbackContext obj)
			{
				if (_binding.AsButton)
				{
					_override.Value = 1f;
					_override.Active = obj.ReadValueAsButton();
				}
				else
				{
					_override.Value = obj.ReadValue<float>();
					_override.Active = !obj.canceled;
				}
			}
		}

		private const string LeftPreviewResource = "XR/OculusHands/PreviewHandLeft";

		private const string RightPreviewResource = "XR/OculusHands/PreviewHandRight";

		private static List<HandPoseManager> _designerPreviewHandsLeft = new List<HandPoseManager>();

		private static List<HandPoseManager> _designerPreviewHandsRight = new List<HandPoseManager>();

		private List<BindingOverride> _activeBindingOverrides;

		private BoundControl[] _boundControls = new BoundControl[0];

		private List<FlightHand> _currentHands = new List<FlightHand>();

		private ControlBaseScript _currentMouseGripControlBaseScript;

		private PosedGripInteractableCollider _interactableCollider;

		private HandPoseManager _myPreviewHand;

		private List<BindingOverride> _potentialBindingOverrides;

		private bool _selected;

		private bool _targetedByBiped;

		private Transform _tooltipPositionTransform;

		public static Dictionary<Collider, IGripTarget> ColliderLookup { get; private set; } = new Dictionary<Collider, IGripTarget>();

		public Collider[] Colliders { get; set; }

		public XRControlGripType GripType => Modifier.GripType;

		public bool InteractionDisabled
		{
			get
			{
				if (!Modifier.HasScreenAxisMap)
				{
					return !XRCameraManagerScript.Instance.XrCamerasEnabled;
				}
				return false;
			}
		}

		public bool IsGripped
		{
			get
			{
				if (!(_currentMouseGripControlBaseScript != null))
				{
					return _currentHands.Count > 0;
				}
				return true;
			}
		}

		public bool IsOutlined
		{
			get
			{
				return base.PartScript.PartMaterialScript.IsOutlined;
			}
			set
			{
				base.PartScript.PartMaterialScript.IsOutlined = value;
			}
		}

		public PosedGripData Modifier { get; set; }

		public GripPose Pose { get; set; }

		public bool SnapHandPositionToTarget => true;

		public bool SnapHandRotationToTarget => true;

		public Transform TargetTransform { get; set; }

		public ControlBaseScript GetControlBase()
		{
			ControlBaseScript value = base.PartScript.GetModifier<ControlBaseScript>();
			if ((object)value == null)
			{
				Rigidbody physxRigidBody = base.PartScript.Body.RigidBody.PhysxRigidBody;
				FlightXRRigManager.Instance.CockpitControls.TryGetValue(physxRigidBody, out value);
			}
			return value;
		}

		public string GetOverrideControlBinding(string controlId)
		{
			PosedGripData.GripControlBinding[] controlBindings = Modifier.ControlBindings;
			foreach (PosedGripData.GripControlBinding gripControlBinding in controlBindings)
			{
				if (gripControlBinding.ControlPath == controlId)
				{
					if (gripControlBinding.IsDefault)
					{
						return null;
					}
					if (gripControlBinding.IsDisabled)
					{
						return "Disabled";
					}
					if (gripControlBinding.IsValid)
					{
						return gripControlBinding.AircraftControl;
					}
				}
			}
			return null;
		}

		public PartTooltipPosition GetTooltipPosition()
		{
			if (!(_interactableCollider == null))
			{
				return new PartTooltipPosition(_tooltipPositionTransform, Modifier.TooltipOffset);
			}
			return default(PartTooltipPosition);
		}

		public bool HandleInput(IInputEvent e, bool isPartStillTarget)
		{
			if (!(e is InputEvent inputEvent))
			{
				return false;
			}
			if (!Modifier.HasScreenAxisMap)
			{
				return false;
			}
			if (e.InputState == InputState.Begin)
			{
				ControlBaseScript controlBase = GetControlBase();
				if (controlBase == null)
				{
					return false;
				}
				_currentMouseGripControlBaseScript = controlBase;
				controlBase.MouseGripStart();
			}
			else if (e.InputState == InputState.Updated)
			{
				Vector2 vector = new Vector2(Screen.width, Screen.height);
				Vector2 vector2 = new Vector2(vector.x * Modifier.ScreenAxisDeadzone.x, vector.y * Modifier.ScreenAxisDeadzone.y);
				Vector2 vector3 = new Vector2(vector.x * Modifier.ScreenAxisSize.x, vector.y * Modifier.ScreenAxisSize.y) - vector2;
				Vector2 deltaPositionSinceBegin = inputEvent.DeltaPositionSinceBegin;
				Vector2 vector4 = new Vector2(Mathf.Max(0f, Mathf.Abs(deltaPositionSinceBegin.x) - vector2.x) / vector3.x * Mathf.Sign(deltaPositionSinceBegin.x), Mathf.Max(0f, Mathf.Abs(deltaPositionSinceBegin.y) - vector2.y) / vector3.y * Mathf.Sign(deltaPositionSinceBegin.y));
				Vector3 positionAxisDelta = Modifier.ScreenXPositionAxisMap * vector4.x + Modifier.ScreenYPositionAxisMap * vector4.y;
				Vector3 rotationAxisDelta = Modifier.ScreenXRotationAxisMap * vector4.x + Modifier.ScreenYRotationAxisMap * vector4.y;
				_currentMouseGripControlBaseScript.MouseGripUpdate(positionAxisDelta, rotationAxisDelta);
			}
			else if (e.InputState == InputState.End)
			{
				_currentMouseGripControlBaseScript.MouseGripEnd();
				_currentMouseGripControlBaseScript = null;
			}
			return true;
		}

		public void Initialize(PosedGripData posedGrip)
		{
			Modifier = posedGrip;
			if (!string.IsNullOrWhiteSpace(posedGrip.PoseName))
			{
				GripPose pose = Resources.Load<GripPose>("XR/CustomAnimations/" + posedGrip.PoseName);
				Pose = pose;
			}
			TargetTransform = base.transform;
			_interactableCollider = TargetTransform.GetComponentInChildren<PosedGripInteractableCollider>();
			if (_interactableCollider != null)
			{
				_tooltipPositionTransform = (string.IsNullOrWhiteSpace(Modifier.TooltipTransformPath) ? _interactableCollider.transform : base.PartScript.transform.Find(Modifier.TooltipTransformPath));
				base.PartScript.PartMaterialScript.OutlineScale = Modifier.OutlineScale;
			}
			Collider[] array = (Colliders = new Collider[posedGrip.ColliderPaths.Length]);
			Collider[] array3 = array;
			for (int i = 0; i < posedGrip.ColliderPaths.Length; i++)
			{
				array3[i] = base.PartScript.gameObject.transform.Find(posedGrip.ColliderPaths[i])?.GetComponent<Collider>();
				if (array3[i] == null)
				{
					Debug.LogWarning("Collider not found on posed grip: " + posedGrip.ColliderPaths[i]);
				}
			}
			InitializePotentialBindingOverrides();
			PosedGripData.GripControlBinding[] controlBindings = posedGrip.ControlBindings;
			int num = 0;
			for (int j = 0; j < controlBindings.Length; j++)
			{
				if (controlBindings[j].IsValid && !controlBindings[j].IsDefault)
				{
					num++;
				}
			}
			BoundControl[] array4 = new BoundControl[num];
			int num2 = 0;
			for (int k = 0; k < controlBindings.Length; k++)
			{
				if (controlBindings[k].IsValid && !controlBindings[k].IsDefault)
				{
					array4[num2++] = new BoundControl(controlBindings[k], this);
				}
			}
			_boundControls = array4;
		}

		public void OnGripAttached(FlightHand hand)
		{
			_currentHands.Add(hand);
			for (int i = 0; i < _boundControls.Length; i++)
			{
				_boundControls[i].Activate(hand.Controller);
			}
		}

		public void OnGripDetached(FlightHand hand)
		{
			int num = _currentHands.IndexOf(hand);
			if (num != -1)
			{
				_currentHands.RemoveAt(num);
			}
			ClearBindingOverrides();
			for (int i = 0; i < _boundControls.Length; i++)
			{
				_boundControls[i].Deactivate();
			}
		}

		public void OnGripUpdate(FlightHand hand)
		{
		}

		public string OnHover()
		{
			return Modifier.Tooltip;
		}

		public void OnTargeted(FullBodyBipedIK bipedIk)
		{
			_targetedByBiped = bipedIk != null;
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				if (Designer.Instance != null)
				{
					Designer.Instance.SelectedPartChangedEvent -= OnSelectedPartChanged;
				}
				OnDeselectedInDesigner();
			}
			else
			{
				if (base.LoadContext != CraftLoadContext.Flight)
				{
					return;
				}
				KeyValuePair<Collider, IGripTarget>[] array = ColliderLookup.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Value as PosedGripScript == this)
					{
						ColliderLookup.Remove(array[i].Key);
					}
				}
				ClearBindingOverrides();
				for (int j = 0; j < _boundControls.Length; j++)
				{
					_boundControls[j].Dispose();
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdateDesigner, CraftUpdateFlags.DesignerDefault);
		}

		protected virtual IEnumerator Start()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Designer.Instance.SelectedPartChangedEvent += OnSelectedPartChanged;
				OnSelectedPartChanged(Designer.Instance.SelectedPart);
			}
			else
			{
				if (base.LoadContext != CraftLoadContext.Flight)
				{
					yield break;
				}
				for (int i = 0; i < Colliders.Length; i++)
				{
					if (Colliders[i] != null)
					{
						ColliderLookup.Add(Colliders[i], this);
					}
				}
				base.PartScript.Aircraft.FastTouchdown += Aircraft_FastTouchdown;
				yield return null;
				if (_interactableCollider != null)
				{
					_interactableCollider.gameObject.layer = 16;
				}
			}
		}

		private void Aircraft_FastTouchdown(float overStress)
		{
			if (!base.PartScript.ConnectedToMainCockpit || _currentHands.Count <= 0)
			{
				return;
			}
			float amplitude = Mathf.Lerp(0.5f, 1f, overStress);
			float duration = Mathf.Lerp(0.15f, 0.18f, overStress);
			foreach (FlightHand currentHand in _currentHands)
			{
				currentHand.SendHaptic(amplitude, duration);
			}
		}

		private void ClearBindingOverrides()
		{
			InputActionMap actionMap = XRInputs.Flight.ActionMap;
			ReadOnlyArray<InputBinding> bindings = actionMap.bindings;
			foreach (BindingOverride activeBindingOverride in _activeBindingOverrides)
			{
				InputBinding binding = bindings[activeBindingOverride.ModifierBindingIndex];
				binding.overridePath = null;
				actionMap.ChangeBinding(activeBindingOverride.ModifierBindingIndex).To(binding);
			}
			_activeBindingOverrides.Clear();
		}

		private void InitializePotentialBindingOverrides()
		{
			_activeBindingOverrides = new List<BindingOverride>();
			_potentialBindingOverrides = new List<BindingOverride>();
			if (!Game.Instance.Device.IsVRBuild)
			{
				return;
			}
			ButtonControl control = XRVirtualInputDevice.Current.GetControl(XRHandType.Left, Modifier.GripType);
			ButtonControl control2 = XRVirtualInputDevice.Current.GetControl(XRHandType.Right, Modifier.GripType);
			ReadOnlyArray<InputBinding> bindings = XRInputs.Flight.ActionMap.bindings;
			int count = bindings.Count;
			for (int i = 0; i < count; i++)
			{
				if (!bindings[i].isComposite || i + 2 >= count)
				{
					continue;
				}
				int num = i + 1;
				int num2 = i + 2;
				InputBinding inputBinding = bindings[num];
				InputBinding inputBinding2 = bindings[num2];
				if (!inputBinding.isPartOfComposite || !inputBinding2.isPartOfComposite)
				{
					continue;
				}
				if (inputBinding.name == "modifier")
				{
					InputControl inputControl = InputControlPath.TryFindControl(XRVirtualInputDevice.Current, inputBinding.path);
					if (inputControl == control || inputControl == control2)
					{
						_potentialBindingOverrides.Add(new BindingOverride(num, num2));
					}
				}
				else if (inputBinding2.name == "modifier")
				{
					InputControl inputControl2 = InputControlPath.TryFindControl(XRVirtualInputDevice.Current, inputBinding2.path);
					if (inputControl2 == control || inputControl2 == control2)
					{
						_potentialBindingOverrides.Add(new BindingOverride(num2, num));
					}
				}
			}
		}

		private void OnDeselectedInDesigner()
		{
			if (_myPreviewHand != null)
			{
				_myPreviewHand.gameObject.SetActive(value: false);
				_myPreviewHand = null;
			}
		}

		private void OnSelectedInDesigner()
		{
			PosedGripData.PreviewHand previewPose = Modifier.PreviewPose;
			if (previewPose == PosedGripData.PreviewHand.None || _targetedByBiped)
			{
				return;
			}
			if (_myPreviewHand == null)
			{
				List<HandPoseManager> list = ((previewPose == PosedGripData.PreviewHand.Left) ? _designerPreviewHandsLeft : _designerPreviewHandsRight);
				HandPoseManager[] array = list.ToArray();
				foreach (HandPoseManager handPoseManager in array)
				{
					if (handPoseManager == null)
					{
						list.Remove(handPoseManager);
					}
					else if (!handPoseManager.gameObject.activeSelf)
					{
						_myPreviewHand = handPoseManager;
						_myPreviewHand.gameObject.SetActive(value: true);
						break;
					}
				}
				if (_myPreviewHand == null)
				{
					string path = ((previewPose == PosedGripData.PreviewHand.Left) ? "XR/OculusHands/PreviewHandLeft" : "XR/OculusHands/PreviewHandRight");
					_myPreviewHand = Object.Instantiate(Resources.Load<GameObject>(path)).GetComponent<HandPoseManager>();
					_myPreviewHand.EnableInputs = false;
					list.Add(_myPreviewHand);
				}
			}
			if (_myPreviewHand != null)
			{
				_myPreviewHand.SetCustomGripPose(Pose);
				UpdatePreviewHandPosition();
			}
		}

		private void OnSelectedPartChanged(PartScript newPart)
		{
			bool flag = newPart == base.PartScript;
			if (flag != _selected)
			{
				_selected = flag;
				if (flag)
				{
					OnSelectedInDesigner();
				}
				else
				{
					OnDeselectedInDesigner();
				}
			}
		}

		private void OnUpdateDesigner(in CraftUpdateFrameData frame)
		{
			if (_myPreviewHand != null)
			{
				UpdatePreviewHandPosition();
			}
		}

		private void UpdatePreviewHandPosition()
		{
			_myPreviewHand.transform.SetPositionAndRotation(TargetTransform.TransformDirection(_myPreviewHand.CurrentGripOffset.position) + TargetTransform.position, TargetTransform.rotation * _myPreviewHand.CurrentGripOffset.rotation);
		}
	}
}
