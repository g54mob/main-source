using haxe.lang;

namespace data.loc
{
	public class XmlExtractor : HxObject
	{
		public string filename;

		public string contextPrefix;

		public string rootPath;

		public string attrPath;

		public Function filterFunc;

		public Function displayFunc;

		public string curSection;

		public Display display;

		public bool haveStartedSplitSection;

		public XmlExtractor(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public XmlExtractor(string filename_, string contextPrefix_, string rootPath_, string attrPath_, Function filterFunc_, Display display_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_loc_XmlExtractor(XmlExtractor __hx_this, string filename_, string contextPrefix_, string rootPath_, string attrPath_, Function filterFunc_, Display display_)
		{
		}

		public static XmlExtractor make(string filename_, string contextPrefix_, string rootPath_, string attrPath_, Function filterFunc_, Display display_)
		{
			return null;
		}

		public static Array select(Xml xml, string path)
		{
			return null;
		}

		public virtual void run(Xml xml, Function extractedFunc)
		{
		}

		public virtual void runChildren(Xml xml, string path, string context, Function extractedFunc)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
