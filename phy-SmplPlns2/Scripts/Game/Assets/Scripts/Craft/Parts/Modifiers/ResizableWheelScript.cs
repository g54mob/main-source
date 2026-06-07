using System;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Simulation.CustomWheelCollider;
using Assets.Scripts.Levels;
using Assets.Scripts.Multiplayer.SyncData;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ResizableWheelScript : PartModifierScript, IVariableOutput, IWheelPart, ICarEngineWheel
	{
		private bool _aircraftStructureChanged;

		private float _currentTurningAngle;

		private CarEngineScript _engine;

		private float _engineTorque;

		private float _functionalHealth = 1f;

		private PartConnection _partConnection;

		private Transform _placementCollider;

		private SingleSoundManager _soundManager;

		private GameObject _sphereCollider;

		private string _tireDirection;

		private GameObject _tireGameObject;

		private Transform _tireMeshParent;

		private string _tireName;

		private ParticleSystem _tireSmoke;

		private float _torqueDirection;

		private float _touchdownSquealDuration;

		private Transform _turningRoot;

		private InputControllerScript _turnInput;

		private ResizableWheelCollider _wc;

		private Transform _wheel;

		private GameObject _wheelMeshCollider;

		private GameObject _wheelRoot;

		public bool Enabled { get; set; }

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

		bool IWheelPart.IsGrounded => _wc.IsGrounded;

		public ResizableWheelData ResizableWheel { get; set; }

		public float Rpm => Mathf.Abs(_wc.Rpm);

		public float SpringReductionCoefficient { get; set; }

		public string TurnActivationGroup
		{
			get
			{
				if (!(_turnInput == null))
				{
					return _turnInput.InputController.ActivationGroup;
				}
				return "0";
			}
		}

		public string TurningInput
		{
			get
			{
				if (!(_turnInput == null))
				{
					return _turnInput.InputController.Input;
				}
				return string.Empty;
			}
		}

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

		Vector3 IWheelPart.WheelPosition => _wc?.transform.position ?? base.transform.position;

		public float WheelRadius
		{
			get
			{
				Vector3 vector = base.PartScript.Part.PartScale ?? Vector3.one;
				return _wc.WheelRadius * (vector.y + vector.z) * 0.5f;
			}
		}

		float IWheelPart.WheelSpeed => _wc.SpeedOverGround;

		protected ResizableWheelCollider WheelCollider => _wc;

		private float TurningRate => ResizableWheel.TurningRate;

		[VariableOutput("Forward Slip")]
		private float FSlip => _wc.ForwardSlip;

		[VariableOutput("Sideways Slip")]
		private float HSlip => _wc.SidewaysSlip;

		[VariableOutput("Offroad")]
		private float Offroad
		{
			get
			{
				if (!_wc.Offroad)
				{
					return 0f;
				}
				return 1f;
			}
		}

		[VariableOutput("RPM")]
		private float RPM => _wc.Rpm;

		public void Initialize(ResizableWheelData resizableWheel)
		{
			SpringReductionCoefficient = 1f;
			ResizableWheel = resizableWheel;
		}

		public override void InitializePartSyncData(PartSyncData syncData)
		{
			base.InitializePartSyncData(syncData);
			syncData.RegisterValue(new SyncFloat
			{
				Value = () => _wc?.Rpm ?? 0f,
				ValueRead = delegate(float x)
				{
					if (_wc != null)
					{
						_wc.Rpm = x;
					}
				}
			});
		}

		public override void OnBeginReposition()
		{
			base.OnBeginReposition();
			if (_wc != null)
			{
				_wc.BrakeInput = 0f;
				_wc.DisableParkingBrake();
			}
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				float value = UnityEngine.Random.value;
				if (value < 0.3f && _turnInput != null)
				{
					_turnInput = null;
					_functionalHealth = Mathf.Max(0f, _functionalHealth - UnityEngine.Random.value);
				}
				else if (value < 0.6f)
				{
					_functionalHealth = Mathf.Max(0f, _functionalHealth - UnityEngine.Random.value);
				}
			}
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			if (ResizableWheel.Direction == "Normal")
			{
				ResizableWheel.Direction = "Reversed";
			}
			else
			{
				ResizableWheel.Direction = "Normal";
			}
		}

		public void SetEngineTorque(float engineTorque)
		{
			_engineTorque = engineTorque;
		}

		protected virtual void Awake()
		{
			_wheelMeshCollider = Utilities.FindFirstGameObjectMyselfOrChildren("MeshCollider", base.PartScript.gameObject);
			_sphereCollider = Utilities.FindFirstGameObjectMyselfOrChildren("SphereCollider", base.PartScript.gameObject);
		}

		protected void OnDestroy()
		{
			if (FloatingOriginScript.Instance != null)
			{
				FloatingOriginScript.Instance.Repositioned -= OnFloatingOriginChanged;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightDefault);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void ActivateTireMesh(string tireName)
		{
			if (!(_tireName != tireName) && !(_tireDirection != ResizableWheel.Direction))
			{
				return;
			}
			_tireName = tireName;
			_tireDirection = ResizableWheel.Direction;
			MeshRenderer[] componentsInChildren;
			if (_tireGameObject != null)
			{
				componentsInChildren = _tireGameObject.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(renderer, destroy: true);
				}
				UnityEngine.Object.Destroy(_tireGameObject);
				_tireGameObject = null;
			}
			_tireGameObject = Utilities.FindFirstGameObjectMyselfOrChildren(tireName, base.PartScript.gameObject);
			_tireGameObject = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/" + tireName)) as GameObject;
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Rim", _tireGameObject);
			if (ResizableWheel.HideRims)
			{
				gameObject?.SetActive(value: false);
			}
			_tireGameObject.transform.SetParent(_tireMeshParent, worldPositionStays: false);
			_tireGameObject.transform.localPosition = Vector3.zero;
			_tireGameObject.name = tireName;
			componentsInChildren = _tireGameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer2 in componentsInChildren)
			{
				base.PartScript.PartMaterialScript.AddRenderer(renderer2);
			}
			base.PartScript.PartMaterialScript.InitializeMaterial();
			_tireGameObject.SetActive(value: true);
			switch (tireName)
			{
			case "TireTractor":
			case "TireTractor2":
			case "TireATV":
				if (ResizableWheel.Direction == "Reversed")
				{
					gameObject.transform.SetParent(_tireGameObject.transform.parent, worldPositionStays: true);
					_tireGameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
					gameObject.transform.SetParent(_tireGameObject.transform, worldPositionStays: true);
				}
				break;
			}
		}

		private void DisableSuspension()
		{
			_wc.SuspensionEnabled = false;
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("NoSuspensionCollider", base.PartScript.gameObject);
			ResizableWheelColliderScript resizableWheelColliderScript = base.PartScript.Body.gameObject.AddComponent<ResizableWheelColliderScript>();
			resizableWheelColliderScript.Collider = gameObject.GetComponent<SphereCollider>();
			resizableWheelColliderScript.WheelCollider = _wc;
			gameObject.SetActive(value: true);
			gameObject.transform.parent = WheelCollider.transform.parent;
		}

		private void InitializeForDesigner()
		{
			ResizableWheel.WheelParametersChanged += WheelParametersChanged;
		}

		private void InitializeForFlight()
		{
			_soundManager = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.SkidAudio, AudioStore.Rumble);
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Physics", base.PartScript.gameObject);
			if (gameObject != null)
			{
				gameObject.SetActive(value: true);
				_wc = gameObject.GetComponent<ResizableWheelCollider>();
				SetRigidBody(base.PartScript.Body.RigidBody);
				_wc.SuspensionDistance = ResizableWheel.SuspensionDistance;
				_wc.BrakeTorque = ResizableWheel.BrakeTorque;
				_wc.Mass = Mathf.Max(ResizableWheel.Mass, 0.25f);
				_wc.CollideWithAircraftLayer = true;
				_wc.OnFastTouchdown += OnFastTouchdown;
				if (ResizableWheel.EngineId > 0)
				{
					_wc.MaxAngularVelocity = ResizableWheel.MaxAngularVelocity;
				}
				PartData partById = base.PartScript.Aircraft.GetPartById(ResizableWheel.EngineId);
				if (partById != null)
				{
					CarEngineScript modifier = partById.PartScript.GetModifier<CarEngineScript>();
					if (modifier != null)
					{
						_engine = modifier;
						_engine.AddWheel(this);
					}
				}
				if (ResizableWheel.Direction == "Normal")
				{
					_torqueDirection = -1f;
				}
				else
				{
					_torqueDirection = 1f;
				}
				UpdateWheelColliderSettings();
			}
			if (base.PartScript.Part.PartConnections.Count > 0)
			{
				_partConnection = base.PartScript.Part.PartConnections[0];
			}
			_wheelMeshCollider.SetActive(value: false);
			_sphereCollider.SetActive(value: true);
			base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
			FloatingOriginScript.Instance.Repositioned += OnFloatingOriginChanged;
		}

		private void OnAircraftStructureChanged()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_aircraftStructureChanged = true;
			}
		}

		private void OnFastTouchdown(float overStress)
		{
			if (base.PartScript.ConnectedToMainCockpit)
			{
				base.PartScript.Aircraft.OnFastTouchdown(overStress);
			}
			if (!_wc.Offroad)
			{
				_tireSmoke?.Play();
				_touchdownSquealDuration = 0.3f;
			}
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_aircraftStructureChanged)
			{
				ProcessAircraftStructureChanged();
			}
			bool flag = true;
			if (!WheelDisconnected)
			{
				WheelCollider.MotorTorque = _engineTorque * _torqueDirection * _functionalHealth;
			}
			else
			{
				flag = false;
			}
			Vector3 vector = Vector3.ProjectOnPlane(Vector3.down, _turningRoot.right);
			if (Mathf.Abs(vector.y) < 0.1f)
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
				vector.Normalize();
				Vector3 vector2 = base.transform.InverseTransformVector(vector);
				float num = Mathf.Atan2(0f - Vector3.up.z, 0f - Vector3.up.y);
				float num2 = Mathf.Atan2(vector2.z, vector2.y) - num;
				_wheelRoot.transform.localEulerAngles = new Vector3(num2 * 57.29578f, 0f, 0f);
			}
			else if (WheelCollider.enabled)
			{
				WheelCollider.enabled = false;
				_wheelMeshCollider.SetActive(value: true);
			}
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginUpdatedEventArgs e)
		{
			_wc.DisableParkingBrakeImmediate();
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			Enabled = true;
			base.PartScript.ThudSoundDisabled = true;
			_wheelRoot = Utilities.FindFirstGameObjectMyselfOrChildren("WheelRoot", base.PartScript.gameObject);
			_turnInput = base.PartScript.GetModifier<InputControllerScript>();
			_wheel = Utilities.FindFirstGameObjectMyselfOrChildren("Wheel", base.PartScript.gameObject).transform;
			_turningRoot = Utilities.FindFirstGameObjectMyselfOrChildren("TurningRoot", base.PartScript.gameObject).transform;
			_placementCollider = Utilities.FindFirstGameObjectMyselfOrChildren("PlacementCollider", base.PartScript.gameObject).transform;
			_tireMeshParent = Utilities.FindFirstGameObjectMyselfOrChildren("VisualMeshes", base.PartScript.gameObject).transform;
			_tireSmoke = Utilities.GetFirstChild<ParticleSystem>("TireSmokeParticles", base.PartScript.gameObject);
			if (frame.CraftLoadContext == CraftLoadContext.Flight)
			{
				InitializeForFlight();
			}
			else if (frame.CraftLoadContext == CraftLoadContext.Designer)
			{
				InitializeForDesigner();
			}
			RebuildWheel();
			if (frame.CraftLoadContext == CraftLoadContext.Flight && !ResizableWheel.EnableSuspension)
			{
				DisableSuspension();
			}
			base.PartScript.PartMaterialScript.BakeMeshData();
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_aircraftStructureChanged)
			{
				ProcessAircraftStructureChanged();
			}
			UpdateWheel();
		}

		private void ProcessAircraftStructureChanged()
		{
			_aircraftStructureChanged = false;
			SetRigidBody(base.PartScript.Body.RigidBody);
			UpdateWheelColliderSettings();
		}

		private void RebuildWheel()
		{
			_wheel.localScale = new Vector3(ResizableWheel.ThicknessScale, ResizableWheel.Radius, ResizableWheel.Radius);
			if (_wc != null)
			{
				_wc.WheelRadius = ResizableWheel.Radius;
				Vector3 center = _wc.Center;
				center.x = -0.12f * ResizableWheel.ThicknessScale;
				_wc.Center = center;
			}
			if (_tireSmoke != null && _wc != null)
			{
				_tireSmoke.transform.localPosition = _wc.Center + Vector3.down * ResizableWheel.Radius;
				ParticleSystem.ShapeModule shape = _tireSmoke.shape;
				shape.scale = Vector3.one * (ResizableWheel.ThicknessScale * 0.24f);
			}
			float num = 1f;
			float num2 = 1f;
			if (ResizableWheel.Tire == "Normal" || ResizableWheel.Tire == "LandingGear" || ResizableWheel.Tire == "Futuristic")
			{
				num = 1f;
				num2 = 1f;
			}
			else if (ResizableWheel.Tire == "Street" || ResizableWheel.Tire == "Racing")
			{
				num = 1.1f;
				num2 = 0.7f;
			}
			else if (ResizableWheel.Tire == "Tractor" || ResizableWheel.Tire == "Tractor2")
			{
				num = 0.9f;
				num2 = 1.1f;
			}
			else
			{
				num = 0.9f;
				num2 = 1.1f;
			}
			ActivateTireMesh("Tire" + ResizableWheel.Tire);
			if (_wc != null)
			{
				_wc.SetWheelFrictionScalars(num, num2);
			}
			_placementCollider.localScale = new Vector3(ResizableWheel.ThicknessScale / 4f, ResizableWheel.Radius * 2f, ResizableWheel.Radius * 2f);
			_placementCollider.transform.position = _wheelMeshCollider.transform.position;
		}

		private void SetRigidBody(IRigidBody rigidBody)
		{
			_wc.Rigidbody = rigidBody;
			if (rigidBody != null)
			{
				rigidBody.maxDepenetrationVelocity = 1f;
			}
		}

		private void UpdateWheel()
		{
			if (!_wc.enabled)
			{
				return;
			}
			if (_wc.Rigidbody != null)
			{
				float num = 0f;
				AircraftScript aircraft = base.PartScript.Aircraft;
				float num2 = 1f;
				if (aircraft.Controls.Brake > 0f)
				{
					_wc.BrakeInput = aircraft.Controls.Brake * _functionalHealth;
					num2 = 2f;
				}
				else if (_wc != null)
				{
					_wc.BrakeInput = 0f;
				}
				if (_wc.IsGrounded)
				{
					float f = _wc.ForwardSlip / _wc.ForwardFriction.AsymptoteSlip * num2;
					num = (Mathf.Max(b: Mathf.Abs(_wc.SidewaysSlip / _wc.SidewaysFriction.AsymptoteSlip * 4f), a: Mathf.Abs(f)) * _wc.SurfaceFriction - 1f) / 5f;
					num = Mathf.Clamp(num, 0f, 1f);
					num *= num;
				}
				else if (_tireSmoke.isPlaying || _touchdownSquealDuration > 0f)
				{
					_tireSmoke.Stop();
					_touchdownSquealDuration = 0f;
				}
				if (_soundManager != null && (num > 0f || _touchdownSquealDuration > 0f) && base.PartScript.EstimateOfUnderwaterPercent < 0.2f)
				{
					if (_touchdownSquealDuration > 0f)
					{
						_touchdownSquealDuration -= Time.deltaTime;
						num = 1f;
					}
					if (!_wc.Offroad)
					{
						_soundManager.AddSound(base.transform.position, num);
					}
				}
			}
			if (_turnInput != null)
			{
				float target = _turnInput.Value * ResizableWheel.TurningAngle;
				if (WheelDisconnected)
				{
					target = 0f;
				}
				_currentTurningAngle = Utilities.StepTowards(_currentTurningAngle, TurningRate * Time.deltaTime, target);
				if (_wc != null && ResizableWheel.TurningAngle > 0f && _turnInput != null)
				{
					_turningRoot.localRotation = Quaternion.Euler(0f, _currentTurningAngle, 0f);
				}
			}
		}

		private void UpdateWheelColliderSettings()
		{
			List<PartData> connectedParts = _wc.ConnectedParts;
			connectedParts.Clear();
			PartGraph.GetConnectedParts(base.PartScript.Part, breakOnRigidBodyBoundary: false, connectedParts);
			GroupCenterOfMass groupCenterOfMass = new GroupCenterOfMass(connectedParts);
			Vector3 vector = WheelCollider.transform.InverseTransformPoint(groupCenterOfMass.CenterOfMass);
			vector.y = 0f;
			float magnitude = vector.magnitude;
			JointSpringSource suspensionSpring = default(JointSpringSource);
			float num = ResizableWheel.SuspensionDistance * (1f - ResizableWheel.SuspensionStiffness);
			suspensionSpring.Spring = groupCenterOfMass.LoadedMass * 9.81f / num;
			suspensionSpring.Damper = suspensionSpring.Spring / 50f;
			_wc.NoSuspensionTraction = groupCenterOfMass.LoadedMass * 9.81f * 0.9f;
			if (magnitude > 1f)
			{
				suspensionSpring.Spring /= magnitude;
				suspensionSpring.Damper /= magnitude;
				_wc.NoSuspensionTraction /= magnitude;
			}
			suspensionSpring.Spring *= SpringReductionCoefficient;
			suspensionSpring.Damper *= SpringReductionCoefficient;
			_wc.NoSuspensionTraction *= SpringReductionCoefficient;
			suspensionSpring.Spring *= ResizableWheel.Spring;
			suspensionSpring.Damper *= ResizableWheel.Damper;
			suspensionSpring.TargetPosition = 0f;
			_wc.SuspensionSpring = suspensionSpring;
			float num2 = ResizableWheel.FrictionScale * 1.5f;
			float num3 = num2 * 0.75f;
			float num4 = ResizableWheel.Radius * _wc.Mass;
			float value = suspensionSpring.Spring / 4000f / num4;
			_wc.AngularVelocityFrictionScale = Mathf.Clamp(value, 1f, 25f);
			_wc.CreateFrictionCurves(ResizableWheel.SlipForwardExtremum, num2 * ResizableWheel.TractionForward, ResizableWheel.SlipForwardAsymptote, num3 * ResizableWheel.TractionForward, ResizableWheel.SlipSidewaysExtremum, num2 * ResizableWheel.TractionSideways, ResizableWheel.SlipSidewaysAsymptote, num3 * ResizableWheel.TractionSideways);
			if (_engine != null)
			{
				bool flag = false;
				PartData part = _engine.PartScript.Part;
				foreach (PartData item in connectedParts)
				{
					if (item == part)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					_engine.RemoveWheel(this);
				}
			}
			_wc.ClearIgnoredGameObjects();
			_wc.IgnoreGameObjectInRaycast(_placementCollider.gameObject);
			_wc.IgnoreGameObjectInRaycast(_wheelMeshCollider);
			_wc.IgnoreGameObjectInRaycast(_sphereCollider);
		}

		private void WheelParametersChanged(object sender, EventArgs e)
		{
			RebuildWheel();
			Designer.Instance.OnAircraftStructureChanged();
		}

		void IVariableOutput.UpdateOutputs()
		{
		}
	}
}
