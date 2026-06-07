namespace Epic.OnlineServices.P2P
{
	public class SocketId : ISettable
	{
		public string SocketName { get; set; }

		internal void Set(SocketIdInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
