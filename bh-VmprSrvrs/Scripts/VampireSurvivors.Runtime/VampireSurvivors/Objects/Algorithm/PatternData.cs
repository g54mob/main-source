using System;
using System.Collections.Generic;

namespace VampireSurvivors.Objects.Algorithm
{
	[Serializable]
	public class PatternData
	{
		public int num;

		public int[][] pattern;

		public List<int> neighboursTop;

		public List<int> neighboursRight;

		public List<int> neighboursBottom;

		public List<int> neighboursLeft;

		public PatternData(int num, int[][] pattern, List<int> neighboursTop, List<int> neighboursRight, List<int> neighboursBottom, List<int> neighboursLeft)
		{
		}
	}
}
