using UnityEngine;
using UnityEngine.UI;

public class ToggleToggler : MonoBehaviour
{
	public Toggle T;

	public void Toggle()
	{
		T.isOn = !T.isOn;
	}
}
