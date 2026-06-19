using System.Collections.Generic;
using UnityEngine;

public class MagicBeamFX : WeaponFX
{
	private enum State
	{
		Off = 0,
		Starting = 1,
		On = 2,
		Ending = 3
	}

	public MeshRenderer beamBodyRenderer;

	[Header("FX")]
	public List<ParticleSystem> alwaysActiveSystems;

	public List<ParticleSystem> activeWhenConnectedSystems;

	public ParticleSystem emissionByScaleParticleSystem;

	public float continuousEmissionRateByScale = 50f;

	[Header("Settings")]
	public bool updatePosition = true;

	public float strengthIntroFactorAmount;

	[Header("Animation")]
	public float spawnTime;

	public float despawnTime;

	private static readonly int IntroFactorID = Shader.PropertyToID("_IntroFactor");

	private static readonly int TimeOffsetID = Shader.PropertyToID("_TimeOffset");

	private State _currentState;

	private float _animationTime;

	private bool _previousFXOnState;

	private bool _previousOnAndConnectedFXState;

	private float _previousIntroFactor;

	private Material _material;

	private float _strength = 1f;

	protected virtual void Awake()
	{
		_material = Object.Instantiate(beamBodyRenderer.sharedMaterial);
		_material.SetFloat(TimeOffsetID, Random.value * 10f);
		_material.SetFloat(IntroFactorID, 0f);
		beamBodyRenderer.sharedMaterial = _material;
		EnableAlwaysActiveVisuals(enable: false);
		EnableConnectedVisuals(enable: false);
	}

	protected virtual void LateUpdate()
	{
		EvaluateState();
		UpdateAnimationTime();
		bool shouldBeamBeOn = _currentState != State.Off;
		bool shouldShowConnected = isOn && isConnected && _currentState == State.On;
		UpdateFX(shouldBeamBeOn, shouldShowConnected);
		UpdateBeam(shouldBeamBeOn);
	}

	private void EvaluateState()
	{
		switch (_currentState)
		{
		case State.Off:
			if (isOn)
			{
				_currentState = State.Starting;
				_animationTime = 0f;
			}
			break;
		case State.Starting:
			if (_animationTime >= spawnTime)
			{
				_currentState = State.On;
			}
			break;
		case State.On:
			if (!isOn)
			{
				_currentState = State.Ending;
				_animationTime = 0f;
			}
			break;
		case State.Ending:
			if (_animationTime >= despawnTime)
			{
				_currentState = State.Off;
			}
			break;
		}
	}

	private void UpdateFX(bool shouldBeamBeOn, bool shouldShowConnected)
	{
		if (_previousFXOnState != shouldBeamBeOn)
		{
			_previousFXOnState = shouldBeamBeOn;
			EnableAlwaysActiveVisuals(shouldBeamBeOn);
		}
		if (_previousOnAndConnectedFXState != shouldShowConnected)
		{
			_previousOnAndConnectedFXState = shouldShowConnected;
			EnableConnectedVisuals(shouldShowConnected);
		}
	}

	private void EnableAlwaysActiveVisuals(bool enable)
	{
		beamBodyRenderer.enabled = enable;
		foreach (ParticleSystem alwaysActiveSystem in alwaysActiveSystems)
		{
			alwaysActiveSystem.gameObject.SetActive(enable);
		}
	}

	private void EnableConnectedVisuals(bool enable)
	{
		foreach (ParticleSystem activeWhenConnectedSystem in activeWhenConnectedSystems)
		{
			activeWhenConnectedSystem.gameObject.SetActive(enable);
		}
	}

	private void UpdateBeam(bool shouldBeamBeOn)
	{
		if (shouldBeamBeOn)
		{
			if (updatePosition)
			{
				UpdatePosition();
			}
			else
			{
				UpdateBeamScale();
			}
			if (emissionByScaleParticleSystem != null)
			{
				ParticleSystem.EmissionModule emission = emissionByScaleParticleSystem.emission;
				emission.rateOverTime = CalculateDistanceScale() * continuousEmissionRateByScale;
			}
		}
	}

	private void UpdateAnimationTime()
	{
		_animationTime += Time.deltaTime;
		switch (_currentState)
		{
		case State.Off:
			SetIntroFactor(0f);
			break;
		case State.Starting:
			SetIntroFactor(_animationTime / spawnTime);
			break;
		case State.On:
			SetIntroFactor(1f);
			break;
		case State.Ending:
			SetIntroFactor(1f - _animationTime / despawnTime);
			break;
		}
	}

	private void SetIntroFactor(float introAnimFactor)
	{
		float b = 1f - strengthIntroFactorAmount + _strength * strengthIntroFactorAmount;
		float value = Mathf.Lerp(0f, b, introAnimFactor);
		value = Mathf.Clamp01(value);
		if (!Mathf.Approximately(value, _previousIntroFactor))
		{
			_previousIntroFactor = value;
			_material.SetFloat(IntroFactorID, value);
		}
	}

	public override void UpdatePosition()
	{
		Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(originPointWorld);
		Vector3 vector2 = EntityMonoBehaviour.ToRenderFromWorld(endPointWorld);
		base.transform.position = vector;
		base.transform.rotation = Quaternion.LookRotation((vector2 - vector).normalized, Vector3.up);
		UpdateBeamScale();
	}

	private void UpdateBeamScale()
	{
		base.transform.localScale = new Vector3(1f, 1f, CalculateDistanceScale());
	}

	private float CalculateDistanceScale()
	{
		Vector3 b = EntityMonoBehaviour.ToRenderFromWorld(originPointWorld);
		return Vector3.Distance(EntityMonoBehaviour.ToRenderFromWorld(endPointWorld), b);
	}

	public void SetStrengthFactor(float beamStrength)
	{
		_strength = beamStrength;
	}
}
