using haxe.lang;

namespace play
{
	public class RankedScoreEntry : HxObject
	{
		public string leaderboardId;

		public int score;

		public int time;

		public int rank;

		public RankedScoreEntry(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public RankedScoreEntry(string leaderboardId_, int score_, int time_, int rank_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_RankedScoreEntry(RankedScoreEntry __hx_this, string leaderboardId_, int score_, int time_, int rank_)
		{
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
