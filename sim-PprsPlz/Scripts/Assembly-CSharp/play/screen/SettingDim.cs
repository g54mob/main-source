using app.vis;
using haxe.lang;

namespace play.screen
{
	public class SettingDim : HxObject
	{
		public int buttonW;

		public int buttonH;

		public int rowHeight;

		public int buttonX;

		public int padding;

		public int fontAscent;

		public int barWidth;

		public Array buttonPlusImages;

		public Array buttonMinusImages;

		public Array buttonOnImages;

		public Array buttonOffImages;

		public SettingDim(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SettingDim(Db db, Layout layout, Font font)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_SettingDim(SettingDim __hx_this, Db db, Layout layout, Font font)
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
