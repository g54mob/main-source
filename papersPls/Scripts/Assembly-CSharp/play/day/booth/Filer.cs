using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class Filer : Ent
	{
		public Function whenOpened;

		public double openHeight;

		public Array visuals;

		public Sprite backSprite;

		public Stater stater;

		public Rect clipRect;

		public double closedHeight;

		public double shiftY;

		public Ent deskItemGroupEnt;

		public Text countText;

		public int prevCount;

		public double ignoreCloseSoundUntilTime;

		public PointData _localSlotPos;

		public double openT;

		public Filer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Filer(Ent parent_, Ent deskItemGroupEnt_, string policyText)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Filer(Filer __hx_this, Ent parent_, Ent deskItemGroupEnt_, string policyText)
		{
		}

		public virtual void bumpIfClosed()
		{
		}

		public virtual double set_openT(double t)
		{
			return 0.0;
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public virtual bool get_open()
		{
			return false;
		}

		public virtual bool set_open(bool open_)
		{
			return false;
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void closeIfOpen()
		{
		}

		public virtual void openIfClosed()
		{
		}

		public virtual int getCount()
		{
			return 0;
		}

		public virtual PointData getLocalSlotPos(DeskItem d)
		{
			return null;
		}

		public virtual bool autoIsOpen()
		{
			return false;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
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
