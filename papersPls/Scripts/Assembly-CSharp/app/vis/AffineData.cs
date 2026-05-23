using haxe.lang;

namespace app.vis
{
	public class AffineData : HxObject
	{
		public double m00;

		public double m01;

		public double m02;

		public double m10;

		public double m11;

		public double m12;

		public AffineData(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AffineData(double m00_, double m01_, double m02_, double m10_, double m11_, double m12_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_AffineData(AffineData __hx_this, double m00_, double m01_, double m02_, double m10_, double m11_, double m12_)
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
