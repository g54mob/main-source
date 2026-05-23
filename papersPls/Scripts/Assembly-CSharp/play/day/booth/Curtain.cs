using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class Curtain : Ent
	{
		public Sprite spriteL;

		public Sprite spriteR;

		public Fill flashFill;

		public Stater stater;

		public double openT;

		public double flashStartStateTime;

		public TravelerEnt travelerEnt;

		public Function whenPrint;

		public Curtain(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Curtain(Ent parent_, TravelerEnt travelerEnt_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Curtain(Curtain __hx_this, Ent parent_, TravelerEnt travelerEnt_)
		{
		}

		public virtual bool get_open()
		{
			return false;
		}

		public virtual bool set_open(bool e)
		{
			return false;
		}

		public virtual bool isOpen()
		{
			return false;
		}

		public virtual void close(Function whenPrint_)
		{
		}

		public virtual void flash()
		{
		}

		public virtual double set_openT(double t)
		{
			return 0.0;
		}

		public override void update()
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
