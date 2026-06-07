namespace Telepathy
{
	public abstract class Common
	{
		public bool NoDelay;

		public readonly int MaxMessageSize;

		public int SendTimeout;

		public int ReceiveTimeout;

		protected Common(int MaxMessageSize)
		{
		}
	}
}
