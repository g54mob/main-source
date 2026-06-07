using Coherence.Brook;

namespace Coherence.Core
{
	internal class SequenceBuffer<T> where T : class
	{
		private const int MinBufferSize = 64;

		private const int MaxBufferSize = 4096;

		private readonly T[] messages;

		protected int Size => 0;

		protected SequenceBuffer(int size)
		{
		}

		protected T Find(MessageID id)
		{
			return null;
		}

		protected void Insert(MessageID id, T data)
		{
		}

		protected void Remove(MessageID id)
		{
		}

		private int Index(MessageID id)
		{
			return 0;
		}

		protected void ClearBuffer()
		{
		}

		private void AssertValidSize(int size)
		{
		}

		private int NextPowerOfTwo(int x)
		{
			return 0;
		}
	}
}
