using System.Collections.Generic;
using Data.Variables;
using Logic.Factory;
using NaughtyAttributes;
using UnityEngine;

public class CallFakeAnimOnMaterial : MonoBehaviour
{
	private static readonly int OutAnimationTime = Shader.PropertyToID("_outAnimationTime");

	private static readonly int InAnimationTime = Shader.PropertyToID("_inAnimationTime");

	private static readonly int StartTime = Shader.PropertyToID("_startTime");

	[SerializeField]
	private Material _material;

	[SerializeField]
	private List<MeshRenderer> _affectedRenderers = new List<MeshRenderer>();

	[Header("Scaling")]
	[SerializeField]
	private IntVariableSO _variableUpdateFrequency;

	protected Material _instancedMat;

	protected bool _initialized;

	private void Start()
	{
		Init();
		if (_variableUpdateFrequency != null)
		{
			_variableUpdateFrequency.ValueChanged += SetOutAnimationTime;
			SetOutAnimationTime(_variableUpdateFrequency.Value);
		}
	}

	private void OnDestroy()
	{
		if (_variableUpdateFrequency != null)
		{
			_variableUpdateFrequency.ValueChanged -= SetOutAnimationTime;
		}
		_initialized = false;
	}

	protected void Init()
	{
		if (_initialized)
		{
			return;
		}
		_instancedMat = new Material(_material);
		foreach (MeshRenderer affectedRenderer in _affectedRenderers)
		{
			affectedRenderer.sharedMaterial = _instancedMat;
		}
		_initialized = true;
	}

	private void SetOutAnimationTime(int updateFrequency)
	{
		float num = (float)updateFrequency / Mathf.Max(FactoryUpdater.Instance.GetStepsPerSecond(), Mathf.Epsilon);
		num -= _material.GetFloat(InAnimationTime);
		if (_material.GetFloat(OutAnimationTime) > num)
		{
			_instancedMat.SetFloat(OutAnimationTime, num);
		}
	}

	[Button("Play Animation", EButtonEnableMode.Always)]
	public void PlayAnimation(float delay = 0f)
	{
		if (!_initialized)
		{
			Init();
		}
		_instancedMat.SetFloat(StartTime, Time.time + delay);
	}

	public void SetCustomAttribute(float customFloat, int propertyID)
	{
		if (!_initialized)
		{
			Init();
		}
		_instancedMat.SetFloat(propertyID, customFloat);
	}
}
