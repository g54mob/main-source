using data;
using haxe.lang;

namespace play.night
{
	public class Line : HxObject
	{
		public LineKind kind;

		public string name;

		public int cost;

		public bool enabled;

		public MustPay mustPay;

		public Op yesNoOp;

		public Line(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Line(LineKind kind_, string name_, int cost_, MustPay mustPay_, Op yesNoOp_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_Line(Line __hx_this, LineKind kind_, string name_, int cost_, MustPay mustPay_, Op yesNoOp_)
		{
		}

		public virtual string get_renameSleepButton()
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
