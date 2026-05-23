using haxe.lang;

namespace app
{
	public class ShuffledSequence : HxObject
	{
		public static int kReshuffleCountMax;

		public Array array;

		public int cur;

		public int seed;

		public bool reshuffleOnLoop;

		public int reshuffleCount;

		static ShuffledSequence()
		{
		}

		public ShuffledSequence(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ShuffledSequence(int count, int seed_, object reshuffleOnLoop_, object cur_, object reshuffleCount_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ShuffledSequence(ShuffledSequence __hx_this, int count, int seed_, object reshuffleOnLoop_, object cur_, object reshuffleCount_)
		{
		}

		public static ShuffledSequence makeBasic(int count, int seed)
		{
			return null;
		}

		public static ShuffledSequence makeReshufflingOnLoop(int count, int seed)
		{
			return null;
		}

		public static ShuffledSequence makeFromState(int count, bool reshuffleOnLoop, ShuffledSequenceState state)
		{
			return null;
		}

		public virtual int getNext()
		{
			return 0;
		}

		public virtual ShuffledSequenceState getState()
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
