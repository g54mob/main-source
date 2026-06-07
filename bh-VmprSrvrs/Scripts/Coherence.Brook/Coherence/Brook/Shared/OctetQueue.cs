namespace Coherence.Brook.Shared
{
	public sealed class OctetQueue
	{
		private int head;

		private int tail;

		private byte[] buffer;

		public int Length { get; private set; }

		public OctetQueue(int capacity)
		{
		}

		public void Enqueue(byte[] buffer, int offset, int size)
		{
		}

		public int Peek(byte[] buffer, int offset, int size)
		{
			return 0;
		}

		public void Skip(int size)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
