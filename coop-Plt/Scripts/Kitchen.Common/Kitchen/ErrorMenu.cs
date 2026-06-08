using Kitchen.Modules;
using UnityEngine;
using WebSocketSharp;

namespace Kitchen
{
	public class ErrorMenu<MenuAction> : Menu<MenuAction>
	{
		public string MessageToDisplay;

		public ErrorMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			if (MessageToDisplay.IsNullOrEmpty())
			{
				RequestMainMenu();
				return;
			}
			ModuleList.Clear();
			AddInfo(MessageToDisplay);
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestMainMenu();
			});
		}

		public void SetError(string message)
		{
			MessageToDisplay = message;
		}
	}
}
