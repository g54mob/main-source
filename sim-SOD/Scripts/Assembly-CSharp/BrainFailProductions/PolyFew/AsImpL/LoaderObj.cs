using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class LoaderObj : Loader
	{
		private class BumpParamDef
		{
			public string optionName;

			public string valueType;

			public int valueNumMin;

			public int valueNumMax;

			public BumpParamDef(string name, string type, int numMin, int numMax)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadModelFile_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string absolutePath;

			public LoaderObj _003C_003E4__this;

			private StreamReader _003Csr_003E5__2;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			public bool isWorking;

			public byte[] downloadedBytes;

			public Exception ex;

			internal void _003CLoadModelFileNetworked_003Eb__0(byte[] bytes)
			{
			}

			internal void _003CLoadModelFileNetworked_003Eb__1(string error)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadModelFileNetworked_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public LoaderObj _003C_003E4__this;

			public string objURL;

			private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

			private TaskAwaiter _003C_003Eu__1;

			private StreamReader _003Csr_003E5__2;

			private TaskAwaiter<string> _003C_003Eu__2;

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
		private sealed class _003C_003Ec__DisplayClass5_0
		{
			public bool isWorking;

			public LoaderObj _003C_003E4__this;

			public Exception ex;

			public Action<Exception> OnError;

			internal void _003CLoadModelFileNetworkedWebGL_003Eb__0(string text)
			{
			}

			internal void _003CLoadModelFileNetworkedWebGL_003Eb__1(string error)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadModelFileNetworkedWebGL_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoaderObj _003C_003E4__this;

			public Action<Exception> OnError;

			public string objURL;

			private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

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
			public _003CLoadModelFileNetworkedWebGL_003Ed__5(int _003C_003E1__state)
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
		private struct _003CLoadMaterialLibrary_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public LoaderObj _003C_003E4__this;

			public string absolutePath;

			public string materialsFolderPath;

			private StreamReader _003Csr_003E5__2;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private sealed class _003C_003Ec__DisplayClass7_0
		{
			public bool isWorking;

			public byte[] downloadedBytes;

			internal void _003CLoadMaterialLibrary_003Eb__0(byte[] bytes)
			{
			}

			internal void _003CLoadMaterialLibrary_003Eb__1(string error)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadMaterialLibrary_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public LoaderObj _003C_003E4__this;

			public string materialURL;

			private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

			private TaskAwaiter _003C_003Eu__1;

			private StreamReader _003Csr_003E5__2;

			private TaskAwaiter<string> _003C_003Eu__2;

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
		private sealed class _003C_003Ec__DisplayClass8_0
		{
			public bool isWorking;

			public LoaderObj _003C_003E4__this;

			internal void _003CLoadMaterialLibraryWebGL_003Eb__0(string text)
			{
			}

			internal void _003CLoadMaterialLibraryWebGL_003Eb__1(string error)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadMaterialLibraryWebGL_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoaderObj _003C_003E4__this;

			public string materialURL;

			private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

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
			public _003CLoadMaterialLibraryWebGL_003Ed__8(int _003C_003E1__state)
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
		private sealed class _003CLoadOrDownloadText_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoaderObj _003C_003E4__this;

			public string url;

			public bool notifyErrors;

			private UnityWebRequest _003Cuwr_003E5__2;

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
			public _003CLoadOrDownloadText_003Ed__20(int _003C_003E1__state)
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

		private string mtlLib;

		private string loadedText;

		protected override bool HasMaterialLibrary => false;

		public override string[] ParseTexturePaths(string absolutePath)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadModelFile_003Ed__3))]
		protected override Task LoadModelFile(string absolutePath, string texturesFolderPath = "", string materialsFolderPath = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadModelFileNetworked_003Ed__4))]
		protected override Task LoadModelFileNetworked(string objURL)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadModelFileNetworkedWebGL_003Ed__5))]
		protected override IEnumerator LoadModelFileNetworkedWebGL(string objURL, Action<Exception> OnError)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadMaterialLibrary_003Ed__6))]
		protected override Task LoadMaterialLibrary(string absolutePath, string materialsFolderPath = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadMaterialLibrary_003Ed__7))]
		protected override Task LoadMaterialLibrary(string materialURL)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadMaterialLibraryWebGL_003Ed__8))]
		protected override IEnumerator LoadMaterialLibraryWebGL(string materialURL)
		{
			return null;
		}

		private void GetFaceIndicesByOneFaceLine(DataSet.FaceIndices[] faces, string[] p, bool isFaceIndexPlus)
		{
		}

		private Vector3 ConvertVec3(float x, float y, float z)
		{
			return default(Vector3);
		}

		private float ParseFloat(string floatString)
		{
			return 0f;
		}

		protected void ParseGeometryData(string objDataText)
		{
		}

		private string ParseMaterialLibName(string path)
		{
			return null;
		}

		private void ParseMaterialData(string data)
		{
		}

		private void ParseMaterialData(string[] lines, List<MaterialData> mtlData)
		{
		}

		private void ParseBumpParameters(string[] param, MaterialData mtlData)
		{
		}

		private Color StringsToColor(string[] p)
		{
			return default(Color);
		}

		[IteratorStateMachine(typeof(_003CLoadOrDownloadText_003Ed__20))]
		private IEnumerator LoadOrDownloadText(string url, bool notifyErrors = true)
		{
			return null;
		}
	}
}
