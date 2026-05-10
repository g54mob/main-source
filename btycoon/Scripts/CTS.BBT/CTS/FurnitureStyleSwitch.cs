using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class FurnitureStyleSwitch : CTSBehaviour
	{
		private enum EChangeType
		{
			Previous = 0,
			Next = 1
		}

		[SerializeField]
		[Inject(false)]
		private Button _button;

		[SerializeField]
		private EChangeType _changeType;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_button.onClick.AddListener(OnButtonClick);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			if (_changeType == EChangeType.Next)
			{
				MonoSingleton<ThemeManager>.Instance.SetNextTheme();
			}
			else
			{
				MonoSingleton<ThemeManager>.Instance.SetPreviousTheme();
			}
		}
	}
}
