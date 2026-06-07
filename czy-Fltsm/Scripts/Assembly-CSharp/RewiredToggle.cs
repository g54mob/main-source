using UnityEngine;
using UnityEngine.UI;

public class RewiredToggle : RewiredComponent
{
	[SerializeField]
	private Toggle _toggle;

	protected override void OnButtonDown()
	{
		_toggle.isOn = !_toggle.isOn;
	}
}
