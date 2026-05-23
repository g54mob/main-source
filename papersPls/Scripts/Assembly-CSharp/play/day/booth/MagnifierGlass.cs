using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class MagnifierGlass : Ent
	{
		public static int kZoomScale;

		public bool visible;

		public int touchPointId;

		public Booth booth;

		public Frame highlightFrame;

		public Frame highlightMaskFrame;

		public Array hits;

		public Image zoomImage;

		public Sprite zoomSprite;

		public int index;

		public Drawer drawer;

		public PointData draggingStageMouse;

		public Function whenMouseUp;

		public Rect _magRectInBooth;

		public QuadIter quadIter;

		public Ent ignoreRootEnt;

		public InspectUi inspectUi;

		static MagnifierGlass()
		{
		}

		public MagnifierGlass(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public MagnifierGlass(Ent parent_, InspectUi inspectUi_, Drawer drawer_, Booth booth_, int index_, Function whenMouseUp_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_MagnifierGlass(MagnifierGlass __hx_this, Ent parent_, InspectUi inspectUi_, Drawer drawer_, Booth booth_, int index_, Function whenMouseUp_)
		{
		}

		public bool get_inUse()
		{
			return false;
		}

		public override void draw(Drawer drawer)
		{
		}

		public override void react(Input input)
		{
		}

		public virtual void clear()
		{
		}

		public virtual void startCustomDrag(Pointer pointer)
		{
		}

		public virtual void updateCustomDrag(PointData stagePos)
		{
		}

		public virtual void drawTree(Ent ent, Drawer drawer)
		{
		}

		public virtual PointData endCustomDragAndGetStageMouse(PointData stagePos)
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
