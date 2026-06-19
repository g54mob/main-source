using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionReference
	{
		public string Scid { get; }

		public string SessionTemplateName { get; }

		public string SessionName { get; }

		internal XblMultiplayerSessionReference(XGamingRuntime.Interop.XblMultiplayerSessionReference interopStruct)
		{
			Scid = interopStruct.GetScid();
			SessionTemplateName = interopStruct.GetSessionTemplateName();
			SessionName = interopStruct.GetSessionName();
		}
	}
}
