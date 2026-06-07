using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Design;
using Assets.Scripts.Design.UI;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using Shapes;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	[BurstCompile]
	public abstract class MeshModifierBaseScript : PartModifierScript, IPartTargetingHandler
	{
		protected readonly struct CollectedRenderer : IDisposable
		{
			public readonly ProceduralPartMeshRenderer renderer;

			private readonly Dictionary<PartData, NativeMesh> _activeMeshes;

			private readonly List<NativeMesh> _cachedList;

			private readonly HashSet<PartData> _unusedParts;

			public int MeshCount => _activeMeshes.Count - _unusedParts.Count;

			public CollectedRenderer(ProceduralPartMeshRenderer renderer)
			{
				this.renderer = renderer;
				_activeMeshes = new Dictionary<PartData, NativeMesh>();
				_cachedList = new List<NativeMesh>();
				_unusedParts = new HashSet<PartData>();
			}

			public void Destroy()
			{
				renderer.Destroy();
				foreach (NativeMesh value in _activeMeshes.Values)
				{
					value.Dispose();
				}
				_activeMeshes.Clear();
				_unusedParts.Clear();
			}

			public void Dispose()
			{
				renderer.Dispose();
				foreach (NativeMesh value in _activeMeshes.Values)
				{
					value.Dispose();
				}
				_activeMeshes.Clear();
				_unusedParts.Clear();
			}

			public NativeMesh GetMesh(PartData part, bool clear = true)
			{
				_unusedParts.Remove(part);
				if (_activeMeshes.TryGetValue(part, out var value))
				{
					if (clear)
					{
						value.Clear();
					}
					return value;
				}
				value = new NativeMesh(256, 256, Allocator.Persistent);
				_activeMeshes.Add(part, value);
				return value;
			}

			public bool MarkPartUnused(PartData part)
			{
				if (_activeMeshes.ContainsKey(part))
				{
					return _unusedParts.Add(part);
				}
				return false;
			}

			public void UpdateRenderer(Action<NativeMesh> postProcessMesh = null)
			{
				foreach (PartData unusedPart in _unusedParts)
				{
					if (_activeMeshes.TryGetValue(unusedPart, out var value))
					{
						value.Dispose();
						_activeMeshes.Remove(unusedPart);
					}
				}
				_unusedParts.Clear();
				List<NativeMesh> cachedList = _cachedList;
				cachedList.Clear();
				cachedList.AddRange(_activeMeshes.Values);
				int num = 0;
				int num2 = 0;
				foreach (NativeMesh item in cachedList)
				{
					num += item.Vertices.Length;
					num2 += item.Triangles.Length;
				}
				using NativeArray<NativeMesh.ReadOnlyUnsafe> nativeArray = new NativeArray<NativeMesh.ReadOnlyUnsafe>(cachedList.Count, Allocator.TempJob);
				using NativeMesh nativeMesh = new NativeMesh(num, num2, Allocator.TempJob);
				NativeArray<NativeMesh.ReadOnlyUnsafe> nativeArray2 = nativeArray;
				for (int i = 0; i < cachedList.Count; i++)
				{
					nativeArray2[i] = cachedList[i].AsReadOnlyUnsafe();
				}
				new CombineCollectedRenderer
				{
					inputMeshes = nativeArray,
					outputMesh = nativeMesh
				}.Run();
				postProcessMesh?.Invoke(nativeMesh);
				renderer.UpdateMesh(nativeMesh);
			}
		}

		[BurstCompile]
		private struct CombineCollectedRenderer : IJob
		{
			[NativeDisableUnsafePtrRestriction]
			public NativeArray<NativeMesh.ReadOnlyUnsafe> inputMeshes;

			public NativeMesh outputMesh;

			public void Execute()
			{
				outputMesh.Clear();
				for (int i = 0; i < inputMeshes.Length; i++)
				{
					outputMesh.Combine(inputMeshes[i]);
				}
				outputMesh.SortSubmeshes();
			}
		}

		protected class MeshModifyContext : IDisposable
		{
			private readonly bool _applyScale;

			private Manifold<Vertex> _colliderModSpace;

			private JFuselageScript _fuselage;

			private MeshModifierBaseScript _modifier;

			private float4x4? _modifierFromTarget;

			private Manifold<Vertex> _sourceModSpace;

			private Manifold<Vertex> _sourceTargetSpace;

			private Manifold<Vertex> _targetModSpace;

			private Manifold<Vertex> _thinManifold;

			private Manifold<Vertex> _thinModSpace;

			public int MeshesEmitted { get; private set; }

			public float4x4 ModifierFromSource { get; }

			public float4x4 ModifierFromTarget
			{
				get
				{
					float4x4 valueOrDefault = _modifierFromTarget.GetValueOrDefault();
					if (!_modifierFromTarget.HasValue)
					{
						valueOrDefault = math.inverse(TargetFromModifier);
						_modifierFromTarget = valueOrDefault;
						return valueOrDefault;
					}
					return valueOrDefault;
				}
			}

			public Manifold<Vertex> Source { get; }

			public Manifold<Vertex> SourceInModifierSpace
			{
				get
				{
					if (!_applyScale)
					{
						return Source;
					}
					return _sourceModSpace ?? (_sourceModSpace = Source.Transform(Allocator.Temp, ModifierFromSource));
				}
			}

			public Manifold<Vertex> SourceInTargetSpace => _sourceTargetSpace ?? (_sourceTargetSpace = Source.Transform(Allocator.Temp, TargetFromSource));

			public Manifold<Vertex> Target { get; }

			public Manifold<Vertex> TargetCollider { get; }

			public Manifold<Vertex> TargetColliderInModifierSpace
			{
				get
				{
					object obj;
					if (TargetCollider != null)
					{
						obj = _colliderModSpace;
						if (obj == null)
						{
							return _colliderModSpace = TargetCollider.Transform(Allocator.Temp, ModifierFromTarget);
						}
					}
					else
					{
						obj = null;
					}
					return (Manifold<Vertex>)obj;
				}
			}

			public float4x4 TargetFromModifier { get; }

			public float4x4 TargetFromSource { get; }

			public Manifold<Vertex> TargetInModifierSpace => _targetModSpace ?? (_targetModSpace = Target.Transform(Allocator.Temp, ModifierFromTarget));

			public PartScript TargetPart => _fuselage.PartScript;

			public Manifold<Vertex> ThinManifoldInModifierSpace => _thinModSpace ?? (_thinModSpace = ThinManifoldTargetSpace.Transform(Allocator.Temp, ModifierFromTarget));

			public Manifold<Vertex> ThinManifoldTargetSpace => _thinManifold ?? (_thinManifold = _fuselage.RequireThinManifold());

			public MeshModifyContext(JFuselageScript target, MeshModifierBaseScript modifier, Manifold<Vertex> targetManifold, Manifold<Vertex> sourceManifold, Manifold<Vertex> targetColliderManifold)
			{
				_fuselage = target;
				_modifier = modifier;
				Source = sourceManifold;
				Target = targetManifold;
				TargetCollider = targetColliderManifold;
				TargetFromModifier = math.mul(math.inverse(target.PartScript.PartToCraftOriginMatrix), modifier.PartScript.PartToCraftOriginMatrix);
				_applyScale = false;
				if (modifier is ScalableMeshModifierBaseScript { ApplyScaleToManifold: not false } scalableMeshModifierBaseScript && math.any(scalableMeshModifierBaseScript.Data.Scale != 1f))
				{
					ModifierFromSource = float4x4.Scale(scalableMeshModifierBaseScript.Data.Scale);
					TargetFromSource = math.mul(TargetFromModifier, ModifierFromSource);
					_applyScale = true;
				}
				else
				{
					ModifierFromSource = float4x4.identity;
					TargetFromSource = TargetFromModifier;
				}
				_sourceTargetSpace = null;
				_sourceModSpace = null;
			}

			public void Dispose()
			{
				_sourceTargetSpace?.Dispose();
				_sourceTargetSpace = null;
				_sourceModSpace?.Dispose();
				_sourceModSpace = null;
				_targetModSpace?.Dispose();
				_targetModSpace = null;
				_thinModSpace?.Dispose();
				_thinModSpace = null;
				_colliderModSpace?.Dispose();
				_colliderModSpace = null;
			}

			public void EmitLocalMeshPart(Manifold<Vertex> manifold, int rendererId, ulong submeshMask = ulong.MaxValue)
			{
				using (Profile.EmitLocalMeshPart.Auto())
				{
					if (manifold.Status != Error.NO_ERROR)
					{
						Debug.LogError($"Mesh modifier part generation failed with {manifold.Status} on part {_modifier.PartScript.Part.Id} against {_fuselage.PartScript.Part.Id}");
					}
					else if (!manifold.IsEmpty)
					{
						NativeMesh mesh = _modifier.GetRenderer(rendererId).GetMesh(_fuselage.PartScript.Part);
						ManifoldUtils.ConvertManifoldToNativeMesh(manifold, mesh, submeshMask);
					}
				}
			}
		}

		protected class ModifiableMeshReceiver : EventDrivenPartIntersectionReceiver<JFuselageScript>
		{
			private MeshModifierBaseScript _modifier;

			public override int LayerMask => 33554432;

			public override bool Enabled
			{
				get
				{
					PartTargetingData partTargeting = _modifier._partTargeting;
					if (partTargeting == null)
					{
						return false;
					}
					return partTargeting.TargetMode == PartTargetingMode.MultipleParts;
				}
			}

			public Bounds ManifoldLocalBounds { get; set; }

			public ModifiableMeshReceiver(DesignerPartIntersectionManager manager, MeshModifierBaseScript modifier, Bounds manifoldLocalBounds)
				: base(manager)
			{
				_modifier = modifier;
				PartTargetingData modifier2 = modifier.PartScript.Part.GetModifier<PartTargetingData>();
				if (modifier2 != null && modifier2.PartIDs != null)
				{
					Assembly assembly = modifier.PartScript.Aircraft.Aircraft.Assembly;
					foreach (int partID in modifier2.PartIDs)
					{
						PartData partById = assembly.GetPartById(partID);
						if (partById != null)
						{
							JFuselageScript modifier3 = partById.PartScript.GetModifier<JFuselageScript>();
							if (modifier3 != null)
							{
								base.Intersections.Add(modifier3);
							}
						}
					}
				}
				ManifoldLocalBounds = manifoldLocalBounds;
			}

			public override (Vector3 Center, Vector3 HalfExtents, Quaternion Rotation) GetBox()
			{
				Transform transform = _modifier.transform;
				Vector3 item = transform.TransformPoint(ManifoldLocalBounds.center);
				Vector3 vector = ManifoldLocalBounds.extents;
				if (_modifier is ScalableMeshModifierBaseScript { ApplyScaleToManifold: not false } scalableMeshModifierBaseScript)
				{
					vector *= scalableMeshModifierBaseScript.Data.Scale;
				}
				Vector3? partScale = _modifier.PartScript.Part.PartScale;
				if (partScale.HasValue)
				{
					vector = (float3)vector * (float3)partScale.Value;
				}
				return (Center: item, HalfExtents: vector, Rotation: transform.rotation);
			}

			public override void OnUpdate()
			{
				base.OnUpdate();
				if (_modifier._partTargeting?.TargetPart != null)
				{
					JFuselageScript modifier = _modifier._partTargeting.TargetPart.PartScript.GetModifier<JFuselageScript>();
					if (modifier != null)
					{
						SetSingleItem(modifier);
					}
					else
					{
						RemoveAllItems();
					}
				}
			}

			protected override void GetItemsFromHit(Collider hitCollider, HashSet<JFuselageScript> resultSet)
			{
				PartScript componentInParent = hitCollider.GetComponentInParent<PartScript>();
				if (componentInParent != null)
				{
					JFuselageScript modifier = componentInParent.GetModifier<JFuselageScript>();
					if (modifier != null)
					{
						resultSet.Add(modifier);
					}
				}
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker Apply = new ProfilerMarker("MeshModifierBaseScript.Apply");

			public static readonly ProfilerMarker ApplyToPart = new ProfilerMarker("MeshModifierBaseScript.ApplyToPart");

			public static readonly ProfilerMarker EmitLocalMeshPart = new ProfilerMarker("MeshModifyContext.EmitLocalMeshPart");

			public static readonly ProfilerMarker UpdateCombinedMeshes = new ProfilerMarker("MeshModifierBaseScript.UpdateCombinedMeshes");
		}

		private Camera _boxRenderCamera;

		private bool _combinedMeshesDirty;

		private BoxCollider _editorCollider;

		private Color? _gizmoColor = Color.white;

		private ModifiableMeshReceiver _intersectionReceiver;

		private Manifold<Vertex> _manifold;

		private bool _manifoldValid;

		private bool _onRenderSubscribed;

		private PartTargetingData _partTargeting;

		private Pose? _prevPose;

		private Dictionary<int, CollectedRenderer> _renderers = new Dictionary<int, CollectedRenderer>();

		private DesignerUIScript _showCuttingVolumesSubscribedTo;

		private bool _subscribedOnShapeChanged;

		public MeshModifierBaseData Data { get; protected set; }

		public abstract bool ModifiesColliders { get; }

		protected BoxCollider EditorCollider => _editorCollider;

		protected ModifiableMeshReceiver IntersectionReceiver => _intersectionReceiver;

		protected Bounds ManifoldLocalBounds { get; private set; }

		private bool RenderCuttingVolumes
		{
			get
			{
				return _onRenderSubscribed;
			}
			set
			{
				if (_onRenderSubscribed != value)
				{
					if (value)
					{
						RenderPipelineManager.beginCameraRendering += RenderVolume;
					}
					else
					{
						RenderPipelineManager.beginCameraRendering -= RenderVolume;
					}
					_onRenderSubscribed = value;
					if (_editorCollider != null)
					{
						_editorCollider.enabled = value;
					}
				}
			}
		}

		private bool SubscribeToCuttingVolumeChange
		{
			get
			{
				return _showCuttingVolumesSubscribedTo != null;
			}
			set
			{
				if (base.LoadContext != CraftLoadContext.Designer)
				{
					return;
				}
				DesignerUIScript designerUIScript = (value ? Designer.Instance.DesignerScript.DesignerUI : null);
				if (designerUIScript != _showCuttingVolumesSubscribedTo)
				{
					RenderCuttingVolumes = value && designerUIScript.CuttingOutlinesVisible;
					if (_showCuttingVolumesSubscribedTo != null)
					{
						_showCuttingVolumesSubscribedTo.CuttingOutlinesVisibleChanged -= OnShowCuttingVolumesChanged;
					}
					if (designerUIScript != null)
					{
						designerUIScript.CuttingOutlinesVisibleChanged += OnShowCuttingVolumesChanged;
					}
					_showCuttingVolumesSubscribedTo = designerUIScript;
				}
			}
		}

		protected event Action<int, ProceduralPartMeshRenderer> OnCreateRenderer;

		public Manifold<Vertex> ApplyToPart(JFuselageScript fuselage, Manifold<Vertex> inputManifold, ref Manifold<Vertex> colliderManifold, Allocator allocator)
		{
			using (Profile.ApplyToPart.Auto())
			{
				if (!_intersectionReceiver.Intersections.Contains(fuselage))
				{
					Debug.LogWarning($"non-affected fuselage applying modifier: {base.PartScript.Part.Id} applying to {fuselage.PartScript.Part.Id}");
					return null;
				}
				if (!_manifoldValid)
				{
					Debug.LogWarning($"Modifier not applying because manifold is not ready (part {base.PartScript.Part.Id})");
					return null;
				}
				if (base.PartScript.IsDragging || !ModifiesColliders)
				{
					colliderManifold = null;
				}
				foreach (CollectedRenderer value in _renderers.Values)
				{
					value.MarkPartUnused(fuselage.PartScript.Part);
				}
				Manifold<Vertex> colliderOut = null;
				Manifold<Vertex> manifold;
				using (MeshModifyContext ctx = new MeshModifyContext(fuselage, this, inputManifold, _manifold, colliderManifold))
				{
					using (Profile.Apply.Auto())
					{
						manifold = Apply(ctx, allocator, ref colliderOut);
						if (manifold.Status != Error.NO_ERROR)
						{
							Debug.LogWarning($"Boolean result {manifold.Status}: {this} on part {base.PartScript.Part.Id} applying to part {fuselage.PartScript.Part.Id}");
							manifold.Dispose();
							manifold = null;
						}
						else if (colliderOut != null && colliderOut.Status != Error.NO_ERROR)
						{
							Debug.LogWarning($"Boolean result (collider) {manifold.Status}: {this} on part {base.PartScript.Part.Id} applying to part {fuselage.PartScript.Part.Id}");
							colliderOut.Dispose();
							colliderOut = null;
						}
						else
						{
							colliderManifold = colliderOut;
						}
					}
				}
				_combinedMeshesDirty = true;
				return manifold;
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			plan.Register(this, InitManifoldMesh, PreStartInitializationFlags.Default, JFuselageScript.GetInitOrder(FuselageGenerationStage.Setup));
			plan.Register(this, FinaliseMesh, PreStartInitializationFlags.Default, JFuselageScript.GetInitOrder(FuselageGenerationStage.Finalise));
		}

		public List<int> GetPartIDs()
		{
			if (_intersectionReceiver == null)
			{
				return new List<int>();
			}
			return _intersectionReceiver.Intersections.Select((JFuselageScript x) => x.PartScript.Part.Id).ToList();
		}

		public override void OnPartAdded()
		{
			base.OnPartAdded();
			Designer.Instance.DesignerScript.DesignerUI.CuttingOutlinesVisible = true;
		}

		public void SetPartIDs(List<int> partIDs)
		{
			List<JFuselageScript> list = new List<JFuselageScript>();
			Assembly assembly = base.PartScript.Aircraft.Aircraft.Assembly;
			foreach (int partID in partIDs)
			{
				JFuselageScript jFuselageScript = assembly.GetPartById(partID)?.PartScript.GetModifier<JFuselageScript>();
				if (jFuselageScript != null)
				{
					list.Add(jFuselageScript);
				}
			}
			_intersectionReceiver.SetMultipleItems(list);
		}

		protected abstract Manifold<Vertex> Apply(MeshModifyContext ctx, Allocator allocator, ref Manifold<Vertex> colliderOut);

		protected virtual void DrawBox()
		{
			(Vector3 Center, Vector3 HalfExtents, Quaternion Rotation) box = _intersectionReceiver.GetBox();
			Vector3 item = box.Center;
			Vector3 item2 = box.HalfExtents;
			Quaternion item3 = box.Rotation;
			PartMaterialScript.PartHighlightSettings tutorialHighlight = base.PartScript.PartMaterialScript.TutorialHighlight;
			if (tutorialHighlight != null && tutorialHighlight.Color.HasValue)
			{
				Draw.Color = base.PartScript.PartMaterialScript.TutorialHighlight.Color.Value;
			}
			Draw.Matrix = Matrix4x4.TRS(item, item3, Vector3.one);
			Utility.DrawCuboid(new Bounds(default(Vector3), item2 * 2f));
		}

		protected void Initialize(MeshModifierBaseData data)
		{
			Data = data;
			base.PartScript.PartDeleted += OnPartDeleted;
			base.PartScript.DraggingChanged += OnDraggingChanged;
			_partTargeting = base.PartScript.Part.GetModifier<PartTargetingData>();
			_partTargeting.SetHandler(this);
		}

		protected abstract Manifold<Vertex> MakeManifold(Allocator allocator);

		protected Manifold<Vertex> MakeManifoldFromMesh(Allocator allocator, string meshName)
		{
			if (!string.IsNullOrWhiteSpace(meshName))
			{
				Mesh mesh = LoadMesh(meshName);
				using MeshGL<Vertex> meshGL = ManifoldUtils.ConvertToMeshGL(Allocator.Temp, mesh, new int[1] { 5 });
				using MeshGL<Vertex> mesh2 = meshGL.Merge(Allocator.Temp);
				return Manifold.Create(allocator, mesh2);
			}
			return null;
		}

		protected void NotifyAffectedParts()
		{
			foreach (JFuselageScript intersection in _intersectionReceiver.Intersections)
			{
				intersection.RaiseMeshModifierChanged();
			}
		}

		protected void OnDestroy()
		{
			_manifold?.Dispose();
			_manifold = null;
			_intersectionReceiver.Dispose();
			foreach (CollectedRenderer value in _renderers.Values)
			{
				value.Dispose();
			}
			_renderers.Clear();
			if (_subscribedOnShapeChanged)
			{
				Data.OnShapeChanged -= OnShapeChanged;
			}
			if (_onRenderSubscribed)
			{
				RenderPipelineManager.beginCameraRendering -= RenderVolume;
				_onRenderSubscribed = false;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			SubscribeToCuttingVolumeChange = false;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SubscribeToCuttingVolumeChange = true;
		}

		protected virtual void PostProcessMesh(int index, NativeMesh mesh, CollectedRenderer renderer)
		{
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdateDesigner, CraftUpdateFlags.DesignerDefault);
			registrar.RegisterStart(OnStartDesigner, CraftUpdateFlags.DesignerDefault);
		}

		protected virtual void UpdateEditorCollider()
		{
			EditorCollider.center = ManifoldLocalBounds.center;
			EditorCollider.size = ManifoldLocalBounds.size;
		}

		protected void UpdateManifoldShape()
		{
			_manifold?.Dispose();
			_manifold = null;
			Manifold<Vertex> manifold = MakeManifold(Allocator.Persistent);
			Bounds manifoldLocalBounds;
			if (manifold == null)
			{
				_manifold = null;
				_manifoldValid = false;
				manifoldLocalBounds = default(Bounds);
				Debug.LogError($"Modifier {this} failed to make manifold for part #{base.PartScript.Part.Id}", this);
			}
			else if (manifold.Status == Error.NO_ERROR)
			{
				_manifold = manifold;
				manifoldLocalBounds = (Bounds)manifold.BoundingBox();
				_manifoldValid = true;
				if (manifold.IsEmpty || math.any(math.isnan(manifoldLocalBounds.min)))
				{
					manifoldLocalBounds = new Bounds(Vector3.zero, Vector3.one);
				}
			}
			else
			{
				_manifold = null;
				_manifoldValid = false;
				manifoldLocalBounds = default(Bounds);
				Debug.LogError($"Modifier part failed to build manifold: {manifold.Status} on part #{base.PartScript.Part.Id}", this);
			}
			ManifoldLocalBounds = manifoldLocalBounds;
			_intersectionReceiver.ManifoldLocalBounds = manifoldLocalBounds;
		}

		private static Mesh LoadMesh(string name)
		{
			if (name.StartsWith('#'))
			{
				return Resources.GetBuiltinResource<Mesh>(name.Substring(1, name.Length - 1));
			}
			return Resources.Load<Mesh>("Craft/Parts/Carver/" + name);
		}

		private void CustomMaterialUpdateCallback(object sender, PartMaterialScript.MaterialUpdateEventArgs e)
		{
			_gizmoColor = e.Color;
		}

		private UniTask FinaliseMesh(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			UpdateMeshesIfDirty();
			return UniTask.CompletedTask;
		}

		private CollectedRenderer GetRenderer(int id)
		{
			if (_renderers.TryGetValue(id, out var value))
			{
				return value;
			}
			value = new CollectedRenderer(new ProceduralPartMeshRenderer(base.PartScript, $"Mesh-{id}", base.LoadContext));
			_renderers.Add(id, value);
			this.OnCreateRenderer?.Invoke(id, value.renderer);
			return value;
		}

		private UniTask InitManifoldMesh(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_manifoldValid = false;
			_intersectionReceiver = new ModifiableMeshReceiver(null, this, default(Bounds));
			UpdateManifoldShape();
			foreach (JFuselageScript intersection in _intersectionReceiver.Intersections)
			{
				intersection.MeshModifiers.Add(this);
			}
			_intersectionReceiver.OnIntersectionAdded += delegate(JFuselageScript fuselage)
			{
				fuselage.MeshModifiers.Add(this);
				fuselage.RaiseMeshModifierChanged();
			};
			_intersectionReceiver.OnIntersectionRemoved += delegate(JFuselageScript fuselage)
			{
				fuselage.MeshModifiers.Remove(this);
				fuselage.RaiseMeshModifierChanged();
				foreach (CollectedRenderer value in _renderers.Values)
				{
					_combinedMeshesDirty |= value.MarkPartUnused(fuselage.PartScript.Part);
				}
			};
			if (loadContext == CraftLoadContext.Designer)
			{
				GameObject gameObject = new GameObject("EditorCollider");
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				gameObject.transform.SetLocalPose(Pose.identity);
				_editorCollider = gameObject.AddComponent<BoxCollider>();
				PartColliderScript partColliderScript = gameObject.AddComponent<PartColliderScript>();
				partColliderScript.ExcludeFromDragModel = true;
				partColliderScript.IgnoreDesignerCollisions = true;
				partColliderScript.IsPrimary = true;
				partColliderScript.IncludeInBounds = false;
				base.PartScript.EditorColliders.Add(new EditorCollider(_editorCollider, base.PartScript, partColliderScript));
				UpdateEditorCollider();
				_editorCollider.enabled = RenderCuttingVolumes;
				Data.OnShapeChanged += OnShapeChanged;
				_subscribedOnShapeChanged = true;
			}
			return UniTask.CompletedTask;
		}

		private void OnDraggingChanged(bool isDragging)
		{
			if (ModifiesColliders)
			{
				OnShapeChanged();
			}
		}

		private void OnLateUpdateDesigner(in CraftUpdateFrameData frameData)
		{
			Pose worldPose = base.transform.GetWorldPose();
			if (_prevPose.HasValue && _prevPose.Value != worldPose)
			{
				foreach (JFuselageScript intersection in _intersectionReceiver.Intersections)
				{
					intersection.RaiseMeshModifierChanged();
				}
			}
			_prevPose = worldPose;
			UpdateMeshesIfDirty();
		}

		private void OnPartDeleted(object sender, PartScript.PartScriptEventArgs e)
		{
			foreach (JFuselageScript intersection in _intersectionReceiver.Intersections)
			{
				intersection.MeshModifiers.Remove(this);
				intersection.RaiseMeshModifierChanged();
			}
		}

		private void OnShapeChanged()
		{
			UpdateManifoldShape();
			UpdateEditorCollider();
			NotifyAffectedParts();
		}

		private void OnShowCuttingVolumesChanged(bool show)
		{
			RenderCuttingVolumes = show;
		}

		private void OnStartDesigner(in CraftUpdateFrameData frameData)
		{
			_intersectionReceiver.SetManager(Designer.Instance.DesignerPartIntersectionManager);
			base.PartScript.PartMaterialScript.CustomMaterialUpdateCallback += CustomMaterialUpdateCallback;
			_boxRenderCamera = Designer.Instance.CameraController.Camera;
		}

		private void RenderVolume(ScriptableRenderContext ctx, Camera cam)
		{
			if (!base.PartScript.Part.VisibleInDesigner || cam != _boxRenderCamera || _intersectionReceiver == null)
			{
				return;
			}
			using (Draw.Command(cam))
			{
				Draw.Thickness = 3f;
				Draw.ThicknessSpace = ThicknessSpace.Pixels;
				Draw.SizeSpace = ThicknessSpace.Meters;
				Draw.BlendMode = ShapesBlendMode.Transparent;
				Draw.Color = _gizmoColor ?? new Color(0.7f, 0.7f, 0.7f, 0.1f);
				DrawBox();
			}
		}

		private bool TryGetRenderer(int idx, out CollectedRenderer renderer)
		{
			if (idx >= _renderers.Count)
			{
				renderer = default(CollectedRenderer);
				return false;
			}
			renderer = _renderers[idx];
			return true;
		}

		private void UpdateCombinedMeshes()
		{
			using (Profile.UpdateCombinedMeshes.Auto())
			{
				int[] array = _renderers.Keys.ToArray();
				foreach (int key in array)
				{
					CollectedRenderer collectedRenderer = _renderers[key];
					if (collectedRenderer.MeshCount == 0)
					{
						_renderers.Remove(key);
						collectedRenderer.Destroy();
					}
				}
				for (int j = 0; j < _renderers.Count; j++)
				{
					CollectedRenderer renderer = _renderers[j];
					int index = j;
					renderer.UpdateRenderer(delegate(NativeMesh m)
					{
						PostProcessMesh(index, m, renderer);
					});
				}
			}
		}

		private void UpdateMeshesIfDirty()
		{
			if (_combinedMeshesDirty)
			{
				_combinedMeshesDirty = false;
				UpdateCombinedMeshes();
			}
		}
	}
}
