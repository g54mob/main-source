using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BrainFailProductions.PolyFew.AsImpL;
using UnityEngine;
using UnityMeshSimplifier;

namespace BrainFailProductions.PolyFewRuntime
{
	[AddComponentMenu(null)]
	public class PolyfewRuntime : MonoBehaviour
	{
		[Serializable]
		public class ObjectMeshPairs : Dictionary<GameObject, MeshRendererPair>
		{
		}

		public enum MeshCombineTarget
		{
			SkinnedAndStatic = 0,
			StaticOnly = 1,
			SkinnedOnly = 2
		}

		[Serializable]
		public class MeshRendererPair
		{
			public bool attachedToMeshFilter;

			public Mesh mesh;

			public MeshRendererPair(bool attachedToMeshFilter, Mesh mesh)
			{
			}

			public void Destruct()
			{
			}
		}

		[Serializable]
		public class CustomMeshActionStructure
		{
			public MeshRendererPair meshRendererPair;

			public GameObject gameObject;

			public Action action;

			public CustomMeshActionStructure(MeshRendererPair meshRendererPair, GameObject gameObject, Action action)
			{
			}
		}

		[Serializable]
		public class SimplificationOptions
		{
			public float simplificationStrength;

			public bool simplifyMeshLossless;

			public bool enableSmartlinking;

			public bool recalculateNormals;

			public bool preserveUVSeamEdges;

			public bool preserveUVFoldoverEdges;

			public bool preserveBorderEdges;

			public bool regardPreservationSpheres;

			public List<PreservationSphere> preservationSpheres;

			public bool regardCurvature;

			public int maxIterations;

			public float aggressiveness;

			public bool useEdgeSort;

			public SimplificationOptions()
			{
			}

			public SimplificationOptions(float simplificationStrength, bool simplifyOptimal, bool enableSmartlink, bool recalculateNormals, bool preserveUVSeamEdges, bool preserveUVFoldoverEdges, bool preserveBorderEdges, bool regardToleranceSphere, List<PreservationSphere> preservationSpheres, bool regardCurvature, int maxIterations, float aggressiveness, bool useEdgeSort)
			{
			}
		}

		[Serializable]
		public class PreservationSphere
		{
			public Vector3 worldPosition;

			public float diameter;

			public float preservationStrength;

			public PreservationSphere(Vector3 worldPosition, float diameter, float preservationStrength)
			{
			}
		}

		[Serializable]
		public class OBJImportOptions : ImportOptions
		{
		}

		[Serializable]
		public class OBJExportOptions
		{
			public readonly bool applyPosition;

			public readonly bool applyRotation;

			public readonly bool applyScale;

			public readonly bool generateMaterials;

			public readonly bool exportTextures;

			public OBJExportOptions(bool applyPosition, bool applyRotation, bool applyScale, bool generateMaterials, bool exportTextures)
			{
			}
		}

		public class ReferencedNumeric<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
		{
			private T val;

			public T Value
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			public ReferencedNumeric(T value)
			{
			}
		}

		[Serializable]
		public class MaterialProperties
		{
			public readonly int texArrIndex;

			public readonly int matIndex;

			public readonly string materialName;

			public readonly Material originalMaterial;

			public Color albedoTint;

			public Vector4 uvTileOffset;

			public float normalIntensity;

			public float occlusionIntensity;

			public float smoothnessIntensity;

			public float glossMapScale;

			public float metalIntensity;

			public Color emissionColor;

			public Vector4 detailUVTileOffset;

			public float alphaCutoff;

			public Color specularColor;

			public float detailNormalScale;

			public float heightIntensity;

			public readonly float uvSec;

			public MaterialProperties(int texArrIndex, int matIndex, string materialName, Material originalMaterial, Color albedoTint, Vector4 uvTileOffset, float normalIntensity, float occlusionIntensity, float smoothnessIntensity, float glossMapScale, float metalIntensity, Color emissionColor, Vector4 detailUVTileOffset, float alphaCutoff, Color specularColor, float detailNormalScale, float heightIntensity, float uvSec)
			{
			}

			public void BurnAttrToImg(ref Texture2D burnOn, int index, int textureArrayIndex)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			public bool isWorking;

			public Action<GameObject> OnSuccess;

			internal void _003CImportOBJFromFileSystem_003Eb__0(GameObject importedObject)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CImportOBJFromFileSystem_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<GameObject> OnSuccess;

			public string objAbsolutePath;

			public string texturesFolderPath;

			public string materialsFolderPath;

			public OBJImportOptions importOptions;

			private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

			public Action<Exception> OnError;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass21_0
		{
			public bool isWorking;

			public Action<GameObject> OnSuccess;

			public Action<Exception> OnError;

			internal void _003CImportOBJFromNetwork_003Eb__0(GameObject importedObject)
			{
			}

			internal void _003CImportOBJFromNetwork_003Eb__1(Exception ex)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CImportOBJFromNetwork_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<GameObject> OnSuccess;

			public Action<Exception> OnError;

			public string objURL;

			public string objName;

			public string diffuseTexURL;

			public string bumpTexURL;

			public string specularTexURL;

			public string opacityTexURL;

			public string materialURL;

			public ReferencedNumeric<float> downloadProgress;

			public OBJImportOptions importOptions;

			private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass22_0
		{
			public bool isWorking;

			public Action OnSuccess;

			internal void _003CExportGameObjectToOBJ_003Eb__0()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExportGameObjectToOBJ_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action OnSuccess;

			public GameObject toExport;

			public string exportPath;

			public OBJExportOptions exportOptions;

			public Action<Exception> OnError;

			private _003C_003Ec__DisplayClass22_0 _003C_003E8__1;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const int MAX_LOD_COUNT = 8;

		public static int SimplifyObjectDeep(GameObject toSimplify, SimplificationOptions simplificationOptions, Action<GameObject, MeshRendererPair> OnEachMeshSimplified)
		{
			return 0;
		}

		public static ObjectMeshPairs SimplifyObjectDeep(GameObject toSimplify, SimplificationOptions simplificationOptions)
		{
			return null;
		}

		public static int SimplifyObjectDeep(ObjectMeshPairs objectMeshPairs, SimplificationOptions simplificationOptions, Action<GameObject, MeshRendererPair> OnEachMeshSimplified)
		{
			return 0;
		}

		public static List<Mesh> SimplifyMeshes(List<Mesh> meshesToSimplify, SimplificationOptions simplificationOptions, Action<Mesh> OnEachMeshSimplified)
		{
			return null;
		}

		public static ObjectMeshPairs GetObjectMeshPairs(GameObject forObject, bool includeInactive)
		{
			return null;
		}

		public static void CombineMeshesInGameObject(GameObject forObject, bool skipInactiveRenderers, Action<string, string> OnError, MeshCombineTarget combineTarget = MeshCombineTarget.SkinnedAndStatic)
		{
		}

		public static GameObject CombineMeshesFromRenderers(Transform rootTransform, MeshRenderer[] originalMeshRenderers, SkinnedMeshRenderer[] originalSkinnedMeshRenderers, Action<string, string> OnError)
		{
			return null;
		}

		public static void ConvertSkinnedMeshesInGameObject(GameObject forObject, bool skipInactiveRenderers, Action<string, string> OnError)
		{
		}

		public static Tuple<SkinnedMeshRenderer, MeshRenderer, Mesh>[] ConvertSkinnedMeshesFromRenderers(SkinnedMeshRenderer[] renderersToConvert, Action<string, string> OnError)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CImportOBJFromFileSystem_003Ed__20))]
		public static void ImportOBJFromFileSystem(string objAbsolutePath, string texturesFolderPath, string materialsFolderPath, Action<GameObject> OnSuccess, Action<Exception> OnError, OBJImportOptions importOptions = null)
		{
		}

		[AsyncStateMachine(typeof(_003CImportOBJFromNetwork_003Ed__21))]
		public static void ImportOBJFromNetwork(string objURL, string objName, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL, string materialURL, ReferencedNumeric<float> downloadProgress, Action<GameObject> OnSuccess, Action<Exception> OnError, OBJImportOptions importOptions = null)
		{
		}

		[AsyncStateMachine(typeof(_003CExportGameObjectToOBJ_003Ed__22))]
		public static void ExportGameObjectToOBJ(GameObject toExport, string exportPath, Action OnSuccess, Action<Exception> OnError, OBJExportOptions exportOptions = null)
		{
		}

		public static int CountTriangles(bool countDeep, GameObject forObject)
		{
			return 0;
		}

		public static int CountTriangles(List<Mesh> toCount)
		{
			return 0;
		}

		public static List<MaterialProperties> GetMaterialsProperties(GameObject forObject)
		{
			return null;
		}

		public static void ChangeMaterialProperties(MaterialProperties changeTo, GameObject forObject)
		{
		}

		private static void SetParametersForSimplifier(SimplificationOptions simplificationOptions, MeshSimplifier meshSimplifier)
		{
		}

		private static bool AreAnyFeasibleMeshes(ObjectMeshPairs objectMeshPairs)
		{
			return false;
		}

		private static void AssignReducedMesh(GameObject gameObject, Mesh originalMesh, Mesh reducedMesh, bool attachedToMeshfilter, bool assignBindposes)
		{
		}

		private static int CountTriangles(ObjectMeshPairs objectMeshPairs)
		{
			return 0;
		}
	}
}
