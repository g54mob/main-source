using haxe.lang;

namespace app.vis
{
	public class Chip : HxObject
	{
		public double x;

		public double y;

		public bool visible;

		public bool mirror;

		public ColorData color;

		public int sourceIndex;

		public Atlas atlas;

		public Rect sourceRect;

		public double originX;

		public double originY;

		public Chip(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Chip(Atlas atlas_, object sourceIndex_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Chip(Chip __hx_this, Atlas atlas_, object sourceIndex_)
		{
		}

		public double get_width()
		{
			return 0.0;
		}

		public double get_height()
		{
			return 0.0;
		}

		public virtual int set_sourceIndex(int v)
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
