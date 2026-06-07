using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("")]
	internal sealed class WaterChunkRenderer : ManagedBehaviour<WaterRenderer>
	{
		[SerializeField]
		internal bool _DrawRenderBounds;

		internal const string k_UpdateMeshBoundsMarker = "Crest.WaterChunkRenderer.UpdateMeshBounds";

		private static readonly ProfilerMarker s_UpdateMeshBoundsMarker = new ProfilerMarker("Crest.WaterChunkRenderer.UpdateMeshBounds");

		internal Transform _Transform;

		internal Mesh _Mesh;

		internal MaterialPropertyBlock _MaterialPropertyBlock;

		private Matrix4x4 _CurrentObjectToWorld;

		private Matrix4x4 _PreviousObjectToWorld;

		internal Material _MotionVectorMaterial;

		internal int _SortingOrder;

		internal int _SiblingIndex;

		internal Rect _UnexpandedBoundsXZ;

		internal Bounds _LocalBounds;

		internal float _LocalScale;

		internal bool _Culled;

		internal bool _Visible;

		internal WaterRenderer _Water;

		internal bool _WaterDataHasBeenBound = true;

		internal int _LodIndex = -1;

		public Renderer Rend { get; private set; }

		public Rect UnexpandedBoundsXZ => _UnexpandedBoundsXZ;

		public bool MaterialOverridden { get; set; }

		internal void Initialize(int index, Renderer renderer, Mesh mesh)
		{
			_LodIndex = index;
			Rend = renderer;
			_Mesh = mesh;
			_Transform = base.transform;
		}

		private protected override void OnStart()
		{
			base.OnStart();
			UpdateMeshBounds();
		}

		internal void UpdateMeshBounds(WaterRenderer water, SurfaceRenderer surface)
		{
			_WaterDataHasBeenBound = false;
			int timeSliceBoundsUpdateFrameCount = surface.TimeSliceBoundsUpdateFrameCount;
			if (timeSliceBoundsUpdateFrameCount <= 1 || _SiblingIndex % timeSliceBoundsUpdateFrameCount == Time.frameCount % surface.Chunks.Count % timeSliceBoundsUpdateFrameCount)
			{
				UpdateMeshBounds();
			}
		}

		private bool ShouldRender(bool culled)
		{
			if (!_Visible)
			{
				return false;
			}
			if (culled && _Culled)
			{
				return false;
			}
			return true;
		}

		internal void OnLateUpdate()
		{
			_PreviousObjectToWorld = _Water.Surface.PreviousObjectToWorld[_SiblingIndex];
			_CurrentObjectToWorld = _Transform.localToWorldMatrix;
			_Water.Surface.PreviousObjectToWorld[_SiblingIndex] = _CurrentObjectToWorld;
		}

		internal void RenderMotionVectors(SurfaceRenderer surface, Camera camera)
		{
			if (ShouldRender(culled: true))
			{
				if (!_WaterDataHasBeenBound)
				{
					Bind();
				}
				Material material = (MaterialOverridden ? _MotionVectorMaterial : surface._MotionVectorMaterial);
				RenderParams renderParams = new RenderParams(material);
				renderParams.motionVectorMode = MotionVectorGenerationMode.Object;
				renderParams.material = material;
				renderParams.matProps = _MaterialPropertyBlock;
				renderParams.worldBounds = Rend.bounds;
				renderParams.layer = surface.Layer;
				renderParams.renderingLayerMask = (uint)surface.Layer;
				renderParams.receiveShadows = false;
				renderParams.shadowCastingMode = ShadowCastingMode.Off;
				renderParams.lightProbeUsage = LightProbeUsage.Off;
				renderParams.reflectionProbeUsage = ReflectionProbeUsage.Off;
				renderParams.camera = camera;
				RenderParams rparams = renderParams;
				Graphics.RenderMesh(in rparams, _Mesh, 0, _CurrentObjectToWorld, _PreviousObjectToWorld);
			}
		}

		private void UpdateMeshBounds()
		{
			Bounds localBounds = _LocalBounds;
			localBounds = ComputeBounds(_Transform, localBounds);
			_UnexpandedBoundsXZ = new Rect(0f, 0f, localBounds.size.x, localBounds.size.z)
			{
				center = localBounds.center.XZ()
			};
			localBounds = ExpandBoundsForDisplacements(_Transform, localBounds);
			Rend.bounds = localBounds;
		}

		internal void Bind()
		{
			_MaterialPropertyBlock = _Water.Surface.PerCascadeMPB[_LodIndex];
			new PropertyWrapperMPB(_MaterialPropertyBlock).SetSHCoefficients(_Transform.position);
			Rend.SetPropertyBlock(_MaterialPropertyBlock);
			_WaterDataHasBeenBound = true;
		}

		private void OnDestroy()
		{
			Helpers.Destroy(_Mesh);
			_Mesh = null;
		}

		private void OnWillRenderObject()
		{
			if (!(Rend == null))
			{
				if (!MaterialOverridden && Rend.sharedMaterial != _Water.Surface.Material)
				{
					Rend.sharedMaterial = _Water.Surface.Material;
					_MotionVectorMaterial = _Water.Surface._MotionVectorMaterial;
				}
				if (!_WaterDataHasBeenBound)
				{
					Bind();
				}
			}
		}

		public Bounds ComputeBounds(Transform transform, Bounds bounds)
		{
			Vector3 extents = bounds.extents;
			Vector3 center = bounds.center;
			float num = _LocalScale * _Water.Scale;
			extents.x *= num;
			extents.z *= num;
			center.x *= num;
			center.z *= num;
			center += transform.position;
			bounds.center = center;
			bounds.extents = extents;
			return bounds;
		}

		public Bounds ExpandBoundsForDisplacements(Transform transform, Bounds bounds)
		{
			Vector3 extents = bounds.extents;
			Vector3 center = bounds.center;
			Rect bounds2 = _UnexpandedBoundsXZ;
			if (_Water._DynamicWavesLod.Enabled)
			{
				DynamicWavesLodSettings settings = _Water.DynamicWavesLod.Settings;
				extents.x += settings._HorizontalDisplace;
				extents.y += settings._VerticalDisplacementCullingContributions;
				extents.z += settings._HorizontalDisplace;
			}
			float horizontal = 0f;
			float vertical = 0f;
			int key;
			ILodInput value;
			foreach (KeyValuePair<int, ILodInput> s_Input in AnimatedWavesLod.s_Inputs)
			{
				s_Input.Deconstruct(out key, out value);
				value.DisplacementReporter?.ReportDisplacement(_Water, ref bounds2, ref horizontal, ref vertical);
			}
			extents.x += horizontal;
			extents.y += vertical;
			extents.z += horizontal;
			float minimum = 0f;
			float maximum = 0f;
			foreach (KeyValuePair<int, ILodInput> s_Input2 in LevelLod.s_Inputs)
			{
				s_Input2.Deconstruct(out key, out value);
				value.HeightReporter?.ReportHeight(_Water, ref bounds2, ref minimum, ref maximum);
			}
			extents.y += Mathf.Abs((minimum - maximum) * 0.5f);
			float num = Mathf.Lerp(minimum, maximum, 0.5f);
			center.y += num;
			bounds.center = center;
			bounds.extents = extents;
			return bounds;
		}
	}
}
