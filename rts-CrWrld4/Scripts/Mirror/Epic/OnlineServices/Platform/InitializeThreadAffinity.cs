namespace Epic.OnlineServices.Platform
{
	public class InitializeThreadAffinity : ISettable
	{
		public ulong NetworkWork { get; set; }

		public ulong StorageIo { get; set; }

		public ulong WebSocketIo { get; set; }

		public ulong P2PIo { get; set; }

		public ulong HttpRequestIo { get; set; }

		internal void Set(InitializeThreadAffinityInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
