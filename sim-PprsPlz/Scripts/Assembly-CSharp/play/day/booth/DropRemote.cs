using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.day.booth
{
	public class DropRemote : Ent
	{
		public Stater stater;

		public double revealT;

		public Array dropButtons;

		public Array switchSprites;

		public Rect switchLocalRect;

		public GroupEnt buttonHolderEnt;

		public double buttonHolderWidth;

		public Array dropButtonsDropped;

		public Function whenDropButtonClick;

		public DropRemote(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DropRemote(Ent parent, Carousel carousel)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_DropRemote(DropRemote __hx_this, Ent parent, Carousel carousel)
		{
		}

		public bool get_open()
		{
			return false;
		}

		public virtual void setDropButtons(Array dropButtons_)
		{
		}

		public virtual void onDropButtonClick(Button button)
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public virtual void drawSwitch(Drawer drawer)
		{
		}

		public virtual bool set_open(bool open_)
		{
			return false;
		}

		public virtual double set_revealT(double revealT_)
		{
			return 0.0;
		}

		public virtual bool wantSwitchFlash()
		{
			return false;
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public virtual PointData autoClickWorldPos()
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
