using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrainFailProductions.PolyFewRuntime;
using UnityEngine;
using UnityEngine.Networking;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public abstract class Loader : MonoBehaviour
	{
		protected struct BuildStats
		{
			public float texturesTime;

			public float materialsTime;

			public float objectsTime;
		}

		protected struct Stats
		{
			public float modelParseTime;

			public float materialsParseTime;

			public float buildTime;

			public BuildStats buildStats;

			public float totalTime;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoad_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GameObject> _003C_003Et__builder;

			public string objAbsolutePath;

			public string objName;

			public Loader _003C_003E4__this;

			public string texturesFolderPath;

			public string materialsFolderPath;

			public Transform parentObj;

			private float _003ClastTime_003E5__2;

			private float _003CstartTime_003E5__3;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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
		private struct _003CLoadFromNetwork_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GameObject> _003C_003Et__builder;

			public string objName;

			public Loader _003C_003E4__this;

			public string objURL;

			public string materialURL;

			public string diffuseTexURL;

			public string bumpTexURL;

			public string specularTexURL;

			public string opacityTexURL;

			private float _003ClastTime_003E5__2;

			private float _003CstartTime_003E5__3;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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
		private sealed class _003CLoadFromNetworkWebGL_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string objName;

			public Loader _003C_003E4__this;

			public string objURL;

			public Action<Exception> OnError;

			public string materialURL;

			public string diffuseTexURL;

			public string bumpTexURL;

			public string specularTexURL;

			public string opacityTexURL;

			public Action<GameObject> OnSuccess;

			private float _003ClastTime_003E5__2;

			private float _003CstartTime_003E5__3;

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
			public _003CLoadFromNetworkWebGL_003Ed__35(int _003C_003E1__state)
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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBuild_003Ed__43 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Loader _003C_003E4__this;

			public string absolutePath;

			public string texturesFolderPath;

			public string objName;

			public Transform parentTransform;

			private float _003CprevTime_003E5__2;

			private string _003CbasePath_003E5__3;

			private int _003Ccount_003E5__4;

			private List<MaterialData>.Enumerator _003C_003E7__wrap4;

			private MaterialData _003Cmtl_003E5__6;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CNetworkedBuild_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Loader _003C_003E4__this;

			public string diffuseTexURL;

			public string bumpTexURL;

			public string specularTexURL;

			public string opacityTexURL;

			public string objName;

			public Transform parentTransform;

			public string objURL;

			private float _003CprevTime_003E5__2;

			private ObjectBuilder.ProgressInfo _003Cinfo_003E5__3;

			private float _003CobjInitPerc_003E5__4;

			private GameObject _003CnewObj_003E5__5;

			private float _003CinitProgress_003E5__6;

			private int _003Ccount_003E5__7;

			private List<MaterialData>.Enumerator _003C_003E7__wrap7;

			private MaterialData _003Cmtl_003E5__9;

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
		private sealed class _003CNetworkedBuildWebGL_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Loader _003C_003E4__this;

			public string diffuseTexURL;

			public string bumpTexURL;

			public string specularTexURL;

			public string opacityTexURL;

			public string objName;

			public Transform parentTransform;

			public string objURL;

			private float _003CprevTime_003E5__2;

			private int _003Ccount_003E5__3;

			private List<MaterialData>.Enumerator _003C_003E7__wrap3;

			private MaterialData _003Cmtl_003E5__5;

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
			public _003CNetworkedBuildWebGL_003Ed__45(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadMaterialTexture_003Ed__51 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Loader _003C_003E4__this;

			public string texturesFolderPath;

			public string basePath;

			public string path;

			private byte[] _003Cresult_003E5__2;

			private FileStream _003Cstream_003E5__3;

			private TaskAwaiter<int> _003C_003Eu__1;

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
		private sealed class _003C_003Ec__DisplayClass52_0
		{
			public bool isWorking;

			public byte[] downloadedBytes;

			internal void _003CLoadMaterialTexture_003Eb__0(byte[] bytes)
			{
			}

			internal void _003CLoadMaterialTexture_003Eb__1(string error)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadMaterialTexture_003Ed__52 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Loader _003C_003E4__this;

			public string textureURL;

			private _003C_003Ec__DisplayClass52_0 _003C_003E8__1;

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
		private sealed class _003C_003Ec__DisplayClass53_0
		{
			public bool isWorking;

			public Loader _003C_003E4__this;

			internal void _003CLoadMaterialTextureWebGL_003Eb__0(Texture2D texture)
			{
			}

			internal void _003CLoadMaterialTextureWebGL_003Eb__1(string error)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadMaterialTextureWebGL_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Loader _003C_003E4__this;

			public string textureURL;

			private _003C_003Ec__DisplayClass53_0 _003C_003E8__1;

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
			public _003CLoadMaterialTextureWebGL_003Ed__53(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CDownloadFile_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

			public string url;

			public Action<string> OnError;

			public Loader _003C_003E4__this;

			public Action<byte[]> DownloadComplete;

			private WWW _003Cwww_003E5__2;

			private float _003ColdProgress_003E5__3;

			private Coroutine _003Cprogress_003E5__4;

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
			public _003CDownloadFile_003Ed__57(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CGetProgress_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

			public WWW www;

			private float _003ColdProgress_003E5__2;

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
			public _003CGetProgress_003Ed__58(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CDownloadFileWebGL_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

			public string url;

			public Action<string> OnError;

			public Loader _003C_003E4__this;

			public Action<string> DownloadComplete;

			private WWW _003Cwww_003E5__2;

			private float _003ColdProgress_003E5__3;

			private Coroutine _003Cprogress_003E5__4;

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
			public _003CDownloadFileWebGL_003Ed__59(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CDownloadTexFileWebGL_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

			public string url;

			public Action<string> OnError;

			public Loader _003C_003E4__this;

			public Action<Texture2D> DownloadComplete;

			private WWW _003Cwww_003E5__2;

			private float _003ColdProgress_003E5__3;

			private Coroutine _003Cprogress_003E5__4;

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
			public _003CDownloadTexFileWebGL_003Ed__60(int _003C_003E1__state)
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

		public static LoadingProgress totalProgress;

		public ImportOptions buildOptions;

		public PolyfewRuntime.ReferencedNumeric<float> individualProgress;

		protected static float LOAD_PHASE_PERC;

		protected static float TEXTURE_PHASE_PERC;

		protected static float MATERIAL_PHASE_PERC;

		protected static float BUILD_PHASE_PERC;

		protected static Dictionary<string, GameObject> loadedModels;

		protected static Dictionary<string, int> instanceCount;

		protected DataSet dataSet;

		protected ObjectBuilder objectBuilder;

		protected List<MaterialData> materialData;

		protected SingleLoadingProgress objLoadingProgress;

		protected Stats loadStats;

		private Texture2D loadedTexture;

		public bool ConvertVertAxis
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Scaling
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected abstract bool HasMaterialLibrary { get; }

		public event Action<GameObject, string> ModelCreated
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

		public event Action<GameObject, string> ModelLoaded
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

		public event Action<string> ModelError
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

		public static GameObject GetModelByPath(string absolutePath)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoad_003Ed__33))]
		public Task<GameObject> Load(string objName, string objAbsolutePath, Transform parentObj, string texturesFolderPath = "", string materialsFolderPath = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadFromNetwork_003Ed__34))]
		public Task<GameObject> LoadFromNetwork(string objURL, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL, string materialURL, string objName)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadFromNetworkWebGL_003Ed__35))]
		public IEnumerator LoadFromNetworkWebGL(string objURL, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL, string materialURL, string objName, Action<GameObject> OnSuccess, Action<Exception> OnError)
		{
			return null;
		}

		public abstract string[] ParseTexturePaths(string absolutePath);

		protected abstract Task LoadModelFile(string absolutePath, string texturesFolderPath = "", string materialsFolderPath = "");

		protected abstract Task LoadModelFileNetworked(string objURL);

		protected abstract IEnumerator LoadModelFileNetworkedWebGL(string objURL, Action<Exception> OnError);

		protected abstract Task LoadMaterialLibrary(string absolutePath, string materialsFolderPath = "");

		protected abstract Task LoadMaterialLibrary(string materialURL);

		protected abstract IEnumerator LoadMaterialLibraryWebGL(string materialURL);

		[AsyncStateMachine(typeof(_003CBuild_003Ed__43))]
		protected Task Build(string absolutePath, string objName, Transform parentTransform, string texturesFolderPath = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CNetworkedBuild_003Ed__44))]
		protected Task NetworkedBuild(Transform parentTransform, string objName, string objURL, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CNetworkedBuildWebGL_003Ed__45))]
		protected IEnumerator NetworkedBuildWebGL(Transform parentTransform, string objName, string objURL, string diffuseTexURL, string bumpTexURL, string specularTexURL, string opacityTexURL)
		{
			return null;
		}

		protected string GetDirName(string absolutePath)
		{
			return null;
		}

		protected virtual void OnLoaded(GameObject obj, string absolutePath)
		{
		}

		protected virtual void OnCreated(GameObject obj, string absolutePath)
		{
		}

		protected virtual void OnLoadFailed(string absolutePath)
		{
		}

		private string GetTextureUrl(string basePath, string texturePath)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadMaterialTexture_003Ed__51))]
		private Task LoadMaterialTexture(string basePath, string path, string texturesFolderPath = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadMaterialTexture_003Ed__52))]
		private Task LoadMaterialTexture(string textureURL)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadMaterialTextureWebGL_003Ed__53))]
		private IEnumerator LoadMaterialTextureWebGL(string textureURL)
		{
			return null;
		}

		private Texture2D LoadTexture(UnityWebRequest loader)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDownloadFile_003Ed__57))]
		public IEnumerator DownloadFile(string url, PolyfewRuntime.ReferencedNumeric<float> downloadProgress, Action<byte[]> DownloadComplete, Action<string> OnError)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetProgress_003Ed__58))]
		private IEnumerator GetProgress(WWW www, PolyfewRuntime.ReferencedNumeric<float> downloadProgress)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDownloadFileWebGL_003Ed__59))]
		public IEnumerator DownloadFileWebGL(string url, PolyfewRuntime.ReferencedNumeric<float> downloadProgress, Action<string> DownloadComplete, Action<string> OnError)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDownloadTexFileWebGL_003Ed__60))]
		public IEnumerator DownloadTexFileWebGL(string url, PolyfewRuntime.ReferencedNumeric<float> downloadProgress, Action<Texture2D> DownloadComplete, Action<string> OnError)
		{
			return null;
		}
	}
}
