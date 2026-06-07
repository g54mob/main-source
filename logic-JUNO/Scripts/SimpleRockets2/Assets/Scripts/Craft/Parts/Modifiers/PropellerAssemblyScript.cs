using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Input;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller;
using Assets.Scripts.Design;
using Assets.Scripts.Ui.Inspector;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Design;
using ModApi.Flight;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;
using UnityEngine.Rendering;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PropellerAssemblyScript : PartModifierScript<PropellerAssemblyData>, IAnalyzePerformance, IDesignerStart, IGameLoopItem, IDesignerUpdate, IFlightStart, IFlightUpdate, IFlightFixedUpdate
	{
		private class InspectorModelInfo
		{
			public string Horsepower => $"{HorsepowerVal:0.0hp}";

			public float HorsepowerVal { get; private set; }

			public string Thrust => Units.GetForceString(ThrustVal);

			public string ThrustToMotorTorque => Units.GetTorqueString(ThrustToMotorTorqueVal);

			public float ThrustToMotorTorqueVal { get; private set; }

			public float ThrustVal { get; private set; }

			public string Twr => $"{TwrVal:0.0}";

			public float TwrVal { get; private set; }

			public void Update(Vector3 thrustVec, float craftMass, float motorTorque, float rpm)
			{
				ThrustVal = thrustVec.magnitude;
				float num = craftMass * 9.81f;
				TwrVal = ThrustVal / num;
				ThrustToMotorTorqueVal = ThrustVal / motorTorque;
				HorsepowerVal = motorTorque * rpm / 7127f;
			}
		}

		private class PropellerDebris : MonoBehaviour, ICraftDebris
		{
			private Rigidbody _body;

			public Rigidbody RigidBody => _body;

			public Transform Transform => RigidBody.transform;

			public static PropellerDebris Create(PropellerAssemblyScript propScript, Transform bladeRoot, Collider collider, float bladeLength, Vector3 rootPos, Vector3 bladeTipDir, Vector3 angularVelocity, bool fromCollision)
			{
				PropellerDebris propellerDebris = new GameObject("PropellerDebris").AddComponent<PropellerDebris>();
				propellerDebris.Initialize(propScript, bladeRoot, collider, bladeLength, rootPos, bladeTipDir, angularVelocity, fromCollision);
				return propellerDebris;
			}

			private void Initialize(PropellerAssemblyScript propScript, Transform bladeRoot, Collider collider, float bladeLength, Vector3 rootPos, Vector3 bladeTipDir, Vector3 angularVelocity, bool fromCollision)
			{
				Vector3 b = -Vector3.Cross(bladeTipDir, angularVelocity).normalized;
				Vector3 position = rootPos + 0.5f * bladeLength * bladeTipDir;
				float num = angularVelocity.magnitude * (fromCollision ? 1f : 0.1f);
				float num2 = ((!fromCollision) ? 1 : (-1));
				_body = base.gameObject.AddComponent<Rigidbody>();
				_body.mass = propScript.Data.CalculateSingleBladeMass() * 0.01f;
				_body.maxAngularVelocity = 100f;
				_body.angularVelocity = num * num2 * angularVelocity.normalized;
				_body.transform.SetPositionAndRotation(position, bladeRoot.rotation);
				_body.angularDrag = 0.5f;
				_body.drag = 0.25f;
				float num3 = Mathf.Min(num * (fromCollision ? 0.5f : 3f), 50f);
				Vector3 normalized = Vector3.Lerp(num2 * bladeTipDir, b, 0.5f).normalized;
				_body.velocity = normalized * num3;
				bladeRoot.parent = _body.transform;
				collider.transform.parent = _body.transform;
				_body.centerOfMass = Vector3.zero;
				propScript.PartScript.CraftScript.AddDebris(this);
				if (fromCollision)
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.PartCollisionGround, rootPos, 0.5f);
				}
				else
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.DisconnectPart, rootPos, 0.1f);
				}
			}
		}

		private const float MaxAlphaSpeed = 1000f;

		private const int MaxInstancedMeshes = 1023;

		private const float MaxSpreadSpeed = 1000f;

		private const float MinRpmForBlurredBlades = 50f;

		private static readonly int AlphaOverrideShaderId = Shader.PropertyToID("_AlphaOverride");

		private List<BladeAssembly> _additionalPropellers = new List<BladeAssembly>();

		private List<BladeAssembly> _allPropellers = new List<BladeAssembly>();

		private float _analysisBladePitch = 1f;

		private SliderModel _analysisPitchSlider;

		private float _analysisRpmPercent = 1f;

		private SliderModel _analysisRpmSlider;

		private AudioSource _audio;

		private PropAssemblyConfig _config;

		private ElectricMotorScript _connectedMotor;

		private InputControllerScript _connectedMotorInputController;

		private bool _connectedMotorUpdated;

		private float _currentPropBlurAlpha;

		private float _diameterScaled;

		private Vector3 _dragForce;

		private float _dragTorqueMag;

		private float _enteredWaterTime;

		private Dictionary<AttachPointScript, Vector3> _initialAttachpointPositions = new Dictionary<AttachPointScript, Vector3>();

		private InspectorModelInfo _inspectorInfo;

		private bool _isConnectedDirectlyToMotor;

		private Joint _joint;

		private Vector3 _lastAV;

		private float _lastRpmReductionScalar;

		private Vector3 _liftForce;

		private float _localAngularVelocity;

		private BladeAssembly _masterPropeller;

		private Material _masterPropellerSharedMat;

		private Mesh _masterPropellerSharedMesh;

		private List<IRendererMaterialMap> _nonInstancedPropRenderers;

		private IInputController _pitchInput;

		private Matrix4x4[][] _propBlurMatrices;

		private Dictionary<BladeAssembly, List<Transform>> _propBlurMeshes = new Dictionary<BladeAssembly, List<Transform>>();

		private Transform _propBlurRoot;

		private Transform _propContainer;

		private Vector3 _propContainerInitialRotation;

		private Rigidbody _propellerBody;

		private Dictionary<Collider, Transform> _propellerColliderMap;

		private Rigidbody _propellerConnectedBody;

		private float _propellerPitchDegrees;

		private bool _propIsBroken;

		private PropellerScript _propPhysics;

		private Transform _propSpinner;

		private ITimeManager _timeManager;

		private bool _transActive;

		private BoxCollider _waterCollider;

		private PartColliderScript _waterColliderScript;

		public Aerofoil Airfoil { get; private set; }

		public float AnalysisMaxRpm
		{
			get
			{
				if (!(ConnectedMotor != null))
				{
					return 10000f;
				}
				return ConnectedMotor.Data.Rpm;
			}
		}

		public int BladeCount => base.Data.BladeCount;

		public float ChordScale => base.Data.ChordScale;

		public Transform ColliderContainer { get; private set; }

		public ElectricMotorScript ConnectedMotor => _connectedMotor;

		public float Diameter => base.Data.Diameter;

		public float DynamicThrustScalar { get; set; } = 1f;

		public bool EngineDestroyed { get; private set; }

		public bool IsActivelyPowered
		{
			get
			{
				if (ConnectedMotor != null)
				{
					return ConnectedMotor.AppliedMotorTorque != 0f;
				}
				return false;
			}
		}

		public bool PerformanceAnalysisDisplayed
		{
			get
			{
				if (_analysisRpmSlider != null && _propPhysics != null && Game.Instance.Designer.SelectedPart == base.PartScript)
				{
					return Game.Instance.Designer.PerformanceAnalysis.Visible;
				}
				return false;
			}
		}

		public bool PropellerPhysicsEnabled { get; set; } = true;

		public float PropellerPitchDegrees
		{
			get
			{
				return _propellerPitchDegrees;
			}
			set
			{
				if (value != _propellerPitchDegrees)
				{
					_propellerPitchDegrees = value;
					UpdatePitchRepresentation();
				}
			}
		}

		public float Rpm { get; private set; }

		public float RpmAbs => Mathf.Abs(Rpm);

		public float RpmPhysical { get; private set; }

		public float RpmPhysicalAbs => Mathf.Abs(RpmPhysical);

		public bool RpmReductionAvailable => _isConnectedDirectlyToMotor;

		public float Thrust => _liftForce.magnitude;

		public bool UsesMachNumber => false;

		public bool WindmillActive
		{
			get
			{
				if (!IsActivelyPowered)
				{
					return _propPhysics != null;
				}
				return false;
			}
		}

		protected virtual float RpmReductionScalar => ConnectedMotor?.RpmReductionScalar ?? 1f;

		private float AnalysisRpm => _analysisRpmPercent * AnalysisMaxRpm;

		public void DesignerStart(in DesignerFrameData frame)
		{
			CommonStart();
			Airfoil = Game.Instance.ResourceLoader.LoadAirfoil("NACAPROP");
			CreatePropPhysicsScript();
			_propPhysics.SimulateRealtime = false;
			base.Data.UpdateStyleProperties();
			UpdateDesignerConnectedMotor();
			SetPitchInputControllerVisibility(base.Data.IsManual);
		}

		public void DesignerUpdate(in DesignerFrameData frame)
		{
			PropellerPitchDegrees = GetPitchInput() * base.Data.MaxPitch;
			if (PerformanceAnalysisDisplayed)
			{
				SimulateForPerformanceAnalysis();
			}
			if (base.Data.PropertiesOpen && _connectedMotorInputController != null)
			{
				float num = -30f * Time.deltaTime;
				num *= (float)((!_connectedMotorInputController.Data.Invert) ? 1 : (-1));
				_propContainer.transform.localRotation *= Quaternion.Euler(0f, num, 0f);
			}
		}

		public void FlightFixedUpdate(in FlightFrameData frame)
		{
			if (PropellerPhysicsEnabled)
			{
				_propPhysics.DoFixedUpdate();
			}
			if (RpmReductionAvailable)
			{
				UpdateRpmReduction();
			}
			if (!EngineDestroyed && PropellerPhysicsEnabled)
			{
				_localAngularVelocity = Utilities.PhysicsUtils.GetAngularVelocityAroundAxis(_config.PropsContainer.up, Quaternion.identity, _propellerBody.angularVelocity);
				RpmPhysical = (0f - _localAngularVelocity) * (30f / MathF.PI) * (float)((!base.Data.ReverseBladeDirection) ? 1 : (-1));
				Rpm = RpmPhysical / RpmReductionScalar;
				if (_joint != null)
				{
					_dragTorqueMag = CalculateDragTorqueFromForce(_dragForce) * RpmReductionScalar;
					Vector3 dragTorque = -_propellerBody.angularVelocity.normalized * _dragTorqueMag;
					dragTorque = PreventWaterDragSpikes(dragTorque);
					_propellerBody.AddTorque(dragTorque);
				}
				bool flag = base.PartScript.WaterPhysics.UnderWaterAmount == 1f;
				bool flag2 = base.PartScript.WaterPhysics.UnderWaterAmount > 0f;
				float num = Mathf.Max(0f, (float)(base.Data.IsWaterProp ? 1 : (flag ? 100 : ((!flag2) ? 1 : 1000))) * RpmAbs * _diameterScaled * 0.00025f / base.Data.SpinTolerance - 1f);
				base.PartScript.TakeDamage(num * frame.DeltaTime, PartDamageType.Overspin);
			}
			else
			{
				Rpm = 0f;
				_liftForce = Vector3.zero;
				_dragForce = Vector3.zero;
				_dragTorqueMag = 0f;
			}
			_lastAV = _propellerBody.angularVelocity;
			_lastRpmReductionScalar = RpmReductionScalar;
			UpdateDynamicPhysicsScalars();
			if (WindmillActive && PropellerPhysicsEnabled)
			{
				WindmillPropeller();
			}
		}

		public void FlightStart(in FlightFrameData frame)
		{
			CommonStart();
			base.PartScript.WaterPhysics.WaterEntered += OnWaterEntered;
			base.PartScript.PartGroup.Initialized += OnPartGroupInitialized;
			_inspectorInfo = new InspectorModelInfo();
			Airfoil = Game.Instance.ResourceLoader.LoadAirfoil("NACAPROP");
			_diameterScaled = Mathf.Pow(Diameter, 0.4f);
			BodyScript bodyScript = base.PartScript.BodyScript as BodyScript;
			_propellerBody = bodyScript.RigidBody;
			if (bodyScript.Joints.Count > 0)
			{
				StoreConnectedBodyInfo();
				CreatePropPhysicsScript();
				_propellerBody.ResetInertiaTensor();
				_propellerBody.angularDrag = 0.05f;
				bodyScript.UpdateAngularDrag = false;
				PropellerPhysicsEnabled = true;
			}
			else
			{
				PropellerPhysicsEnabled = false;
			}
			base.PartScript.CraftScript.CraftStructureChanged += OnCraftStructureChanged;
			Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
			Collider[] array = componentsInChildren;
			foreach (Collider collider in array)
			{
				Collider[] array2 = componentsInChildren;
				foreach (Collider collider2 in array2)
				{
					if (collider != collider2)
					{
						Physics.IgnoreCollision(collider, collider2);
					}
				}
			}
			_timeManager = Game.Instance.FlightScene.TimeManager;
			_timeManager.TimeMultiplierModeChanging += OnTimeMultiplierModeChanging;
			_audio = base.transform.GetComponent<AudioSource>();
			_audio.time = UnityEngine.Random.Range(0f, _audio.clip.length);
		}

		public void FlightUpdate(in FlightFrameData frame)
		{
			UpdatePropBlurSpreadAndBladePitch();
			UpdatePropellerTransparency();
			_waterColliderScript.SelectionEnabledInFlight = _transActive;
			PropellerPitchDegrees = GetPitchInput() * base.Data.MaxPitch;
			if (_propIsBroken && _propellerColliderMap.Count == 0 && !base.PartScript.Data.IsDestroyed)
			{
				Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog($"{base.PartScript.Data.Name} [ID {base.PartScript.Data.Id}] has been destroyed due to impact damage.", FlightLogEntryCategory.CraftDamage, isDynamic: false, base.PartScript);
				base.PartScript.BodyScript.ExplodePart(base.PartScript, 1f);
			}
			if (_audio != null)
			{
				_audio.pitch = Mathf.Min(Time.timeScale * RpmAbs * (float)base.Data.BladeCount / 360f, 20f);
				_audio.volume = Mathf.Clamp01(Mathf.Pow((0.01f * RpmAbs * base.Data.MassDry + Thrust) * 0.001f, 0.25f));
				if (_audio.volume > 0.01f)
				{
					if (!_audio.isPlaying)
					{
						_audio.Play();
					}
				}
				else if (_audio.isPlaying)
				{
					_audio.Stop();
				}
			}
			if (Application.isEditor)
			{
				_ = _propPhysics != null;
			}
		}

		public override void OnAttachmentDestroyed(PartConnection.Attachment attachment)
		{
			base.OnAttachmentDestroyed(attachment);
			UpdateDesignerConnectedMotor();
		}

		public override bool OnCollision(IPartFlightCollision partCollision)
		{
			if (RpmAbs > 100f && _propellerColliderMap != null)
			{
				Collider collider = partCollision.Collision?.GetContact(0).thisCollider;
				if (collider != null && _propellerColliderMap.TryGetValue(collider, out var propRoot))
				{
					PropellerDebris.Create(this, propRoot, collider, base.Data.Radius, propRoot.transform.position, propRoot.transform.right, _lastAV / _lastRpmReductionScalar, fromCollision: true);
					_propellerBody.ResetCenterOfMass();
					_propellerColliderMap.Remove(collider);
					if (!_propIsBroken)
					{
						foreach (KeyValuePair<Collider, Transform> mapItem in _propellerColliderMap)
						{
							UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
							{
								if (_propellerColliderMap.TryGetValue(mapItem.Key, out propRoot))
								{
									PropellerDebris.Create(this, propRoot, mapItem.Key, base.Data.Radius, propRoot.transform.position, propRoot.transform.right, _propellerBody.angularVelocity, fromCollision: false);
									_propellerColliderMap.Remove(mapItem.Key);
									_propellerBody.ResetCenterOfMass();
								}
							}, UnityEngine.Random.Range(0.25f, 1.25f));
						}
					}
					_propPhysics.SimulateRealtime = false;
					_propIsBroken = true;
				}
			}
			return base.OnCollision(partCollision);
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			base.OnConnectedToPart(e);
			UpdateDesignerConnectedMotor();
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new SpacerModel()).UpdateAction = delegate
			{
				_inspectorInfo.Update(_liftForce, base.PartScript.CraftScript.Mass * 100f, MotorTorque(), Rpm);
			};
			model.Add(new TextModel("RPM", () => $"{Rpm:0}"));
			model.Add(new TextModel("Thrust", () => _inspectorInfo.Thrust));
			model.Add(new TextModel("Blade Pitch", () => Units.GetAngleString(PropellerPitchDegrees, 1)));
			if (_propPhysics != null)
			{
				model.Add(new TextModel("Effective AoA", () => Units.GetAngleString(_propPhysics.AngleOfAttack, 1)));
			}
			if (!Application.isEditor)
			{
				return;
			}
			if (_propPhysics != null)
			{
				model.Add(new TextModel("Geometric Pitch", () => Units.GetDistanceString(_propPhysics.GeometricPitch)));
				model.Add(new TextModel("Slip", () => $"{1f - _propPhysics.Slip:P}"));
				model.Add(new TextModel("Theoretical Max Spd.", () => Units.GetVelocityString(_propPhysics.TheoreticalMaxSpeed)));
			}
			model.Add(new TextModel("TWR", () => _inspectorInfo.Twr));
			model.Add(new TextModel("Motor Torque", () => Units.GetTorqueString(MotorTorque()))).DetermineVisibility = () => PowerInfoAvailable();
			model.Add(new TextModel("Horsepower", () => _inspectorInfo.Horsepower)).DetermineVisibility = () => PowerInfoAvailable();
			model.Add(new TextModel("Thrust/Motor Torque", () => _inspectorInfo.ThrustToMotorTorque)).DetermineVisibility = () => PowerInfoAvailable();
			if (_connectedMotor != null)
			{
				model.Add(new ToggleModel("RPM Governor", () => _connectedMotor.Data.ThrottleGovernorEnabled, delegate(bool x)
				{
					_connectedMotor.Data.ThrottleGovernorEnabled = x;
				})).DetermineVisibility = () => MotorAvailable();
				model.Add(new NumericInputModel("Governor tgt", () => _connectedMotor.Data.Rpm, delegate(double x)
				{
					_connectedMotor.Data.Rpm = (float)x;
				}, 0.0, null, (double x) => $"{x:0.#}")).DetermineVisibility = () => MotorAvailable() && _connectedMotor.Data.ThrottleGovernorEnabled;
			}
			bool MotorAvailable()
			{
				return _connectedMotor != null;
			}
			float MotorTorque()
			{
				return Mathf.Abs((_connectedMotor != null) ? _connectedMotor.AppliedMotorTorque : 0f) * 100f;
			}
			bool PowerInfoAvailable()
			{
				if (MotorAvailable())
				{
					return !_connectedMotor.Data.ThrottleGovernorEnabled;
				}
				return false;
			}
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Max Speed", () => Units.GetVelocityString(Mathf.Abs(_propPhysics.TheoreticalMaxSpeed)), null, "The theoretical max speed the propeller could propel an object with no slip.  Achieved speeds will be lower."));
			groupModel.Add(new TextModel("TWR", () => GetTwr(), null, "The Thrust to Weight ratio, or how much the engine can push relative to how heavy the craft is."));
			groupModel.Add(new TextModel("Thrust", () => Units.GetForceString(Thrust), null, "The push force of the propeller at the selected RPM, in the selected air density."));
			groupModel.Add(new TextModel("Max RPM (air)", () => GetMaxRpm(water: false), null, "How fast the propeller can spin before taking damage."));
			groupModel.Add(new TextModel("Max RPM (water)", () => GetMaxRpm(water: true), null, "How fast the propeller can spin before taking damage."));
			_analysisRpmPercent = 1f;
			_analysisRpmSlider = groupModel.Add(new SliderModel("RPM", () => _analysisRpmPercent, delegate(float x)
			{
				_analysisRpmPercent = Mathf.Max(0f, x);
			}));
			_analysisRpmSlider.ValueFormatter = (float x) => $"{Mathf.RoundToInt(AnalysisRpm)}";
			_analysisBladePitch = base.Data.MaxPitch;
			_analysisPitchSlider = groupModel.Add(new SliderModel("Blade Pitch", () => _analysisBladePitch, delegate(float x)
			{
				_analysisBladePitch = Mathf.Clamp(x, 1f, 89f);
			}, 1f, 89f, wholeNumbers: true));
			_analysisPitchSlider.ValueFormatter = (float x) => Units.GetAngleString(_analysisBladePitch, 0);
			_analysisPitchSlider.DetermineVisibility = () => base.Data.IsManual;
			string GetMaxRpm(bool water)
			{
				float num = base.Data.SpinTolerance * 4000f / Mathf.Pow(Diameter, 0.4f);
				num *= ((!water) ? 1f : (base.Data.IsWaterProp ? 1f : 0.01f));
				return $"{num:0}";
			}
			string GetTwr()
			{
				double surfaceGravity = (Game.Instance.Designer.PerformanceAnalysis as CraftPerformanceAnalysis).SelectedEnvironment.SurfaceGravity;
				double num = (double)Thrust / (surfaceGravity * (double)base.PartScript.CraftScript.Mass);
				return $"{num:0.00}";
			}
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			UpdateDesignerConnectedMotor(unsubscribeOnly: true);
			if (base.PartScript.PartGroup != null)
			{
				base.PartScript.PartGroup.Initialized -= OnPartGroupInitialized;
			}
			if (Game.InFlightScene)
			{
				_timeManager.TimeMultiplierModeChanging -= OnTimeMultiplierModeChanging;
			}
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			base.OnSymmetry(mode, originalPart, created);
			RebuildPropellerAssembly(repositionConnectedParts: true, mode);
		}

		public void RebuildPropellerAssembly(bool repositionConnectedParts, SymmetryMode? symmetry = null)
		{
			if (symmetry == SymmetryMode.Mirror)
			{
				base.Data.ReverseBladeDirection = !base.Data.ReverseBladeDirection;
			}
			Transform bladePrefabRoot = _masterPropeller.BladePrefabRoot;
			while (bladePrefabRoot.childCount != 0)
			{
				UnityEngine.Object.DestroyImmediate(bladePrefabRoot.GetChild(0).gameObject);
			}
			Vector3 localScale = _masterPropeller.Blade.localScale;
			_masterPropeller.Blade.localScale = Vector3.one;
			string styleBlade = base.Data.StyleBlade;
			GameObject gameObject = Resources.Load<GameObject>("Craft/Parts/Prefabs/Propellers/" + styleBlade + (base.Data.ReverseBladeDirection ? "Flipped" : string.Empty));
			if (gameObject != null)
			{
				GameObject obj = UnityEngine.Object.Instantiate(gameObject);
				obj.transform.parent = bladePrefabRoot;
				obj.transform.localEulerAngles = Vector3.zero;
				obj.transform.localPosition = Vector3.zero;
				_transActive = CalculateDesiredCombinedBladeTransparency() > 0f;
				obj.GetComponentInChildren<PartMeshScript>().UsesAlphaOverride = _transActive;
				_masterPropeller.Blade.localScale = localScale;
				UpdateHubStyle();
				CreatePropellersFromMaster();
				UpdateScale(repositionConnectedParts);
				if (_propPhysics != null)
				{
					_propPhysics.OnPropellerRebuilt(GetComponentInChildren<PropPhysicsInfoScript>());
				}
			}
			else
			{
				Debug.LogError("Couldn't load propeller: " + styleBlade);
			}
		}

		public void RegisterDragFromPropPhysics(Vector3 dragForce)
		{
			_dragForce = dragForce;
			if (float.IsNaN(dragForce.magnitude) || float.IsInfinity(dragForce.magnitude))
			{
				Debug.LogError($"Propeller drag force is NaN or Infinity, disabling propeller physics: {dragForce.magnitude}");
				PropellerPhysicsEnabled = false;
			}
		}

		public void RegisterLiftFromPropPhysics(Vector3 liftForce)
		{
			_liftForce = liftForce;
			if (float.IsNaN(liftForce.magnitude) || float.IsInfinity(liftForce.magnitude))
			{
				Debug.LogError($"Propeller lift force is NaN or Infinity, disabling propeller physics: {liftForce.magnitude}");
				PropellerPhysicsEnabled = false;
			}
		}

		public void ResetDesignerRotation()
		{
			if (_propContainer != null)
			{
				_propContainer.localEulerAngles = _propContainerInitialRotation;
			}
		}

		public void SetPitchInputControllerVisibility(bool visible)
		{
			if (_pitchInput != null && _pitchInput.Visible != visible)
			{
				_pitchInput.Visible = visible;
			}
		}

		public void UpdateBladeCount()
		{
			CreatePropellersFromMaster();
		}

		public void UpdatePitchRepresentation()
		{
			if (!EngineDestroyed)
			{
				float num = PropellerPitchDegrees;
				if (base.Data.ReverseBladeDirection)
				{
					num *= -1f;
				}
				num *= base.Data.PropellerPitchScale;
				float num2 = 360f / (float)base.Data.BladeCount;
				float num3 = 0f;
				foreach (BladeAssembly allPropeller in _allPropellers)
				{
					allPropeller.Root.localEulerAngles = new Vector3(0f, num3, 0f);
					RotateBlade(allPropeller, 0f, num);
					num3 += num2;
				}
			}
			OnDesignerPitchChanged();
		}

		public void UpdatePropDirection(bool syncToMotor)
		{
			RebuildPropellerAssembly(repositionConnectedParts: false);
			if (syncToMotor && _connectedMotorInputController != null && _connectedMotorInputController.Data.Invert != base.Data.ReverseBladeDirection)
			{
				_connectedMotorInputController.Data.Invert = base.Data.ReverseBladeDirection;
				Symmetry.SynchronizePartModifiers(_connectedMotor.PartScript);
			}
		}

		public void UpdateScale(bool repositionConnectedParts)
		{
			float num = (base.Data.Radius - _masterPropeller.Blade.localPosition.magnitude * 2f) / 1f;
			Vector3 localScale = new Vector3(num, num, num * ChordScale);
			foreach (BladeAssembly allPropeller in _allPropellers)
			{
				allPropeller.Blade.localScale = localScale;
			}
			if (Game.InFlightScene)
			{
				foreach (KeyValuePair<Collider, Transform> item in _propellerColliderMap)
				{
					item.Key.transform.localScale = Vector3.Scale(item.Key.transform.localScale, new Vector3(num, num, num * ChordScale));
				}
			}
			float num2 = base.Data.HubScale * num;
			_propSpinner.localScale = num2 * Vector3.one;
			if (Game.InDesignerScene)
			{
				float num3 = num2;
				for (int i = 0; i < base.PartScript.AttachPointScripts.Count; i++)
				{
					AttachPointScript attachPointScript = base.PartScript.AttachPointScripts[i];
					Vector3 localPosition = attachPointScript.transform.localPosition;
					Vector3 vector = _initialAttachpointPositions[attachPointScript];
					Vector3 localPosition2 = num3 * vector;
					attachPointScript.transform.localPosition = localPosition2;
					if (repositionConnectedParts && i == 0)
					{
						Vector3 vector2 = attachPointScript.transform.TransformDirection(attachPointScript.transform.localPosition - localPosition);
						base.PartScript.Transform.position += vector2;
					}
				}
			}
			else if (Game.InFlightScene)
			{
				AddWaterCollider();
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (Game.InDesignerScene)
			{
				foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
				{
					_initialAttachpointPositions.Add(attachPointScript, attachPointScript.transform.localPosition);
				}
			}
			CommonInitialization();
		}

		private static float CalculatePerBladeAlpha(float numBlades, float desiredCombinedTransparency)
		{
			return 1f - Mathf.Pow(desiredCombinedTransparency, 1f / numBlades);
		}

		private static Vector3 GetLocalFromWorldScale(Transform parentTrans, Vector3 worldScale)
		{
			Vector3 vector = parentTrans?.lossyScale ?? Vector3.one;
			return new Vector3(worldScale.x / vector.x, worldScale.y / vector.y, worldScale.z / vector.z);
		}

		private void AddWaterCollider()
		{
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				if (_waterCollider != null)
				{
					UnityEngine.Object.Destroy(_waterCollider.gameObject);
					UnityEngine.Object.DestroyImmediate(_waterCollider.GetComponent<PartColliderScript>());
					UnityEngine.Object.DestroyImmediate(_waterCollider.GetComponent<Collider>());
				}
				GameObject gameObject = new GameObject("WaterCollider");
				gameObject.transform.parent = base.transform;
				Transform obj = gameObject.transform;
				Vector3 localPosition = (gameObject.transform.localEulerAngles = Vector3.zero);
				obj.localPosition = localPosition;
				gameObject.layer = base.gameObject.layer;
				BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
				boxCollider.isTrigger = true;
				boxCollider.size = new Vector3(base.Data.Diameter, base.Data.Diameter, 0.1f);
				_waterColliderScript = gameObject.AddComponent<PartColliderScript>();
				_waterColliderScript.IsPrimary = true;
				_waterCollider = boxCollider;
				base.PartScript.InitializeColliders();
			});
		}

		private float CalculateDesiredCombinedBladeTransparency()
		{
			float result = 0f;
			if (Game.InFlightScene)
			{
				float num = ((RpmAbs < 50f) ? 0f : RpmAbs);
				result = 1f - Mathf.Lerp(1f, 0.6f, Mathf.Clamp01(num / 1000f));
			}
			return result;
		}

		private float CalculateDragTorqueFromForce(Vector3 dragForce)
		{
			Vector3 rhs = 0.5f * base.Data.Radius * base.transform.forward;
			return Vector3.Cross(dragForce, rhs).magnitude;
		}

		private void CommonInitialization()
		{
			_config = GetComponent<PropAssemblyConfig>();
			_masterPropeller = new BladeAssembly(_config.PropsContainer.Find("Propeller"));
			_propContainer = base.transform.Find("Hub");
			_propSpinner = _propContainer.Find("HubMesh/Mesh");
			_propBlurRoot = _config.PropsContainer.Find("PropBlur");
			_propContainerInitialRotation = _propContainer.transform.localEulerAngles;
			RebuildPropellerAssembly(repositionConnectedParts: false);
		}

		private void CommonStart()
		{
			_pitchInput = GetInputController("BladeAngle");
		}

		private void CreatePropellersFromMaster()
		{
			foreach (BladeAssembly additionalPropeller in _additionalPropellers)
			{
				UnityEngine.Object.DestroyImmediate(additionalPropeller.Root.gameObject);
			}
			_additionalPropellers.Clear();
			float num = 360f / (float)base.Data.BladeCount;
			float num2 = num;
			int num3 = 2;
			while (num3 <= base.Data.BladeCount)
			{
				Transform transform = UnityEngine.Object.Instantiate(_masterPropeller.Root.gameObject).transform;
				Vector3 vector = new Vector3(0f, num2, 0f);
				transform.parent = _masterPropeller.Root.parent;
				transform.localPosition = Quaternion.Euler(vector) * _masterPropeller.Root.localPosition;
				transform.localEulerAngles = vector;
				transform.localScale = _masterPropeller.Root.localScale;
				PropellerScript componentInChildren = transform.GetComponentInChildren<PropellerScript>();
				if (componentInChildren != null)
				{
					UnityEngine.Object.Destroy(componentInChildren);
				}
				_additionalPropellers.Add(new BladeAssembly(transform));
				num3++;
				num2 += num;
			}
			_allPropellers.Clear();
			_allPropellers.Add(_masterPropeller);
			_allPropellers.AddRange(_additionalPropellers);
			UpdatePitchRepresentation();
			if (!Physics.autoSyncTransforms)
			{
				Physics.SyncTransforms();
			}
			if (Game.InFlightScene)
			{
				ColliderContainer = new GameObject("Colliders").transform;
				ColliderContainer.parent = _config.PropsContainer.transform;
				ColliderContainer.localPosition = Vector3.zero;
				ColliderContainer.localEulerAngles = Vector3.zero;
				_propellerColliderMap = new Dictionary<Collider, Transform>();
				foreach (BladeAssembly allPropeller in _allPropellers)
				{
					Collider componentInChildren2 = allPropeller.Blade.GetComponentInChildren<Collider>();
					componentInChildren2.transform.parent = ColliderContainer;
					if (componentInChildren2.TryGetComponent<PartColliderScript>(out var component))
					{
						component.SelectionEnabledInFlight = true;
					}
					_propellerColliderMap.Add(componentInChildren2, allPropeller.Root);
				}
			}
			base.PartScript.PartMaterialScript.UpdateRenderers();
			StoreNonInstancedPropellerRenderers();
		}

		private void CreatePropPhysicsScript()
		{
			_propPhysics = new GameObject("PropPhysics").AddComponent<PropellerScript>();
			_propPhysics.transform.parent = _config.PropsContainer;
			Transform obj = _propPhysics.transform;
			Vector3 localPosition = (_propPhysics.transform.localEulerAngles = Vector3.zero);
			obj.localPosition = localPosition;
			_propPhysics.transform.localScale = Vector3.one;
			_propPhysics.Initialize(_propellerBody, _propellerConnectedBody, GetComponentInChildren<PropPhysicsInfoScript>());
		}

		private void DrawPropBlurMeshes()
		{
			if (_propBlurMatrices == null)
			{
				UpdatePropBlurMatrixCache();
			}
			float y = Mathf.Lerp(0f, base.Data.BladeBlurSpread, Mathf.Clamp01(RpmAbs / 1000f)) / (float)base.Data.BladeBlurCount;
			int num = 0;
			int num2 = 0;
			Vector3 lossyScale = _masterPropeller.BladeMesh.lossyScale;
			for (int i = 0; i < _allPropellers.Count; i++)
			{
				BladeAssembly bladeAssembly = _allPropellers[i];
				Quaternion rotation = bladeAssembly.Root.parent.rotation;
				Vector3 position = bladeAssembly.Root.position;
				Vector3 localEulerAngles = bladeAssembly.Root.localEulerAngles;
				Quaternion quaternion = Quaternion.Euler(new Vector3(localEulerAngles.x, localEulerAngles.y, localEulerAngles.z));
				Quaternion quaternion2 = Quaternion.Euler(0f, y, 0f);
				for (int j = 0; j < base.Data.BladeBlurCount; j++)
				{
					_propBlurMatrices[num][num2].SetTRS(position, rotation * quaternion, lossyScale);
					if (++num2 >= 1023)
					{
						num2 = 0;
						num++;
					}
					quaternion = quaternion2 * quaternion;
					if (j % 100 == 0)
					{
						quaternion.Normalize();
					}
				}
			}
			if (_masterPropellerSharedMat != null && _masterPropellerSharedMesh != null && _nonInstancedPropRenderers.Count > 0)
			{
				MaterialPropertyBlock materialPropertyBlockForNonCombinedMesh = base.PartScript.PartGroup.GetMaterialPropertyBlockForNonCombinedMesh(_nonInstancedPropRenderers[0]);
				Matrix4x4[][] propBlurMatrices = _propBlurMatrices;
				foreach (Matrix4x4[] array in propBlurMatrices)
				{
					Graphics.DrawMeshInstanced(_masterPropellerSharedMesh, 0, _masterPropellerSharedMat, array, array.Length, materialPropertyBlockForNonCombinedMesh, ShadowCastingMode.Off, receiveShadows: true, 31);
				}
			}
		}

		private ElectricMotorScript GetConnectedMotor(out bool isConnectedDirectlyToMotor)
		{
			ElectricMotorScript electricMotorScript = null;
			List<PartConnection> partConnections = base.PartScript.Data.PartConnections;
			isConnectedDirectlyToMotor = false;
			if (partConnections.Count > 0)
			{
				if (partConnections.Count > 1)
				{
					Debug.LogError("Propeller Assembly found more than one part connection, which currently yields undefined results...make sure we're getting the connection to the motor which spins the prop.");
				}
				electricMotorScript = partConnections[0].GetOtherPart(base.PartScript.Data).GetModifier<ElectricMotorData>()?.Script;
				isConnectedDirectlyToMotor = electricMotorScript != null;
			}
			if (Game.InFlightScene && electricMotorScript == null)
			{
				List<PartData> partsOnRigidBodyBoundary = PartGraph.GetPartsOnRigidBodyBoundary(base.PartScript.Data);
				if (partsOnRigidBodyBoundary != null && partsOnRigidBodyBoundary.Count > 0)
				{
					ElectricMotorData modifier = partsOnRigidBodyBoundary[0].GetModifier<ElectricMotorData>();
					if (modifier != null)
					{
						electricMotorScript = modifier.Script;
					}
				}
			}
			return electricMotorScript;
		}

		private float GetJointStability()
		{
			Vector3 position = base.PartScript.Data.AttachPoints[0].Position;
			Vector3 vector = base.transform.InverseTransformPoint(_propellerConnectedBody.transform.TransformPoint(_joint.anchor));
			return Vector3.Dot(position.normalized, vector.normalized);
		}

		private float GetPitchInput()
		{
			float value;
			switch (base.Data.PitchControlType)
			{
			case PropellerAssemblyData.PitchControl.Manual:
				value = (Game.InFlightScene ? _pitchInput.Value : ((float)(base.Data.PropertiesOpen ? 1 : 0)));
				break;
			case PropellerAssemblyData.PitchControl.Fixed:
				value = 1f;
				break;
			default:
				Debug.LogWarning("Unknown pitch control type: " + base.Data.PitchControlType);
				value = 0f;
				break;
			}
			return Mathf.Clamp(value, -1f, 1f);
		}

		private void LateUpdate()
		{
			if (Game.InFlightScene)
			{
				if (!_propIsBroken && RpmAbs > 50f)
				{
					DrawPropBlurMeshes();
				}
			}
			else if (_connectedMotorUpdated)
			{
				_connectedMotorUpdated = false;
				bool invert = _connectedMotorInputController.Data.Invert;
				if (base.Data.SyncWithMotor && base.Data.ReverseBladeDirection != invert)
				{
					base.Data.ReverseBladeDirection = invert;
					UpdatePropDirection(syncToMotor: false);
				}
			}
		}

		private void OnConnectedMotorChanged()
		{
			if (PerformanceAnalysisDisplayed)
			{
				_analysisRpmSlider.ForceRefreshValueText = true;
				(_analysisRpmSlider.ItemElement as SliderElement).Update();
			}
		}

		private void OnConnectedMotorInvertChanged(InputControllerData source)
		{
			_connectedMotorUpdated = true;
		}

		private void OnCraftStructureChanged()
		{
			StoreConnectedBodyInfo();
		}

		private void OnDesignerPitchChanged()
		{
			if (_analysisPitchSlider != null)
			{
				_analysisBladePitch = base.Data.MaxPitch;
				_analysisPitchSlider.Update();
			}
		}

		private void OnPartGroupInitialized(IPartGroupScript craftScript)
		{
			if (Game.InFlightScene)
			{
				UpdateSharedMeshAndMaterials();
			}
		}

		private void OnPropellerTransparencyActiveStateChanged(bool transparencyActive)
		{
			foreach (IRendererMaterialMap nonInstancedPropRenderer in _nonInstancedPropRenderers)
			{
				nonInstancedPropRenderer.UsesAlphaOverride = transparencyActive;
				nonInstancedPropRenderer.ReplaceOriginalMaterials(transparencyActive ? base.PartScript.PartGroup.MaterialTransparency : base.PartScript.PartGroup.Material, setAsCurrent: true);
			}
			UpdateSharedMeshAndMaterials();
			StoreNonInstancedPropellerRenderers();
		}

		private void OnTimeMultiplierModeChanging(TimeMultiplierModeChangedEvent e)
		{
			if (e.EnteredWarpMode && _propIsBroken)
			{
				base.PartScript.BodyScript.ExplodePart(base.PartScript, 0f);
			}
		}

		private void OnWaterEntered(IPartWaterPhysics source)
		{
			_enteredWaterTime = Time.fixedTime;
		}

		private Vector3 PreventWaterDragSpikes(Vector3 dragTorque)
		{
			if (ConnectedMotor != null && _enteredWaterTime > 0f)
			{
				float num = ConnectedMotor.Data.Torque * 0.01f * 5f;
				if (dragTorque.magnitude > num)
				{
					dragTorque = Vector3.ClampMagnitude(dragTorque, num);
				}
				if (Time.time - _enteredWaterTime > 1f)
				{
					_enteredWaterTime = -1f;
				}
			}
			return dragTorque;
		}

		private void RotateBlade(BladeAssembly blade, float neutralRotation, float pitchDegrees)
		{
			blade.Root.Rotate(new Vector3(0f - (pitchDegrees - neutralRotation), 0f, 0f), Space.Self);
		}

		private void SimulateForPerformanceAnalysis()
		{
			float propellerPitchDegrees = _propellerPitchDegrees;
			_propellerPitchDegrees = _analysisBladePitch;
			Rpm = AnalysisRpm;
			_propPhysics.UpdateWingShape();
			_propPhysics.Simulate(applyForces: false);
			_propellerPitchDegrees = propellerPitchDegrees;
		}

		private void StoreConnectedBodyInfo()
		{
			BodyScript bodyScript = base.PartScript.BodyScript as BodyScript;
			_propellerBody = bodyScript.RigidBody;
			if (bodyScript.Joints.Count > 0)
			{
				IBodyJoint bodyJoint = bodyScript.Joints[0];
				_joint = bodyJoint.Joints[0].Joint;
				_joint.breakTorque = float.PositiveInfinity;
				_propellerConnectedBody = bodyJoint.Body.RigidBody;
				_connectedMotor = GetConnectedMotor(out _isConnectedDirectlyToMotor);
				if (_propPhysics != null)
				{
					_propPhysics.RigidBodyToAddForceTo = _propellerConnectedBody;
				}
			}
		}

		private void StoreNonInstancedPropellerRenderers()
		{
			_nonInstancedPropRenderers = base.PartScript.PartMaterialScript.RendererMaps.Where((IRendererMaterialMap x) => x.ExcludeFromMeshCombine).ToList();
		}

		private void UpdateDesignerConnectedMotor(bool unsubscribeOnly = false)
		{
			if (_connectedMotorInputController != null)
			{
				_connectedMotorInputController.Data.InvertChanged -= OnConnectedMotorInvertChanged;
				_connectedMotorInputController = null;
			}
			_connectedMotor = GetConnectedMotor(out _isConnectedDirectlyToMotor);
			if (_connectedMotor != null)
			{
				_connectedMotorInputController = _connectedMotor.PartScript?.GetModifier<InputControllerScript>();
				if (!unsubscribeOnly && _connectedMotorInputController != null)
				{
					_connectedMotorInputController.Data.InvertChanged += OnConnectedMotorInvertChanged;
				}
			}
			OnConnectedMotorChanged();
		}

		private void UpdateDynamicPhysicsScalars()
		{
			float dynamicThrustScalar = (base.Data.IsWaterProp ? Mathf.Lerp(0.1f, 1f, base.PartScript.WaterPhysics.UnderWaterAmount) : 1f);
			DynamicThrustScalar = dynamicThrustScalar;
		}

		private void UpdateHubStyle()
		{
			string styleHub = base.Data.StyleHub;
			GameObject gameObject = Resources.Load<GameObject>("Craft/Parts/Prefabs/Propellers/" + styleHub);
			if (gameObject != null)
			{
				Transform transform = UnityEngine.Object.Instantiate(gameObject).transform;
				transform.parent = _propSpinner.parent;
				Vector3 localPosition = (transform.localEulerAngles = Vector3.zero);
				transform.localPosition = localPosition;
				transform.localScale = Vector3.one;
				UnityEngine.Object.DestroyImmediate(_propSpinner.gameObject);
				_propSpinner = transform;
			}
			else
			{
				Debug.LogError("Couldn't load prop hub: " + styleHub);
			}
		}

		private void UpdatePropBlurMatrixCache()
		{
			int num = BladeCount * base.Data.BladeBlurCount;
			int num2 = num / 1023 + 1;
			_propBlurMatrices = new Matrix4x4[num2][];
			for (int i = 0; i < num2; i++)
			{
				int num3 = i * 1023;
				int num4 = Mathf.Min(num - num3, 1023);
				_propBlurMatrices[i] = new Matrix4x4[num4];
			}
		}

		private void UpdatePropBlurSpreadAndBladePitch()
		{
			float num = Mathf.Lerp(0f, base.Data.BladeBlurSpread, Mathf.Clamp01(RpmAbs / 1000f)) / (float)base.Data.BladeBlurCount;
			foreach (KeyValuePair<BladeAssembly, List<Transform>> propBlurMesh in _propBlurMeshes)
			{
				BladeAssembly key = propBlurMesh.Key;
				List<Transform> value = propBlurMesh.Value;
				Vector3 localEulerAngles = key.Root.localEulerAngles;
				float num2 = num;
				foreach (Transform item in value)
				{
					item.localEulerAngles = new Vector3(localEulerAngles.x, localEulerAngles.y + num2, localEulerAngles.z);
					num2 += num;
				}
			}
		}

		private void UpdatePropellerTransparency(float perBladeAlpha)
		{
			if (_currentPropBlurAlpha == perBladeAlpha)
			{
				return;
			}
			_currentPropBlurAlpha = perBladeAlpha;
			if (_nonInstancedPropRenderers == null)
			{
				return;
			}
			foreach (IRendererMaterialMap nonInstancedPropRenderer in _nonInstancedPropRenderers)
			{
				nonInstancedPropRenderer.AlphaOverride = _currentPropBlurAlpha;
			}
		}

		private void UpdatePropellerTransparency()
		{
			float num = CalculateDesiredCombinedBladeTransparency();
			float perBladeAlpha = (_propIsBroken ? (-1f) : CalculatePerBladeAlpha(base.Data.BladeBlurCount, num));
			bool transActive = _transActive;
			_transActive = num > 0f;
			if (transActive != _transActive)
			{
				OnPropellerTransparencyActiveStateChanged(_transActive);
			}
			UpdatePropellerTransparency(perBladeAlpha);
		}

		private void UpdateRpmReduction()
		{
			if (RpmPhysicalAbs > 1000f)
			{
				_connectedMotor.RpmReductionScalar *= 0.5f;
			}
			else if (RpmPhysicalAbs < 400f && RpmReductionScalar < 1f)
			{
				float num = Mathf.Clamp01(_connectedMotor.RpmReductionScalar * 2f);
				if (Utilities.CompareFloats(num, 1f, 0.01f))
				{
					num = 1f;
				}
				_connectedMotor.RpmReductionScalar = num;
			}
		}

		private void UpdateSharedMeshAndMaterials()
		{
			_masterPropellerSharedMat = _masterPropeller.BladeMesh.GetComponent<MeshRenderer>().sharedMaterial;
			_masterPropellerSharedMesh = _masterPropeller.BladeMesh.GetComponent<MeshFilter>().sharedMesh;
			_masterPropellerSharedMat.enableInstancing = true;
		}

		private void WindmillPropeller()
		{
			float num = 0f - PropellerPitchDegrees / 90f;
			if (num == 0f)
			{
				num = -0.1f;
			}
			if (Mathf.Abs(PropellerPitchDegrees) != 90f)
			{
				float z = base.transform.InverseTransformDirection(base.PartScript.CraftScript.ReferenceFrame.FrameSurfaceVelocity + _propellerBody.velocity).z;
				if (z != 0f)
				{
					Vector3 vector = (base.Data.ReverseBladeDirection ? (-1f) : 1f) * 0.01f * Mathf.Min(1f, base.PartScript.CraftScript.AtmosphereSample.AirDensity) * num * Diameter * z * base.transform.forward;
					float num2 = _propPhysics.CalculateRpmAtNoSlip(z) * 0.75f;
					float value = Rpm / num2;
					float num3 = 1f - Mathf.Clamp01(value);
					_propellerBody.AddTorque(num3 * 1f * vector);
					Vector3 force = _dragForce.magnitude * -base.transform.forward;
					_propellerBody.AddForce(force);
				}
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			DesignerStart(in frame);
		}

		void IDesignerUpdate.DesignerUpdate(in DesignerFrameData frame)
		{
			DesignerUpdate(in frame);
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			FlightStart(in frame);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			FlightUpdate(in frame);
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			FlightFixedUpdate(in frame);
		}
	}
}
