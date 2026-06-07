using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class AutoOffToggle : MonoBehaviour
{
	[SerializeField]
	private Toggle _toggle;

	private void OnValidate()
	{
		Awake();
	}

	private void Awake()
	{
		if (_toggle == null)
		{
			_toggle = GetComponent<Toggle>();
		}
	}

	private void OnDisable()
	{
		if (_toggle.isOn)
		{
			_toggle.isOn = false;
		}
	}
}
