using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MBVersionConcrete : MBVersionInterface
	{
		[CompilerGenerated]
		private sealed class _003CFindRuntimeMaterialsFromAddresses_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MB2_TextureBakeResults.CoroutineResult isComplete;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFindRuntimeMaterialsFromAddresses_003Ed__34(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private Vector2 _HALF_UV;

		public string version()
		{
			return null;
		}

		public bool Is_2017_1_OrNewer()
		{
			return false;
		}

		public bool Is_2018_3_OrNewer()
		{
			return false;
		}

		public bool GetActive(GameObject go)
		{
			return false;
		}

		public void SetActive(GameObject go, bool isActive)
		{
		}

		public void SetActiveRecursively(GameObject go, bool isActive)
		{
		}

		public UnityEngine.Object[] FindSceneObjectsOfType(Type t)
		{
			return null;
		}

		public bool IsSwizzledNormalMapPlatform()
		{
			return false;
		}

		public bool IsMaterialKeywordValid(Material mat, string keyword)
		{
			return false;
		}

		public void OptimizeMesh(Mesh m)
		{
		}

		public bool IsRunningAndMeshNotReadWriteable(Mesh m)
		{
			return false;
		}

		public Vector2[] GetMeshUV1s(Mesh m, MB2_LogLevel LOG_LEVEL)
		{
			return null;
		}

		public Vector2[] GetMeshUVChannel(int channel, Mesh m, MB2_LogLevel LOG_LEVEL)
		{
			return null;
		}

		public void MeshClear(Mesh m, bool t)
		{
		}

		public void MeshAssignUVChannel(int channel, Mesh m, Vector2[] uvs)
		{
		}

		public Vector4 GetLightmapTilingOffset(Renderer r)
		{
			return default(Vector4);
		}

		public Transform[] GetBones(Renderer r, bool isSkinnedMeshWithBones)
		{
			return null;
		}

		public int GetBlendShapeFrameCount(Mesh m, int shapeIndex)
		{
			return 0;
		}

		public float GetBlendShapeFrameWeight(Mesh m, int shapeIndex, int frameIndex)
		{
			return 0f;
		}

		public void GetBlendShapeFrameVertices(Mesh m, int shapeIndex, int frameIndex, Vector3[] vs, Vector3[] ns, Vector3[] ts)
		{
		}

		public void ClearBlendShapes(Mesh m)
		{
		}

		public void AddBlendShapeFrame(Mesh m, string nm, float wt, Vector3[] vs, Vector3[] ns, Vector3[] ts)
		{
		}

		public int MaxMeshVertexCount()
		{
			return 0;
		}

		public void SetMeshIndexFormatAndClearMesh(Mesh m, int numVerts, bool vertices, bool justClearTriangles)
		{
		}

		public bool GraphicsUVStartsAtTop()
		{
			return false;
		}

		public bool IsTexture_sRGBgammaCorrected(Texture2D tex, bool hint)
		{
			return false;
		}

		public bool IsTextureReadable(Texture2D tex)
		{
			return false;
		}

		public float GetScaleInLightmap(MeshRenderer r)
		{
			return 0f;
		}

		public bool CollectPropertyNames(List<ShaderTextureProperty> texPropertyNames, ShaderTextureProperty[] shaderTexPropertyNames, List<ShaderTextureProperty> _customShaderPropNames, Material resultMaterial, MB2_LogLevel LOG_LEVEL)
		{
			return false;
		}

		public void DoSpecialRenderPipeline_TexturePackerFastSetup(GameObject cameraGameObject)
		{
		}

		public ColorSpace GetProjectColorSpace()
		{
			return default(ColorSpace);
		}

		public MBVersion.PipelineType DetectPipeline()
		{
			return default(MBVersion.PipelineType);
		}

		public string UnescapeURL(string url)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFindRuntimeMaterialsFromAddresses_003Ed__34))]
		public IEnumerator FindRuntimeMaterialsFromAddresses(MB2_TextureBakeResults texBakeResult, MB2_TextureBakeResults.CoroutineResult isComplete)
		{
			return null;
		}

		public bool IsAssetInProject(UnityEngine.Object target)
		{
			return false;
		}
	}
}
