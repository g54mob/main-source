using haxe.lang;

namespace data
{
	public class NewsArticle : HxObject
	{
		public string title;

		public string sub;

		public string image;

		public string stamp;

		public string factId;

		public int sortScore;

		public NewsArticle(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NewsArticle(Node tab)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_NewsArticle(NewsArticle __hx_this, Node tab)
		{
		}

		public static int compare(NewsArticle a, NewsArticle b)
		{
			return 0;
		}

		public virtual string get_textForBulletin()
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
