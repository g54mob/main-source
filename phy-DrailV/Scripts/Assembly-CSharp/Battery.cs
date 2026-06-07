using System;
using System.Collections;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Battery : MonoBehaviour
{
	public const string BATTERY_POWER_SAVE_KEY = "Battery_power";

	public const string BATTERY_DEPLETED_SAVE_KEY = "Battery_depleted";

	public const float MAX_POWER = 100f;

	public const float NOMINAL_POWER_THRESHOLD = 5f;

	private const float CHARGE_CHECK_INTERVAL = 0.1f;

	public LedBarDriverBase ledBarDriver;

	private bool ledPowerIndication = true;

	private float currentPower = 100f;

	private Coroutine displayUpdateCoro;

	private bool initialized;

	public float CurrentPower => currentPower;

	public bool Depleted { get; private set; }

	public bool ProvidesNominalPower { get; private set; }

	public event Action PowerDepleted;

	public event Action PowerRestored;

	public event Action LowPower;

	public event Action NominalPower;

	public void Initialize(float power = 100f, bool depleted = false)
	{
		ledBarDriver.Initialize();
		currentPower = power;
		Depleted = depleted;
		ProvidesNominalPower = !Depleted && currentPower >= 5f;
		UpdateVisuals();
		if (base.gameObject.activeInHierarchy)
		{
			if (displayUpdateCoro != null)
			{
				StopCoroutine(displayUpdateCoro);
			}
			displayUpdateCoro = StartCoroutine(LedDisplayUpdateLoop());
		}
		initialized = true;
	}

	private void OnEnable()
	{
		if (initialized)
		{
			displayUpdateCoro = StartCoroutine(LedDisplayUpdateLoop());
		}
	}

	private void OnDisable()
	{
		if (displayUpdateCoro != null)
		{
			StopCoroutine(displayUpdateCoro);
		}
		displayUpdateCoro = null;
	}

	private IEnumerator LedDisplayUpdateLoop()
	{
		while (true)
		{
			float previousPower = currentPower;
			yield return WaitFor.Seconds(0.1f);
			float num = currentPower - previousPower;
			LedBarDriverBase.DisplayMode mode = (ledPowerIndication ? ((!(num > 0f)) ? ((!(currentPower >= 5f)) ? LedBarDriverBase.DisplayMode.BLINKING : LedBarDriverBase.DisplayMode.NORMAL) : LedBarDriverBase.DisplayMode.FILLING) : LedBarDriverBase.DisplayMode.OFF);
			UpdateDisplay(mode);
		}
	}

	private void UpdateDisplay(LedBarDriverBase.DisplayMode mode)
	{
		ledBarDriver.UpdateDisplayMode(mode);
	}

	private void UpdateVisuals()
	{
		ledBarDriver.UpdateValue(currentPower / 100f);
	}

	private void UpdatePower(float powerDelta)
	{
		if (!initialized)
		{
			return;
		}
		currentPower = Mathf.Clamp(currentPower + powerDelta, 0f, 100f);
		if (!(currentPower > float.Epsilon))
		{
			if (!Depleted)
			{
				Depleted = true;
				ProvidesNominalPower = false;
				this.PowerDepleted?.Invoke();
			}
		}
		else if (Depleted)
		{
			if (currentPower >= 5f)
			{
				Depleted = false;
				ProvidesNominalPower = true;
				this.PowerRestored?.Invoke();
				this.NominalPower?.Invoke();
			}
		}
		else if (currentPower < 5f && ProvidesNominalPower)
		{
			ProvidesNominalPower = false;
			this.LowPower?.Invoke();
		}
		else if (currentPower >= 5f && !ProvidesNominalPower)
		{
			ProvidesNominalPower = true;
			this.NominalPower?.Invoke();
		}
		UpdateVisuals();
	}

	public void Drain(float percentToDrain)
	{
		if (!Depleted)
		{
			UpdatePower(0f - percentToDrain);
		}
	}

	public void Charge(float percentToCharge)
	{
		UpdatePower(percentToCharge);
	}

	public void TogglePowerDisplay(bool on)
	{
		if (on != ledPowerIndication)
		{
			ledPowerIndication = on;
			UpdateDisplay((!on) ? LedBarDriverBase.DisplayMode.OFF : LedBarDriverBase.DisplayMode.NORMAL);
		}
	}

	public void LoadSavedState(JObject saveData)
	{
		float power = 100f;
		bool depleted = false;
		if (saveData != null)
		{
			float? num = saveData.GetFloat("Battery_power");
			float valueOrDefault = num.GetValueOrDefault();
			if (num.HasValue)
			{
				power = valueOrDefault;
			}
			bool? flag = saveData.GetBool("Battery_depleted");
			bool valueOrDefault2 = flag == true;
			if (flag.HasValue)
			{
				depleted = valueOrDefault2;
			}
			Initialize(power, depleted);
		}
	}

	public void SaveState(JObject data)
	{
		if (currentPower >= 99.9f)
		{
			data.Remove("Battery_power");
		}
		else
		{
			data.SetFloat("Battery_power", currentPower);
		}
		if (Depleted)
		{
			data.SetBool("Battery_depleted", Depleted);
		}
		else
		{
			data.Remove("Battery_depleted");
		}
	}

	private void SetToEmpty()
	{
		UpdatePower(0f - CurrentPower);
	}

	private void SetToLowPower()
	{
		UpdatePower(5f - CurrentPower);
	}

	private void SetToFullPower()
	{
		UpdatePower(100f - CurrentPower);
	}
}
