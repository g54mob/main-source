using app.vis;
using haxe.lang;

namespace app.ent
{
	public class Ent : HxObject
	{
		public static uint nextGuid;

		public string name;

		public int flags;

		public Ent parent;

		public Trunk trunk;

		public PointData pos;

		public uint guid;

		public EntEnv env;

		public Array children;

		public SafeChildIter treeSafeChildIter;

		public PointData _worldPos;

		public Rect _worldRect;

		public Rect _localRect;

		public Tweener _tweener;

		static Ent()
		{
		}

		public Ent(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Ent(Ent parent_, string name_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_Ent(Ent __hx_this, Ent parent_, string name_)
		{
		}

		public bool get_active()
		{
			return false;
		}

		public bool set_active(bool v)
		{
			return false;
		}

		public bool get_activeInTree()
		{
			return false;
		}

		public bool get_flagEnableReact()
		{
			return false;
		}

		public bool set_flagEnableReact(bool v)
		{
			return false;
		}

		public double get_x()
		{
			return 0.0;
		}

		public double set_x(double v)
		{
			return 0.0;
		}

		public double get_y()
		{
			return 0.0;
		}

		public double set_y(double v)
		{
			return 0.0;
		}

		public EntEnv get_env()
		{
			return null;
		}

		public bool get_isLastInParent()
		{
			return false;
		}

		public virtual Tweener tweener()
		{
			return null;
		}

		public virtual string debugName()
		{
			return null;
		}

		public virtual void update()
		{
		}

		public virtual void draw(Drawer drawer)
		{
		}

		public virtual void react(Input input)
		{
		}

		public virtual double width()
		{
			return 0.0;
		}

		public virtual double height()
		{
			return 0.0;
		}

		public virtual bool addChild(Ent ent)
		{
			return false;
		}

		public virtual bool removeChild(Ent ent)
		{
			return false;
		}

		public virtual void orderChildToBeginning(Ent ent)
		{
		}

		public virtual void orderChildToEnd(Ent ent)
		{
		}

		public virtual void sortChildren(Function compareFunc)
		{
		}

		public virtual void orderChildAfter(Ent child, Ent beforeEnt)
		{
		}

		public virtual void orderChildBefore(Ent child, Ent afterEnt)
		{
		}

		public virtual bool removeFromParent()
		{
			return false;
		}

		public virtual int getChildIndex(Ent child)
		{
			return 0;
		}

		public InPlace convertLocalToParent(PointData posInLocal)
		{
			return null;
		}

		public InPlace convertLocalToWorld(PointData posInLocal)
		{
			return null;
		}

		public InPlace convertWorldToLocal(PointData posInWorld)
		{
			return null;
		}

		public virtual PointData worldPos()
		{
			return null;
		}

		public virtual Rect worldRect()
		{
			return null;
		}

		public virtual Rect localRect()
		{
			return null;
		}

		public virtual Ent findDescendantEnt(uint findGuid)
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
