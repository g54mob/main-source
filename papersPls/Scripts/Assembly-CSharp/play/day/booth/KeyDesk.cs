using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.day.border;

namespace play.day.booth
{
	public class KeyDesk : Ent
	{
		public static int kDropBelowRifleButtonDist;

		public bool visible;

		public Stater stater;

		public Sprite backSpriteL;

		public Sprite backSpriteR;

		public Fill darkenFill;

		public Rect backClipL;

		public Rect backClipR;

		public Rect maskAreaRectInWorld;

		public Array keyDraggers;

		public Border border;

		public Sprite bulletinGunTutSprite;

		public Rect helpWorldRect;

		public Fill helpDarkenFill;

		static KeyDesk()
		{
		}

		public KeyDesk(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public KeyDesk(Ent parent_, bool wantGunHelp)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_KeyDesk(KeyDesk __hx_this, Ent parent_, bool wantGunHelp)
		{
		}

		public virtual void setBorder(Border border_)
		{
		}

		public virtual void prepareForOpen(Array keyDeskItems)
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

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public override void react(Input input)
		{
		}

		public virtual bool checkHelpClick(Input input, bool helping)
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

		public virtual PointData autoGetHelpDismissClickWorldPos()
		{
			return null;
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
