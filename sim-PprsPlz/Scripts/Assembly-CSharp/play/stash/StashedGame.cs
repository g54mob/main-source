using app.plat;
using data;
using haxe.lang;

namespace play.stash
{
	public class StashedGame : HxObject
	{
		public static int kStashVersion;

		public int stashVersion;

		public string gameVersion;

		public StashedGameScreen screen;

		public PlatformKind platformKind;

		public StashedDay day;

		public FactSet storyStateFacts;

		public StashedDayScreen dayScreen;

		public string endId;

		static StashedGame()
		{
		}

		public StashedGame(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StashedGame(PlatformKind platformKind_, StashedGameScreen screen_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_stash_StashedGame(StashedGame __hx_this, PlatformKind platformKind_, StashedGameScreen screen_)
		{
		}

		public virtual bool isValid()
		{
			return false;
		}

		public virtual string getSoakId()
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
	}
}
