using app;
using app.ent;
using app.vis;
using data;
using haxe.ds;
using haxe.lang;
using play.day.border;
using play.stash;
using play.ui;

namespace play.day.booth
{
	public class Booth : Ent
	{
		public Function whenTravelerLeaves;

		public Function whenDetainStart;

		public Function whenDetaineeLeaves;

		public Ent papersRootEnt;

		public BoothEngine engine;

		public Sprite wallSprite;

		public ConsoleEnt consoleEnt;

		public List papers;

		public Sprite deskSprite;

		public BorderCam borderCamL;

		public BorderCam borderCamR;

		public Shutter shutter;

		public TravelerEnt travelerEnt;

		public InspectUi inspectUi;

		public IStampBar stampBar;

		public Button shutterSwitchButton;

		public Clock boothClock;

		public Stater stater;

		public SpeechChat speechChat;

		public DropButton fingerprintButton;

		public DropButton searchButton;

		public DropButton detainButton;

		public Array nonPaperInspectables;

		public Fill introFill;

		public RevealTextEnt introRevealTextEnt;

		public GroupEnt introGroupEnt;

		public bool waitingForFirstTraveler;

		public Day day;

		public int borderAmbientPlayId;

		public int boothAmbientPlayId;

		public Filer filer;

		public Curtain curtain;

		public int stayingPapersRevealOnDeskIndex;

		public Array stayingPaperIdsAtStart;

		public double timeBombStartTime;

		public double timeBombBeepCountdown;

		public TouchGlows touchGlows;

		public StoryState storyState;

		public Carousel carousel;

		public Rack rack;

		public DropRemote dropRemote;

		public KeyDesk keyDesk;

		public GroupEnt counterGroupEnt;

		public CriminalPoster criminalPoster;

		public CriminalPosterPin criminalPosterPin;

		public bool busyWithBorderObservationOnly;

		public bool nuditySetting;

		public Sprite debugErrorFlagSprite;

		public Array debugNonInterrogatedFactPaths;

		public Booth(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Booth(Ent parent_, BoothEnvRun run, Day day_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Booth(Booth __hx_this, Ent parent_, BoothEnvRun run, Day day_)
		{
		}

		public virtual bool get_readyForNextTraveler()
		{
			return false;
		}

		public virtual bool get_timeIsUp()
		{
			return false;
		}

		public BoothEnv get_boothEnv()
		{
			return null;
		}

		public virtual void applyMountedPaperIdsOrder(Array mountedPaperIds)
		{
		}

		public virtual StashedBooth makeStash()
		{
			return null;
		}

		public virtual bool restoreFromStash(StashedBooth s)
		{
			return false;
		}

		public virtual bool checkHaveStampedSomething()
		{
			return false;
		}

		public virtual bool checkHaveFloatingDeskItem()
		{
			return false;
		}

		public virtual bool checkWillEnableActionButtonSoon()
		{
			return false;
		}

		public virtual bool checkCurtainIsClosed()
		{
			return false;
		}

		public virtual bool isBefore6PM()
		{
			return false;
		}

		public virtual bool updateHidingPapers()
		{
			return false;
		}

		public virtual void onGuardsReadyToDetain()
		{
		}

		public virtual bool applyNextQuedOp()
		{
			return false;
		}

		public virtual void startIntro()
		{
		}

		public virtual void inspectUi_onOpen()
		{
		}

		public virtual void inspectUi_onDenialEnabledClick()
		{
		}

		public virtual void dropButton_onClick(Button d)
		{
		}

		public virtual void inspectUi_onInterrogateClick()
		{
		}

		public virtual void acceptNextTraveler()
		{
		}

		public virtual void onCallingNextTraveler()
		{
		}

		public virtual void goBusyWithBorder(object observationOnly)
		{
		}

		public virtual void moveAllFloatingDeskItemsToCarousel()
		{
		}

		public Paper getPaperForDeskItem(DeskItem deskItem)
		{
			return null;
		}

		public virtual void deskItem_onGiven(DeskItem deskItem)
		{
		}

		public virtual void deskItem_onPutInFiler(DeskItem deskItem, bool firstTime)
		{
		}

		public virtual void deskItem_onRemoveFromFiler(DeskItem deskItem, bool firstTime)
		{
		}

		public virtual void deskItem_onHidden(DeskItem deskItem)
		{
		}

		public virtual Giveable deskItem_testGiveable(DeskItem deskItem)
		{
			return null;
		}

		public virtual void deskItem_onMounted(DeskItem deskItem, bool mounted)
		{
		}

		public virtual void deskItem_onDoubleClicked(PointData worldPos)
		{
		}

		public virtual void shutterSwitch_onClick(Button b)
		{
		}

		public virtual void hideTransientPapers()
		{
		}

		public virtual void engine_onPaperPageUpdated(string idWithIndex)
		{
		}

		public virtual void engine_onWantLeaveEarly()
		{
		}

		public virtual void engine_onWantResist()
		{
		}

		public virtual void engine_onWantCustomAction(string action)
		{
		}

		public virtual void engine_onWantShutterOpenOrClosed(bool open)
		{
		}

		public virtual void engine_onActionEnabledOrDisabled(EngineAction action, bool enabled)
		{
		}

		public virtual void engine_onPapersAdded(Array enginePapers)
		{
		}

		public virtual void engine_onPaperRemoved(string idWithIndex)
		{
		}

		public virtual void engine_onWantedPapersChanged()
		{
		}

		public virtual void unfloatWantedPapers()
		{
		}

		public virtual void engine_onSpeak(string text, bool fromInspector)
		{
		}

		public virtual void engine_onWantEnd(string endId)
		{
		}

		public virtual Array getSortedPapers()
		{
			return null;
		}

		public virtual Paper getFocusedPaperOnDesk(Input input)
		{
			return null;
		}

		public virtual void debugStampAll(StampApprovalKind approvalType)
		{
		}

		public virtual void debugGiveAll(string exceptPaperId)
		{
		}

		public virtual void debugGive(string paperId)
		{
		}

		public virtual Paper applyStampInk(Array sortedPapers, StampApprovalKind approvalType, Image image, PointData stagePos)
		{
			return null;
		}

		public virtual void onApplyStampInk(StampApprovalKind approvalKind, Image inkImage, PointData inkWorldPos)
		{
		}

		public virtual void paper_onUnhandledLinkClicked(Paper paper, string link, Rect boothRect)
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void timeBombExplode()
		{
		}

		public virtual Inspectable getInspectable(PointData stagePos)
		{
			return null;
		}

		public virtual Array getAllVisibleInspectables(object includeOffscreen)
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

		public virtual void attachBorderCamsToBorder(Border border)
		{
		}

		public virtual bool autoIsWorking()
		{
			return false;
		}

		public virtual bool autoIsEmpty()
		{
			return false;
		}

		public virtual bool autoIsBusyWithBorder()
		{
			return false;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
		}

		public virtual Paper autoFindPaper(string paperId)
		{
			return null;
		}

		public virtual int autoGetPaperCurPageIndex(string paperId)
		{
			return 0;
		}

		public virtual bool autoHasBoothFactPath(string factPath)
		{
			return false;
		}

		public virtual Rack tutorGetRack()
		{
			return null;
		}

		public virtual Carousel tutorGetCarousel()
		{
			return null;
		}

		public virtual Paper tutorGetBulletinPaper()
		{
			return null;
		}

		public virtual bool tutorGetHavePassport()
		{
			return false;
		}

		public virtual bool tutorGetHaveFloatingDeskItem()
		{
			return false;
		}

		public virtual bool tutorGetHaveStampedSomething()
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
