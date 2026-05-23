using app;
using haxe.lang;

namespace data
{
	public class Speech : HxObject
	{
		public string text;

		public string factPath;

		public bool fromInspector;

		public bool pauseAfter;

		public Speech(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Speech(Rand rand, string text_, string factPath_, object fromInspector_, object male)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Speech(Speech __hx_this, Rand rand, string text_, string factPath_, object fromInspector_, object male)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
