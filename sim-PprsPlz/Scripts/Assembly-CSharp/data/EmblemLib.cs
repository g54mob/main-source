using app;
using app.vis;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class EmblemLib : HxObject
	{
		public Array emblemSets;

		public Res res;

		public StringMap emblemFastNodes;

		public EmblemLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EmblemLib(Res res_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_EmblemLib(EmblemLib __hx_this, Res res_)
		{
		}

		public virtual Image getEmblemImage(Rand rand, string id, string nation, EmblemIndex emblemIndex)
		{
			return null;
		}

		public virtual Image getValidImage(string id, int backColor)
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
