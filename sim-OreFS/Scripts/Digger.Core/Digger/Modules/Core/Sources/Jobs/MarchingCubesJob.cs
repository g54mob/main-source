using System;
using Digger.Modules.Core.Sources.NativeCollections;
using Digger.Modules.Core.Sources.Polygonizers;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct MarchingCubesJob : IJobParallelFor
	{
		private struct WorkNorm
		{
			public float3 N0;

			public float3 N1;

			public float3 N2;

			public float3 N3;

			public float3 N4;

			public float3 N5;

			public float3 N6;

			public float3 N7;
		}

		private struct WorkVert
		{
			public VertexData V0;

			public VertexData V1;

			public VertexData V2;

			public VertexData V3;

			public VertexData V4;

			public VertexData V5;

			public VertexData V6;

			public VertexData V7;

			public VertexData V8;

			public VertexData V9;

			public VertexData V10;

			public VertexData V11;

			public VertexData this[int i] => i switch
			{
				0 => V0, 
				1 => V1, 
				2 => V2, 
				3 => V3, 
				4 => V4, 
				5 => V5, 
				6 => V6, 
				7 => V7, 
				8 => V8, 
				9 => V9, 
				10 => V10, 
				11 => V11, 
				_ => default(VertexData), 
			};
		}

		public int SizeVox;

		public int SizeVox2;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		private NativeArray<int> edgeTable;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		private NativeArray<int> triTable;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		private NativeArray<float3> corners;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		private NativeArray<Voxel> voxels;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		private NativeArray<float> alphamaps;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		private NativeArray<float3> normals;

		private int2 alphamapsSize;

		private int3 localAlphamapsSize;

		private NativeCounter.Concurrent vertexCounter;

		[NativeDisableParallelForRestriction]
		public NativeArray<VertexData> outVertexData;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<ushort> outTriangles;

		private float3 chunkWorldPosition;

		private float3 scale;

		private float2 uvScale;

		private int2 alphamapOrigin;

		private int lod;

		private TerrainMaterialType materialType;

		public float Isovalue;

		public byte AlteredOnly;

		public byte FullOutput;

		public byte IsBuiltInHDRP;

		public byte IsLowPolyStyle;

		public MarchingCubesJob(NativeArray<int> edgeTable, NativeArray<int> triTable, NativeArray<float3> corners, NativeCounter.Concurrent vertexCounter, NativeArray<Voxel> voxels, NativeArray<float3> normals, NativeArray<float> alphamaps, PolyOut o, Vector3 scale, Vector2 uvScale, Vector3 chunkWorldPosition, int lod, int2 alphamapOrigin, int2 alphamapsSize, int3 localAlphamapsSize, TerrainMaterialType materialType)
		{
			this.edgeTable = edgeTable;
			this.triTable = triTable;
			this.corners = corners;
			this.vertexCounter = vertexCounter;
			this.voxels = voxels;
			this.normals = normals;
			this.alphamaps = alphamaps;
			outVertexData = o.outVertexData;
			outTriangles = o.outTriangles;
			SizeVox = 0;
			SizeVox2 = 0;
			Isovalue = 0f;
			AlteredOnly = 1;
			FullOutput = 1;
			this.scale = scale;
			this.lod = lod;
			this.alphamapsSize = alphamapsSize;
			this.localAlphamapsSize = localAlphamapsSize;
			this.uvScale = uvScale;
			this.alphamapOrigin = alphamapOrigin;
			this.chunkWorldPosition = chunkWorldPosition;
			this.materialType = materialType;
			IsBuiltInHDRP = 0;
			IsLowPolyStyle = 0;
		}

		private static Voxel GetProminentVoxel(Voxel vA, Voxel vB)
		{
			uint alteration = vA.Alteration;
			bool isIndestructible = vA.IsIndestructible;
			uint alteration2 = vB.Alteration;
			bool isIndestructible2 = vB.IsIndestructible;
			if (isIndestructible && !isIndestructible2)
			{
				return vA;
			}
			if (isIndestructible2 && !isIndestructible)
			{
				return vB;
			}
			if (alteration > alteration2)
			{
				return vA;
			}
			if (alteration < alteration2)
			{
				return vB;
			}
			if (!(math.abs(vA.Value) < math.abs(vB.Value)))
			{
				return vB;
			}
			return vA;
		}

		private float3 VertexInterp(float3 p1, float3 p2, Voxel vA, Voxel vB)
		{
			if (math.abs(Isovalue - vA.Value) < 0.0001f)
			{
				return p1;
			}
			if (math.abs(Isovalue - vB.Value) < 0.0001f)
			{
				return p2;
			}
			if (math.abs(vB.Value - vA.Value) < 0.0001f)
			{
				return p1;
			}
			float t = (Isovalue - vA.Value) / (vB.Value - vA.Value);
			return math.lerp(p1, p2, t);
		}

		private float3 ComputeNormalAt(int xi, int yi, int zi, float voxelOriginValue)
		{
			float3 float5 = new float3(voxels[(xi + 1) * SizeVox2 + yi * SizeVox + zi].Value - voxelOriginValue, voxels[xi * SizeVox2 + (yi + 1) * SizeVox + zi].Value - voxelOriginValue, voxels[xi * SizeVox2 + yi * SizeVox + (zi + 1)].Value - voxelOriginValue);
			if (math.all(math.abs(float5) < 0.0001f) && xi > 0 && yi > 0 && zi > 0)
			{
				float5 = new float3(voxelOriginValue - voxels[(xi - 1) * SizeVox2 + yi * SizeVox + zi].Value, voxelOriginValue - voxels[xi * SizeVox2 + (yi - 1) * SizeVox + zi].Value, voxelOriginValue - voxels[xi * SizeVox2 + yi * SizeVox + (zi - 1)].Value);
			}
			if (math.all(math.abs(float5) < 0.0001f))
			{
				return new float3(0f, 0f, 0f);
			}
			return float5;
		}

		private unsafe void ComputeUVsAndColor(int3 pi, VertexData* v, float3 vertexRelativePos, Voxel voxel)
		{
			uint alteration = voxel.Alteration;
			if (alteration == 0 || alteration == 1)
			{
				v->Normal = InterpolateNormal(pi.x, pi.z, vertexRelativePos.xz);
			}
			if (materialType == TerrainMaterialType.MicroSplat)
			{
				ComputeUVsAndColorForMicroSplat(v, voxel);
				return;
			}
			float2 uv = (v->UV = new float2((chunkWorldPosition.x + v->Vertex.x) * uvScale.x, (chunkWorldPosition.z + v->Vertex.z) * uvScale.y));
			if (alteration == 0 || alteration == 1)
			{
				v->SplatControl1 = GetControlAt(uv, 0);
				v->SplatControl2 = GetControlAt(uv, 1);
				v->SplatControl3 = GetControlAt(uv, 2);
				v->SplatControl4 = GetControlAt(uv, 3);
			}
			else
			{
				uint firstTextureIndex = voxel.FirstTextureIndex;
				uint secondTextureIndex = voxel.SecondTextureIndex;
				float normalizedTextureLerp = voxel.NormalizedTextureLerp;
				v->SplatControl1 = GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 0);
				v->SplatControl2 = GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 1);
				v->SplatControl3 = GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 2);
				v->SplatControl4 = GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 3);
			}
		}

		private unsafe void ComputeUVsAndColorForMicroSplat(VertexData* v, Voxel voxel)
		{
			float2 uv = (v->UV = new float2((chunkWorldPosition.x + v->Vertex.x) * uvScale.x, (chunkWorldPosition.z + v->Vertex.z) * uvScale.y));
			if (voxel.Alteration == 0 || voxel.Alteration == 1)
			{
				v->Color = new float4(EncodeToFloat(GetControlAt(uv, 0)), EncodeToFloat(GetControlAt(uv, 1)), EncodeToFloat(GetControlAt(uv, 2)), EncodeToFloat(GetControlAt(uv, 3)));
				v->SplatControl0 = new float4(0f, 0f, EncodeToFloat(GetControlAt(uv, 4)), EncodeToFloat(GetControlAt(uv, 5)));
				v->SplatControl1 = new float4(0f, 0f, EncodeToFloat(GetControlAt(uv, 6)), EncodeToFloat(GetControlAt(uv, 7)));
				return;
			}
			uint firstTextureIndex = voxel.FirstTextureIndex;
			uint secondTextureIndex = voxel.SecondTextureIndex;
			float normalizedTextureLerp = voxel.NormalizedTextureLerp;
			v->Color = new float4(EncodeToFloat(GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 0)), EncodeToFloat(GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 1)), EncodeToFloat(GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 2)), EncodeToFloat(GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 3)));
			v->SplatControl0 = new float4(0f, 0f, EncodeToFloat(GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 4)), EncodeToFloat(GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 5)));
			v->SplatControl1 = new float4(0f, 0f, EncodeToFloat(GetControlFor(firstTextureIndex, secondTextureIndex, normalizedTextureLerp, 6)), EncodeToFloat(new float4(voxel.NormalizedWetnessWeight, voxel.NormalizedPuddlesWeight, 0f, 0f)));
		}

		private float4 GetControlAt(float2 uv, int index)
		{
			float2 obj = new float2(uv.x * (float)(alphamapsSize.x - 1), uv.y * (float)(alphamapsSize.y - 1));
			int num = math.clamp(Convert.ToInt32(math.floor(obj.x)), 0, alphamapsSize.x - 2);
			int num2 = math.clamp(Convert.ToInt32(math.floor(obj.y)), 0, alphamapsSize.y - 2);
			float2 relPos = obj - new float2(num, num2);
			int x = math.clamp(num - alphamapOrigin.x, 0, localAlphamapsSize.x - 2);
			int z = math.clamp(num2 - alphamapOrigin.y, 0, localAlphamapsSize.y - 2);
			index *= 4;
			int z2 = localAlphamapsSize.z;
			float4 zero = float4.zero;
			if (index < z2)
			{
				zero[0] = InterpolateAlphamap(index, z2, x, z, 0, relPos);
			}
			if (index + 1 < z2)
			{
				zero[1] = InterpolateAlphamap(index, z2, x, z, 1, relPos);
			}
			if (index + 2 < z2)
			{
				zero[2] = InterpolateAlphamap(index, z2, x, z, 2, relPos);
			}
			if (index + 3 < z2)
			{
				zero[3] = InterpolateAlphamap(index, z2, x, z, 3, relPos);
			}
			return zero;
		}

		private float InterpolateAlphamap(int index, int mapCount, int x, int z, int i, float2 relPos)
		{
			float f = alphamaps[x * localAlphamapsSize.y * mapCount + z * mapCount + index + i];
			float f2 = alphamaps[(x + 1) * localAlphamapsSize.y * mapCount + z * mapCount + index + i];
			float f3 = alphamaps[x * localAlphamapsSize.y * mapCount + (z + 1) * mapCount + index + i];
			float f4 = alphamaps[(x + 1) * localAlphamapsSize.y * mapCount + (z + 1) * mapCount + index + i];
			return Utils.BilinearInterpolate(f, f2, f3, f4, relPos.y, relPos.x);
		}

		private float3 InterpolateNormal(int x, int z, float2 relPos)
		{
			if (relPos.x < 0f || relPos.x > 1f)
			{
				return new float3(1f, 0f, 0f);
			}
			if (relPos.y < 0f || relPos.y > 1f)
			{
				return new float3(0f, 0f, 1f);
			}
			float3 f = normals[Utils.XZToNormalIndex(x, z, SizeVox)];
			float3 f2 = normals[Utils.XZToNormalIndex(x + 1, z, SizeVox)];
			float3 f3 = normals[Utils.XZToNormalIndex(x, z + 1, SizeVox)];
			float3 f4 = normals[Utils.XZToNormalIndex(x + 1, z + 1, SizeVox)];
			return Utils.BilinearInterpolate(f, f2, f3, f4, relPos.y, relPos.x);
		}

		private static float4 GetControlFor(uint firstTextureIndex, uint secondTextureIndex, float lerp, int index)
		{
			float4 result = new float4(0f, 0f, 0f, 0f);
			if (index * 4 == firstTextureIndex)
			{
				result.x = 1f - lerp;
			}
			else if (index * 4 == secondTextureIndex)
			{
				result.x = lerp;
			}
			if (index * 4 + 1 == firstTextureIndex)
			{
				result.y = 1f - lerp;
			}
			else if (index * 4 + 1 == secondTextureIndex)
			{
				result.y = lerp;
			}
			if (index * 4 + 2 == firstTextureIndex)
			{
				result.z = 1f - lerp;
			}
			else if (index * 4 + 2 == secondTextureIndex)
			{
				result.z = lerp;
			}
			if (index * 4 + 3 == firstTextureIndex)
			{
				result.w = 1f - lerp;
			}
			else if (index * 4 + 3 == secondTextureIndex)
			{
				result.w = lerp;
			}
			return result;
		}

		private static float EncodeToFloat(float4 enc)
		{
			uint num = (uint)(enc.x * 255f);
			uint num2 = (uint)(enc.y * 255f);
			uint num3 = (uint)(enc.z * 255f);
			uint num4 = (uint)(enc.w * 255f);
			return (float)((num << 24) + (num2 << 16) + (num3 << 8) + num4) / 4.2949673E+09f;
		}

		public unsafe void Execute(int index)
		{
			int3 pi = Utils.IndexToXYZ(index, SizeVox, SizeVox2);
			if (pi.x >= SizeVox - lod - 1 || pi.y >= SizeVox - lod - 1 || pi.z >= SizeVox - lod - 1 || pi.x % lod != 0 || pi.y % lod != 0 || pi.z % lod != 0)
			{
				return;
			}
			Voxel voxel = voxels[pi.x * SizeVox * SizeVox + pi.y * SizeVox + pi.z];
			Voxel voxel2 = voxels[(pi.x + lod) * SizeVox * SizeVox + pi.y * SizeVox + pi.z];
			Voxel voxel3 = voxels[(pi.x + lod) * SizeVox * SizeVox + pi.y * SizeVox + (pi.z + lod)];
			Voxel voxel4 = voxels[pi.x * SizeVox * SizeVox + pi.y * SizeVox + (pi.z + lod)];
			Voxel voxel5 = voxels[pi.x * SizeVox * SizeVox + (pi.y + lod) * SizeVox + pi.z];
			Voxel voxel6 = voxels[(pi.x + lod) * SizeVox * SizeVox + (pi.y + lod) * SizeVox + pi.z];
			Voxel voxel7 = voxels[(pi.x + lod) * SizeVox * SizeVox + (pi.y + lod) * SizeVox + (pi.z + lod)];
			Voxel voxel8 = voxels[pi.x * SizeVox * SizeVox + (pi.y + lod) * SizeVox + (pi.z + lod)];
			uint alteration = voxel.Alteration;
			uint alteration2 = voxel2.Alteration;
			uint alteration3 = voxel3.Alteration;
			uint alteration4 = voxel4.Alteration;
			uint alteration5 = voxel5.Alteration;
			uint alteration6 = voxel6.Alteration;
			uint alteration7 = voxel7.Alteration;
			uint alteration8 = voxel8.Alteration;
			if (alteration == 6 || alteration2 == 6 || alteration3 == 6 || alteration4 == 6 || alteration5 == 6 || alteration6 == 6 || alteration7 == 6 || alteration8 == 6 || (AlteredOnly == 1 && alteration == 0 && alteration2 == 0 && alteration3 == 0 && alteration4 == 0 && alteration5 == 0 && alteration6 == 0 && alteration7 == 0 && alteration8 == 0))
			{
				return;
			}
			int num = 0;
			if (voxel.IsInside)
			{
				num |= 1;
			}
			if (voxel2.IsInside)
			{
				num |= 2;
			}
			if (voxel3.IsInside)
			{
				num |= 4;
			}
			if (voxel4.IsInside)
			{
				num |= 8;
			}
			if (voxel5.IsInside)
			{
				num |= 0x10;
			}
			if (voxel6.IsInside)
			{
				num |= 0x20;
			}
			if (voxel7.IsInside)
			{
				num |= 0x40;
			}
			if (voxel8.IsInside)
			{
				num |= 0x80;
			}
			if (num == 0 || num == 255)
			{
				return;
			}
			float3 float5 = new float3
			{
				x = pi.x,
				y = pi.y,
				z = pi.z
			};
			WorkNorm workNorm = new WorkNorm
			{
				N0 = ComputeNormalAt(pi.x, pi.y, pi.z, voxel.Value),
				N1 = ComputeNormalAt(pi.x + lod, pi.y, pi.z, voxel2.Value),
				N2 = ComputeNormalAt(pi.x + lod, pi.y, pi.z + lod, voxel3.Value),
				N3 = ComputeNormalAt(pi.x, pi.y, pi.z + lod, voxel4.Value),
				N4 = ComputeNormalAt(pi.x, pi.y + lod, pi.z, voxel5.Value),
				N5 = ComputeNormalAt(pi.x + lod, pi.y + lod, pi.z, voxel6.Value),
				N6 = ComputeNormalAt(pi.x + lod, pi.y + lod, pi.z + lod, voxel7.Value),
				N7 = ComputeNormalAt(pi.x, pi.y + lod, pi.z + lod, voxel8.Value)
			};
			WorkVert wVert = default(WorkVert);
			if ((edgeTable[num] & 1) != 0)
			{
				float3 normal = VertexInterp(workNorm.N0, workNorm.N1, voxel, voxel2);
				float3 float6 = VertexInterp(corners[0], corners[1], voxel, voxel2);
				wVert.V0 = new VertexData
				{
					Vertex = scale * (float5 + float6 * lod),
					Normal = normal
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel = GetProminentVoxel(voxel, voxel2);
					ComputeUVsAndColor(pi, &wVert.V0, float6, prominentVoxel);
				}
			}
			if ((edgeTable[num] & 2) != 0)
			{
				float3 normal2 = VertexInterp(workNorm.N1, workNorm.N2, voxel2, voxel3);
				float3 float7 = VertexInterp(corners[1], corners[2], voxel2, voxel3);
				wVert.V1 = new VertexData
				{
					Vertex = scale * (float5 + float7 * lod),
					Normal = normal2
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel2 = GetProminentVoxel(voxel2, voxel3);
					ComputeUVsAndColor(pi, &wVert.V1, float7, prominentVoxel2);
				}
			}
			if ((edgeTable[num] & 4) != 0)
			{
				float3 normal3 = VertexInterp(workNorm.N2, workNorm.N3, voxel3, voxel4);
				float3 float8 = VertexInterp(corners[2], corners[3], voxel3, voxel4);
				wVert.V2 = new VertexData
				{
					Vertex = scale * (float5 + float8 * lod),
					Normal = normal3
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel3 = GetProminentVoxel(voxel3, voxel4);
					ComputeUVsAndColor(pi, &wVert.V2, float8, prominentVoxel3);
				}
			}
			if ((edgeTable[num] & 8) != 0)
			{
				float3 normal4 = VertexInterp(workNorm.N3, workNorm.N0, voxel4, voxel);
				float3 float9 = VertexInterp(corners[3], corners[0], voxel4, voxel);
				wVert.V3 = new VertexData
				{
					Vertex = scale * (float5 + float9 * lod),
					Normal = normal4
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel4 = GetProminentVoxel(voxel4, voxel);
					ComputeUVsAndColor(pi, &wVert.V3, float9, prominentVoxel4);
				}
			}
			if ((edgeTable[num] & 0x10) != 0)
			{
				float3 normal5 = VertexInterp(workNorm.N4, workNorm.N5, voxel5, voxel6);
				float3 float10 = VertexInterp(corners[4], corners[5], voxel5, voxel6);
				wVert.V4 = new VertexData
				{
					Vertex = scale * (float5 + float10 * lod),
					Normal = normal5
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel5 = GetProminentVoxel(voxel5, voxel6);
					ComputeUVsAndColor(pi, &wVert.V4, float10, prominentVoxel5);
				}
			}
			if ((edgeTable[num] & 0x20) != 0)
			{
				float3 normal6 = VertexInterp(workNorm.N5, workNorm.N6, voxel6, voxel7);
				float3 float11 = VertexInterp(corners[5], corners[6], voxel6, voxel7);
				wVert.V5 = new VertexData
				{
					Vertex = scale * (float5 + float11 * lod),
					Normal = normal6
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel6 = GetProminentVoxel(voxel6, voxel7);
					ComputeUVsAndColor(pi, &wVert.V5, float11, prominentVoxel6);
				}
			}
			if ((edgeTable[num] & 0x40) != 0)
			{
				float3 normal7 = VertexInterp(workNorm.N6, workNorm.N7, voxel7, voxel8);
				float3 float12 = VertexInterp(corners[6], corners[7], voxel7, voxel8);
				wVert.V6 = new VertexData
				{
					Vertex = scale * (float5 + float12 * lod),
					Normal = normal7
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel7 = GetProminentVoxel(voxel7, voxel8);
					ComputeUVsAndColor(pi, &wVert.V6, float12, prominentVoxel7);
				}
			}
			if ((edgeTable[num] & 0x80) != 0)
			{
				float3 normal8 = VertexInterp(workNorm.N7, workNorm.N4, voxel8, voxel5);
				float3 float13 = VertexInterp(corners[7], corners[4], voxel8, voxel5);
				wVert.V7 = new VertexData
				{
					Vertex = scale * (float5 + float13 * lod),
					Normal = normal8
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel8 = GetProminentVoxel(voxel8, voxel5);
					ComputeUVsAndColor(pi, &wVert.V7, float13, prominentVoxel8);
				}
			}
			if ((edgeTable[num] & 0x100) != 0)
			{
				float3 normal9 = VertexInterp(workNorm.N0, workNorm.N4, voxel, voxel5);
				float3 float14 = VertexInterp(corners[0], corners[4], voxel, voxel5);
				wVert.V8 = new VertexData
				{
					Vertex = scale * (float5 + float14 * lod),
					Normal = normal9
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel9 = GetProminentVoxel(voxel, voxel5);
					ComputeUVsAndColor(pi, &wVert.V8, float14, prominentVoxel9);
				}
			}
			if ((edgeTable[num] & 0x200) != 0)
			{
				float3 normal10 = VertexInterp(workNorm.N1, workNorm.N5, voxel2, voxel6);
				float3 float15 = VertexInterp(corners[1], corners[5], voxel2, voxel6);
				wVert.V9 = new VertexData
				{
					Vertex = scale * (float5 + float15 * lod),
					Normal = normal10
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel10 = GetProminentVoxel(voxel2, voxel6);
					ComputeUVsAndColor(pi, &wVert.V9, float15, prominentVoxel10);
				}
			}
			if ((edgeTable[num] & 0x400) != 0)
			{
				float3 normal11 = VertexInterp(workNorm.N2, workNorm.N6, voxel3, voxel7);
				float3 float16 = VertexInterp(corners[2], corners[6], voxel3, voxel7);
				wVert.V10 = new VertexData
				{
					Vertex = scale * (float5 + float16 * lod),
					Normal = normal11
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel11 = GetProminentVoxel(voxel3, voxel7);
					ComputeUVsAndColor(pi, &wVert.V10, float16, prominentVoxel11);
				}
			}
			if ((edgeTable[num] & 0x800) != 0)
			{
				float3 normal12 = VertexInterp(workNorm.N3, workNorm.N7, voxel4, voxel8);
				float3 float17 = VertexInterp(corners[3], corners[7], voxel4, voxel8);
				wVert.V11 = new VertexData
				{
					Vertex = scale * (float5 + float17 * lod),
					Normal = normal12
				};
				if (FullOutput == 1)
				{
					Voxel prominentVoxel12 = GetProminentVoxel(voxel4, voxel8);
					ComputeUVsAndColor(pi, &wVert.V11, float17, prominentVoxel12);
				}
			}
			if (triTable[num * 16] != -1 && AddTriangle(0, num, ref wVert) && triTable[num * 16 + 3] != -1 && AddTriangle(3, num, ref wVert) && triTable[num * 16 + 6] != -1 && AddTriangle(6, num, ref wVert) && triTable[num * 16 + 9] != -1 && AddTriangle(9, num, ref wVert) && triTable[num * 16 + 12] != -1)
			{
				AddTriangle(12, num, ref wVert);
			}
		}

		private bool AddTriangle(int i, int cubeindex, ref WorkVert wVert)
		{
			int i2 = triTable[cubeindex * 16 + i];
			int i3 = triTable[cubeindex * 16 + (i + 1)];
			int i4 = triTable[cubeindex * 16 + (i + 2)];
			VertexData value = wVert[i2];
			VertexData value2 = wVert[i3];
			VertexData value3 = wVert[i4];
			float3 vertex = value.Vertex;
			float3 vertex2 = value2.Vertex;
			float3 vertex3 = value3.Vertex;
			if (Utils.Approximately(vertex, vertex2) || Utils.Approximately(vertex2, vertex3) || Utils.Approximately(vertex, vertex3) || Utils.AreColinear(vertex, vertex2, vertex3))
			{
				return true;
			}
			int num = vertexCounter.Increment() - 3;
			if (num + 2 >= 65536)
			{
				return false;
			}
			if (materialType == TerrainMaterialType.Standard || materialType == TerrainMaterialType.URP || materialType == TerrainMaterialType.HDRP)
			{
				value.Color = new float4(1f, 0f, 0f, 0f);
				value2.Color = new float4(0f, 1f, 0f, 0f);
				value3.Color = new float4(0f, 0f, 1f, 0f);
			}
			if (IsLowPolyStyle == 1)
			{
				value3.Normal = (value2.Normal = (value.Normal = math.normalize(math.cross(vertex2 - vertex, vertex3 - vertex))));
			}
			else
			{
				float3 float5 = ((!math.all(value.Normal == float3.zero)) ? math.normalize(value.Normal) : (math.all(value2.Normal == float3.zero) ? math.normalize(value3.Normal) : math.normalize(value2.Normal)));
				value.Normal = (math.all(value.Normal == float3.zero) ? float5 : math.normalize(value.Normal));
				value2.Normal = (math.all(value2.Normal == float3.zero) ? float5 : math.normalize(value2.Normal));
				value3.Normal = (math.all(value3.Normal == float3.zero) ? float5 : math.normalize(value3.Normal));
			}
			outVertexData[num] = value;
			outVertexData[num + 1] = value2;
			outVertexData[num + 2] = value3;
			outTriangles[num] = (ushort)num;
			outTriangles[num + 1] = (ushort)(num + 1);
			outTriangles[num + 2] = (ushort)(num + 2);
			return true;
		}
	}
}
