using app.ent;
using app.vis;
using haxe.lang;
using play.save;
using play.ui;

namespace play.screen
{
	public class LoadButton : Ent
	{
		public SaveNode saveNode;

		public Button button;

		public Function whenClick;

		public int track;

		public PointData lerpPrePos;

		public PointData lerpCurPos;

		public LoadButton parentButton;

		public LoadTabTemplate template;

		public DiagramLine diagramLine;

		public Fill diagramLineBackFill;

		public LoadButton(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public LoadButton(Ent parent, LoadTabTemplate template_, LoadButton parentButton_, SaveNode saveNode_, int track_, Function whenClick_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_LoadButton(LoadButton __hx_this, Ent parent, LoadTabTemplate template_, LoadButton parentButton_, SaveNode saveNode_, int track_, Function whenClick_)
		{
		}

		public bool getMatches(LoadButton other)
		{
			return false;
		}

		public virtual void setMode(LoadMode mode)
		{
		}

		public virtual void button_onClick(Button b)
		{
		}

		public virtual void drawConnectingLine()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void lerpFrom(PointData prePos)
		{
		}

		public virtual void lerpPos(double t)
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
