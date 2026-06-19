using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XVersion
	{
		public ushort Major { get; }

		public ushort Minor { get; }

		public ushort Build { get; }

		public ushort Revision { get; }

		internal XVersion(XGamingRuntime.Interop.XVersion rawVersion)
		{
			Major = rawVersion.major;
			Minor = rawVersion.minor;
			Build = rawVersion.build;
			Revision = rawVersion.revision;
		}
	}
}
