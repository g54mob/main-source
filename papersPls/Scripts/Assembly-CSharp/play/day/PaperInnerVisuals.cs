using app.vis;
using data;
using haxe.lang;

namespace play.day
{
	public class PaperInnerVisuals : HxObject
	{
		public static Array kMarkNames;

		public static Rect _compareProximityRA;

		public static Rect _compareProximityRB;

		public static PointData _compareProximityCA;

		public static PointData _compareProximityCB;

		public static int kSmallFieldWidth;

		public Image backgroundImage;

		public bool oddShape;

		public Array visuals;

		static PaperInnerVisuals()
		{
		}

		public PaperInnerVisuals(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PaperInnerVisuals(BoothEnv boothEnv, PaperDef def, int multiPaperIndex, int pageIndex, int touchTargetExpand)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_PaperInnerVisuals(PaperInnerVisuals __hx_this, BoothEnv boothEnv, PaperDef def, int multiPaperIndex, int pageIndex, int touchTargetExpand)
		{
		}

		public static Mark getMarkFromName(PaperDef paperDef, int pageIndex, string markName)
		{
			return null;
		}

		public static int autoGetPageIndexForFactId(BoothEnv boothEnv, PaperDef def, int multiPaperIndex, string factId)
		{
			return 0;
		}

		public static int autoGetPageIndexWithLink(BoothEnv boothEnv, PaperDef def, int multiPaperIndex, string link)
		{
			return 0;
		}

		public static int compareProximity(PointData p, Rect ra, Rect rb)
		{
			return 0;
		}

		public virtual Image toImage()
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
