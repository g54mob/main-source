using haxe.lang;

namespace app
{
	public class ShuffledSequenceState : HxObject
	{
		public int seed;

		public int cur;

		public int reshuffleCount;

		public ShuffledSequenceState(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ShuffledSequenceState(int seed, int cur, int reshuffleCount)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ShuffledSequenceState(ShuffledSequenceState __hx_this, int seed, int cur, int reshuffleCount)
		{
		}

		public static ShuffledSequenceState fromString(string str)
		{
			return null;
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
