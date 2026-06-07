using System;
using System.Collections;
using DV;
using DV.Utils;
using UnityEngine;

public abstract class Indicator : MonoBehaviour
{
	[SerializeField]
	protected float value;

	public float minValue;

	public float maxValue = 1f;

	public bool absoluteNormalizedValue;

	protected bool assumeIsPaused;

	private Coroutine UnpauseCoro;

	public float Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
			if (!assumeIsPaused)
			{
				OnValueSet();
			}
			FireValueChanged();
		}
	}

	public float NormalizedValue
	{
		get
		{
			if (!absoluteNormalizedValue)
			{
				return Mathf.InverseLerp(minValue, maxValue, value);
			}
			return Mathf.InverseLerp(0f, maxValue, Mathf.Abs(value));
		}
	}

	public event Action<float> ValueChanged;

	public event Action<float> NormalizedValueChanged;

	protected abstract void OnValueSet();

	protected virtual void Start()
	{
		SetupListeners(on: true);
	}

	protected virtual void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused += OnGamePaused;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnGameUnPaused;
		}
		else
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnGamePaused;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnGameUnPaused;
		}
	}

	private void OnGamePaused()
	{
		assumeIsPaused = true;
		if (UnpauseCoro != null)
		{
			StopCoroutine(UnpauseCoro);
			UnpauseCoro = null;
		}
	}

	private void OnGameUnPaused()
	{
		if (base.gameObject.activeInHierarchy)
		{
			if (UnpauseCoro != null)
			{
				StopCoroutine(UnpauseCoro);
			}
			UnpauseCoro = StartCoroutine(DelayedUnpause());
		}
		else
		{
			assumeIsPaused = false;
		}
	}

	private IEnumerator DelayedUnpause()
	{
		yield return null;
		assumeIsPaused = false;
		UnpauseCoro = null;
	}

	public float GetNormalizedValue(bool clamped = true)
	{
		return NormalizeValue(value, clamped);
	}

	public float NormalizeValue(float value, bool clamped = true)
	{
		return InverseLerp(minValue, maxValue, value, clamped);
	}

	private static float InverseLerp(float a, float b, float value, bool clamp)
	{
		if (a != b)
		{
			if (clamp)
			{
				return Mathf.Clamp01((value - a) / (b - a));
			}
			return (value - a) / (b - a);
		}
		return 0f;
	}

	protected void FireValueChanged()
	{
		this.ValueChanged?.Invoke(value);
		this.NormalizedValueChanged?.Invoke(NormalizedValue);
	}
}
