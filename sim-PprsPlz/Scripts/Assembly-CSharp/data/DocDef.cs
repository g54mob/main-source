using app;
using haxe.lang;

namespace data
{
	public class DocDef : HxObject
	{
		public string id;

		public string cite;

		public string stay;

		public bool multi;

		public int money;

		public string sayTrade;

		public string achievementId;

		public bool noticeErrors;

		public Array factDefs;

		public Array clearConfusionPaths;

		public DocDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DocDef(WorldDef worldDef, Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_DocDef(DocDef __hx_this, WorldDef worldDef, Xml node)
		{
		}

		public virtual void addFactDefs(WorldDef worldDef, Xml node)
		{
		}

		public virtual double generateExpirationDate(Rand rand, double nowDate, double durationInMonths)
		{
			return 0.0;
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
