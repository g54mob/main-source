using app;
using app.vis;
using haxe.lang;

namespace play.day
{
	public class DayNewsImage : HxObject
	{
		public static int kArticleX;

		public static int kArticleY;

		public static int kColWidth;

		public static int kColPaddingX;

		public static int kLineHeight;

		public static int kLinePaddingY;

		public static int kArticlePaddingX;

		public static int kTimeTextBaselineY;

		public static int kTextDrop;

		public static int kPaperColor;

		public static int kImageColor;

		public static int kWordBreakColor;

		public static int kTextColor;

		public static int kTimeTextColor;

		static DayNewsImage()
		{
		}

		public DayNewsImage(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DayNewsImage()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_DayNewsImage(DayNewsImage __hx_this)
		{
		}

		public static Image make(Db db, Rand rand, DayNews dayNews)
		{
			return null;
		}

		public static int roundToNearestLine(double heightInPixels)
		{
			return 0;
		}
	}
}
