using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class CursorEnt : Ent
	{
		public Sprite sprite;

		public Image handImage;

		public Image arrowImage;

		public bool recordingTouch;

		public PartData touchImagePart;

		public PartData untouchImagePart;

		public Sprite touchDragSprite;

		public PartData touchDragImagePart;

		public Image touchDragLayerImage;

		public PointData touchDownWorkPos;

		public CursorEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CursorEnt(Ent parent_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_CursorEnt(CursorEnt __hx_this, Ent parent_)
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
