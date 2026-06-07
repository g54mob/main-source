using app.vis;
using haxe.lang;

namespace play.day
{
	public class LayoutImage : HxObject
	{
		public static int kColWidth;

		public Array rects;

		public int numLines;

		public int numCols;

		public Image backImage;

		static LayoutImage()
		{
		}

		public LayoutImage(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public LayoutImage(Res res, int dayId)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_LayoutImage(LayoutImage __hx_this, Res res, int dayId)
		{
		}

		public static Rect getColorBoundsRect(Image image, uint mask, uint color)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
