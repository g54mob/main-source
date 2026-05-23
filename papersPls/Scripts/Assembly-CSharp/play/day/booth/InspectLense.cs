using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class InspectLense : Ent
	{
		public Booth booth;

		public Carousel carousel;

		public Frame highlightFrame;

		public Rect highlightRect;

		public Inspectable highlightInspectable;

		public Function whenSelectInspectable;

		public InspectUi inspectUi;

		public InspectLenseInspectableExtra inspectableExtra0;

		public InspectLenseInspectableExtra inspectableExtra1;

		public Drawer extraDrawer;

		public DeskItem hitDeskItem;

		public InspectLense(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public InspectLense(Ent parent, Booth booth_, Carousel carousel_, Function whenSelectInspectable_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_InspectLense(InspectLense __hx_this, Ent parent, Booth booth_, Carousel carousel_, Function whenSelectInspectable_)
		{
		}

		public virtual void setVisible(bool visible)
		{
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

		public virtual void reactSelectInspectableAt(PointData stagePos)
		{
		}

		public virtual void reactHighlightInspectableAt(PointData stagePos)
		{
		}

		public virtual Inspectable getInspectableAt(PointData stagePos)
		{
			return null;
		}

		public virtual Rect getSelectedInspectableRectInBooth(int index)
		{
			return null;
		}

		public virtual void syncInspectablesWithInspectUi()
		{
		}

		public virtual DeskItem getHitDeskItemAt(PointData stagePos)
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
