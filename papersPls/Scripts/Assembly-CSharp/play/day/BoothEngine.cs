using app;
using data;
using haxe.lang;
using play.stash;

namespace play.day
{
	public class BoothEngine : HxObject
	{
		public BoothEnv env;

		public Day day;

		public bool mistakeCaught;

		public Array enginePapers;

		public int numTravelers;

		public bool wantLeaveEarly;

		public bool wantResist;

		public bool justPoisonedTraveler;

		public bool haveStampedSomething;

		public bool justMadeMistake;

		public OpQue opQue;

		public bool fast;

		public int enabledActions;

		public Array confiscatedPaperIds;

		public bool haveRunApprovedDeniedResponses;

		public int preventStashCount;

		public Function whenSpeak;

		public Function whenPapersAdded;

		public Function whenPaperRemoved;

		public Function whenWantShutterOpenOrClosed;

		public Function whenPaperPageUpdated;

		public Function whenWantLeaveEarly;

		public Function whenWantResist;

		public Function whenWantCustomAction;

		public Function whenActionEnabledOrDisabled;

		public Function whenWantedPapersChanged;

		public Function whenWantEnd;

		public BoothEnvRun run;

		public Tweener tweenerForSlowMode;

		public BoothEngine(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BoothEngine(BoothEnvRun run_, Day day_, Tweener tweenerForSlowMode_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_BoothEngine(BoothEngine __hx_this, BoothEnvRun run_, Day day_, Tweener tweenerForSlowMode_)
		{
		}

		public bool get_opQueHasItems()
		{
			return false;
		}

		public virtual bool get_canStash()
		{
			return false;
		}

		public virtual bool set_wantResist(bool w)
		{
			return false;
		}

		public virtual StashedBoothEngine makeStash()
		{
			return null;
		}

		public virtual bool restoreFromStash(StashedBoothEngine s)
		{
			return false;
		}

		public virtual void start()
		{
		}

		public virtual bool getEnabled(EngineAction action)
		{
			return false;
		}

		public virtual void setEnabled(EngineAction action, bool e)
		{
		}

		public virtual void handleEvent(EngineEvent @event)
		{
		}

		public virtual void addNewEnvPapers()
		{
		}

		public virtual void closeShutter()
		{
		}

		public virtual void incrementTravelerIdleTime(double dt)
		{
		}

		public virtual bool applyNextQuedOp(double time)
		{
			return false;
		}

		public virtual bool getOpQueHasItems()
		{
			return false;
		}

		public virtual bool shouldAutoConfiscatePaper(PaperDef def)
		{
			return false;
		}

		public virtual void clickAction(EngineAction action)
		{
		}

		public virtual string getLeaveDir()
		{
			return null;
		}

		public virtual void printSearchPhoto()
		{
		}

		public virtual void debugAddPaper(string paperId)
		{
		}

		public virtual void interrogateFactPaths(Array factPaths, Op debugForceOp)
		{
		}

		public virtual bool getPaperPoisoned(string idWithIndex)
		{
			return false;
		}

		public virtual void setPaperPoisoned(string idWithIndex)
		{
		}

		public virtual StampApproval getPaperApproval(string idWithIndex)
		{
			return null;
		}

		public virtual void setPaperApproval(string idWithIndex, StampApproval approval)
		{
		}

		public virtual void stampPaper(string idWithIndex, StampApprovalKind approvalType)
		{
		}

		public virtual bool canGivePaperToTraveler(string idWithIndex)
		{
			return false;
		}

		public virtual void givePaperToTraveler(string idWithIndex)
		{
		}

		public virtual void putPaperInFiler(string idWithIndex, bool firstTime)
		{
		}

		public virtual void removePaperFromFiler(string idWithIndex, bool firstTime)
		{
		}

		public virtual string confiscatePaper(string idWithIndex)
		{
			return null;
		}

		public virtual bool handleTimeBombUnscrew(int index)
		{
			return false;
		}

		public virtual TimeBombWireResult handleTimeBombCutWire(int index)
		{
			return null;
		}

		public virtual void handlePaperCustomLinkClicked(string paperId, string linkId)
		{
		}

		public virtual void speak(string text, bool fromInspector)
		{
		}

		public virtual EnginePaper findEnginePaper(string idWithIndex)
		{
			return null;
		}

		public virtual void removePaper(string idWithIndex)
		{
		}

		public virtual StampApproval get_givenApproval()
		{
			return null;
		}

		public virtual StampApproval set_givenApproval(StampApproval a)
		{
			return null;
		}

		public virtual bool applyTravelerResponseOps(string id)
		{
			return false;
		}

		public virtual bool applyDefaultResponseOps(string id)
		{
			return false;
		}

		public virtual Array expandConditionalOps(Array ops)
		{
			return null;
		}

		public virtual bool hasEnableButtonOpInQue()
		{
			return false;
		}

		public virtual void applyOps(Array ops, object fromQue)
		{
		}

		public virtual void applyUpdatedSettings()
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
