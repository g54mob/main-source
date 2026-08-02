using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

namespace CritiasFoliage
{
	public class FoliageRenderer : MonoBehaviour
	{
		private struct FoliageRendererStats
		{
			public int m_ProcessedCells;

			public int m_ProcessedInstances;

			public int m_ProcessedDrawCalls;

			public int m_ProcessedCellsSubdiv;

			public void Reset()
			{
				m_ProcessedCells = 0;
				m_ProcessedCellsSubdiv = 0;
				m_ProcessedInstances = 0;
				m_ProcessedDrawCalls = 0;
			}
		}

		private class GPUBufferCellCachedData : IDisposable
		{
			public ComputeBuffer m_BufferPositions;

			public ComputeBuffer m_BufferArguments;

			public uint m_IndexCount;

			public uint m_InstanceCount;

			public void Dispose()
			{
				if (m_BufferPositions != null)
				{
					m_BufferPositions.Release();
					m_BufferPositions = null;
				}
				if (m_BufferArguments != null)
				{
					m_BufferArguments.Release();
					m_BufferArguments = null;
				}
			}
		}

		public FoliageRenderSettings m_Settings;

		private FoliageDataRuntime m_FoliageData;

		private Dictionary<int, FoliageType> m_FoliageTypes = new Dictionary<int, FoliageType>();

		private FoliageType[] m_FoliageTypesArray;

		private float m_MaxDistanceGrass;

		private float m_MaxDistanceGrassSqr;

		private float m_MaxDistanceTree;

		private float m_MaxDistanceTreeSqr;

		private float m_MaxDistanceAll;

		private float m_MaxDistanceAllSqr;

		private int m_CellNeighborCount;

		private int m_ShaderIDCritiasFoliageDistance;

		private int m_ShaderIDCritiasFoliageDistanceSqr;

		private int m_ShaderIDCritiasFoliageLOD;

		private int m_ShaderIDCritiasFoliageLODSqr;

		private int m_ShaderIDCritiasInstanceBuffer;

		private int m_ShaderIDCritiasBendPosition;

		private int m_ShaderIDCritiasBendDistance;

		private int m_ShaderIDCritiasBendScale;

		private Action<Plane[], Matrix4x4> ExtractPlanes;

		private Plane[] m_CameraPlanes = new Plane[6];

		private FoliageCell currentCell;

		private FoliageRendererStats m_DrawStats;

		private Camera m_CurrentFrameCameraCull;

		private Camera m_CurrentFrameCameraDraw;

		private Vector3 m_CurrentFrameCameraPosition;

		private int m_CurrentFrameLayer;

		private bool m_CurrentFrameAllowIndirect;

		private Vector3 m_CurrentFrameBendPosition;

		private Matrix4x4[][] m_MtxLODTemp;

		private int[] m_MtxLODTempCount = new int[6];

		private Matrix4x4[][] m_MtxLODTempShadow;

		private int[] m_MtxLODTempShadowCount = new int[6];

		private FoliageDisposableCache<long, GPUBufferCellCachedData> m_CachedGPUBufferData = new FoliageDisposableCache<long, GPUBufferCellCachedData>(1250, 125);

		private uint[] m_TempDrawArgs = new uint[5];

		private void Awake()
		{
			MethodInfo method = typeof(GeometryUtility).GetMethod("Internal_ExtractPlanes", BindingFlags.Static | BindingFlags.NonPublic, null, new Type[2]
			{
				typeof(Plane[]),
				typeof(Matrix4x4)
			}, null);
			ExtractPlanes = Delegate.CreateDelegate(typeof(Action<Plane[], Matrix4x4>), method) as Action<Plane[], Matrix4x4>;
			m_MtxLODTemp = new Matrix4x4[6][];
			m_MtxLODTempShadow = new Matrix4x4[1000][];
			for (int i = 0; i < 6; i++)
			{
				m_MtxLODTemp[i] = new Matrix4x4[1000];
				m_MtxLODTempShadow[i] = new Matrix4x4[1000];
				for (int j = 0; j < 1000; j++)
				{
					m_MtxLODTemp[i][j] = Matrix4x4.identity;
					m_MtxLODTempShadow[i][j] = Matrix4x4.identity;
				}
			}
			if (!m_Settings.m_WindTransform)
			{
				m_Settings.m_WindTransform = Camera.main.transform;
			}
			if (!m_Settings.m_UsedCameraCulling)
			{
				m_Settings.m_UsedCameraCulling = Camera.main;
			}
			m_ShaderIDCritiasFoliageDistance = Shader.PropertyToID("CRITIAS_MaxFoliageTypeDistance");
			m_ShaderIDCritiasFoliageDistanceSqr = Shader.PropertyToID("CRITIAS_MaxFoliageTypeDistanceSqr");
			m_ShaderIDCritiasFoliageLOD = Shader.PropertyToID("CRITIAS_FoliageMaxDistanceLOD");
			m_ShaderIDCritiasFoliageLODSqr = Shader.PropertyToID("CRITIAS_FoliageMaxDistanceLODSqr");
			m_ShaderIDCritiasInstanceBuffer = Shader.PropertyToID("CRITIAS_InstancePositionBuffer");
			m_ShaderIDCritiasBendPosition = Shader.PropertyToID("CRITIAS_Bend_Position");
			m_ShaderIDCritiasBendDistance = Shader.PropertyToID("CRITIAS_Bend_Distance");
			m_ShaderIDCritiasBendScale = Shader.PropertyToID("CRITIAS_Bend_Scale");
		}

		public void InitRenderer(FoliagePainter painter, FoliageDataRuntime dataToRender, List<FoliageType> foliageTypes)
		{
			m_FoliageData = dataToRender;
			foreach (FoliageType foliageType in foliageTypes)
			{
				FoliageTypeUtilities.BuildDataRuntime(painter, foliageType, m_Settings.m_WindTransform);
			}
			UpdateFoliageTypes(foliageTypes);
		}

		public void UpdateFoliageTypes(List<FoliageType> foliageTypes)
		{
			m_MaxDistanceGrass = 0f;
			m_MaxDistanceTree = 0f;
			m_MaxDistanceAll = 0f;
			m_FoliageTypes.Clear();
			foreach (FoliageType foliageType in foliageTypes)
			{
				if (foliageType.IsGrassType && foliageType.m_RenderInfo.m_MaxDistance > m_MaxDistanceGrass)
				{
					m_MaxDistanceGrass = foliageType.m_RenderInfo.m_MaxDistance;
				}
				else if (!foliageType.IsGrassType && foliageType.m_RenderInfo.m_MaxDistance > m_MaxDistanceTree)
				{
					m_MaxDistanceTree = foliageType.m_RenderInfo.m_MaxDistance;
				}
				m_FoliageTypes.Add(foliageType.m_Hash, foliageType);
			}
			m_FoliageTypesArray = foliageTypes.ToArray();
			m_MaxDistanceGrass = Mathf.Clamp(m_MaxDistanceGrass, 0f, 500f);
			m_MaxDistanceGrassSqr = m_MaxDistanceGrass * m_MaxDistanceGrass;
			m_MaxDistanceTree = Mathf.Clamp(m_MaxDistanceTree, 0f, 1000f);
			m_MaxDistanceTreeSqr = m_MaxDistanceTree * m_MaxDistanceTree;
			m_MaxDistanceAll = Mathf.Max(m_MaxDistanceGrass, m_MaxDistanceTree);
			m_MaxDistanceAllSqr = m_MaxDistanceAll * m_MaxDistanceAll;
			m_CellNeighborCount = Mathf.CeilToInt(m_MaxDistanceAll / 100f);
		}

		private void Update()
		{
			m_CurrentFrameCameraCull = m_Settings.m_UsedCameraCulling;
			m_CurrentFrameCameraDraw = m_Settings.m_UsedCameraDrawing;
			m_CurrentFrameLayer = LayerMask.NameToLayer(m_Settings.m_UsedLayer);
			ExtractPlanes(m_CameraPlanes, m_CurrentFrameCameraCull.projectionMatrix * m_CurrentFrameCameraCull.worldToCameraMatrix);
			m_CurrentFrameCameraPosition = m_CurrentFrameCameraCull.transform.position;
			m_CurrentFrameBendPosition = ((m_Settings.m_BendTransform != null) ? m_Settings.m_BendTransform.position : m_CurrentFrameCameraPosition);
			currentCell.Set(m_CurrentFrameCameraPosition);
			m_CurrentFrameAllowIndirect = m_Settings.m_AllowDrawInstancedIndirect;
			m_DrawStats.Reset();
			for (int i = 0; i < m_FoliageTypesArray.Length; i++)
			{
				if (m_FoliageTypesArray[i].IsSpeedTreeType)
				{
					m_FoliageTypesArray[i].CopyBlock();
				}
			}
			bool applyShadowCorrection = m_Settings.m_ApplyShadowPoppingCorrection;
			float shadowCorrectionDistanceSqr = m_Settings.m_ShadowPoppingCorrection * m_Settings.m_ShadowPoppingCorrection;
			FoliageCell.IterateNeighboring(currentCell, m_CellNeighborCount, delegate(int hash)
			{
				if (m_FoliageData.m_FoliageData.TryGetValue(hash, out var value))
				{
					float num = value.m_Bounds.SqrDistance(m_CurrentFrameCameraPosition);
					if (num <= m_MaxDistanceAllSqr && GeometryUtility.TestPlanesAABB(m_CameraPlanes, value.m_Bounds))
					{
						if (num <= m_MaxDistanceTreeSqr)
						{
							ProcessCellTree(value, num, applyShadowCorrection, shadowCorrectionDistanceSqr, shadowOnly: false);
						}
						if (num <= m_MaxDistanceGrassSqr && m_Settings.m_DrawInstanced)
						{
							ProcessCellGrass(value);
						}
						m_DrawStats.m_ProcessedCells++;
					}
					else if (num <= shadowCorrectionDistanceSqr)
					{
						ProcessCellTree(value, num, applyShadowCorrection, shadowCorrectionDistanceSqr, shadowOnly: true);
					}
				}
			});
		}

		private void OnDisable()
		{
			m_CachedGPUBufferData.Dispose();
		}

		private void ProcessCellGrass(FoliageCellDataRuntime runtimeCell)
		{
			int i = 0;
			for (int num = runtimeCell.m_FoliageDataSubdivided.Length; i < num; i++)
			{
				FoliageCellSubdividedDataRuntime value = runtimeCell.m_FoliageDataSubdivided[i].Value;
				float num2 = value.m_Bounds.SqrDistance(m_CurrentFrameCameraPosition);
				if (num2 <= m_MaxDistanceGrassSqr && GeometryUtility.TestPlanesAABB(m_CameraPlanes, value.m_Bounds))
				{
					ProcessSubdividedCell(runtimeCell, value, num2);
					m_DrawStats.m_ProcessedCellsSubdiv++;
				}
			}
		}

		private void ProcessCellTree(FoliageCellDataRuntime cell, float distanceSqr, bool shadowCorrection, float shadowCorrectionDistanceSqr, bool shadowOnly)
		{
			int i = 0;
			for (int num = cell.m_TypeHashLocationsRuntime.Length; i < num; i++)
			{
				FoliageType foliageType = m_FoliageTypes[cell.m_TypeHashLocationsRuntime[i].Key];
				FoliageInstance[] editTime = cell.m_TypeHashLocationsRuntime[i].Value.m_EditTime;
				float maxDistance = foliageType.m_RenderInfo.m_MaxDistance;
				float num2 = maxDistance * maxDistance;
				MaterialPropertyBlock typeMPB = foliageType.m_RuntimeData.m_TypeMPB;
				typeMPB.SetFloat(m_ShaderIDCritiasFoliageDistance, maxDistance);
				typeMPB.SetFloat(m_ShaderIDCritiasFoliageDistanceSqr, num2);
				FoliageTypeLODTree[] treeLods = foliageType.m_RuntimeData.m_LODDataTree;
				bool castShadow = foliageType.m_RenderInfo.m_CastShadow;
				ShadowCastingMode shadow = (castShadow ? ShadowCastingMode.On : ShadowCastingMode.Off);
				for (int j = 0; j < m_MtxLODTempCount.Length; j++)
				{
					m_MtxLODTempCount[j] = 0;
					m_MtxLODTempShadowCount[j] = 0;
				}
				int k = 0;
				for (int num3 = editTime.Length; k < num3; k++)
				{
					Vector3 position = editTime[k].m_Position;
					float num4 = position.x - m_CurrentFrameCameraPosition.x;
					float num5 = position.y - m_CurrentFrameCameraPosition.y;
					float num6 = position.z - m_CurrentFrameCameraPosition.z;
					float num7 = num4 * num4 + num5 * num5 + num6 * num6;
					if (num7 <= num2 && GeometryUtility.TestPlanesAABB(m_CameraPlanes, editTime[k].m_Bounds) && !shadowOnly)
					{
						int currentLOD = GetCurrentLOD(ref treeLods, Mathf.Sqrt(num7));
						int num8 = m_MtxLODTempCount[currentLOD];
						m_MtxLODTemp[currentLOD][num8].m00 = editTime[k].m_Matrix.m00;
						m_MtxLODTemp[currentLOD][num8].m01 = editTime[k].m_Matrix.m01;
						m_MtxLODTemp[currentLOD][num8].m02 = editTime[k].m_Matrix.m02;
						m_MtxLODTemp[currentLOD][num8].m03 = editTime[k].m_Matrix.m03;
						m_MtxLODTemp[currentLOD][num8].m10 = editTime[k].m_Matrix.m10;
						m_MtxLODTemp[currentLOD][num8].m11 = editTime[k].m_Matrix.m11;
						m_MtxLODTemp[currentLOD][num8].m12 = editTime[k].m_Matrix.m12;
						m_MtxLODTemp[currentLOD][num8].m13 = editTime[k].m_Matrix.m13;
						m_MtxLODTemp[currentLOD][num8].m20 = editTime[k].m_Matrix.m20;
						m_MtxLODTemp[currentLOD][num8].m21 = editTime[k].m_Matrix.m21;
						m_MtxLODTemp[currentLOD][num8].m22 = editTime[k].m_Matrix.m22;
						m_MtxLODTemp[currentLOD][num8].m23 = editTime[k].m_Matrix.m23;
						m_MtxLODTempCount[currentLOD]++;
						if (m_MtxLODTempCount[currentLOD] >= 1000)
						{
							IssueBatchLOD(m_MtxLODTemp[currentLOD], m_MtxLODTempCount[currentLOD], treeLods[currentLOD], typeMPB, shadow);
							m_MtxLODTempCount[currentLOD] = 0;
						}
					}
					else if (castShadow && shadowCorrection && num7 <= shadowCorrectionDistanceSqr)
					{
						int currentLOD2 = GetCurrentLOD(ref treeLods, Mathf.Sqrt(num7));
						int num9 = m_MtxLODTempShadowCount[currentLOD2];
						m_MtxLODTempShadow[currentLOD2][num9].m00 = editTime[k].m_Matrix.m00;
						m_MtxLODTempShadow[currentLOD2][num9].m01 = editTime[k].m_Matrix.m01;
						m_MtxLODTempShadow[currentLOD2][num9].m02 = editTime[k].m_Matrix.m02;
						m_MtxLODTempShadow[currentLOD2][num9].m03 = editTime[k].m_Matrix.m03;
						m_MtxLODTempShadow[currentLOD2][num9].m10 = editTime[k].m_Matrix.m10;
						m_MtxLODTempShadow[currentLOD2][num9].m11 = editTime[k].m_Matrix.m11;
						m_MtxLODTempShadow[currentLOD2][num9].m12 = editTime[k].m_Matrix.m12;
						m_MtxLODTempShadow[currentLOD2][num9].m13 = editTime[k].m_Matrix.m13;
						m_MtxLODTempShadow[currentLOD2][num9].m20 = editTime[k].m_Matrix.m20;
						m_MtxLODTempShadow[currentLOD2][num9].m21 = editTime[k].m_Matrix.m21;
						m_MtxLODTempShadow[currentLOD2][num9].m22 = editTime[k].m_Matrix.m22;
						m_MtxLODTempShadow[currentLOD2][num9].m23 = editTime[k].m_Matrix.m23;
						m_MtxLODTempShadowCount[currentLOD2]++;
						if (m_MtxLODTempShadowCount[currentLOD2] >= 1000)
						{
							IssueBatchLOD(m_MtxLODTempShadow[currentLOD2], m_MtxLODTempShadowCount[currentLOD2], treeLods[currentLOD2], typeMPB, ShadowCastingMode.ShadowsOnly);
							m_MtxLODTempShadowCount[currentLOD2] = 0;
						}
					}
				}
				for (int l = 0; l < treeLods.Length; l++)
				{
					if (m_MtxLODTempCount[l] > 0)
					{
						IssueBatchLOD(m_MtxLODTemp[l], m_MtxLODTempCount[l], treeLods[l], typeMPB, shadow);
						m_MtxLODTempCount[l] = 0;
					}
					if (m_MtxLODTempShadowCount[l] > 0)
					{
						IssueBatchLOD(m_MtxLODTempShadow[l], m_MtxLODTempShadowCount[l], treeLods[l], typeMPB, ShadowCastingMode.ShadowsOnly);
						m_MtxLODTempShadowCount[l] = 0;
					}
				}
				m_DrawStats.m_ProcessedInstances += editTime.Length;
			}
		}

		private void IssueBatchLOD(Matrix4x4[] batch, int count, FoliageTypeLODTree lod, MaterialPropertyBlock mpb, ShadowCastingMode shadow)
		{
			mpb.SetFloat(m_ShaderIDCritiasFoliageLOD, lod.m_EndDistance);
			mpb.SetFloat(m_ShaderIDCritiasFoliageLODSqr, lod.m_EndDistance * lod.m_EndDistance);
			Mesh mesh = lod.m_Mesh;
			Material[] materials = lod.m_Materials;
			if (m_Settings.m_DrawInstanced)
			{
				int i = 0;
				for (int subMeshCount = mesh.subMeshCount; i < subMeshCount; i++)
				{
					Graphics.DrawMeshInstanced(mesh, i, materials[i], batch, count, mpb, shadow, receiveShadows: true, m_CurrentFrameLayer, m_CurrentFrameCameraDraw);
					m_DrawStats.m_ProcessedDrawCalls++;
				}
			}
			else
			{
				int j = 0;
				for (int subMeshCount2 = mesh.subMeshCount; j < subMeshCount2; j++)
				{
					for (int k = 0; k < count; k++)
					{
						Graphics.DrawMesh(mesh, batch[k], materials[j], m_CurrentFrameLayer, m_CurrentFrameCameraDraw, j, mpb, shadow, receiveShadows: true, null, m_Settings.m_UseLightProbes);
						m_DrawStats.m_ProcessedDrawCalls++;
					}
				}
			}
			m_DrawStats.m_ProcessedInstances += count;
		}

		private int GetCurrentLOD(ref FoliageTypeLODTree[] treeLods, float treeDistance)
		{
			for (int i = 0; i < treeLods.Length; i++)
			{
				if (treeDistance < treeLods[i].m_EndDistance)
				{
					return i;
				}
			}
			return treeLods.Length - 1;
		}

		private void ProcessSubdividedCell(FoliageCellDataRuntime cell, FoliageCellSubdividedDataRuntime cellSubdivided, float distance)
		{
			int i = 0;
			for (int num = cellSubdivided.m_TypeHashLocationsRuntime.Length; i < num; i++)
			{
				FoliageType foliageType = m_FoliageTypes[cellSubdivided.m_TypeHashLocationsRuntime[i].Key];
				float num2 = foliageType.m_RenderInfo.m_MaxDistance * foliageType.m_RenderInfo.m_MaxDistance;
				if (!(distance <= num2))
				{
					continue;
				}
				Matrix4x4[][] editTime = cellSubdivided.m_TypeHashLocationsRuntime[i].Value.m_EditTime;
				MaterialPropertyBlock typeMPB = foliageType.m_RuntimeData.m_TypeMPB;
				typeMPB.SetFloat(m_ShaderIDCritiasFoliageDistance, foliageType.m_RenderInfo.m_MaxDistance);
				typeMPB.SetFloat(m_ShaderIDCritiasFoliageDistanceSqr, num2);
				if (foliageType.m_EnableBend)
				{
					typeMPB.SetFloat(m_ShaderIDCritiasBendDistance, foliageType.m_BendDistance);
					typeMPB.SetFloat(m_ShaderIDCritiasBendScale, foliageType.m_BendPower);
					typeMPB.SetVector(m_ShaderIDCritiasBendPosition, m_CurrentFrameBendPosition);
				}
				Mesh mesh = foliageType.m_RuntimeData.m_LODDataGrass.m_Mesh;
				Material material = foliageType.m_RuntimeData.m_LODDataGrass.m_Material;
				if (foliageType.RenderIndirect && m_CurrentFrameAllowIndirect)
				{
					long key = (((long)cell.m_Position.GetHashCode() << 32) | cellSubdivided.m_Position.GetHashCode()) + foliageType.m_Hash;
					if (!m_CachedGPUBufferData.ContainsKey(key))
					{
						GPUBufferCellCachedData gPUBufferCellCachedData = new GPUBufferCellCachedData();
						Matrix4x4[] array;
						if (editTime.Length > 1)
						{
							int num3 = 0;
							for (int j = 0; j < editTime.Length; j++)
							{
								num3 += editTime[j].Length;
							}
							List<Matrix4x4> list = new List<Matrix4x4>(num3);
							for (int k = 0; k < editTime.Length; k++)
							{
								list.AddRange(editTime[k]);
							}
							array = list.ToArray();
						}
						else
						{
							array = editTime[0];
						}
						gPUBufferCellCachedData.m_BufferPositions = new ComputeBuffer(array.Length, 64);
						gPUBufferCellCachedData.m_BufferPositions.SetData(array);
						gPUBufferCellCachedData.m_BufferArguments = new ComputeBuffer(1, m_TempDrawArgs.Length * 4, ComputeBufferType.DrawIndirect);
						gPUBufferCellCachedData.m_IndexCount = mesh.GetIndexCount(0);
						gPUBufferCellCachedData.m_InstanceCount = (uint)array.Length;
						m_CachedGPUBufferData.Add(key, gPUBufferCellCachedData);
					}
					GPUBufferCellCachedData gPUBufferCellCachedData2 = m_CachedGPUBufferData[key];
					typeMPB.SetBuffer(m_ShaderIDCritiasInstanceBuffer, gPUBufferCellCachedData2.m_BufferPositions);
					m_TempDrawArgs[0] = gPUBufferCellCachedData2.m_IndexCount;
					m_TempDrawArgs[1] = (uint)((float)gPUBufferCellCachedData2.m_InstanceCount * m_Settings.m_GrassDensity);
					gPUBufferCellCachedData2.m_BufferArguments.SetData(m_TempDrawArgs);
					Graphics.DrawMeshInstancedIndirect(mesh, 0, material, cellSubdivided.m_Bounds, gPUBufferCellCachedData2.m_BufferArguments, 0, typeMPB, ShadowCastingMode.Off, receiveShadows: true, m_CurrentFrameLayer, m_CurrentFrameCameraDraw);
				}
				else
				{
					ShadowCastingMode castShadows = (foliageType.m_RenderInfo.m_CastShadow ? ShadowCastingMode.On : ShadowCastingMode.Off);
					int l = 0;
					for (int num4 = editTime.Length; l < num4; l++)
					{
						Graphics.DrawMeshInstanced(mesh, 0, material, editTime[l], (int)((float)editTime[l].Length * m_Settings.m_GrassDensity), typeMPB, castShadows, receiveShadows: true, m_CurrentFrameLayer, m_CurrentFrameCameraDraw);
						m_DrawStats.m_ProcessedDrawCalls++;
					}
				}
			}
		}
	}
}
