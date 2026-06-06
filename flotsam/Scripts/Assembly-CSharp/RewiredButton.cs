using UnityEngine;
using UnityEngine.UI;

public class RewiredButton : RewiredComponent
{
	[SerializeField]
	private Button _button;

	protected override void OnButtonDown()
	{
		if (_button.IsActive() && _button.IsInteractable())
		{
			_button.onClick.Invoke();
		}
	}
}
