using System;
using System.Collections;
using DV.CabControls;
using UnityEngine;

public class JoystickDriver : MonoBehaviour
{
	public enum Behavior
	{
		Natural = 0,
		Additive = 1,
		Toggling = 2
	}

	public Behavior behavior;

	public float deadZone = 0.1f;

	private ControlImplBase control;

	private float timer;

	private float oldValue;

	private Rigidbody body;

	private bool isInitialized;

	public event Action<float> ValueUpdated;

	private void OnEnable()
	{
		if (!isInitialized)
		{
			StartCoroutine(Initialize());
		}
	}

	private IEnumerator Initialize()
	{
		yield return null;
		yield return null;
		if (isInitialized)
		{
			yield break;
		}
		body = GetComponent<Rigidbody>();
		body.solverIterations = 42;
		control = GetComponent<ControlImplBase>();
		if (behavior != Behavior.Additive)
		{
			control.ValueChanged += delegate(ValueChangedEventArgs e)
			{
				OnValueChanged(Normalize(e.newValue));
			};
		}
		isInitialized = true;
	}

	private void Update()
	{
		if (!control)
		{
			return;
		}
		float? num = Normalize(control.Value);
		if (!num.HasValue || behavior != Behavior.Additive)
		{
			return;
		}
		if (num.Value != 0f)
		{
			if (oldValue == 0f)
			{
				this.ValueUpdated?.Invoke(num.Value);
				timer = 0f;
			}
			else if (timer > 0.425f)
			{
				timer -= 0.125f;
				this.ValueUpdated?.Invoke(num.Value);
			}
		}
		timer += Time.deltaTime;
		oldValue = num.Value;
	}

	private void OnValueChanged(float? value)
	{
		if (value.HasValue)
		{
			switch (behavior)
			{
			case Behavior.Natural:
				this.ValueUpdated?.Invoke(value.Value);
				break;
			case Behavior.Toggling:
				CheckTogglingState(value.Value);
				break;
			}
		}
	}

	private void CheckTogglingState(float newValue)
	{
		float obj = oldValue;
		if (!0f.Equals(obj))
		{
			if (!1f.Equals(obj))
			{
				if ((-1f).Equals(obj) && (double)newValue > -0.5)
				{
					oldValue = 0f;
				}
			}
			else if ((double)newValue < 0.5)
			{
				oldValue = 0f;
			}
		}
		else if ((double)newValue > 0.5)
		{
			oldValue = 1f;
			this.ValueUpdated?.Invoke(1f);
		}
		else if ((double)newValue < -0.5)
		{
			oldValue = -1f;
			this.ValueUpdated?.Invoke(-1f);
		}
	}

	private float? Normalize(float value)
	{
		if ((double)body.velocity.magnitude > 0.5)
		{
			return null;
		}
		float num = (value - 0.5f) * 2f;
		if (Mathf.Abs(num) < deadZone)
		{
			return 0f;
		}
		return num;
	}

	public void ForcePosition(float value)
	{
		if ((bool)control)
		{
			control.SetValue(value);
			if (behavior == Behavior.Natural)
			{
				OnValueChanged(Normalize(value));
			}
		}
	}
}
