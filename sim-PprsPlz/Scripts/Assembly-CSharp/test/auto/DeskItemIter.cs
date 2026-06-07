using app.ent;
using haxe.lang;
using play.day.booth;

namespace test.auto
{
	public class DeskItemIter : HxObject
	{
		public Trunk trunk;

		public Array children;

		public int index;

		public bool rev;

		public DeskItemIter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DeskItemIter(Trunk trunk_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_DeskItemIter(DeskItemIter __hx_this, Trunk trunk_)
		{
		}

		public DeskItemIter forward()
		{
			return null;
		}

		public DeskItemIter reverse()
		{
			return null;
		}

		public virtual DeskItemIter start(bool rev_)
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

		public virtual DeskItem next()
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
