using System;

namespace NSMedieval.UI
{
	public class CustomButtonAction
	{
		public Action Action;

		public bool ClosePrompt;

		public CustomButtonAction()
		{
			Action = null;
			ClosePrompt = true;
		}

		public CustomButtonAction(Action action, bool closePrompt = true)
		{
			Action = action;
			ClosePrompt = closePrompt;
		}
	}
}
