using app.ent;
using haxe.lang;
using play.save;
using play.ui;

namespace play.screen
{
	public class LoadScreen : GameScreen
	{
		public static int kColorFaded;

		public static int kMaxTracks;

		public static int kMaxDays;

		public Menu menu;

		public int highestDay;

		public GroupEnt scroller;

		public GroupEnt dayHeaderScroller;

		public GroupEnt loadButtonsHolder;

		public Array loadButtons;

		public Button deleteButton;

		public LoadMode mode;

		public Confirm confirm;

		public SaveNode confirmingSaveNode;

		public int numTracks;

		public Array dragScrollSprites;

		public Array dayHeaderVisuals;

		public double dayHeadersWidth;

		public KineticScroll kineticScrollX;

		public KineticScroll kineticScrollY;

		public ScrollPassthroughEnt scrollPassthroughEnt;

		public ReactPassthroughEnt dayHeaderPassthroughEnt;

		public double scrollX;

		public double scrollY;

		public LoadScreenDim dim;

		public SaveManager saveManager;

		static LoadScreen()
		{
		}

		public LoadScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public LoadScreen(Ent parent, AlltimeStats alltimeStats, SaveManager saveManager_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_LoadScreen(LoadScreen __hx_this, Ent parent, AlltimeStats alltimeStats, SaveManager saveManager_)
		{
		}

		public override void update()
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

		public virtual double set_scrollX(double s)
		{
			return 0.0;
		}

		public virtual double set_scrollY(double s)
		{
			return 0.0;
		}

		public virtual void applyScroll()
		{
		}

		public virtual double get_scrollMaxX()
		{
			return 0.0;
		}

		public virtual double get_scrollMaxY()
		{
			return 0.0;
		}

		public virtual SaveNode createLoadButtons()
		{
			return null;
		}

		public virtual double getLoadButtonsHolderX(int numTracks_)
		{
			return 0.0;
		}

		public virtual int addLoadButton(LoadTabTemplate template, LoadButton parentButton, SaveNode saveNode, int track)
		{
			return 0;
		}

		public virtual LoadMode set_mode(LoadMode m)
		{
			return null;
		}

		public virtual void loadButton_onClick(SaveNode saveNode)
		{
		}

		public virtual void confirm_onClick(string id)
		{
		}

		public virtual void menu_onClick(string id)
		{
		}

		public virtual void deleteButton_onClick(Button b)
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
