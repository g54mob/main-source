using System.Buffers;
using System.Collections.Generic;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct SimSessionKeyboardChange : NetMessage, IMemoryPackable<SimSessionKeyboardChange>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class SimSessionKeyboardChangeFormatter : MemoryPackFormatter<SimSessionKeyboardChange>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionKeyboardChange value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref SimSessionKeyboardChange value)
			{
			}
		}

		public int[] down;

		public int[] up;

		public static bool TryDiff(Dictionary<int, bool> last, Dictionary<int, bool> current, out SimSessionKeyboardChange msg)
		{
			msg = default(SimSessionKeyboardChange);
			return false;
		}

		static SimSessionKeyboardChange()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionKeyboardChange value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref SimSessionKeyboardChange value)
		{
		}
	}
}
