using haxe.lang;

namespace play.day.booth
{
	public class CarouselState : Enum
	{
		public static readonly CarouselState NORMAL;

		public static readonly CarouselState STAMPING;

		public static readonly CarouselState INSPECTING;

		public static readonly CarouselState FILING;

		public static readonly CarouselState UNLOCKING;

		public static readonly CarouselState BUSYWITHBORDER_OBSERVATIONONLY;

		protected static readonly string[] __hx_constructs;

		protected CarouselState(int index)
			: base(0)
		{
		}
	}
}
