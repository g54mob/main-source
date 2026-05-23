using app;
using data;
using haxe.lang;
using play.day;

namespace play.night
{
	public class Family : HxObject
	{
		public Array members;

		public Budget budget;

		public Array messages;

		public FactAdaptorInt numEscapePassports;

		public int numFamilyPassports;

		public FactAdaptorInt haveFamilyPassports;

		public FactAdaptorInt haveNiece;

		public FactAdaptorStringArray tokenIds;

		public FactAdaptorString apartmentClass;

		public string wantEndId;

		public FactAdaptorInt savings;

		public FactAdaptorInt rent;

		public FactAdaptorInt heat;

		public FactAdaptorInt flags;

		public Calendar calendar;

		public FactAdaptorString calendarAdaptor;

		public Db db;

		public Rand rand;

		public AlltimeStats alltimeStats;

		public StoryState storyState;

		public Summary daySummary;

		public Family(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Family(Db db_, Rand rand_, AlltimeStats alltimeStats_, StoryState storyState_, Summary daySummary_, bool easyMode)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_Family(Family __hx_this, Db db_, Rand rand_, AlltimeStats alltimeStats_, StoryState storyState_, Summary daySummary_, bool easyMode)
		{
		}

		public static object getSummary(FactSet storyFacts)
		{
			return null;
		}

		public static Gender getSpeechGender(FamilyMember member)
		{
			return null;
		}

		public static string buildMessage(Lang lang, string textIdPrefix, Array members)
		{
			return null;
		}

		public virtual bool getEveryoneIsDead()
		{
			return false;
		}

		public virtual int getNumMembersAlive()
		{
			return 0;
		}

		public virtual FamilyVisuals makeVisuals(Layout layout)
		{
			return null;
		}

		public virtual void applyEventWithId(string eventId)
		{
		}

		public virtual void applyEvent(NightEvent @event)
		{
		}

		public virtual string expandExpressionLhs(string lhs)
		{
			return null;
		}

		public virtual void applyRentAndHeatAffectingEvents(Array nightEventIds)
		{
		}

		public virtual void applyOp(Op op)
		{
		}

		public virtual FamilyMember getMember(string id)
		{
			return null;
		}

		public virtual void applyBudget()
		{
		}

		public virtual void adjustAllStats(string statId, int delta)
		{
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual int debugGetSavings()
		{
			return 0;
		}

		public virtual void debugMakeEveryoneSick()
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

		public override string ToString()
		{
			return null;
		}
	}
}
