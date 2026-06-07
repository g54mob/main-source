using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Simulation;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Multiplayer.SyncData;
using Assets.Scripts.Rendering;
using Assets.Scripts.Settings;
using Jundroo.Common.Events;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using NWH.Common.Utility;
using NWH.VehiclePhysics2.Powertrain;
using Shapes;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	[BurstCompile(CompileSynchronously = true)]
	public class PropellerAssemblyScript : PowertrainModifierScript, IPartCollisionHandler, IFlightGizmo, IDesignerThrust
	{
		private static class Profile
		{
			public static readonly ProfilerMarker DrawPropsInFlightScene = new ProfilerMarker("PropellerAssemblyScript.DrawPropsInFlightScene");
		}

		private class PropellerDebris : MonoBehaviour
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
				_body.angularDamping = 0.5f;
				_body.linearDamping = 0.25f;
				float num3 = Mathf.Min(num * (fromCollision ? 0.5f : 3f), 50f);
				Vector3 normalized = Vector3.Lerp(num2 * bladeTipDir, b, 0.5f).normalized;
				_body.linearVelocity = normalized * num3;
				bladeRoot.parent = _body.transform;
				collider.transform.parent = _body.transform;
				_body.centerOfMass = Vector3.zero;
				if (fromCollision)
				{
					AudioManager.PlaySound(AudioStore.PartBreakOffAudio, rootPos, 0.5f);
				}
				else
				{
					AudioManager.PlaySound(AudioStore.PartBreakOffAlternate, rootPos, 0.5f);
				}
				bladeRoot.GetComponentInChildren<MeshRenderer>(includeInactive: true).enabled = true;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void UpdatePropBlurMatrices_000071DB_0024PostfixBurstDelegate([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees);

		internal static class UpdatePropBlurMatrices_000071DB_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<UpdatePropBlurMatrices_000071DB_0024PostfixBurstDelegate>(UpdatePropBlurMatrices).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<Matrix4x4*, int, float3*, float3*, quaternion*, quaternion*, float, void>)functionPointer)(matrices, count, positionPtr, scalePtr, baseRotationPtr, localRotationPtr, stepRotationDegrees);
						return;
					}
				}
				UpdatePropBlurMatrices_0024BurstManaged(matrices, count, positionPtr, scalePtr, baseRotationPtr, localRotationPtr, stepRotationDegrees);
			}
		}

		private const float MaxAlphaSpeed = 1000f;

		private const int MaxInstancedMeshes = 511;

		private const float MaxSpreadSpeed = 1000f;

		private const float MinRpmForBlurredBlades = 50f;

		private static readonly int AlphaOverrideShaderId = Shader.PropertyToID("_AlphaOverride");

		private List<BladeAssembly> _additionalPropellers = new List<BladeAssembly>();

		private List<BladeAssembly> _allPropellers = new List<BladeAssembly>();

		private AudioSource _audio;

		private LPFbyDistance _audioFilter;

		[SerializeField]
		private Mesh _bladeMeshCombined;

		private PropAssemblyConfig _config;

		private ReflectionProbe _craftReflectionProbe;

		private EnumSetting<CraftQualitySettings.CraftReflectionsQuality> _craftReflectionsSetting;

		private bool _destroyed;

		private float _diameterScaled;

		private float _dragTorque;

		private float _enteredWaterTime;

		private ReflectionProbe _globalReflectionProbe;

		private PIDController _governorPidController;

		private Dictionary<AttachPointScript, Vector3> _initialAttachpointPositions = new Dictionary<AttachPointScript, Vector3>();

		private Joint _joint;

		private Vector3 _lastAV;

		private Vector3 _liftForce;

		private float _localAngularVelocity;

		private BladeAssembly _masterPropeller;

		private PropellerPowertrainComponent _nwhPowertrainComponent;

		private IInputController _pitchInput;

		private IPowertrain _powertrain;

		[SerializeField]
		private Material _propBlurMaterial;

		private Matrix4x4[] _propBlurMatrices;

		private Transform _propContainer;

		private Vector3 _propContainerInitialRotation;

		private List<PropellerDebris> _propDebris;

		[SerializeField]
		private Material _propDefaultMaterial;

		private IRigidBody _propellerBody;

		private Dictionary<Collider, Transform> _propellerColliderMap;

		private Rigidbody _propellerConnectedBody;

		private float _propellerPitchDegrees;

		private bool _propIsBroken;

		private MaterialPropertyBlock _propMaterialPropertyBlock;

		private PropellerPhysics _propPhysics;

		private Transform _propSpinner;

		private bool _refreshEditorColliders;

		private float _remoteTargetRpm;

		private Rigidbody _rigidBodyToAddForceTo;

		private bool _transActive;

		private float _visualRpmReductionScalar = 1f;

		private BoxCollider _waterCollider;

		private PartColliderScript _waterColliderScript;

		public Aerofoil Airfoil { get; private set; }

		public int BladeCount => Data.BladeCount;

		public float ChordScale => Data.ChordScale;

		public Transform ColliderContainer { get; private set; }

		public PropellerAssemblyData Data { get; set; }

		Vector3 IDesignerThrust.DesignerCenterOfThrust => base.transform.position;

		float IDesignerThrust.DesignerThrust => Data.Diameter * Data.Diameter * (float)Data.BladeCount;

		DesignerThrustTypes IDesignerThrust.DesignerThrustType => DesignerThrustTypes.PropAssembly;

		public float Diameter => Data.Diameter;

		public float DynamicThrustScalar { get; set; } = 1f;

		public bool EngineDestroyed { get; private set; }

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

		public float Thrust => _liftForce.magnitude;

		public Vector3 WorldPropellerAxis => base.transform.up;

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			if (inputConnection == null)
			{
				throw new ArgumentNullException("inputConnection");
			}
			inputConnection.ChildConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("PowertrainInput", base.gameObject)?.transform;
			return new PowertrainNode(this, inputConnection)
			{
				InitializePowertrain = delegate(IPowertrain powertrain, PowertrainComponent inputComponent)
				{
					PropellerPhysicsEnabled = true;
					_nwhPowertrainComponent = new PropellerPowertrainComponent
					{
						name = $"Prop-{base.PartScript.Part.Id}",
						inertia = PhysicsUtility.GetMomentOfInertiaAboutWorldAxis(base.PartScript.Body.RigidBody.PhysxRigidBody, WorldPropellerAxis) / 0.01f,
						PropellerAssembly = this
					};
					_powertrain = powertrain;
					return _nwhPowertrainComponent;
				}
			};
		}

		void IFlightGizmo.DrawFlightGizmo(Camera camera)
		{
			if (!base.isActiveAndEnabled || !base.PartScript.Aircraft.IsPrimaryLocalPlayer)
			{
				return;
			}
			Draw.Matrix = base.transform.localToWorldMatrix;
			Draw.BlendMode = ShapesBlendMode.Transparent;
			Draw.ThicknessSpace = ThicknessSpace.Noots;
			Draw.Thickness = 0.3f;
			Draw.Opacity = 0.5f;
			foreach (PropellerPhysics.BladeSegment segment in _propPhysics.Segments)
			{
				Vector3 vector = new Vector3(segment.Radius, 0f, 0f);
				Draw.Line(vector, vector + new Vector3(0f, ScaleGizmosMagnitude(segment.LiftMagnitude), 0f), (segment.LiftMagnitude > 0f) ? Color.green : Color.red);
				float num = (Data.ReverseBladeDirection ? 1f : (-1f));
				Draw.Line(vector, vector + new Vector3(0f, 0f, num * ScaleGizmosMagnitude(segment.TorqueMagnitude)), (segment.TorqueMagnitude > 0f) ? Color.yellow : Constants.Colors.Primary);
			}
		}

		public void FlightStart(in CraftUpdateFrameData frame)
		{
			CommonStart();
			Airfoil = Game.Instance.ResourceLoader.LoadAirfoil("NACAPROPCLARKY");
			_diameterScaled = Mathf.Pow(Diameter, 0.4f);
			BodyScript body = base.PartScript.Body;
			_propellerBody = body.RigidBody;
			StoreConnectedBodyInfo();
			CreatePropPhysicsScript();
			PropellerPhysicsEnabled = false;
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
			_governorPidController = new PIDController(100f, 0f, 1f, 0f - Data.MaxPitchRate, Data.MaxPitchRate);
			_audio = base.transform.GetComponent<AudioSource>();
			_audioFilter = _audio.gameObject.AddComponent<LPFbyDistance>();
			_audioFilter.Filter = _audio.gameObject.AddComponent<AudioLowPassFilter>();
			if (Data.MagicEngineId > 0 && !base.IsConnectedToEngine)
			{
				base.PartScript.Aircraft.GetPartById(Data.MagicEngineId)?.PartScript.GetModifierWithInterface<IMagicPowertrainSource>()?.RegisterSink(this);
			}
			InitializeFlightScenePropRendering();
			FlightSceneScript.Instance.FlightGizmos.RegisterGizmo(this);
		}

		public float GetDragTorque()
		{
			if (_propPhysics != null)
			{
				return _propPhysics.CalculatedDragTorque;
			}
			return 0f;
		}

		public override void InitializePartSyncData(PartSyncData syncData)
		{
			base.InitializePartSyncData(syncData);
			syncData.RegisterValue(new SyncFloat
			{
				Value = () => Rpm,
				ValueRead = delegate(float x)
				{
					_remoteTargetRpm = x;
				}
			});
		}

		bool IPartCollisionHandler.OnCollision(PartScript partScript, Collision collision, in ContactPoint contactPoint)
		{
			if (base.PartScript.Aircraft.RemoteAircraft)
			{
				return true;
			}
			if (RpmAbs > 100f && _propellerColliderMap != null)
			{
				Collider collider = collision?.GetContact(0).thisCollider;
				if (collider != null && _propellerColliderMap.TryGetValue(collider, out var propRoot))
				{
					if (_propDebris == null)
					{
						_propDebris = new List<PropellerDebris>(BladeCount);
					}
					_propDebris.Add(PropellerDebris.Create(this, propRoot, collider, Data.Radius, propRoot.transform.position, propRoot.transform.right, _lastAV, fromCollision: true));
					_propellerBody.PhysxRigidBody.ResetCenterOfMass();
					_propellerColliderMap.Remove(collider);
					if (!_propIsBroken)
					{
						foreach (KeyValuePair<Collider, Transform> mapItem in _propellerColliderMap)
						{
							UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
							{
								if (_propellerColliderMap.TryGetValue(mapItem.Key, out propRoot))
								{
									_propDebris.Add(PropellerDebris.Create(this, propRoot, mapItem.Key, Data.Radius, propRoot.transform.position, propRoot.transform.right, _propellerBody.angularVelocity, fromCollision: false));
									_propellerColliderMap.Remove(mapItem.Key);
									_propellerBody.PhysxRigidBody.ResetCenterOfMass();
								}
							}, UnityEngine.Random.Range(0.25f, 1.25f));
						}
					}
					_propIsBroken = true;
				}
			}
			return false;
		}

		public override void OnEnterWater()
		{
			base.OnEnterWater();
			_enteredWaterTime = Time.fixedTime;
		}

		public void OnFlightGizmosEnabled(bool enabled)
		{
		}

		public void OnSymmetry()
		{
			RebuildPropellerAssembly(repositionConnectedParts: true);
		}

		public void RebuildPropellerAssembly(bool repositionConnectedParts)
		{
			Transform bladePrefabRoot = _masterPropeller.BladePrefabRoot;
			while (bladePrefabRoot.childCount != 0)
			{
				UnityEngine.Object.DestroyImmediate(bladePrefabRoot.GetChild(0).gameObject);
			}
			Vector3 localScale = _masterPropeller.Blade.localScale;
			_masterPropeller.Blade.localScale = Vector3.one;
			GameObject obj = UnityEngine.Object.Instantiate(Data.PropellerPrefab.prefab);
			obj.GetComponentInChildren<MeshFilter>(includeInactive: true).gameObject.AddComponent<PropellerMeshTwister>().ApplyTwist(Data.TwistAngleRoot * ((Data.ReverseBladeDirection != Data.IsPushProp) ? 1f : (-1f)), 0f, PropellerMeshTwister.Axis.X, Data.ReverseBladeDirection);
			obj.transform.parent = bladePrefabRoot;
			obj.transform.localEulerAngles = Vector3.zero;
			obj.transform.localPosition = Vector3.zero;
			_transActive = CalculateDesiredCombinedBladeTransparency() > 0f;
			_masterPropeller.Blade.localScale = localScale;
			UpdateHubStyle();
			CreatePropellersFromMaster();
			UpdateScale(repositionConnectedParts);
			_refreshEditorColliders = true;
			base.PartScript.PartMaterialScript.InitializeMaterial();
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
			if (EngineDestroyed)
			{
				return;
			}
			float num = PropellerPitchDegrees;
			if (Data.ReverseBladeDirection)
			{
				num *= -1f;
			}
			if (Data.IsPushProp)
			{
				num *= -1f;
			}
			num *= Data.PropellerPitchScale;
			float num2 = 360f / (float)Data.BladeCount;
			float num3 = 0f;
			foreach (BladeAssembly allPropeller in _allPropellers)
			{
				allPropeller.Root.localEulerAngles = new Vector3(0f, num3, 0f);
				RotateBlade(allPropeller, 0f, num);
				num3 += num2;
			}
		}

		public void UpdatePropDirection()
		{
			RebuildPropellerAssembly(repositionConnectedParts: false);
		}

		public void UpdateRPMFromPowertrain(float rpm, float angularVelocityRadS)
		{
			Rpm = rpm * (Data.ReverseBladeDirection ? 1f : (-1f));
		}

		public void UpdateScale(bool repositionConnectedParts)
		{
			float num = (Data.Radius - _masterPropeller.Blade.localPosition.magnitude * 2f) / 1f;
			Vector3 localScale = new Vector3(num, num, num * ChordScale);
			foreach (BladeAssembly allPropeller in _allPropellers)
			{
				allPropeller.Blade.localScale = localScale;
			}
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				foreach (KeyValuePair<Collider, Transform> item in _propellerColliderMap)
				{
					item.Key.transform.localScale = Vector3.Scale(item.Key.transform.localScale, new Vector3(num, num, num * ChordScale));
				}
			}
			float num2 = Data.HubScale * num * Data.HubPrefab.baseScale;
			_propSpinner.localScale = num2 * Vector3.one;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				float num3 = num2;
				for (int i = 0; i < base.PartScript.AttachPointScripts.Count; i++)
				{
					AttachPointScript attachPointScript = base.PartScript.AttachPointScripts[i];
					Vector3 position = attachPointScript.transform.position;
					Vector3 vector = _initialAttachpointPositions[attachPointScript];
					Vector3 localPosition = num3 * vector;
					attachPointScript.transform.localPosition = localPosition;
					if (repositionConnectedParts && i == 0)
					{
						Vector3 vector2 = position - attachPointScript.transform.position;
						base.PartScript.transform.position += vector2;
					}
				}
			}
			else if (base.LoadContext == CraftLoadContext.Flight)
			{
				AddWaterCollider();
			}
		}

		protected void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				FlightSceneScript.Instance.FlightGizmos.UnregisterGizmo(this);
			}
			if (_propDebris != null)
			{
				foreach (PropellerDebris propDebri in _propDebris)
				{
					UnityEngine.Object.Destroy(propDebri.gameObject);
				}
				_propDebris.Clear();
			}
			if (_bladeMeshCombined != null)
			{
				UnityEngine.Object.Destroy(_bladeMeshCombined);
			}
			ThemeScript theme = base.PartScript?.Aircraft?.Theme;
			ReleaseMaterial(theme, transparent: true, ref _propBlurMaterial);
			ReleaseMaterial(theme, transparent: false, ref _propDefaultMaterial);
			static void ReleaseMaterial(ThemeScript themeScript, bool transparent, ref Material mat)
			{
				if (mat != null)
				{
					if (themeScript != null)
					{
						if (transparent)
						{
							themeScript.ReleaseTransparentPartMaterialInstance(mat);
						}
						else
						{
							themeScript.ReleaseDefaultPartMaterialInstance(mat);
						}
					}
					else
					{
						UnityEngine.Object.Destroy(mat);
					}
				}
				mat = null;
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
				{
					_initialAttachpointPositions.Add(attachPointScript, attachPointScript.transform.localPosition);
				}
			}
			CommonInitialization();
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				registrar.RegisterStart(FlightStart, CraftUpdateFlags.FlightDefault);
				registrar.RegisterFixedUpdate(FlightFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
				registrar.RegisterUpdate(FlightUpdate, CraftUpdateFlags.FlightUnpaused);
			}
			else if (base.LoadContext == CraftLoadContext.Designer)
			{
				registrar.RegisterStart(DesignerStart, CraftUpdateFlags.DesignerDefault);
				registrar.RegisterUpdate(DesignerUpdate, CraftUpdateFlags.DesignerDefault);
			}
			registrar.RegisterLateUpdate(OnLateUpdate);
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

		private static float ScaleGizmosMagnitude(float magnitude)
		{
			return Mathf.Sqrt(Mathf.Abs(magnitude)) * Mathf.Sign(magnitude) * 0.1f;
		}

		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		[MonoPInvokeCallback(typeof(Assets_002EScripts_002ECraft_002EParts_002EModifiers_002EPropulsion_002EPropeller_002EUpdatePropBlurMatrices_000071DB_0024PostfixBurstDelegate))]
		private unsafe static void UpdatePropBlurMatrices([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees)
		{
			UpdatePropBlurMatrices_000071DB_0024BurstDirectCall.Invoke(matrices, count, positionPtr, scalePtr, baseRotationPtr, localRotationPtr, stepRotationDegrees);
		}

		private void AddWaterCollider()
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
			boxCollider.size = new Vector3(Data.Diameter, 0.1f, Data.Diameter);
			_waterColliderScript = gameObject.AddComponent<PartColliderScript>();
			_waterColliderScript.IsPrimary = true;
			_waterCollider = boxCollider;
			base.PartScript.PrimaryPartCollider = boxCollider;
		}

		private void BuildCombinedBladeMesh()
		{
			MeshRenderer componentInChildren = _masterPropeller.Blade.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			Mesh sharedMesh = componentInChildren.GetComponent<MeshFilter>().sharedMesh;
			_bladeMeshCombined = MeshUtility.CombineSubmeshes(sharedMesh);
			_bladeMeshCombined.name = sharedMesh.name + "_Combined";
			List<Vector3> value;
			using (ListPool<Vector3>.Get(out value))
			{
				List<Vector3> value2;
				using (ListPool<Vector3>.Get(out value2))
				{
					List<Vector4> value3;
					using (ListPool<Vector4>.Get(out value3))
					{
						_bladeMeshCombined.GetVertices(value);
						_bladeMeshCombined.GetNormals(value2);
						_bladeMeshCombined.GetTangents(value3);
						bool flag = value3.Count == value.Count;
						Transform transform = componentInChildren.transform;
						Matrix4x4 matrix4x = _masterPropeller.Blade.transform.worldToLocalMatrix * transform.localToWorldMatrix;
						for (int i = 0; i < value.Count; i++)
						{
							value[i] = matrix4x.MultiplyPoint3x4(value[i]);
							value2[i] = matrix4x.MultiplyVector(value2[i]).normalized;
							if (flag)
							{
								value3[i] = new float4(matrix4x.MultiplyVector(value3[i]).normalized, value3[i].w);
							}
						}
						_bladeMeshCombined.SetVertices(value);
						_bladeMeshCombined.SetNormals(value2);
						if (flag)
						{
							_bladeMeshCombined.SetTangents(value3);
						}
						_bladeMeshCombined.RecalculateBounds();
					}
				}
			}
		}

		private float CalculateDesiredCombinedBladeTransparency()
		{
			float num = ((RpmAbs < 50f) ? 0f : RpmAbs);
			return 1f - Mathf.Lerp(1f, 0.6f, Mathf.Clamp01(num / 1000f));
		}

		private void CommonInitialization()
		{
			_config = GetComponent<PropAssemblyConfig>();
			_masterPropeller = new BladeAssembly(_config.PropsContainer.Find("Propeller"));
			_propContainer = base.transform.Find("Hub");
			_propSpinner = _propContainer.Find("HubMesh/Mesh");
			_propContainerInitialRotation = _propContainer.transform.localEulerAngles;
			RebuildPropellerAssembly(repositionConnectedParts: false);
		}

		private void CommonStart()
		{
			_pitchInput = GetInputController("BladeAngle");
			base.PartScript.Aircraft.OnAircraftStructureChanged += OnCraftStructureChanged;
		}

		private void CreatePropellersFromMaster()
		{
			foreach (BladeAssembly additionalPropeller in _additionalPropellers)
			{
				UnityEngine.Object.DestroyImmediate(additionalPropeller.Root.gameObject);
			}
			_additionalPropellers.Clear();
			float num = 360f / (float)Data.BladeCount;
			float num2 = num;
			int num3 = 2;
			while (num3 <= Data.BladeCount)
			{
				Transform transform = UnityEngine.Object.Instantiate(_masterPropeller.Root.gameObject).transform;
				Vector3 vector = new Vector3(0f, num2, 0f);
				transform.parent = _masterPropeller.Root.parent;
				transform.localPosition = Quaternion.Euler(vector) * _masterPropeller.Root.localPosition;
				transform.localEulerAngles = vector;
				transform.localScale = _masterPropeller.Root.localScale;
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
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				ColliderContainer = new GameObject("Colliders").transform;
				ColliderContainer.parent = _config.PropsContainer.transform;
				ColliderContainer.localPosition = Vector3.zero;
				ColliderContainer.localEulerAngles = Vector3.zero;
				_propellerColliderMap = new Dictionary<Collider, Transform>();
				foreach (BladeAssembly allPropeller in _allPropellers)
				{
					Collider componentInChildren = allPropeller.Blade.GetComponentInChildren<Collider>();
					componentInChildren.transform.parent = ColliderContainer;
					_propellerColliderMap.Add(componentInChildren, allPropeller.Root);
				}
			}
			base.PartScript.PartMaterialScript.UpdateRenderers();
			_refreshEditorColliders = true;
		}

		private void CreatePropPhysicsScript()
		{
			_propPhysics = new PropellerPhysics();
			Vector3.Dot(base.transform.up, base.PartScript.Aircraft.OrientedCenterOfMassRigidBodies.forward);
			PropPhysicsInfoScript componentInChildren = GetComponentInChildren<PropPhysicsInfoScript>();
			int segmentCount = Mathf.Clamp((int)Diameter * 2, 4, 10);
			_propPhysics.Initialize(Airfoil, BladeCount, componentInChildren.GetLengthScalar(), componentInChildren.GetWidthScalar(), Data.TwistAngleRoot, segmentCount);
			_propPhysics.DragScalar = Data.DragScalar;
			_propPhysics.ThrustScalar = Data.ThrustScalar;
		}

		private void DesignerStart(in CraftUpdateFrameData frame)
		{
			CommonStart();
			Airfoil = Game.Instance.ResourceLoader.LoadAirfoil("NACAPROPCLARKY");
			SetPitchInputControllerVisibility(Data.IsManual);
		}

		private void DesignerUpdate(in CraftUpdateFrameData frame)
		{
			if (_refreshEditorColliders)
			{
				_refreshEditorColliders = false;
				Assembly.CreateEditorCollidersForPartScript(base.PartScript);
			}
			if (Data.PitchControlType != PropellerAssemblyData.PitchControl.Auto)
			{
				PropellerPitchDegrees = GetPitchInput() * Data.MaxPitch;
			}
			_ = Data.PropertiesOpen;
		}

		private unsafe void DrawPropsInFlightScene(bool blur)
		{
			using (Profile.DrawPropsInFlightScene.Auto())
			{
				int bladeCount = BladeCount;
				int num = Mathf.Min(511, Data.BladeBlurCount);
				int num2 = 511 / num;
				int num3 = Mathf.CeilToInt((float)bladeCount / (float)num2);
				int num4 = num2 * num;
				if (_propBlurMatrices == null || _propBlurMatrices.Length < num4)
				{
					_propBlurMatrices = new Matrix4x4[num4];
				}
				if (!blur)
				{
					num = 1;
					num2 = bladeCount;
					num3 = 1;
					num4 = bladeCount;
				}
				else
				{
					UpdatePropellerTransparency();
				}
				RenderParams rparams = new RenderParams(blur ? _propBlurMaterial : _propDefaultMaterial);
				rparams.layer = 21;
				rparams.shadowCastingMode = ShadowCastingMode.On;
				rparams.receiveShadows = !blur;
				rparams.reflectionProbeUsage = ReflectionProbeUsage.BlendProbes;
				rparams.lightProbeUsage = LightProbeUsage.BlendProbes;
				ReflectionProbe reflectionProbe = ((_craftReflectionsSetting.Value == CraftQualitySettings.CraftReflectionsQuality.Realtime) ? _craftReflectionProbe : _globalReflectionProbe);
				Texture texture = reflectionProbe?.texture;
				if (texture != null)
				{
					_propMaterialPropertyBlock.SetTexture("unity_SpecCube0", texture);
					_propMaterialPropertyBlock.SetVector("unity_SpecCube0_HDR", reflectionProbe.textureHDRDecodeValues);
					rparams.matProps = _propMaterialPropertyBlock;
				}
				float stepRotationDegrees = Mathf.Lerp(0f, Data.BladeBlurSpread, Mathf.Clamp01(RpmAbs / 1000f)) / (float)num;
				int num5 = 0;
				for (int i = 0; i < num3; i++)
				{
					int num6 = math.min(bladeCount - num5, num2);
					int instanceCount = num6 * num;
					for (int j = 0; j < num6; j++)
					{
						BladeAssembly bladeAssembly = _allPropellers[num5];
						float3 float5 = bladeAssembly.Blade.position;
						float3 float6 = _masterPropeller.Blade.lossyScale;
						quaternion quaternion2 = bladeAssembly.Root.localRotation;
						quaternion quaternion3 = _propContainer.rotation;
						ulong gcHandle;
						Matrix4x4* ptr = (Matrix4x4*)UnsafeUtility.PinGCArrayAndGetDataAddress(_propBlurMatrices, out gcHandle);
						UpdatePropBlurMatrices(ptr + j * num, num, &float5, &float6, &quaternion3, &quaternion2, stepRotationDegrees);
						UnsafeUtility.ReleaseGCObject(gcHandle);
						num5++;
					}
					Graphics.RenderMeshInstanced(in rparams, _bladeMeshCombined, 0, _propBlurMatrices, instanceCount);
				}
			}
		}

		private void FlightFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (Data.PitchControlType == PropellerAssemblyData.PitchControl.Auto && _powertrain != null)
			{
				float autoMinRpmPercent = Data.AutoMinRpmPercent;
				float autoMaxRpmPercent = Data.AutoMaxRpmPercent;
				float engineThrottle = _powertrain.EngineThrottle;
				float setPoint = Mathf.Lerp(autoMinRpmPercent, autoMaxRpmPercent, engineThrottle);
				float processVariable = Mathf.Clamp01(_powertrain.EngineRpm / _powertrain.EngineMaxRpm);
				_governorPidController.SetPoint = setPoint;
				_governorPidController.ProcessVariable = processVariable;
				float value = 0f - _governorPidController.ControlVariable(frame.DeltaTime);
				value = Mathf.Clamp(value, -10f, 10f) * frame.DeltaTime;
				float propellerPitchDegrees = Mathf.Clamp(PropellerPitchDegrees + value, 0f, 80f);
				PropellerPitchDegrees = propellerPitchDegrees;
			}
			if (_nwhPowertrainComponent != null && PropellerPhysicsEnabled && _propPhysics != null)
			{
				AtmosphereSample atmosphereSample = base.PartScript.Aircraft.AtmosphereSample;
				Vector3 aircraftVel = _rigidBodyToAddForceTo.linearVelocity - base.PartScript.Aircraft.WindVelocity;
				Vector3 vector = base.transform.up;
				if (Data.IsPushProp)
				{
					vector = -vector;
				}
				_propPhysics.Simulate(aircraftVel, Rpm, PropellerPitchDegrees, atmosphereSample.AirDensity, vector, atmosphereSample.SpeedOfSound);
				_liftForce = _propPhysics.CalculatedThrustVector;
				_dragTorque = _propPhysics.CalculatedDragTorque;
				_rigidBodyToAddForceTo.AddForceAtPosition(_liftForce, base.transform.position);
			}
			else
			{
				Rpm = 0f;
				_liftForce = Vector3.zero;
				_dragTorque = 0f;
			}
			UpdateDynamicPhysicsScalars();
		}

		private void FlightUpdate(in CraftUpdateFrameData frame)
		{
			UpdateVisualRpmReduction();
			if (base.PartScript.Aircraft.RemoteAircraft)
			{
				Rpm = Mathf.Lerp(Rpm, _remoteTargetRpm, Time.deltaTime * 20f);
			}
			float y = Rpm * _visualRpmReductionScalar * 360f / 60f * Time.deltaTime;
			_propContainer.localRotation *= Quaternion.Euler(0f, y, 0f);
			if (Data.PitchControlType != PropellerAssemblyData.PitchControl.Auto)
			{
				PropellerPitchDegrees = GetPitchInput() * Data.MaxPitch;
			}
			if (base.PartScript.PhysicsEnabled && _propIsBroken && _propellerColliderMap.Count == 0 && !_destroyed)
			{
				_destroyed = true;
				FlightSceneScript.Instance.FlightUI.ShowMessage(base.PartScript.Part.Name + " has been destroyed due to impact damage.");
				base.PartScript.Body.ExplodePart(base.PartScript, 1f, 0);
			}
			if (!(_audio != null))
			{
				return;
			}
			_audio.pitch = Mathf.Min(Time.timeScale * RpmAbs * (float)Data.BladeCount / 540f, 20f);
			float num = Mathf.Pow(Mathf.Abs(_audio.pitch - 5f) / _audio.pitch, 1.5f) + 0.5f;
			_audioFilter.Limit = num * 1000f;
			_audio.volume = 0.5f * Mathf.Pow(Mathf.Abs(_dragTorque / Diameter), 0.3f);
			num = Diameter / (4f * num * num);
			_audio.minDistance = 2f + 25f * num;
			_audio.maxDistance = 10f + 500f * num;
			if (_audio.volume > 0.01f)
			{
				if (!_audio.isPlaying)
				{
					_audio.timeSamples = UnityEngine.Random.Range(0, _audio.clip.samples);
					_audio.Play();
				}
			}
			else if (_audio.isPlaying)
			{
				_audio.Stop();
			}
		}

		private float GetPitchInput()
		{
			float value;
			switch (Data.PitchControlType)
			{
			case PropellerAssemblyData.PitchControl.Manual:
				value = ((base.LoadContext == CraftLoadContext.Flight) ? _pitchInput.Value : ((float)(Data.PropertiesOpen ? 1 : 0)));
				break;
			case PropellerAssemblyData.PitchControl.Fixed:
				value = 1f;
				break;
			default:
				Debug.LogWarning("Unknown pitch control type: " + Data.PitchControlType);
				value = 0f;
				break;
			}
			return Mathf.Clamp(value, -1f, 1f);
		}

		private void InitializeFlightScenePropRendering()
		{
			if (base.LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			BuildCombinedBladeMesh();
			ThemeScript theme = base.PartScript.Aircraft.Theme;
			_propDefaultMaterial = theme.RequestDefaultPartMaterialInstance();
			_propDefaultMaterial.enableInstancing = true;
			_propBlurMaterial = theme.RequestTransparentPartMaterialInstance(zwrite: false, preserveSpecular: false);
			_propBlurMaterial.enableInstancing = true;
			_propMaterialPropertyBlock = new MaterialPropertyBlock();
			_craftReflectionProbe = base.PartScript.Aircraft.ReflectionProbe;
			_globalReflectionProbe = UnityEngine.Object.FindAnyObjectByType<GlobalReflectionProbeScript>().ReflectionProbe;
			_craftReflectionsSetting = Game.Instance.Settings.Quality.Craft.Reflections;
			foreach (BladeAssembly allPropeller in _allPropellers)
			{
				allPropeller.Blade.GetComponentInChildren<MeshRenderer>(includeInactive: true).enabled = false;
			}
		}

		private void OnCraftStructureChanged()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				StoreConnectedBodyInfo();
			}
			else if (base.LoadContext == CraftLoadContext.Designer)
			{
				Data.RefreshDesignerUI();
			}
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				bool blur = !EngineDestroyed && !_propIsBroken && RpmAbs > 50f;
				DrawPropsInFlightScene(blur);
			}
		}

		private void RotateBlade(BladeAssembly blade, float neutralRotation, float pitchDegrees)
		{
			blade.Root.Rotate(new Vector3(0f - (pitchDegrees - neutralRotation), 0f, 0f), Space.Self);
		}

		private void StoreConnectedBodyInfo()
		{
			BodyScript body = base.PartScript.Body;
			_propellerBody = body.RigidBody;
			if (body.Joints.Count > 0)
			{
				BodyJoint bodyJoint = body.Joints[0];
				_joint = bodyJoint.GetJointForAttachPoint(base.PartScript.Part.AttachPoints[0]);
				if (_joint != null)
				{
					_joint.breakTorque = float.PositiveInfinity;
					_propellerConnectedBody = bodyJoint.OtherBody(body).RigidBody.PhysxRigidBody;
					_rigidBodyToAddForceTo = _propellerConnectedBody;
				}
			}
			if (_propellerConnectedBody == null)
			{
				_propellerConnectedBody = _propellerBody.PhysxRigidBody;
			}
		}

		private void UpdateDynamicPhysicsScalars()
		{
			float dynamicThrustScalar = (Data.IsWaterProp ? Mathf.Lerp(0.1f, 1f, base.PartScript.EstimateOfUnderwaterPercent) : 1f);
			DynamicThrustScalar = dynamicThrustScalar;
		}

		private void UpdateHubStyle()
		{
			GameObject prefab = Data.HubPrefab.prefab;
			if (prefab != null)
			{
				Transform transform = UnityEngine.Object.Instantiate(prefab).transform;
				transform.parent = _propSpinner.parent;
				Vector3 localPosition = (transform.localEulerAngles = Vector3.zero);
				transform.localPosition = localPosition;
				transform.localScale = Vector3.one;
				UnityEngine.Object.DestroyImmediate(_propSpinner.gameObject);
				_propSpinner = transform;
			}
		}

		private void UpdatePropellerTransparency()
		{
			float desiredCombinedTransparency = CalculateDesiredCombinedBladeTransparency();
			float value = (_propIsBroken ? 1f : CalculatePerBladeAlpha(Data.BladeBlurCount, desiredCombinedTransparency));
			_propBlurMaterial.SetFloat("_Alpha", value);
		}

		private void UpdateVisualRpmReduction()
		{
			float num = RpmAbs * _visualRpmReductionScalar;
			if (num > 500f)
			{
				_visualRpmReductionScalar *= 0.5f;
			}
			else if (num < 200f && _visualRpmReductionScalar < 1f)
			{
				_visualRpmReductionScalar *= 2f;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		internal unsafe static void UpdatePropBlurMatrices_0024BurstManaged([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees)
		{
			float3 translation = *positionPtr;
			float3 scale = *scalePtr;
			quaternion b = *localRotationPtr;
			quaternion a = *baseRotationPtr;
			quaternion b2 = quaternion.RotateY(math.radians(stepRotationDegrees));
			for (int i = 0; i < count; i++)
			{
				a = math.mul(a, b2);
				matrices[i] = float4x4.TRS(translation, math.mul(a, b), scale);
			}
		}
	}
}
