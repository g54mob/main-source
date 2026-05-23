using app.ent;
using app.vis;
using data;
using haxe.lang;

namespace play.screen
{
	public class CreditList : Ent
	{
		public static int kSpaceHeight;

		public static int kImagePaddingT;

		public static int kImagePaddingB;

		public static int kRolePaddingT;

		public Array visuals;

		public double buildTop;

		public double buildWidth;

		public PointData drawWorldPos;

		public double worldClipT;

		public Rect clipRect;

		public double offscreenY;

		public Array availableLanguageCodes;

		static CreditList()
		{
		}

		public CreditList(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CreditList(Ent parent, double worldClipT_, double worldClipB, double offscreenY_, Array availableLanguageCodes_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_CreditList(CreditList __hx_this, Ent parent, double worldClipT_, double worldClipB, double offscreenY_, Array availableLanguageCodes_)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void addNode(Node node)
		{
		}

		public virtual void addText(string str, string style)
		{
		}

		public virtual void addImage(string name)
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
