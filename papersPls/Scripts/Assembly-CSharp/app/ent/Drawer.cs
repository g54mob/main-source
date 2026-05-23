using app.vis;
using haxe.ds;
using haxe.lang;

namespace app.ent
{
	public class Drawer : HxObject
	{
		public Array layers;

		public IntMap layerDict;

		public Drawer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Drawer()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_Drawer(Drawer __hx_this)
		{
		}

		public virtual void reset()
		{
		}

		public virtual Layer getLayer(int id)
		{
			return null;
		}

		public void add(PointData hostPos, Visual visual, object forceIfInvisible)
		{
		}

		public void addMultiple(PointData hostPos, Array visuals, object forceIfInvisible)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
