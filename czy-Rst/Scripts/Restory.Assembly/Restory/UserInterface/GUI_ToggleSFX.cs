using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public class GUI_ToggleSFX : GUI_SfxEventHandler
	{
		[SerializeField]
		private Toggle toggle;

		private void OnEnable()
		{
			toggle.onValueChanged.AddListener(ResolveToggleValueChanged);
		}

		private void OnDisable()
		{
			if (toggle.MonoShellExists())
			{
				toggle.onValueChanged.RemoveListener(ResolveToggleValueChanged);
			}
		}

		private void ResolveToggleValueChanged(bool newValue)
		{
			TryToPlaySound(soundBank.OnToggleSwitchedSound);
		}
	}
}
