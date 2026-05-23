using haxe.lang;

namespace app.ent
{
	public class SafeChildIter : HxObject
	{
		public Ent ent;

		public bool rev;

		public int index;

		public SafeChildIter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SafeChildIter(Ent ent_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_SafeChildIter(SafeChildIter __hx_this, Ent ent_)
		{
		}

		public SafeChildIter forward()
		{
			return null;
		}

		public SafeChildIter reverse()
		{
			return null;
		}

		public virtual SafeChildIter start(bool rev_)
		{
			return null;
		}

		public virtual int nextIndex(int curIndex)
		{
			return 0;
		}

		public virtual bool hasNext()
		{
			return false;
		}

		public virtual Ent next()
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
