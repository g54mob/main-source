using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionReferenceUri
	{
		public string Value { get; private set; }

		internal XblMultiplayerSessionReferenceUri(XGamingRuntime.Interop.XblMultiplayerSessionReferenceUri interopStruct)
		{
			Value = interopStruct.GetValue();
		}
	}
}
