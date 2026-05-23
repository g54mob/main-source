using app;
using data;
using haxe.ds;
using haxe.lang;

namespace play.day
{
	public class TravelerContext : HxObject
	{
		public string travelerId;

		public FactSet dayFacts;

		public Db db;

		public StoryState storyState;

		public TravelerContext(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TravelerContext(Db db_, StoryState storyState_, string travelerId_, FactSet dayFacts_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_TravelerContext(TravelerContext __hx_this, Db db_, StoryState storyState_, string travelerId_, FactSet dayFacts_)
		{
		}

		public static void assignVar(Rand rand, Node node, StringMap vars)
		{
		}

		public virtual TravelerSpec makeTravelerSpec(Rand rand)
		{
			return null;
		}

		public virtual bool applyToSpec(Rand rand, TravelerSpec spec, Node node)
		{
			return false;
		}

		public virtual FactGroup getFactGroup(Node node)
		{
			return null;
		}

		public virtual bool testConditional(Rand rand, Array @params, int paramIndex, StringMap vars)
		{
			return false;
		}

		public virtual bool hasDayRule(string rule)
		{
			return false;
		}

		public virtual string expandExpressionLhs(string lhs)
		{
			return null;
		}

		public string getDayRules()
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
