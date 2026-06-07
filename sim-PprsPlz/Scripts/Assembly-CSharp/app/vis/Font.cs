using data;
using haxe.ds;
using haxe.lang;

namespace app.vis
{
	public class Font : HxObject
	{
		public static int kSpaceCharCode;

		public static string kTabString;

		public string name;

		public int ascent;

		public int capHeight;

		public int spaceWidth;

		public int lineHeight;

		public IntMap letters;

		public Array pageImages;

		public int letterAdvanceXMax;

		public string hyphen;

		public int hyphenWidth;

		static Font()
		{
		}

		public Font(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Font(Res res, string name_, int forceLineHeight, Lang lang)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Font(Font __hx_this, Res res, string name_, int forceLineHeight, Lang lang)
		{
		}

		public static string unescape(string letter)
		{
			return null;
		}

		public static string escape(string letter)
		{
			return null;
		}

		public int get_descent()
		{
			return 0;
		}

		public virtual int getTextWidth(string text)
		{
			return 0;
		}

		public virtual SplitResult split(string text, int maxWidth, bool multiLine)
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
