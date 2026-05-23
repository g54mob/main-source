using haxe.lang;

namespace play.day
{
	public class PaperInfo : HxObject
	{
		public string id;

		public double expirationDate;

		public string idWithIndex;

		public int multiPaperIndex;

		public PaperInfo(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PaperInfo(string id_, int multiPaperIndex_, double expirationDate_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_PaperInfo(PaperInfo __hx_this, string id_, int multiPaperIndex_, double expirationDate_)
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
