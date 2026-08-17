using Assets.Scripts.Utility;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
	public float disableDelay = 1.5f;

	private float disableAtTime;

	private void OnEnable()
	{
		float num = MyTime.time + disableDelay;
		disableAtTime = num;
	}

	private void Update()
	{
		if (MyTime.time > disableAtTime)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}
}
