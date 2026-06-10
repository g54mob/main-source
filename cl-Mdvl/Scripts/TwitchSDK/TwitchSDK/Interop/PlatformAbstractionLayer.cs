using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TwitchSDK.Interop
{
	public abstract class PlatformAbstractionLayer : BaseDisposable
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void PALCall(IntPtr thisPtr, int call, IntPtr payload);

		private GCHandle HandleToMyself;

		private PALCall DoPALCallDelegate = DoPALCall;

		internal IntPtr Native { get; private set; }

		private void DoPALCall_Autogen(int call, IMarshallable p)
		{
			switch (call)
			{
			case 1126061481:
				((WebRequestRequest)p).ReturnTask((Func<WebRequestRequest, Task<WebRequestResult>>)WebRequest);
				break;
			case -764117084:
				((SleepRequest)p).ReturnTask((Func<SleepRequest, Task>)Sleep);
				break;
			case 1884918045:
				((ReadFileRequest)p).ReturnTask((Func<ReadFileRequest, Task<string>>)ReadFile);
				break;
			case 981515029:
				((WriteFileRequest)p).ReturnTask((Func<WriteFileRequest, Task>)WriteFile);
				break;
			case -1432180053:
				((LogRequest)p).ReturnTask((Func<LogRequest, Task>)Log);
				break;
			case -2108203796:
				((CreateWebSocketRequest)p).ReturnTask((Func<CreateWebSocketRequest, Task<int>>)CreateWebSocket);
				break;
			case -1797785895:
				((SendWebSocketMessageRequest)p).ReturnTask((Func<SendWebSocketMessageRequest, Task>)SendWebSocketMessage);
				break;
			case 1978333561:
				((RecvWebSocketMessageRequest)p).ReturnTask((Func<RecvWebSocketMessageRequest, Task<string>>)RecvWebSocketMessage);
				break;
			case 491657886:
				((CloseWebSocketRequest)p).ReturnTask((Func<CloseWebSocketRequest, Task>)CloseWebSocket);
				break;
			default:
				throw new Exception("Unknown PAL call code. Probably a version mismatch between core library and .NET wrapper.");
			}
		}

		protected abstract Task<WebRequestResult> WebRequest(WebRequestRequest req);

		protected abstract Task Sleep(SleepRequest req);

		protected abstract Task<string> ReadFile(ReadFileRequest req);

		protected abstract Task WriteFile(WriteFileRequest req);

		protected abstract Task Log(LogRequest req);

		protected abstract Task<int> CreateWebSocket(CreateWebSocketRequest req);

		protected abstract Task SendWebSocketMessage(SendWebSocketMessageRequest req);

		protected abstract Task<string> RecvWebSocketMessage(RecvWebSocketMessageRequest req);

		protected abstract Task CloseWebSocket(CloseWebSocketRequest req);

		public PlatformAbstractionLayer()
		{
			HandleToMyself = GCHandle.Alloc(this, GCHandleType.Normal);
			Native = NativeApi.ProxyPAL_new(GCHandle.ToIntPtr(HandleToMyself), DoPALCallDelegate);
		}

		[MonoPInvokeCallback(typeof(PALCall))]
		private static void DoPALCall(IntPtr thisPtr, int call, IntPtr payload)
		{
			((PlatformAbstractionLayer)GCHandle.FromIntPtr(thisPtr).Target).DoPALCall(call, payload);
		}

		private void DoPALCall(int call, IntPtr payload)
		{
			IMarshallable p = Types.Unmarshal(payload);
			DoPALCall_Autogen(call, p);
		}

		protected override void DisposeUnmanaged()
		{
			NativeApi.ProxyPAL_Dispose(Native);
			HandleToMyself.Free();
			Native = IntPtr.Zero;
		}
	}
}
