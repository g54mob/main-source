using haxe.lang;

namespace app
{
	public class Probability : HxObject
	{
		public Rand rand;

		public Array choices;

		public Probability(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Probability(Rand rand_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Probability(Probability __hx_this, Rand rand_)
		{
		}

		public int get_numChoices()
		{
			return 0;
		}

		public virtual void addChoice(string val, double prob)
		{
		}

		public virtual string select()
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
	}
}
