using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;
using play.stash;

namespace play.day.booth
{
	public class DeskItem : Ent
	{
		public static double kHideCountdownMax;

		public static double kPrintCountdownMax;

		public static double kPrintDelay;

		public static double kSpitCountdownMax;

		public static double kDragClickDist;

		public static double kMountDropSink;

		public static double kCarouselFromSlotCountdownMax;

		public static double kCarouselFloatSpacing;

		public string id;

		public string idWithIndex;

		public bool visible;

		public bool dragging;

		public bool wasDragged;

		public bool canPinch;

		public Function onClick;

		public Function whenGiven;

		public Function whenPutInFiler;

		public Function whenRemoveFromFiler;

		public Function whenHidden;

		public Function whenMounted;

		public Function whenDoubleClicked;

		public Function testGiveable;

		public Function testHasLink;

		public Sprite rackSprite;

		public Reveal reveal;

		public PointData visaCenter;

		public SoundsDef soundsDef;

		public Sprite outerSprite;

		public Sprite innerSprite;

		public Sprite filerSprite;

		public Sprite mountSprite;

		public Sprite innerShadowSprite;

		public Sprite innerStampInkSprite;

		public PointData innerShadowOffset;

		public DeskItemPlacement placement;

		public PointData dragStartOffset;

		public PointData dragStartStagePos;

		public double dragStartTime;

		public DeskItemPlacement dragStartPlacement;

		public PointData dragCurStagePos;

		public bool draggingMoved;

		public double dropVel;

		public PointData outerSize;

		public PointData innerSize;

		public PointData filerSize;

		public bool innerIsOddShape;

		public Sprite giveIconSprite;

		public DeskItemState state;

		public double animCountdown;

		public PointData hideStartPos;

		public Hide hide;

		public Filer filer;

		public PointData posInFiler;

		public FilerType filerType;

		public bool putInFilerOnce;

		public bool removedFromFilerOnce;

		public TouchDrag touchDrag;

		public int touchGlowId;

		public TouchGlows touchGlows;

		public Carousel carousel;

		public int controlledByCarouselCount;

		public int carouselReactPointerCount;

		public bool controlledByCarouselShowInnerShadow;

		public bool waitingToSpitFromRight;

		public bool multitouchEnabled;

		public DockPoint dockPoint;

		public Array visuals;

		public Array innerVisuals;

		public Array filerVisuals;

		public Fill debugHitRectFill;

		public Solo_app_vis_Point workPointSolo;

		static DeskItem()
		{
		}

		public DeskItem(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DeskItem(Ent parent_, string id_, Filer filer_, Reveal reveal_, Hide hide_, FilerType filerType_, SoundsDef soundsDef_, TouchGlows touchGlows_, Carousel carousel_, PointData visaCenter_, bool canPinch_, bool multitouchEnabled_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_DeskItem(DeskItem __hx_this, Ent parent_, string id_, Filer filer_, Reveal reveal_, Hide hide_, FilerType filerType_, SoundsDef soundsDef_, TouchGlows touchGlows_, Carousel carousel_, PointData visaCenter_, bool canPinch_, bool multitouchEnabled_)
		{
		}

		public static void coordinateReavelFloating(Ent deskItemsParent)
		{
		}

		public bool get_isInFiler()
		{
			return false;
		}

		public bool get_isHidden()
		{
			return false;
		}

		public bool get_isHiding()
		{
			return false;
		}

		public bool get_isGiving()
		{
			return false;
		}

		public bool get_wasGiven()
		{
			return false;
		}

		public bool get_isOnDesk()
		{
			return false;
		}

		public bool get_isOnWall()
		{
			return false;
		}

		public bool get_canGive()
		{
			return false;
		}

		public bool get_canHangOnWall()
		{
			return false;
		}

		public bool get_canConfiscate()
		{
			return false;
		}

		public bool get_isFloating()
		{
			return false;
		}

		public Giveable get_giveable()
		{
			return null;
		}

		public bool get_isBlockingOtherGiving()
		{
			return false;
		}

		public int get_onlyPointerId()
		{
			return 0;
		}

		public virtual PointData set_innerShadowOffset(PointData p)
		{
			return null;
		}

		public bool get_hasDockPoint()
		{
			return false;
		}

		public bool get_hasCarousel()
		{
			return false;
		}

		public bool get_isControlledByCarousel()
		{
			return false;
		}

		public bool get_isOnlyFiler()
		{
			return false;
		}

		public override Rect worldRect()
		{
			return null;
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual bool makeStash(StashedBoothPaperState paperState)
		{
			return false;
		}

		public virtual void restoreFromStash(StashedBoothPaperState paperState, PointData mountPos)
		{
		}

		public virtual void startRevealAnim(PointData mountPos)
		{
		}

		public virtual void startHideAnim(Hide overrideHide)
		{
		}

		public virtual void setOuterImage(Image outerImage)
		{
		}

		public virtual void setInnerImage(Image innerImage, bool innerIsOddShape_)
		{
		}

		public virtual void addInnerVisual(Visual innerVisual)
		{
		}

		public virtual void setFilerImage(Image filerImage)
		{
		}

		public virtual void addFilerVisual(Visual filerVisual)
		{
		}

		public virtual void setMountImage(Image mountImage)
		{
		}

		public virtual void setRackImage(Image rackImage)
		{
		}

		public virtual void returnToDock()
		{
		}

		public virtual DeskItemPlacement set_placement(DeskItemPlacement p)
		{
			return null;
		}

		public virtual bool applyStampInkToInner(Image inkImage, PointData inkWorldPos)
		{
			return false;
		}

		public PointData workPointSoloLock()
		{
			return null;
		}

		public void workPointSoloUnlock()
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public virtual void initInFiler(PointData pos_)
		{
		}

		public virtual void animateReveal(double dt)
		{
		}

		public virtual void animateHide(double dt)
		{
		}

		public virtual void clip(Visual visual, Rect bounds)
		{
		}

		public virtual void updateClipRects()
		{
		}

		public virtual void moveDepthToTop()
		{
		}

		public virtual void setInnerVisualsLayer(int layer)
		{
		}

		public virtual bool unfloatIfPossible()
		{
			return false;
		}

		public virtual bool startCustomDrag(PointData mouseInWorld)
		{
			return false;
		}

		public virtual bool isOverFiler(PointData mouseInBooth)
		{
			return false;
		}

		public virtual void updateCustomDrag(double dt)
		{
		}

		public virtual void clampPlacementPos()
		{
		}

		public virtual void endCustomDrag()
		{
		}

		public virtual bool wantMoveDepthToTopWhileDragging()
		{
			return false;
		}

		public virtual void commitToFiler()
		{
		}

		public bool getDragIsCommitted(PointData stagePos)
		{
			return false;
		}

		public void killTouchGlow()
		{
		}

		public virtual bool confirmHitTestPointVisible(PointData stagePos)
		{
			return false;
		}

		public virtual Visual getInnerVisualAt(PointData worldPos)
		{
			return null;
		}

		public virtual Array getInnerVisualsAt(PointData worldPos)
		{
			return null;
		}

		public virtual Visual getOuterVisualAt(PointData worldPos)
		{
			return null;
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public virtual double innerWidth()
		{
			return 0.0;
		}

		public virtual double innerHeight()
		{
			return 0.0;
		}

		public virtual bool innerCheckHit(PointData worldPos)
		{
			return false;
		}

		public virtual bool carouselStartGivingIfPossible()
		{
			return false;
		}

		public virtual void carouselSetControlledForOneFrame(object showInnerShadow)
		{
		}

		public bool carouselIsInner()
		{
			return false;
		}

		public virtual void carouselSetPlacement(DeskItemPlacement placement_, bool maintainCenter)
		{
		}

		public virtual void carouselSaveMountPos(PointData mountPos)
		{
		}

		public virtual void carouselCommitToFiler()
		{
		}

		public virtual CarouselReactPointerResult carouselReactPointer(Pointer pointer)
		{
			return null;
		}

		public virtual bool carouselCheckHitLink(PointData worldPos)
		{
			return false;
		}

		public virtual void carouselOpenFiler()
		{
		}

		public virtual double carouselYAboveFiler()
		{
			return 0.0;
		}

		public virtual bool carouselGetPutInFilerOnce()
		{
			return false;
		}

		public virtual double filerHeight()
		{
			return 0.0;
		}

		public virtual bool autoTestHit(PointData worldPos)
		{
			return false;
		}

		public virtual PointData autoInnerSize()
		{
			return null;
		}

		public virtual PointData autoGetSizeForPlacement(DeskItemPlacement forPlacement)
		{
			return null;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
		}

		public virtual Image autoRenderInnerVisualsToImage()
		{
			return null;
		}

		public virtual PointData autoUnclippedCenter()
		{
			return null;
		}

		public virtual Array tutorGetInnerVisuals()
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
