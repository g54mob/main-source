using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public static class GPUITerrainUtility
	{
		private const float DETAIL_DENSITY_VALUE_DIVIDER = 255f;

		public static RenderTexture CreateDetailRenderTexture(int resolution, string name)
		{
			RenderTexture renderTexture = new RenderTexture(resolution, resolution, 0, GPUIRuntimeSettings.Instance.API_HAS_GUARANTEED_R8_SUPPORT ? RenderTextureFormat.R8 : RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear);
			renderTexture.name = name;
			renderTexture.isPowerOfTwo = false;
			renderTexture.enableRandomWrite = true;
			renderTexture.filterMode = FilterMode.Point;
			renderTexture.useMipMap = false;
			renderTexture.autoGenerateMips = false;
			renderTexture.Create();
			return renderTexture;
		}

		public static void CaptureTerrainDetailToRenderTexture(Terrain terrain, int detailLayer, RenderTexture renderTexture, bool sampleTerrainHoles)
		{
			int detailResolution = terrain.terrainData.detailResolution;
			int[,] detailLayer2 = terrain.terrainData.GetDetailLayer(0, 0, detailResolution, detailResolution, detailLayer);
			CaptureTerrainDetailToRenderTexture(terrain, detailResolution, detailLayer2, renderTexture, sampleTerrainHoles);
		}

		public static void CaptureTerrainDetailToRenderTexture(Terrain terrain, int detailResolution, int[,] details, RenderTexture renderTexture, bool sampleTerrainHoles)
		{
			int num = detailResolution * detailResolution;
			GraphicsBuffer graphicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, num, 4);
			graphicsBuffer.SetData(details);
			ComputeShader cS_TerrainDetailCapture = GPUITerrainConstants.CS_TerrainDetailCapture;
			if (sampleTerrainHoles)
			{
				cS_TerrainDetailCapture.EnableKeyword(GPUITerrainConstants.Kw_GPUI_TERRAIN_HOLES);
				cS_TerrainDetailCapture.SetTexture(0, GPUITerrainConstants.PROP_terrainHoleTexture, terrain.terrainData.holesTexture);
			}
			else
			{
				cS_TerrainDetailCapture.DisableKeyword(GPUITerrainConstants.Kw_GPUI_TERRAIN_HOLES);
			}
			cS_TerrainDetailCapture.SetTexture(0, GPUITerrainConstants.PROP_terrainDetailTexture, renderTexture);
			cS_TerrainDetailCapture.SetBuffer(0, GPUITerrainConstants.PROP_detailLayerBuffer, graphicsBuffer);
			cS_TerrainDetailCapture.SetInt(GPUITerrainConstants.PROP_detailResolution, detailResolution);
			cS_TerrainDetailCapture.DispatchX(0, num);
			graphicsBuffer.Dispose();
		}

		public static void UpdateTerrainDetailWithRenderTexture(Terrain terrain, int detailLayer, RenderTexture renderTexture)
		{
			int detailResolution = terrain.terrainData.detailResolution;
			Texture2D texture2D = GPUITextureUtility.RenderTextureToTexture2D(renderTexture, TextureFormat.R8, linear: true);
			int[,] array = new int[detailResolution, detailResolution];
			for (int i = 0; i < detailResolution; i++)
			{
				for (int j = 0; j < detailResolution; j++)
				{
					float num = texture2D.GetPixel(i, j).r * 255f;
					array[j, i] = (int)num;
				}
			}
			terrain.terrainData.SetDetailLayer(0, 0, detailLayer, array);
		}

		public static Mesh CreateCrossQuadsMesh(string name, int quadCount)
		{
			GameObject gameObject = new GameObject(name, typeof(MeshFilter));
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			gameObject.transform.position = Vector3.zero;
			CombineInstance[] array = new CombineInstance[quadCount];
			for (int i = 0; i < quadCount; i++)
			{
				GameObject gameObject2 = new GameObject("quadToCombine_" + i, typeof(MeshFilter));
				Mesh mesh = GPUIUtility.GenerateQuadMesh(1f, 1f, new Rect(0f, 0f, 1f, 1f), centerPivotAtBottom: true, 0f, 0f, setVertexColors: true);
				for (int j = 0; j < mesh.normals.Length; j++)
				{
					mesh.normals[i] = Vector3.up;
				}
				gameObject2.GetComponent<MeshFilter>().sharedMesh = mesh;
				gameObject2.transform.parent = gameObject.transform;
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.transform.localRotation = Quaternion.identity * Quaternion.AngleAxis(180f / (float)quadCount * (float)i, Vector3.up);
				gameObject2.transform.localScale = Vector3.one;
				array[i] = new CombineInstance
				{
					mesh = gameObject2.GetComponent<MeshFilter>().sharedMesh,
					transform = gameObject2.transform.localToWorldMatrix
				};
			}
			gameObject.GetComponent<MeshFilter>().sharedMesh = new Mesh();
			gameObject.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(array, mergeSubMeshes: true, useMatrices: true);
			Mesh sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.name = name;
			Object.DestroyImmediate(gameObject);
			return sharedMesh;
		}

		public static Mesh GenerateBladeMesh(Vector2 size, int segmentCount, float bendMultiplier, float bendLowerAmount, AnimationCurve bladeBendCurve, AnimationCurve bladeWidthCurve)
		{
			Mesh mesh = new Mesh();
			mesh.name = "BladeMesh";
			int num = 4 + 2 * (segmentCount - 1) + 1;
			float num2 = size.y / (float)(segmentCount + 1);
			Vector3[] array = new Vector3[num];
			Vector2[] array2 = new Vector2[num];
			int[] array3 = new int[segmentCount * 6 + 3];
			for (int i = 0; i < segmentCount; i++)
			{
				float num3 = bladeBendCurve.Evaluate(((float)i + 1f) / (float)(segmentCount + 1)) * size.y * bendMultiplier;
				float num4 = num3 * bendLowerAmount;
				float num5 = size.x * bladeWidthCurve.Evaluate(((float)i + 1f) / (float)segmentCount);
				array[(i + 1) * 2] = new Vector3(0f - num5, num2 * (float)(i + 1) - num4, num3);
				array[(i + 1) * 2 + 1] = new Vector3(num5, num2 * (float)(i + 1) - num4, num3);
				array2[(i + 1) * 2] = new Vector2(0f, ((float)i + 1f) / (float)(segmentCount + 1));
				array2[(i + 1) * 2 + 1] = new Vector2(1f, ((float)i + 1f) / (float)(segmentCount + 1));
				array3[i * 6] = i * 2;
				array3[i * 6 + 1] = (i + 1) * 2;
				array3[i * 6 + 2] = i * 2 + 1;
				array3[i * 6 + 3] = i * 2 + 1;
				array3[i * 6 + 4] = (i + 1) * 2;
				array3[i * 6 + 5] = (i + 1) * 2 + 1;
			}
			float num6 = size.x * bladeWidthCurve.Evaluate(0f);
			array[0] = new Vector3(0f - num6, 0f, 0f);
			array[1] = new Vector3(num6, 0f, 0f);
			float num7 = bladeBendCurve.Evaluate(1f) * size.y * bendMultiplier;
			array[num - 1] = new Vector3(0f, size.y - num7 * bendLowerAmount, num7);
			mesh.vertices = array;
			array2[0] = Vector2.zero;
			array2[1] = new Vector2(1f, 0f);
			array2[num - 1] = Vector2.one;
			mesh.uv = array2;
			array3[^3] = segmentCount * 2;
			array3[^2] = num - 1;
			array3[^1] = segmentCount * 2 + 1;
			mesh.triangles = array3;
			Vector3 vector = new Vector3(0f, 0f, -1f);
			Vector4 vector2 = new Vector4(1f, 0f, 0f, -1f);
			Vector3[] array4 = new Vector3[num];
			for (int j = 0; j < num; j++)
			{
				array4[j] = vector;
			}
			mesh.normals = array4;
			Vector4[] array5 = new Vector4[num];
			for (int k = 0; k < num; k++)
			{
				array5[k] = vector2;
			}
			mesh.tangents = array5;
			Color[] array6 = new Color[num];
			for (int l = 0; l < num; l++)
			{
				array6[l] = Color.Lerp(Color.clear, Color.red, mesh.vertices[l].y / size.y);
			}
			mesh.colors = array6;
			return mesh;
		}

		public static void SetDetailDensityInsideCollider(GPUIDetailManager detailManager, Collider collider, float valueToSet, float offset = 0f, List<int> prototypeIndexFilter = null)
		{
			if (!detailManager.IsInitialized)
			{
				Debug.LogWarning("Detail Manager is not initialized. Can not modify the detail density!");
				return;
			}
			if (collider is BoxCollider boxCollider)
			{
				SetDetailDensityInsideBoxCollider(detailManager, valueToSet, boxCollider, offset, prototypeIndexFilter);
			}
			else if (collider is SphereCollider sphereCollider)
			{
				SetDetailDensityInsideSphereCollider(detailManager, valueToSet, sphereCollider, offset, prototypeIndexFilter);
			}
			else if (collider is CapsuleCollider capsuleCollider)
			{
				SetDetailDensityInsideCapsuleCollider(detailManager, valueToSet, capsuleCollider, offset, prototypeIndexFilter);
			}
			else
			{
				SetDetailDensityInsideBounds(detailManager, valueToSet, collider.bounds, offset, prototypeIndexFilter);
			}
			detailManager.RequireUpdate();
		}

		public static void SetDetailDensityInsideBounds(GPUIDetailManager detailManager, float valueToSet, Bounds bounds, float offset, List<int> prototypeIndexFilter)
		{
			if (!detailManager.IsInitialized)
			{
				Debug.LogWarning("Detail Manager is not initialized. Can not modify the detail density!");
				return;
			}
			valueToSet /= 255f;
			int prototypeCount = detailManager.GetPrototypeCount();
			ComputeShader cS_TerrainDetailDensityModifier = GPUITerrainConstants.CS_TerrainDetailDensityModifier;
			int kernelIndex = 0;
			foreach (GPUITerrain activeTerrainValue in detailManager.GetActiveTerrainValues())
			{
				if (!activeTerrainValue.GetBounds().Intersects(bounds))
				{
					continue;
				}
				Texture heightmapTexture = activeTerrainValue.GetHeightmapTexture();
				if (heightmapTexture == null)
				{
					continue;
				}
				if (!activeTerrainValue.IsDetailDensityTexturesLoaded)
				{
					activeTerrainValue.CreateDetailTextures();
				}
				for (int i = 0; i < prototypeCount; i++)
				{
					if (prototypeIndexFilter == null || prototypeIndexFilter.Count <= 0 || prototypeIndexFilter.Contains(i))
					{
						RenderTexture detailDensityTexture = activeTerrainValue.GetDetailDensityTexture(activeTerrainValue.GetTerrainDetailPrototypeIndex(i));
						if (!(detailDensityTexture == null))
						{
							int width = detailDensityTexture.width;
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_terrainDetailTexture, detailDensityTexture);
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_heightmapTexture, heightmapTexture);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_heightmapTextureSize, heightmapTexture.width);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_detailTextureSize, width);
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainPosition, activeTerrainValue.GetPosition());
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainSize, activeTerrainValue.GetSize());
							cS_TerrainDetailDensityModifier.SetFloat(GPUIConstants.PROP_valueToSet, valueToSet);
							cS_TerrainDetailDensityModifier.SetVector(GPUIConstants.PROP_boundsCenter, bounds.center);
							cS_TerrainDetailDensityModifier.SetVector(GPUIConstants.PROP_boundsExtents, bounds.extents + Vector3.one * offset);
							cS_TerrainDetailDensityModifier.DispatchXZ(kernelIndex, width, width);
						}
					}
				}
			}
			detailManager.RequireUpdate();
		}

		public static void SetDetailDensityInsideBoxCollider(GPUIDetailManager detailManager, float valueToSet, BoxCollider boxCollider, float offset, List<int> prototypeIndexFilter)
		{
			if (!detailManager.IsInitialized)
			{
				Debug.LogWarning("Detail Manager is not initialized. Can not modify the detail density!");
				return;
			}
			valueToSet /= 255f;
			int prototypeCount = detailManager.GetPrototypeCount();
			ComputeShader cS_TerrainDetailDensityModifier = GPUITerrainConstants.CS_TerrainDetailDensityModifier;
			int kernelIndex = 1;
			Vector3 center = boxCollider.center;
			Vector3 vector = boxCollider.size / 2f + Vector3.one * offset;
			Matrix4x4 localToWorldMatrix = boxCollider.transform.localToWorldMatrix;
			Bounds bounds = boxCollider.bounds;
			foreach (GPUITerrain activeTerrainValue in detailManager.GetActiveTerrainValues())
			{
				if (!activeTerrainValue.GetBounds().Intersects(bounds))
				{
					continue;
				}
				Texture heightmapTexture = activeTerrainValue.GetHeightmapTexture();
				if (heightmapTexture == null)
				{
					continue;
				}
				if (!activeTerrainValue.IsDetailDensityTexturesLoaded)
				{
					activeTerrainValue.CreateDetailTextures();
				}
				for (int i = 0; i < prototypeCount; i++)
				{
					if (prototypeIndexFilter == null || prototypeIndexFilter.Count <= 0 || prototypeIndexFilter.Contains(i))
					{
						RenderTexture detailDensityTexture = activeTerrainValue.GetDetailDensityTexture(activeTerrainValue.GetTerrainDetailPrototypeIndex(i));
						if (!(detailDensityTexture == null))
						{
							int width = detailDensityTexture.width;
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_terrainDetailTexture, detailDensityTexture);
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_heightmapTexture, heightmapTexture);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_heightmapTextureSize, heightmapTexture.width);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_detailTextureSize, width);
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainPosition, activeTerrainValue.GetPosition());
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainSize, activeTerrainValue.GetSize());
							cS_TerrainDetailDensityModifier.SetFloat(GPUIConstants.PROP_valueToSet, valueToSet);
							cS_TerrainDetailDensityModifier.SetVector(GPUIConstants.PROP_boundsCenter, center);
							cS_TerrainDetailDensityModifier.SetVector(GPUIConstants.PROP_boundsExtents, vector);
							cS_TerrainDetailDensityModifier.SetMatrix(GPUIConstants.PROP_modifierTransform, localToWorldMatrix);
							cS_TerrainDetailDensityModifier.DispatchXZ(kernelIndex, width, width);
						}
					}
				}
			}
		}

		public static void SetDetailDensityInsideSphereCollider(GPUIDetailManager detailManager, float valueToSet, SphereCollider sphereCollider, float offset, List<int> prototypeIndexFilter)
		{
			if (!detailManager.IsInitialized)
			{
				Debug.LogWarning("Detail Manager is not initialized. Can not modify the detail density!");
				return;
			}
			valueToSet /= 255f;
			int prototypeCount = detailManager.GetPrototypeCount();
			ComputeShader cS_TerrainDetailDensityModifier = GPUITerrainConstants.CS_TerrainDetailDensityModifier;
			int kernelIndex = 2;
			Vector3 vector = sphereCollider.center + sphereCollider.transform.position;
			Vector3 lossyScale = sphereCollider.transform.lossyScale;
			float val = sphereCollider.radius * Mathf.Max(Mathf.Max(lossyScale.x, lossyScale.y), lossyScale.z) + offset;
			Bounds bounds = sphereCollider.bounds;
			foreach (GPUITerrain activeTerrainValue in detailManager.GetActiveTerrainValues())
			{
				if (!activeTerrainValue.GetBounds().Intersects(bounds))
				{
					continue;
				}
				Texture heightmapTexture = activeTerrainValue.GetHeightmapTexture();
				if (heightmapTexture == null)
				{
					continue;
				}
				if (!activeTerrainValue.IsDetailDensityTexturesLoaded)
				{
					activeTerrainValue.CreateDetailTextures();
				}
				for (int i = 0; i < prototypeCount; i++)
				{
					if (prototypeIndexFilter == null || prototypeIndexFilter.Count <= 0 || prototypeIndexFilter.Contains(i))
					{
						RenderTexture detailDensityTexture = activeTerrainValue.GetDetailDensityTexture(activeTerrainValue.GetTerrainDetailPrototypeIndex(i));
						if (!(detailDensityTexture == null))
						{
							int width = detailDensityTexture.width;
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_terrainDetailTexture, detailDensityTexture);
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_heightmapTexture, heightmapTexture);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_heightmapTextureSize, heightmapTexture.width);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_detailTextureSize, width);
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainPosition, activeTerrainValue.GetPosition());
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainSize, activeTerrainValue.GetSize());
							cS_TerrainDetailDensityModifier.SetFloat(GPUIConstants.PROP_valueToSet, valueToSet);
							cS_TerrainDetailDensityModifier.SetVector(GPUIConstants.PROP_boundsCenter, vector);
							cS_TerrainDetailDensityModifier.SetFloat(GPUIConstants.PROP_modifierRadius, val);
							cS_TerrainDetailDensityModifier.DispatchXZ(kernelIndex, width, width);
						}
					}
				}
			}
		}

		public static void SetDetailDensityInsideCapsuleCollider(GPUIDetailManager detailManager, float valueToSet, CapsuleCollider capsuleCollider, float offset, List<int> prototypeIndexFilter)
		{
			if (!detailManager.IsInitialized)
			{
				Debug.LogWarning("Detail Manager is not initialized. Can not modify the detail density!");
				return;
			}
			valueToSet /= 255f;
			int prototypeCount = detailManager.GetPrototypeCount();
			ComputeShader cS_TerrainDetailDensityModifier = GPUITerrainConstants.CS_TerrainDetailDensityModifier;
			int kernelIndex = 3;
			Vector3 center = capsuleCollider.center;
			Vector3 lossyScale = capsuleCollider.transform.lossyScale;
			float val = capsuleCollider.radius * Mathf.Max(Mathf.Max((capsuleCollider.direction == 0) ? 0f : lossyScale.x, (capsuleCollider.direction == 1) ? 0f : lossyScale.y), (capsuleCollider.direction == 2) ? 0f : lossyScale.z) + offset;
			float val2 = capsuleCollider.height * ((capsuleCollider.direction == 0) ? lossyScale.x : ((capsuleCollider.direction == 1) ? lossyScale.y : ((capsuleCollider.direction == 2) ? lossyScale.z : 0f)));
			Bounds bounds = capsuleCollider.bounds;
			foreach (GPUITerrain activeTerrainValue in detailManager.GetActiveTerrainValues())
			{
				if (!activeTerrainValue.GetBounds().Intersects(bounds))
				{
					continue;
				}
				Texture heightmapTexture = activeTerrainValue.GetHeightmapTexture();
				if (heightmapTexture == null)
				{
					continue;
				}
				if (!activeTerrainValue.IsDetailDensityTexturesLoaded)
				{
					activeTerrainValue.CreateDetailTextures();
				}
				for (int i = 0; i < prototypeCount; i++)
				{
					if (prototypeIndexFilter == null || prototypeIndexFilter.Contains(i))
					{
						RenderTexture detailDensityTexture = activeTerrainValue.GetDetailDensityTexture(activeTerrainValue.GetTerrainDetailPrototypeIndex(i));
						if (!(detailDensityTexture == null))
						{
							int width = detailDensityTexture.width;
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_terrainDetailTexture, detailDensityTexture);
							cS_TerrainDetailDensityModifier.SetTexture(kernelIndex, GPUITerrainConstants.PROP_heightmapTexture, heightmapTexture);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_heightmapTextureSize, heightmapTexture.width);
							cS_TerrainDetailDensityModifier.SetInt(GPUITerrainConstants.PROP_detailTextureSize, width);
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainPosition, activeTerrainValue.GetPosition());
							cS_TerrainDetailDensityModifier.SetVector(GPUITerrainConstants.PROP_terrainSize, activeTerrainValue.GetSize());
							cS_TerrainDetailDensityModifier.SetFloat(GPUIConstants.PROP_valueToSet, valueToSet);
							cS_TerrainDetailDensityModifier.SetVector(GPUIConstants.PROP_boundsCenter, center);
							cS_TerrainDetailDensityModifier.SetFloat(GPUIConstants.PROP_modifierRadius, val);
							cS_TerrainDetailDensityModifier.SetFloat(GPUIConstants.PROP_modifierHeight, val2);
							cS_TerrainDetailDensityModifier.DispatchXZ(kernelIndex, width, width);
						}
					}
				}
			}
		}
	}
}
