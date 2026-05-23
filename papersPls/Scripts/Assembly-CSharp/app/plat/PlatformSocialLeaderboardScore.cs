using haxe.lang;

namespace app.plat
{
	public class PlatformSocialLeaderboardScore : HxObject
	{
		public int score;

		public int time;

		public int rank;

		public PlatformSocialLeaderboardScore(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformSocialLeaderboardScore(int score_, int time_, object rank_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformSocialLeaderboardScore(PlatformSocialLeaderboardScore __hx_this, int score_, int time_, object rank_)
		{
		}

		public static PlatformSocialLeaderboardScore make(int score_, int time_, int rank_)
		{
			return null;
		}

		public virtual bool matches(PlatformSocialLeaderboardScore other)
		{
			return false;
		}

		public virtual string toString()
		{
			return null;
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
