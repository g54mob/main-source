using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BrainFailProductions.PolyFew.AsImpL;
using UnityEngine;

namespace BrainFailProductions.PolyFewRuntime
{
	public class UtilityServicesRuntime : MonoBehaviour
	{
		public class OBJExporterImporter
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CExportMeshToOBJ_003Ed__15 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public OBJExporterImporter _003C_003E4__this;

				public Mesh mesh;

				public string exportPath;

				private string _003CobjectName_003E5__2;

				private StringBuilder _003Csb_003E5__3;

				private int _003ClastIndex_003E5__4;

				private int _003CfaceOrder_003E5__5;

				private Vector3[] _003C_003E7__wrap5;

				private int _003C_003E7__wrap6;

				private Vector3 _003Cvx_003E5__8;

				private TaskAwaiter _003C_003Eu__1;

				private Vector2[] _003C_003E7__wrap8;

				private Vector2 _003Cv_003E5__10;

				private int[] _003Ctris_003E5__11;

				private int _003Ct_003E5__12;

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

			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CImportFromLocalFileSystem_003Ed__20 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public string objPath;

				public string texturesFolderPath;

				public string materialsFolderPath;

				public PolyfewRuntime.OBJImportOptions importOptions;

				public Action<GameObject> Callback;

				private GameObject _003CobjectToPopulate_003E5__2;

				private ObjectImporter _003CobjImporter_003E5__3;

				private TaskAwaiter<GameObject> _003C_003Eu__1;

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

			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CImportFromNetwork_003Ed__21 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncVoidMethodBuilder _003C_003Et__builder;

				public string objURL;

				public string diffuseTexURL;

				public string materialURL;

				public PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

				public PolyfewRuntime.OBJImportOptions importOptions;

				public string objName;

				public string bumpTexURL;

				public string specularTexURL;

				public string opacityTexURL;

				public Action<GameObject> OnSuccess;

				public Action<Exception> OnError;

				private GameObject _003CobjectToPopulate_003E5__2;

				private ObjectImporter _003CobjImporter_003E5__3;

				private TaskAwaiter<GameObject> _003C_003Eu__1;

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

			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CImportFromNetworkWebGL_003Ed__22 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncVoidMethodBuilder _003C_003Et__builder;

				public Action<GameObject> OnSuccess;

				public Action<Exception> OnError;

				public string objURL;

				public string diffuseTexURL;

				public string materialURL;

				public PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

				public PolyfewRuntime.OBJImportOptions importOptions;

				public string objName;

				public string bumpTexURL;

				public string specularTexURL;

				public string opacityTexURL;

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

			private bool applyPosition;

			private bool applyRotation;

			private bool applyScale;

			private bool generateMaterials;

			private bool exportTextures;

			private string exportPath;

			private MeshFilter meshFilter;

			private Mesh meshToExport;

			private MeshRenderer meshRenderer;

			private void InitializeExporter(GameObject toExport, string exportPath, PolyfewRuntime.OBJExportOptions exportOptions)
			{
			}

			private void InitializeExporter(Mesh toExport, string exportPath)
			{
			}

			private Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle)
			{
				return default(Vector3);
			}

			private Vector3 MultiplyVec3s(Vector3 v1, Vector3 v2)
			{
				return default(Vector3);
			}

			public void ExportGameObjectToOBJ(GameObject toExport, string exportPath, PolyfewRuntime.OBJExportOptions exportOptions = null, Action OnSuccess = null)
			{
			}

			[AsyncStateMachine(typeof(_003CExportMeshToOBJ_003Ed__15))]
			public Task ExportMeshToOBJ(Mesh mesh, string exportPath)
			{
				return null;
			}

			private string TryExportTexture(string propertyName, Material m, string exportPath)
			{
				return null;
			}

			private string ExportTexture(Texture2D t, string exportPath)
			{
				return null;
			}

			private string ConstructOBJString(int index)
			{
				return null;
			}

			private string MaterialToString(Material m)
			{
				return null;
			}

			[AsyncStateMachine(typeof(_003CImportFromLocalFileSystem_003Ed__20))]
			public Task ImportFromLocalFileSystem(string objPath, string texturesFolderPath, string materialsFolderPath, Action<GameObject> Callback, PolyfewRuntime.OBJImportOptions importOptions = null)
			{
				return null;
			}

			[AsyncStateMachine(typeof(_003CImportFromNetwork_003Ed__21))]
			public void ImportFromNetwork(string objURL, string objName, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL, string materialURL, PolyfewRuntime.ReferencedNumeric<float> downloadProgress, Action<GameObject> OnSuccess, Action<Exception> OnError, PolyfewRuntime.OBJImportOptions importOptions = null)
			{
			}

			[AsyncStateMachine(typeof(_003CImportFromNetworkWebGL_003Ed__22))]
			public void ImportFromNetworkWebGL(string objURL, string objName, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL, string materialURL, PolyfewRuntime.ReferencedNumeric<float> downloadProgress, Action<GameObject> OnSuccess, Action<Exception> OnError, PolyfewRuntime.OBJImportOptions importOptions = null)
			{
			}
		}

		public static Texture2D DuplicateTexture(Texture2D source)
		{
			return null;
		}

		public static Renderer[] GetChildRenderersForCombining(GameObject forObject, bool skipInactiveChildObjects)
		{
			return null;
		}

		public static MeshRenderer CreateStaticLevelRenderer(string name, Transform parentTransform, Transform originalTransform, Mesh mesh, Material[] materials)
		{
			return null;
		}

		public static SkinnedMeshRenderer CreateSkinnedLevelRenderer(string name, Transform parentTransform, Transform originalTransform, Mesh mesh, Material[] materials, Transform rootBone, Transform[] bones)
		{
			return null;
		}

		private static void CollectChildRenderersForCombining(Transform transform, List<Renderer> resultRenderers, bool skipInactiveChildObjects)
		{
		}

		private static void ParentAndResetTransform(Transform transform, Transform parentTransform)
		{
		}

		public static void ParentAndOffsetTransform(Transform transform, Transform parentTransform, Transform originalTransform)
		{
		}
	}
}
