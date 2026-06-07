using UnityEngine;

namespace Assets.Nimbatus.GUI.Story
{
	public class IntroNextButton : MonoBehaviour
	{
		public UIButton Button;

		private IntroUiManager _manager;

		private bool _isEnabled;

		public void Awake()
		{
			DisableButton();
		}

		public void Init(IntroUiManager manager)
		{
			_manager = manager;
		}

		public void OnClick()
		{
			if (_manager != null && _isEnabled)
			{
				_manager.NextText();
			}
		}

		public void DisableButton()
		{
			Button.isEnabled = false;
			Button.UpdateColor(true);
			_isEnabled = false;
		}

		public void EnableButton()
		{
			Button.isEnabled = true;
			_isEnabled = true;
		}
	}
}
