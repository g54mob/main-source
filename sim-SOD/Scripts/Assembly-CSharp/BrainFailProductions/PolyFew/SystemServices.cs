using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BrainFailProductions.PolyFew
{
	public static class SystemServices
	{
		[Serializable]
		public struct RegexPatterns
		{
			public string netError;

			public string nullOrEmpty;

			public string generalError;

			public string apiMistmatch;

			public string parametersMismatch;

			public string nothing;
		}

		public struct MessagePatternPair
		{
			public string patternAppended { get; private set; }

			public string parsedMessage { get; private set; }

			public MessagePatternPair(string patternAppended, string parsedMessage)
			{
				this.patternAppended = null;
				this.parsedMessage = null;
			}
		}

		public class HTTPMethod
		{
			public enum HTTPMethods
			{
				POST = 0,
				GET = 1
			}

			public readonly string methodName;

			public HTTPMethod(HTTPMethods method)
			{
			}
		}

		public enum ImageFormat
		{
			PNG = 0,
			JPG = 1,
			EXR = 2
		}

		[CompilerGenerated]
		private sealed class _003CUnityAsyncGETRequest_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string encodedUrl;

			public int? timeout;

			public Dictionary<string, string> headers;

			public Action<string, long> callback;

			private UnityWebRequest _003CwebRequest_003E5__2;

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
			public _003CUnityAsyncGETRequest_003Ed__3(int _003C_003E1__state)
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
		private sealed class _003CUnityAsyncPOSTRequest_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string baseUrl;

			public int? timeout;

			public byte[] data;

			public Dictionary<string, string> headers;

			public Action<string, long> callback;

			private UnityWebRequest _003CwebRequest_003E5__2;

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
			public _003CUnityAsyncPOSTRequest_003Ed__6(int _003C_003E1__state)
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
		private sealed class _003C_003Ec__DisplayClass7_0
		{
			public HttpWebRequest request;

			public byte[] postData;

			public HttpWebResponse httpResponse;

			internal void _003CSendHTTPRequestAsync_003Eb__0()
			{
			}

			internal void _003CSendHTTPRequestAsync_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendHTTPRequestAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public byte[] postData;

			private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

			public string baseUrl;

			public Action<string, HttpStatusCode?> callback;

			public int? timeout;

			public HTTPMethod requestMethod;

			public Dictionary<string, string> header;

			public Dictionary<string, string> requestParameters;

			private TaskAwaiter _003C_003Eu__1;

			private byte[] _003CparamsData_003E5__2;

			private TaskAwaiter<Stream> _003C_003Eu__2;

			private TaskAwaiter<string> _003C_003Eu__3;

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
		private sealed class _003C_003Ec__DisplayClass9_0
		{
			public HttpWebResponse httpResponse;

			public HttpWebRequest request;

			internal void _003CAsyncResourceDownload_003Eb__0()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAsyncResourceDownload_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			private _003C_003Ec__DisplayClass9_0 _003C_003E8__1;

			public string resourceUrl;

			public Action<byte[], string, HttpStatusCode?> callback;

			public int? timeout;

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
		private struct _003CAsyncReachabilityCheck_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Action<bool> callback;

			public string testUrl;

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
		private struct _003CRunDelayedCommand_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public float secs;

			public Action command;

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
		private struct _003CWriteTextureAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ImageFormat format;

			public Texture2D texture;

			public string fileName;

			public string path;

			public Action<string> callback;

			private byte[] _003Cdata_003E5__2;

			private FileStream _003CfileStream_003E5__3;

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
		private struct _003CWriteBytesAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string fullPath;

			public byte[] data;

			public Action<string> callback;

			private FileStream _003CfileStream_003E5__2;

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

		public static RegexPatterns regexPatterns;

		private static void SetPatterns()
		{
		}

		[IteratorStateMachine(typeof(_003CUnityAsyncGETRequest_003Ed__3))]
		public static IEnumerator UnityAsyncGETRequest(string encodedUrl, Action<string, long> callback, int? timeout = null, Dictionary<string, string> headers = null)
		{
			return null;
		}

		public static void UnityBlockingGETRequest(string encodedUrl, Action<string, long> callback, int? timeout = null, Dictionary<string, string> headers = null)
		{
		}

		public static void UnityBlockingPOSTRequest(string baseUrl, Action<string, long> callback, byte[] data, int? timeout = null, Dictionary<string, string> headers = null)
		{
		}

		[IteratorStateMachine(typeof(_003CUnityAsyncPOSTRequest_003Ed__6))]
		public static IEnumerator UnityAsyncPOSTRequest(string baseUrl, Action<string, long> callback, byte[] data, int? timeout = null, Dictionary<string, string> headers = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendHTTPRequestAsync_003Ed__7))]
		public static Task SendHTTPRequestAsync(string baseUrl, HTTPMethod requestMethod, Action<string, HttpStatusCode?> callback, Dictionary<string, string> requestParameters, byte[] postData, string contentType, int? timeout = null, Dictionary<string, string> header = null)
		{
			return null;
		}

		public static void SendHTTPRequestBlocking(string baseUrl, HTTPMethod requestMethod, Action<string, HttpStatusCode?> callback, Dictionary<string, string> requestParameters, byte[] postData, string contentType, int? timeout = null, Dictionary<string, string> header = null)
		{
		}

		[AsyncStateMachine(typeof(_003CAsyncResourceDownload_003Ed__9))]
		public static Task AsyncResourceDownload(string resourceUrl, Action<byte[], string, HttpStatusCode?> callback, int? timeout = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAsyncReachabilityCheck_003Ed__10))]
		public static Task AsyncReachabilityCheck(string testUrl, Action<bool> callback)
		{
			return null;
		}

		public static void BlockingReachabilityCheck(string url, Action<bool> callback)
		{
		}

		public static MessagePatternPair ParseResponseMessage(string message)
		{
			return default(MessagePatternPair);
		}

		public static bool IsSuccessStatusCode(long statusCode)
		{
			return false;
		}

		public static string GetQueryStringFromKeyValues(Dictionary<string, string> parameters)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRunDelayedCommand_003Ed__17))]
		public static Task RunDelayedCommand(float secs, Action command)
		{
			return null;
		}

		public static byte[] ReadAllBytes(Stream source)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteTextureAsync_003Ed__19))]
		public static Task WriteTextureAsync(Texture2D texture, ImageFormat format, string fileName, string path, Action<string> callback)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteBytesAsync_003Ed__20))]
		public static Task WriteBytesAsync(byte[] data, string fullPath, Action<string> callback)
		{
			return null;
		}
	}
}
