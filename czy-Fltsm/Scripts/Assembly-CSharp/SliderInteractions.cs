using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.UI;

public class SliderInteractions : MonoBehaviour
{
	private enum State
	{
		Stopped = 0,
		Increase = 1,
		Decrease = 2
	}

	[SerializeField]
	private Slider _slider;

	[SerializeField]
	private int _progressInteractionThreshold = 10;

	[SerializeField]
	private float _regressInterval = 1f;

	[SerializeField]
	private float[] _values = new float[4] { 1f, 10f, 100f, 1000f };

	private State _state;

	private int _valueIndex;

	private int _interactCount;

	private float _stoppedTimestamp;

	private void LateUpdate()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (_state == State.Stopped && 0 < _valueIndex && _regressInterval < realtimeSinceStartup - _stoppedTimestamp)
		{
			_valueIndex--;
			_stoppedTimestamp = realtimeSinceStartup;
		}
	}

	public void Increase()
	{
		SetState(State.Increase);
		AddValue(GetValue());
	}

	public void Decrease()
	{
		SetState(State.Decrease);
		AddValue(0f - GetValue());
	}

	public void Stop()
	{
		SetState(State.Stopped);
		_stoppedTimestamp = Time.realtimeSinceStartup;
	}

	private void SetState(State state)
	{
		if (_state != state)
		{
			_state = state;
			_interactCount = 0;
		}
	}

	private void AddValue(float amount)
	{
		_slider.value = Mathf.Clamp(MathExtensions.AddAndRoundToMultiple(_slider.value, amount), 0f, _slider.maxValue);
		_interactCount++;
		if (_progressInteractionThreshold <= _interactCount && _valueIndex < _values.Length - 1)
		{
			_valueIndex++;
			_interactCount = 0;
		}
	}

	private float GetValue()
	{
		if (_valueIndex < _values.Length)
		{
			return _values[_valueIndex];
		}
		return 0f;
	}
}
