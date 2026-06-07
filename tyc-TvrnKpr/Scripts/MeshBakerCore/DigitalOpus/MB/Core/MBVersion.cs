using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MBVersion
	{
		public enum PipelineType
		{
			Unsupported = 0,
			Default = 1,
			URP = 2,
			HDRP = 3
		}

		[CompilerGenerated]
		private sealed class _003CFindRuntimeMaterialsFromAddresses_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MB2_TextureBakeResults textureBakeResult;

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
			public _003CFindRuntimeMaterialsFromAddresses_003Ed__38(int _003C_003E1__state)
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

		public const string MB_USING_HDRP = "MB_USING_HDRP";

		private static MBVersionInterface _MBVersion;

		private static MBVersionInterface _CreateMBVersionConcrete()
		{
			return null;
		}

		public static string version()
		{
			return null;
		}

		public static bool Is_2018_3_OrNewer()
		{
			return false;
		}

		public static bool Is_2017_1_OrNewer()
		{
			return false;
		}

		public static bool GetActive(GameObject go)
		{
			return false;
		}

		public static void SetActive(GameObject go, bool isActive)
		{
		}

		public static void SetActiveRecursively(GameObject go, bool isActive)
		{
		}

		public static UnityEngine.Object[] FindSceneObjectsOfType(Type t)
		{
			return null;
		}

		public static bool IsRunningAndMeshNotReadWriteable(Mesh m)
		{
			return false;
		}

		public static Vector2[] GetMeshChannel(int channel, Mesh m, MB2_LogLevel LOG_LEVEL)
		{
			return null;
		}

		public static float GetScaleInLightmap(MeshRenderer r)
		{
			return 0f;
		}

		public static void MeshClear(Mesh m, bool t)
		{
		}

		public static void MeshAssignUVChannel(int channel, Mesh m, Vector2[] uvs)
		{
		}

		public static Vector4 GetLightmapTilingOffset(Renderer r)
		{
			return default(Vector4);
		}

		public static Transform[] GetBones(Renderer r, bool isSkinnedMeshWithBones)
		{
			return null;
		}

		public static bool IsSwizzledNormalMapPlatform()
		{
			return false;
		}

		public static bool IsMaterialKeywordValid(Material mat, string keyword)
		{
			return false;
		}

		public static void OptimizeMesh(Mesh m)
		{
		}

		public static int GetBlendShapeFrameCount(Mesh m, int shapeIndex)
		{
			return 0;
		}

		public static float GetBlendShapeFrameWeight(Mesh m, int shapeIndex, int frameIndex)
		{
			return 0f;
		}

		public static void GetBlendShapeFrameVertices(Mesh m, int shapeIndex, int frameIndex, Vector3[] vs, Vector3[] ns, Vector3[] ts)
		{
		}

		public static void ClearBlendShapes(Mesh m)
		{
		}

		public static void AddBlendShapeFrame(Mesh m, string nm, float wt, Vector3[] vs, Vector3[] ns, Vector3[] ts)
		{
		}

		public static int MaxMeshVertexCount()
		{
			return 0;
		}

		public static void SetMeshIndexFormatAndClearMesh(Mesh m, int numVerts, bool vertices, bool justClearTriangles)
		{
		}

		public static bool GraphicsUVStartsAtTop()
		{
			return false;
		}

		public static bool IsTexture_sRGBgammaCorrected(Texture2D tex, bool hint)
		{
			return false;
		}

		public static bool IsTextureReadable(Texture2D tex)
		{
			return false;
		}

		public static void CollectPropertyNames(List<ShaderTextureProperty> texPropertyNames, ShaderTextureProperty[] shaderTexPropertyNames, List<ShaderTextureProperty> _customShaderPropNames, Material resultMaterial, MB2_LogLevel LOG_LEVEL)
		{
		}

		internal static void DoSpecialRenderPipeline_TexturePackerFastSetup(GameObject cameraGameObject)
		{
		}

		public static ColorSpace GetProjectColorSpace()
		{
			return default(ColorSpace);
		}

		public static PipelineType DetectPipeline()
		{
			return default(PipelineType);
		}

		public static string UnescapeURL(string url)
		{
			return null;
		}

		public static bool IsAssetInProject(UnityEngine.Object target)
		{
			return false;
		}

		public static bool IsUsingAddressables()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CFindRuntimeMaterialsFromAddresses_003Ed__38))]
		internal static IEnumerator FindRuntimeMaterialsFromAddresses(MB2_TextureBakeResults textureBakeResult, MB2_TextureBakeResults.CoroutineResult isComplete)
		{
			return null;
		}
	}
}
