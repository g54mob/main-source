using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerEvent
	{
		public int Result { get; }

		public string ErrorMessage { get; }

		public object Context { get; }

		public XblMultiplayerEventType EventType { get; }

		public XblMultiplayerEventArgsHandle EventArgsHandle { get; }

		public XblMultiplayerSessionType SessionType { get; }

		internal XblMultiplayerEvent(XGamingRuntime.Interop.XblMultiplayerEvent interopStruct)
		{
			Result = interopStruct.Result;
			ErrorMessage = interopStruct.ErrorMessage.GetString();
			EventType = interopStruct.EventType;
			EventArgsHandle = new XblMultiplayerEventArgsHandle(interopStruct.EventArgsHandle);
			SessionType = interopStruct.SessionType;
			Context = null;
			if (interopStruct.Context != IntPtr.Zero)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(interopStruct.Context);
				Context = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
