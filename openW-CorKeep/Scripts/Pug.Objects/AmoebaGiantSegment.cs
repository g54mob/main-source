using System.Collections;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class AmoebaGiantSegment : WormSegment
{
	public GameObject animationBone;

	public GameObject animationBoneFront;

	public Transform head;

	public AmoebaGiantSegmentTail body;

	public AmoebaGiantSegmentTail tail;

	public AnimationCurve animPos = AnimationCurve.Linear(0f, 0f, 1f, 0f);

	public AnimationCurve animBonePos = AnimationCurve.Linear(0f, 0f, 1f, 0f);

	public AnimationCurve animBoneScale = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	public Vector3 animTimeOffsets = new Vector3(-0.1f, -0.2f, -0.3f);

	public Vector4 animWeights = Vector4.one;

	public float animSpeed = 1f;

	public float aimPosOffset;

	public float aimBonePosOffset;

	public float aimBoneScaleOffset;

	private Vector3[] m_originalPositions = new Vector3[3];

	[Min(0f)]
	public int animationFPS = 12;

	private int m_animationFrame;

	private int m_prevAnimationFrame;

	private TimerSimple debrisAudioTimer = new TimerSimple(1.5f);

	private PoolableAudioSource earthquakeAudioLoop;

	protected override void Awake()
	{
		base.Awake();
		m_originalPositions[0] = head.transform.localPosition;
		m_originalPositions[1] = body.transform.localPosition;
		m_originalPositions[2] = tail.transform.localPosition;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		debrisAudioTimer.Start();
		earthquakeAudioLoop = AudioManager.SfxFollowTransform(SfxID.EarthquakeLoop, base.transform, 0.6f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 40f);
	}

	public override void OnFree()
	{
		base.OnFree();
		StopAudioLoopsAndTimers();
	}

	public override void UpdateRotation(NativeArray<SnakeSegmentsBuffer> segments, int segmentIndex, float3 segmentDirection, SnakeBossSegmentSpriteController segmentController, Transform segmentTransform)
	{
		if (m_animationFrame != m_prevAnimationFrame)
		{
			float y = 90f - Mathf.Atan2(segmentDirection.z, segmentDirection.x) * 57.29578f;
			segmentTransform.localEulerAngles = new Vector3(0f, y, 0f);
		}
	}

	private void AnimateSegments()
	{
		head.transform.localPosition = m_originalPositions[0];
		AnimateSegment(null, Vector3.zero, animationBoneFront.transform, 0f, Vector3.right, animWeights.x);
		AnimateSegment(head, m_originalPositions[0], animationBone.transform, animTimeOffsets.x, Vector3.right, animWeights.y, animateMeshPosition: true);
		AnimateSegment(body.transform, m_originalPositions[1], body.animationBone.transform, animTimeOffsets.y, Vector3.right, animWeights.z);
		AnimateSegment(tail.transform, m_originalPositions[2], tail.animationBone.transform, animTimeOffsets.z, -Vector3.forward, animWeights.w);
	}

	private void AnimateSegment(Transform meshTransform, Vector3 originalPos, Transform animationBone, float timeOffset, Vector3 forwardVector, float weight, bool animateMeshPosition = false)
	{
		float num = Time.time * animSpeed + timeOffset;
		if (meshTransform != null && animateMeshPosition)
		{
			meshTransform.position += meshTransform.forward * (animPos.Evaluate(math.clamp(math.frac(num + aimPosOffset), 0f, 1f)) * weight);
		}
		animationBone.localPosition = forwardVector * animBonePos.Evaluate(math.frac(num + aimBonePosOffset)) * weight;
		animationBone.localScale = Vector3.one * Mathf.LerpUnclamped(1f, animBoneScale.Evaluate(math.frac(num + aimBoneScaleOffset)), weight);
	}

	private void StopAudioLoopsAndTimers()
	{
		debrisAudioTimer.Stop();
		if (earthquakeAudioLoop != null)
		{
			earthquakeAudioLoop.FadeOutAndStop();
			earthquakeAudioLoop = null;
		}
	}

	public override void ManagedLateUpdate()
	{
		if (animationFPS > 0)
		{
			m_animationFrame = Mathf.FloorToInt(Time.time * (float)animationFPS);
		}
		else
		{
			m_animationFrame = m_prevAnimationFrame + 1;
		}
		base.ManagedLateUpdate();
		if (!(Manager.main.player == null) && !base.isHidden)
		{
			if (m_animationFrame != m_prevAnimationFrame)
			{
				AnimateSegments();
			}
			m_prevAnimationFrame = m_animationFrame;
		}
	}

	protected override void OnDeath()
	{
		StopAudioLoopsAndTimers();
		StartCoroutine(OnDeathCoroutine());
	}

	private IEnumerator OnDeathCoroutine()
	{
		int i = wormSegmentTails.Count - 1;
		while (i >= 0)
		{
			if (wormSegmentTails[i].gameObject.activeInHierarchy)
			{
				AudioManager.Sfx(SfxTableID.AmoebaTakeDamage, base.transform.position);
				SpawnDeathParticles(wormSegmentTails[i].gameObject);
				wormSegmentTails[i].gameObject.SetActive(value: false);
				wormSegmentTails[i].gameObject.transform.localPosition = Vector3.zero;
				yield return new WaitForSeconds(0.01f);
			}
			int num = i - 1;
			i = num;
		}
		AudioManager.Sfx(soundOptions.deathSfx.value, base.transform.position);
		SpawnDeathParticles(headSegmentTransform.gameObject);
		XScaler.gameObject.SetActive(value: false);
		OnHide();
	}

	protected override void SpawnDeathParticles(GameObject segment)
	{
		Vector3 position = segment.transform.position + Vector3.up * 0.25f;
		Manager.effects.PlayPuff(PuffID.Cytoplasm, position, 8);
		Manager.effects.PlayPuff(PuffID.AmoebaEruptBrain, position, 8);
	}
}
