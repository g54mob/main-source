using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.XR;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.XR
{
	public class ControlBaseScript : PartModifierScript, IVariableDeclarations, IVariableOutput
	{
		public delegate void HapticEvent(float amplitude, float duration);

		public class AttachedHand
		{
			public Pose current;

			public HapticEvent HapticCallback;

			public Pose initial;

			public Pose initialControlPose;

			public Pose initialLocal;

			public AttachedHand parentHand;

			public bool Dead { get; set; }

			public AttachedHand(Pose initial, Pose initialControlPose)
			{
				this.initial = initial;
				current = initial;
				this.initialControlPose = initialControlPose;
				initialLocal = this.initialControlPose.InverseTransformPose(initial);
			}
		}

		public class ControlAxis
		{
			[DesignerPropertyTextSpinner(new string[] { "X", "-X", "Y", "-Y", "Z", "-Z" }, Label = "Axis", Order = 20)]
			private Vector3 _axis;

			private bool _failed;

			[DesignerPropertyTextSpinner(new string[] { }, AllowManualEntry = true, ExtraWidth = 75, ShrinkText = true, WrapText = true, Label = "Input", Order = 10)]
			private string _input;

			[DesignerPropertySpinner(-1000000.0, 1000000.0, 0.05, AllowManualEntry = true, Label = "Max Value", Order = 40)]
			private float _maxValue;

			[DesignerPropertySpinner(-1000000.0, 1000000.0, 0.05, AllowManualEntry = true, Label = "Min Value", Order = 30)]
			private float _minValue;

			[DesignerPropertySpinner(-1000000.0, 1000000.0, 0.05, AllowManualEntry = true, Label = "Multiplier", Order = 50)]
			private float _multiplier;

			[DesignerPropertySpinner(-1000000.0, 1000000.0, 0.01, AllowManualEntry = true, Label = "Rotation Max", Order = 60)]
			private float _rotationMaxDistance;

			private int _varPriority;

			public Vector3 Axis
			{
				get
				{
					return _axis;
				}
				set
				{
					_axis = value;
				}
			}

			public Func<float> GetInput { get; set; }

			public string InputName
			{
				get
				{
					return _input;
				}
				set
				{
					_input = value;
				}
			}

			public bool IsValid
			{
				get
				{
					if (!_failed && !string.IsNullOrWhiteSpace(_input) && _input != "Disabled")
					{
						return _multiplier != 0f;
					}
					return false;
				}
			}

			public double LastLimitChangeTime { get; set; } = -1.0;

			public float MaxValue
			{
				get
				{
					return _maxValue;
				}
				set
				{
					_maxValue = value;
				}
			}

			public float MinValue
			{
				get
				{
					return _minValue;
				}
				set
				{
					_minValue = value;
				}
			}

			public float Multiplier
			{
				get
				{
					return _multiplier;
				}
				set
				{
					_multiplier = value;
				}
			}

			public AircraftControls.InputOverride Override { get; set; }

			public float RotationMaxDistance
			{
				get
				{
					return _rotationMaxDistance;
				}
				set
				{
					_rotationMaxDistance = value;
				}
			}

			public Action<float> Setter { get; set; }

			public float Value => GetInput() * Multiplier;

			public float ValueClamped => Mathf.Clamp(GetInput(), MinValue, MaxValue) * Multiplier;

			public AircraftVariable Variable { get; set; }

			public bool WasBeyondLimit { get; set; }

			public bool InitIO(AircraftScript aircraft)
			{
				Match match;
				if ((match = Regex.Match(InputName, "Activate([1-8])")).Success)
				{
					int x = int.Parse(match.Groups[1].Value);
					GetInput = () => (!aircraft.Controls.GetActivationState(x)) ? (-1f) : 1f;
					Setter = delegate(float v)
					{
						if (aircraft.Controls.GetActivationState(x) != v > 0f)
						{
							aircraft.Controls.ActivateGroup(x - 1);
						}
					};
					return true;
				}
				if (InputName == "LandingGear")
				{
					GetInput = () => (!aircraft.Controls.LandingGearDown) ? 1f : (-1f);
					Setter = delegate(float v)
					{
						aircraft.Controls.SetLandingGearDown(v <= 0f);
					};
					return true;
				}
				Func<float> axisGetter = aircraft.Controls.GetAxisGetter(InputName, -1f, null, returnNull: true);
				if (axisGetter != null)
				{
					GetInput = axisGetter;
					Override = new AircraftControls.InputOverride();
				}
				else
				{
					try
					{
						string text = InputName;
						int num = text.IndexOf(":");
						if (num != -1)
						{
							_varPriority = int.Parse(text.Substring(num + 1));
							text = text.Substring(0, num);
						}
						Variable = aircraft.VariableSystem.AddVariable(text);
						GetInput = () => Variable.Value;
					}
					catch (Exception ex)
					{
						Debug.LogWarning("Control axis error for '" + InputName + "': " + ex.Message);
						_failed = true;
						return false;
					}
				}
				return true;
			}

			public void SetValue(float value)
			{
				if (Setter != null)
				{
					Setter(value);
				}
				else if (Override != null)
				{
					Override.Value = value;
				}
				else if (Variable != null)
				{
					Variable.SetValue(value, _varPriority);
				}
			}
		}

		private static readonly Quaternion OrthoX = Quaternion.AngleAxis(90f, Vector3.right);

		private static readonly Quaternion OrthoY = Quaternion.AngleAxis(90f, Vector3.up);

		private List<AttachedHand> _attachedHands = new List<AttachedHand>();

		private BodyJoint _bodyJoint;

		private Rigidbody _controlRigidbody;

		private Quaternion _inverseJointRotationOffset;

		private bool _isEnabled;

		private bool _isMouseAttached;

		private bool _isSixDoF;

		private ConfigurableJoint _joint;

		private float[] _mouseGripInitialPositionAxisValues;

		private float[] _mouseGripInitialRotationAxisValues;

		private Vector3 _mouseGripPositionAxisDelta;

		private Vector3 _mouseGripRotationAxisDelta;

		private ControlBaseScript _parentControl;

		private bool _parentControlChecked;

		private ControlAxis[] _positionAxes;

		private ControlAxis[] _rotationAxes;

		private Transform _targetTransform;

		public ControlBaseData ControlBase { get; private set; }

		private Pose CurrentBodyPose
		{
			get
			{
				if (ControlBase.Mode == ControlBaseData.ControlMode.Joint)
				{
					return new Pose(_joint.transform.InverseTransformPoint(_joint.connectedBody.transform.TransformPoint(_joint.connectedAnchor)) - _joint.anchor, _inverseJointRotationOffset * Quaternion.Inverse(_joint.transform.rotation) * _joint.connectedBody.transform.rotation);
				}
				return TargetPose;
			}
		}

		private Transform ReferenceTransform { get; set; }

		private Pose TargetPose
		{
			get
			{
				if (ControlBase.Mode == ControlBaseData.ControlMode.Joint)
				{
					return new Pose(_joint.targetPosition, _joint.targetRotation);
				}
				return new Pose(_targetTransform.localPosition, _targetTransform.localRotation);
			}
			set
			{
				if (ControlBase.Mode == ControlBaseData.ControlMode.Joint)
				{
					_joint.targetPosition = value.position;
					_joint.targetRotation = value.rotation;
				}
				else
				{
					_targetTransform.localPosition = value.position;
					_targetTransform.localRotation = value.rotation;
				}
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(OnPreStartLayerUpdates, PreStartInitializationFlags.FlightDefault, 600);
		}

		IEnumerator<string> IVariableDeclarations.GetVariableOutputs()
		{
			ControlAxis[] positionAxes = _positionAxes;
			foreach (ControlAxis controlAxis in positionAxes)
			{
				if (controlAxis.Variable != null)
				{
					yield return controlAxis.Variable.Name;
				}
			}
			positionAxes = _rotationAxes;
			foreach (ControlAxis controlAxis2 in positionAxes)
			{
				if (controlAxis2.Variable != null)
				{
					yield return controlAxis2.Variable.Name;
				}
			}
		}

		public void GripEnd(AttachedHand hand)
		{
			_attachedHands.Remove(hand);
			if (_parentControl != null && hand.parentHand != null)
			{
				_parentControl.GripEnd(hand.parentHand);
				hand.parentHand = null;
			}
			if (_attachedHands.Count != 0)
			{
				return;
			}
			AircraftControls controls = base.Controls;
			for (int i = 0; i < _positionAxes.Length; i++)
			{
				if (_positionAxes[i].Override != null)
				{
					controls.RemoveRawOverrideInput(_positionAxes[i].InputName, _positionAxes[i].Override);
				}
			}
			for (int j = 0; j < _rotationAxes.Length; j++)
			{
				if (_rotationAxes[j].Override != null)
				{
					controls.RemoveRawOverrideInput(_rotationAxes[j].InputName, _rotationAxes[j].Override);
				}
			}
		}

		public AttachedHand GripStart(Pose worldPose, HapticEvent haptic)
		{
			AttachedHand attachedHand = new AttachedHand(WorldToLocalPose(worldPose), TargetPose)
			{
				HapticCallback = (ControlBase.Haptics ? haptic : null)
			};
			_attachedHands.Add(attachedHand);
			if (_attachedHands.Count == 1)
			{
				AircraftControls controls = base.Controls;
				for (int i = 0; i < _positionAxes.Length; i++)
				{
					if (_positionAxes[i].Override != null)
					{
						controls.AddRawOverrideInput(_positionAxes[i].InputName, _positionAxes[i].Override);
					}
				}
				for (int j = 0; j < _rotationAxes.Length; j++)
				{
					if (_rotationAxes[j].Override != null)
					{
						controls.AddRawOverrideInput(_rotationAxes[j].InputName, _rotationAxes[j].Override);
					}
				}
			}
			if (_parentControl != null)
			{
				attachedHand.parentHand = _parentControl.GripStart(worldPose, haptic);
			}
			return attachedHand;
		}

		public void GripUpdate(AttachedHand hand, Pose worldPose)
		{
			if ((ControlBase.Mode == ControlBaseData.ControlMode.Joint && _joint == null) || (ControlBase.Mode == ControlBaseData.ControlMode.Transform && _targetTransform == null))
			{
				hand.Dead = true;
				return;
			}
			hand.current = WorldToLocalPose(worldPose);
			if (_parentControl != null && hand.parentHand != null)
			{
				Pose pose = hand.current;
				pose.InverseTransformBy(TargetPose);
				_parentControl.GripUpdate(hand.parentHand, LocalToWorldPose(pose));
			}
		}

		public void Initialize(ControlBaseData controlBase)
		{
			ControlBase = controlBase;
			_positionAxes = GetValidControls(controlBase.MovementAxes);
			_rotationAxes = GetValidControls(controlBase.RotationAxes);
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				return;
			}
			for (int i = 0; i < _positionAxes.Length; i++)
			{
				if (ControlBase.Mode == ControlBaseData.ControlMode.Joint)
				{
					_positionAxes[i].Axis = base.PartScript.transform.localRotation * _positionAxes[i].Axis;
				}
			}
			for (int j = 0; j < _rotationAxes.Length; j++)
			{
				if (ControlBase.Mode == ControlBaseData.ControlMode.Joint)
				{
					_rotationAxes[j].Axis = base.PartScript.transform.localRotation * _rotationAxes[j].Axis;
				}
			}
			ControlAxis[] GetValidControls(ControlAxis[] axes)
			{
				int num = 0;
				for (int k = 0; k < axes.Length; k++)
				{
					if (axes[k].IsValid && axes[k].InitIO(base.PartScript.Aircraft))
					{
						num++;
					}
				}
				ControlAxis[] array = new ControlAxis[num];
				num = 0;
				for (int l = 0; l < axes.Length; l++)
				{
					if (axes[l].IsValid)
					{
						array[num++] = axes[l];
					}
				}
				return array;
			}
		}

		public void MouseGripEnd()
		{
			_isMouseAttached = false;
			AircraftControls controls = base.Controls;
			for (int i = 0; i < _positionAxes.Length; i++)
			{
				if (_positionAxes[i].Override != null)
				{
					controls.RemoveRawOverrideInput(_positionAxes[i].InputName, _positionAxes[i].Override);
				}
			}
			for (int j = 0; j < _rotationAxes.Length; j++)
			{
				if (_rotationAxes[j].Override != null)
				{
					controls.RemoveRawOverrideInput(_rotationAxes[j].InputName, _rotationAxes[j].Override);
				}
			}
		}

		public void MouseGripStart()
		{
			_isMouseAttached = true;
			_mouseGripPositionAxisDelta = Vector3.zero;
			_mouseGripRotationAxisDelta = Vector3.zero;
			AircraftControls controls = base.Controls;
			for (int i = 0; i < _positionAxes.Length; i++)
			{
				if (_positionAxes[i].Override != null)
				{
					controls.AddRawOverrideInput(_positionAxes[i].InputName, _positionAxes[i].Override);
				}
			}
			for (int j = 0; j < _rotationAxes.Length; j++)
			{
				if (_rotationAxes[j].Override != null)
				{
					controls.AddRawOverrideInput(_rotationAxes[j].InputName, _rotationAxes[j].Override);
				}
			}
			_mouseGripInitialRotationAxisValues = _rotationAxes.Select((ControlAxis x) => x.GetInput()).ToArray();
			_mouseGripInitialPositionAxisValues = _positionAxes.Select((ControlAxis x) => x.GetInput()).ToArray();
		}

		public void MouseGripUpdate(Vector3 positionAxisDelta, Vector3 rotationAxisDelta)
		{
			_mouseGripPositionAxisDelta = positionAxisDelta;
			_mouseGripRotationAxisDelta = rotationAxisDelta;
		}

		void IVariableOutput.UpdateOutputs()
		{
		}

		protected virtual void OnDestroy()
		{
			if (_isEnabled && ControlBase.Mode == ControlBaseData.ControlMode.Joint && FlightXRRigManager.Instance != null)
			{
				Dictionary<Rigidbody, ControlBaseScript> cockpitControls = FlightXRRigManager.Instance.CockpitControls;
				if (!cockpitControls.ContainsKey(_controlRigidbody))
				{
					Debug.LogError("Control not found to unbind on destroy");
				}
				else
				{
					cockpitControls.Remove(_controlRigidbody);
				}
				for (int i = 0; i < _attachedHands.Count; i++)
				{
					_attachedHands[i].Dead = true;
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocal);
		}

		private static float GetAngleAroundAxis(Quaternion quaternion, Vector3 axis)
		{
			Vector3 orthoVec = GetOrthoVec(axis);
			Vector3 to = Vector3.ProjectOnPlane(quaternion * orthoVec, axis);
			return Vector3.SignedAngle(orthoVec, to, axis);
		}

		private static Vector3 GetOrthoVec(Vector3 vector)
		{
			Vector3 vector2 = OrthoX * vector;
			if (Math.Abs(Vector3.Dot(vector2, vector)) > 0.6f)
			{
				return OrthoY * vector;
			}
			return vector2;
		}

		private Pose LocalToWorldPose(Pose localPose)
		{
			Pose parent = ((ControlBase.Mode != ControlBaseData.ControlMode.Joint) ? _targetTransform.parent.GetWorldPose() : new Pose(base.transform.position, _joint.transform.rotation));
			return parent.TransformPose(localPose);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			ControlBaseData.ControlMode mode = ControlBase.Mode;
			if (!_isEnabled || (mode == ControlBaseData.ControlMode.Joint && _joint == null) || (mode == ControlBaseData.ControlMode.Transform && _targetTransform == null))
			{
				return;
			}
			if (!_parentControlChecked)
			{
				_parentControlChecked = true;
				FlightXRRigManager.Instance.CockpitControls.TryGetValue(base.PartScript.Body.RigidBody.PhysxRigidBody, out _parentControl);
			}
			Vector3 targetPosition = default(Vector3);
			Quaternion quaternion = Quaternion.identity;
			if (_isMouseAttached)
			{
				targetPosition = Vector3.zero;
				quaternion = Quaternion.identity;
				for (int i = 0; i < _positionAxes.Length; i++)
				{
					ControlAxis controlAxis = _positionAxes[i];
					float num = Vector3.Dot(controlAxis.Axis, _mouseGripPositionAxisDelta);
					float num2 = Mathf.Clamp(_mouseGripInitialPositionAxisValues[i] + num, controlAxis.MinValue, controlAxis.MaxValue);
					controlAxis.SetValue(num2);
					targetPosition += controlAxis.Axis * (controlAxis.Multiplier * num2);
				}
				for (int j = 0; j < _rotationAxes.Length; j++)
				{
					ControlAxis controlAxis2 = _rotationAxes[j];
					float num3 = Vector3.Dot(controlAxis2.Axis, _mouseGripRotationAxisDelta);
					float num4 = Mathf.Clamp(_mouseGripInitialRotationAxisValues[j] + num3, controlAxis2.MinValue, controlAxis2.MaxValue);
					controlAxis2.SetValue(num4);
					Quaternion quaternion2 = Quaternion.AngleAxis(num4 * controlAxis2.Multiplier, controlAxis2.Axis);
					quaternion *= quaternion2;
				}
			}
			else if (_attachedHands.Count == 0)
			{
				targetPosition = Vector3.zero;
				for (int k = 0; k < _positionAxes.Length; k++)
				{
					ControlAxis controlAxis3 = _positionAxes[k];
					targetPosition += controlAxis3.Axis * controlAxis3.ValueClamped;
				}
				quaternion = Quaternion.identity;
				for (int l = 0; l < _rotationAxes.Length; l++)
				{
					ControlAxis controlAxis4 = _rotationAxes[l];
					quaternion *= Quaternion.AngleAxis(controlAxis4.ValueClamped, controlAxis4.Axis);
				}
			}
			else if (_isSixDoF)
			{
				int count = _attachedHands.Count;
				targetPosition = default(Vector3);
				AttachedHand attachedHand = _attachedHands[0];
				if (count == 1)
				{
					Quaternion quaternion3 = attachedHand.current.rotation * Quaternion.Inverse(attachedHand.initialLocal.rotation);
					for (int m = 0; m < _rotationAxes.Length; m++)
					{
						ControlAxis controlAxis5 = _rotationAxes[m];
						float angleAroundAxis = GetAngleAroundAxis(quaternion3, controlAxis5.Axis);
						angleAroundAxis = Mathf.Clamp(angleAroundAxis, controlAxis5.MinValue * controlAxis5.Multiplier, controlAxis5.MaxValue * controlAxis5.Multiplier);
						controlAxis5.SetValue(angleAroundAxis / controlAxis5.Multiplier);
						Quaternion quaternion4 = Quaternion.AngleAxis(angleAroundAxis, controlAxis5.Axis);
						quaternion *= quaternion4;
						quaternion3 = Quaternion.Inverse(quaternion4) * quaternion3;
					}
					targetPosition = attachedHand.current.position - quaternion * attachedHand.initialLocal.position;
				}
				else
				{
					if (count > 2)
					{
						Debug.Log($"{count} hands? huh?");
					}
					AttachedHand attachedHand2 = _attachedHands[1];
					Quaternion a = attachedHand.current.rotation * Quaternion.Inverse(attachedHand.initialLocal.rotation);
					Quaternion b = attachedHand2.current.rotation * Quaternion.Inverse(attachedHand2.initialLocal.rotation);
					Quaternion quaternion5 = Quaternion.Lerp(a, b, 0.5f);
					Vector3 toDirection = attachedHand2.current.position - attachedHand.current.position;
					Vector3 fromDirection = quaternion5 * (attachedHand2.initialLocal.position - attachedHand.initialLocal.position);
					Quaternion quaternion6 = Quaternion.FromToRotation(fromDirection, toDirection);
					float num5 = Mathf.Sqrt(Mathf.Min(toDirection.sqrMagnitude, fromDirection.sqrMagnitude));
					float num6 = 0f;
					for (int n = 0; n < _rotationAxes.Length; n++)
					{
						num6 += _rotationAxes[n].RotationMaxDistance;
					}
					num6 /= (float)_rotationAxes.Length;
					Quaternion quaternion7 = Quaternion.Lerp(quaternion5, quaternion6 * quaternion5, Mathf.Clamp01(num5 / num6));
					for (int num7 = 0; num7 < _rotationAxes.Length; num7++)
					{
						ControlAxis controlAxis6 = _rotationAxes[num7];
						float angleAroundAxis2 = GetAngleAroundAxis(quaternion7, controlAxis6.Axis);
						angleAroundAxis2 = Mathf.Clamp(angleAroundAxis2, controlAxis6.MinValue * controlAxis6.Multiplier, controlAxis6.MaxValue * controlAxis6.Multiplier);
						controlAxis6.SetValue(angleAroundAxis2 / controlAxis6.Multiplier);
						Quaternion quaternion8 = Quaternion.AngleAxis(angleAroundAxis2, controlAxis6.Axis);
						quaternion *= quaternion8;
						quaternion7 = Quaternion.Inverse(quaternion8) * quaternion7;
					}
					targetPosition = 0.5f * (attachedHand.current.position - quaternion * attachedHand.initialLocal.position + (attachedHand2.current.position - quaternion * attachedHand2.initialLocal.position));
				}
				Vector3 zero = Vector3.zero;
				for (int num8 = 0; num8 < _positionAxes.Length; num8++)
				{
					ControlAxis controlAxis7 = _positionAxes[num8];
					float value = Vector3.Dot(controlAxis7.Axis, targetPosition);
					value = Mathf.Clamp(value, controlAxis7.MinValue * controlAxis7.Multiplier, controlAxis7.MaxValue * controlAxis7.Multiplier);
					controlAxis7.SetValue(value / controlAxis7.Multiplier);
					zero += controlAxis7.Axis * value;
				}
				targetPosition = zero;
			}
			else
			{
				float[] axisValues = new float[_positionAxes.Length];
				PositionPass(ref targetPosition, ref axisValues, doHaptics: false);
				quaternion = RotationPass();
				PositionPass(ref targetPosition, ref axisValues, doHaptics: true);
				for (int num9 = 0; num9 < _positionAxes.Length; num9++)
				{
					_positionAxes[num9].SetValue(axisValues[num9]);
				}
			}
			if (mode == ControlBaseData.ControlMode.Joint)
			{
				_joint.targetPosition = targetPosition;
				_joint.targetRotation = quaternion;
			}
			else
			{
				_targetTransform.localPosition = targetPosition;
				_targetTransform.localRotation = quaternion;
			}
			void PositionPass(ref Vector3 reference2, ref float[] reference, bool doHaptics)
			{
				Vector3 rhs = default(Vector3);
				for (int num10 = 0; num10 < _attachedHands.Count; num10++)
				{
					AttachedHand attachedHand3 = _attachedHands[num10];
					rhs += attachedHand3.initialControlPose.position + attachedHand3.current.position - attachedHand3.initial.position;
				}
				rhs /= (float)_attachedHands.Count;
				for (int num11 = 0; num11 < _positionAxes.Length; num11++)
				{
					Vector3 axis = _positionAxes[num11].Axis;
					float num12 = Vector3.Dot(axis, rhs);
					float multiplier = _positionAxes[num11].Multiplier;
					float min = _positionAxes[num11].MinValue * multiplier;
					float max = _positionAxes[num11].MaxValue * multiplier;
					float num13 = reference[num11] * multiplier;
					if (doHaptics)
					{
						ProcessAxisHaptic(_positionAxes[num11], (num12 + num13) / multiplier);
					}
					num12 = Mathf.Clamp(num12 + num13, min, max) - num13;
					reference[num11] += num12 / multiplier;
					Vector3 vector = axis * num12;
					reference2 += vector;
					rhs -= vector;
				}
				for (int num14 = 0; num14 < _attachedHands.Count; num14++)
				{
					Pose current = _attachedHands[num14].current;
					current.position -= reference2;
					_attachedHands[num14].current = current;
				}
			}
			void ProcessAxisHaptic(ControlAxis axis, float unclampedValue)
			{
				bool flag = unclampedValue > axis.MaxValue || unclampedValue < axis.MinValue;
				if (flag != axis.WasBeyondLimit)
				{
					axis.WasBeyondLimit = flag;
					if (Time.timeAsDouble - axis.LastLimitChangeTime > 0.20000000298023224)
					{
						foreach (AttachedHand attachedHand5 in _attachedHands)
						{
							if (flag)
							{
								attachedHand5.HapticCallback?.Invoke(0.5f, 0.2f);
							}
							else
							{
								attachedHand5.HapticCallback?.Invoke(0.3f, 0.1f);
							}
						}
					}
					axis.LastLimitChangeTime = Time.timeAsDouble;
				}
			}
			Quaternion RotationPass()
			{
				Quaternion identity = Quaternion.identity;
				for (int num10 = 0; num10 < _rotationAxes.Length; num10++)
				{
					Vector3 axis = _rotationAxes[num10].Axis;
					float multiplier = _rotationAxes[num10].Multiplier;
					float minValue = _rotationAxes[num10].MinValue;
					float maxValue = _rotationAxes[num10].MaxValue;
					float rotationMaxDistance = _rotationAxes[num10].RotationMaxDistance;
					float num11 = 0f;
					for (int num12 = 0; num12 < _attachedHands.Count; num12++)
					{
						AttachedHand attachedHand3 = _attachedHands[num12];
						float num13 = 0f;
						float sqrMagnitude = Vector3.Cross(attachedHand3.current.position, axis).sqrMagnitude;
						float num14 = ((rotationMaxDistance != 0f && !(sqrMagnitude > rotationMaxDistance * rotationMaxDistance)) ? (1f - Mathf.Clamp01(Mathf.Sqrt(sqrMagnitude) / rotationMaxDistance)) : 0f);
						if (num14 > 0f)
						{
							float angleAroundAxis3 = GetAngleAroundAxis(attachedHand3.current.rotation * Quaternion.Inverse(attachedHand3.initialLocal.rotation), axis);
							num13 += num14 * angleAroundAxis3;
						}
						if (num14 < 1f)
						{
							num13 += (1f - num14) * Vector3.SignedAngle(Vector3.ProjectOnPlane(attachedHand3.initialLocal.position, axis), Vector3.ProjectOnPlane(attachedHand3.current.position, axis), axis);
						}
						num11 += num13;
					}
					num11 /= (float)_attachedHands.Count * multiplier;
					ProcessAxisHaptic(_rotationAxes[num10], num11);
					num11 = Mathf.Clamp(num11, minValue, maxValue);
					_rotationAxes[num10].SetValue(num11);
					Quaternion quaternion9 = Quaternion.AngleAxis(num11 * multiplier, axis);
					identity *= quaternion9;
					quaternion9 = Quaternion.Inverse(quaternion9);
					for (int num15 = 0; num15 < _attachedHands.Count; num15++)
					{
						AttachedHand attachedHand4 = _attachedHands[num15];
						attachedHand4.current.rotation = quaternion9 * attachedHand4.current.rotation;
						attachedHand4.current.position = quaternion9 * attachedHand4.current.position;
					}
				}
				return identity;
			}
		}

		private UniTask OnPreStartLayerUpdates(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (ControlBase.IgnoreAircraftCollisions)
			{
				PartData part = base.PartScript.Part;
				if (part.AttachPoints.Count > 0 && part.AttachPoints[0].PartConnections.Count > 0)
				{
					PartConnection item = base.PartScript.Part.AttachPoints[0].PartConnections[0];
					List<PartConnection> partConnectionsToIgnore = new List<PartConnection> { item };
					foreach (PartData part2 in new PartGraph(base.PartScript.Part, partConnectionsToIgnore).Parts)
					{
						LayerUtility.SetLayerRecursive(part2.PartScript.gameObject, 25, 19);
					}
				}
			}
			return UniTask.CompletedTask;
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (base.LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			for (int i = 0; i < _positionAxes.Length; i++)
			{
				Vector3 axis = _positionAxes[i].Axis;
				flag |= !Mathf.Approximately(axis.x, 0f);
				flag2 |= !Mathf.Approximately(axis.y, 0f);
				flag3 |= !Mathf.Approximately(axis.z, 0f);
			}
			for (int j = 0; j < _rotationAxes.Length; j++)
			{
				Vector3 axis2 = _rotationAxes[j].Axis;
				flag4 |= Mathf.Abs(axis2.x) > 0.0001f;
				flag5 |= Mathf.Abs(axis2.y) > 0.0001f;
				flag6 |= Mathf.Abs(axis2.z) > 0.0001f;
				Vector3 normalized = axis2.normalized;
				flag7 |= Mathf.Abs(Mathf.Abs(normalized.x) - 1f) < 0.0001f;
				flag8 |= Mathf.Abs(Mathf.Abs(normalized.y) - 1f) < 0.0001f;
				flag9 |= Mathf.Abs(Mathf.Abs(normalized.z) - 1f) < 0.0001f;
			}
			if ((flag4 && flag5) || (flag4 && flag6) || (flag5 && flag6))
			{
				flag4 = (flag5 = (flag6 = true));
			}
			_isSixDoF = _positionAxes.Length == 3 && _rotationAxes.Length == 3 && flag && flag2 && flag3 && flag7 && flag8 && flag9;
			switch (ControlBase.Mode)
			{
			case ControlBaseData.ControlMode.Joint:
			{
				int attachPointId = ControlBase.AttachPointId;
				List<AttachPointData> attachPoints = base.PartScript.Part.AttachPoints;
				if (attachPoints.Count > attachPointId)
				{
					AttachPointData attachPointData = attachPoints[attachPointId];
					if (attachPointData.PartConnections.Count == 1)
					{
						foreach (BodyJoint joint4 in base.PartScript.Body.Joints)
						{
							ConfigurableJoint jointForAttachPoint = joint4.GetJointForAttachPoint(attachPointData);
							if (jointForAttachPoint != null)
							{
								Rigidbody component = jointForAttachPoint.GetComponent<Rigidbody>();
								if (base.PartScript.Body.RigidBody.PhysxRigidBody == component)
								{
									_bodyJoint = joint4;
									_joint = jointForAttachPoint;
									_isEnabled = true;
								}
							}
						}
					}
				}
				if (!_isEnabled)
				{
					break;
				}
				ReferenceTransform = _joint.transform;
				ConfigurableJoint joint = _joint;
				Vector3 axis3 = (_joint.secondaryAxis = Vector3.zero);
				joint.axis = axis3;
				_joint.autoConfigureConnectedAnchor = false;
				_joint.anchor = _joint.transform.InverseTransformPoint(base.transform.position);
				_joint.connectedAnchor = _joint.connectedBody.transform.InverseTransformPoint(base.transform.position);
				_joint.xMotion = (flag ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked);
				_joint.yMotion = (flag2 ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked);
				_joint.zMotion = (flag3 ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked);
				_joint.angularXMotion = (flag4 ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked);
				_joint.angularYMotion = (flag5 ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked);
				_joint.angularZMotion = (flag6 ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked);
				_joint.slerpDrive = ControlBase.SlerpDrive;
				ConfigurableJoint joint2 = _joint;
				ConfigurableJoint joint3 = _joint;
				JointDrive jointDrive = (_joint.zDrive = ControlBase.PositionDrive);
				JointDrive xDrive = (joint3.yDrive = jointDrive);
				joint2.xDrive = xDrive;
				_joint.rotationDriveMode = RotationDriveMode.Slerp;
				_controlRigidbody = _joint.connectedBody;
				_inverseJointRotationOffset = Quaternion.Inverse(_joint.connectedBody.rotation) * base.transform.rotation;
				_controlRigidbody.ResetInertiaTensor();
				_controlRigidbody.GetComponent<BodyScript>().InertiaTensorRecalculationEnabled = false;
				if (FlightXRRigManager.Instance != null)
				{
					Dictionary<Rigidbody, ControlBaseScript> cockpitControls = FlightXRRigManager.Instance.CockpitControls;
					if (cockpitControls.ContainsKey(_controlRigidbody))
					{
						Debug.LogError("Control not activating, target body is already a control");
						_isEnabled = false;
					}
					else
					{
						cockpitControls.Add(_controlRigidbody, this);
					}
				}
				break;
			}
			case ControlBaseData.ControlMode.Transform:
				_isEnabled = false;
				if (ControlBase.TargetTransformPath != null)
				{
					_targetTransform = base.transform.Find(ControlBase.TargetTransformPath);
					if (_targetTransform != null)
					{
						ReferenceTransform = _targetTransform.parent;
						_isEnabled = true;
					}
				}
				break;
			}
		}

		private Pose WorldToLocalPose(Pose worldPose)
		{
			Pose parent = ((ControlBase.Mode != ControlBaseData.ControlMode.Joint) ? _targetTransform.parent.GetWorldPose() : new Pose(base.transform.position, _joint.transform.rotation));
			return parent.InverseTransformPose(worldPose);
		}
	}
}
