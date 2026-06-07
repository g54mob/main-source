using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/Deformable")]
	public class ElasticDeformable : Deformable
	{
		public enum VertexColorMask
		{
			None = -1,
			R = 0,
			G = 1,
			B = 2,
			A = 3
		}

		[Tooltip("A value of zero will result in infinite oscillation. A value of one will result in no oscillation.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float dampingRatio = 0.3f;

		[Tooltip("An angular frequency of 1 means the oscillation completes one full period over one second.")]
		[SerializeField]
		private float angularFrequency = 4f;

		[SerializeField]
		private Vector3 gravity = Vector3.zero;

		[SerializeField]
		private VertexColorMask mask = VertexColorMask.None;

		[Tooltip("A value of zero will result in infinite oscillation. A value of one will result in no oscillation.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float maskedDampingRatio = 0.8f;

		[Tooltip("An angular frequency of 1 means the oscillation completes one full period over one second.")]
		[SerializeField]
		private float maskedAngularFrequency = 8f;

		private NativeArray<float3> velocityBuffer;

		private NativeArray<float3> currentPointBuffer;

		public override StripMode StripMode
		{
			get
			{
				return StripMode.DontStrip;
			}
			set
			{
				Debug.LogError("Cannot set StripMode.\nElasticDeformable is a continuous simulation and should not be stripped");
			}
		}

		public float DampingRatio
		{
			get
			{
				return dampingRatio;
			}
			set
			{
				dampingRatio = Mathf.Clamp01(value);
			}
		}

		public float AngularFrequency
		{
			get
			{
				return angularFrequency;
			}
			set
			{
				angularFrequency = value;
			}
		}

		public VertexColorMask Mask
		{
			get
			{
				return mask;
			}
			set
			{
				mask = value;
			}
		}

		public float MaskedDampingRatio
		{
			get
			{
				return maskedDampingRatio;
			}
			set
			{
				maskedDampingRatio = Mathf.Clamp01(value);
			}
		}

		public float MaskedAngularFrequency
		{
			get
			{
				return maskedAngularFrequency;
			}
			set
			{
				maskedAngularFrequency = value;
			}
		}

		public override UpdateFrequency UpdateFrequency => UpdateFrequency.Immediate;

		public override void AllocateData()
		{
			base.AllocateData();
			velocityBuffer = new NativeArray<float3>(data.Length, Allocator.Persistent);
		}

		public override void DisposeData()
		{
			base.DisposeData();
			if (velocityBuffer.IsCreated)
			{
				velocityBuffer.Dispose();
			}
			if (currentPointBuffer.IsCreated)
			{
				currentPointBuffer.Dispose();
			}
		}

		public override JobHandle Schedule(bool ignoreCullingMode, JobHandle dependency = default(JobHandle))
		{
			if (!ignoreCullingMode && cullingMode == CullingMode.DontUpdate && !IsVisible())
			{
				return dependency;
			}
			if (data.Target.GetGameObject() == null && !data.Initialize(base.gameObject))
			{
				return dependency;
			}
			if (!CanUpdate())
			{
				return dependency;
			}
			handle = dependency;
			for (int i = 0; i < deformerElements.Count; i++)
			{
				DeformerElement deformerElement = deformerElements[i];
				Deformer component = deformerElement.Component;
				if (deformerElement.CanProcess())
				{
					if (component.RequiresUpdatedBounds && base.BoundsRecalculation == BoundsRecalculation.Auto)
					{
						handle = MeshUtils.RecalculateBounds(data.DynamicNative, handle);
						currentModifiedDataFlags |= DataFlags.Bounds;
					}
					handle = component.Process(data, handle);
					currentModifiedDataFlags |= component.DataFlags;
				}
			}
			if (Application.isPlaying)
			{
				if (!currentPointBuffer.IsCreated)
				{
					currentPointBuffer = new NativeArray<float3>(data.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					handle = new CopyFloat3sJob
					{
						from = data.DynamicNative.VertexBuffer,
						to = currentPointBuffer
					}.Schedule(data.Length, 64, handle);
					handle = new TransformPointsJob
					{
						points = currentPointBuffer,
						matrix = base.transform.localToWorldMatrix
					}.Schedule(currentPointBuffer.Length, 128, handle);
				}
				if (!Mathf.Approximately(gravity.sqrMagnitude, 0f))
				{
					handle = new AddFloat3ToFloat3sJob
					{
						value = gravity * Time.deltaTime,
						values = velocityBuffer
					}.Schedule(velocityBuffer.Length, 64, handle);
				}
				handle = new TransformPointsJob
				{
					points = data.DynamicNative.VertexBuffer,
					matrix = base.transform.localToWorldMatrix
				}.Schedule(data.Length, 64, handle);
				if (Mask == VertexColorMask.None)
				{
					handle = new ElasticPointsUpdateJob
					{
						dampingRatio = DampingRatio,
						angularFrequency = AngularFrequency,
						deltaTime = Time.deltaTime,
						velocities = velocityBuffer,
						currentPoints = currentPointBuffer,
						targetPoints = data.DynamicNative.VertexBuffer
					}.Schedule(data.Length, 64, handle);
				}
				else
				{
					handle = new MaskedElasticPointsUpdateJob
					{
						unmaskedDampingRatio = DampingRatio,
						unmaskedAngularFrequency = AngularFrequency,
						maskedDampingRatio = maskedDampingRatio,
						maskedAngularFrequency = maskedAngularFrequency,
						deltaTime = Time.deltaTime,
						velocities = velocityBuffer,
						currentPoints = currentPointBuffer,
						targetPoints = data.DynamicNative.VertexBuffer,
						colors = data.DynamicNative.ColorBuffer,
						maskIndex = (int)Mask
					}.Schedule(data.Length, 64, handle);
				}
				handle = new TransformPointsFromJob
				{
					from = currentPointBuffer,
					to = data.DynamicNative.VertexBuffer,
					matrix = base.transform.worldToLocalMatrix
				}.Schedule(data.Length, 128, handle);
			}
			bool num = currentModifiedDataFlags.HasFlag(DataFlags.Vertices);
			if (num && base.NormalsRecalculation == NormalsRecalculation.Auto)
			{
				handle = MeshUtils.RecalculateNormals(data.DynamicNative, handle);
				currentModifiedDataFlags |= DataFlags.Normals;
			}
			if ((num && base.BoundsRecalculation == BoundsRecalculation.Auto) || base.BoundsRecalculation == BoundsRecalculation.OnceAtTheEnd)
			{
				handle = MeshUtils.RecalculateBounds(data.DynamicNative, handle);
				currentModifiedDataFlags |= DataFlags.Bounds;
			}
			return handle;
		}

		public override void ApplyData(bool ignoreCullingMode)
		{
			if (CanUpdate())
			{
				if (Application.isPlaying)
				{
					currentModifiedDataFlags |= DataFlags.Vertices;
				}
				data.ApplyData(currentModifiedDataFlags | lastModifiedDataFlags);
				if (base.BoundsRecalculation == BoundsRecalculation.Custom)
				{
					data.DynamicMesh.bounds = base.CustomBounds;
				}
				if (base.ColliderRecalculation == ColliderRecalculation.Auto)
				{
					RecalculateMeshCollider();
				}
				DynamicMeshUpdated?.Invoke(data);
				ResetDynamicData();
			}
		}

		private void Reset()
		{
			base.CullingMode = CullingMode.AlwaysUpdate;
		}
	}
}
