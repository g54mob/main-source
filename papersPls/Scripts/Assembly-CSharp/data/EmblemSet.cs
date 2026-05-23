using app.vis;
using haxe.lang;

namespace data
{
	public class EmblemSet : HxObject
	{
		public string id;

		public string nation;

		public Image gridImage;

		public Image translucentGridImage;

		public PointData cellSize;

		public int count;

		public int validCount;

		public EmblemSet(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EmblemSet()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_EmblemSet(EmblemSet __hx_this)
		{
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
