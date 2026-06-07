using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.day.booth
{
	public class InspectUiDiagram : HxObject
	{
		public double visibleT;

		public Db db;

		public Layout layout;

		public Rect r0;

		public Rect r1;

		public Frame selectionOuterFrame;

		public Text discrepancyTextField;

		public InterrogateButton interrogateButton;

		public bool allowInnerJoin;

		public Array diagramLines;

		public string stableJoinSide;

		public int stableJoinCount;

		public PointData join;

		public InspectUiDiagram(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public InspectUiDiagram(Db db_, Layout layout_, Font font, Frame selectionOuterFrame_, InterrogateButton interrogateButton_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_InspectUiDiagram(InspectUiDiagram __hx_this, Db db_, Layout layout_, Font font, Frame selectionOuterFrame_, InterrogateButton interrogateButton_)
		{
		}

		public string get_discrepancyText()
		{
			return null;
		}

		public virtual void draw(PointData hostPos, Drawer drawer)
		{
		}

		public virtual void set(string discrepancyText_, Rect r0_, Rect r1_)
		{
		}

		public virtual double set_visibleT(double t)
		{
			return 0.0;
		}

		public virtual void buildCurvedLine(DiagramLine line, Rect rect, PointData end, bool endHorizontally)
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
