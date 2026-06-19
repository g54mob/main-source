using Michsky.DreamOS;
using UnityEngine;

namespace Player.TutorialHelpers
{
	public class ComputerChatAppOpenTutorialHelper : BaseTutorialHelper
	{
		[SerializeField]
		private WindowManager _window;

		private void OnEnable()
		{
			_window.onOpen.AddListener(TutorialAppOpened);
		}

		private void TutorialAppOpened()
		{
			EmitStep("checkMessages");
		}
	}
}
