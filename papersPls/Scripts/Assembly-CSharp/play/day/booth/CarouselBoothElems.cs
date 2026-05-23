using haxe.lang;

namespace play.day.booth
{
	public class CarouselBoothElems : HxObject
	{
		public StampDesk stampDesk;

		public InspectUi inspectUi;

		public DropRemote dropRemote;

		public Filer filer;

		public KeyDesk keyDesk;

		public Function checkHaveStampedSomething;

		public Function checkHaveFloatingDeskItem;

		public Function checkWillEnableActionButtonSoon;

		public Function checkCurtainIsClosed;

		public CarouselBoothElems(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CarouselBoothElems(StampDesk stampDesk, InspectUi inspectUi, DropRemote dropRemote, Filer filer, KeyDesk keyDesk, Function checkHaveStampedSomething, Function checkHaveFloatingDeskItem, Function checkWillEnableActionButtonSoon, Function checkCurtainIsClosed)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_CarouselBoothElems(CarouselBoothElems __hx_this, StampDesk stampDesk, InspectUi inspectUi, DropRemote dropRemote, Filer filer, KeyDesk keyDesk, Function checkHaveStampedSomething, Function checkHaveFloatingDeskItem, Function checkWillEnableActionButtonSoon, Function checkCurtainIsClosed)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
