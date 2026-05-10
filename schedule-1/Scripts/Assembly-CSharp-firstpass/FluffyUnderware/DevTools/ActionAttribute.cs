using System.Reflection;

namespace FluffyUnderware.DevTools
{
	public class ActionAttribute : DTAttribute
	{
		public enum ActionEnum
		{
			Show = 0,
			Hide = 1,
			Enable = 2,
			Disable = 3,
			ShowInfo = 4,
			ShowWarning = 5,
			ShowError = 6,
			Callback = 7
		}

		public enum ActionPositionEnum
		{
			Above = 0,
			Below = 1
		}

		public ActionEnum Action;

		public ActionPositionEnum Position;

		public object ActionData;

		private MethodInfo mCallback;

		protected ActionAttribute(string actionData, ActionEnum action = ActionEnum.Callback)
			: base(0)
		{
		}

		public void Callback(object classInstance)
		{
		}
	}
}
