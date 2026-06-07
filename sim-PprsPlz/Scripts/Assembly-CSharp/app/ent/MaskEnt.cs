using app.vis;
using haxe.lang;

namespace app.ent
{
	public class MaskEnt : Ent
	{
		public Rect rect;

		public Fill fill;

		public MaskEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public MaskEnt(Ent parent, Rect rect_, ColorData color)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_MaskEnt(MaskEnt __hx_this, Ent parent, Rect rect_, ColorData color)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public override void react(Input input)
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
