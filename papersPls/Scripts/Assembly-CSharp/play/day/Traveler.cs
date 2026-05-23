using app;
using app.vis;
using data;
using haxe.ds;
using haxe.lang;

namespace play.day
{
	public class Traveler : HxObject
	{
		public Face face;

		public Face docFace;

		public bool male;

		public TravelerName name;

		public string idNumber;

		public string nationality;

		public List initialPaperIds;

		public Error modifiedError;

		public Array customFactGroups;

		public int criminalIndex;

		public string special;

		public bool forceDeny;

		public bool slow;

		public string customLeaveDir;

		public Op responseOp;

		public FingerprintCode fingerprintCode;

		public double heightInMeters;

		public int weight;

		public string duration;

		public string purpose;

		public string job;

		public string district;

		public string specId;

		public string issuingCity;

		public string contrabandTypes;

		public StringMap contrabands;

		public int numVaccines;

		public bool canDetain;

		public string noFilerPaperId;

		public bool haveClosedShutter;

		public bool haveDroppedDetainButton;

		public bool poisoned;

		public bool detained;

		public double idleTime;

		public bool enteredBefore6PM;

		public bool gaveStampedPassport;

		public bool confiscatedPassportAtSomePoint;

		public Db db;

		public Rand rand;

		public Array wantPaperIdRegs;

		public Array rejectPaperIdRegs;

		public Array bodyImages;

		public Traveler(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Traveler(Db db_, Rand rand_, FaceCycler faceCycler, NameCycler nameCycler, TravelerSpec spec, Error error, Array unusedCriminals)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_Traveler(Traveler __hx_this, Db db_, Rand rand_, FaceCycler faceCycler, NameCycler nameCycler, TravelerSpec spec, Error error, Array unusedCriminals)
		{
		}

		public static string makeRandomIdNumber(Rand rand)
		{
			return null;
		}

		public static string invalidateIdNumber(Rand rand, string num)
		{
			return null;
		}

		public virtual bool get_isSpecial()
		{
			return false;
		}

		public virtual bool get_specialEnterRight()
		{
			return false;
		}

		public virtual bool get_hasBomb()
		{
			return false;
		}

		public virtual int get_heightInCm()
		{
			return 0;
		}

		public virtual double getBirthDate(double nowDate)
		{
			return 0.0;
		}

		public virtual void addWantPaperId(string pattern)
		{
		}

		public virtual void addRejectPaperId(string pattern)
		{
		}

		public virtual void setNoFilerPaperId(string paperId)
		{
		}

		public virtual bool canGivePaper(string paperId)
		{
			return false;
		}

		public virtual string getDescription()
		{
			return null;
		}

		public virtual Image getBodyImage(bool nude, bool front)
		{
			return null;
		}

		public virtual Image getContrabandImage(Rand rand, string loc)
		{
			return null;
		}

		public virtual Array getResponseRunOps(string id)
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
