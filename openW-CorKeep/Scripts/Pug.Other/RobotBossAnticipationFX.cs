using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class RobotBossAnticipationFX : PoolableSimple
{
	private enum BossAnticipationState
	{
		None = 0,
		Light = 1,
		BeamsGrow = 2,
		BeamsStay = 3,
		BeamsFade = 4
	}

	public Transform parentTransform;

	public List<Transform> beamsTransforms;

	public List<SpriteRenderer> beamSpriteRenderers;

	[FormerlySerializedAs("lightFlickerEffect")]
	public Light lamp;

	public bool shouldRotate;

	public bool shouldSwirlAttack;

	public float beamSwirlAnticipationTime = 2f;

	public float beamsSwirlSpeed = 45f;

	private BossAnticipationState _state;

	[Space(10f)]
	public float rotationSpeed = 20f;

	public bool play;

	private float _playTime = -1f;

	public float lampFadeDuration = 0.5f;

	public float beamsGrowDuration = 0.5f;

	public float beamsStayDuration = 1f;

	public float beamsStayDurationBuffer = 1f;

	public float beamsFadeDuration = 0.3f;

	public float lampMaxIntensity = 14f;

	public float beamsScaleMultiplier = 3f;

	[Header("Beam Scaling")]
	public AnimationCurve beamScaleX = AnimationCurve.Linear(0f, 0f, 1f, 0.6f);

	public AnimationCurve beamScaleZ = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float3 rangeAttackDirection;

	public Color lasercolor;

	public float laserAlpha = 0.16f;

	public override void OnOccupied()
	{
		base.OnOccupied();
		beamsStayDurationBuffer = beamsStayDuration;
		ResetBeams();
	}

	private void ResetBeams(bool voidColors = false)
	{
		shouldSwirlAttack = false;
		shouldRotate = false;
		parentTransform.rotation = Quaternion.identity;
		beamsStayDuration = beamsStayDurationBuffer;
		for (int i = 0; i < beamsTransforms.Count; i++)
		{
			beamsTransforms[i].gameObject.SetActive(value: true);
			float y = (float)i * 45f;
			beamsTransforms[i].rotation = Quaternion.Euler(0f, y, 0f);
			beamsTransforms[i].gameObject.SetActive(value: false);
		}
	}

	private void OnValidate()
	{
		if (play)
		{
			shouldSwirlAttack = true;
			Play();
			play = false;
		}
	}

	public void Stop()
	{
		ResetBeams();
	}

	public void Play(RobotBossAttackPattern attackType = RobotBossAttackPattern.all, float3 direction = default(float3), bool voidColors = false, bool rotateBeams = false)
	{
		ResetBeams(voidColors);
		switch (attackType)
		{
		case RobotBossAttackPattern.swirlAttack:
			foreach (Transform beamsTransform in beamsTransforms)
			{
				beamsTransform.gameObject.SetActive(value: true);
			}
			shouldSwirlAttack = true;
			rangeAttackDirection = direction;
			beamsStayDuration = beamSwirlAnticipationTime;
			AudioManager.Sfx(SfxTableID.robotBossBigChargeAttackSfx, base.transform.position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 4f, 0f, 1f, 0f, 0.68f);
			break;
		case RobotBossAttackPattern.all:
			foreach (Transform beamsTransform2 in beamsTransforms)
			{
				beamsTransform2.gameObject.SetActive(value: true);
			}
			break;
		case RobotBossAttackPattern.Cardinal:
			beamsTransforms[0].gameObject.SetActive(value: true);
			beamsTransforms[2].gameObject.SetActive(value: true);
			beamsTransforms[4].gameObject.SetActive(value: true);
			beamsTransforms[6].gameObject.SetActive(value: true);
			break;
		case RobotBossAttackPattern.Diagonal:
			beamsTransforms[1].gameObject.SetActive(value: true);
			beamsTransforms[3].gameObject.SetActive(value: true);
			beamsTransforms[5].gameObject.SetActive(value: true);
			beamsTransforms[7].gameObject.SetActive(value: true);
			break;
		case RobotBossAttackPattern.Diagonal30:
			parentTransform.rotation = Quaternion.Euler(0f, 30f, 0f);
			beamsTransforms[0].gameObject.SetActive(value: true);
			beamsTransforms[2].gameObject.SetActive(value: true);
			beamsTransforms[4].gameObject.SetActive(value: true);
			beamsTransforms[6].gameObject.SetActive(value: true);
			break;
		case RobotBossAttackPattern.Diagonal60:
			parentTransform.rotation = Quaternion.Euler(0f, 60f, 0f);
			beamsTransforms[0].gameObject.SetActive(value: true);
			beamsTransforms[2].gameObject.SetActive(value: true);
			beamsTransforms[4].gameObject.SetActive(value: true);
			beamsTransforms[6].gameObject.SetActive(value: true);
			break;
		case RobotBossAttackPattern.Rotate:
			shouldRotate = true;
			foreach (Transform beamsTransform3 in beamsTransforms)
			{
				beamsTransform3.gameObject.SetActive(value: true);
			}
			break;
		}
		_playTime = Time.time;
	}

	public RobotBossAttackPattern GetRandomAttack()
	{
		RobotBossAttackPattern[] array = (RobotBossAttackPattern[])Enum.GetValues(typeof(RobotBossAttackPattern));
		return array[UnityEngine.Random.Range(0, array.Length)];
	}

	private void LateUpdate()
	{
		if (_state == BossAnticipationState.None)
		{
			parentTransform.gameObject.SetActive(value: false);
			lamp.gameObject.SetActive(value: false);
		}
		float num = Time.time - _playTime;
		float num2 = lampFadeDuration + beamsGrowDuration + beamsStayDuration + beamsFadeDuration;
		if (_playTime > 0f && num < num2 + 0.5f)
		{
			parentTransform.gameObject.SetActive(value: true);
			lamp.gameObject.SetActive(value: true);
			if (num < lampFadeDuration)
			{
				_state = BossAnticipationState.Light;
				float t = Mathf.Clamp01(num / lampFadeDuration);
				lamp.intensity = Mathf.Lerp(0f, lampMaxIntensity - 2f, t);
			}
			else if (num < lampFadeDuration + beamsGrowDuration)
			{
				_state = BossAnticipationState.BeamsGrow;
				float time = Mathf.Clamp01((num - lampFadeDuration) / beamsGrowDuration);
				foreach (Transform beamsTransform in beamsTransforms)
				{
					float x = beamScaleX.Evaluate(time);
					float z = beamScaleZ.Evaluate(time) * beamsScaleMultiplier;
					beamsTransform.localScale = new Vector3(x, 1f, z);
				}
			}
			else if (num < lampFadeDuration + beamsGrowDuration + beamsStayDuration)
			{
				_state = BossAnticipationState.BeamsStay;
				lamp.intensity = lampMaxIntensity * 1.2f;
				if (shouldSwirlAttack)
				{
					float time2 = Mathf.Clamp01((num - lampFadeDuration) / (beamsGrowDuration + beamsStayDuration));
					_ = 1f / (float)beamsTransforms.Count;
					_ = Time.time;
					for (int i = 0; i < beamsTransforms.Count; i++)
					{
						Transform transform = beamsTransforms[i];
						Quaternion to = Quaternion.LookRotation(rangeAttackDirection);
						transform.rotation = Quaternion.RotateTowards(transform.rotation, to, beamsSwirlSpeed * Time.deltaTime);
						float x2 = beamScaleX.Evaluate(time2) * 2f;
						transform.localScale = new Vector3(x2, 1f, transform.localScale.z);
					}
				}
			}
			else if (num < lampFadeDuration + beamsGrowDuration + beamsStayDuration + beamsFadeDuration)
			{
				_state = BossAnticipationState.BeamsFade;
				float t2 = Mathf.Clamp01((num - (lampFadeDuration + beamsGrowDuration + beamsStayDuration)) / beamsFadeDuration);
				lamp.intensity = Mathf.Lerp(beamScaleX.Evaluate(1f) * lampMaxIntensity, 0f, t2);
				foreach (Transform beamsTransform2 in beamsTransforms)
				{
					float x3 = Mathf.Lerp(beamScaleX.Evaluate(1f), 0f, t2);
					float z2 = Mathf.Lerp(beamScaleZ.Evaluate(1f) * beamsScaleMultiplier, 0f, t2);
					beamsTransform2.localScale = new Vector3(x3, 1f, z2);
				}
				lamp.intensity = Mathf.Lerp(lampMaxIntensity, 0f, t2);
			}
			else
			{
				_state = BossAnticipationState.None;
			}
		}
		if (shouldRotate)
		{
			parentTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
		}
	}
}
