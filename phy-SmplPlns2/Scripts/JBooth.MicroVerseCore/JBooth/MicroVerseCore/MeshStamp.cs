using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class MeshStamp : Stamp, IHeightModifier, IModifier
	{
		public enum Resolution
		{
			k32 = 0x20,
			k64 = 0x40,
			k128 = 0x80,
			k256 = 0x100,
			k512 = 0x200,
			k1024 = 0x400,
			k2048 = 0x800
		}

		public enum BlendMode
		{
			Add = 0,
			Subtract = 1,
			Fillaround = 2,
			Connect = 3
		}

		public GameObject targetObject;

		[Tooltip("When true, the renderers on the target object will be hidden and the objects removed in build/play mode. In essence, this is used when you just want to model with the mesh and not have it exist for gameplay")]
		public bool hideRenderers;

		[Tooltip("Offset to Y position of result")]
		public float offset;

		[Tooltip("Scale Height Result of offset")]
		[Range(0f, 1f)]
		public float heightScale = 1f;

		[Tooltip("Min/Max range of height values")]
		public Vector2 heightClamp = new Vector2(0f, 1f);

		[Tooltip("Resolution of the depth rendering buffer")]
		public Resolution resolution = Resolution.k256;

		public FalloffFilter falloff = new FalloffFilter();

		[Range(0f, 24f)]
		[Tooltip("Blurs the area between the mesh stamp and the terrain")]
		public float blur;

		[Tooltip("Do we pull terrain up towards the mesh, or down away from the mesh")]
		public BlendMode blendMode;

		[Range(0.9f, 0.1f)]
		[Tooltip("The heighest point on the mesh terrain connnects to")]
		public float connectHeight = 0.9f;

		private Material material;

		private static Shader meshShader;

		private static Camera cam;

		private List<MeshFilter> tempFilters = new List<MeshFilter>(1);

		private static int _AlphaMapSize = Shader.PropertyToID("_AlphaMapSize");

		private static int _NoiseUV = Shader.PropertyToID("_NoiseUV");

		private static int _YBounds = Shader.PropertyToID("_YBounds");

		private static int _HeightScaleClamp = Shader.PropertyToID("_HeightScaleClamp");

		private static int _ConnectHeight = Shader.PropertyToID("_ConnectHeight");

		private static int _Transform = Shader.PropertyToID("_Transform");

		private static int _RealSize = Shader.PropertyToID("_RealSize");

		private static int _StampTex = Shader.PropertyToID("_StampTex");

		public RenderTexture targetDepthTexture { get; set; }

		public override void StripInBuild()
		{
			if (hideRenderers && (bool)targetObject)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(targetObject);
				}
				else
				{
					Object.DestroyImmediate(targetObject);
				}
			}
			base.StripInBuild();
		}

		private void FitCameraToTarget(Camera cam, Bounds bounds)
		{
			if (blendMode == BlendMode.Add)
			{
				cam.transform.position = new Vector3(bounds.center.x, bounds.max.y + 10001f, bounds.center.z);
				cam.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			}
			else
			{
				cam.transform.position = new Vector3(bounds.center.x, bounds.min.y + 9999f, bounds.center.z);
				cam.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
			}
			cam.nearClipPlane = 0.5f;
			cam.farClipPlane = bounds.size.y + 1f;
			float num = Mathf.Max(bounds.size.x, bounds.size.z);
			cam.orthographicSize = num / 2f;
			cam.depthTextureMode = DepthTextureMode.Depth;
			cam.orthographic = true;
		}

		public void SetHideRenderers(GameObject go, bool enabled)
		{
			if (!(go == null))
			{
				Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = enabled;
				}
			}
		}

		private void ScanMeshFilters(GameObject go)
		{
			MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>();
			tempFilters.Clear();
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				LODGroup componentInParent = meshFilter.GetComponentInParent<LODGroup>();
				if (componentInParent != null)
				{
					LOD[] lODs = componentInParent.GetLODs();
					if (lODs.Length == 0 || lODs[0].renderers == null || lODs[0].renderers.Length == 0)
					{
						continue;
					}
					Renderer[] renderers = lODs[0].renderers;
					for (int j = 0; j < renderers.Length; j++)
					{
						if (renderers[j].gameObject == meshFilter.gameObject)
						{
							if (meshFilter.sharedMesh.isReadable)
							{
								tempFilters.Add(meshFilter);
							}
							else
							{
								Debug.LogError("Mesh Filter in game object " + meshFilter.gameObject?.ToString() + " is not read/write, cannot use for mesh stamp", meshFilter.gameObject);
							}
						}
					}
				}
				else if (meshFilter.sharedMesh.isReadable)
				{
					tempFilters.Add(meshFilter);
				}
				else
				{
					Debug.LogError("Mesh Filter in game object " + meshFilter.gameObject?.ToString() + " is not read/write, cannot use for mesh stamp", meshFilter.gameObject);
				}
			}
		}

		private Bounds GetPrefabBounds(GameObject go)
		{
			ScanMeshFilters(go);
			Bounds result = default(Bounds);
			if (tempFilters.Count > 0)
			{
				result = GeometryUtility.CalculateBounds(tempFilters[0].sharedMesh.vertices, tempFilters[0].transform.localToWorldMatrix);
				for (int i = 1; i < tempFilters.Count; i++)
				{
					Bounds bounds = GeometryUtility.CalculateBounds(tempFilters[i].sharedMesh.vertices, tempFilters[i].transform.localToWorldMatrix);
					result.Encapsulate(bounds);
				}
			}
			int num = (int)blur * 4;
			Vector3 size = result.size;
			size.x += 3 + num;
			size.z += 3 + num;
			result.size = size;
			return result;
		}

		public void RenderCamera(Camera cam, RenderTexture texture)
		{
			CommandBuffer commandBuffer = new CommandBuffer();
			commandBuffer.SetRenderTarget(texture);
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			commandBuffer.SetViewProjectionMatrices(cam.worldToCameraMatrix, cam.projectionMatrix);
			ScanMeshFilters(targetObject);
			for (int i = 0; i < tempFilters.Count; i++)
			{
				commandBuffer.DrawMesh(tempFilters[i].sharedMesh, tempFilters[i].transform.localToWorldMatrix, tempFilters[i].GetComponent<MeshRenderer>().sharedMaterial);
			}
			Graphics.ExecuteCommandBuffer(commandBuffer);
		}

		public RenderTexture Capture()
		{
			return null;
		}

		public void Initialize()
		{
			if (targetObject != null && targetDepthTexture == null)
			{
				if (targetDepthTexture != null)
				{
					Object.DestroyImmediate(targetDepthTexture);
				}
				targetDepthTexture = Capture();
			}
			if (meshShader == null)
			{
				meshShader = Shader.Find("Hidden/MicroVerse/MeshStamp");
			}
			if (material == null)
			{
				material = new Material(meshShader);
			}
		}

		public override Bounds GetBounds()
		{
			FalloffOverride componentInParent = GetComponentInParent<FalloffOverride>();
			FalloffFilter.FilterType filterType = falloff.filterType;
			FalloffFilter filter = falloff;
			if (componentInParent != null && componentInParent.enabled)
			{
				filterType = componentInParent.filter.filterType;
				filter = componentInParent.filter;
			}
			if (filterType == FalloffFilter.FilterType.SplineArea && filter.splineArea != null)
			{
				return filter.splineArea.GetBounds();
			}
			if (filterType == FalloffFilter.FilterType.Global && filter.paintArea != null && filter.paintArea.clampOutsideOfBounds)
			{
				return filter.paintArea.GetBounds();
			}
			if (targetObject != null)
			{
				Bounds prefabBounds = GetPrefabBounds(targetObject);
				Vector3 size = prefabBounds.size;
				size.y = 999999f;
				prefabBounds.size = size;
				return prefabBounds;
			}
			return default(Bounds);
		}

		protected override void OnDestroy()
		{
			if (targetDepthTexture != null)
			{
				Object.DestroyImmediate(targetDepthTexture);
				targetDepthTexture = null;
			}
			base.OnDestroy();
		}

		private void OnDrawGizmosSelected()
		{
			if (MicroVerse.instance != null)
			{
				Gizmos.color = MicroVerse.instance.options.colors.heightStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0f, 0f), Vector3.one);
			}
		}

		public bool ApplyHeightStamp(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od)
		{
			if (targetDepthTexture != null)
			{
				keywordBuilder.Clear();
				PrepareMaterial(material, heightmapData, keywordBuilder.keywords);
				material.SetFloat(_AlphaMapSize, source.width);
				Vector3 position = heightmapData.terrain.transform.position;
				position.x /= heightmapData.terrain.terrainData.size.x;
				position.z /= heightmapData.terrain.terrainData.size.z;
				material.SetVector(_NoiseUV, new Vector3(position.x, position.z, GetTerrainScalingFactor(heightmapData.terrain)));
				Bounds prefabBounds = GetPrefabBounds(targetObject);
				material.SetMatrix(_Transform, ComputeStampMatrix(heightmapData.terrain, prefabBounds));
				material.SetVector(_YBounds, new Vector4(prefabBounds.min.y - 0.5f, prefabBounds.max.y + 0.5f, prefabBounds.size.y + 1f, offset));
				material.SetVector(_HeightScaleClamp, new Vector3(heightScale, heightClamp.x, heightClamp.y));
				material.SetFloat(_ConnectHeight, 1f);
				if (blendMode == BlendMode.Subtract)
				{
					keywordBuilder.Add("_SUBTRACT");
				}
				else if (blendMode == BlendMode.Connect)
				{
					keywordBuilder.Add("_CONNECT");
					material.SetFloat(_ConnectHeight, connectHeight);
				}
				else if (blendMode == BlendMode.Fillaround)
				{
					keywordBuilder.Add("_FILLAROUND");
				}
				keywordBuilder.Assign(material);
				Graphics.Blit(source, dest, material);
				return true;
			}
			return false;
		}

		private Matrix4x4 ComputeStampMatrix(Terrain terrain, Bounds bounds)
		{
			Vector3 size = terrain.terrainData.size;
			Vector3 heightmapScale = terrain.terrainData.heightmapScale;
			int heightmapResolution = terrain.terrainData.heightmapResolution;
			Vector2 vector = new Vector2(heightmapScale.x * (float)heightmapResolution, heightmapScale.z * (float)heightmapResolution);
			Vector3 vector2 = terrain.transform.worldToLocalMatrix.MultiplyPoint3x4(bounds.center);
			Vector3 size2 = bounds.size;
			float num = Mathf.Max(size2.x, size2.z);
			Matrix4x4 matrix4x = Matrix4x4.Translate(-(new Vector2(vector2.x, vector2.z) / vector));
			matrix4x = Matrix4x4.Scale(new Vector3(size.x / num, size.z / num, 0f)) * matrix4x;
			return Matrix4x4.Translate(new Vector3(0.5f, 0.5f, 0f)) * matrix4x;
		}

		private void PrepareMaterial(Material material, HeightmapData heightmapData, List<string> keywords)
		{
			material.SetVector(_RealSize, TerrainUtil.ComputeTerrainSize(heightmapData.terrain));
			material.SetTexture(_StampTex, targetDepthTexture);
			falloff.PrepareTerrain(material, heightmapData.terrain, base.transform, keywords);
			falloff.PrepareMaterial(material, base.transform, keywords);
			material.SetFloat("_BlurSize", blur);
		}

		public void Dispose()
		{
		}
	}
}
