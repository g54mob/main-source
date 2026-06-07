using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Lattice", Description = "Free-form deform a mesh using lattice control points", Type = typeof(LatticeDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/LatticeDeformer")]
	public class LatticeDeformer : Deformer
	{
		public enum InterpolationMode
		{
			Linear = 0,
			[InspectorName("Hermite (WIP)")]
			Hermite = 1
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LatticeJob : IJobParallelFor
		{
			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<float3> controlPoints;

			[ReadOnly]
			public int3 resolution;

			[ReadOnly]
			public float4x4 meshToTarget;

			[ReadOnly]
			public float4x4 targetToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float3 float5 = math.transform(meshToTarget, vertices[index]) + math.float3(0.5f, 0.5f, 0.5f);
				int3 x = new int3((int)(float5.x * (float)(resolution.x - 1)), (int)(float5.y * (float)(resolution.y - 1)), (int)(float5.z * (float)(resolution.z - 1)));
				x = math.max(x, new int3(0, 0, 0));
				x = math.min(x, resolution - new int3(2, 2, 2));
				int index2 = x.x + x.y * resolution.x + x.z * (resolution.x * resolution.y);
				int index3 = x.x + 1 + x.y * resolution.x + x.z * (resolution.x * resolution.y);
				int index4 = x.x + (x.y + 1) * resolution.x + x.z * (resolution.x * resolution.y);
				int index5 = x.x + 1 + (x.y + 1) * resolution.x + x.z * (resolution.x * resolution.y);
				int index6 = x.x + x.y * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				int index7 = x.x + 1 + x.y * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				int index8 = x.x + (x.y + 1) * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				int index9 = x.x + 1 + (x.y + 1) * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				float3 valueToClamp = float5 * (resolution - new int3(1, 1, 1)) - x;
				valueToClamp = math.clamp(valueToClamp, float3.zero, new float3(1f, 1f, 1f));
				float3 zero = float3.zero;
				if (float5.x < 0f)
				{
					float start = math.lerp(controlPoints[index2].x, controlPoints[index4].x, valueToClamp.y);
					float end = math.lerp(controlPoints[index6].x, controlPoints[index8].x, valueToClamp.y);
					float num = math.lerp(start, end, valueToClamp.z);
					zero.x = float5.x + num;
				}
				else if (float5.x > 1f)
				{
					float start2 = math.lerp(controlPoints[index3].x, controlPoints[index5].x, valueToClamp.y);
					float end2 = math.lerp(controlPoints[index7].x, controlPoints[index9].x, valueToClamp.y);
					float num2 = math.lerp(start2, end2, valueToClamp.z);
					zero.x = float5.x + num2 - 1f;
				}
				else
				{
					float start3 = math.lerp(controlPoints[index2].x, controlPoints[index4].x, valueToClamp.y);
					float start4 = math.lerp(controlPoints[index3].x, controlPoints[index5].x, valueToClamp.y);
					float end3 = math.lerp(controlPoints[index6].x, controlPoints[index8].x, valueToClamp.y);
					float end4 = math.lerp(controlPoints[index7].x, controlPoints[index9].x, valueToClamp.y);
					float start5 = math.lerp(start3, end3, valueToClamp.z);
					float end5 = math.lerp(start4, end4, valueToClamp.z);
					zero.x = math.lerp(start5, end5, valueToClamp.x);
				}
				if (float5.y < 0f)
				{
					float start6 = math.lerp(controlPoints[index2].y, controlPoints[index3].y, valueToClamp.x);
					float end6 = math.lerp(controlPoints[index6].y, controlPoints[index7].y, valueToClamp.x);
					float num3 = math.lerp(start6, end6, valueToClamp.z);
					zero.y = float5.y + num3;
				}
				else if (float5.y > 1f)
				{
					float start7 = math.lerp(controlPoints[index4].y, controlPoints[index5].y, valueToClamp.x);
					float end7 = math.lerp(controlPoints[index8].y, controlPoints[index9].y, valueToClamp.x);
					float num4 = math.lerp(start7, end7, valueToClamp.z);
					zero.y = float5.y + num4 - 1f;
				}
				else
				{
					float start8 = math.lerp(controlPoints[index2].y, controlPoints[index3].y, valueToClamp.x);
					float start9 = math.lerp(controlPoints[index4].y, controlPoints[index5].y, valueToClamp.x);
					float end8 = math.lerp(controlPoints[index6].y, controlPoints[index7].y, valueToClamp.x);
					float end9 = math.lerp(controlPoints[index8].y, controlPoints[index9].y, valueToClamp.x);
					float start10 = math.lerp(start8, end8, valueToClamp.z);
					float end10 = math.lerp(start9, end9, valueToClamp.z);
					zero.y = math.lerp(start10, end10, valueToClamp.y);
				}
				if (float5.z < 0f)
				{
					float start11 = math.lerp(controlPoints[index2].z, controlPoints[index3].z, valueToClamp.x);
					float end11 = math.lerp(controlPoints[index4].z, controlPoints[index5].z, valueToClamp.x);
					float num5 = math.lerp(start11, end11, valueToClamp.y);
					zero.z = float5.z + num5;
				}
				else if (float5.z > 1f)
				{
					float start12 = math.lerp(controlPoints[index6].z, controlPoints[index7].z, valueToClamp.x);
					float end12 = math.lerp(controlPoints[index8].z, controlPoints[index9].z, valueToClamp.x);
					float num6 = math.lerp(start12, end12, valueToClamp.y);
					zero.z = float5.z + num6 - 1f;
				}
				else
				{
					float start13 = math.lerp(controlPoints[index2].z, controlPoints[index3].z, valueToClamp.x);
					float start14 = math.lerp(controlPoints[index6].z, controlPoints[index7].z, valueToClamp.x);
					float end13 = math.lerp(controlPoints[index4].z, controlPoints[index5].z, valueToClamp.x);
					float end14 = math.lerp(controlPoints[index8].z, controlPoints[index9].z, valueToClamp.x);
					float start15 = math.lerp(start13, end13, valueToClamp.y);
					float end15 = math.lerp(start14, end14, valueToClamp.y);
					zero.z = math.lerp(start15, end15, valueToClamp.z);
				}
				vertices[index] = math.transform(targetToMesh, zero);
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LatticeJob_Hermite : IJobParallelFor
		{
			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<float3> controlPoints;

			[ReadOnly]
			public int3 resolution;

			[ReadOnly]
			public float4x4 meshToTarget;

			[ReadOnly]
			public float4x4 targetToMesh;

			public NativeArray<float3> vertices;

			private float hermite(float a, float b, float t)
			{
				return math.lerp(a, b, math.smoothstep(0f, 1f, t));
			}

			public void Execute(int index)
			{
				float3 float5 = math.transform(meshToTarget, vertices[index]) + math.float3(0.5f, 0.5f, 0.5f);
				int3 x = new int3((int)(float5.x * (float)(resolution.x - 1)), (int)(float5.y * (float)(resolution.y - 1)), (int)(float5.z * (float)(resolution.z - 1)));
				x = math.max(x, new int3(0, 0, 0));
				x = math.min(x, resolution - new int3(2, 2, 2));
				int index2 = x.x + x.y * resolution.x + x.z * (resolution.x * resolution.y);
				int index3 = x.x + 1 + x.y * resolution.x + x.z * (resolution.x * resolution.y);
				int index4 = x.x + (x.y + 1) * resolution.x + x.z * (resolution.x * resolution.y);
				int index5 = x.x + 1 + (x.y + 1) * resolution.x + x.z * (resolution.x * resolution.y);
				int index6 = x.x + x.y * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				int index7 = x.x + 1 + x.y * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				int index8 = x.x + (x.y + 1) * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				int index9 = x.x + 1 + (x.y + 1) * resolution.x + (x.z + 1) * (resolution.x * resolution.y);
				float3 valueToClamp = float5 * (resolution - new int3(1, 1, 1)) - x;
				valueToClamp = math.clamp(valueToClamp, float3.zero, new float3(1f, 1f, 1f));
				float3 zero = float3.zero;
				if (float5.x < 0f)
				{
					float start = math.lerp(controlPoints[index2].x, controlPoints[index4].x, valueToClamp.y);
					float end = math.lerp(controlPoints[index6].x, controlPoints[index8].x, valueToClamp.y);
					float num = math.lerp(start, end, valueToClamp.z);
					zero.x = float5.x + num;
				}
				else if (float5.x > 1f)
				{
					float start2 = math.lerp(controlPoints[index3].x, controlPoints[index5].x, valueToClamp.y);
					float end2 = math.lerp(controlPoints[index7].x, controlPoints[index9].x, valueToClamp.y);
					float num2 = math.lerp(start2, end2, valueToClamp.z);
					zero.x = float5.x + num2 - 1f;
				}
				else
				{
					float a = hermite(controlPoints[index2].x, controlPoints[index4].x, valueToClamp.y);
					float a2 = hermite(controlPoints[index3].x, controlPoints[index5].x, valueToClamp.y);
					float b = hermite(controlPoints[index6].x, controlPoints[index8].x, valueToClamp.y);
					float b2 = hermite(controlPoints[index7].x, controlPoints[index9].x, valueToClamp.y);
					float start3 = hermite(a, b, valueToClamp.z);
					float end3 = hermite(a2, b2, valueToClamp.z);
					zero.x = math.lerp(start3, end3, valueToClamp.x);
				}
				if (float5.y < 0f)
				{
					float a3 = hermite(controlPoints[index2].y, controlPoints[index3].y, valueToClamp.x);
					float b3 = hermite(controlPoints[index6].y, controlPoints[index7].y, valueToClamp.x);
					float num3 = hermite(a3, b3, valueToClamp.z);
					zero.y = float5.y + num3;
				}
				else if (float5.y > 1f)
				{
					float a4 = hermite(controlPoints[index4].y, controlPoints[index5].y, valueToClamp.x);
					float b4 = hermite(controlPoints[index8].y, controlPoints[index9].y, valueToClamp.x);
					float num4 = hermite(a4, b4, valueToClamp.z);
					zero.y = float5.y + num4 - 1f;
				}
				else
				{
					float a5 = hermite(controlPoints[index2].y, controlPoints[index3].y, valueToClamp.x);
					float a6 = hermite(controlPoints[index4].y, controlPoints[index5].y, valueToClamp.x);
					float b5 = hermite(controlPoints[index6].y, controlPoints[index7].y, valueToClamp.x);
					float b6 = hermite(controlPoints[index8].y, controlPoints[index9].y, valueToClamp.x);
					float start4 = hermite(a5, b5, valueToClamp.z);
					float end4 = hermite(a6, b6, valueToClamp.z);
					zero.y = math.lerp(start4, end4, valueToClamp.y);
				}
				if (float5.z < 0f)
				{
					float a7 = hermite(controlPoints[index2].z, controlPoints[index3].z, valueToClamp.x);
					float b7 = hermite(controlPoints[index4].z, controlPoints[index5].z, valueToClamp.x);
					float num5 = hermite(a7, b7, valueToClamp.y);
					zero.z = float5.z + num5;
				}
				else if (float5.z > 1f)
				{
					float a8 = hermite(controlPoints[index6].z, controlPoints[index7].z, valueToClamp.x);
					float b8 = hermite(controlPoints[index8].z, controlPoints[index9].z, valueToClamp.x);
					float num6 = hermite(a8, b8, valueToClamp.y);
					zero.z = float5.z + num6 - 1f;
				}
				else
				{
					float a9 = hermite(controlPoints[index2].z, controlPoints[index3].z, valueToClamp.x);
					float a10 = hermite(controlPoints[index6].z, controlPoints[index7].z, valueToClamp.x);
					float b9 = hermite(controlPoints[index4].z, controlPoints[index5].z, valueToClamp.x);
					float b10 = hermite(controlPoints[index8].z, controlPoints[index9].z, valueToClamp.x);
					float start5 = hermite(a9, b9, valueToClamp.y);
					float end5 = hermite(a10, b10, valueToClamp.y);
					zero.z = math.lerp(start5, end5, valueToClamp.z);
				}
				vertices[index] = math.transform(targetToMesh, zero);
			}
		}

		[SerializeField]
		[HideInInspector]
		private Transform target;

		[SerializeField]
		private float3[] controlPoints;

		[SerializeField]
		private InterpolationMode mode;

		[SerializeField]
		private Vector3Int resolution = new Vector3Int(2, 2, 2);

		public bool CanAutoFitBounds
		{
			get
			{
				if (base.transform.GetComponentInParent<Deformable>() != null)
				{
					return true;
				}
				LODGroup componentInParent = base.transform.GetComponentInParent<LODGroup>();
				if (componentInParent == null)
				{
					return false;
				}
				LOD[] lODs = componentInParent.GetLODs();
				if (lODs.Length != 0 && lODs[0].renderers.Length != 0 && lODs[0].renderers[0] != null && lODs[0].renderers[0].GetComponentInParent<Deformable>() != null)
				{
					return true;
				}
				return false;
			}
		}

		public float3[] ControlPoints => controlPoints;

		public Vector3Int Resolution => resolution;

		public override DataFlags DataFlags => DataFlags.Vertices;

		protected virtual void Reset()
		{
			GenerateControlPoints(resolution);
			FitBoundsToParentDeformable();
		}

		public void FitBoundsToParentDeformable()
		{
			Deformable deformable = base.transform.GetComponentInParent<Deformable>();
			if (deformable == null)
			{
				LOD[] lODs = base.transform.GetComponentInParent<LODGroup>().GetLODs();
				if (lODs.Length != 0 && lODs[0].renderers.Length != 0 && lODs[0].renderers[0] != null)
				{
					deformable = lODs[0].renderers[0].GetComponent<Deformable>();
				}
			}
			if (deformable != null)
			{
				Bounds bounds = deformable.GetCurrentMesh().bounds;
				Vector3 size = bounds.size;
				size.x = Mathf.Max(Mathf.Abs(size.x), 0.0001f) * Mathf.Sign(size.x);
				size.y = Mathf.Max(Mathf.Abs(size.y), 0.0001f) * Mathf.Sign(size.y);
				size.z = Mathf.Max(Mathf.Abs(size.z), 0.0001f) * Mathf.Sign(size.z);
				bounds.size = size;
				base.transform.localPosition = bounds.center;
				base.transform.localScale = bounds.size;
				base.transform.localRotation = Quaternion.identity;
			}
		}

		public void GenerateControlPoints(Vector3Int newResolution)
		{
			GenerateControlPoints(newResolution, null, Vector3Int.zero);
		}

		public void GenerateControlPoints(Vector3Int newResolution, float3[] resampleOriginalPoints, Vector3Int resampleOriginalResolution)
		{
			resolution = newResolution;
			controlPoints = new float3[resolution.x * resolution.y * resolution.z];
			for (int i = 0; i < resolution.z; i++)
			{
				for (int j = 0; j < resolution.y; j++)
				{
					for (int k = 0; k < resolution.x; k++)
					{
						int index = GetIndex(k, j, i);
						controlPoints[index] = new float3((float)k / (float)(newResolution.x - 1) - 0.5f, (float)j / (float)(newResolution.y - 1) - 0.5f, (float)i / (float)(newResolution.z - 1) - 0.5f);
					}
				}
			}
			if (resampleOriginalPoints != null)
			{
				NativeArray<float3> vertices = new NativeArray<float3>(controlPoints, Allocator.TempJob);
				IJobParallelForExtensions.Run(new LatticeJob
				{
					controlPoints = new NativeArray<float3>(resampleOriginalPoints, Allocator.TempJob),
					resolution = new int3(resampleOriginalResolution.x, resampleOriginalResolution.y, resampleOriginalResolution.z),
					meshToTarget = float4x4.identity,
					targetToMesh = float4x4.identity,
					vertices = vertices
				}, controlPoints.Length);
				resolution = newResolution;
				vertices.CopyTo(controlPoints);
				vertices.Dispose();
			}
		}

		public int GetIndex(int x, int y, int z)
		{
			return x + y * resolution.x + z * (resolution.x * resolution.y);
		}

		public int GetIndex(Vector3Int resolution, int x, int y, int z)
		{
			return x + y * resolution.x + z * (resolution.x * resolution.y);
		}

		public float3 GetControlPoint(int x, int y, int z)
		{
			int index = GetIndex(x, y, z);
			return controlPoints[index];
		}

		public void SetControlPoint(int x, int y, int z, float3 controlPoint)
		{
			int index = GetIndex(x, y, z);
			controlPoints[index] = controlPoint;
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(base.transform, data.Target.GetTransform());
			InterpolationMode interpolationMode = mode;
			if (interpolationMode == InterpolationMode.Linear || interpolationMode != InterpolationMode.Hermite)
			{
				return new LatticeJob
				{
					controlPoints = new NativeArray<float3>(controlPoints, Allocator.TempJob),
					resolution = new int3(resolution.x, resolution.y, resolution.z),
					meshToTarget = meshToAxisSpace,
					targetToMesh = meshToAxisSpace.inverse,
					vertices = data.DynamicNative.VertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new LatticeJob_Hermite
			{
				controlPoints = new NativeArray<float3>(controlPoints, Allocator.TempJob),
				resolution = new int3(resolution.x, resolution.y, resolution.z),
				meshToTarget = meshToAxisSpace,
				targetToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
