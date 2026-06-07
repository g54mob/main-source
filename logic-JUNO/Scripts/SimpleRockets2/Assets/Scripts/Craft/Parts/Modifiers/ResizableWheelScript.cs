using System;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Input;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.CustomWheelCollider;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Parts.Styles;
using ModApi.Data;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ResizableWheelScript : PartModifierScript<ResizableWheelData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightUpdate, IFlightFixedUpdate, IDesignerStart, IDesignerUpdate
	{
		private AudioSource _audioMotor;

		private AudioSource _audioRollingFast;

		private AudioSource _audioRollingOffroad;

		private AudioSource _audioRollingRoad;

		private PositionBiomeData _biomeData;

		private IInputController _brakeInput;

		private float _currentTurningAngle;

		private float _designerTargetTurnAngle;

		private int _designerTargetTurnIndex;

		private float _designerTargetTurnReachedTime;

		private float _functionalHealth = 1f;

		private bool _loaded;

		private IInputController _motorInput;

		[SerializeField]
		private float _motorTorque;

		[SerializeField]
		private float _motorTorqueAverage;

		private PartConnection _partConnection;

		[SerializeField]
		private float _powerConsumption;

		private IInputController _rpmInput;

		private AnimationCurve _rpmToTorqueCurve;

		private ISingleSound _sound;

		private GameObject _sphereCollider;

		private TireTrackRenderer _tireTrackRenderer;

		private int _torqueDirection;

		private Transform _trackContainer;

		private float _trackWidth;

		private Transform _turningRoot;

		private IInputController _turnInput;

		private ResizableWheelCollider _wc;

		private Transform _wheel;

		private GameObject _wheelMeshCollider;

		private Transform _wheelMeshParent;

		private GameObject _wheelRoot;

		public float CurrentRpm
		{
			get
			{
				if (!base.Data.Direction)
				{
					return 0f - _wc.Rpm;
				}
				return _wc.Rpm;
			}
		}

		public bool Enabled { get; set; }

		public Func<float> ExternalMotorTorque { get; set; }

		public bool Grounded
		{
			get
			{
				if (_wc != null)
				{
					return _wc.IsGrounded;
				}
				return false;
			}
		}

		public float MaxRpm => base.Data.MaxRpm;

		public float PowerConsumption => _powerConsumption;

		public float SpringReductionCoefficient { get; set; }

		public int TurnActivationGroup
		{
			get
			{
				if (_turnInput != null)
				{
					return ((InputControllerScript)_turnInput).Data.ActivationGroup;
				}
				return 0;
			}
		}

		public string TurningInput
		{
			get
			{
				if (_turnInput != null)
				{
					return ((InputControllerScript)_turnInput).Data.Input;
				}
				return string.Empty;
			}
		}

		public bool UsesMachNumber => false;

		public bool WheelDisconnected
		{
			get
			{
				if (_partConnection != null)
				{
					return _partConnection.IsDestroyed;
				}
				return true;
			}
		}

		protected ResizableWheelCollider WheelCollider => _wc;

		private float MaxPowerConsumption => base.Data.Torque * (float)((base.Data.Version < 3) ? 29 : 350);

		private float TurningRate => base.Data.TurningRate;

		public void AddBrakeTorque(float brakeTorque)
		{
			if (_wc == null)
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					_wc.BrakeTorque += brakeTorque * 0.01f;
				});
			}
			else
			{
				_wc.BrakeTorque += brakeTorque * 0.01f;
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			_wc = GetWheelCollider();
			RebuildWheel();
			SetupTorqueDirection();
			_turnInput = GetInputController("Turn");
			_brakeInput = GetInputController("Brake");
			_rpmInput = GetInputController("RPM");
			_motorInput = GetInputController("Motor");
			if (_motorInput == null)
			{
				_motorInput = GetInputController("Torque");
			}
			VisibilityRPM(base.Data.MotorTorque > 0f);
			VisibilityTurn(base.Data.TurningAngle > 0f);
		}

		void IDesignerUpdate.DesignerUpdate(in DesignerFrameData frame)
		{
			if (!base.Data.PropertiesOpen || !(_wc != null))
			{
				return;
			}
			bool flag = false;
			if (base.Data.TurningAngle > 0f)
			{
				if (Mathf.Abs(_designerTargetTurnAngle) > base.Data.TurningAngle)
				{
					_designerTargetTurnAngle = base.Data.TurningAngle * Mathf.Sign(_designerTargetTurnAngle);
				}
				if (Mathf.Approximately(_currentTurningAngle, _designerTargetTurnAngle))
				{
					_designerTargetTurnReachedTime += frame.DeltaTime;
					switch (_designerTargetTurnIndex)
					{
					case 0:
						if (_designerTargetTurnReachedTime >= 2f)
						{
							flag = false;
							_designerTargetTurnAngle = base.Data.TurningAngle;
							_designerTargetTurnIndex = 1;
							_designerTargetTurnReachedTime = 0f;
						}
						break;
					case 1:
						if (_designerTargetTurnReachedTime >= 0.25f)
						{
							_designerTargetTurnAngle = 0f;
							_designerTargetTurnIndex = 2;
							_designerTargetTurnReachedTime = 0f;
						}
						break;
					case 2:
						if (_designerTargetTurnReachedTime >= 0.25f)
						{
							_designerTargetTurnAngle = 0f - base.Data.TurningAngle;
							_designerTargetTurnIndex = 3;
							_designerTargetTurnReachedTime = 0f;
						}
						break;
					case 3:
						if (_designerTargetTurnReachedTime >= 0.25f)
						{
							_designerTargetTurnAngle = 0f;
							_designerTargetTurnIndex = 0;
							_designerTargetTurnReachedTime = 0f;
						}
						break;
					}
				}
			}
			else
			{
				_designerTargetTurnAngle = 0f;
				_designerTargetTurnReachedTime = 0f;
				_designerTargetTurnIndex = 0;
			}
			_currentTurningAngle = Utilities.StepTowards(_currentTurningAngle, TurningRate * frame.DeltaTime / 2f, _designerTargetTurnAngle);
			_turningRoot.localRotation = Quaternion.Euler(0f, _currentTurningAngle + 90f, 0f);
			if (Mathf.Approximately(_currentTurningAngle, 0f) && _designerTargetTurnIndex == 0)
			{
				flag = true;
			}
			if (flag)
			{
				_wc.WheelRotationAngle += 45f * frame.DeltaTime * (float)_torqueDirection;
				_wc.UpdateWheelRotation();
			}
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			bool flag = true;
			if (!WheelDisconnected)
			{
				IFuelSource batteryFuelSource = base.PartScript.BatteryFuelSource;
				if (batteryFuelSource != null && !batteryFuelSource.IsEmpty && base.Data.TorqueScaled > 0f)
				{
					float num = ((_motorInput != null) ? Mathf.Clamp(_motorInput.Value, -1f, 1f) : 0f);
					_motorTorque = num * base.Data.TorqueScaled * 0.01f;
					if (ExternalMotorTorque != null)
					{
						_motorTorque += ExternalMotorTorque() * 0.01f;
					}
					float num2 = ((_rpmInput != null) ? (Mathf.Clamp(_rpmInput.Value, -1f, 1f) * MaxRpm) : MaxRpm);
					if (num2 != 0f)
					{
						float time = Mathf.Abs(CurrentRpm) / MaxRpm;
						_motorTorque *= _rpmToTorqueCurve.Evaluate(time) * ((num > 0f) ? Mathf.Sign(num2) : 1f);
						float num3 = Mathf.Lerp(0.01f, 0.1f, Mathf.Abs(num2) / MaxRpm) * MaxRpm;
						float num4 = Mathf.Clamp01((((num2 > 0f) ? (num2 - CurrentRpm) : (CurrentRpm - num2)) + num3) / (2f * num3));
						_motorTorque *= num4;
						_powerConsumption = Mathf.Abs(_motorTorque / (base.Data.TorqueScaled * 0.01f)) * MaxPowerConsumption;
						if (_powerConsumption > 0f)
						{
							batteryFuelSource.RemoveFuel(0.001f * _powerConsumption * frame.DeltaTime);
						}
					}
					else
					{
						_motorTorque = 0f;
						_powerConsumption = 0f;
					}
				}
				else
				{
					_motorTorque = 0f;
					_powerConsumption = 0f;
				}
				WheelCollider.MotorTorque = _motorTorque * (float)_torqueDirection * _functionalHealth;
			}
			else
			{
				_motorTorque = 0f;
				_powerConsumption = 0f;
				flag = false;
			}
			Vector3 gravityNormal = base.PartScript.CraftScript.GravityNormal;
			Vector3 normalized = Vector3.ProjectOnPlane(gravityNormal, _turningRoot.right).normalized;
			if (Vector3.Dot(normalized, gravityNormal) < 0.5f)
			{
				flag = false;
			}
			if (flag)
			{
				if (!WheelCollider.enabled)
				{
					WheelCollider.enabled = true;
					_wheelMeshCollider.SetActive(value: false);
				}
				Vector3 vector = base.transform.InverseTransformVector(normalized);
				float num5 = Mathf.Atan2(0f - Vector3.up.x, 0f - Vector3.up.y);
				float num6 = Mathf.Atan2(vector.x, vector.y) - num5;
				_wheelRoot.transform.localEulerAngles = new Vector3(num6 * 57.29578f, 0f, 0f);
			}
			else if (WheelCollider.enabled)
			{
				_wc.enabled = false;
				_tireTrackRenderer.Updating = false;
				_wheelMeshCollider.SetActive(value: true);
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			Initialize();
			_sound = Game.Instance.FlightScene.SingleSoundManager.GetSingleSound("Audio/Sounds/tireSkid");
			_rpmToTorqueCurve = Resources.Load<CurveObject>("Craft/Parts/RpmToTorqueCurve").Curve;
			ResizableWheelCollider wheelCollider = GetWheelCollider();
			if (wheelCollider != null)
			{
				wheelCollider.gameObject.SetActive(value: true);
				float a = ((base.Data.Version < 3) ? base.Data.Mass : base.Data.WheelMass);
				float b = ((base.Data.Version < 3) ? 0.25f : 0.001f);
				wheelCollider.PartScript = base.PartScript;
				wheelCollider.Rigidbody = base.PartScript.BodyScript.RigidBody;
				wheelCollider.SuspensionDistance = base.Data.SuspensionDistance;
				wheelCollider.BrakeTorque = base.Data.BrakeTorque * 0.01f;
				wheelCollider.Mass = Mathf.Max(a, b);
				wheelCollider.CollideWithAircraftLayer = true;
				wheelCollider.Rigidbody.maxDepenetrationVelocity = 1f;
				_wc = wheelCollider;
				SetupTorqueDirection();
				UpdateWheelColliderSettings();
			}
			if (base.PartScript.Data.PartConnections.Count > 0)
			{
				_partConnection = base.PartScript.Data.PartConnections[0];
			}
			_wheelMeshCollider.SetActive(value: false);
			_sphereCollider.SetActive(value: true);
			AudioSource[] components = base.transform.GetComponents<AudioSource>();
			_audioMotor = components[0];
			_audioMotor.time = UnityEngine.Random.Range(0f, _audioMotor.clip.length);
			_audioRollingFast = components[1];
			_audioRollingFast.time = UnityEngine.Random.Range(0f, _audioRollingFast.clip.length);
			_audioRollingOffroad = components[2];
			_audioRollingOffroad.time = UnityEngine.Random.Range(0f, _audioRollingOffroad.clip.length);
			_audioRollingRoad = components[3];
			_audioRollingRoad.time = UnityEngine.Random.Range(0f, _audioRollingRoad.clip.length);
			RebuildWheel();
			if (!base.Data.EnableSuspension)
			{
				DisableSuspension();
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (!frame.IsWarping)
			{
				_wc.Rigidbody = base.PartScript.BodyScript.RigidBody;
				UpdateWheel(frame.DeltaTime);
			}
			_motorTorqueAverage = Mathf.Lerp(_motorTorqueAverage, Mathf.Abs(_motorTorque), 10f * frame.DeltaTime / base.Data.Scale);
			if (_audioMotor != null && base.Data.SoundVolume > 0f)
			{
				_audioMotor.pitch = Mathf.Clamp(0.0025f * Mathf.Abs(CurrentRpm) * Time.timeScale, 0.1f, 20f);
				float a = (WheelDisconnected ? 0f : (0.25f * base.Data.Scale * Mathf.Abs(CurrentRpm) / MaxRpm));
				float b = Mathf.Pow(0.1f * _motorTorqueAverage, 0.25f);
				b = Mathf.Clamp01(Mathf.Max(a, b)) * base.Data.SoundVolume;
				_audioMotor.volume = b;
				if (b > 0.01f)
				{
					if (!_audioMotor.isPlaying)
					{
						_audioMotor.Play();
					}
				}
				else if (_audioMotor.isPlaying)
				{
					_audioMotor.Stop();
				}
			}
			if (!(_audioRollingFast != null) || !(_audioRollingOffroad != null) || !(_audioRollingRoad != null))
			{
				return;
			}
			if (Grounded)
			{
				float sqrMagnitude = _wc.Rigidbody.velocity.sqrMagnitude;
				float num = Mathf.Clamp01(sqrMagnitude * 0.001f - 0.5f);
				_audioRollingFast.volume = num * base.Data.Scale * 0.25f;
				float offroadPercentage = _wc.OffroadPercentage;
				float num2 = base.Data.Scale * 0.1f * Mathf.Clamp01(sqrMagnitude * 0.1f) * (1f - num) * (Mathf.Abs(_wc.ForwardSlip) + Mathf.Abs(_wc.SidewaysSlip));
				_audioRollingOffroad.volume = offroadPercentage * num2;
				_audioRollingRoad.volume = (1f - offroadPercentage) * num2;
				float num3 = sqrMagnitude * 0.001f * 2.5f + 0.5f;
				_audioRollingFast.pitch = 0.1f * num3;
				_audioRollingOffroad.pitch = num3;
				_audioRollingRoad.pitch = num3;
				if (_audioRollingFast.volume > 0.001f)
				{
					if (!_audioRollingFast.isPlaying)
					{
						_audioRollingFast.Play();
					}
				}
				else if (_audioRollingFast.isPlaying)
				{
					_audioRollingFast.Stop();
				}
				if (offroadPercentage * num2 > 0.001f)
				{
					if (!_audioRollingOffroad.isPlaying)
					{
						_audioRollingOffroad.Play();
					}
				}
				else if (_audioRollingOffroad.isPlaying)
				{
					_audioRollingOffroad.Stop();
				}
				if ((1f - offroadPercentage) * num2 > 0.001f)
				{
					if (!_audioRollingRoad.isPlaying)
					{
						_audioRollingRoad.Play();
					}
				}
				else if (_audioRollingRoad.isPlaying)
				{
					_audioRollingRoad.Stop();
				}
			}
			else
			{
				if (_audioRollingFast.isPlaying)
				{
					_audioRollingFast.Stop();
				}
				if (_audioRollingOffroad.isPlaying)
				{
					_audioRollingOffroad.Stop();
				}
				if (_audioRollingRoad.isPlaying)
				{
					_audioRollingRoad.Stop();
				}
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			if (!_loaded)
			{
				_loaded = true;
			}
			else if (Game.InFlightScene && base.PartScript.GameObject.activeInHierarchy)
			{
				_wc.Rigidbody = base.PartScript.BodyScript.RigidBody;
				UpdateWheelColliderSettings();
			}
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (Game.InFlightScene && base.PartScript.GameObject.activeInHierarchy)
			{
				_wc.Rigidbody = base.PartScript.BodyScript.RigidBody;
				UpdateWheelColliderSettings();
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			WheelCollider.OnGenerateInspectorModel(model, _torqueDirection);
			model.Add(new TextModel("Power Consumption", () => Units.GetPowerString(PowerConsumption)), "Wheel");
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Top Speed", () => Units.GetVelocityString(MaxRpm * base.Data.Radius * MathF.PI / 30f), null, "The ideal top speed achievable with the wheel based on its radius and rpm."));
			groupModel.Add(new TextModel("Max RPM", () => ((int)MaxRpm).ToString(), null, "The max amount of revolutions per minute the wheel can achieve."));
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(MaxPowerConsumption), null, "The max power consumption of the wheel."));
			groupModel.Add(new TextModel("Concrete Friction", () => Units.GetPercentageString(base.Data.FrictionConcrete), null, "The amount of friction on structures."));
			groupModel.Add(new TextModel("Offroad Friction", () => Units.GetPercentageString(base.Data.FrictionOffroad), null, "The amount of friction on the terrain."));
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			HandleDirectionFromSymmetry(mode, created);
		}

		public override void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
			base.RecalculateFrameState(positionDelta, velocityDelta);
			_tireTrackRenderer?.MoveAllSections(positionDelta);
			ResizableWheelCollider wc = _wc;
			if (wc != null)
			{
				wc.LastGroundPoint += positionDelta;
				wc.RecalculateFrameState();
			}
		}

		public void ResetWheelRotation()
		{
			if (_wc != null)
			{
				_wc.WheelRotationAngle = 0f;
				_wc.UpdateWheelRotation();
				_turningRoot.localRotation = Quaternion.Euler(0f, 90f, 0f);
				_designerTargetTurnAngle = 0f;
				_designerTargetTurnIndex = 0;
				_designerTargetTurnReachedTime = 0f;
			}
		}

		public override void ValidatePart(ValidationResult result)
		{
			result.ValidatFuel(this, base.PartScript.BatteryFuelSource, MaxPowerConsumption * 0.1f);
		}

		public void VisibilityRPM(bool visible)
		{
			if (_rpmInput != null && _rpmInput.Visible != visible)
			{
				_rpmInput.Visible = visible;
			}
		}

		public void VisibilityTurn(bool visible)
		{
			if (_turnInput != null && _turnInput.Visible != visible)
			{
				_turnInput.Visible = visible;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_wheel = Utilities.FindFirstGameObjectMyselfOrChildren("Wheel", base.PartScript.GameObject).transform;
			_wheelMeshCollider = Utilities.FindFirstGameObjectMyselfOrChildren("MeshCollider", base.PartScript.GameObject);
			_sphereCollider = Utilities.FindFirstGameObjectMyselfOrChildren("SphereCollider", base.PartScript.GameObject);
			if (Game.InFlightScene)
			{
				PartScript obj = base.PartScript as PartScript;
				obj.RegisterInertiaTensorCollider(_wheelMeshCollider, required: true);
				obj.RegisterInertiaTensorCollider(_sphereCollider, required: false);
				_wheel.localScale = new Vector3(base.Data.ThicknessScale, base.Data.Scale, base.Data.Scale);
				return;
			}
			Initialize();
			if (Game.InDesignerScene)
			{
				base.Data.WheelParametersChanged += WheelParametersChanged;
			}
			RebuildWheel();
		}

		private void ActivateRimMesh(string name)
		{
			foreach (IPartStyle style in Game.Instance.PartStyleManager.GetStyles(base.PartScript.Data.PartType.Id, 1))
			{
				string id = style.Id;
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(id, base.PartScript.GameObject);
				if (gameObject == null && name == id)
				{
					gameObject = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/Wheels/" + id)) as GameObject;
					gameObject.transform.SetParent(_wheelMeshParent, worldPositionStays: false);
					gameObject.layer = _wheelMeshParent.gameObject.layer;
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.name = id;
					base.PartScript.PartMaterialScript.AddRenderer(gameObject.GetComponent<MeshRenderer>(), true);
				}
				if (!(gameObject != null))
				{
					continue;
				}
				if (name == id)
				{
					gameObject.SetActive(value: true);
					Vector3 localScale = gameObject.transform.localScale;
					localScale.y = (localScale.x = base.Data.RimScale);
					if (base.Data.Direction)
					{
						localScale.x *= -1f;
					}
					gameObject.transform.localScale = localScale;
				}
				else if (Game.InDesignerScene)
				{
					gameObject.SetActive(value: false);
				}
				else
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(gameObject.GetComponent<MeshRenderer>());
					UnityEngine.Object.DestroyImmediate(gameObject);
				}
			}
		}

		private void ActivateTireMesh(string name)
		{
			foreach (IPartStyle style in Game.Instance.PartStyleManager.GetStyles(base.PartScript.Data.PartType.Id, 2))
			{
				string id = style.Id;
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(id, base.PartScript.GameObject);
				if (gameObject == null && name == id)
				{
					gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/Prefabs/Wheels/" + id);
					gameObject.transform.SetParent(_wheelMeshParent, worldPositionStays: false);
					gameObject.layer = _wheelMeshParent.gameObject.layer;
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.name = id;
					base.PartScript.PartMaterialScript.AddRenderer(gameObject.GetComponent<MeshRenderer>(), true);
				}
				if (!(gameObject != null))
				{
					continue;
				}
				if (name == id)
				{
					gameObject.SetActive(value: true);
					if (base.Data.Direction)
					{
						gameObject.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
					}
					else
					{
						gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
					}
				}
				else if (Game.InDesignerScene)
				{
					gameObject.SetActive(value: false);
				}
				else
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(gameObject.GetComponent<MeshRenderer>());
					UnityEngine.Object.DestroyImmediate(gameObject);
				}
			}
		}

		private void DisableSuspension()
		{
			ResizableWheelCollider wc = _wc;
			wc.SuspensionEnabled = false;
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("NoSuspensionCollider", base.PartScript.GameObject);
			ResizableWheelColliderScript resizableWheelColliderScript = base.PartScript.BodyScript.GameObject.AddComponent<ResizableWheelColliderScript>();
			resizableWheelColliderScript.Collider = gameObject.GetComponent<SphereCollider>();
			resizableWheelColliderScript.EscaperCollider = gameObject.GetComponentInChildren<CapsuleCollider>();
			resizableWheelColliderScript.WheelCollider = wc;
			gameObject.SetActive(value: true);
			gameObject.transform.parent = WheelCollider.transform.parent;
		}

		private ResizableWheelCollider GetWheelCollider()
		{
			ResizableWheelCollider result = null;
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Physics", base.PartScript.GameObject);
			if (gameObject != null)
			{
				result = gameObject.GetComponent<ResizableWheelCollider>();
			}
			return result;
		}

		private void HandleDirectionFromSymmetry(SymmetryMode mode, bool created)
		{
			if ((uint)(mode - 1) <= 1u)
			{
				IPartScript partScript = Symmetry.GetSymmetricPartScripts(base.PartScript).FirstOrDefault((IPartScript x) => x != base.PartScript);
				if (partScript != null && (base.Data.Part.Mirrored || mode == SymmetryMode.Radial2) && Game.InDesignerScene)
				{
					ResizableWheelScript modifier = partScript.GetModifier<ResizableWheelScript>();
					base.Data.Direction = !modifier.Data.Direction;
				}
				else if (partScript != null && partScript.Data.Mirrored && Game.InDesignerScene)
				{
					if (partScript.GetModifier<ResizableWheelScript>().Data.Direction == base.Data.Direction)
					{
						base.Data.Direction = !base.Data.Direction;
					}
				}
				else if (created && mode == SymmetryMode.Mirror)
				{
					base.Data.Direction = !base.Data.Direction;
				}
				else
				{
					Debug.Log("Unsupported mirror/symmetry configuration.", this);
				}
			}
			SetupTorqueDirection();
		}

		private void Initialize()
		{
			Enabled = true;
			base.PartScript.CollisionSoundsEnabled = false;
			_wheelRoot = Utilities.FindFirstGameObjectMyselfOrChildren("WheelRoot", base.PartScript.GameObject);
			if (!Game.InDesignerScene)
			{
				_turnInput = GetInputController("Turn");
				_brakeInput = GetInputController("Brake");
				_rpmInput = GetInputController("RPM");
				_motorInput = GetInputController("Motor");
				if (_motorInput == null)
				{
					_motorInput = GetInputController("Torque");
				}
			}
			_turningRoot = Utilities.FindFirstGameObjectMyselfOrChildren("TurningRoot", base.PartScript.GameObject).transform;
			_wheelMeshParent = Utilities.FindFirstGameObjectMyselfOrChildren("VisualMeshes", base.PartScript.GameObject).transform;
			_trackContainer = Utilities.FindFirstGameObjectMyselfOrChildren("TrackContainer", base.PartScript.GameObject).transform;
			_tireTrackRenderer = _trackContainer.GetComponentInChildren<TireTrackRenderer>(includeInactive: true);
			_tireTrackRenderer.Initialize();
			SpringReductionCoefficient = 1f;
			_biomeData = FlightSceneScript.Instance?.CraftBiomeData;
		}

		private void RebuildWheel()
		{
			ResizableWheelCollider wc = _wc;
			IPartStyle style = base.PartScript.Data.Styles[1].Style;
			IPartStyle style2 = base.PartScript.Data.Styles[2].Style;
			ResizableWheelData data = base.Data;
			_wheel.localScale = new Vector3(data.ThicknessScale, data.Scale, data.Scale);
			_trackWidth = data.ThicknessScale * 0.4f;
			_tireTrackRenderer.Width = _trackWidth;
			if (Game.InFlightScene && wc != null)
			{
				wc.WheelRadius = data.Radius;
				wc.WheelWidth = data.ThicknessScale;
				Vector3 center = wc.Center;
				center.x = _wheelMeshParent.localPosition.x * data.ThicknessScale;
				wc.Center = center;
				_trackContainer.localPosition = new Vector3(0f, 0f, 0f - wc.Center.x + _turningRoot.localPosition.z);
			}
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 1f * data.Scale;
			}
			SetupTorqueDirection();
			ActivateTireMesh(style2.Id);
			ActivateRimMesh(style.Id);
			if (base.PartScript.SymmetrySlice?.SymmetryGroup != null)
			{
				HandleDirectionFromSymmetry(base.PartScript.SymmetrySlice.SymmetryGroup.SymmetryMode, created: false);
			}
			if (wc != null)
			{
				wc.SetWheelFrictionScalars(data.FrictionConcrete, data.FrictionOffroad);
			}
		}

		private void SetupTorqueDirection()
		{
			_torqueDirection = (base.Data.Direction ? 1 : (-1));
		}

		private void UpdateWheel(float deltaTime)
		{
			base.PartScript.BodyScript.SetCollidingWithTerrainFlag(null);
			ResizableWheelCollider wc = _wc;
			if (wc.enabled)
			{
				float num = 0f;
				if (base.PartScript.BodyScript != null && base.PartScript.BodyScript.RigidBody != null)
				{
					float num2 = 1f;
					if (_brakeInput == null)
					{
						ICommandPod commandPod = base.PartScript.CommandPod;
						if (commandPod != null && commandPod.Controls.Brake > 0f)
						{
							wc.BrakeInput = commandPod.Controls.Brake * _functionalHealth;
							num2 = 2f;
						}
						else if (wc != null)
						{
							wc.BrakeInput = 0f;
						}
					}
					else
					{
						wc.BrakeInput = Mathf.Clamp01(_brakeInput.Value) * _functionalHealth;
						num2 = 2f;
					}
					if (wc.IsGrounded)
					{
						bool flag = wc.LastGroundCollider.gameObject.layer == 31 || wc.LastGroundCollider.gameObject.layer == 30;
						base.PartScript.BodyScript.SetCollidingWithTerrainFlag(!flag);
						if (!flag && wc.OffroadPercentage < 0.3f)
						{
							float f = wc.ForwardSlip * 10f * num2 / Mathf.Max(0.001f, wc.ForwardFriction.AsymptoteSlip);
							num = (Mathf.Max(b: Mathf.Abs(wc.SidewaysSlip * 4f / Mathf.Max(0.001f, wc.SidewaysFriction.AsymptoteSlip)), a: Mathf.Abs(f)) * wc.SurfaceFriction - 1f) / 10f;
							num = Mathf.Clamp(num, 0f, 1f);
							num *= num;
						}
						if ((wc.OffroadPercentage > 0.3f || num > 0.1f) && !flag)
						{
							Vector3 vector = (Utilities.CompareVector3s(base.PartScript.BodyScript.SurfaceVelocity, Vector3.zero, 0.1f) ? wc.DummyWheel.forward : base.PartScript.BodyScript.SurfaceVelocity);
							vector = Vector3.ProjectOnPlane(vector, wc.LastGroundNormal).normalized;
							_trackContainer.LookAt(_trackContainer.position + vector, wc.LastGroundNormal);
							Vector3 localPosition = _trackContainer.InverseTransformPoint(wc.LastGroundPoint + wc.LastGroundNormal * 0.05f);
							localPosition.x = 0f;
							localPosition.z = 0f;
							_tireTrackRenderer.transform.localPosition = localPosition;
							_tireTrackRenderer.Width = _trackWidth * Mathf.Clamp(Mathf.Abs(Vector3.Dot(vector, wc.DummyWheel.forward)), 0.25f, 1f);
							_tireTrackRenderer.CurrentOpacityMultiplier = ((wc.OffroadPercentage < 0.3f) ? 1f : _biomeData.TireTrackStrength);
							_tireTrackRenderer.Updating = true;
						}
						else
						{
							_tireTrackRenderer.Updating = false;
						}
					}
					else
					{
						_tireTrackRenderer.Updating = false;
					}
					if (_turnInput != null)
					{
						float target = _turnInput.Value * base.Data.TurningAngle;
						if (WheelDisconnected)
						{
							target = 0f;
						}
						_currentTurningAngle = Utilities.StepTowards(_currentTurningAngle, TurningRate * deltaTime, target);
						if (wc != null && base.Data.TurningAngle > 0f && _turnInput != null)
						{
							_turningRoot.localRotation = Quaternion.Euler(0f, _currentTurningAngle + 90f, 0f);
						}
					}
				}
				if (_sound != null && num > 0f && (base.PartScript.WaterPhysics == null || base.PartScript.WaterPhysics.UnderWaterAmount < 0.2f) && wc.OffroadPercentage < 0.3f)
				{
					_sound.AddPosition(base.transform.position, num * (1f - wc.OffroadPercentage));
				}
			}
			else
			{
				_tireTrackRenderer.Updating = false;
			}
		}

		private void UpdateWheelColliderSettings()
		{
			if (base.PartScript?.CraftScript?.CraftNode != null)
			{
				ResizableWheelCollider wc = _wc;
				Vector3 vector = base.transform.InverseTransformPoint(base.PartScript.CraftScript.CenterOfMass.position);
				vector.y = 0f;
				float magnitude = vector.magnitude;
				JointSpringSource suspensionSpring = default(JointSpringSource);
				float num = (float)base.PartScript.CraftScript.CraftNode.Parent.PlanetData.SurfaceGravity;
				float b = base.Data.SuspensionDistance * (1f - base.Data.SuspensionStiffness);
				float mass = base.PartScript.CraftScript.Mass;
				suspensionSpring.Spring = mass * num / Mathf.Max(0.001f, b);
				suspensionSpring.Damper = suspensionSpring.Spring / 50f;
				wc.NoSuspensionTraction = mass * num * 0.9f;
				if (magnitude > 1f)
				{
					suspensionSpring.Spring /= magnitude;
					suspensionSpring.Damper /= magnitude;
					wc.NoSuspensionTraction /= magnitude;
				}
				suspensionSpring.Spring *= SpringReductionCoefficient;
				suspensionSpring.Damper *= SpringReductionCoefficient;
				wc.NoSuspensionTraction *= SpringReductionCoefficient;
				suspensionSpring.Spring *= base.Data.Spring;
				suspensionSpring.Damper *= base.Data.Damper;
				suspensionSpring.TargetPosition = 0f;
				wc.SuspensionSpring = suspensionSpring;
				float num2 = base.Data.FrictionScale * 1f;
				float num3 = num2 * 0.5f;
				float num4 = _wc.Mass / mass;
				wc.AngularVelocityFrictionScale = Mathf.Lerp(25f, 1f, Mathf.Clamp01(num4 * 100f / 5f));
				wc.CreateFrictionCurves(base.Data.SlipForwardExtremum, num2 * base.Data.TractionForward, base.Data.SlipForwardAsymptote, num3 * base.Data.TractionForward, base.Data.SlipSidewaysExtremum, num2 * base.Data.TractionSideways, base.Data.SlipSidewaysAsymptote, num3 * base.Data.TractionSideways);
				wc.ClearIgnoredGameObjects();
				wc.IgnoreGameObjectInRaycast(_wheelMeshCollider);
				wc.IgnoreGameObjectInRaycast(_sphereCollider);
			}
		}

		private void WheelParametersChanged(object sender, EventArgs e)
		{
			RebuildWheel();
		}
	}
}
