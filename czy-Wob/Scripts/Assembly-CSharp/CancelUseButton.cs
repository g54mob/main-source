using UnityEngine;

public class CancelUseButton : MonoBehaviour
{
	public void Load(Clickable.ClickCallback newCallback)
	{
		Clickable clickable = base.gameObject.AddComponent<Clickable>();
		clickable.SetClickCallbacks(newCallback);
		clickable.SetClickCallbackTime(Clickable.CallbackTime.CLICK_END);
		SetActive(activeVal: false);
	}

	public void SetActive(bool activeVal)
	{
		GetComponent<Clickable>().enabled = activeVal;
	}
}
