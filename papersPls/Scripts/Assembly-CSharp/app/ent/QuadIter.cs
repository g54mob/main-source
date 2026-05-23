using app.vis;
using haxe.lang;

namespace app.ent
{
	public class QuadIter : HxObject
	{
		public VisualIter visualIter;

		public int nextTileIndex;

		public Visual visual;

		public Rect clip;

		public Quad quad;

		public QuadIter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public QuadIter()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_QuadIter(QuadIter __hx_this)
		{
		}

		public virtual QuadIter begin(Drawer drawer)
		{
			return null;
		}

		public virtual bool hasNext()
		{
			return false;
		}

		public virtual Quad next()
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
