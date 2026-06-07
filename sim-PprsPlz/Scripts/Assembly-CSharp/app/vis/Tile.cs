using haxe.lang;

namespace app.vis
{
	public class Tile : HxObject
	{
		public static int SRCFLIP_X;

		public Image image;

		public Rect srcRect;

		public Rect dstRect;

		public ColorData color;

		public int srcFlip;

		static Tile()
		{
		}

		public Tile(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Tile()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Tile(Tile __hx_this)
		{
		}

		public virtual string toString()
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

		public override string ToString()
		{
			return null;
		}
	}
}
