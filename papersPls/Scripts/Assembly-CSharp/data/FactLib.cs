using app;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class FactLib : HxObject
	{
		public WorldDef worldDef;

		public StringMap docDefs;

		public StringMap factDefs;

		public List groupDefs;

		public Lang lang;

		public Rand rand;

		public ErrorLib errorLib;

		public Array persistPaperIds;

		public FactLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FactLib(Res res, Lang lang_, ErrorLib errorLib_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FactLib(FactLib __hx_this, Res res, Lang lang_, ErrorLib errorLib_)
		{
		}

		public virtual FactSet getFacts(string rootId)
		{
			return null;
		}

		public virtual bool isMultiPaper(string paperId)
		{
			return false;
		}

		public virtual int getPaperMoney(string paperId)
		{
			return 0;
		}

		public virtual string getPaperAchievementId(string paperId)
		{
			return null;
		}

		public virtual string getPaperSayTrade(string paperId)
		{
			return null;
		}

		public virtual bool hasFact(string factPath)
		{
			return false;
		}

		public virtual bool getFactIsEditable(string path)
		{
			return false;
		}

		public virtual string getFactFormat(string path, string def)
		{
			return null;
		}

		public virtual string getFactPrefix(string path)
		{
			return null;
		}

		public virtual bool getFactInvalidatesPath(string path, string value, string nation, string otherPath)
		{
			return false;
		}

		public virtual Array debugGetInvalidatedPathDescriptions(string path)
		{
			return null;
		}

		public virtual string getCiteText(string path, string value)
		{
			return null;
		}

		public virtual Array getClearConfusionFactPaths(string paperId)
		{
			return null;
		}

		public virtual FactGroup getExpandedFactGroup(FactGroup factGroup, string nationality)
		{
			return null;
		}

		public virtual Array getFactGroups(string nationality)
		{
			return null;
		}

		public virtual double generatePaperExpirationDate(Rand rand, string paperId, double nowDate, double durationInMonths)
		{
			return 0.0;
		}

		public virtual string getPaperStay(string paperId)
		{
			return null;
		}

		public virtual bool getPaperPersistsForGame(string paperId)
		{
			return false;
		}

		public virtual Array getPersistPaperIds()
		{
			return null;
		}

		public virtual bool getShouldNoticeError(string path)
		{
			return false;
		}

		public virtual string getConfiscationWhen(string confiscationId)
		{
			return null;
		}

		public virtual string getConfiscationRuleDesc(string confiscationId)
		{
			return null;
		}

		public virtual string getConfiscationErrorDesc(string confiscationId)
		{
			return null;
		}

		public virtual Array debugGetAllPaperIds()
		{
			return null;
		}

		public virtual FactSet debugGetAllFacts()
		{
			return null;
		}

		public virtual string getMiscAttribute(string id)
		{
			return null;
		}

		public virtual Array getRandomAccessNations(Rand rand, bool includeArstotzka, int count)
		{
			return null;
		}

		public virtual string getRandomNationality(Rand rand, string purpose)
		{
			return null;
		}

		public virtual string getRandomPurpose(Rand rand, string nation, string rules, string errorIdPatterns, object forInvalid)
		{
			return null;
		}

		public virtual Array getPotentiallyValidPurposes(string nation, string rules)
		{
			return null;
		}

		public virtual Array getAutoPaperIds(string purpose, string rules)
		{
			return null;
		}

		public virtual string getRandomDuration(Rand rand, string purpose)
		{
			return null;
		}

		public virtual Array debugGetNations()
		{
			return null;
		}

		public virtual string getRandomDistrict(Rand rand)
		{
			return null;
		}

		public virtual string getRandomJob(Rand rand)
		{
			return null;
		}

		public virtual string getDurationText(string duration)
		{
			return null;
		}

		public virtual string getRandomIssuingCity(Rand rand, string nationality)
		{
			return null;
		}

		public virtual string getRandomVaccine(Rand rand)
		{
			return null;
		}

		public virtual string getRulebookPageMask(string rules, string confiscationId)
		{
			return null;
		}

		public virtual string getLocalized(string str)
		{
			return null;
		}

		public virtual Array getLocalizedAll(object iter)
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
