using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;
using UnityEngine.Networking;

namespace GRP.Steam
{
	public class ImageUrlViewable : Viewable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadTexture_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ImageUrlViewable _003C_003E4__this;

			private string _003Curl_003E5__2;

			private UnityWebRequest _003Creq_003E5__3;

			private Awaitable.Awaiter _003C_003Eu__1;

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
		private struct _003CLoadTexture_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Texture2D> _003C_003Et__builder;

			public bool useCache;

			public string url;

			private UnityWebRequest _003Creq_003E5__2;

			private Awaitable.Awaiter _003C_003Eu__1;

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

		public State<string> url;

		public State<bool> loading;

		public State<Texture2D> texture;

		public bool useCache;

		private static Dictionary<string, Texture2D> cache;

		private bool cached;

		private Debouncer debouncer;

		public ImageUrlViewable(string url)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadTexture_003Ed__8))]
		public void LoadTexture()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadTexture_003Ed__9))]
		public static Task<Texture2D> LoadTexture(string url, bool useCache = true)
		{
			return null;
		}
	}
}
