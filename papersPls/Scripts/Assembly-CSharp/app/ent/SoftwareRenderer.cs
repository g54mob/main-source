using app.vis;
using haxe.lang;

namespace app.ent
{
	public class SoftwareRenderer : HxObject
	{
		public Image image;

		public Sprite sprite;

		public QuadIter quadIter;

		public double postScale;

		public SoftwareRenderer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SoftwareRenderer(int width, int height, object postScale_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_SoftwareRenderer(SoftwareRenderer __hx_this, int width, int height, object postScale_)
		{
		}

		public virtual void render(Drawer drawer)
		{
		}

		public virtual void renderFromQuadIter(QuadIter quadIter2)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
