using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

namespace DigitalOpus.MB.Core
{
	public class MBVersionConcrete : MBVersionInterface
	{
		private Vector2 _HALF_UV = new Vector2(0.5f, 0.5f);

		public string version()
		{
			return "3.32.0";
		}

		public int GetMajorVersion()
		{
			string unityVersion = Application.unityVersion;
			string[] array = unityVersion.Split('.');
			return int.Parse(array[0]);
		}

		public int GetMinorVersion()
		{
			string unityVersion = Application.unityVersion;
			string[] array = unityVersion.Split('.');
			return int.Parse(array[1]);
		}

		public bool GetActive(GameObject go)
		{
			return go.activeInHierarchy;
		}

		public void SetActive(GameObject go, bool isActive)
		{
			go.SetActive(isActive);
		}

		public void SetActiveRecursively(GameObject go, bool isActive)
		{
			go.SetActive(isActive);
		}

		public UnityEngine.Object[] FindSceneObjectsOfType(Type t)
		{
			return UnityEngine.Object.FindObjectsOfType(t);
		}

		public void OptimizeMesh(Mesh m)
		{
		}

		public bool IsRunningAndMeshNotReadWriteable(Mesh m)
		{
			if (Application.isPlaying)
			{
				return !m.isReadable;
			}
			return false;
		}

		public Vector2[] GetMeshUV1s(Mesh m, MB2_LogLevel LOG_LEVEL)
		{
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				MB2_Log.LogDebug("UV1 does not exist in Unity 5+");
			}
			Vector2[] array = m.uv;
			if (array.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug(string.Concat("Mesh ", m, " has no uv1s. Generating"));
				}
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					Debug.LogWarning(string.Concat("Mesh ", m, " didn't have uv1s. Generating uv1s."));
				}
				array = new Vector2[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _HALF_UV;
				}
			}
			return array;
		}

		public Vector2[] GetMeshUVChannel(int channel, Mesh m, MB2_LogLevel LOG_LEVEL)
		{
			Vector2[] array = new Vector2[0];
			switch (channel)
			{
			case 0:
				array = m.uv;
				break;
			case 2:
				array = m.uv2;
				break;
			case 3:
				array = m.uv3;
				break;
			case 4:
				array = m.uv4;
				break;
			default:
				Debug.LogError("Mesh does not have UV channel " + channel);
				break;
			}
			if (array.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug(string.Concat("Mesh ", m, " has no uv", channel, ". Generating"));
				}
				array = new Vector2[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _HALF_UV;
				}
			}
			return array;
		}

		public void MeshClear(Mesh m, bool t)
		{
			m.Clear(t);
		}

		public void MeshAssignUVChannel(int channel, Mesh m, Vector2[] uvs)
		{
			switch (channel)
			{
			case 0:
				m.uv = uvs;
				break;
			case 2:
				m.uv2 = uvs;
				break;
			case 3:
				m.uv3 = uvs;
				break;
			case 4:
				m.uv4 = uvs;
				break;
			default:
				Debug.LogError("Mesh does not have UV channel " + channel);
				break;
			}
		}

		public Vector4 GetLightmapTilingOffset(Renderer r)
		{
			return r.lightmapScaleOffset;
		}

		public Transform[] GetBones(Renderer r, bool isSkinnedMeshWithBones)
		{
			if (isSkinnedMeshWithBones)
			{
				return ((SkinnedMeshRenderer)r).bones;
			}
			if (r is MeshRenderer || (r is SkinnedMeshRenderer && !isSkinnedMeshWithBones))
			{
				return new Transform[1] { r.transform };
			}
			Debug.LogError("Could not getBones. Object does not have a renderer");
			return null;
		}

		public int GetBlendShapeFrameCount(Mesh m, int shapeIndex)
		{
			return m.GetBlendShapeFrameCount(shapeIndex);
		}

		public float GetBlendShapeFrameWeight(Mesh m, int shapeIndex, int frameIndex)
		{
			return m.GetBlendShapeFrameWeight(shapeIndex, frameIndex);
		}

		public void GetBlendShapeFrameVertices(Mesh m, int shapeIndex, int frameIndex, Vector3[] vs, Vector3[] ns, Vector3[] ts)
		{
			m.GetBlendShapeFrameVertices(shapeIndex, frameIndex, vs, ns, ts);
		}

		public void ClearBlendShapes(Mesh m)
		{
			m.ClearBlendShapes();
		}

		public void AddBlendShapeFrame(Mesh m, string nm, float wt, Vector3[] vs, Vector3[] ns, Vector3[] ts)
		{
			m.AddBlendShapeFrame(nm, wt, vs, ns, ts);
		}

		public int MaxMeshVertexCount()
		{
			return 2147483646;
		}

		public void SetMeshIndexFormatAndClearMesh(Mesh m, int numVerts, bool vertices, bool justClearTriangles)
		{
			if (vertices && numVerts > 65534 && m.indexFormat == IndexFormat.UInt16)
			{
				MBVersion.MeshClear(m, false);
				m.indexFormat = IndexFormat.UInt32;
			}
			else if (vertices && numVerts <= 65534 && m.indexFormat == IndexFormat.UInt32)
			{
				MBVersion.MeshClear(m, false);
				m.indexFormat = IndexFormat.UInt16;
			}
			else if (justClearTriangles)
			{
				MBVersion.MeshClear(m, true);
			}
			else
			{
				MBVersion.MeshClear(m, false);
			}
		}

		public bool GraphicsUVStartsAtTop()
		{
			return SystemInfo.graphicsUVStartsAtTop;
		}

		public bool IsTextureReadable(Texture2D tex)
		{
			try
			{
				tex.GetPixel(0, 0);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool CollectPropertyNames(List<ShaderTextureProperty> texPropertyNames, ShaderTextureProperty[] shaderTexPropertyNames, List<ShaderTextureProperty> _customShaderPropNames, Material resultMaterial, MB2_LogLevel LOG_LEVEL)
		{
			string text = string.Empty;
			for (int i = 0; i < shaderTexPropertyNames.Length; i++)
			{
				if (resultMaterial.HasProperty(shaderTexPropertyNames[i].name))
				{
					text = text + ", " + shaderTexPropertyNames[i].name;
					if (!texPropertyNames.Contains(shaderTexPropertyNames[i]))
					{
						texPropertyNames.Add(shaderTexPropertyNames[i]);
					}
					if (resultMaterial.GetTextureOffset(shaderTexPropertyNames[i].name) != new Vector2(0f, 0f) && LOG_LEVEL >= MB2_LogLevel.warn)
					{
						Debug.LogWarning("Result material has non-zero offset. This is may be incorrect.");
					}
					if (resultMaterial.GetTextureScale(shaderTexPropertyNames[i].name) != new Vector2(1f, 1f) && LOG_LEVEL >= MB2_LogLevel.warn)
					{
						Debug.LogWarning("Result material should have tiling of 1,1");
					}
				}
			}
			for (int j = 0; j < _customShaderPropNames.Count; j++)
			{
				if (resultMaterial.HasProperty(_customShaderPropNames[j].name))
				{
					text = text + ", " + _customShaderPropNames[j].name;
					texPropertyNames.Add(_customShaderPropNames[j]);
					if (resultMaterial.GetTextureOffset(_customShaderPropNames[j].name) != new Vector2(0f, 0f) && LOG_LEVEL >= MB2_LogLevel.warn)
					{
						Debug.LogWarning("Result material has non-zero offset. This is probably incorrect.");
					}
					if (resultMaterial.GetTextureScale(_customShaderPropNames[j].name) != new Vector2(1f, 1f) && LOG_LEVEL >= MB2_LogLevel.warn)
					{
						Debug.LogWarning("Result material should probably have tiling of 1,1.");
					}
				}
				else if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					Debug.LogWarning("Result material shader does not use property " + _customShaderPropNames[j].name + " in the list of custom shader property names");
				}
			}
			return true;
		}

		public void DoSpecialRenderPipeline_TexturePackerFastSetup(GameObject cameraGameObject)
		{
			MBVersion.PipelineType pipelineType = DetectPipeline();
		}

		public ColorSpace GetProjectColorSpace()
		{
			if (QualitySettings.desiredColorSpace != QualitySettings.activeColorSpace)
			{
				Debug.LogError(string.Concat("The active color space (", QualitySettings.activeColorSpace, ") is not the desired color space (", QualitySettings.desiredColorSpace, "). Baked atlases may be off."));
			}
			return QualitySettings.activeColorSpace;
		}

		public MBVersion.PipelineType DetectPipeline()
		{
			if (GraphicsSettings.renderPipelineAsset != null)
			{
				return MBVersion.PipelineType.Unsupported;
			}
			return MBVersion.PipelineType.Default;
		}

		public string UnescapeURL(string url)
		{
			return UnityWebRequest.UnEscapeURL(url);
		}
	}
}
