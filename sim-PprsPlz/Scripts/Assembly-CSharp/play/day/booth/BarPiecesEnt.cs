using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class BarPiecesEnt : Ent
	{
		public bool visible;

		public Sprite barTopSprite;

		public Sprite barMidSprite;

		public Sprite barBotSprite;

		public Array stamps;

		public Function whenClickBar;

		public Rect clipInParent;

		public Rect clipInLocal;

		public PointData _localPos;

		public Rect _hitTestWorldRect;

		public BarPiecesEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BarPiecesEnt(Ent parent_, PartData topImagePart, PartData midImagePart, PartData botImagePart, Array stamps_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_BarPiecesEnt(BarPiecesEnt __hx_this, Ent parent_, PartData topImagePart, PartData midImagePart, PartData botImagePart, Array stamps_)
		{
		}

		public bool set_visible(bool v)
		{
			return false;
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

		public virtual void setClipInParent(Rect clipInParent_)
		{
		}

		public virtual void setVisualsLayer(int layer)
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
