using System.Collections.Generic;
using ModApi.Levels.Scores;

namespace Assets.Scripts.Levels.Scores
{
	public class LevelScoreComparer : ILevelScoreComparer, IComparer<LevelScore>
	{
		public static readonly LevelScoreComparer AscendingComparer = new LevelScoreComparer(ascending: true);

		public static readonly LevelScoreComparer DescendingComparer = new LevelScoreComparer(ascending: false);

		private int _greaterThanResult;

		private int _lessThanResult;

		public bool IsAscendingComparer { get; }

		private LevelScoreComparer(bool ascending)
		{
			IsAscendingComparer = ascending;
			_greaterThanResult = (ascending ? 1 : (-1));
			_lessThanResult = ((!ascending) ? 1 : (-1));
		}

		public virtual int Compare(LevelScore x, LevelScore y)
		{
			if (x.Score > y.Score)
			{
				return _greaterThanResult;
			}
			if (x.Score < y.Score)
			{
				return _lessThanResult;
			}
			if (!(x.DateTime >= y.DateTime))
			{
				return 1;
			}
			return -1;
		}
	}
}
