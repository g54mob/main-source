using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public static class GamepadExecuteEvents
	{
		public static ExecuteEvents.EventFunction<IConfirmHandler> ConfirmHandler { get; }

		public static ExecuteEvents.EventFunction<IBackHandler> BackHandler { get; }

		public static ExecuteEvents.EventFunction<IMenuHandler> MenuHandler { get; }

		public static ExecuteEvents.EventFunction<IOptionHandler> OptionHandler { get; }

		public static ExecuteEvents.EventFunction<ITriggerHandler> TriggerLeftHandler { get; }

		public static ExecuteEvents.EventFunction<ITriggerHandler> TriggerRightHandler { get; }

		public static ExecuteEvents.EventFunction<IBumperHandler> BumperLeftHandler { get; }

		public static ExecuteEvents.EventFunction<IBumperHandler> BumperRightHandler { get; }

		public static ExecuteEvents.EventFunction<IWestButtonHandler> WestButtonHandler { get; }

		public static ExecuteEvents.EventFunction<INorthButtonHandler> NorthButtonHandler { get; }

		public static ExecuteEvents.EventFunction<IDpadHandler> DPadHandler { get; }

		public static ExecuteEvents.EventFunction<IRightStickHandler> RightStickHandler { get; }

		public static ExecuteEvents.EventFunction<ILeftStickHandler> LeftStickHandler { get; }

		public static ExecuteEvents.EventFunction<IRightStickButtonHandler> RightStickButtonHandler { get; }

		public static ExecuteEvents.EventFunction<ILeftStickButtonHandler> LeftStickButtonHandler { get; }

		private static void Execute(IConfirmHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(IBackHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(IMenuHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(IOptionHandler handler, BaseEventData eventData)
		{
		}

		private static void ExecuteLeft(ITriggerHandler handler, BaseEventData eventData)
		{
		}

		private static void ExecuteRight(ITriggerHandler handler, BaseEventData eventData)
		{
		}

		private static void ExecuteLeft(IBumperHandler handler, BaseEventData eventData)
		{
		}

		private static void ExecuteRight(IBumperHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(IWestButtonHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(INorthButtonHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(IDpadHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(IRightStickHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(ILeftStickHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(IRightStickButtonHandler handler, BaseEventData eventData)
		{
		}

		private static void Execute(ILeftStickButtonHandler handler, BaseEventData eventData)
		{
		}
	}
}
