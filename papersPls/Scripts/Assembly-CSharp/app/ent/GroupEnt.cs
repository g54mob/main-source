using haxe.lang;

namespace app.ent
{
	public class GroupEnt : Ent
	{
		public Array visuals;

		public GroupEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public GroupEnt(Ent parent_, Array visuals_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_GroupEnt(GroupEnt __hx_this, Ent parent_, Array visuals_)
		{
		}

		public override void draw(Drawer drawer)
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
