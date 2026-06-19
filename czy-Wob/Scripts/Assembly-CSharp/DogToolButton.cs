using UnityEngine;
using UnityEngine.UI;

public class DogToolButton : PlayToolButton
{
	public GameObject dogNumTextRef;

	public GameObject dogBackingRef;

	protected override void InternalUpdate()
	{
		base.InternalUpdate();
		int remainingAllowedDogs = homeRef.GetRemainingAllowedDogs();
		if (remainingAllowedDogs <= 0)
		{
			dogNumTextRef.SetActive(value: false);
			dogBackingRef.SetActive(value: false);
		}
		else
		{
			dogNumTextRef.SetActive(value: true);
			dogBackingRef.SetActive(value: true);
			dogNumTextRef.GetComponent<Text>().text = remainingAllowedDogs.ToString();
		}
	}
}
