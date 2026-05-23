using haxe.lang;

namespace play.day
{
	public class ConfiscatedPaper : HxObject
	{
		public string id;

		public string title;

		public string envelopePaperIdWithIndex;

		public string originalPaperIdWithIndex;

		public string nation;

		public ConfiscatedPaper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ConfiscatedPaper(string id_, string title_, string originalPaperIdWithIndex_, string envelopePaperIdWithIndex_, string nation_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_ConfiscatedPaper(ConfiscatedPaper __hx_this, string id_, string title_, string originalPaperIdWithIndex_, string envelopePaperIdWithIndex_, string nation_)
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
