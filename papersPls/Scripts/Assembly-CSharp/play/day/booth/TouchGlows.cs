using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class TouchGlows : Ent
	{
		public Array glows;

		public int idCounter;

		public TouchGlows(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TouchGlows(Ent parent_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_TouchGlows(TouchGlows __hx_this, Ent parent_)
		{
		}

		public virtual object getFirstGlow(int id)
		{
			return null;
		}

		public virtual int createGlow(Rect localRect)
		{
			return 0;
		}

		public virtual void destroyGlow(int touchGlowId)
		{
		}

		public virtual void destroyAll()
		{
		}

		public override void draw(Drawer drawer)
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
