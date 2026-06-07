using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class BorderCamVisual : Visual
	{
		public BorderCamRenderer renderer;

		public Rect srcRectInBorder;

		public BorderCamVisual(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BorderCamVisual(BorderCamRenderer renderer_, Rect srcRectInBorder_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_BorderCamVisual(BorderCamVisual __hx_this, BorderCamRenderer renderer_, Rect srcRectInBorder_)
		{
		}

		public override void buildTiles()
		{
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
