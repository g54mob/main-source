using app;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class WorldDef : HxObject
	{
		public Array nationNodes;

		public Array durationNodes;

		public Array jobNodes;

		public Array districtNodes;

		public Array purposeDefs;

		public Array autoPaperDefs;

		public Array vaccineNodes;

		public StringMap confiscationDefs;

		public Xml miscNode;

		public Array rulebookPageNodes;

		public StringMap locs;

		public WorldDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public WorldDef(Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_WorldDef(WorldDef __hx_this, Xml node)
		{
		}

		public virtual Array getRandomAccessNations(Rand rand, bool includeArstotzka, int count)
		{
			return null;
		}

		public virtual string getRandomNationality(Rand rand, string purpose)
		{
			return null;
		}

		public virtual Array getPotentiallyValidPurposes(string nation, string rules)
		{
			return null;
		}

		public virtual string getRandomPurpose(Rand rand, ErrorLib errorLib, string nation, string rules, string errorIdPatterns, bool forInvalid)
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

		public virtual string getMiscAttribute(string id)
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
