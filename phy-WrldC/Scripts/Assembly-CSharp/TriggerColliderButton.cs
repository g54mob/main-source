using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderButton : LevelButtonBase
{
	[SerializeField]
	private float delayedOnStateSeconds;

	private bool isRealTimeOn;

	private float timerCounter;

	private List<GameObject> blocksInsideTriggerZone;

	private new void Awake()
	{
		blocksInsideTriggerZone = new List<GameObject>();
		timerCounter = 0f;
	}

	private void Update()
	{
		if (delayedOnStateSeconds > 0f)
		{
			if (base.IsOn)
			{
				timerCounter += Time.deltaTime;
				if (timerCounter > delayedOnStateSeconds && !isRealTimeOn)
				{
					base.IsOn = false;
					InvokeOnChangedState(isOn: false);
				}
			}
		}
		else if (!isRealTimeOn && base.IsOn)
		{
			base.IsOn = false;
			InvokeOnChangedState(isOn: false);
		}
	}

	public override void SetupToAction()
	{
		base.SetupToAction();
		blocksInsideTriggerZone.Clear();
		timerCounter = 0f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Block"))
		{
			if (blocksInsideTriggerZone.Count == 0 && !base.IsOn)
			{
				base.IsOn = true;
				InvokeOnChangedState(isOn: true);
				isRealTimeOn = true;
				timerCounter = 0f;
			}
			if (!blocksInsideTriggerZone.Contains(other.gameObject))
			{
				blocksInsideTriggerZone.Add(other.gameObject);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Block"))
		{
			if (blocksInsideTriggerZone.Contains(other.gameObject))
			{
				blocksInsideTriggerZone.Remove(other.gameObject);
			}
			if (blocksInsideTriggerZone.Count == 0)
			{
				isRealTimeOn = false;
			}
		}
	}
}
