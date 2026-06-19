using Unity.Collections;
using UnityEngine.Scripting;

namespace Pug.UnityExtensions
{
	[Preserve]
	public struct BitwiseDataStreamReader
	{
		private StreamCompressionModel _compressionModel;

		private uint _bitBuffer;

		private int _bitIndex;

		public BitwiseDataStreamReader(StreamCompressionModel compressionModel)
		{
			_compressionModel = compressionModel;
			_bitBuffer = 0u;
			_bitIndex = 32;
		}

		[Preserve]
		public bool ReadBit(ref DataStreamReader bitStream)
		{
			if (_bitIndex == 32)
			{
				_bitBuffer = bitStream.ReadPackedUInt(in _compressionModel);
				_bitIndex = 0;
			}
			bool result = (_bitBuffer & (uint)(1 << _bitIndex)) != 0;
			_bitIndex++;
			return result;
		}

		[Preserve]
		public byte ReadByte(ref DataStreamReader bitStream)
		{
			byte b = 0;
			for (int i = 0; i < 8; i++)
			{
				if (ReadBit(ref bitStream))
				{
					b |= (byte)(1 << i);
				}
			}
			return b;
		}
	}
}
