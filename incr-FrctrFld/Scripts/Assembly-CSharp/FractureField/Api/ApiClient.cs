using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace FractureField.Api
{
	public class ApiClient
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass21_0<T>
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CAwaitableGet_003Eb__1_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<UnityWebRequest> _003C_003Et__builder;

				public _003C_003Ec__DisplayClass21_0<T> _003C_003E4__this;

				private TaskAwaiter<UnityWebRequest> _003C_003Eu__1;

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

			public string endpoint;

			internal object _003CAwaitableGet_003Eb__0()
			{
				return null;
			}

			[AsyncStateMachine(typeof(_003C_003Ec__DisplayClass21_0<>._003C_003CAwaitableGet_003Eb__1_003Ed))]
			internal Task<UnityWebRequest> _003CAwaitableGet_003Eb__1()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass24_0<T>
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CAwaitablePost_003Eb__1_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<UnityWebRequest> _003C_003Et__builder;

				public _003C_003Ec__DisplayClass24_0<T> _003C_003E4__this;

				private TaskAwaiter<UnityWebRequest> _003C_003Eu__1;

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

			public string endpoint;

			public object data;

			internal object _003CAwaitablePost_003Eb__0()
			{
				return null;
			}

			[AsyncStateMachine(typeof(_003C_003Ec__DisplayClass24_0<>._003C_003CAwaitablePost_003Eb__1_003Ed))]
			internal Task<UnityWebRequest> _003CAwaitablePost_003Eb__1()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass29_0
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CAwaitableDelete_003Eb__2_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<UnityWebRequest> _003C_003Et__builder;

				public _003C_003Ec__DisplayClass29_0 _003C_003E4__this;

				private TaskAwaiter<UnityWebRequest> _003C_003Eu__1;

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

			public string endpoint;

			public Action onSuccess;

			internal object _003CAwaitableDelete_003Eb__0()
			{
				return null;
			}

			[AsyncStateMachine(typeof(_003C_003CAwaitableDelete_003Eb__2_003Ed))]
			internal Task<UnityWebRequest> _003CAwaitableDelete_003Eb__2()
			{
				return null;
			}

			internal void _003CAwaitableDelete_003Eb__1(object _)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitableDelete_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string endpoint;

			public Action onSuccess;

			public bool allowRetry;

			private _003C_003Ec__DisplayClass29_0 _003C_003E8__1;

			public Action<Exception> onError;

			public Action onFinally;

			private TaskAwaiter<ApiResponse<object>> _003C_003Eu__1;

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
		private struct _003CAwaitableGet_003Ed__21<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string endpoint;

			public bool allowRetry;

			private _003C_003Ec__DisplayClass21_0<T> _003C_003E8__1;

			public Action<T> onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

			private TaskAwaiter<ApiResponse<T>> _003C_003Eu__1;

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
		private struct _003CAwaitablePost_003Ed__24<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string endpoint;

			public object data;

			public bool allowRetry;

			private _003C_003Ec__DisplayClass24_0<T> _003C_003E8__1;

			public Action<T> onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

			private TaskAwaiter<ApiResponse<T>> _003C_003Eu__1;

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
		private struct _003CDelete_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public string endpoint;

			public Action onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

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
		private sealed class _003CDeleteCoroutine_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string endpoint;

			public Action onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

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
			public _003CDeleteCoroutine_003Ed__28(int _003C_003E1__state)
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
		private struct _003CExecuteRequestAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<UnityWebRequest> _003C_003Et__builder;

			public UnityWebRequest request;

			private TaskAwaiter<bool> _003C_003Eu__1;

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
		private struct _003CGet_003Ed__22<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public string endpoint;

			public Action<T> onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

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
		private sealed class _003CGetCoroutine_003Ed__20<T> : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string endpoint;

			public Action<T> onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

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
			public _003CGetCoroutine_003Ed__20(int _003C_003E1__state)
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
		private struct _003CHandleRequestWithRetry_003Ed__17<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ApiResponse<T>> _003C_003Et__builder;

			public Func<Task<UnityWebRequest>> createRequest;

			public bool allowRetry;

			private UnityWebRequest _003Crequest_003E5__2;

			private TaskAwaiter<UnityWebRequest> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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
		private struct _003CPost_003Ed__25<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public string endpoint;

			public object data;

			public Action<T> onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

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
		private struct _003CPost_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public string endpoint;

			public object data;

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
		private struct _003CPost_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public string endpoint;

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
		private sealed class _003CPostCoroutine_003Ed__23<T> : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string endpoint;

			public object data;

			public Action<T> onSuccess;

			public Action<Exception> onError;

			public Action onFinally;

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
			public _003CPostCoroutine_003Ed__23(int _003C_003E1__state)
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
		private struct _003CReauthenticateAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		private const bool UseLocalhost = false;

		private static string _baseUrl;

		public static bool IsBaseURLSet;

		private static Func<string> _getAuthTokenFunc;

		private static Func<Task<bool>> _reauthenticateFunc;

		public static LogLevel LogLevel { get; }

		public static void SetBaseURL(string url)
		{
		}

		public static void SetAuthTokenProvider(Func<string> getAuthTokenFunc)
		{
		}

		public static void SetReauthenticateProvider(Func<Task<bool>> reauthenticateFunc)
		{
		}

		private static string GetAuthToken()
		{
			return null;
		}

		private static void SetupRequest(UnityWebRequest request)
		{
		}

		private static void SetHeaders(UnityWebRequest request)
		{
		}

		private static void SetAuthToken(UnityWebRequest request)
		{
		}

		private static ApiResponse<T> HandleResponse<T>(UnityWebRequest request)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CExecuteRequestAsync_003Ed__16))]
		private static Task<UnityWebRequest> ExecuteRequestAsync(UnityWebRequest request)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CHandleRequestWithRetry_003Ed__17<>))]
		private static Task<ApiResponse<T>> HandleRequestWithRetry<T>(Func<Task<UnityWebRequest>> createRequest, bool allowRetry = true)
		{
			return null;
		}

		private static void HandleCallbacks<T>(ApiResponse<T> response, string endpoint, Action<T> onSuccess, Action<Exception> onError, Action onFinally)
		{
		}

		[AsyncStateMachine(typeof(_003CReauthenticateAsync_003Ed__19))]
		private static Task<bool> ReauthenticateAsync()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetCoroutine_003Ed__20<>))]
		public static IEnumerator GetCoroutine<T>(string endpoint, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitableGet_003Ed__21<>))]
		public static Task AwaitableGet<T>(string endpoint, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null, bool allowRetry = true)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGet_003Ed__22<>))]
		public static void Get<T>(string endpoint, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
		}

		[IteratorStateMachine(typeof(_003CPostCoroutine_003Ed__23<>))]
		public static IEnumerator PostCoroutine<T>(string endpoint, object data = null, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitablePost_003Ed__24<>))]
		public static Task AwaitablePost<T>(string endpoint, object data = null, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null, bool allowRetry = true)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPost_003Ed__25<>))]
		public static void Post<T>(string endpoint, object data, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
		}

		[AsyncStateMachine(typeof(_003CPost_003Ed__26))]
		public static void Post(string endpoint, object data)
		{
		}

		[AsyncStateMachine(typeof(_003CPost_003Ed__27))]
		public static void Post(string endpoint)
		{
		}

		[IteratorStateMachine(typeof(_003CDeleteCoroutine_003Ed__28))]
		public static IEnumerator DeleteCoroutine(string endpoint, Action onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitableDelete_003Ed__29))]
		public static Task AwaitableDelete(string endpoint, Action onSuccess = null, Action<Exception> onError = null, Action onFinally = null, bool allowRetry = true)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDelete_003Ed__30))]
		public static void Delete(string endpoint, Action onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
		}
	}
}
