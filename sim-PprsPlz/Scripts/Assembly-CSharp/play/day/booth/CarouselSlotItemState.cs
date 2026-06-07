using haxe.lang;

namespace play.day.booth
{
	public class CarouselSlotItemState : Enum
	{
		public static readonly CarouselSlotItemState APPEARING_FROMSLOT;

		public static readonly CarouselSlotItemState APPEARING_FROMINNER;

		public static readonly CarouselSlotItemState IDLING;

		public static readonly CarouselSlotItemState GIVING;

		public static readonly CarouselSlotItemState DESKITEMGONE;

		public static readonly CarouselSlotItemState GRABBED;

		public static readonly CarouselSlotItemState UNGRABBING;

		public static readonly CarouselSlotItemState RISINGFORHANG;

		public static readonly CarouselSlotItemState FALLINGTOWALL;

		public static readonly CarouselSlotItemState CONFISCATING;

		public static readonly CarouselSlotItemState CONFISCATING_QUICK;

		public static readonly CarouselSlotItemState EMPTY;

		protected static readonly string[] __hx_constructs;

		protected CarouselSlotItemState(int index)
			: base(0)
		{
		}
	}
}
