using Beans.Unity.Collections;
using Beans.Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[Deformer(Name = "Texture Displace", Description = "Displaces mesh based off a texture", Type = typeof(TextureDisplaceDeformer), XRotation = -90f)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/TextureDisplaceDeformer")]
	public class TextureDisplaceDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct WorldTextureDisplaceJob : IJobParallelFor
		{
			public float factor;

			public bool repeat;

			public int channel;

			public float2 offset;

			public float2 tiling;

			public float3 direction;

			public float4x4 meshToAxis;

			public NativeArray<float3> vertices;

			[ReadOnly]
			public NativeArray<float3> normals;

			[ReadOnly]
			public NativeTexture2D texture;

			public void Execute(int index)
			{
				float4 float5 = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				int2 int5 = math.int2(texture.width, texture.height);
				int2 int6 = (int2)((float5.xy + offset) * tiling * int5);
				int6 += int5 / 2;
				if (repeat)
				{
					int6 = mathx.repeat(int6, int5);
				}
				else if (OutsideTexture(int6, int5))
				{
					return;
				}
				Color32 pixel = texture.GetPixel(int6.x, int6.y);
				float4 float6 = math.float4((float)(int)pixel.r * 0.003921569f, (float)(int)pixel.g * 0.003921569f, (float)(int)pixel.b * 0.003921569f, (float)(int)pixel.a * 0.003921569f);
				vertices[index] += direction * (float6[channel] * factor);
			}

			private bool OutsideTexture(int2 p, int2 size)
			{
				if (p.x >= 0 && p.y >= 0 && p.x < size.x)
				{
					return p.y >= size.y;
				}
				return true;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct WorldTextureDisplaceBilinearJob : IJobParallelFor
		{
			public float factor;

			public bool repeat;

			public int channel;

			public float2 offset;

			public float2 tiling;

			public float3 direction;

			public float4x4 meshToAxis;

			public NativeArray<float3> vertices;

			[ReadOnly]
			public NativeArray<float3> normals;

			[ReadOnly]
			public NativeTexture2D texture;

			public void Execute(int index)
			{
				float4 float5 = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				int2 int5 = math.int2(texture.width, texture.height);
				float2 p = (float5.xy + offset) * tiling * int5;
				p += (float2)(int5 / 2);
				p /= (float2)int5;
				if (repeat || !OutsideTexture(p))
				{
					Color32 pixelBilinear = texture.GetPixelBilinear(p.x, p.y);
					float4 float6 = math.float4((float)(int)pixelBilinear.r * 0.003921569f, (float)(int)pixelBilinear.g * 0.003921569f, (float)(int)pixelBilinear.b * 0.003921569f, (float)(int)pixelBilinear.a * 0.003921569f);
					vertices[index] += direction * (float6[channel] * factor);
				}
			}

			private bool OutsideTexture(float2 p)
			{
				if (!(p.x < 0f) && !(p.y < 0f) && !(p.x > 1f))
				{
					return p.y > 1f;
				}
				return true;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct UVTextureDisplaceJob : IJobParallelFor
		{
			public float factor;

			public bool repeat;

			public int channel;

			public float2 offset;

			public float2 tiling;

			public NativeArray<float3> vertices;

			[ReadOnly]
			public NativeArray<float3> normals;

			[ReadOnly]
			public NativeArray<float2> uvs;

			[ReadOnly]
			public NativeTexture2D texture;

			public void Execute(int index)
			{
				float2 obj = uvs[index];
				int2 int5 = math.int2(texture.width, texture.height);
				int2 int6 = (int2)((obj + offset) * tiling * int5);
				if (repeat)
				{
					int6 = mathx.repeat(int6, int5);
				}
				else if (OutsideTexture(int6, int5))
				{
					return;
				}
				Color32 pixel = texture.GetPixel(int6.x, int6.y);
				float4 float5 = math.float4((float)(int)pixel.r * 0.003921569f, (float)(int)pixel.g * 0.003921569f, (float)(int)pixel.b * 0.003921569f, (float)(int)pixel.a * 0.003921569f);
				vertices[index] += normals[index] * (float5[channel] * factor);
			}

			private bool OutsideTexture(int2 p, int2 size)
			{
				if (p.x >= 0 && p.y >= 0 && p.x < size.x)
				{
					return p.y >= size.y;
				}
				return true;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct UVTextureDisplaceBilinearJob : IJobParallelFor
		{
			public float factor;

			public bool repeat;

			public int channel;

			public float2 offset;

			public float2 tiling;

			public NativeArray<float3> vertices;

			[ReadOnly]
			public NativeArray<float3> normals;

			[ReadOnly]
			public NativeArray<float2> uvs;

			[ReadOnly]
			public NativeTexture2D texture;

			public void Execute(int index)
			{
				float2 p = (uvs[index] + offset) * tiling;
				if (repeat || !OutsideTexture(p))
				{
					Color32 pixelBilinear = texture.GetPixelBilinear(p.x, p.y);
					float4 float5 = math.float4((float)(int)pixelBilinear.r * 0.003921569f, (float)(int)pixelBilinear.g * 0.003921569f, (float)(int)pixelBilinear.b * 0.003921569f, (float)(int)pixelBilinear.a * 0.003921569f);
					vertices[index] += normals[index] * (float5[channel] * factor);
				}
			}

			private bool OutsideTexture(float2 p)
			{
				if (!(p.x < 0f) && !(p.y < 0f) && !(p.x > 1f))
				{
					return p.y > 1f;
				}
				return true;
			}
		}

		private const float _1OVER255 = 0.003921569f;

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private TextureSampleSpace space;

		[SerializeField]
		[HideInInspector]
		private ColorChannel channel;

		[SerializeField]
		[HideInInspector]
		private bool repeat;

		[SerializeField]
		[HideInInspector]
		private bool bilinear;

		[SerializeField]
		[HideInInspector]
		private Vector2 offset = Vector2.zero;

		[SerializeField]
		[HideInInspector]
		private Vector2 tiling = Vector2.one;

		[SerializeField]
		[HideInInspector]
		private Texture2D texture;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		private JobHandle handle;

		private Color32[] managedPixels;

		private NativeTexture2D nativeTexture;

		private bool textureDirty;

		public float Factor
		{
			get
			{
				return factor;
			}
			set
			{
				factor = value;
			}
		}

		public bool Repeat
		{
			get
			{
				return repeat;
			}
			set
			{
				repeat = value;
			}
		}

		public bool Bilinear
		{
			get
			{
				return bilinear;
			}
			set
			{
				bilinear = value;
			}
		}

		public TextureSampleSpace Space
		{
			get
			{
				return space;
			}
			set
			{
				space = value;
			}
		}

		public ColorChannel Channel
		{
			get
			{
				return channel;
			}
			set
			{
				channel = value;
			}
		}

		public Vector2 Offset
		{
			get
			{
				return offset;
			}
			set
			{
				offset = value;
			}
		}

		public Vector2 Tiling
		{
			get
			{
				return tiling;
			}
			set
			{
				tiling = value;
			}
		}

		public Texture2D Texture
		{
			get
			{
				return texture;
			}
			set
			{
				if (value != null)
				{
					texture = value;
					textureDirty = true;
				}
			}
		}

		public Transform Axis
		{
			get
			{
				if (axis == null)
				{
					axis = base.transform;
				}
				return axis;
			}
			set
			{
				axis = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		private void OnEnable()
		{
			textureDirty = true;
		}

		private void OnDisable()
		{
			handle.Complete();
			if (nativeTexture.IsCreated)
			{
				nativeTexture.Dispose();
			}
		}

		public void MarkTextureDataDirty()
		{
			textureDirty = true;
		}

		public void ForceUpdateNativeData()
		{
			if (Texture != null && Texture.isReadable)
			{
				managedPixels = texture.GetPixels32();
				nativeTexture.Update(managedPixels, texture.width, texture.height);
			}
			else if (nativeTexture.IsCreated)
			{
				nativeTexture.Dispose();
			}
			textureDirty = false;
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (textureDirty)
			{
				ForceUpdateNativeData();
			}
			if (Mathf.Approximately(Factor, 0f) || Texture == null || !nativeTexture.IsCreated)
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			JobHandle jobHandle = ((Space != TextureSampleSpace.UV) ? (Bilinear ? new WorldTextureDisplaceBilinearJob
			{
				factor = Factor,
				repeat = Repeat,
				channel = (int)Channel,
				offset = Offset,
				tiling = Tiling,
				direction = Quaternion.Inverse(data.Target.GetTransform().rotation) * Axis.forward,
				meshToAxis = meshToAxisSpace,
				texture = nativeTexture,
				vertices = data.DynamicNative.VertexBuffer,
				normals = data.DynamicNative.NormalBuffer
			}.Schedule(data.Length, 32, dependency) : new WorldTextureDisplaceJob
			{
				factor = Factor,
				repeat = Repeat,
				channel = (int)Channel,
				offset = Offset,
				tiling = Tiling,
				direction = Quaternion.Inverse(data.Target.GetTransform().rotation) * Axis.forward,
				meshToAxis = meshToAxisSpace,
				texture = nativeTexture,
				vertices = data.DynamicNative.VertexBuffer,
				normals = data.DynamicNative.NormalBuffer
			}.Schedule(data.Length, 32, dependency)) : (Bilinear ? new UVTextureDisplaceBilinearJob
			{
				factor = Factor,
				repeat = Repeat,
				channel = (int)Channel,
				offset = Offset,
				tiling = Tiling,
				texture = nativeTexture,
				uvs = data.DynamicNative.UVBuffer,
				vertices = data.DynamicNative.VertexBuffer,
				normals = data.DynamicNative.NormalBuffer
			}.Schedule(data.Length, 32, dependency) : new UVTextureDisplaceJob
			{
				factor = Factor,
				repeat = Repeat,
				channel = (int)Channel,
				offset = Offset,
				tiling = Tiling,
				texture = nativeTexture,
				uvs = data.DynamicNative.UVBuffer,
				vertices = data.DynamicNative.VertexBuffer,
				normals = data.DynamicNative.NormalBuffer
			}.Schedule(data.Length, 32, dependency)));
			handle = JobHandle.CombineDependencies(handle, jobHandle);
			return jobHandle;
		}
	}
}
