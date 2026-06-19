using Unity.Collections;
using UnityEngine.Scripting;

namespace Pug.UnityExtensions
{
	[Preserve]
	public struct BitwiseDataStreamWriter
	{
		private StreamCompressionModel _compressionModel;

		private uint _bitBuffer;

		private int _bitIndex;

		public BitwiseDataStreamWriter(StreamCompressionModel compressionModel)
		{
			_compressionModel = compressionModel;
			_bitBuffer = 0u;
			_bitIndex = 0;
		}

		[Preserve]
		public void WriteBit(ref DataStreamWriter bitStream, bool value)
		{
			_bitBuffer |= (uint)((value ? 1 : 0) << _bitIndex);
			_bitIndex++;
			if (_bitIndex == 32)
			{
				Flush(ref bitStream);
			}
		}

		[Preserve]
		public void WriteByte(ref DataStreamWriter bitStream, byte value)
		{
			for (int i = 0; i < 8; i++)
			{
				WriteBit(ref bitStream, (value & (1 << i)) != 0);
			}
		}

		public void Flush(ref DataStreamWriter bitStream)
		{
			if (_bitIndex != 0)
			{
				bitStream.WritePackedUInt(_bitBuffer, in _compressionModel);
				_bitBuffer = 0u;
				_bitIndex = 0;
			}
		}
	}
}
