using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.day.booth
{
	public class Shutter : Ent
	{
		public Button switchButton;

		public double openT;

		public Fill shadowFill;

		public Array shutterSprites;

		public TravelerEnt travelerEnt;

		public Stater stater;

		public double height_;

		public Shutter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Shutter(Ent parent_, TravelerEnt travelerEnt_, bool startOpen)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Shutter(Shutter __hx_this, Ent parent_, TravelerEnt travelerEnt_, bool startOpen)
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

		public bool get_isFullyRaised()
		{
			return false;
		}

		public virtual void snapToState(bool open_)
		{
		}

		public override void update()
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

		public virtual double set_openT(double t)
		{
			return 0.0;
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
