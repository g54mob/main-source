using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrainFailProductions.PolyFewRuntime;
using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class ObjectImporter : MonoBehaviour
	{
		private enum ImportPhase
		{
			Idle = 0,
			TextureImport = 1,
			ObjLoad = 2,
			AssetBuild = 3,
			Done = 4
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CImportModelAsync_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GameObject> _003C_003Et__builder;

			public ObjectImporter _003C_003E4__this;

			public string filePath;

			public ImportOptions options;

			public string objName;

			public Transform parentObj;

			public string texturesFolderPath;

			public string materialsFolderPath;

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
		private struct _003CImportModelFromNetwork_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GameObject> _003C_003Et__builder;

			public ObjectImporter _003C_003E4__this;

			public ImportOptions options;

			public string objName;

			public PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

			public string objURL;

			public string diffuseTexURL;

			public string bumpTexURL;

			public string specularTexURL;

			public string opacityTexURL;

			public string materialURL;

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

		public static PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

		public static int activeDownloads;

		private static float objDownloadProgress;

		private static float textureDownloadProgress;

		private static float materialDownloadProgress;

		public static bool isException;

		protected int numTotalImports;

		protected bool allLoaded;

		protected ImportOptions buildOptions;

		protected List<Loader> loaderList;

		private ImportPhase importPhase;

		public int NumImportRequests => 0;

		public event Action ImportingStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ImportingComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<GameObject, string> CreatedModel
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<GameObject, string> ImportedModel
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<string> ImportError
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private Loader CreateLoader(string absolutePath, bool isNetwork = false)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CImportModelAsync_003Ed__31))]
		public Task<GameObject> ImportModelAsync(string objName, string filePath, Transform parentObj, ImportOptions options, string texturesFolderPath = "", string materialsFolderPath = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CImportModelFromNetwork_003Ed__32))]
		public Task<GameObject> ImportModelFromNetwork(string objURL, string objName, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL, string materialURL, PolyfewRuntime.ReferencedNumeric<float> downloadProgress, ImportOptions options)
		{
			return null;
		}

		public void ImportModelFromNetworkWebGL(string objURL, string objName, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL, string materialURL, PolyfewRuntime.ReferencedNumeric<float> downloadProgress, ImportOptions options, Action<GameObject> OnSuccess, Action<Exception> OnError)
		{
		}

		public virtual void UpdateStatus()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnImportingComplete()
		{
		}

		protected virtual void OnModelCreated(GameObject obj, string absolutePath)
		{
		}

		protected virtual void OnImported(GameObject obj, string absolutePath)
		{
		}

		protected virtual void OnImportError(string absolutePath)
		{
		}
	}
}
