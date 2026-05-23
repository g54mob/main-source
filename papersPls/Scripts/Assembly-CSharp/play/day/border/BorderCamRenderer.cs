using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class BorderCamRenderer : Visual
	{
		public Atlas atlas;

		public double scale;

		public Image atlasImage;

		public Image backImage;

		public BorderCamRenderer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BorderCamRenderer(Res res, Border border, double scale_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_BorderCamRenderer(BorderCamRenderer __hx_this, Res res, Border border, double scale_)
		{
		}

		public static void applyPalette(Image image, uint palette0, uint palette1, uint palette2, uint palette3)
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
