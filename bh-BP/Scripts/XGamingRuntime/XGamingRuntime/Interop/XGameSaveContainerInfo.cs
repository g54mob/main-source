namespace XGamingRuntime.Interop
{
	internal struct XGameSaveContainerInfo
	{
		internal UTF8StringPtr name;

		internal UTF8StringPtr displayName;

		internal uint blobCount;

		internal ulong totalSize;

		internal TimeT lastModifiedTime;

		internal bool NeedsSync;
	}
}
