using System;
using app.ent;
using app.vis;
using data;
using haxe.ds;
using haxe.lang;
using play;
using play.day;
using play.day.booth;
using play.day.border;
using play.screen;
using play.ui;

namespace test.auto
{
	public class AutoEnv : HxObject
	{
		public static Array kInspectableClickCorners;

		public Layout layout;

		public AutoRoute autoRoute;

		public Array wantAuditKinds;

		public int kDeskItemSpacing;

		public Trunk trunk;

		public Bootstrap bootstrap;

		public Rect screenRect;

		public StringMap deskItemInnerSizeMap;

		public StampBar stampBar;

		public StringMap deskItemIters;

		public int linkCenterStagger;

		public Array sentryErrors;

		public Date startDate;

		public double startStamp;

		static AutoEnv()
		{
		}

		public AutoEnv(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoEnv(Bootstrap bootstrap_, AutoRoute autoRoute_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoEnv(AutoEnv __hx_this, Bootstrap bootstrap_, AutoRoute autoRoute_)
		{
		}

		public static Ent findFirstEntTyped(Ent parent, System.Type entClass)
		{
			return null;
		}

		public static DeskItem getMountedDeskItemAtWorldPos(Ent parent, PointData worldPos)
		{
			return null;
		}

		public Booth get_booth()
		{
			return null;
		}

		public Border get_border()
		{
			return null;
		}

		public Carousel get_carousel()
		{
			return null;
		}

		public GameScreen get_gameScreen()
		{
			return null;
		}

		public bool get_hasCarousel()
		{
			return false;
		}

		public virtual Node getRouteTabNode(string id)
		{
			return null;
		}

		public virtual DeskItemIter deskItemIter(string id)
		{
			return null;
		}

		public virtual Day getDay()
		{
			return null;
		}

		public virtual int getDayId()
		{
			return 0;
		}

		public virtual EndReport getEndReport()
		{
			return null;
		}

		public virtual int getStashGeneration()
		{
			return 0;
		}

		public virtual bool hasStash()
		{
			return false;
		}

		public virtual void restoreFromStash()
		{
		}

		public virtual StoryState getStoryState()
		{
			return null;
		}

		public virtual void skipToDay(int dayId)
		{
		}

		public virtual void skipToTraveler(string travelerId)
		{
		}

		public virtual Array getEndIds()
		{
			return null;
		}

		public virtual void skipToEnd(string endId)
		{
		}

		public virtual int getTravelerNum()
		{
			return 0;
		}

		public virtual Traveler getTraveler()
		{
			return null;
		}

		public virtual string getTravelerId()
		{
			return null;
		}

		public virtual Array findDeskItemsWithIdRegex(EReg paperIdEReg)
		{
			return null;
		}

		public virtual Image getDeskItemInnerImage(DeskItem deskItem)
		{
			return null;
		}

		public virtual bool hasBooth()
		{
			return false;
		}

		public virtual bool canConfiscatePassport()
		{
			return false;
		}

		public virtual bool hasButton(string buttonId)
		{
			return false;
		}

		public virtual bool isButtonOnscreen(string buttonId, object wantEntirelyOnscreen)
		{
			return false;
		}

		public virtual bool isBoothWorking()
		{
			return false;
		}

		public virtual bool isBoothEmpty()
		{
			return false;
		}

		public virtual IStampBar getStampBar()
		{
			return null;
		}

		public virtual DeskItemDrag getStampBarToggleDrag(bool open)
		{
			return null;
		}

		public virtual bool carouselHasFloatingDeskItems()
		{
			return false;
		}

		public virtual DeskItemDrag carouselGetNextDeskItemUnfloatClick()
		{
			return null;
		}

		public virtual bool getNeedsDenialReason()
		{
			return false;
		}

		public virtual bool canInspect()
		{
			return false;
		}

		public virtual bool isInspectUiOpen()
		{
			return false;
		}

		public virtual bool isBusyWithBorder()
		{
			return false;
		}

		public virtual bool isInterrogateButtonVisible()
		{
			return false;
		}

		public virtual PointData getInspectButtonCenter()
		{
			return null;
		}

		public virtual PointData getInterrogateButtonCenter()
		{
			return null;
		}

		public virtual PointData getButtonCenter(string buttonId)
		{
			return null;
		}

		public virtual PointData getEntWorldPos(string entName)
		{
			return null;
		}

		public virtual bool isEngineActionEnabled(EngineAction action)
		{
			return false;
		}

		public virtual DeskItemDrag getNextEngineActionClick(EngineAction action)
		{
			return null;
		}

		public virtual PointData getStampClickPos(StampApprovalKind approvalKind)
		{
			return null;
		}

		public virtual Rect getEntWorldRect(string entName, object clipAgainstScreen)
		{
			return null;
		}

		public virtual void confirmOnGameScreen(System.Type gameScreenClass)
		{
		}

		public virtual System.Type getCurGameScreenClass()
		{
			return null;
		}

		public virtual SpeechChat getSpeechChatEnt()
		{
			return null;
		}

		public virtual Array getAllDeskItems()
		{
			return null;
		}

		public virtual bool isSomeEntWaitingYes()
		{
			return false;
		}

		public virtual bool isSomeEntWaiting(Ent parent)
		{
			return false;
		}

		public virtual bool isBoothWaitingOnSomething()
		{
			return false;
		}

		public virtual bool hasTutor()
		{
			return false;
		}

		public virtual Array getTutorActions()
		{
			return null;
		}

		public virtual DeskItemDrag getDeskItemPointExposureDrag(DeskItem deskItem, PointData point)
		{
			return null;
		}

		public virtual Array getNewDeskItems(Array oldDeskItems)
		{
			return null;
		}

		public virtual bool hasNewDeskItems(Array oldDeskItems)
		{
			return false;
		}

		public virtual DeskItem findDeskItemWithId(string deskItemId)
		{
			return null;
		}

		public virtual DeskItemDrag getDeskItemExposureDrag(DeskItem deskItem)
		{
			return null;
		}

		public virtual DeskItemDrag getDeskItemDragUnderStamp(DeskItem deskItem, StampApprovalKind approvalKind)
		{
			return null;
		}

		public virtual DeskItemDrag getDeskItemDragToFace(DeskItem deskItem)
		{
			return null;
		}

		public virtual DeskItem getDeskItemAtHitPos(PointData worldPos)
		{
			return null;
		}

		public virtual bool isWallMountedDeskItemInParkingSpot(DeskItem deskItem, Rect parkingSpotRect)
		{
			return false;
		}

		public virtual DeskItemDrag getNextDeskItemCleanupDrag()
		{
			return null;
		}

		public virtual bool getDeskItemParkingSpotIsOnWall(DeskItem deskItem)
		{
			return false;
		}

		public virtual PointData getDeskItemWallMountPos(string paperDefId)
		{
			return null;
		}

		public virtual object getDeskItemParkingSpot(DeskItem deskItem, object switchCounterSides)
		{
			return null;
		}

		public virtual DeskItem getNextStampableDeskItem()
		{
			return null;
		}

		public virtual DeskItem getNextGiveableDeskItem(string exceptDeskItemId)
		{
			return null;
		}

		public virtual bool hasErrors()
		{
			return false;
		}

		public virtual bool hasDeskItemWithId(string deskItemId)
		{
			return false;
		}

		public virtual int getDeskItemRawPageIndex(DeskItem deskItem)
		{
			return 0;
		}

		public virtual int getDeskItemSequentialPageIndex(DeskItem deskItem)
		{
			return 0;
		}

		public virtual int getDeskItemSequentialPageCount(DeskItem deskItem)
		{
			return 0;
		}

		public virtual PointData getDeskItemNavLinkCenter(DeskItem deskItem, bool next)
		{
			return null;
		}

		public virtual PointData getDeskItemLinkCenter(DeskItem deskItem, string link)
		{
			return null;
		}

		public virtual object getErrorInspectNextPair(Array interrogatedErrorPairs)
		{
			return null;
		}

		public virtual DeskItemDrag getDeskItemMoveToInnerDrag(DeskItem deskItem, PointData targetTL, object includeExposureDrag)
		{
			return null;
		}

		public virtual Pincher getPincher()
		{
			return null;
		}

		public virtual bool getDeskItemIsInPincher(DeskItem deskItem)
		{
			return false;
		}

		public virtual DeskItemDrag carouselGetDeskItemFocusDrag(DeskItem deskItem)
		{
			return null;
		}

		public virtual DeskItemDrag getDeskItemExposeAndClickAt(DeskItem deskItem, PointData point)
		{
			return null;
		}

		public virtual DeskItemDrag getNextInspectDrag(object factPathPair)
		{
			return null;
		}

		public virtual DeskItemDrag getNextInspectableClick(string factPathL, string factPathR, object onlyWithHoldingEntGuid)
		{
			return null;
		}

		public virtual DeskItemDrag getNextExploreDrag(StringMap pageExploreHistory)
		{
			return null;
		}

		public virtual DeskItemDrag getNextPoisonDrag()
		{
			return null;
		}

		public virtual DeskItemDrag getNextFollowLinkDrag(string deskItemId, string link)
		{
			return null;
		}

		public virtual void mergeStayingPageExploreHistory(StringMap initialPageHistory, StringMap travelerPageHistory)
		{
		}

		public virtual RifleButton getRifleButton(Ent ent, bool tranq)
		{
			return null;
		}

		public virtual Node getRouteAttackNode()
		{
			return null;
		}

		public virtual bool getSnipeAttackWantTranq()
		{
			return false;
		}

		public virtual AutoSnipeTarget toSnipeTarget(string name)
		{
			return null;
		}

		public virtual bool canSnipe()
		{
			return false;
		}

		public virtual bool getSnipePosIsClickable(PointData snipePos)
		{
			return false;
		}

		public virtual DeskItemDrag getNextSnipeDrag(bool tranq)
		{
			return null;
		}

		public virtual bool isFilerOpen()
		{
			return false;
		}

		public virtual PointData getFilerHandleCenter()
		{
			return null;
		}

		public virtual DeskItemDrag getNextConfiscateDrag()
		{
			return null;
		}

		public virtual DeskItemDrag getNextOuterBoothExposeDrag()
		{
			return null;
		}

		public virtual Button findButton(Ent parent, string buttonId)
		{
			return null;
		}

		public virtual Ent findFirstEntNamed(Ent parent, string name)
		{
			return null;
		}

		public virtual Ent findFirstEntTypeNamed(Ent parent, System.Type entClass, string name)
		{
			return null;
		}

		public virtual Stamp findStamp(StampApprovalKind approvalKind)
		{
			return null;
		}

		public virtual int getNightScreenDayId()
		{
			return 0;
		}

		public virtual bool getBudgetIsAnimating()
		{
			return false;
		}

		public virtual Array getWantCheckedBudgetLineKinds()
		{
			return null;
		}

		public virtual PointData getNextBudgetLineClick(Array wantCheckedLineKinds)
		{
			return null;
		}

		public virtual void runSentry()
		{
		}

		public virtual bool hasSentryError()
		{
			return false;
		}

		public virtual string getSentryErrorMessages()
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
