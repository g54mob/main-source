namespace XGamingRuntime.Interop
{
	internal struct XVersion
	{
		internal readonly ushort major;

		internal readonly ushort minor;

		internal readonly ushort build;

		internal readonly ushort revision;

		internal XVersion(XGamingRuntime.XVersion publicObject)
		{
			major = 0;
			minor = 0;
			build = 0;
			revision = 0;
		}
	}
}
