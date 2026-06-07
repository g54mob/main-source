using app.vis;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class FactDef : HxObject
	{
		public string path;

		public string id;

		public string val;

		public string valLoc;

		public string prefix;

		public bool editable;

		public string format;

		public PointData range;

		public bool noticeErrors;

		public Array invalidateDefs;

		public Array citeDefs;

		public FactDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FactDef(DocDef docDef, Xml node, string overrideId, string overrideVal)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FactDef(FactDef __hx_this, DocDef docDef, Xml node, string overrideId, string overrideVal)
		{
		}

		public virtual string getCite(FactLib factLib, Lang lang, StringMap docDefs, string curVal)
		{
			return null;
		}

		public virtual bool getInvalidatesPath(string curValue, string nation, string otherPath)
		{
			return false;
		}

		public virtual Array debugGetInvalidatedPathDescriptions()
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
