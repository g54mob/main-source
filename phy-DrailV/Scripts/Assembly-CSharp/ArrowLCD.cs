using UnityEngine;

public class ArrowLCD : MonoBehaviour
{
	public void TurnOff()
	{
		base.gameObject.SetActive(value: false);
	}

	public void TurnOn(bool left)
	{
		base.transform.localEulerAngles = (left ? Vector3.zero : new Vector3(0f, 180f, 0f));
		base.gameObject.SetActive(value: true);
	}
}
