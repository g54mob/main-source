using app.vis;
using haxe.lang;

namespace app.ent
{
	public class VisualIter : HxObject
	{
		public int iterLayerIndex;

		public Iter_app_vis_Visual visualIter;

		public Array sortedLayers;

		public int sortedLayerCount;

		public VisualIter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public VisualIter()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_VisualIter(VisualIter __hx_this)
		{
		}

		public virtual VisualIter begin(Drawer drawer)
		{
			return null;
		}

		public virtual bool hasNext()
		{
			return false;
		}

		public virtual Visual next()
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
