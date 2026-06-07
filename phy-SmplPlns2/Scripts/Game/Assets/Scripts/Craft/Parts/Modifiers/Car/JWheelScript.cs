using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.CraftResourceData;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Levels;
using Assets.Scripts.Multiplayer.SyncData;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Jundroo.DevConsole;
using NWH.Common.Vehicles;
using NWH.VehiclePhysics2.GroundDetection;
using NWH.VehiclePhysics2.Powertrain;
using NWH.WheelController3D;
using Shapes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	public class JWheelScript : PowertrainModifierScript, IVariableOutput, IWheelPart, IFlightGizmo
	{
		private static bool _registeredConsoleCommands;

		private bool _aircraftStructureChanged;

		private MeshRenderer _barrelRenderer;

		[SerializeField]
		private Transform _brakeCaliper;

		private IInputController _brakeInput;

		[SerializeField]
		private Transform _brakeRotor;

		private List<MeshRenderer> _cloneRenderers;

		private GameObject _cloneRoot;

		private float _currentTurningAngle;

		private bool _designerAnimationEnabled;

		private Sequence _designeRotateTween;

		private Vector3 _designerRotation;

		[SerializeField]
		private Transform _designerTurningRoot;

		private float _functionalHealth = 1f;

		private IMagicPowertrainSource _magicCarEngine;

		private PartConnection _partConnection;

		[SerializeField]
		private Transform _placementCollider;

		[SerializeField]
		private Transform _rimAssembly;

		[SerializeField]
		private Transform _rimMeshParent;

		private MeshRenderer _rimRenderer;

		private SingleSoundManager _smDustRoll;

		private SingleSoundManager _smDustSkid;

		private SingleSoundManager _smGravelRoll;

		private SingleSoundManager _smGravelSkid;

		private SingleSoundManager _smSolidRoll;

		private SingleSoundManager _smSolidSkid;

		private JWheelSuspensionData _suspension;

		private AttachPointData _suspensionAttachPoint;

		[SerializeField]
		private Transform _tireMeshParent;

		private MeshRenderer _tireRenderer;

		private IInputController _turnInput;

		private float _weightOnWheel;

		private WheelComponent _wheelComponent;

		[SerializeField]
		private WheelController _wheelController;

		[SerializeField]
		private Transform _wheelScaleRoot;

		private int _wheelSurfaceMapIndex;

		private SurfacePreset _wheelSurfacePreset;

		public bool Enabled { get; set; }

		public bool Grounded
		{
			get
			{
				if (_wheelController != null)
				{
					return _wheelController.IsGrounded;
				}
				return false;
			}
		}

		bool IWheelPart.IsGrounded => _wheelController.IsGrounded;

		public float Rpm => Mathf.Abs(_wheelController.RPM);

		public float SpringReductionCoefficient { get; set; }

		public string TurningInput
		{
			get
			{
				if (_turnInput != null)
				{
					return _turnInput.InputId;
				}
				return string.Empty;
			}
		}

		public JWheelData Wheel { get; set; }

		public WheelController WheelCollider => _wheelController;

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

		public Vector3 WheelPosition => _wheelController.transform.position;

		public float WheelRadius => Wheel.Radius;

		float IWheelPart.WheelSpeed => _wheelController.LongitudinalSpeed;

		private bool IsOffroad => _wheelSurfaceMapIndex != -1;

		private float TurningRate => Wheel.TurningRate;

		private WheelComponent WheelComponent
		{
			get
			{
				if (_wheelComponent == null)
				{
					_wheelComponent = new WheelComponent
					{
						name = $"Wheel-{base.PartScript.Part.Id}",
						wheelUAPI = _wheelController
					};
				}
				return _wheelComponent;
			}
		}

		[VariableOutput("Forward Slip")]
		private float FSlip => _wheelController.LongitudinalSlip;

		[VariableOutput("Sideways Slip")]
		private float HSlip => _wheelController.LateralSlip;

		[VariableOutput("Offroad")]
		private float Offroad
		{
			get
			{
				if (!IsOffroad)
				{
					return 0f;
				}
				return 1f;
			}
		}

		[VariableOutput("RPM")]
		private float RPM => _wheelController.RPM;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			inputConnection.ChildConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("PowertrainInput", base.gameObject)?.transform;
			return new PowertrainNode(this, inputConnection)
			{
				InitializePowertrain = (IPowertrain powertrain, PowertrainComponent inputComponent) => WheelComponent
			};
		}

		public void DesignerUpdateTurningAngle()
		{
			Transform designerTurningRoot = _designerTurningRoot;
			float num = (Wheel.ReversedDirection ? 1f : (-1f));
			designerTurningRoot.localEulerAngles = new Vector3(0f, num * Wheel.TurningAngle, 0f);
			_designeRotateTween?.Kill();
			_designeRotateTween = DOTween.Sequence().AppendInterval(1f).Append(designerTurningRoot.DOLocalRotate(new Vector3(0f, (0f - num) * Wheel.TurningAngle, 0f), 2f))
				.AppendInterval(1f)
				.Append(designerTurningRoot.DOLocalRotate(Vector3.zero, 2f))
				.SetLink(base.gameObject);
		}

		public void DrawFlightGizmo(Camera camera)
		{
			Draw.Matrix = WheelCollider.transform.localToWorldMatrix;
			Draw.BlendMode = ShapesBlendMode.Transparent;
			Draw.ThicknessSpace = ThicknessSpace.Noots;
			Draw.Thickness = 0.3f;
			Draw.Opacity = 0.5f;
			Vector3 zero = Vector3.zero;
			float num = 1f / Mathf.Max(base.PartScript.Aircraft.CenterOfMass.LoadedMass, 1f) * 0.015f;
			Draw.Line(zero, zero + new Vector3(0f, 0f, WheelCollider.forwardFriction.force * num), (WheelCollider.forwardFriction.force > 0f) ? Color.green : Color.red);
			Draw.Line(zero, zero + new Vector3(WheelCollider.sideFriction.force * num, 0f, 0f), Color.red);
		}

		public void EnableDesignerAnimation(bool enable)
		{
			if (_designerAnimationEnabled != enable)
			{
				_designerAnimationEnabled = enable;
				if (!enable)
				{
					_designeRotateTween?.Kill(complete: true);
					_designeRotateTween = null;
				}
			}
		}

		public void Initialize(JWheelData resizableWheel)
		{
			SpringReductionCoefficient = 1f;
			Wheel = resizableWheel;
		}

		public override void InitializePartSyncData(PartSyncData syncData)
		{
			base.InitializePartSyncData(syncData);
			syncData.RegisterValue(new SyncFloat
			{
				Value = () => _wheelController?.forwardFriction.slip ?? 0f,
				ValueRead = delegate(float x)
				{
					if (_wheelController != null)
					{
						_wheelController.forwardFriction.slip = x;
					}
				}
			});
			syncData.RegisterValue(new SyncFloat
			{
				Value = () => _wheelController?.sideFriction.slip ?? 0f,
				ValueRead = delegate(float x)
				{
					if (_wheelController != null)
					{
						_wheelController.sideFriction.slip = x;
					}
				}
			});
		}

		public override void OnBeginReposition()
		{
			base.OnBeginReposition();
			_ = _wheelController != null;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				float value = Random.value;
				if (value < 0.3f && _turnInput != null)
				{
					_turnInput = null;
					_functionalHealth = Mathf.Max(0f, _functionalHealth - Random.value);
				}
				else if (value < 0.6f)
				{
					_functionalHealth = Mathf.Max(0f, _functionalHealth - Random.value);
				}
			}
		}

		public void OnFlightGizmosEnabled(bool enabled)
		{
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Wheel.ReversedDirection = !Wheel.ReversedDirection;
		}

		public async UniTask RebuildWheel(bool async)
		{
			float num = _suspension?.SuspensionLength ?? 0f;
			float singleWidth = Wheel.SingleWidth;
			float num2 = Wheel.Radius / singleWidth * 2f;
			float rimScale = Wheel.TirePrefab.rimScale;
			_brakeRotor.localScale = new Vector3(num2 * rimScale * Mathf.Min(1f, Wheel.WidthPercentage), rimScale, rimScale);
			float b = 0.5f - 0.21f * _brakeRotor.localScale.x;
			float num3 = Mathf.Lerp(-0.5f, b, Wheel.RimOffset);
			_brakeRotor.localPosition = new Vector3(num3, 0f, 0f);
			float num4 = num3 * singleWidth;
			_wheelController.wheel.rimOffset = 0f - num4 + 0.02f;
			_wheelScaleRoot.localScale = new Vector3(singleWidth, Wheel.Radius * 2f, Wheel.Radius * 2f);
			_wheelController.transform.localPosition = new Vector3(num4 - (Wheel.Duals ? (Wheel.SingleWidth / 2f) : 0f), num, 0f);
			_wheelController.transform.localRotation = (Wheel.ReversedDirection ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity);
			_wheelController.SpringMaxLength = num;
			_wheelController.side = (Wheel.ReversedDirection ? 1f : (-1f));
			_wheelController.Width = Wheel.TotalWidth;
			_wheelController.Radius = Wheel.Radius;
			LoadTire(Wheel.TirePrefab);
			LoadRim(Wheel.RimPrefab, Wheel.TirePrefab);
			Transform parent = _rimAssembly.parent;
			parent.localPosition = (Wheel.Duals ? new Vector3(-0.5f, 0f, 0f) : Vector3.zero);
			if (_cloneRoot != null)
			{
				foreach (MeshRenderer cloneRenderer in _cloneRenderers)
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(cloneRenderer, destroy: true);
				}
				Object.DestroyImmediate(_cloneRoot);
				_cloneRoot = null;
				_cloneRenderers.Clear();
			}
			if (Wheel.Duals)
			{
				_cloneRoot = Object.Instantiate(parent.gameObject);
				_cloneRoot.transform.SetParent(parent, worldPositionStays: false);
				_cloneRoot.transform.SetLocalPositionAndRotation(new Vector3(1f, 0f, 0f), Quaternion.identity);
				if (_cloneRenderers == null)
				{
					_cloneRenderers = new List<MeshRenderer>();
				}
				_cloneRoot.GetComponentsInChildren(_cloneRenderers);
				foreach (MeshRenderer cloneRenderer2 in _cloneRenderers)
				{
					base.PartScript.PartMaterialScript.AddRenderer(cloneRenderer2, excludeFromCombine: true);
				}
			}
			await base.PartScript.PartMaterialScript.InitializeMaterial(async);
			_brakeCaliper.position = _brakeRotor.position;
			Vector3 lossyScale = _brakeRotor.lossyScale;
			lossyScale.x *= (Wheel.ReversedDirection ? 1f : (-1f));
			_brakeCaliper.localScale = lossyScale;
			_placementCollider.localScale = new Vector3(Wheel.TotalWidth / 4f, Wheel.Radius * 2f, Wheel.Radius * 2f);
			_placementCollider.localPosition = Vector3.zero;
			WheelCollider.WheelVisual.transform.localPosition = new Vector3(0f, 0f - _wheelController.SpringMaxLength, 0f);
			WheelCollider.NonRotatingVisual.transform.localPosition = new Vector3(0f, 0f - _wheelController.SpringMaxLength, 0f);
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				FlightSceneScript.Instance.FlightGizmos.UnregisterGizmo(this);
			}
			MeshCollider meshCollider = _wheelController?.wheel?.meshCollider;
			if (meshCollider != null)
			{
				Mesh sharedMesh = meshCollider.sharedMesh;
				if (sharedMesh != null)
				{
					Object.Destroy(sharedMesh);
				}
				PhysicsMaterial material = meshCollider.material;
				if (material != null)
				{
					Object.Destroy(material);
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterUpdate(OnDesignerUpdate, CraftUpdateFlags.DesignerDefault);
		}

		private void FindSuspension()
		{
			if (base.LoadContext == CraftLoadContext.Flight && base.PartScript.Part.PartConnections.Count > 0)
			{
				JWheelSuspensionData modifier = base.PartScript.Part.PartConnections[0].GetOtherPart(base.PartScript.Part).GetModifier<JWheelSuspensionData>();
				if (modifier != null)
				{
					_suspension = modifier;
					_suspensionAttachPoint = base.PartScript.Part.PartConnections[0].GetOtherAttachPoint(base.PartScript.Part.AttachPoints[0]);
				}
			}
		}

		private void InitializeForFlight()
		{
			FindSuspension();
			bool remoteAircraft = base.PartScript.Aircraft.RemoteAircraft;
			_smDustSkid = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.SkidDust, AudioStore.Rumble, remoteAircraft);
			_smDustRoll = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.RollDust, AudioStore.Rumble, remoteAircraft, isFaded: false, 2f, 20f);
			if (!_smDustRoll.gameObject.TryGetComponent<AudioLowPassFilter>(out var component))
			{
				component = _smDustRoll.gameObject.AddComponent<AudioLowPassFilter>();
			}
			component.cutoffFrequency = 500f;
			_smGravelSkid = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.SkidGravel, AudioStore.Rumble, remoteAircraft);
			_smGravelRoll = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.RollGravel, AudioStore.Rumble, remoteAircraft, isFaded: false, 2f, 20f);
			if (!_smGravelRoll.gameObject.TryGetComponent<AudioLowPassFilter>(out component))
			{
				component = _smGravelRoll.gameObject.AddComponent<AudioLowPassFilter>();
			}
			component.cutoffFrequency = 500f;
			_smSolidSkid = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.SkidSolid, AudioStore.Rumble, remoteAircraft);
			_smSolidRoll = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.RollSolid, AudioStore.Rumble, remoteAircraft, isFaded: false, 2f, 20f);
			if (!_smSolidRoll.gameObject.TryGetComponent<AudioLowPassFilter>(out component))
			{
				component = _smSolidRoll.gameObject.AddComponent<AudioLowPassFilter>();
			}
			component.cutoffFrequency = 500f;
			if (_wheelController != null)
			{
				_wheelController.isRemote = remoteAircraft;
				_wheelController.enabled = true;
				if (remoteAircraft)
				{
					WheelController wheelController = _wheelController;
					wheelController.layerMask = (int)wheelController.layerMask & -67108865;
				}
				_wheelController.Mass = Mathf.Max(base.PartScript.Part.LoadedMass / 0.01f, 0.25f);
				_wheelController.FrictionCircleStrength = Wheel.FrictionCircleStrength;
				_wheelController.FrictionCircleShape = Wheel.FrictionCirclePower;
				base.PartScript.Aircraft.Powertrain.RegisterWheel(WheelComponent);
			}
			if (base.PartScript.Part.PartConnections.Count > 0)
			{
				_partConnection = base.PartScript.Part.PartConnections[0];
			}
		}

		private void LoadRim(WheelPrefabs.RimPrefab rimPrefab, WheelPrefabs.TirePrefab tirePrefab)
		{
			if (_rimRenderer != null)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(_rimRenderer, destroy: true);
				Object.Destroy(_rimRenderer.gameObject);
				_rimRenderer = null;
			}
			if (_barrelRenderer != null)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(_barrelRenderer, destroy: true);
				Object.Destroy(_barrelRenderer.gameObject);
				_barrelRenderer = null;
			}
			Quaternion localRotation = Quaternion.Euler(0f, (!Wheel.ReversedDirection) ? 180 : 0, 0f);
			_rimAssembly.localRotation = localRotation;
			GameObject gameObject = Object.Instantiate(rimPrefab.barrelPrefab);
			if (gameObject != null)
			{
				gameObject.transform.SetParent(_tireMeshParent, worldPositionStays: false);
				gameObject.layer = base.gameObject.layer;
				gameObject.transform.localRotation = localRotation;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = new Vector3(1f, tirePrefab.rimScale, tirePrefab.rimScale);
				_barrelRenderer = gameObject.GetComponent<MeshRenderer>();
				base.PartScript.PartMaterialScript.AddRenderer(_barrelRenderer, excludeFromCombine: true);
			}
			if (!Wheel.HideRims)
			{
				GameObject gameObject2 = Object.Instantiate(rimPrefab.prefab);
				if (gameObject2 != null)
				{
					gameObject2.transform.SetParent(_rimMeshParent, worldPositionStays: false);
					gameObject2.layer = base.gameObject.layer;
					gameObject2.transform.localPosition = Vector3.zero;
					gameObject2.transform.localScale = Vector3.one;
					_rimRenderer = gameObject2.GetComponent<MeshRenderer>();
					base.PartScript.PartMaterialScript.AddRenderer(_rimRenderer, excludeFromCombine: true);
				}
			}
		}

		private void LoadTire(WheelPrefabs.TirePrefab tirePrefab)
		{
			if (_tireRenderer != null)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(_tireRenderer, destroy: true);
				Object.Destroy(_tireRenderer.gameObject);
			}
			GameObject gameObject = Object.Instantiate(tirePrefab.prefab);
			if (gameObject != null)
			{
				gameObject.transform.SetParent(_tireMeshParent, worldPositionStays: false);
				gameObject.layer = base.gameObject.layer;
				gameObject.transform.localRotation = Quaternion.Euler(0f, (!Wheel.ReversedDirection) ? 180 : 0, 0f);
				gameObject.transform.localPosition = Vector3.zero;
				if (Wheel.ReversedDirection)
				{
					gameObject.transform.localScale = new Vector3(1f, 1f, -1f);
				}
				_tireRenderer = gameObject.GetComponent<MeshRenderer>();
				base.PartScript.PartMaterialScript.AddRenderer(_tireRenderer, excludeFromCombine: true);
			}
		}

		private void OnAircraftStructureChanged()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_aircraftStructureChanged = true;
			}
			else if (base.LoadContext == CraftLoadContext.Designer)
			{
				Wheel.RefreshDesignerUI();
			}
		}

		private void OnDesignerUpdate(in CraftUpdateFrameData frame)
		{
			if (_designerAnimationEnabled)
			{
				_designerRotation.x += Time.unscaledDeltaTime * 30f;
			}
			_tireMeshParent.localEulerAngles = _designerRotation;
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_aircraftStructureChanged)
			{
				ProcessAircraftStructureChanged();
			}
			WheelCollider.WakeFromSleep();
		}

		private async UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (loadContext == CraftLoadContext.Flight)
			{
				InitializeForFlight();
			}
			await RebuildWheel(async);
			base.Part.PrimaryPlacementCollider = _placementCollider.GetComponent<Collider>();
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			Enabled = true;
			base.PartScript.ThudSoundDisabled = true;
			_turnInput = GetInputController("Turn");
			_brakeInput = GetInputController("Brake");
			base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
			if (frame.CraftLoadContext == CraftLoadContext.Flight)
			{
				UpdateWheelColliderSettings();
				SetRigidBody();
				WheelCollider.OnStart();
				FlightSceneScript.Instance.FlightGizmos.RegisterGizmo(this);
				if (Wheel.MagicEngineId > 0 && !base.IsConnectedToEngine)
				{
					PartData partById = base.PartScript.Aircraft.GetPartById(Wheel.MagicEngineId);
					if (partById != null)
					{
						IMagicPowertrainSource modifierWithInterface = partById.PartScript.GetModifierWithInterface<IMagicPowertrainSource>();
						if (modifierWithInterface != null)
						{
							_magicCarEngine = modifierWithInterface;
							_magicCarEngine.RegisterSink(this);
						}
					}
				}
			}
			if (!_registeredConsoleCommands)
			{
				_registeredConsoleCommands = true;
				DevConsoleApi.RegisterCommand("SimpleFrictionCircleToggle", delegate
				{
					Debug.Log("SimpleFrictionCircle " + ((WheelController.UseSimpleFrictionCircle = !WheelController.UseSimpleFrictionCircle) ? "enabled" : "disabled"));
				});
			}
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_aircraftStructureChanged)
			{
				ProcessAircraftStructureChanged();
			}
			UpdateWheel();
			if (_suspension != null)
			{
				_suspension.Script.UpdateSuspensionVisuals(this, _suspensionAttachPoint);
			}
		}

		private void ProcessAircraftStructureChanged()
		{
			_aircraftStructureChanged = false;
			SetRigidBody();
			UpdateWheelColliderSettings();
		}

		private void SetRigidBody()
		{
			IRigidBody rigidBody = base.PartScript.Body.RigidBody;
			_wheelController.JundrooSetRigidBody(rigidBody.PhysxRigidBody, base.PartScript.Body.transform);
			if (rigidBody != null)
			{
				rigidBody.maxDepenetrationVelocity = 1f;
			}
		}

		private void UpdateWheel()
		{
			if (!_wheelController.enabled)
			{
				return;
			}
			if (_wheelController.TargetRigidbody != null)
			{
				AircraftScript aircraft = base.PartScript.Aircraft;
				float value = _brakeInput.Value;
				_wheelController.brakeInput = Mathf.Clamp01(value + (aircraft.Controls.ParkingBrake ? 1f : 0f));
				if (value > 0f)
				{
					float num = (aircraft.Controls.ParkingBrake ? 5f : 1f);
					_wheelController.BrakeTorque = value * num * _functionalHealth * _weightOnWheel * WheelRadius * Wheel.BrakeTorque * 2f;
				}
				else if (_wheelController != null)
				{
					_wheelController.BrakeTorque = 0f;
				}
				if (_wheelController.IsGrounded && _wheelComponent != null && _wheelComponent.surfacePreset != null)
				{
					SurfacePreset surfacePreset = _wheelComponent.surfacePreset;
					WheelUAPI wheelUAPI = _wheelComponent.wheelUAPI;
					float num2 = 0.25f + 1.125f / (WheelRadius * WheelRadius + 0.5f);
					if (surfacePreset.playSkidSounds)
					{
						float num3 = Mathf.Max(0f, wheelUAPI.NormalizedLateralSlip - 0.1f) * Mathf.Sqrt(Mathf.Abs(_wheelController.LateralSpeed) / 30f);
						float num4 = Mathf.Max(0f, wheelUAPI.NormalizedLongitudinalSlip - 0.1f);
						float volume = surfacePreset.skidSoundVolume * (num3 + num4);
						switch (surfacePreset.soundTypeIndex)
						{
						case 0:
							_smDustSkid.AddSound(base.transform.position, volume, surfacePreset.skidSoundPitch * num2);
							break;
						case 1:
							_smGravelSkid.AddSound(base.transform.position, volume, surfacePreset.skidSoundPitch * num2);
							break;
						default:
							_smSolidSkid.AddSound(base.transform.position, volume, surfacePreset.skidSoundPitch * num2);
							break;
						}
					}
					if (surfacePreset.playSurfaceSounds)
					{
						float num5 = Mathf.Abs(_wheelController.LongitudinalSpeed) / 30f;
						switch (surfacePreset.soundTypeIndex)
						{
						case 0:
							_smDustRoll.AddSound(base.transform.position, surfacePreset.surfaceSoundVolume * num5, Mathf.Max(0.5f, num5 * surfacePreset.surfaceSoundPitch * num2));
							break;
						case 1:
							_smGravelRoll.AddSound(base.transform.position, surfacePreset.surfaceSoundVolume * num5, Mathf.Max(0.5f, num5 * surfacePreset.surfaceSoundPitch * num2));
							break;
						default:
							_smSolidRoll.AddSound(base.transform.position, surfacePreset.surfaceSoundVolume * num5, Mathf.Max(0.5f, num5 * surfacePreset.surfaceSoundPitch * num2));
							break;
						}
					}
				}
			}
			if (_turnInput != null)
			{
				float target = _turnInput.Value * Wheel.TurningAngle;
				if (WheelDisconnected)
				{
					target = 0f;
				}
				_currentTurningAngle = Utilities.StepTowards(_currentTurningAngle, TurningRate * Time.deltaTime, target);
				if (_wheelController != null && Wheel.TurningAngle > 0f && _turnInput != null)
				{
					float num6 = 1f;
					float turningAngleDampening = Wheel.TurningAngleDampening;
					if (turningAngleDampening > 0f)
					{
						float num7 = 1f / (turningAngleDampening * turningAngleDampening) * 25f;
						if (num7 > 0f)
						{
							float num8 = Mathf.Abs(_wheelController.LongitudinalSpeed);
							num6 = Mathf.Lerp(1f, 0.1f, Mathf.Clamp01(num8 / num7));
						}
					}
					_wheelController.SteerAngle = _currentTurningAngle * num6;
				}
			}
			if (_wheelComponent != null && _wheelSurfacePreset != _wheelComponent.surfacePreset)
			{
				_wheelSurfacePreset = _wheelComponent.surfacePreset;
				_wheelSurfaceMapIndex = _wheelComponent.surfaceMapIndex;
				TireProfile.TireSurfaceProfile tireSurfaceProfile = Wheel.TirePrefab.tireProfile.GetTireSurfaceProfile(_wheelComponent.surfacePreset);
				float num9 = (Wheel.Duals ? 1.05f : 1f);
				float num10 = (Wheel.Duals ? 1.25f : 1f);
				_wheelController.LateralFrictionGrip = Wheel.TractionSideways * tireSurfaceProfile.grip * num9;
				_wheelController.LongitudinalFrictionGrip = Wheel.TractionForward * tireSurfaceProfile.grip * num9;
				_wheelController.LateralFrictionStiffness = tireSurfaceProfile.stiffness * num10;
				_wheelController.LongitudinalFrictionStiffness = tireSurfaceProfile.stiffness * num10;
			}
		}

		private void UpdateWheelColliderSettings()
		{
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				PartGraph.GetConnectedParts(base.PartScript.Part, breakOnRigidBodyBoundary: false, value);
				GroupCenterOfMass groupCenterOfMass = new GroupCenterOfMass(value);
				float num = 0f;
				foreach (PartData item in value)
				{
					if (item.PartScript.GetModifierWithInterface<IWheelPart>() != null)
					{
						float num2 = Mathf.Max(1f, Vector3.Distance(item.PartScript.transform.position, groupCenterOfMass.CenterOfMass));
						num += 1f / num2;
					}
				}
				float num3 = Mathf.Max(1f, Vector3.Distance(base.PartScript.transform.position, groupCenterOfMass.CenterOfMass));
				float num4 = 1f / num3 / Mathf.Max(1f, num);
				_weightOnWheel = groupCenterOfMass.LoadedMass / 0.01f * 9.81f * num4 * 1.05f;
				float num5 = base.PartScript.Part.LoadedMass * 50f / 0.01f * 9.81f;
				if (_suspension != null)
				{
					float num6 = _weightOnWheel * 4f * _suspension.Stiffness;
					float num7 = Mathf.Sqrt(num6) * 20f * _suspension.Damper;
					_wheelController.SpringMaxForce = num6;
					_wheelController.DamperBumpRate = num7;
					_wheelController.DamperReboundRate = num7;
					_wheelController.MaxLoad = _weightOnWheel * 2f;
				}
				else
				{
					_wheelController.MaxLoad = _weightOnWheel * 1.5f;
				}
				if (_wheelController.MaxLoad > num5)
				{
					_wheelController.MaxLoad = num5;
				}
				float num8 = 0.015f * _wheelController.MaxLoad * Wheel.Radius;
				_wheelController.RollingResistanceTorque = num8;
				WheelComponent._initialRollingResistance = num8;
				FrictionPreset frictionPreset = Wheel.FrictionPreset.frictionPreset;
				if (Wheel.Pacejka.HasValue)
				{
					frictionPreset = Object.Instantiate(frictionPreset);
					frictionPreset.BCDE = Wheel.Pacejka.Value;
					frictionPreset.UpdateFrictionCurve();
				}
				WheelComponent.fallbackFrictionPreset = frictionPreset;
			}
		}

		void IVariableOutput.UpdateOutputs()
		{
		}
	}
}
