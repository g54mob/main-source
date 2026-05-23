using data;
using haxe.lang;

namespace play.night
{
	public class Budget : HxObject
	{
		public Array lines;

		public Lang lang;

		public Budget(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Budget(Lang lang_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_Budget(Budget __hx_this, Lang lang_)
		{
		}

		public virtual void addLine(LineKind kind, string name, int cost, MustPay mustPay, Op yesNoOp)
		{
		}

		public virtual void updateLineCost(string name, int cost)
		{
		}

		public virtual int get_profit()
		{
			return 0;
		}

		public virtual int get_total()
		{
			return 0;
		}

		public virtual bool willPay(string lineName)
		{
			return false;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual BalanceResult balance()
		{
			return null;
		}

		public virtual string getRenameSleepButton()
		{
			return null;
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
