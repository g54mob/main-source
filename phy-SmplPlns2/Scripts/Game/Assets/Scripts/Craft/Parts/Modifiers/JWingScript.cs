using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Parts.Events;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Physics;
using Assets.Scripts.Craft.Wings.Runtime;
using Assets.Scripts.Craft.Wings.VFX;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Multiplayer.SyncData;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using Jundroo.DevConsole;
using Shapes;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class JWingScript : PartModifierScript, IWingScript, IFlightGizmo
	{
		private static bool _commandInitComplete = false;

		private static float _flightGizmosScale = 1f;

		private Dictionary<MeshCollider, (int MeshIdx, ColliderInfo Info)> _colliderMetadata;

		private Transform[] _controlSurfaceParentTransforms;

		private List<ControlSurfacePartData> _controlSurfaces = new List<ControlSurfacePartData>();

		private ControlSurface[] _controlSurfacesArray;

		private ControlSurfacePartScript[] _controlSurfaceScripts;

		private Vector3[] _controlSurfaceUVs;

		private bool _designerChangesSuspended;

		private bool _designerChangesWaiting;

		private bool _floatingOriginSubscribed;

		private WingInputManager _input;

		private bool _isDesigner;

		private bool _isRemote;

		private List<ControlSurfacePartData> _newControlSurfaces = new List<ControlSurfacePartData>();

		private WingPhysicsManager _physics;

		private bool _readyToGenerate;

		private Vector3 _remoteCraftVortexTrailOrigin;

		private ProceduralPartMeshRenderer[] _renderers = Array.Empty<ProceduralPartMeshRenderer>();

		private bool _structureChangedSubscribed;

		private float3 _syncedVortexData;

		private WingTrailRenderer _trailRenderer;

		public JWingData Data { get; internal set; }

		public float LiftScale => Data.LiftScale;

		public WingPhysicsManager Physics => _physics;

		bool IWingScript.PhysicsEnabled => true;

		public bool PhysicsInitialised => _physics != null;

		public WingSurfaceClaims SurfaceClaims { get; private set; }

		public void BuildMeshFlight(bool remote)
		{
			WingRuntimeOutput output = WingBuilder.Generate(GetBuilderInput(), Data.PhysicsSamples);
			_isRemote = remote;
			ref NativeArray<SliceData> physicsSlices = ref output.PhysicsSlices;
			_remoteCraftVortexTrailOrigin = physicsSlices[physicsSlices.Length - 1].panelTipTrailing;
			InitRuntime(output, !remote);
			Data.OnWingMeshRebuilt(in output.MeshOutput);
			UpdateColliders(in output.MeshOutput);
			base.PartScript.PartMaterialScript.OnThemeUpdated();
			base.PartScript.PartMaterialScript.OnMeshChanged();
			UpdateControlSurfaceMasses(in output.MeshOutput);
			if (!remote && !_structureChangedSubscribed)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				_structureChangedSubscribed = true;
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnFindControlSurfaces, PreStartInitializationFlags.Default, 501);
			plan.Register(this, OnGenerate, PreStartInitializationFlags.Default, 502);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightDefault, 503);
		}

		public WingDebugInfo DebugGenerationDesigner()
		{
			WingBuilderInput builderInput = GetBuilderInput();
			WingDebugInfo wingDebugInfo = (builderInput.DebugCollector = new WingDebugInfo());
			UpdateMeshDesigner(wingDebugInfo);
			return wingDebugInfo;
		}

		void IFlightGizmo.DrawFlightGizmo(Camera camera)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			_physics.DrawingGizmos = true;
			NativeArray<WingPhysicsManager.DebugData>? debugData = _physics.GetDebugData();
			if (!debugData.HasValue)
			{
				return;
			}
			NativeArray<WingPhysicsManager.DebugData> value = debugData.Value;
			Draw.Matrix = base.transform.localToWorldMatrix;
			for (int i = 0; i < value.Length; i++)
			{
				WingPhysicsManager.DebugData debugData2 = value[i];
				if (!(debugData2.freeStreamSpeedSq < 0.001f))
				{
					float num = _flightGizmosScale / (debugData2.segmentWidth * debugData2.freeStreamSpeedSq);
					float3 forcePos = debugData2.forcePos;
					float3 float5 = forcePos + debugData2.liftForce * num;
					float3 float6 = float5 + debugData2.dragForce * num;
					float3 float7 = forcePos + debugData2.freeStreamDir * _flightGizmosScale;
					Draw.BlendMode = ShapesBlendMode.Transparent;
					Draw.ThicknessSpace = ThicknessSpace.Noots;
					Draw.Thickness = 0.3f;
					Draw.Opacity = 0.5f;
					Draw.Line(forcePos, float5, Color.green);
					Draw.Line(float5, float6, Color.red);
					Draw.Thickness = 0.1f;
					Draw.Line(forcePos, float7, Color.grey);
				}
			}
		}

		public float GetArea()
		{
			return Data.WingArea;
		}

		public Vector3 GetCentreOfLift(out float lift)
		{
			lift = 0f;
			return Vector3.zero;
		}

		public float GetProjectedAreaMoment(Vector3 axis, out Vector3 centre)
		{
			float num = 0f;
			float3 float5 = 0f;
			float3 x = base.transform.InverseTransformDirection(axis);
			float num2 = (Data.Flipped ? (-1f) : 1f);
			for (int i = 0; i < Data.WingSlices.Count - 1; i++)
			{
				WingSlice lastDerivedSliceTip = Data.WingSlices[i].LastDerivedSliceTip;
				WingSlice lastDerivedSliceRoot = Data.WingSlices[i + 1].LastDerivedSliceRoot;
				if (lastDerivedSliceTip != null && lastDerivedSliceRoot != null)
				{
					float3 up = lastDerivedSliceTip.Up;
					up.y *= num2;
					float num3 = math.abs(math.dot(x, math.normalizesafe(up)));
					float num4 = 0.5f * (lastDerivedSliceTip.Scale + lastDerivedSliceRoot.Scale) * (lastDerivedSliceRoot.SpanPosition - lastDerivedSliceTip.SpanPosition) * num3;
					num += num4;
					float5 += num4 * MathUtils.TrapezoidCentroid(lastDerivedSliceTip.Scale, lastDerivedSliceRoot.Scale, lastDerivedSliceTip.SpanPosition - lastDerivedSliceRoot.SpanPosition, lastDerivedSliceTip.QuarterChord, lastDerivedSliceRoot.QuarterChord);
				}
			}
			float5.y *= num2;
			float num5 = ((num != 0f) ? (1f / num) : 0f);
			centre = base.transform.TransformPoint(float5 * num5);
			return num;
		}

		public void Init(JWingData data, bool initPhysics)
		{
			Data = data;
			SurfaceClaims = new WingSurfaceClaims(data.WingSlices);
			_isDesigner = !initPhysics;
		}

		public override void InitializePartSyncData(PartSyncData syncData)
		{
			syncData.RegisterValue(new SyncVector
			{
				Value = () => _syncedVortexData,
				ValueRead = delegate(Vector3 x)
				{
					_syncedVortexData = x;
				}
			});
		}

		public override void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
			base.OnConnectedToPart(thisAttachPoint, targetPart, targetAttachPoint, isSymmetryOperation);
			bool flag = Vector3.Angle(Vector3.up, base.transform.up) > 90f;
			if (Data.Flipped != flag)
			{
				Data.Flipped = flag;
				Data.UpdateMeshes();
			}
		}

		void IFlightGizmo.OnFlightGizmosEnabled(bool enabled)
		{
			Physics.DrawingGizmos = enabled;
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Data.Flipped = !Data.Flipped;
			UpdateMeshDesigner();
		}

		public bool ResolveRaycast(in RaycastHit hit, out int meshIdx, out float spanPosition)
		{
			if (_colliderMetadata == null || !(hit.collider is MeshCollider key) || !_colliderMetadata.TryGetValue(key, out (int, ColliderInfo) value))
			{
				meshIdx = -1;
				spanPosition = -1f;
				return false;
			}
			meshIdx = value.Item1;
			float3 y = (float3)base.transform.InverseTransformPoint(hit.point) - value.Item2.RootSlicePos;
			float3 x = value.Item2.TipSlicePos - value.Item2.RootSlicePos;
			x.z = 0f;
			y.z = 0f;
			float num = math.dot(x, y) / math.lengthsq(x);
			if (num < -0.01f || num > 1.01f)
			{
				spanPosition = -1f;
				return false;
			}
			spanPosition = math.lerp(value.Item2.SpanPositionRange.x, value.Item2.SpanPositionRange.y, num);
			return true;
		}

		public bool ResumeMeshUpdates()
		{
			_designerChangesSuspended = false;
			if (_designerChangesWaiting)
			{
				_designerChangesWaiting = false;
				UpdateMeshDesigner();
				return true;
			}
			return false;
		}

		public Vector3 SnapSurfaceAttachPosition(Vector3 position)
		{
			return position;
		}

		public void SuspendMeshUpdates()
		{
			_designerChangesSuspended = true;
		}

		public void UpdateMeshDesigner()
		{
			UpdateMeshDesigner(null);
		}

		public void UpdateSurfaceClaims(ControlSurfacePartScript exclude = null)
		{
			SurfaceClaims.Clear();
			foreach (ControlSurfacePartData controlSurface in _controlSurfaces)
			{
				if (!(exclude != null) || controlSurface != exclude.Data)
				{
					controlSurface.ControlSurface.AddToClaims(SurfaceClaims);
				}
			}
		}

		internal static void DestroyMeshColliders(ProceduralPartMeshRenderer renderer)
		{
			MeshCollider[] componentsInChildren = renderer.Transform.GetComponentsInChildren<MeshCollider>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Mesh sharedMesh = componentsInChildren[i].sharedMesh;
				if (sharedMesh != null)
				{
					UnityEngine.Object.Destroy(sharedMesh);
				}
			}
		}

		protected void OnDestroy()
		{
			_physics?.OnDestroy();
			_input?.Dispose();
			MeshCollider[] componentsInChildren = GetComponentsInChildren<MeshCollider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.Destroy(componentsInChildren[i].sharedMesh);
			}
			if (_structureChangedSubscribed)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
				_structureChangedSubscribed = false;
			}
			if (_floatingOriginSubscribed)
			{
				GameWorld.Instance.FloatingOriginChanged -= OnFloatingOriginChanged;
				_floatingOriginSubscribed = false;
			}
			if (_isDesigner)
			{
				Data.WingDataChanged -= UpdateMeshDesigner;
				base.PartScript.PartConnectionChanged -= OnConnectionChanged;
			}
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				FlightSceneScript.Instance.FlightGizmos.UnregisterGizmo(this);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(FlightUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterFixedUpdate(FlightFixedUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private static void InitCommands()
		{
			if (!_commandInitComplete)
			{
				_commandInitComplete = true;
				DevConsoleApi.RegisterCommand("WingSpanwiseSolverToggle", delegate
				{
					bool flag = (WingPhysicsManager.UseSpanwiseSolver = !WingPhysicsManager.UseSpanwiseSolver);
					Debug.Log("Spanwise solver " + (flag ? "enabled" : "disabled"));
				});
				DevConsoleApi.RegisterCommand("WingSpanwiseSolverGetIterations", () => LiftingLineSolver.IterationsSetting);
				DevConsoleApi.RegisterCommand("WingSpanwiseSolverSetIterations", delegate(int v)
				{
					LiftingLineSolver.IterationsSetting = v;
				});
				DevConsoleApi.RegisterCommand("WingSpanwiseSolverGetFourierTerms", () => LiftingLineSolver.FourierTermsSetting);
				DevConsoleApi.RegisterCommand("WingSpanwiseSolverSetFourierTerms", delegate(int v)
				{
					LiftingLineSolver.FourierTermsSetting = v;
				});
				DevConsoleApi.RegisterCommand("WingSpanwiseSolverGetRelaxation", () => LiftingLineSolver.RelaxationSetting);
				DevConsoleApi.RegisterCommand("WingSpanwiseSolverSetRelaxation", delegate(float v)
				{
					LiftingLineSolver.RelaxationSetting = v;
				});
				DevConsoleApi.RegisterCommand("WingVisualiserScale", delegate(float f)
				{
					_flightGizmosScale = f;
				});
				DevConsoleApi.RegisterCommand("WingGetViscousDragDueToLiftMultiplier", () => WingPhysicsManager.ViscousDragDueToLiftMultiplier);
				DevConsoleApi.RegisterCommand("WingSetViscousDragDueToLiftMultiplier", delegate(float f)
				{
					WingPhysicsManager.ViscousDragDueToLiftMultiplier = f;
				});
			}
		}

		private void ControlSurfaceDataChanged(ControlSurfacePartData controlSurface)
		{
			if (_isDesigner)
			{
				UpdateMeshDesigner();
			}
		}

		private void FindControlSurfaces()
		{
			PartData part = base.PartScript.Part;
			List<ControlSurfacePartData> list = (_isDesigner ? _newControlSurfaces : _controlSurfaces);
			list.Clear();
			foreach (AttachPointData attachPoint in part.AttachPoints)
			{
				foreach (PartConnection partConnection in attachPoint.PartConnections)
				{
					ControlSurfacePartData modifier = partConnection.GetOtherPart(part).GetModifier<ControlSurfacePartData>();
					if (modifier != null && modifier.GetFirstConnectedWing() == Data && !list.Contains(modifier))
					{
						list.Add(modifier);
					}
				}
			}
			if (!_isDesigner)
			{
				return;
			}
			foreach (ControlSurfacePartData controlSurface in _controlSurfaces)
			{
				controlSurface.OnDataChanged -= ControlSurfaceDataChanged;
			}
			bool flag = list.Count != _controlSurfaces.Count;
			if (!flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].OnDataChanged += ControlSurfaceDataChanged;
					if (list[i] != _controlSurfaces[i])
					{
						flag = true;
						_controlSurfaces[i] = list[i];
					}
				}
			}
			else
			{
				_controlSurfaces.Clear();
				foreach (ControlSurfacePartData item in list)
				{
					_controlSurfaces.Add(item);
					item.OnDataChanged += ControlSurfaceDataChanged;
				}
			}
			if (flag)
			{
				UpdateMeshDesigner();
				Data.ControlSurfacesInformational.Clear();
				Data.ControlSurfacesInformational.AddRange(_controlSurfaces);
			}
		}

		private PartScript FindCSMeshOwner(int meshIndex)
		{
			if (meshIndex == 0)
			{
				return base.PartScript;
			}
			for (int i = 0; i < _controlSurfacesArray.Length; i++)
			{
				ControlSurface controlSurface = _controlSurfacesArray[i];
				if (meshIndex >= controlSurface.MeshIndexOffset && meshIndex < controlSurface.MeshIndexOffset + controlSurface.MeshCount)
				{
					return _controlSurfaces[i].Part.PartScript;
				}
			}
			return null;
		}

		private void FlightFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_trailRenderer != null)
			{
				_trailRenderer.AddTime(frame.DeltaTime);
				_trailRenderer.AddOffset(frame.Craft.WindVelocity * frame.DeltaTime);
			}
			if (_physics != null)
			{
				_physics.WaveDragMultiplier = Mathf.Clamp(base.PartScript.Body.DragPhysics.WaveDragMultiplier * 0.75f, 1f, 3f);
			}
		}

		private void FlightUpdate(in CraftUpdateFrameData frame)
		{
			LiftingLineSolver.TrailingVortex? trailingVortex = ((!_isRemote) ? _physics?.Solver?.TrailingVortexData : ((!math.any(_syncedVortexData <= 0f)) ? new LiftingLineSolver.TrailingVortex?(new LiftingLineSolver.TrailingVortex
			{
				sourcePos = _remoteCraftVortexTrailOrigin,
				asymptotePos = _remoteCraftVortexTrailOrigin,
				sourcePower = _syncedVortexData.x,
				asymptotePower = _syncedVortexData.x,
				sourceRadius = _syncedVortexData.y,
				asymptoteRadius = _syncedVortexData.y * 1.4f,
				lifetime = _syncedVortexData.z,
				motionRate = 5f
			}) : ((LiftingLineSolver.TrailingVortex?)null)));
			if (_trailRenderer == null)
			{
				if (!trailingVortex.HasValue || Data.DisableWingtipVortices)
				{
					_syncedVortexData = -1f;
					return;
				}
				_trailRenderer = base.gameObject.AddComponent<WingTrailRenderer>();
			}
			if (trailingVortex.HasValue)
			{
				LiftingLineSolver.TrailingVortex value = trailingVortex.Value;
				if (Data.Flipped)
				{
					value.asymptotePos.y = 0f - value.asymptotePos.y;
					value.sourcePos.y = 0f - value.sourcePos.y;
				}
				_trailRenderer.SetVortex(value);
				if (!_isRemote)
				{
					_syncedVortexData = new float3(math.max(value.sourcePower, value.asymptotePower), value.sourceRadius, value.lifetime);
				}
			}
			else if (!_isRemote)
			{
				_syncedVortexData = -1f;
			}
		}

		private WingBuilderInput GetBuilderInput()
		{
			UpdateControlSurfaceInputData();
			return new WingBuilderInput
			{
				parent = base.transform,
				flipped = Data.Flipped,
				inputSlices = Data.WingSlices.ToArray(),
				surfaces = _controlSurfacesArray,
				ControlSurfaceUVs = _controlSurfaceUVs,
				surfaceParentTransforms = _controlSurfaceParentTransforms,
				getPartMeshRenderers = GetRenderers,
				MainMeshUV = new Vector3(base.PartScript.PartMaterialScript.MaterialIdPrimary, DecalLayers.DefaultRenderingLayerFloat, base.PartScript.Part.Id),
				WingtipStyle = Data.WingTipStyle
			};
		}

		private ProceduralPartMeshRenderer[] GetRenderers(int number, int? controlSurface)
		{
			if (controlSurface.HasValue)
			{
				return _controlSurfaceScripts[controlSurface.Value].GetRenderers(number);
			}
			return _renderers = _renderers.Resize(number, (int i) => new ProceduralPartMeshRenderer(base.PartScript, $"Mesh-{i}", base.LoadContext), DestroyMeshColliders);
		}

		private void InitRuntime(WingRuntimeOutput output, bool initPhysics)
		{
			InitCommands();
			if (_physics != null)
			{
				_physics.OnDestroy();
				_physics = null;
			}
			if (_input != null)
			{
				_input.Dispose();
				_input = null;
			}
			_input = new WingInputManager(output);
			if (base.PartScript.PhysicsEnabled && initPhysics)
			{
				_physics = new WingPhysicsManager(output, this, _input, base.PartScript.Body.RigidBody.PhysxRigidBody)
				{
					ForceScale = 0.01f,
					LiftScale = LiftScale,
					ViscousDragScale = Data.ViscousDragScale,
					ZeroLiftDragScale = Data.ZeroLiftDragScale,
					WindVectorGetter = () => FlightSceneScript.Instance.WindManager.WindVelocity
				};
				FlightSceneScript.Instance.FlightGizmos.RegisterGizmo(this);
			}
			GameWorld.Instance.FloatingOriginChanged += OnFloatingOriginChanged;
			_floatingOriginSubscribed = true;
		}

		private void OnAircraftStructureChanged()
		{
			if (_physics != null)
			{
				_physics.Rigidbody = base.PartScript.Body.RigidBody.PhysxRigidBody;
			}
		}

		private void OnConnectionChanged(object sender, PartConnectionChangedEventArgs e)
		{
			FindControlSurfaces();
		}

		private void OnCreateRenderer(MeshRenderer renderer, int index)
		{
			PartScript partScript = ((index == 0) ? base.PartScript : FindCSMeshOwner(index));
			partScript.PartMaterialScript.AddRenderer(renderer, null, null, new int[1], index != 0, excludeFromDrag: false).MeshIsUnique = true;
			DecalTargetScript decalTargetScript = renderer.gameObject.AddComponent<DecalTargetScript>();
			decalTargetScript.UseSharedMesh = true;
			decalTargetScript.AddRenderer(renderer);
		}

		private void OnDestroyRenderer(MeshRenderer renderer)
		{
			renderer.GetComponentInParent<PartScript>().PartMaterialScript.RemoveRenderer(renderer);
		}

		private UniTask OnFindControlSurfaces(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			FindControlSurfaces();
			return UniTask.CompletedTask;
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			if (_physics != null)
			{
				_physics.WorldOriginAltitude = e.NewFloatingOriginOffset.y;
			}
			if (_trailRenderer != null)
			{
				_trailRenderer.AddOffset(e.Delta);
			}
		}

		private UniTask OnGenerate(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_readyToGenerate = true;
			if (craftScript.RemoteAircraft)
			{
				BuildMeshFlight(remote: true);
			}
			else if (!_isDesigner)
			{
				BuildMeshFlight(remote: false);
			}
			else
			{
				UpdateMeshDesigner();
				Data.WingDataChanged += UpdateMeshDesigner;
				base.PartScript.PartConnectionChanged += OnConnectionChanged;
			}
			return UniTask.CompletedTask;
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			SetupInputs();
			return UniTask.CompletedTask;
		}

		private void SetupInputs()
		{
			for (int i = 0; i < _controlSurfaces.Count; i++)
			{
				foreach (InputControllerScript controller in _controlSurfaces[i].Part.PartScript.GetModifiers<InputControllerScript>())
				{
					string text = controller.InputController.Name;
					if (text.StartsWith("controlsurface-", StringComparison.OrdinalIgnoreCase) && int.TryParse(text.AsSpan(15), out var result))
					{
						_input.SetInputGetter(i, result, () => controller.Value);
					}
				}
			}
		}

		private void UpdateColliders(in WingBuildOutput output)
		{
			PartScript partScript = null;
			for (int i = 0; i < output.MeshObjects.Length; i++)
			{
				List<ColliderInfo> list = output.Colliders[i];
				if (list == null)
				{
					continue;
				}
				PartScript partScript2 = FindCSMeshOwner(i);
				bool flag = partScript2 != partScript;
				partScript = partScript2;
				if (base.LoadContext == CraftLoadContext.Designer)
				{
					DecalTargetScript component = output.MeshObjects[i].GetComponent<DecalTargetScript>();
					AttachPointScript component2 = GetComponent<AttachPointScript>();
					foreach (ColliderInfo item in list)
					{
						GameObject gameObject = item.Collider.gameObject;
						gameObject.layer = ((base.gameObject.layer == 2) ? 2 : 15);
						if (!gameObject.TryGetComponent<DecalTargetColliderScript>(out var _))
						{
							gameObject.AddComponent<DecalTargetColliderScript>().DecalTargets.Add(component);
						}
						if (!gameObject.TryGetComponent<AttachPointProxyScript>(out var component4))
						{
							component4 = gameObject.AddComponent<AttachPointProxyScript>();
						}
						component4.AttachPointScript = component2;
					}
				}
				foreach (ColliderInfo item2 in list)
				{
					MeshCollider collider = item2.Collider;
					PartColliderScript component5;
					bool flag2 = collider.TryGetComponent<PartColliderScript>(out component5);
					if (flag2 && component5.IsPrimary == flag)
					{
						flag = false;
						continue;
					}
					if (flag2)
					{
						UnityEngine.Object.Destroy(component5);
					}
					component5 = (flag ? PartColliderScript.AddAsPrimary(collider.gameObject) : collider.gameObject.AddComponent<PartColliderScript>());
					component5.ExcludeFromDragModel = true;
					flag = false;
				}
			}
		}

		private void UpdateControlSurfaceInputData()
		{
			if (_controlSurfaces.Count == 0)
			{
				_controlSurfacesArray = new ControlSurface[0];
				_controlSurfaceScripts = null;
				_controlSurfaceUVs = null;
				_controlSurfaceParentTransforms = null;
				return;
			}
			int count = _controlSurfaces.Count;
			if (_controlSurfacesArray == null || _controlSurfacesArray.Length != count)
			{
				_controlSurfacesArray = new ControlSurface[count];
				_controlSurfaceScripts = new ControlSurfacePartScript[count];
				_controlSurfaceUVs = new Vector3[count];
				_controlSurfaceParentTransforms = new Transform[count];
			}
			for (int i = 0; i < count; i++)
			{
				ControlSurfacePartData controlSurfacePartData = _controlSurfaces[i];
				ControlSurface.UpdateClone(ref _controlSurfacesArray[i], controlSurfacePartData.ControlSurface);
				PartScript partScript = controlSurfacePartData.Part.PartScript;
				ControlSurfacePartScript modifier = partScript.GetModifier<ControlSurfacePartScript>();
				if (modifier != null)
				{
					modifier.LastGeneratedWing = this;
				}
				_controlSurfaceScripts[i] = modifier;
				_controlSurfaceParentTransforms[i] = modifier.transform;
				_controlSurfaceUVs[i] = new Vector3(partScript.PartMaterialScript.MaterialIdPrimary, 0f, partScript.Part.Id);
			}
		}

		private void UpdateControlSurfaceMasses(in WingBuildOutput wingOut)
		{
			for (int i = 0; i < _controlSurfaces.Count; i++)
			{
				ControlSurfacePartData controlSurfacePartData = _controlSurfaces[i];
				ControlSurface controlSurface = _controlSurfacesArray[i];
				if (controlSurface.MeshIndexOffset >= 0)
				{
					Span<MassPropertiesOutput> massOut = wingOut.MassPropertiesOutput.AsSpan(controlSurface.MeshIndexOffset, controlSurface.MeshCount);
					RigidTransform rigidTransform = wingOut.ControlSurfaceRootPoses[i];
					controlSurfacePartData.SetMassProperties(massOut, new Pose(rigidTransform.pos, rigidTransform.rot));
				}
				else
				{
					controlSurfacePartData.SetMassDefault();
				}
			}
		}

		private void UpdateMeshDesigner(WingDebugInfo debugCollector)
		{
			if (!_readyToGenerate)
			{
				return;
			}
			if (_designerChangesSuspended)
			{
				_designerChangesWaiting = true;
			}
			WingBuilderInput builderInput = GetBuilderInput();
			builderInput.DebugCollector = debugCollector;
			WingBuildOutput output = WingBuilder.Generate(builderInput);
			Data.OnWingMeshRebuilt(in output);
			UpdateColliders(in output);
			base.PartScript.PartMaterialScript.OnThemeUpdated();
			base.PartScript.PartMaterialScript.OnMeshChanged();
			UpdateControlSurfaceMasses(in output);
			DecalTargetScript[] componentsInChildren = GetComponentsInChildren<DecalTargetScript>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ReinitializeRenderers();
			}
			if (_colliderMetadata == null)
			{
				_colliderMetadata = new Dictionary<MeshCollider, (int, ColliderInfo)>();
			}
			_colliderMetadata.Clear();
			HashSet<PartScript> hashSet = HashSetPool<PartScript>.Get();
			for (int j = 0; j < output.Colliders.Length; j++)
			{
				List<ColliderInfo> list = output.Colliders[j];
				if (list == null)
				{
					continue;
				}
				foreach (ColliderInfo item in list)
				{
					_colliderMetadata.Add(item.Collider, (j, item));
				}
				PartScript partScript = output.MeshObjects[j]?.GetComponentInParent<PartScript>();
				if (partScript != null)
				{
					hashSet.Add(partScript);
				}
			}
			StartCoroutine(CreateEditorCollidersCoroutine(hashSet));
			if (_controlSurfaces.Count <= 0)
			{
				return;
			}
			Pose worldPose = base.transform.GetWorldPose();
			for (int k = 0; k < _controlSurfaces.Count; k++)
			{
				RigidTransform rigidTransform = output.ControlSurfaceRootPoses[k];
				Pose pose = worldPose.TransformPose(new Pose(rigidTransform.pos, rigidTransform.rot));
				_controlSurfaces[k].Part.PartScript.transform.SetGlobalPose(pose);
				componentsInChildren = _controlSurfaces[k].Part.PartScript.gameObject.GetComponentsInChildren<DecalTargetScript>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].ReinitializeRenderers();
				}
			}
			static IEnumerator CreateEditorCollidersCoroutine(HashSet<PartScript> partScripts)
			{
				foreach (PartScript partScript2 in partScripts)
				{
					partScript2.EditorColliders.Clear();
				}
				yield return new WaitForEndOfFrame();
				foreach (PartScript partScript3 in partScripts)
				{
					if (!(partScript3 == null))
					{
						Assembly.CreateEditorCollidersForPartScript(partScript3);
					}
				}
				HashSetPool<PartScript>.Release(partScripts);
			}
		}
	}
}
