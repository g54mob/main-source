using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API
{
	internal static class WebRequestRunner
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunDownload_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public string url;

			public RequestHandle<Result> handle;

			public ProgressHandle progressHandle;

			public Stream downloadTo;

			private Result _003Cresult_003E5__2;

			private WebRequest _003Crequest_003E5__3;

			private WebResponse _003Cresponse_003E5__4;

			private TaskAwaiter<WebResponse> _003C_003Eu__1;

			private TaskAwaiter<Result> _003C_003Eu__2;

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
		private struct _003CExecute_003Ed__3<TResult> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<TResult>> _003C_003Et__builder;

			public RequestHandle<ResultAnd<TResult>> handle;

			public ProgressHandle progressHandle;

			public WebRequestConfig config;

			private WebRequest _003Crequest_003E5__2;

			private TaskAwaiter<WebRequest> _003C_003Eu__1;

			private TaskAwaiter<WebResponse> _003C_003Eu__2;

			private TaskAwaiter<ResultAnd<TResult>> _003C_003Eu__3;

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
		private struct _003CProcessDownloadResponse_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public WebResponse response;

			public string url;

			public WebRequest request;

			private Stream _003Cstream_003E5__2;

			private string _003CcompleteRequestLog_003E5__3;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CProcessResponse_003Ed__7<TResult> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<TResult>> _003C_003Et__builder;

			public WebResponse response;

			public WebRequestConfig config;

			public WebRequest request;

			private Stream _003Cstream_003E5__2;

			private TaskAwaiter<ResultAnd<TResult>> _003C_003Eu__1;

			private TaskAwaiter<Result> _003C_003Eu__2;

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
		private struct _003CGetDownloadResponse_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<WebResponse> _003C_003Et__builder;

			public WebRequest request;

			public Stream downloadStream;

			public ProgressHandle progressHandle;

			private WebResponse _003Cresponse_003E5__2;

			private TaskAwaiter<WebResponse> _003C_003Eu__1;

			private Stream _003CresponseStream_003E5__3;

			private long _003CtotalSize_003E5__4;

			private byte[] _003Cbuffer_003E5__5;

			private long _003CbytesDownloaded_003E5__6;

			private long _003CbytesDownloadedForThisSample_003E5__7;

			private Stopwatch _003CprogressMeasure_003E5__8;

			private Stopwatch _003CyieldMeasure_003E5__9;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__2;

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
		private struct _003CGetUploadResponse_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<WebResponse> _003C_003Et__builder;

			public WebRequest request;

			public WebRequestConfig config;

			public ProgressHandle progressHandle;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<WebResponse> _003C_003Eu__2;

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
		private struct _003CBuildWebRequest_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<WebRequest> _003C_003Et__builder;

			public WebRequestConfig config;

			private HttpWebRequest _003Crequest_003E5__2;

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
		private struct _003CSetupUrlEncodedRequest_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebRequestConfig config;

			public WebRequest request;

			private Stream _003CrequestStream_003E5__2;

			private StreamWriter _003Cwriter_003E5__3;

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
		private struct _003CSetupMultipartRequest_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebRequest request;

			public WebRequestConfig config;

			public ProgressHandle progressHandle;

			private Stream _003CrequestStream_003E5__2;

			private Stream _003Ccontent_003E5__3;

			private TaskAwaiter<Stream> _003C_003Eu__1;

			private int _003CbytesRead_003E5__4;

			private long _003CtotalBytesRead_003E5__5;

			private long _003CbytesUploadedForThisSample_003E5__6;

			private Stopwatch _003Cstopwatch_003E5__7;

			private byte[] _003Cbuffer_003E5__8;

			private TaskAwaiter _003C_003Eu__2;

			private TaskAwaiter<int> _003C_003Eu__3;

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
		private struct _003CFormatResult_003Ed__18<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<T>> _003C_003Et__builder;

			public Stream response;

			private TaskAwaiter<T> _003C_003Eu__1;

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
		private struct _003CHttpStatusCodeError_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public Stream response;

			public int status;

			public string requestLog;

			private TaskAwaiter<ResultAnd<ErrorObject>> _003C_003Eu__1;

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

		public static RequestHandle<Result> Download(string url, Stream downloadTo, ProgressHandle progressHandle)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRunDownload_003Ed__1))]
		private static Task<Result> RunDownload(string url, Stream downloadTo, RequestHandle<Result> handle, ProgressHandle progressHandle)
		{
			return null;
		}

		public static RequestHandle<ResultAnd<T>> Upload<T>(WebRequestConfig config, ProgressHandle progressHandle)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CExecute_003Ed__3<>))]
		public static Task<ResultAnd<TResult>> Execute<TResult>(WebRequestConfig config, RequestHandle<ResultAnd<TResult>> handle, ProgressHandle progressHandle)
		{
			return null;
		}

		private static void LogRequestBeingSent(this WebRequest request, WebRequestConfig config)
		{
		}

		private static void LogRequestBeingAborted(this WebRequest request, WebRequestConfig config)
		{
		}

		[AsyncStateMachine(typeof(_003CProcessDownloadResponse_003Ed__6))]
		private static Task<Result> ProcessDownloadResponse(WebRequest request, WebResponse response, string url)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CProcessResponse_003Ed__7<>))]
		private static Task<ResultAnd<TResult>> ProcessResponse<TResult>(WebRequest request, WebResponse response, WebRequestConfig config)
		{
			return null;
		}

		private static bool IsSuccessStatusCode(int code)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CGetDownloadResponse_003Ed__9))]
		private static Task<WebResponse> GetDownloadResponse(this WebRequest request, Stream downloadStream, ProgressHandle progressHandle)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetUploadResponse_003Ed__10))]
		private static Task<WebResponse> GetUploadResponse(this WebRequest request, WebRequestConfig config, ProgressHandle progressHandle)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CBuildWebRequest_003Ed__11))]
		private static Task<WebRequest> BuildWebRequest(WebRequestConfig config, ProgressHandle progressHandle)
		{
			return null;
		}

		private static WebRequest BuildWebRequestForUpload(WebRequestConfig config, ProgressHandle progressHandle)
		{
			return null;
		}

		private static WebRequest BuildWebRequestForDownload(string url)
		{
			return null;
		}

		private static void SetModioHeaders(this WebRequest webRequest)
		{
		}

		private static void SetConfigHeaders(this WebRequest request, WebRequestConfig config)
		{
		}

		[AsyncStateMachine(typeof(_003CSetupUrlEncodedRequest_003Ed__16))]
		private static Task SetupUrlEncodedRequest(this WebRequest request, WebRequestConfig config)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSetupMultipartRequest_003Ed__17))]
		private static Task SetupMultipartRequest(this WebRequest request, WebRequestConfig config, ProgressHandle progressHandle)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CFormatResult_003Ed__18<>))]
		public static Task<ResultAnd<T>> FormatResult<T>(Stream response)
		{
			return null;
		}

		private static T Deserialize<T>(Stream content)
		{
			return default(T);
		}

		private static bool IsJson(string input)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CHttpStatusCodeError_003Ed__21))]
		private static Task<Result> HttpStatusCodeError(Stream response, string requestLog, int status)
		{
			return null;
		}

		private static ResultAnd<TResult> TimeOutError<TResult>(WebRequestConfig requestConfig, WebException ex)
		{
			return null;
		}

		private static string GenerateLogForWebRequestConfig(WebRequestConfig config)
		{
			return null;
		}

		private static string GenerateLogForRequestMessage(WebRequest request)
		{
			return null;
		}

		private static string GenerateLogForResponseMessage(WebResponse response)
		{
			return null;
		}

		private static string GenerateLogForStatusCode(int code)
		{
			return null;
		}

		private static string GenerateErrorsIntoSingleLog(Dictionary<string, string> errors)
		{
			return null;
		}
	}
}
