using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveBlobInfo
	{
		public string Name { get; }

		public uint Size { get; }

		internal XGameSaveBlobInfo(XGamingRuntime.Interop.XGameSaveBlobInfo interopHandle)
		{
			Name = interopHandle.Name.GetString();
			Size = interopHandle.Size;
		}
	}
}
