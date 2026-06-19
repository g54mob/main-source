using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal record Range(Index Start, Index End)
	{
		public static Range All => Index.Start..Index.End;

		public override string ToString()
		{
			return $"{Start}..{End}";
		}

		public static Range StartAt(Index start)
		{
			return start..Index.End;
		}

		public static Range EndAt(Index end)
		{
			return Index.Start..end;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int Offset, int Length) GetOffsetAndLength(int length)
		{
			Index start = Start;
			int num = ((!start.IsFromEnd) ? start.Value : (length - start.Value));
			Index end = End;
			int num2 = ((!end.IsFromEnd) ? end.Value : (length - end.Value));
			if ((uint)num2 > (uint)length || (uint)num > (uint)num2)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return (Offset: num, Length: num2 - num);
		}
	}
}
