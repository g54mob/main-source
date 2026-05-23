using app.vis;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class PaperDef : HxObject
	{
		public static double kOuterImageScale;

		public static double kOuterImageRotationDegreesMax;

		public Array pages;

		public string id;

		public string nation;

		public bool hasDockPoint;

		public string tradeForPaperId;

		public bool fromTraveler;

		public Reveal reveal;

		public bool stampable;

		public Stay stay;

		public bool inspectable;

		public FilerType filerType;

		public bool rotateOuter;

		public SoundsDef sounds;

		public bool oddShape;

		public PointData visaCenter;

		public bool canPinch;

		public string outerImageName;

		public string mountImageName;

		static PaperDef()
		{
		}

		public PaperDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PaperDef(FactLib factLib, Xml paperNode, StringMap soundsDefs)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_PaperDef(PaperDef __hx_this, FactLib factLib, Xml paperNode, StringMap soundsDefs)
		{
		}

		public static Reveal getReveal(string str)
		{
			return null;
		}

		public static string makeIdWithIndex(string paperId, int index)
		{
			return null;
		}

		public static object getIdAndIndex(string idWithIndex)
		{
			return null;
		}

		public virtual bool get_isMountable()
		{
			return false;
		}

		public virtual Image getOuterImage(Res res)
		{
			return null;
		}

		public virtual Image getMountImage(Res res)
		{
			return null;
		}

		public virtual int findPageIndex(string pageId)
		{
			return 0;
		}

		public virtual Mark findMarkWithText(string text)
		{
			return null;
		}

		public virtual Image generateRotatedOuterImage(Res res, double angle)
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
