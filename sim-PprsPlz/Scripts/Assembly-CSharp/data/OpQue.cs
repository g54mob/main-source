using haxe.ds;
using haxe.lang;

namespace data
{
	public class OpQue : HxObject
	{
		public List items;

		public double defaultDelay;

		public double curTime;

		public OpQue(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public OpQue(object defaultDelay_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_OpQue(OpQue __hx_this, object defaultDelay_)
		{
		}

		public virtual bool get_hasItems()
		{
			return false;
		}

		public virtual double get_lastTimeToPop()
		{
			return 0.0;
		}

		public virtual void push(Op op, object overrideDelay)
		{
		}

		public virtual void delay(double duration)
		{
		}

		public virtual Op pop(double curTime_)
		{
			return null;
		}

		public virtual bool hasOnlySayOps()
		{
			return false;
		}

		public virtual bool hasEnableButtonOp()
		{
			return false;
		}

		public virtual void clear()
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
