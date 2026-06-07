using app;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class Lang : HxObject
	{
		public static string kAliasDefaultSwapSets;

		public static StringMap htmlEnts;

		public StringMap text;

		public StringMap repl;

		public LangFixed @fixed;

		public StringMap textHash;

		public StringMap replHash;

		public Array aliasSwapSetsUtf32;

		public Array typoNonLetterChars;

		static Lang()
		{
		}

		public Lang(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Lang(Res res, Uppercaser uppercaser)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Lang(Lang __hx_this, Res res, Uppercaser uppercaser)
		{
		}

		public static bool isMap(object d)
		{
			return false;
		}

		public static string cleanHtml(string str)
		{
			return null;
		}

		public virtual void loadFromXml(Xml xml)
		{
		}

		public virtual void buildAliasSwapSets(Uppercaser uppercaser)
		{
		}

		public virtual string getReplaced(string text, object replace0, object replace1, object replace2)
		{
			return null;
		}

		public virtual string makeAlias(Rand rand, string name, string swapSets)
		{
			return null;
		}

		public virtual string makeTypo(Rand rand, string name)
		{
			return null;
		}

		public virtual string formatVerboseDate(double date)
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
