using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Craft.FlightData;
using Assets.Scripts.Craft.Fuel;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using Assets.Scripts.DebugScripts;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Social.Achievements;
using Assets.Scripts.Tools;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Exceptions;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Levels;
using ModApi.Planet;
using ModApi.Planet.Modifiers.Material;
using ModApi.Scripts.State.Validation;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Craft
{
	[GameLoopExecutionOrder(-5000)]
	[BurstCompile(CompileSynchronously = true)]
	public class CraftScript : MonoBehaviourBase, ICraftScript, IFlightFixedUpdate, IGameLoopItem, IFlightFixedUpdateWarp, IFlightLateUpdate, IFlightUpdate, IFlightUpdatePaused, IDesignerLateUpdate, IFlightPostStart
	{
		public enum CraftOrientationMode
		{
			Rocket = 0,
			Airplane = 1
		}

		public unsafe delegate void RepositionParticles_0000519F_0024PostfixBurstDelegate([NoAlias] ParticleSystem.Particle* particles, int particleCount, Vector3* positionDelta, Vector3* velocityDelta);

		internal static class RepositionParticles_0000519F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RepositionParticles_0000519F_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static RepositionParticles_0000519F_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke([NoAlias] ParticleSystem.Particle* particles, int particleCount, Vector3* positionDelta, Vector3* velocityDelta)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ParticleSystem.Particle*, int, Vector3*, Vector3*, void>)functionPointer)(particles, particleCount, positionDelta, velocityDelta);
						return;
					}
				}
				RepositionParticles_0024BurstManaged(particles, particleCount, positionDelta, velocityDelta);
			}
		}

		private const float DebrisUnloadAgl = 500f;

		private const float DebrisUnloadDistanceSquared = 1000000f;

		private Transform _cameraFocus;

		private Transform _cameraTarget;

		private Vector3 _cameraTargetOffset = Vector3.zero;

		private Transform _centerOfMassTransform;

		private List<ICommandPod> _commandPods = new List<ICommandPod>();

		private CraftFuelSources _craftFuelSources;

		private CraftNode _craftNode;

		private List<ICraftDebris> _debris = new List<ICraftDebris>();

		[SerializeField]
		private bool _enableDebugBall;

		private bool _firstFrame = true;

		private CraftFlightData _flightData;

		private List<FlightProgramScript> _flightProgramScripts;

		private Vector3? _frameVelocity;

		private FuelMonitor _fuelMonitor;

		private List<FuselageScript> _fuselageScripts;

		private Queue<IBodyScript> _inertiaTensorRecalculationQueue = new Queue<IBodyScript>();

		private bool _isInitialized;

		private Vector3 _lastRebuildCenterOfMass = Vector3.zero;

		private bool _physicsEnabled;

		private bool _processDisconnectedBodies;

		private bool _recalculateDrag;

		private bool _recalculateMass;

		private float _reEntryEffectIntensity;

		private bool _structureChanged;

		private Vector3[] _tempChildPositions;

		private Quaternion[] _tempChildRotations;

		private Transform _terrainAlignedTransform;

		private bool _waterWavesEnabled;

		public ICommandPod ActiveCommandPod { get; private set; }

		public AtmosphereSample AtmosphereSample
		{
			get
			{
				return _flightData.AtmosphereSample;
			}
			private set
			{
				_flightData.AtmosphereSample = value;
			}
		}

		public Transform CameraFocus
		{
			get
			{
				return _cameraFocus;
			}
			set
			{
				_cameraFocus = value;
				if (value == null)
				{
					_cameraTarget.parent = RootPart.Transform;
					if (_cameraTarget.TryGetComponent<LifeCycleEventsNotifier>(out var component))
					{
						UnityEngine.Object.Destroy(component);
					}
				}
				else
				{
					_cameraTarget.parent = value;
					MonitorCameraFocusTransform();
				}
			}
		}

		public Transform CameraTarget => _cameraTarget;

		public Vector3 CameraTargetOffset
		{
			set
			{
				_cameraTargetOffset = value;
			}
		}

		public Transform CenterOfMass => _centerOfMassTransform;

		public IEnumerable<ICommandPod> CommandPods => _commandPods;

		public CraftAudio CraftAudio { get; private set; }

		public ICraftNode CraftNode
		{
			get
			{
				return _craftNode;
			}
			set
			{
				_craftNode = value as CraftNode;
			}
		}

		public CraftData Data { get; private set; }

		public Vector3 DragAcceleration { get; private set; }

		public ICraftFlightData FlightData => _flightData;

		public IReadOnlyList<FlightProgramScript> FlightProgramScripts
		{
			get
			{
				if (_flightProgramScripts == null)
				{
					_flightProgramScripts = new List<FlightProgramScript>();
					foreach (PartData part in Data.Assembly.Parts)
					{
						FlightProgramScript modifier = part.PartScript.GetModifier<FlightProgramScript>();
						if (modifier != null)
						{
							_flightProgramScripts.Add(modifier);
						}
					}
				}
				return _flightProgramScripts;
			}
		}

		public Quaternion FrameHeading => CenterOfMass.rotation;

		public Vector3 FramePosition => CenterOfMass.position;

		public Vector3 FrameVelocity
		{
			get
			{
				if (!_frameVelocity.HasValue)
				{
					float num = 0f;
					Vector3 zero = Vector3.zero;
					Vector3 zero2 = Vector3.zero;
					IReadOnlyList<BodyData> bodies = Data.Assembly.Bodies;
					for (int i = 0; i < bodies.Count; i++)
					{
						BodyData bodyData = bodies[i];
						if (!bodyData.BodyScript.IsDebris)
						{
							zero += bodyData.BodyScript.RigidBody.velocity * bodyData.Mass;
							num += bodyData.Mass;
						}
						zero2 += bodyData.BodyScript.DragForce;
					}
					DragAcceleration = zero2 / num;
					if (num > 0f)
					{
						_frameVelocity = zero / num;
					}
					else
					{
						_frameVelocity = RootPart.BodyScript.RigidBody.velocity;
					}
				}
				return _frameVelocity.Value;
			}
		}

		public ICraftFuelSources FuelSources => _craftFuelSources;

		public FuelTransferManager FuelTransfer { get; set; }

		public IReadOnlyList<FuselageScript> FuselageScripts
		{
			get
			{
				if (_fuselageScripts == null)
				{
					_fuselageScripts = new List<FuselageScript>();
					foreach (PartData part in Data.Assembly.Parts)
					{
						FuselageScript modifier = part.PartScript.GetModifier<FuselageScript>();
						if (modifier != null)
						{
							_fuselageScripts.Add(modifier);
						}
					}
				}
				return _fuselageScripts;
			}
		}

		public Vector3 GravityForce => _flightData.GravityFrame;

		public float GravityMagnitude => _flightData.GravityMagnitude;

		public Vector3 GravityNormal => _flightData.GravityFrameNormalized;

		public Vector3 InertiaTensor { get; private set; }

		public InletAir InletAir { get; private set; }

		public bool IsPhysicsEnabled
		{
			get
			{
				return _physicsEnabled;
			}
			set
			{
				if (_physicsEnabled != value)
				{
					EnablePhysics(value);
				}
			}
		}

		public float Mass { get; private set; }

		public int NumAstronauts { get; private set; }

		public CraftOrientationMode OrientationMode { get; private set; }

		public IPartHighlighter PartHighlighter => PartHighlighterScript.Instance;

		public ICommandPod PrimaryCommandPod => RootPart?.GetModifier<CommandPodScript>();

		public float ReEntryIntensity => _reEntryEffectIntensity;

		public IReferenceFrame ReferenceFrame => CraftNode.ReferenceFrame;

		public IPartScript RootPart { get; private set; }

		public Vector3 SurfaceVelocity => _flightData.SurfaceVelocityFrame;

		public Transform Transform => base.transform;

		public event ActiveCommandPodChandedHandler ActiveCommandPodChanged;

		public event ActiveCommandPodChandedHandler ActiveCommandPodChanging;

		public event CraftScriptDelegate CraftSplit;

		public event SimpleNotificationDelegate CraftStructureChanged;

		public event DockBeginDelegate DockBegin;

		public event DockingDelegate DockComplete;

		public event CraftScriptDelegate Initialized
		{
			add
			{
				if (_isInitialized)
				{
					value(this);
				}
				else
				{
					_initialized += value;
				}
			}
			remove
			{
				_initialized -= value;
			}
		}

		public event Action<Quaternion> NavballRotationUpdate;

		public event Action<int, Vector3?> NavballVectorUpdate;

		public event PartCollisionDelegate PartCollisionEnter;

		public event PartDelegate PartExploded;

		public event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanged;

		private event CraftScriptDelegate _initialized;

		public unsafe static void RepositionParticleSystem(ParticleSystem ps, Vector3 positionDelta, Vector3 velocityDelta)
		{
			if (ps.main.simulationSpace == ParticleSystemSimulationSpace.World)
			{
				int particleCount = ps.particleCount;
				if (particleCount > 0)
				{
					NativeArray<ParticleSystem.Particle> nativeArray = new NativeArray<ParticleSystem.Particle>(particleCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					ParticleSystem.Particle* unsafeBufferPointerWithoutChecks = (ParticleSystem.Particle*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray);
					ps.GetParticles(nativeArray, particleCount, 0);
					RepositionParticles(unsafeBufferPointerWithoutChecks, particleCount, &positionDelta, &velocityDelta);
					ps.SetParticles(nativeArray, particleCount, 0);
				}
			}
		}

		public void AbsorbCraftScript(CraftScript sourceCraftScript)
		{
			_craftFuelSources.AbsorbFuelSources(sourceCraftScript._craftFuelSources);
			SetStructureChanged();
		}

		public void AddDebris(ICraftDebris debris)
		{
			_debris.Add(debris);
		}

		public Bounds CalculateBounds()
		{
			return CalculateBounds(includeDisconnected: false);
		}

		public Bounds CalculateBounds(bool includeDisconnected)
		{
			Vector3 vector = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Vector3 vector2 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			foreach (PartData part in Data.Assembly.Parts)
			{
				if (includeDisconnected || !part.PartScript.Disconnected)
				{
					Bounds bounds = part.PartScript.CalculateBounds();
					vector = Vector3.Max(vector, bounds.max);
					vector2 = Vector3.Min(vector2, bounds.min);
				}
			}
			Bounds result = default(Bounds);
			result.SetMinMax(vector2, vector);
			return result;
		}

		public void CalculatePrice()
		{
			long num = 0L;
			foreach (PartData part in Data.Assembly.Parts)
			{
				if (!part.PartScript.Disconnected)
				{
					num += part.Price;
				}
			}
			Data.Price = num;
		}

		public void CalculateStartingBounds()
		{
			if (!Game.InDesignerScene)
			{
				throw new GameException("CraftScript.CalculateStartingBounds can only be called in the designer.");
			}
			Bounds bounds = CalculateBounds();
			Data.InitialBoundsMin = bounds.min - CenterOfMass.position;
			Data.InitialBoundsMax = bounds.max - CenterOfMass.position;
		}

		public float CalculateWingArea()
		{
			float num = 0f;
			foreach (PartData part in Data.Assembly.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					WingScript wingScript = modifier.GetScript() as WingScript;
					if (wingScript != null)
					{
						num += wingScript.Data.WingArea;
					}
				}
			}
			return num;
		}

		public float CalculateWingLoading()
		{
			return Mass / CalculateWingArea();
		}

		void IDesignerLateUpdate.DesignerLateUpdate(in DesignerFrameData frame)
		{
			if (_structureChanged)
			{
				_structureChanged = false;
				RaiseDesignerCraftStructureChangedEvent();
			}
			if (_firstFrame)
			{
				_firstFrame = false;
				OnInitialized();
			}
		}

		public void DestroyBody(BodyData body)
		{
			body.OnBodyDestroyed();
			Data.Assembly.RemoveBody(body);
			while (body.BodyScript.PartGroups.Count > 0)
			{
				IPartGroupScript partGroupScript = body.BodyScript.PartGroups[0];
				if (partGroupScript.BodyScript == body.BodyScript)
				{
					DestroyPartGroup(partGroupScript);
					continue;
				}
				Debug.Log("Part Group is in wrong body");
				((BodyScript)body.BodyScript).PartGroups.Remove(partGroupScript);
			}
			body.BodyScript.GameObject.SetActive(value: false);
		}

		public void DestroyPart(PartData part, bool destroyPartGameObject)
		{
			while (part.PartConnections.Count > 0)
			{
				part.PartConnections[0].DestroyConnection();
			}
			Data.Assembly.RemovePartCollisions(part);
			if (Game.InFlightScene)
			{
				foreach (PartModifierScript modifier in part.PartScript.Modifiers)
				{
					modifier.FlightEnd();
				}
				if (RootPart == part.PartScript)
				{
					_craftNode.DestroyCraft();
				}
			}
			part.OnPartDestroyed();
			((PartScript)part.PartScript).OnPartDestroyed();
			Data.Assembly.RemovePart(part);
			part.PartScript.PartGroup?.RemovePart(part);
			part.PartScript.BodyScript?.Data.Parts.Remove(part);
			part.PartScript.GameObject.SetActive(value: false);
			if (destroyPartGameObject)
			{
				part.PartScript.Transform.parent = null;
				UnityEngine.Object.Destroy(part.PartScript.GameObject);
				part.PartScript = null;
			}
		}

		public void DestroyPartGroup(IPartGroupScript partGroup)
		{
			for (int num = partGroup.Data.Parts.Count - 1; num >= 0; num--)
			{
				PartData partData = partGroup.Data.Parts[num];
				if (!partData.IsDestroyed)
				{
					DestroyPart(partData, destroyPartGameObject: false);
				}
			}
			((BodyScript)partGroup.BodyScript).PartGroups.Remove(partGroup);
			partGroup.GameObject.SetActive(value: false);
		}

		public void FlightEnd()
		{
			foreach (ICraftDebris item in _debris)
			{
				UnityEngine.Object.Destroy(item.Transform.gameObject);
			}
			_debris.Clear();
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				(body.BodyScript as BodyScript).FlightEnd();
			}
			foreach (PartData part in Data.Assembly.Parts)
			{
				foreach (PartModifierScript modifier in part.PartScript.Modifiers)
				{
					modifier.FlightEnd();
				}
			}
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			Vector3 force = Vector3.zero;
			if (ReferenceFrame.DeltaRotation != 0.0)
			{
				Vector3d planetVector = Utilities.RotateVectorAroundYAxis(CraftNode.Velocity, 0.0 - ReferenceFrame.DeltaRotation) - CraftNode.Velocity;
				force = ReferenceFrame.PlanetToFrameVector(planetVector);
			}
			_flightData.FixedUpdate();
			if (IsPhysicsEnabled)
			{
				IReadOnlyList<BodyData> bodies = Data.Assembly.Bodies;
				int count = bodies.Count;
				for (int i = 0; i < count; i++)
				{
					IBodyScript bodyScript = bodies[i].BodyScript;
					if (bodyScript.ApplyStandardForces)
					{
						Rigidbody rigidBody = bodyScript.RigidBody;
						if (ReferenceFrame.DeltaRotation != 0.0)
						{
							rigidBody.AddForce(force, ForceMode.VelocityChange);
						}
						rigidBody.AddForce(rigidBody.mass * Game.Instance.Settings.Game.Flight.GravityScale.Value * _flightData.GravityFrame);
					}
				}
				RepositionTerrainAlignedTransform();
			}
			_frameVelocity = null;
		}

		void IFlightFixedUpdateWarp.FlightFixedUpdateWarp(in FlightFrameData frame)
		{
			_flightData.FixedUpdate();
		}

		void IFlightLateUpdate.FlightLateUpdate(in FlightFrameData frame)
		{
			if (_structureChanged)
			{
				RebuildCraftStructure(raiseStructureChangedEvent: true);
				_structureChanged = false;
			}
			else if (_processDisconnectedBodies)
			{
				if (ProcessDisconnectedBodies())
				{
					_processDisconnectedBodies = true;
					_recalculateDrag = true;
				}
				else
				{
					_processDisconnectedBodies = false;
				}
			}
			else if (_recalculateDrag)
			{
				_recalculateDrag = false;
				foreach (BodyData body in Data.Assembly.Bodies)
				{
					if (!body.BodyScript.IsDebris && !body.BodyScript.Disconnected)
					{
						FlightSceneScript.Instance.DragCalculator.Queue.AddBody(body.BodyScript);
					}
				}
			}
			InletAir.Update();
			_fuelMonitor?.LateUpdate();
			if (_firstFrame)
			{
				_firstFrame = false;
				InitializePartGroups();
				OnInitialized();
			}
			_frameVelocity = null;
		}

		void IFlightPostStart.FlightPostStart(in FlightFrameData frame)
		{
			Physics.SyncTransforms();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			UpdateFlightData();
			CraftAudio.Update();
			if (IsPhysicsEnabled)
			{
				UpdateInContactWithPlanetStatus();
			}
			if (_recalculateMass)
			{
				_recalculateMass = false;
				RecalculateCenterOfMass();
				if ((_lastRebuildCenterOfMass - _centerOfMassTransform.localPosition).sqrMagnitude > 1f)
				{
					RebuildCraftStructure(raiseStructureChangedEvent: true);
				}
			}
			_craftFuelSources.Update((float)frame.DeltaTimeWorld);
			FuelTransfer.Update((float)frame.DeltaTimeWorld);
			UpdateCameraTarget(frame.DeltaTimeUnscaled);
			UpdateNavballHooks();
			_fuelMonitor?.Update();
			if (_inertiaTensorRecalculationQueue.Count > 0)
			{
				IBodyScript bodyScript = _inertiaTensorRecalculationQueue.Dequeue();
				if (!bodyScript.Disconnected && !bodyScript.Data.IsDestroyed)
				{
					CraftBuilder.CalculateInertiaTensors(bodyScript, bodyScript.RigidBody.isKinematic);
				}
			}
		}

		void IFlightUpdatePaused.FlightUpdatePaused(in FlightFrameData frame)
		{
			UpdateCameraTarget(frame.DeltaTimeUnscaled);
		}

		public double GetAltitudeAboveGroundLevel(Vector3 framePosition)
		{
			RaycastHit hitInfo;
			Vector3d planetNormal = ((!Physics.Raycast(framePosition, _flightData.GravityFrameNormalized, out hitInfo, 1000f, 536870912)) ? ReferenceFrame.FrameToPlanetVector(-_flightData.GravityFrameNormalized) : ReferenceFrame.FrameToPlanetVector(hitInfo.normal));
			PlanetVertexData terrainVertexData = CraftNode.Parent.GetTerrainVertexData(VertexDataRequestType.HeightData, ReferenceFrame.FrameToPlanetPosition(framePosition), planetNormal);
			return (double)GetAltitudeAboveSeaLevel(framePosition) - terrainVertexData.Height;
		}

		public float GetAltitudeAboveSeaLevel(Vector3 framePosition)
		{
			return _terrainAlignedTransform.InverseTransformPoint(framePosition).y;
		}

		public float GetAltitudeAboveSeaLevelWithWave(Vector3 framePosition)
		{
			return GetAltitudeAboveSeaLevel(framePosition) - ReferenceFrame.GetWaterWaveOffset(framePosition, this);
		}

		public float GetAltitudeAboveSeaLevelWithWave(Vector3 framePosition, float waveOffset)
		{
			return GetAltitudeAboveSeaLevel(framePosition) - waveOffset;
		}

		public float GetColliderSubmergedPercent(Collider collider)
		{
			if (!collider.enabled || !collider.gameObject.activeInHierarchy)
			{
				Debug.LogWarning("Requesting submerged percent for a disabled collider (" + collider.name + " is not supported. Part: " + collider.GetComponentInParent<PartScript>().name, collider.gameObject);
				return 0f;
			}
			_ = collider.bounds;
			Vector3 framePosition = FramePosition;
			Vector3 vector = _flightData.GravityFrame * 2000f;
			Vector3 position = framePosition - vector;
			Vector3 position2 = framePosition + vector;
			Vector3 framePosition2 = collider.ClosestPoint(position2);
			Vector3 framePosition3 = collider.ClosestPoint(position);
			float num;
			float num2;
			if (_waterWavesEnabled)
			{
				float waterWaveOffset = ReferenceFrame.GetWaterWaveOffset(collider.transform.position, this);
				if (_enableDebugBall)
				{
					Vector3 waterPosBelowPoint = ReferenceFrame.GetWaterPosBelowPoint(collider.transform.position, includeWaves: false, this);
					DebugGizmos.DrawBall($"{collider.gameObject.GetInstanceID()}- {collider.name} wave", waterPosBelowPoint + _terrainAlignedTransform.up * waterWaveOffset, 0.1f, Color.blue, emissive: false);
				}
				num = GetAltitudeAboveSeaLevelWithWave(framePosition2, waterWaveOffset);
				num2 = GetAltitudeAboveSeaLevelWithWave(framePosition3, waterWaveOffset);
			}
			else
			{
				num = GetAltitudeAboveSeaLevel(framePosition2);
				num2 = GetAltitudeAboveSeaLevel(framePosition3);
			}
			float result = 0f;
			if (num <= 0f)
			{
				float num3 = num2 - num;
				result = ((!(num2 <= 0f)) ? Mathf.Clamp(Mathf.Abs(num) / num3, 0f, 1f) : 1f);
			}
			return result;
		}

		public FuelMonitor GetOrCreateFuelMonitor()
		{
			if (_fuelMonitor == null)
			{
				_fuelMonitor = new FuelMonitor(this);
			}
			return _fuelMonitor;
		}

		public IPartScript GetPayloadPart(string payloadId, int contractNumber, string payloadTrackingId)
		{
			PartData partData = null;
			if (!string.IsNullOrWhiteSpace(payloadTrackingId))
			{
				partData = Data.Assembly.Parts.Where((PartData x) => x.Payload?.PayloadTrackingId == payloadTrackingId).FirstOrDefault();
			}
			else
			{
				List<PartData> source = Data.Assembly.Parts.Where((PartData x) => x.Payload?.PayloadId == payloadId && x.Payload?.PayloadTrackingId == null).ToList();
				partData = source.Where(delegate(PartData x)
				{
					IPayload payload = x.Payload;
					return payload != null && payload.ContractNumber == contractNumber;
				}).FirstOrDefault();
				if (partData == null)
				{
					partData = source.Where(delegate(PartData x)
					{
						IPayload payload = x.Payload;
						return payload != null && payload.ContractNumber == 0;
					}).FirstOrDefault();
				}
			}
			return partData?.PartScript;
		}

		public float GetVerticalVelocity()
		{
			return _terrainAlignedTransform.InverseTransformDirection(RootPart.BodyScript.SurfaceVelocity).y;
		}

		public void Initialize(CraftData craft)
		{
			Data = craft;
			foreach (ThemeData theme in craft.Themes)
			{
				Game.Instance.ThemeManager.RequestTheme(theme);
			}
			_terrainAlignedTransform = new GameObject("TerrainAlignedTransform").transform;
			_terrainAlignedTransform.SetParent(base.transform, worldPositionStays: false);
			_waterWavesEnabled = WaterMaterialModifier.AreWavesEnabled();
			Game.Instance.QualitySettings.Water.Waves.Changed += OnWaterWavesEnabledChanged;
			MemoryLeakUtility.Track(this, craft.Name);
		}

		public void InitializeFromSourceCraft(ICraftScript sourceCraftScript)
		{
			_flightData.InitializeFromSource(sourceCraftScript.FlightData);
		}

		public void InitiateDragRecalculation()
		{
			_recalculateDrag = true;
		}

		public void OnCraftLoaded(bool movedToNewCraft, bool initialLaunch)
		{
			foreach (PartData part in Data.Assembly.Parts)
			{
				if (part.IsRootPart)
				{
					RootPart = part.PartScript;
				}
			}
			RebuildCraftStructure(raiseStructureChangedEvent: false);
			foreach (PartData part2 in Data.Assembly.Parts)
			{
				PartScript partScript = part2.PartScript as PartScript;
				partScript.OnCraftLoaded(this, movedToNewCraft);
				if (initialLaunch)
				{
					partScript.OnInitialLaunch();
				}
				if (initialLaunch && partScript.Disconnected)
				{
					part2.Config.PreventDebris = true;
				}
			}
		}

		public void OnDockBegin(IDockingPortScript portA, IDockingPortScript portB)
		{
			this.DockBegin?.Invoke(portA, portB);
		}

		public void OnDockComplete(string playerCraftName, int playerNodeId, string otherCraftName, int otherNodeId)
		{
			this.DockComplete?.Invoke(playerCraftName, playerNodeId, otherCraftName, otherNodeId);
			if (AchievementHelper.IsInSpace(this) && Game.Instance.LevelManager.CurrentLevel == null && playerNodeId != otherNodeId)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.FirstDocking);
			}
		}

		public void OnEngineActivationStatusChanged(bool activated)
		{
			_flightData.OnStructureChanged();
		}

		public void OnNodeLoaded()
		{
			RepositionTerrainAlignedTransform();
			UpdateEventSubscriptions(subscribe: true);
			foreach (PartData part in Data.Assembly.Parts)
			{
				(part.PartScript as PartScript).OnNodeLoaded();
			}
			UpdateFlightData();
		}

		public void OnPartCollisionEnter(IPartFlightCollision partCollision)
		{
			this.PartCollisionEnter?.Invoke(partCollision);
		}

		public void OnPartExploded(PartData part)
		{
			this.PartExploded?.Invoke(part);
		}

		public void OnPreNodeLoaded()
		{
			foreach (PartData part in Data.Assembly.Parts)
			{
				(part.PartScript as PartScript).OnPreNodeLoaded();
			}
		}

		public void QueueInertiaTensorRecalculation(IBodyScript bodyScript)
		{
			if (!_inertiaTensorRecalculationQueue.Contains(bodyScript))
			{
				_inertiaTensorRecalculationQueue.Enqueue(bodyScript);
			}
		}

		public void RaiseCraftSplitEvent()
		{
			this.CraftSplit?.Invoke(this);
		}

		public void RaiseDesignerCraftStructureChangedEvent()
		{
			if (Game.InFlightScene)
			{
				Debug.LogError("This method cannot be called from the flight scene. Call SetStructureChanged instead.");
			}
			else
			{
				RebuildCraftStructure(raiseStructureChangedEvent: true);
			}
		}

		public void RecalculateCenterOfMass()
		{
			Vector3d zero = Vector3d.zero;
			double num = 0.0;
			if (Game.InFlightScene)
			{
				IReadOnlyList<BodyData> bodies = Data.Assembly.Bodies;
				for (int i = 0; i < bodies.Count; i++)
				{
					IBodyScript bodyScript = bodies[i].BodyScript;
					if (!bodyScript.Disconnected)
					{
						zero += new Vector3d(bodyScript.WorldCenterOfMass) * bodyScript.RigidBody.mass;
						num += (double)bodyScript.RigidBody.mass;
					}
				}
			}
			else
			{
				foreach (PartData part in new PartGraph(RootPart.Data, breakOnRigidBodyBoundary: false).Parts)
				{
					double num2 = part.Mass;
					zero += new Vector3d(part.PartScript.Transform.position) * num2;
					num += num2;
				}
			}
			if (num > 0.0)
			{
				SetCenterOfMassGameObjectPosition((zero / num).ToVector3());
			}
			else
			{
				SetCenterOfMassGameObjectPosition(RootPart.Transform.position);
			}
			Mass = (float)num;
		}

		public void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta, Vector3 frameZeroVelocity)
		{
			RecenterDebris(positionDelta, velocityDelta);
			_frameVelocity = null;
			List<ParticleSystem> value;
			using (CollectionPool<List<ParticleSystem>, ParticleSystem>.Get(out value))
			{
				base.gameObject.GetComponentsInChildren(value);
				for (int i = 0; i < value.Count; i++)
				{
					RepositionParticleSystem(value[i], positionDelta, velocityDelta);
				}
			}
			IReadOnlyList<PartData> parts = Data.Assembly.Parts;
			for (int j = 0; j < parts.Count; j++)
			{
				List<PartModifierScript> modifiers = parts[j].PartScript.Modifiers;
				for (int k = 0; k < modifiers.Count; k++)
				{
					modifiers[k].RecalculateFrameState(positionDelta, velocityDelta);
				}
			}
		}

		public void RecenterTransformOnCoM(bool updateRotation)
		{
			if (_tempChildPositions == null || _tempChildPositions.Length != base.transform.childCount)
			{
				_tempChildPositions = new Vector3[base.transform.childCount];
				_tempChildRotations = new Quaternion[base.transform.childCount];
			}
			Vector3 position = CenterOfMass.position;
			Quaternion rotation = CenterOfMass.rotation;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				_tempChildPositions[i] = child.position;
				_tempChildRotations[i] = child.rotation;
			}
			if (updateRotation)
			{
				base.transform.SetPositionAndRotation(position, rotation);
			}
			else
			{
				base.transform.position = position;
			}
			for (int j = 0; j < base.transform.childCount; j++)
			{
				Transform child2 = base.transform.GetChild(j);
				child2.position = _tempChildPositions[j];
				if (updateRotation)
				{
					child2.rotation = _tempChildRotations[j];
				}
			}
			if (_craftNode == null || !_craftNode.InContactWithPlanet || !(_flightData.VelocityMagnitude < 0.10000000149011612))
			{
				return;
			}
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				if (body.BodyScript.RigidBody.velocity.magnitude < 0.1f)
				{
					body.BodyScript.RigidBody.Sleep();
				}
			}
		}

		public void RestoreActiveCommandPod()
		{
			ICommandPod commandPod = Data.Assembly.GetPartById(Data.ActiveCommandPodId)?.PartScript?.GetModifier<CommandPodScript>();
			ICommandPod activeCommandPod = commandPod ?? PrimaryCommandPod;
			SetActiveCommandPod(activeCommandPod);
		}

		public void SetActiveCommandPod(ICommandPod commandPod)
		{
			if (commandPod == null || commandPod.Part.PartScript.CraftScript.Data == Data)
			{
				ICommandPod activeCommandPod = ActiveCommandPod;
				this.ActiveCommandPodChanging?.Invoke(this, ActiveCommandPod, activeCommandPod);
				ActiveCommandPod = commandPod;
				this.ActiveCommandPodChanged?.Invoke(this, ActiveCommandPod, activeCommandPod);
				Data.ActiveCommandPodId = commandPod?.Part.Id ?? 0;
				return;
			}
			throw new InvalidOperationException("Specified command pod is not in this craft node.");
		}

		public void SetMassChanged()
		{
			_recalculateMass = true;
		}

		public void SetPrimaryCommandPod(ICommandPod commandPod, bool saveUndoStep = true)
		{
			if (!Game.InDesignerScene)
			{
				throw new InvalidOperationException("SetPrimaryCommandPod can only be called from the designer");
			}
			if (saveUndoStep)
			{
				Game.Instance.Designer.CreateUndoStep();
			}
			IPartScript partScript = commandPod.Part.PartScript;
			if (partScript.SymmetrySlice != null)
			{
				Debug.Log("Symmetry removed from new primary command pod");
				Symmetry.RemoveSymmetryGroup(partScript.SymmetrySlice.SymmetryGroup);
			}
			PartData partData = RootPart.Data.GetModifier<CommandPodData>()?.Part;
			foreach (PartData part in Data.Assembly.Parts)
			{
				if (part.CommandPod == partData)
				{
					part.CommandPod = commandPod.Part;
				}
			}
			if (partData != null)
			{
				partData.IsRootPart = false;
			}
			RootPart = partScript;
			commandPod.Part.IsRootPart = true;
			Data.ActiveCommandPodId = commandPod.Part.Id;
			_centerOfMassTransform.SetParent(RootPart.Transform);
			SetStructureChanged();
		}

		public void SetStructureChanged()
		{
			_structureChanged = true;
		}

		public void SetVelocity(Vector3 velocity)
		{
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				body.BodyScript.RigidBody.velocity = velocity;
			}
			_frameVelocity = null;
		}

		public void Unload()
		{
			foreach (ThemeData theme in Data.Themes)
			{
				Game.Instance.ThemeManager.ReleaseTheme(theme.Theme);
				theme.Theme = null;
			}
			UpdateEventSubscriptions(subscribe: false);
			_fuelMonitor?.Dispose();
			_fuelMonitor = null;
			_craftFuelSources.Dispose();
			CraftNode = null;
			this.CraftStructureChanged = null;
			base.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void UpdateFuelSourcesForDebris(PartLookup partIsland)
		{
			List<CraftFuelSource> list = new List<CraftFuelSource>();
			_craftFuelSources.CreateFuelSourceForConnectedParts(partIsland.Parts, removeDisconnectedCrossFeeds: true, list);
			foreach (CraftFuelSource item in list)
			{
				item.SupportsFuelTransfer = false;
			}
		}

		public void ValidateCraft(ValidationResult result)
		{
			foreach (PartData part in Data.Assembly.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					modifier.GetScript()?.ValidatePart(result);
				}
				foreach (PartConnection partConnection in part.PartConnections)
				{
					if (partConnection.Attachments.Count == 1 && partConnection.Attachments[0].AttachPointA.RequiresPhysicsJoint && partConnection.Attachments[0].AttachPointB.RequiresPhysicsJoint)
					{
						result.AddMessage("BadAttachment", "The part is using an invalid attachment. Connecting two shafts to eachother isn't supported.", part, ValidationMessageType.Warning);
					}
				}
			}
		}

		protected virtual void Awake()
		{
			_flightData = new CraftFlightData(this);
			FuelTransfer = new FuelTransferManager(this);
			OrientationMode = CraftOrientationMode.Rocket;
			CraftAudio = new CraftAudio(this);
			InletAir = new InletAir();
			Game.Instance.QualitySettings.Crafts.Reflections.Changed += ShadowsOrReflectionsQualityChanged;
			Game.Instance.QualitySettings.Shadows.Changed += ShadowsOrReflectionsQualityChanged;
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.Crafts.Reflections.Changed -= ShadowsOrReflectionsQualityChanged;
			Game.Instance.QualitySettings.Shadows.Changed -= ShadowsOrReflectionsQualityChanged;
			Game.Instance.QualitySettings.Water.Waves.Changed -= OnWaterWavesEnabledChanged;
			foreach (ThemeData theme in Data.Themes)
			{
				if (theme.Theme != null)
				{
					Game.Instance.ThemeManager.ReleaseTheme(theme.Theme);
					theme.Theme = null;
				}
			}
			if (Game.InFlightScene)
			{
				UnityEngine.Object.Destroy(_centerOfMassTransform.gameObject);
				UnityEngine.Object.Destroy(_cameraTarget.gameObject);
				if (CraftNode != null)
				{
					CraftNode.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
				}
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private unsafe static void RepositionParticles([NoAlias] ParticleSystem.Particle* particles, int particleCount, Vector3* positionDelta, Vector3* velocityDelta)
		{
			RepositionParticles_0000519F_0024BurstDirectCall.Invoke(particles, particleCount, positionDelta, velocityDelta);
		}

		private void CalculateInertiaTensor()
		{
			if (!Game.InFlightScene)
			{
				return;
			}
			Transform centerOfMass = CenterOfMass;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				if (!body.BodyScript.Disconnected && !body.BodyScript.IsDebris)
				{
					Rigidbody rigidBody = body.BodyScript.RigidBody;
					Vector3 vector = centerOfMass.InverseTransformPoint(rigidBody.transform.position);
					float num = vector.y * vector.y + vector.z * vector.z;
					float num2 = vector.x * vector.x + vector.z * vector.z;
					float num3 = vector.x * vector.x + vector.y * vector.y;
					Vector3 vector2 = new Vector3(num * rigidBody.mass, num2 * rigidBody.mass, num3 * rigidBody.mass);
					zero2 += vector2;
					Vector3 vector3 = rigidBody.transform.TransformDirection(rigidBody.inertiaTensor);
					zero += new Vector3(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y), Mathf.Abs(vector3.z));
				}
			}
			Vector3 vector4 = centerOfMass.InverseTransformDirection(zero);
			zero2 += new Vector3(Mathf.Abs(vector4.x), Mathf.Abs(vector4.y), Mathf.Abs(vector4.z));
			InertiaTensor = zero2;
		}

		private void EnablePhysics(bool enable)
		{
			_physicsEnabled = enable;
			foreach (PartData part in Data.Assembly.Parts)
			{
				foreach (PartModifierScript modifier in part.PartScript.Modifiers)
				{
					modifier.OnBeforePhysicsChanged(enable);
				}
			}
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				if (enable)
				{
					body.BodyScript.RigidBody.isKinematic = false;
				}
				else
				{
					body.BodyScript.RigidBody.isKinematic = true;
				}
			}
			_frameVelocity = null;
			if (!enable)
			{
				RecenterDebris(Vector3.zero, Vector3.zero);
				RecenterTransformOnCoM(updateRotation: true);
			}
			foreach (PartData part2 in Data.Assembly.Parts)
			{
				foreach (PartModifierScript modifier2 in part2.PartScript.Modifiers)
				{
					modifier2.OnPhysicsChanged(enable);
				}
			}
		}

		private List<IRendererMaterialMap> GetAllRenderers()
		{
			List<IRendererMaterialMap> list = new List<IRendererMaterialMap>();
			IReadOnlyList<BodyData> readOnlyList = Data?.Assembly?.Bodies;
			if (readOnlyList == null)
			{
				return list;
			}
			foreach (BodyData item in readOnlyList)
			{
				IReadOnlyList<IPartGroupScript> readOnlyList2 = item?.BodyScript?.PartGroups;
				if (readOnlyList2 == null)
				{
					continue;
				}
				foreach (IPartGroupScript item2 in readOnlyList2)
				{
					if (item2.PartGroupRenderer != null)
					{
						list.Add(item2.PartGroupRenderer);
					}
					List<PartData> list2 = item2?.Data?.Parts;
					if (list2 == null)
					{
						continue;
					}
					foreach (PartData item3 in list2)
					{
						IPartMaterialScript partMaterialScript = item3?.PartScript?.PartMaterialScript;
						if (partMaterialScript != null)
						{
							list.AddRange(partMaterialScript.RendererMaps);
						}
					}
				}
			}
			return list;
		}

		private void InitializePartGroups()
		{
			if (!Game.InFlightScene)
			{
				return;
			}
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				foreach (PartGroupScript item in body.BodyScript.PartGroups.Cast<PartGroupScript>())
				{
					item.Initialize();
				}
			}
		}

		private void LateUpdate()
		{
			if (_firstFrame && !Game.InDesignerScene && !Game.InFlightScene)
			{
				_firstFrame = false;
				OnInitialized();
			}
		}

		private void MonitorCameraFocusTransform()
		{
			LifeCycleEventsNotifier monitor = _cameraTarget.gameObject.AddComponent<LifeCycleEventsNotifier>();
			monitor.Disabled.AddListener(delegate
			{
				ResetCameraFocus();
			});
			void ResetCameraFocus()
			{
				UnityEngine.Object.Destroy(monitor);
				_cameraFocus = null;
				if (_cameraTarget.parent != RootPart.Transform)
				{
					Transform cameraTarget = _cameraTarget;
					_cameraTarget = new GameObject("CameraTarget").transform;
					_cameraTarget.parent = RootPart.Transform;
					UnityEngine.Object.Destroy(cameraTarget.gameObject);
				}
			}
		}

		private void OnInitialized()
		{
			if (Game.InFlightScene)
			{
				CraftNode.NameChanged += OnNodeNameChanged;
				RootPart.Data.PreferredNodeName = CraftNode.Name;
			}
			_isInitialized = true;
			this._initialized?.Invoke(this);
		}

		private void OnNodeNameChanged(string newName, string oldName)
		{
			RootPart.Data.PreferredNodeName = newName;
		}

		private void OnPhysicsQualitySettingChanged(object sender, SettingChangedEventArgs<PhysicsQualitySettings.PhysicsUpdateFrequencyQuality> newSetting)
		{
			int solverIterations = PhysicsQualitySettings.GetSolverIterations(newSetting.Setting);
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				Rigidbody rigidbody = body.BodyScript?.RigidBody;
				if (rigidbody != null)
				{
					rigidbody.solverIterations = solverIterations;
				}
			}
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			if (e.EnteredWarpMode)
			{
				foreach (ICraftDebris item in _debris)
				{
					UnityEngine.Object.Destroy(item.Transform.gameObject);
				}
				_debris.Clear();
				List<BodyData> list = null;
				foreach (BodyData body in Data.Assembly.Bodies)
				{
					if (body.BodyScript.IsDebris)
					{
						if (list == null)
						{
							list = new List<BodyData>();
						}
						list.Add(body);
					}
				}
				if (list != null)
				{
					foreach (BodyData item2 in list)
					{
						DestroyBody(item2);
					}
				}
			}
			this.TimeMultiplierModeChanged?.Invoke(e);
		}

		private void OnWaterWavesEnabledChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			_waterWavesEnabled = WaterMaterialModifier.AreWavesEnabled();
		}

		private bool ProcessDisconnectedBodies()
		{
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				if (!body.IsDestroyed && body.BodyScript.Disconnected && !body.BodyScript.IsDebris)
				{
					CraftSplitter.ProcessDisconnectedBody(body, this);
					return true;
				}
			}
			return false;
		}

		private void RebuildCraftStructure(bool raiseStructureChangedEvent)
		{
			foreach (PartData part in Data.Assembly.Parts)
			{
				(part.PartScript as PartScript).Disconnected = true;
			}
			foreach (BodyData body in Data.Assembly.Bodies)
			{
				BodyScript bodyScript = body.BodyScript as BodyScript;
				if (bodyScript != null)
				{
					bodyScript.Disconnected = true;
					bodyScript.OnCraftStructureChanging();
				}
			}
			_flightProgramScripts = null;
			_commandPods.Clear();
			NumAstronauts = 0;
			if (!RootPart.Data.IsDestroyed)
			{
				foreach (PartData part2 in new PartGraph(RootPart.Data, breakOnRigidBodyBoundary: false).Parts)
				{
					PartScript partScript = part2.PartScript as PartScript;
					partScript.Disconnected = false;
					if (part2.PartType.IsCommandPod)
					{
						CommandPodScript modifier = partScript.GetModifier<CommandPodScript>();
						_commandPods.Add(modifier);
						if (partScript.HasModifier<EvaScript>())
						{
							NumAstronauts++;
						}
					}
					BodyScript bodyScript2 = partScript.BodyScript as BodyScript;
					if (bodyScript2 != null)
					{
						bodyScript2.Disconnected = false;
					}
				}
			}
			if (_craftFuelSources == null)
			{
				_craftFuelSources = new CraftFuelSources(FuelTransfer);
				_craftFuelSources.Rebuild(this);
			}
			else if (Game.InDesignerScene)
			{
				_craftFuelSources.Rebuild(this);
			}
			if (Game.InFlightScene)
			{
				foreach (PartData part3 in Data.Assembly.Parts)
				{
					if (part3.PartScript.Disconnected && !part3.PartScript.BodyScript.Disconnected)
					{
						Debug.LogErrorFormat("There is an orphaned part (id: {0}, type: {1}). They do exist in the wild.", part3.Id, part3.PartType.Name);
					}
				}
				_processDisconnectedBodies = true;
				_flightData.OnStructureChanged();
			}
			RecalculateCenterOfMass();
			CalculateInertiaTensor();
			_lastRebuildCenterOfMass = _centerOfMassTransform.localPosition;
			if (!raiseStructureChangedEvent)
			{
				return;
			}
			foreach (PartData part4 in Data.Assembly.Parts)
			{
				part4.PartScript.OnCraftStructureChanged();
			}
			this.CraftStructureChanged?.Invoke();
		}

		private void RecenterDebris(Vector3 positionDelta, Vector3 velocityDelta)
		{
			List<BodyData> list = null;
			Vector3 position = RootPart.Transform.position;
			IReadOnlyList<BodyData> bodies = Data.Assembly.Bodies;
			for (int i = 0; i < bodies.Count; i++)
			{
				BodyData bodyData = bodies[i];
				Rigidbody rigidBody = bodyData.BodyScript.RigidBody;
				if ((_craftNode.AltitudeAgl > 500.0 || _craftNode.IsDestroyed) && bodyData.BodyScript.IsDebris && ((rigidBody.transform.position - position).sqrMagnitude > 1000000f || _craftNode.IsDestroyed))
				{
					if (list == null)
					{
						list = new List<BodyData>();
					}
					list.Add(bodyData);
				}
				rigidBody.transform.position += positionDelta;
				if (!rigidBody.isKinematic)
				{
					rigidBody.velocity += velocityDelta;
				}
				((BodyScript)bodyData.BodyScript).OnRecentered();
			}
			if (list != null)
			{
				foreach (BodyData item in list)
				{
					DestroyBody(item);
				}
			}
			if (_debris.Count <= 0 || !(CraftNode.AltitudeAgl > 500.0))
			{
				return;
			}
			List<ICraftDebris> list2 = new List<ICraftDebris>();
			foreach (ICraftDebris item2 in _debris)
			{
				item2.Transform.position += positionDelta;
				item2.RigidBody.velocity += velocityDelta;
				if ((item2.Transform.position - Transform.position).sqrMagnitude > 1000000f)
				{
					list2.Add(item2);
				}
			}
			foreach (ICraftDebris item3 in list2)
			{
				_debris.Remove(item3);
				UnityEngine.Object.Destroy(item3.Transform.gameObject);
			}
		}

		private void RepositionTerrainAlignedTransform()
		{
			_terrainAlignedTransform.position = FramePosition + (float)CraftNode.Altitude * _flightData.GravityFrameNormalized;
			_terrainAlignedTransform.up = -_flightData.GravityFrame;
		}

		private void SetCenterOfMassGameObjectPosition(Vector3 position)
		{
			if (_centerOfMassTransform == null)
			{
				Transform transform = new GameObject("CenterOfMass").transform;
				transform.SetParent(RootPart.Transform, worldPositionStays: false);
				transform.localPosition = Vector3.zero;
				transform.localScale = Vector3.one;
				if (Game.InFlightScene)
				{
					GameObject gameObject = new GameObject("CameraTarget");
					_cameraTarget = gameObject.transform;
					_cameraTarget.SetParent(RootPart.Transform, worldPositionStays: false);
					_cameraTarget.SetLocalPositionAndRotation(transform.localPosition, Quaternion.identity);
					_cameraTarget.localScale = Vector3.one;
					_cameraTarget.position = position;
				}
				_centerOfMassTransform = transform;
			}
			ICommandPod commandPod = ActiveCommandPod ?? PrimaryCommandPod;
			if (commandPod != null)
			{
				_centerOfMassTransform.rotation = commandPod.PilotSeatOrientation.rotation;
				if (_cameraTarget != null)
				{
					_cameraTarget.rotation = _centerOfMassTransform.rotation;
				}
			}
			_centerOfMassTransform.position = position;
			Data.LocalCenterOfMass = _centerOfMassTransform.localPosition;
		}

		private void ShadowsOrReflectionsQualityChanged(object sender, EventArgs e)
		{
			IGameQualitySettings qualitySettings = Game.Instance.QualitySettings;
			ShadowQualitySettings shadows = qualitySettings.Shadows;
			CraftQualitySettings crafts = qualitySettings.Crafts;
			foreach (IRendererMaterialMap allRenderer in GetAllRenderers())
			{
				Renderer renderer = allRenderer.Renderer;
				shadows.ConfigurePartRenderer(renderer);
				crafts.ConfigurePartRenderer(renderer);
			}
		}

		private void UpdateCameraTarget(float unscaledDeltaTime)
		{
			if (_cameraTarget != null)
			{
				if (CameraFocus == null)
				{
					Vector3 vector = _centerOfMassTransform.localPosition - _cameraTarget.localPosition + _cameraTargetOffset;
					_cameraTarget.localPosition += 5f * Mathf.Clamp(unscaledDeltaTime, 0f, 0.2f) * vector;
				}
				else
				{
					Vector3 vector2 = CameraFocus.position - _cameraTarget.position;
					_cameraTarget.position += 5f * Mathf.Clamp(unscaledDeltaTime, 0f, 0.2f) * vector2;
				}
			}
		}

		private void UpdateEventSubscriptions(bool subscribe)
		{
			if (Game.InFlightScene)
			{
				if (subscribe)
				{
					Game.Instance.QualitySettings.Physics.PhysicsUpdateFrequency.Changed += OnPhysicsQualitySettingChanged;
					CraftNode.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
				}
				else
				{
					Game.Instance.QualitySettings.Physics.PhysicsUpdateFrequency.Changed -= OnPhysicsQualitySettingChanged;
					CraftNode.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
				}
			}
		}

		private void UpdateFlightData()
		{
			_flightData.Update(Game.Instance.FlightScene.FlightSceneUI.NavSphere);
			if (Game.Instance.QualitySettings.ImageEffects.ReEntry.Value == ImageEffectsQualitySettings.ReEntryQuality.On)
			{
				IReadOnlyList<BodyData> bodies = Data.Assembly.Bodies;
				float num = 0f;
				float num2 = 0f;
				for (int i = 0; i < bodies.Count; i++)
				{
					num += bodies[i].BodyScript.ReEntryEffectStrength * bodies[i].BodyScript.RigidBody.mass;
					num2 += bodies[i].BodyScript.RigidBody.mass;
				}
				_reEntryEffectIntensity = num / num2;
			}
			else
			{
				_reEntryEffectIntensity = 0f;
			}
		}

		private void UpdateInContactWithPlanetStatus()
		{
			bool flag = false;
			bool flag2 = false;
			IReadOnlyList<BodyData> bodies = Data.Assembly.Bodies;
			for (int i = 0; i < bodies.Count; i++)
			{
				BodyData bodyData = bodies[i];
				if (!bodyData.BodyScript.Disconnected)
				{
					flag = flag || bodyData.BodyScript.CollidingWithTerrain;
					flag2 = flag2 || bodyData.BodyScript.WaterPhysics.UnderWaterAmount > 0f;
				}
			}
			_craftNode.InContactWithPlanet = flag || flag2;
			_craftNode.InContactWithWater = flag2;
			_craftNode.WaterDepth = (flag2 ? Mathd.Max(0.0, _craftNode.AltitudeAboveTerrain - _craftNode.AltitudeAgl) : 0.0);
		}

		private void UpdateNavballHooks()
		{
			if (this.NavballRotationUpdate == null && this.NavballVectorUpdate == null)
			{
				return;
			}
			INavSphere navSphere = FlightSceneScript.Instance.FlightSceneUI.NavSphere;
			Quaternion groundRotation = Quaternion.Inverse(Quaternion.LookRotation(FlightData.North.ToVector3(), FlightData.PositionNormalized.ToVector3()));
			Quaternion obj = groundRotation * ReferenceFrame.FrameToPlanetRotation(CenterOfMass.rotation).ToQuaternion();
			this.NavballRotationUpdate?.Invoke(obj);
			Vector3? arg = null;
			Func<NavSphereIndicatorType, Vector3d?> getVector;
			if (FlightSceneScript.Instance.CraftNode == CraftNode)
			{
				getVector = navSphere.GetVectorFunc();
				if (navSphere.HeadingLocked)
				{
					arg = groundRotation * _craftNode.Controls.TargetDirection.GetValueOrDefault().ToVector3();
				}
			}
			else
			{
				Dictionary<NavSphereIndicatorType, Vector3d?> vectors = new Dictionary<NavSphereIndicatorType, Vector3d?>();
				NavSphereScript.UpdateVectors(vectors, navSphere.VelocityMode, CraftNode, null, null);
				getVector = (NavSphereIndicatorType t) => vectors[t];
			}
			SetVector(0, NavSphereIndicatorType.VelocityPrograde);
			SetVector(1, NavSphereIndicatorType.VelocityRetrograde);
			SetVector(2, NavSphereIndicatorType.RadialOut);
			SetVector(3, NavSphereIndicatorType.RadialIn);
			SetVector(4, NavSphereIndicatorType.Normal);
			SetVector(5, NavSphereIndicatorType.AntiNormal);
			SetVector(6, NavSphereIndicatorType.Target);
			SetVector(7, NavSphereIndicatorType.AntiTarget);
			SetVector(8, NavSphereIndicatorType.ManeuverNode);
			this.NavballVectorUpdate?.Invoke(9, arg);
			void SetVector(int index, NavSphereIndicatorType vector)
			{
				Vector3? arg2 = getVector(vector)?.ToVector3();
				if (arg2.HasValue)
				{
					arg2 = groundRotation * arg2.Value;
				}
				this.NavballVectorUpdate?.Invoke(index, arg2);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(CompileSynchronously = true)]
		public unsafe static void RepositionParticles_0024BurstManaged([NoAlias] ParticleSystem.Particle* particles, int particleCount, Vector3* positionDelta, Vector3* velocityDelta)
		{
			Vector3 vector = *positionDelta;
			Vector3 vector2 = *velocityDelta;
			for (int i = 0; i < particleCount; i++)
			{
				particles[i].position += vector;
				particles[i].velocity += vector2;
			}
		}
	}
}
