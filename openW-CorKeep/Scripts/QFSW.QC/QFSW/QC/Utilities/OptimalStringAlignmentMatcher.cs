using System;

namespace QFSW.QC.Utilities
{
	public class OptimalStringAlignmentMatcher
	{
		public const int MODIFICATION_COST_UNIT = 65536;

		private const int REMOVE_AT_START_COST_UNIT = 1;

		private int[][] _dp = new int[3][];

		private char[] _sourceBuffer;

		private char[] _queryBuffer;

		public int Match(string source, string query, bool caseSensitive)
		{
			if (_sourceBuffer == null || _sourceBuffer.Length < source.Length)
			{
				_sourceBuffer = new char[source.Length];
			}
			for (int i = 0; i < source.Length; i++)
			{
				_sourceBuffer[i] = (caseSensitive ? source[i] : char.ToLower(source[i]));
			}
			if (_queryBuffer == null || _queryBuffer.Length < query.Length)
			{
				_queryBuffer = new char[query.Length];
			}
			for (int j = 0; j < query.Length; j++)
			{
				_queryBuffer[j] = (caseSensitive ? query[j] : char.ToLower(query[j]));
			}
			for (int k = 0; k < 3; k++)
			{
				if (_dp[k] == null || _dp[k].Length < query.Length + 1)
				{
					_dp[k] = new int[query.Length + 1];
				}
			}
			for (int l = 0; l <= query.Length; l++)
			{
				_dp[0][l] = l * 65536;
			}
			for (int m = 1; m <= source.Length; m++)
			{
				int[] array = _dp[2];
				_dp[2] = _dp[1];
				_dp[1] = _dp[0];
				_dp[0] = array;
				_dp[0][0] = m;
				for (int n = 1; n <= query.Length; n++)
				{
					int val = int.MaxValue;
					if (_sourceBuffer[m - 1] == _queryBuffer[n - 1])
					{
						val = Math.Min(val, _dp[1][n - 1]);
					}
					val = ((n != query.Length) ? Math.Min(val, _dp[1][n] + 65536) : Math.Min(val, _dp[1][n]));
					val = Math.Min(val, _dp[0][n - 1] + 65536);
					val = Math.Min(val, _dp[1][n - 1] + 65536);
					if (m > 1 && n > 1 && _sourceBuffer[m - 1] == _queryBuffer[n - 2] && _sourceBuffer[m - 2] == _queryBuffer[n - 1])
					{
						val = Math.Min(val, _dp[2][n - 2] + 65536);
					}
					_dp[0][n] = val;
				}
			}
			return _dp[0][query.Length];
		}
	}
}
