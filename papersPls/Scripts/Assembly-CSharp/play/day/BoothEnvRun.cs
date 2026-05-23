using data;
using haxe.lang;

namespace play.day
{
	public class BoothEnvRun : HxObject
	{
		public Db db;

		public StoryState storyState;

		public FaceCycler faceCycler;

		public NameCycler nameCycler;

		public Shape layoutShape;

		public Settings settings;

		public AlltimeStats alltimeStats;

		public BoothEnvRun(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BoothEnvRun(Db db_, StoryState storyState_, Settings settings_, Shape layoutShape_, FaceCycler faceCycler_, NameCycler nameCycler_, AlltimeStats alltimeStats_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_BoothEnvRun(BoothEnvRun __hx_this, Db db_, StoryState storyState_, Settings settings_, Shape layoutShape_, FaceCycler faceCycler_, NameCycler nameCycler_, AlltimeStats alltimeStats_)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
