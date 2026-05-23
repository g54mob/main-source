using app.plat;
using app.vis;
using haxe.ds;
using haxe.lang;

public class Layout : HxObject
{
	public static int kDesktopPixelWidth;

	public static int kDesktopPixelHeight;

	public static int kTabletPixelWidth;

	public static int kTabletPixelHeight;

	public static int kTabletPixelWidthMax;

	public static int kTabletPixelHeightMax;

	public static int kTabletDefaultCounterH;

	public static int kPhonePixelWidth;

	public static int kPhonePixelHeight;

	public static int kPhonePixelWidthMax;

	public static int kPhonePixelHeightMax;

	public static double kPhoneTabletAspectThresh;

	public static int kFingerprintButtonWidth;

	public static int kSearchButtonWidth;

	public static int kDetainButtonWidth;

	public static int kGiveZoneWidth;

	public static int kDefaultWallWidth;

	public static int kShutterSwitchWidth;

	public static int kFilerWidth;

	public static int kEndlessScoreboardWidth;

	public static int kTitleHeight;

	public static int kBorderFullWidth;

	public static int kBorderFullHeight;

	public Rect booth;

	public Rect boothInner;

	public Rect boothInnerClip;

	public Rect boothInnerClamp;

	public Rect boothOuter;

	public Rect boothOuterClamp;

	public Rect boothCarouselFilerClip;

	public Rect desk;

	public Rect console;

	public Rect wall;

	public Rect counter;

	public Rect wallMountArea;

	public Rect border;

	public Rect give;

	public PointData borderOuterBoothButton;

	public int borderOuterBoothButtonReactMargin;

	public double borderScale;

	public bool borderShowSnipingSurround;

	public PointData borderPersonHitSize;

	public double borderSnipingTimescale;

	public PointData shutterSwitch;

	public PointData stampBar;

	public PointData reasonSprite;

	public PointData filer;

	public PointData slotCenter;

	public double counterTopEdgeY;

	public double outerFloorMidY;

	public PointData fingerprintButton;

	public PointData searchButton;

	public PointData detainButton;

	public Rect interrogateButtonRect;

	public bool interrogateButtonTextCentered;

	public Rect inspectableCounter;

	public Rect inspectableFace;

	public Rect inspectableClock;

	public Rect inspectableWeight;

	public PointData consoleClock;

	public PointData consoleTranscriptBolt;

	public PointData consoleDate;

	public PointData consoleTravelerCount;

	public PointData consoleWeight;

	public ConsoleKind consoleKind;

	public double consoleClockHourWidth;

	public StringMap dockPoints;

	public Rect borderCamRectL;

	public Rect borderCamRectR;

	public double portraitHeightStretchT;

	public BoothLayout boothLayout;

	public bool useInspectMagnifier;

	public bool inspectInstructionsOnTop;

	public bool inspectDiagramFavorUpRight;

	public Rect inspectButtonOverrideHitRect;

	public int touchTargetExpand;

	public bool touch;

	public bool headerInEndless;

	public PointData endlessScoreboardPos;

	public bool endlessScoreboardScrollWithBorder;

	public int boothHeaderHeight;

	public Rect grabDeskItemGraceRect;

	public double tranqRifleButtonY;

	public double boothMountDragBottomY;

	public double boothPrintBottomY;

	public double stampBarEdgeGrace;

	public double filerEnvelopeSpacingY;

	public bool filerUseBigHandle;

	public PointData filerCountCenter;

	public int menuItemPaddingY;

	public int settingsPadding;

	public bool settingsTipsOnTop;

	public int settingsButtonX;

	public PointData settingsButtonSize;

	public double titleLogoScale;

	public bool titleStackFooter;

	public bool titleShowVersion;

	public double titleLogoTop;

	public double titleMenuCenterY;

	public PointData confirmBoxPadding;

	public int standardFooterButtonY;

	public int notchHeight;

	public int introTextWidth;

	public int nightMessageWidth;

	public double gameScreenHeaderY;

	public Aspect aspect;

	public Platform platform;

	public Shape shape;

	public int layerFiler;

	public int layerShutterShadow;

	public int layerMountedDeskItem;

	public int layerWall;

	public int layerStampDesk;

	public int layerTutorial;

	public int layerUnstashOverlay;

	public Rect rack;

	public Rect carousel;

	public Rect stampDesk;

	public bool showPauseButton;

	public int kPixelWidth;

	public int kPixelHeight;

	public int subpixelCount;

	static Layout()
	{
	}

	public Layout(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Layout(Platform platform_)
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Layout(Layout __hx_this, Platform platform_)
	{
	}

	public static object findBestPortraitScreenSize(int stageWidth, int stageHeight, int gameWidthMin, int gameWidthMax, int gameHeightMin, int gameHeightMax)
	{
		return null;
	}

	public bool get_isDesktop()
	{
		return false;
	}

	public int fromLandY(int y)
	{
		return 0;
	}

	public int fromLandX(int x)
	{
		return 0;
	}

	public int fromPortX(int x)
	{
		return 0;
	}

	public int fromPortY(int y)
	{
		return 0;
	}

	public virtual int landOrPort(int land, int port)
	{
		return 0;
	}

	public virtual double getFitScale(double defaultW, double defaultH, double availableH)
	{
		return 0.0;
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
