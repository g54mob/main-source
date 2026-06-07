using haxe.lang;

namespace data
{
	public class ScoreScale : HxObject
	{
		public double scale0;

		public double scale1;

		public double time0;

		public double time1;

		public ScoreScale(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ScoreScale(Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_ScoreScale(ScoreScale __hx_this, Xml node)
		{
		}

		public virtual int getScale(double time)
		{
			return 0;
		}

		public virtual int transform(int inScore, double time)
		{
			return 0;
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
