using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;

namespace play.day.booth
{
	public class InspectUi : Ent
	{
		public static uint kFillColor;

		public static uint kLineColor;

		public static uint kRedColor;

		public Function whenOpen;

		public Function whenDenialEnabledClick;

		public Function whenInterrogateClick;

		public Array selectedInspectables;

		public bool visible;

		public double alpha;

		public BoothEnv boothEnv;

		public Booth booth;

		public Sprite openButtonSprite;

		public Sprite closeButtonSprite;

		public Sprite buttonBackSprite;

		public Sprite overlaySprite;

		public Frame selectionInnerFrame;

		public Frame selectionOuterFrame;

		public InterrogateButton interrogateButton;

		public Text instructionsTextField;

		public Stater stater;

		public Stater diagramStater;

		public Magnifier magnifier;

		public double surroundT;

		public Array surroundLines;

		public Carousel carousel;

		public InspectLense carouselInspectLense;

		public bool selectedInspectableAddAtZero;

		public InspectUiOverlayState overlayState;

		public InspectUiDiagram diagram;

		public double revealT;

		public bool disabled;

		public Rect testHitRect;

		public bool initialScanVisible;

		public Rect initialScanClip;

		public Array initialScanFrames;

		static InspectUi()
		{
		}

		public InspectUi(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public InspectUi(Ent parent_, BoothEnv boothEnv_, Booth booth_, Carousel carousel_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_InspectUi(InspectUi __hx_this, Ent parent_, BoothEnv boothEnv_, Booth booth_, Carousel carousel_)
		{
		}

		public static PointData getInspectPointerUpWorldPos(Pointer pointer)
		{
			return null;
		}

		public virtual bool get_open()
		{
			return false;
		}

		public bool get_isInterrogateButtonVisible()
		{
			return false;
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void onDrawRack(Drawer drawer)
		{
		}

		public Rect getOpenButtonHitRect()
		{
			return null;
		}

		public Rect getCloseButtonHitRect()
		{
			return null;
		}

		public virtual bool testHitOpenCloseButton(PointData stagePos)
		{
			return false;
		}

		public override void react(Input input)
		{
		}

		public virtual bool set_open(bool open_)
		{
			return false;
		}

		public virtual void disable()
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

		public virtual double set_surroundT(double t)
		{
			return 0.0;
		}

		public virtual void generateInitialScan()
		{
		}

		public virtual void interrogateButton_onClick(InterrogateButton interrogateButton)
		{
		}

		public virtual Array getSelectedInspectableFactPaths()
		{
			return null;
		}

		public virtual FactRelationship getSelectedInspectableFactRelationship()
		{
			return null;
		}

		public virtual void quickInspect(PointData worldPos)
		{
		}

		public virtual void selectInspectableAt(PointData stageMouse)
		{
		}

		public virtual void selectInspectable(Inspectable inspectable)
		{
		}

		public virtual void revalidateSelectedInspectables()
		{
		}

		public virtual void prepareForNewTraveler()
		{
		}

		public bool getStaticInspectableNeedsRender(Inspectable inspectable, string existingFactPath)
		{
			return false;
		}

		public void renderStaticInspectable(Inspectable inspectable, bool innerFrame)
		{
		}

		public virtual void updateOverlay()
		{
		}

		public virtual double set_revealT(double t)
		{
			return 0.0;
		}

		public virtual PointData autoGetOpenButtonCenter()
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
