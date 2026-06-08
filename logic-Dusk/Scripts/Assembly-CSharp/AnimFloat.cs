using System;
using System.Reflection;
using UnityEngine;

[Serializable]
public class AnimFloat : MonoBehaviour
{
	public AnimationCurve animation = new AnimationCurve();

	public float animationTime = 1f;

	public float minValue;

	public float maxValue = 1f;

	public string varName;

	private string _varName;

	public MonoBehaviour obj;

	private MonoBehaviour _obj;

	private float time;

	private FieldInfo field;

	public bool isPlaying { get; private set; }

	private void OnDestroy()
	{
		obj = null;
		_obj = null;
	}

	private void OnEnable()
	{
		time = animationTime;
		SetField();
	}

	private void SetField()
	{
		if (_varName != varName || _obj != obj)
		{
			_varName = varName;
			_obj = obj;
			field = _obj.GetType().GetField(_varName);
		}
	}

	private void Update()
	{
		if (isPlaying)
		{
			if (field == null)
			{
				SetField();
			}
			if (field != null)
			{
				field.SetValue(_obj, Value());
			}
		}
	}

	public void Play()
	{
		isPlaying = true;
		SetField();
		time = Time.time;
	}

	public void Stop()
	{
		isPlaying = false;
	}

	public float Value()
	{
		float num = (Time.time - time) / animationTime;
		if (num > 1f)
		{
			num = 1f;
			isPlaying = false;
		}
		return Mathf.Lerp(minValue, maxValue, animation.Evaluate(num));
	}
}
