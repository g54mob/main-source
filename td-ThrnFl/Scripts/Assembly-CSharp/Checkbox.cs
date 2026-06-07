using UnityEngine;
using UnityEngine.Events;

public class Checkbox : MonoBehaviour
{
	public UnityEvent onToggle = new UnityEvent();

	public bool state;

	public GameObject checkObj;

	public void SetState(bool active)
	{
		state = active;
		UpdateDisplay();
	}

	public void Toggle()
	{
		state = !state;
		UpdateDisplay();
		onToggle.Invoke();
	}

	private void UpdateDisplay()
	{
		checkObj.SetActive(state);
	}
}
