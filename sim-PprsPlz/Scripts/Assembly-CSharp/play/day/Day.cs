using app;
using data;
using haxe.ds;
using haxe.lang;
using play.stash;

namespace play.day
{
	public class Day : HxObject
	{
		public int id;

		public double date;

		public string title;

		public Array bulletin;

		public StringMap rules;

		public int minTravelers;

		public double durationInMinutes;

		public int guardFlags;

		public Attack attack;

		public bool hasLeftJailors;

		public bool hasBoss;

		public int numMadeTravelers;

		public int numProcessedTravelersPaid;

		public int numProcessedTravelersUnpaid;

		public FactSet facts;

		public DayNews news;

		public Array extraPaperIds;

		public Array extraBulletingPageIds;

		public int numDetains;

		public FriendlyGuard friendlyGuard;

		public Array criminals;

		public bool testingTraveler;

		public string confiscationId;

		public int waitingLineLength;

		public Endless endless;

		public string openRulebookPage;

		public int seed;

		public bool isFirstSnipingDay;

		public Rand newsRand;

		public Rand borderRand;

		public Rand nightRand;

		public Rand travelerRand;

		public Array confiscatedPapers;

		public bool hadBomber;

		public bool hadPoisoning;

		public int bribeMoney;

		public Array tokenIds;

		public AttackResult attackResult;

		public Function whenAddNews;

		public Function whenAddNightEvent;

		public Array nightEventIds;

		public Array travelerIds;

		public int featureFlags;

		public Array citations;

		public DayRun run;

		public Day(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Day(DayRun run_, int id_, Endless endless_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_Day(Day __hx_this, DayRun run_, int id_, Endless endless_)
		{
		}

		public static double dayIdToDate(int dayId, bool endless)
		{
			return 0.0;
		}

		public virtual int get_numCitations()
		{
			return 0;
		}

		public virtual int get_numPenalties()
		{
			return 0;
		}

		public virtual int get_penaltyCost()
		{
			return 0;
		}

		public virtual bool get_hasFriendlyGuard()
		{
			return false;
		}

		public StoryState get_storyState()
		{
			return null;
		}

		public bool get_wantBoothTutorial()
		{
			return false;
		}

		public virtual bool get_canStash()
		{
			return false;
		}

		public virtual StashedDay makeStash()
		{
			return null;
		}

		public virtual bool restoreFromStash(StashedDay s)
		{
			return false;
		}

		public virtual void addDetain()
		{
		}

		public virtual void killFriendlyGuard()
		{
		}

		public virtual void makeTravelerTest(Array travelerIds_)
		{
		}

		public bool hasGuard(int index)
		{
			return false;
		}

		public bool hasFeature(Feature f)
		{
			return false;
		}

		public virtual bool hasRule(string r)
		{
			return false;
		}

		public virtual bool getNextTravelerIsChattyPrisonGuard()
		{
			return false;
		}

		public virtual bool getFirstTravelerIsSecretPolice()
		{
			return false;
		}

		public string getNextTravelerId()
		{
			return null;
		}

		public virtual TravelerSpec makeTravelerSpec()
		{
			return null;
		}

		public virtual Citation addCitation(string message)
		{
			return null;
		}

		public virtual void addConfiscatedPaper(ConfiscatedPaper confiscatedPaper)
		{
		}

		public virtual string findConfiscatedIdForPaperIdWithIndex(string paperIdWithIndex)
		{
			return null;
		}

		public virtual void setAttackResultWithPriority(AttackResult ar)
		{
		}

		public virtual void addTomorrowVisitor(string travelerId)
		{
		}

		public virtual Summary getSummary()
		{
			return null;
		}

		public virtual void addTravelerNews(string newsId)
		{
		}

		public virtual void addNightEvent(string nightEventId)
		{
		}

		public void incStat(string statId, object delta)
		{
		}

		public virtual ErrorContext makeErrorContext(TravelerSpec travelerSpec)
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
