using System;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Propulsion;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ReactionControlNozzleScript : PartModifierScript<ReactionControlNozzleData>, IReactionControlNozzle, IAnalyzePerformance, IFlightStart, IGameLoopItem, IDesignerStart, IFlightUpdate, IFlightFixedUpdate, IFlightFixedUpdateWarp
	{
		private Transform _centerOfThrust;

		private EventMigrator<ICommandPod> _craftControlsChangedMigrator;

		private float _deactivateTime = 1f;

		private Vector3 _forceDirection;

		private IFuelSource _fuelSource;

		private Func<float> _inputAxis;

		private IInputController _inputPitch;

		private IInputController _inputRoll;

		private IInputController _inputThrottle;

		private IInputController _inputTranslateForward;

		private IInputController _inputTranslateRight;

		private IInputController _inputTranslateUp;

		private IInputController _inputYaw;

		private Vector3[] _multiDirectionVectors;

		private ParticleSystem _particleSystem;

		private ParticleSystem.EmissionModule _particleSystemEmission;

		private ParticleSystem.MainModule _particleSystemMain;

		private bool _rcnApplyForces;

		private float _rcnThrottle;

		private bool _recalculateInputs;

		private ISingleSound _sound;

		private bool _translationMode;

		public float CurrentThrust { get; private set; }

		public IFuelSource FuelSource => _fuelSource;

		public bool IsActive => base.PartScript.Data.Activated;

		public PartData Part => base.PartScript.Data;

		public float RcnThrottle => _rcnThrottle;

		public bool UsesMachNumber => false;

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			UpdateScale();
			VisibilityThrottle(base.Data.ManualInput);
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (_rcnApplyForces && !_fuelSource.IsEmpty)
			{
				Vector3 position = _centerOfThrust.position;
				Vector3 force = _rcnThrottle * base.Data.Power * _forceDirection;
				CurrentThrust = force.magnitude;
				base.PartScript.BodyScript.RigidBody.AddForceAtPosition(force, position);
				float num = _rcnThrottle * base.Data.FuelConsumptionRate * frame.DeltaTime;
				_fuelSource.RemoveFuel(num);
			}
		}

		void IFlightFixedUpdateWarp.FlightFixedUpdateWarp(in FlightFrameData frame)
		{
			CurrentThrust = 0f;
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			UpdateInputControllers();
			_centerOfThrust = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfThrust", base.gameObject).transform;
			_particleSystem = _centerOfThrust.Find("ParticleSystem").GetComponent<ParticleSystem>();
			_particleSystemEmission = _particleSystem.emission;
			_particleSystemMain = _particleSystem.main;
			_sound = Game.Instance.FlightScene.SingleSoundManager.GetSingleSound("Audio/Sounds/RCSNozzle");
			_sound.MaxVolume = 0.05f;
			UpdateScale();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			bool flag = true;
			_rcnApplyForces = false;
			bool flag2 = false;
			if (base.PartScript.CommandPod != null)
			{
				flag2 = base.PartScript.Data.Activated && !_fuelSource.IsEmpty;
				_translationMode = true;
			}
			float num = 0f;
			if (flag2)
			{
				if (_inputThrottle != null)
				{
					num = Mathf.Clamp01(_inputThrottle.Value);
					_forceDirection = -base.transform.up;
				}
				else
				{
					if (_recalculateInputs)
					{
						_recalculateInputs = false;
						ConfigureRcnBasedOnLocationAndOrientation();
					}
					num = ((_inputAxis == null) ? 0f : _inputAxis());
					if (frame.IsWarping)
					{
						num = 0f;
					}
					if (base.Data.MultiDirection)
					{
						float value = _inputRoll.Value;
						float value2 = _inputPitch.Value;
						float value3 = _inputYaw.Value;
						Vector3 vec = Mathf.Clamp01(value) * _multiDirectionVectors[0] + Mathf.Clamp01(0f - value) * _multiDirectionVectors[1] + Mathf.Clamp01(value2) * _multiDirectionVectors[2] + Mathf.Clamp01(0f - value2) * _multiDirectionVectors[3] + Mathf.Clamp01(value3) * _multiDirectionVectors[4] + Mathf.Clamp01(0f - value3) * _multiDirectionVectors[5];
						if (_translationMode)
						{
							float value4 = _inputTranslateForward.Value;
							float value5 = _inputTranslateRight.Value;
							float value6 = _inputTranslateUp.Value;
							vec += Mathf.Clamp01(value4) * _multiDirectionVectors[6] + Mathf.Clamp01(0f - value4) * _multiDirectionVectors[7] + Mathf.Clamp01(value5) * _multiDirectionVectors[8] + Mathf.Clamp01(0f - value5) * _multiDirectionVectors[9] + Mathf.Clamp01(value6) * _multiDirectionVectors[10] + Mathf.Clamp01(0f - value6) * _multiDirectionVectors[11];
						}
						num = Mathf.Clamp01(vec.sqrMagnitude);
						if (Utilities.CompareVector3s(vec, Vector3.zero) || num < 0.001f)
						{
							vec = -Vector3.up;
							num = 0f;
						}
						_forceDirection = base.transform.TransformDirection(vec.normalized);
						_centerOfThrust.forward = Vector3.Lerp(_centerOfThrust.forward, -_forceDirection, Mathf.Clamp(_rcnThrottle, 0.1f, 1f) * 10f * Mathf.Clamp(frame.DeltaTime, 0f, 0.05f));
						if (num > 0f)
						{
							_deactivateTime = 0f;
						}
					}
					else
					{
						_forceDirection = -base.transform.up;
					}
				}
				if (num > 0f)
				{
					_rcnApplyForces = true;
					_particleSystemMain.startColor = new Color(1f, 1f, 1f, num);
					_particleSystemEmission.enabled = true;
					if (!_particleSystem.isPlaying)
					{
						_particleSystem.Play();
					}
					_rcnThrottle = Mathf.Abs(num);
					flag = false;
				}
				else
				{
					_rcnThrottle = 0f;
					_particleSystemEmission.enabled = false;
				}
			}
			else
			{
				_rcnThrottle = 0f;
				_particleSystemEmission.enabled = false;
			}
			if (num == 0f && _deactivateTime < 1f && base.Data.MultiDirection)
			{
				_deactivateTime = Mathf.Clamp01(_deactivateTime + Time.deltaTime);
				_centerOfThrust.forward = Vector3.Lerp(_centerOfThrust.forward, base.transform.up, _deactivateTime);
			}
			if (_sound != null && !flag)
			{
				_sound.AddPosition(base.transform.position, Utilities.CompareFloats(_rcnThrottle, 0f, 0.1f) ? 0f : _rcnThrottle);
			}
		}

		public override void OnActivated()
		{
			base.OnActivated();
			base.PartScript.CraftScript.OnEngineActivationStatusChanged(activated: true);
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			if (!movedToNewCraft)
			{
				_recalculateInputs = true;
				_craftControlsChangedMigrator = new EventMigrator<ICommandPod>(() => base.PartScript.CommandPod, delegate(ICommandPod commandPod)
				{
					commandPod.ControlsChanged += OnCommandPodControlsChanged;
				}, delegate(ICommandPod commandPod)
				{
					commandPod.ControlsChanged -= OnCommandPodControlsChanged;
				});
				_craftControlsChangedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
				{
					partScript.CommandPodChanged += migrator.MigrateEvent;
				}, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
				{
					partScript.CommandPodChanged -= migrator.MigrateEvent;
				});
			}
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (base.PartScript.CommandPod != null)
			{
				_fuelSource = base.PartScript.CommandPod.MonoFuelSource;
			}
			else
			{
				_fuelSource = EmptyFuelSource.GetOrCreate(FuelType.Monopropellant);
			}
		}

		public override void OnDeactivated()
		{
			base.OnDeactivated();
			base.PartScript.CraftScript.OnEngineActivationStatusChanged(activated: false);
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Throttle", () => Utilities.FormatPercentage(_rcnThrottle)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Fuel Consumption", () => Units.GetMassFlowRateString(base.Data.FuelConsumptionRate), null, "The amount of liters of fuel burnt per second at full throttle."));
			groupModel.Add(new TextModel("Thrust", () => Units.GetForceString(base.Data.Power), null, "The amount of thrust produced by the engine at full throttle"));
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			_craftControlsChangedMigrator?.Dispose();
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateScale();
		}

		public void ToggleParticles(bool active)
		{
			if (_particleSystem == null)
			{
				_particleSystem = GetComponentInChildren<ParticleSystem>();
			}
			if (active)
			{
				_particleSystem.Play();
			}
			else
			{
				_particleSystem.Stop();
			}
		}

		public void UpdateScale()
		{
			Transform transform = base.transform.Find("Scalar");
			if (!(transform != null))
			{
				return;
			}
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 0.3f * base.Data.Scale;
			}
			transform.transform.localScale = new Vector3(base.Data.Scale, base.Data.Scale, base.Data.Scale);
		}

		public override void ValidatePart(ValidationResult result)
		{
			result.ValidatFuel(this, _fuelSource);
		}

		public void VisibilityThrottle(bool visible)
		{
			if (_inputThrottle == null)
			{
				_inputThrottle = GetInputController("Throttle");
			}
			if (_inputThrottle != null && _inputThrottle.Visible != visible)
			{
				_inputThrottle.Visible = visible;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			UpdateScale();
		}

		private Vector3 ClampOptimalDirectionVector(Vector3 v, Vector3 neutralDirection)
		{
			if (Vector3.Angle(neutralDirection, v) > 70f)
			{
				Vector3 vector = Vector3.RotateTowards(neutralDirection, v, 1.2217305f, 1f);
				v = ((!(Vector3.Dot(vector, v) > 0.4f)) ? Vector3.zero : vector);
			}
			return base.transform.InverseTransformDirection(v);
		}

		private void ConfigureRcnBasedOnLocationAndOrientation()
		{
			if (base.PartScript.CommandPod == null || _centerOfThrust == null)
			{
				_inputAxis = () => 0f;
				return;
			}
			Transform centerOfMass = base.PartScript.CraftScript.CenterOfMass;
			Vector3 position = _centerOfThrust.position;
			if (base.Data.MultiDirection)
			{
				if (_multiDirectionVectors == null)
				{
					_multiDirectionVectors = new Vector3[12];
				}
				Vector3 rhs = position - centerOfMass.position;
				Vector3 vector = -Vector3.Cross(centerOfMass.forward, rhs);
				Vector3 vector2 = Vector3.Cross(centerOfMass.right, rhs);
				Vector3 vector3 = Vector3.Cross(centerOfMass.up, rhs);
				Vector3 forward = centerOfMass.forward;
				Vector3 right = centerOfMass.right;
				Vector3 up = centerOfMass.up;
				_multiDirectionVectors[0] = vector;
				_multiDirectionVectors[1] = -vector;
				_multiDirectionVectors[2] = vector2;
				_multiDirectionVectors[3] = -vector2;
				_multiDirectionVectors[4] = vector3;
				_multiDirectionVectors[5] = -vector3;
				_multiDirectionVectors[6] = forward;
				_multiDirectionVectors[7] = -forward;
				_multiDirectionVectors[8] = right;
				_multiDirectionVectors[9] = -right;
				_multiDirectionVectors[10] = up;
				_multiDirectionVectors[11] = -up;
				Vector3 up2 = base.transform.up;
				for (int num = 0; num < _multiDirectionVectors.Length; num++)
				{
					_multiDirectionVectors[num] = ClampOptimalDirectionVector(_multiDirectionVectors[num], -up2);
				}
				_inputAxis = delegate
				{
					float num2 = Mathf.Abs(_inputRoll.Value) + Mathf.Abs(_inputPitch.Value) + Mathf.Abs(_inputYaw.Value);
					if (_translationMode)
					{
						num2 += Mathf.Abs(_inputTranslateForward.Value) + Mathf.Abs(_inputTranslateRight.Value) + Mathf.Abs(_inputTranslateUp.Value);
					}
					return Mathf.Clamp01(num2);
				};
				return;
			}
			Vector3 forceDir = -_centerOfThrust.forward;
			Vector3 rotationalWeights = MathUtils.ComputeRotationContributions(position, forceDir, centerOfMass, invertContributions: false, singleAxis: false);
			Vector3 translationalWeights = MathUtils.ComputeTranslationContributions(position, forceDir, centerOfMass, invertContributions: false, singleAxis: false, 0.1f);
			_inputAxis = delegate
			{
				float num2 = Mathf.Clamp01(_inputPitch.Value * rotationalWeights.x + _inputYaw.Value * rotationalWeights.y + _inputRoll.Value * rotationalWeights.z);
				if (_translationMode)
				{
					num2 += Mathf.Clamp01(_inputTranslateForward.Value * translationalWeights.z + _inputTranslateRight.Value * translationalWeights.x + _inputTranslateUp.Value * translationalWeights.y);
				}
				return num2;
			};
		}

		private void OnCommandPodControlsChanged(ICommandPod source, bool adjustControlsToCom)
		{
			if (adjustControlsToCom)
			{
				_recalculateInputs = true;
			}
			UpdateInputControllers();
		}

		private void UpdateInputControllers()
		{
			_inputThrottle = (base.Data.ManualInput ? GetInputController("Throttle") : null);
			_inputPitch = GetInputController((CraftControls x) => x.Pitch);
			_inputRoll = GetInputController((CraftControls x) => x.Roll);
			_inputYaw = GetInputController((CraftControls x) => x.Yaw);
			_inputTranslateForward = GetInputController((CraftControls x) => x.TranslateForward);
			_inputTranslateRight = GetInputController((CraftControls x) => x.TranslateRight);
			_inputTranslateUp = GetInputController((CraftControls x) => x.TranslateUp);
		}
	}
}
