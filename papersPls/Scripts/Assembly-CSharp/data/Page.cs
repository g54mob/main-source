using app;
using haxe.lang;

namespace data
{
	public class Page : HxObject
	{
		public string id;

		public Array marks;

		public string defaultInnerImageName;

		public string portraitWideInnerImageName;

		public string portraitThinInnerImageName;

		public Page(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Page(Xml pageNode, Mark defaults)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Page(Page __hx_this, Xml pageNode, Mark defaults)
		{
		}

		public virtual ImageAndMarkPositions getInnerImageAndMarkPositions(Res res, Shape layoutShape, Rand rand)
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
