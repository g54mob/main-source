using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.day.booth;

namespace play.day.border
{
	public class RifleButton : Ent
	{
		public Function whenClick;

		public bool selected;

		public int numBullets;

		public string soundId;

		public Cursor scopeCursor;

		public string shotAnim;

		public bool isTranq;

		public Stater stater;

		public Sprite rifleNormalSprite;

		public Sprite rifleSelectSprite;

		public Sprite lockNoKeySprite;

		public Sprite lockInsertedKeySprite;

		public Sprite lockTurnedKeySprite;

		public Array bulletSprites;

		public double lockWidth;

		public DeskItem draggingKeyDeskItem;

		public string keyDeskItemId;

		public Array visuals;

		public int ignoreInputUntilFrame;

		public RifleButton(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public RifleButton(Ent parent, string assetSuffix, string soundId_, int numBullets_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_RifleButton(RifleButton __hx_this, Ent parent, string assetSuffix, string soundId_, int numBullets_)
		{
		}

		public virtual int set_numBullets(int n)
		{
			return 0;
		}

		public State get_state()
		{
			return null;
		}

		public virtual State set_state(State s)
		{
			return null;
		}

		public virtual bool set_selected(bool s)
		{
			return false;
		}

		public virtual void selected_tween(double t)
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void ignoreInputForOneFrame()
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
