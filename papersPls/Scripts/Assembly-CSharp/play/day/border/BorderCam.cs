using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class BorderCam : Ent
	{
		public Border border;

		public Sprite noiseSprite;

		public bool leftSide;

		public Rand rand;

		public BorderCamVisual camVisual;

		public BorderCam(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BorderCam(Ent parent, Border border_, BorderCamRenderer renderer, bool leftSide_, int seed)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_BorderCam(BorderCam __hx_this, Ent parent, Border border_, BorderCamRenderer renderer, bool leftSide_, int seed)
		{
		}

		public override void draw(Drawer drawer)
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

		public virtual void tween_buttonPressed(double t)
		{
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
