using haxe.ds;
using haxe.lang;

namespace data
{
	public class EndlessStyle : HxObject
	{
		public string id;

		public string name;

		public string description;

		public double timeLimit;

		public bool reportScoreMax;

		public StringMap actions;

		public ScoreScale scoreScale;

		public string iconAssetName;

		public string buttonAssetName;

		public string leaderboardIdFragment;

		public string bulletin;

		public EndlessStyle(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndlessStyle(Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_EndlessStyle(EndlessStyle __hx_this, Xml node)
		{
		}

		public virtual bool get_hasTimeLimit()
		{
			return false;
		}

		public virtual Action getAction(string actionId)
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
