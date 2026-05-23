using haxe.lang;

namespace app.ent
{
	public class Trunk : Ent
	{
		public EntEnv trunkEnv;

		public Trunk(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Trunk(EntEnv trunkEnv_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_Trunk(Trunk __hx_this, EntEnv trunkEnv_)
		{
		}

		public static bool wantProcess(Ent ent)
		{
			return false;
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public override void react(Input input)
		{
		}

		public virtual void treeUpdate(Ent ent)
		{
		}

		public virtual void treeDraw(Ent ent, Drawer drawer)
		{
		}

		public virtual void treeReact(Ent ent, Input input)
		{
		}

		public virtual void debugLogTree(Ent ent)
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
