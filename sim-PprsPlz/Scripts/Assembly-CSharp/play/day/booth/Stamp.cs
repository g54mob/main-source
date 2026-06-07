using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;

namespace play.day.booth
{
	public class Stamp : Ent
	{
		public Function whenApplyInk;

		public bool visible;

		public Stater stater;

		public Sprite topSprite;

		public Sprite botSprite;

		public Image inkImage;

		public StampApprovalKind approvalType;

		public Rect clipInParent;

		public Rect clipInLocal;

		public PointData _workPoint;

		public double inkInLocalX;

		public double inkInParentY;

		public Stamp(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Stamp(Ent parent_, string name, StampApprovalKind approvalType_, double date, object baseOffsetY, object pressDuration)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Stamp(Stamp __hx_this, Ent parent_, string name, StampApprovalKind approvalType_, double date, object baseOffsetY, object pressDuration)
		{
		}

		public bool get_stamping()
		{
			return false;
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

		public virtual bool testHit(PointData worldPos)
		{
			return false;
		}

		public virtual void drawInBar(Drawer drawer)
		{
		}

		public virtual void stamp()
		{
		}

		public virtual void setVisualsLayer(int layer)
		{
		}

		public virtual void applyInk()
		{
		}

		public virtual void setClipInParent(Rect clipInParent_)
		{
		}

		public virtual PointData autoClickWorldPos()
		{
			return null;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
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
