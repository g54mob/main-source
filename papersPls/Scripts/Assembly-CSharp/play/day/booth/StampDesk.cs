using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;

namespace play.day.booth
{
	public class StampDesk : Ent, IStampBar, IHxObject
	{
		public static int kStampBarY;

		public static double kStampPressDuration;

		public static int kStampOffsetFromBarEdgeX;

		public bool enabled;

		public bool reasonStampEnabled;

		public Function whenOpened;

		public bool visible;

		public Stater stater;

		public BarPiecesEnt approveBarPieces;

		public Stamp approveStamp;

		public BarPiecesEnt denyBarPieces;

		public Stamp denyStamp;

		public BarPiecesEnt reasonBarPieces;

		public Stamp reasonStamp;

		public Sprite reasonTriggerSpriteU;

		public Sprite reasonTriggerSpriteD;

		public Rect reasonTriggerRect;

		public Rect reasonClip;

		public Sprite backSpriteL;

		public Sprite backSpriteR;

		public Fill darkenFill;

		public Rect backClipL;

		public Rect backClipR;

		public Rect maskAreaRectInWorld;

		public Carousel carousel;

		public DeskItem stampingDeskItem;

		public PointData stampingDeskItemStartPos;

		public PointData stampingDeskItemCenteredPos;

		public DeskItemDragHelper dragHelper;

		public PullChain pullChain;

		public bool tutorBlockingStamps;

		public bool draggedWhileOpening;

		public ReasonLight reasonLightInside;

		public ReasonLight reasonLightOutside;

		static StampDesk()
		{
		}

		public StampDesk(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StampDesk(Ent parent_, Carousel carousel_, double date)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_StampDesk(StampDesk __hx_this, Ent parent_, Carousel carousel_, double date)
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

		public override void update()
		{
		}

		public virtual void onPullRingTriggered()
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

		public virtual PointData tutorGetPullChainRingCenterInWorld()
		{
			return null;
		}

		public virtual bool tutorGetHaveDraggedDeskItem()
		{
			return false;
		}

		public virtual void tutorBlockStamps(bool tutorBlockingStamps_)
		{
		}

		public virtual void tutorAbort()
		{
		}

		public virtual PointData tutorGetApprovedStampClickWorldPos()
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
