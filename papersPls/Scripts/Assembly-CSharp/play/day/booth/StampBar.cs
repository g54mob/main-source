using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;
using play.ui;

namespace play.day.booth
{
	public class StampBar : Ent, IStampBar, IHxObject
	{
		public bool enabled;

		public bool reasonStampEnabled;

		public Function whenOpened;

		public Stater approveDenyStater;

		public BarPiecesEnt approveDenyBarPieces;

		public Stamp approveStamp;

		public Stamp denyStamp;

		public Stater reasonStater;

		public BarPiecesEnt reasonBarPieces;

		public Stamp reasonStamp;

		public DropButton reasonDropButton;

		public StampBar(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StampBar(Ent parent_, double date)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_StampBar(StampBar __hx_this, Ent parent_, double date)
		{
		}

		public DeskItem get_stampingSoloDeskItem()
		{
			return null;
		}

		public virtual Function set_whenApplyInk(Function func)
		{
			return null;
		}

		public virtual void reasonDropButton_onClick(Button b)
		{
		}

		public virtual void approveDenyBarPieces_onClickBar()
		{
		}

		public override void update()
		{
		}

		public virtual bool set_reasonStampEnabled(bool e)
		{
			return false;
		}

		public virtual bool get_open()
		{
			return false;
		}

		public virtual bool set_open(bool open_)
		{
			return false;
		}

		public virtual bool set_enabled(bool e)
		{
			return false;
		}

		public virtual PointData autoToggleClickWorldPos()
		{
			return null;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
		}

		public virtual Rect autoGetOpenStampRect(StampApprovalKind approvalKind)
		{
			return null;
		}

		public virtual PointData autoStampClickWorldPos(StampApprovalKind approvalKind)
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
