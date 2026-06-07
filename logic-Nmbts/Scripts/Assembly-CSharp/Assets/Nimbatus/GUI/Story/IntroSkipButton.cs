using UnityEngine;

namespace Assets.Nimbatus.GUI.Story
{
	public class IntroSkipButton : MonoBehaviour
	{
		private IntroUiManager _manager;

		public void Init(IntroUiManager manager)
		{
			_manager = manager;
		}

		public void OnClick()
		{
			if (_manager != null)
			{
				_manager.Skip();
			}
		}
	}
}
