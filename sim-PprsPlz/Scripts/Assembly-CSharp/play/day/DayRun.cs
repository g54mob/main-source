using app.plat;
using data;
using haxe.lang;

namespace play.day
{
	public class DayRun : HxObject
	{
		public Db db;

		public StoryState storyState;

		public Settings settings;

		public PlatformKind platformKind;

		public FaceCycler faceCycler;

		public int storySeed;

		public DayRun(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DayRun(Db db_, StoryState storyState_, Settings settings_, PlatformKind platformKind_, FaceCycler faceCycler_, int storySeed_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_DayRun(DayRun __hx_this, Db db_, StoryState storyState_, Settings settings_, PlatformKind platformKind_, FaceCycler faceCycler_, int storySeed_)
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
