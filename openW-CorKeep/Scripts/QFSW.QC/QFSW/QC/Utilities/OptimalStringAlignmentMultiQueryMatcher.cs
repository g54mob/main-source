using System;
using System.Runtime.CompilerServices;

namespace QFSW.QC.Utilities
{
	public class OptimalStringAlignmentMultiQueryMatcher
	{
		public const int MODIFICATION_COST_UNIT = 65536;

		private const int REMOVE_AT_START_COST_UNIT = 1;

		private const int MAX_SCORE = 1073741823;

		private char[] _sourceBuffer;

		private char[] _queryBuffer;

		private int[] _dp;

		public int Match(string source, string query, bool caseSensitive)
		{
			if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(query))
			{
				return 1073741823;
			}
			PrepareSourceBuffer(source, caseSensitive);
			int num = 0;
			ReadOnlySpan<char> readOnlySpan = query.AsSpan();
			while (!readOnlySpan.IsEmpty)
			{
				int i;
				for (i = 0; i < readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[i]); i++)
				{
				}
				if (i >= readOnlySpan.Length)
				{
					break;
				}
				readOnlySpan = readOnlySpan.Slice(i);
				int j;
				for (j = 0; j < readOnlySpan.Length && !char.IsWhiteSpace(readOnlySpan[j]); j++)
				{
				}
				ReadOnlySpan<char> queryWord = readOnlySpan.Slice(0, j);
				num += ComputeDistance(queryWord, caseSensitive, source.Length);
				if (num >= 1073741823)
				{
					return 1073741823;
				}
				readOnlySpan = readOnlySpan.Slice(j);
			}
			return num;
		}

		private void PrepareSourceBuffer(string source, bool caseSensitive)
		{
			EnsureCapacity(ref _sourceBuffer, source.Length);
			for (int i = 0; i < source.Length; i++)
			{
				_sourceBuffer[i] = (caseSensitive ? source[i] : char.ToLowerInvariant(source[i]));
			}
		}

		private int ComputeDistance(ReadOnlySpan<char> queryWord, bool caseSensitive, int sourceLength)
		{
			int length = queryWord.Length;
			EnsureCapacity(ref _queryBuffer, length);
			for (int i = 0; i < length; i++)
			{
				_queryBuffer[i] = (caseSensitive ? queryWord[i] : char.ToLowerInvariant(queryWord[i]));
			}
			int num = length + 1;
			EnsureCapacity(ref _dp, num * 3);
			int num2 = 0;
			int num3 = num;
			int num4 = num * 2;
			for (int j = 0; j <= length; j++)
			{
				_dp[num3 + j] = j * 65536;
			}
			for (int k = 1; k <= sourceLength; k++)
			{
				_dp[num4] = k;
				char c = _sourceBuffer[k - 1];
				for (int l = 1; l <= length; l++)
				{
					char c2 = _queryBuffer[l - 1];
					int num5 = ((c != c2) ? 65536 : 0);
					int num6 = 1073741823;
					int num7 = _dp[num3 + (l - 1)] + num5;
					if (num7 < num6)
					{
						num6 = num7;
					}
					int num8 = ((l != length) ? 65536 : 0);
					int num9 = _dp[num3 + l] + num8;
					if (num9 < num6)
					{
						num6 = num9;
					}
					int num10 = _dp[num4 + (l - 1)] + 65536;
					if (num10 < num6)
					{
						num6 = num10;
					}
					if (k > 1 && l > 1 && c == _queryBuffer[l - 2] && _sourceBuffer[k - 2] == c2)
					{
						int num11 = _dp[num2 + (l - 2)] + 65536;
						if (num11 < num6)
						{
							num6 = num11;
						}
					}
					_dp[num4 + l] = num6;
				}
				int num12 = num2;
				num2 = num3;
				num3 = num4;
				num4 = num12;
			}
			return _dp[num3 + length];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnsureCapacity<T>(ref T[] array, int requiredLength)
		{
			if (array == null || array.Length < requiredLength)
			{
				int num = ((array == null) ? requiredLength : Math.Max(requiredLength, array.Length * 2));
				array = new T[num];
			}
		}
	}
}
