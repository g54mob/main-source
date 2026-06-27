using Rewired;

namespace Restory.Gameplay.PlayerInput
{
	public static class ControllerHelperEx
	{
		public static bool GetAnyButton(this Player.ControllerHelper controllerHelper)
		{
			foreach (Controller controller in controllerHelper.Controllers)
			{
				if (controller.GetAnyButton())
				{
					return true;
				}
			}
			return false;
		}

		public static bool GetAnyButtonDown(this Player.ControllerHelper controllerHelper)
		{
			foreach (Controller controller in controllerHelper.Controllers)
			{
				if (controller.GetAnyButtonDown())
				{
					return true;
				}
			}
			return false;
		}
	}
}
