using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerEvent
	{
		public int Result { get; private set; }

		public string ErrorMessage { get; private set; }

		public object Context { get; private set; }

		public XblMultiplayerEventType EventType { get; private set; }

		public XblMultiplayerEventArgsHandle EventArgsHandle { get; private set; }

		public XblMultiplayerSessionType SessionType { get; private set; }

		internal XblMultiplayerEvent(XGamingRuntime.Interop.XblMultiplayerEvent interopStruct)
		{
		}
	}
}
