using UnityEngine;

public class LaserButton : LevelButtonBase
{
	[SerializeField]
	private float stateChangeDelay = 0.1f;

	[SerializeField]
	private bool shouldStartOn = true;

	private GameObject ledLightObject;

	private Material material;

	private bool internalFlag;

	private float timeCounter;

	protected override void Awake()
	{
		base.Awake();
		ledLightObject = base.transform.Find("LedLight").gameObject;
		material = GetComponent<Renderer>().material;
		internalFlag = false;
		base.IsOn = shouldStartOn;
		SetLedOnOff(shouldStartOn);
		timeCounter = stateChangeDelay + 1f;
	}

	protected override void AddReplayComponents()
	{
		base.AddReplayComponents();
		base.gameObject.AddComponent<LaserButtonReplay>();
	}

	public void SetOn()
	{
		if (!base.IsOn)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter >= stateChangeDelay)
			{
				base.IsOn = true;
				InvokeOnChangedState(isOn: true);
				SetLedOnOff(isOn: true);
				timeCounter = 0f;
			}
		}
		internalFlag = true;
	}

	private void LateUpdate()
	{
		if (base.IsOn && !internalFlag)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter >= stateChangeDelay)
			{
				base.IsOn = false;
				InvokeOnChangedState(isOn: false);
				SetLedOnOff(isOn: false);
				timeCounter = 0f;
			}
		}
		internalFlag = false;
	}

	public void SetLedOnOff(bool isOn)
	{
		material.SetColor("_EmissionColor", isOn ? Color.HSVToRGB(0f, 0f, 5f) : Color.HSVToRGB(0f, 0f, 1f));
		ledLightObject.SetActive(isOn);
	}
}
