using haxe.lang;

namespace app.vis
{
	public class Clipper : HxObject
	{
		public int dx;

		public int dy;

		public int sx0;

		public int sy0;

		public int sx1;

		public int sy1;

		public Clipper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Clipper()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Clipper(Clipper __hx_this)
		{
		}

		public int get_w()
		{
			return 0;
		}

		public int get_h()
		{
			return 0;
		}

		public bool get_valid()
		{
			return false;
		}

		public virtual bool clip(int dstWidth, int dstHeight, int dx_, int dy_, int srcWidth, int srcHeight, int sx, int sy, int sw, int sh)
		{
			return false;
		}

		public bool clip2(int dstWidth, int dstHeight, int dx_, int dy_, int srcWidth, int srcHeight, Rect srcRect)
		{
			return false;
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
