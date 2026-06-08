namespace XGamingRuntime.Interop
{
	internal enum XTaskQueueDispatchMode : uint
	{
		Manual = 0u,
		ThreadPool = 1u,
		SerializedThreadPool = 2u,
		Immediate = 3u
	}
}
