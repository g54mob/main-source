using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BossLarva : EntityMonoBehaviour
{
	public List<GameObject> segmentObjects;

	public List<SpriteRenderer> larvaPartSRs;

	public List<SpriteRenderer> shadows;

	public List<Animator> segmentAnimators;

	public List<ParticleSystem> DeathParticleSystems;

	private TimerSimple directionAnimationUpdateTimer = new TimerSimple(0.5f);

	private TimerSimple timerBeforeAnimationUpdateCooldownStarts = new TimerSimple(0.1f);

	private TimerSimple shakeTimer = new TimerSimple(0.15f);

	private TimerSimple debrisAudioTimer = new TimerSimple(1.5f);

	private List<float> angles;

	private PoolableAudioSource earthquakeAudioLoop;

	private PoolableAudioSource growlAudioLoop;

	private bool pingpong;

	public Color enragedColor;

	private Vector3 prevPosition;

	protected override bool hideDirectlyOnDeath => false;

	public override Vector3 center => base.transform.position + Vector3.up * 3f;

	protected override void Awake()
	{
		base.Awake();
		angles = new List<float>();
		for (int i = 0; i < 12; i++)
		{
			int num = i * 30 % 360;
			angles.Add(num);
		}
		angles.Add(360f);
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		directionAnimationUpdateTimer.Start();
		timerBeforeAnimationUpdateCooldownStarts.Start();
		shakeTimer.Start();
		debrisAudioTimer.Start();
		for (int i = 1; i < segmentAnimators.Count - 1; i++)
		{
			segmentAnimators[i].SetInteger("currentSegment", i);
		}
		earthquakeAudioLoop = AudioManager.SfxFollowTransform(SfxID.EarthquakeLoop, base.transform, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 40f);
		growlAudioLoop = AudioManager.SfxFollowTransform(SfxID.larvaBossGrowl, base.transform, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 50f);
		prevPosition = base.transform.position;
	}

	public override void OnFree()
	{
		base.OnFree();
		StopAudioLoopsAndTimers();
	}

	private void StopAudioLoopsAndTimers()
	{
		shakeTimer.Stop();
		debrisAudioTimer.Stop();
		if (earthquakeAudioLoop != null)
		{
			earthquakeAudioLoop.FadeOutAndStop();
			earthquakeAudioLoop = null;
		}
		if (growlAudioLoop != null)
		{
			growlAudioLoop.FadeOutAndStop();
			growlAudioLoop = null;
		}
	}

	private void UpdateShake()
	{
		if (shakeTimer.isRunning && shakeTimer.isTimerElapsed)
		{
			float num = 35f;
			float num2 = Mathf.Clamp((Manager.main.player.transform.position - base.transform.position).magnitude, 0f, num);
			float num3 = 2.5f * (1f - num2 / num);
			Manager.camera.ShakeCameraNow(0.2f, num3, num3, null, null, 0, 0.8f);
			shakeTimer.Start();
		}
	}

	private void UpdateDebris()
	{
		if (debrisAudioTimer.isRunning && debrisAudioTimer.isTimerElapsed)
		{
			pingpong = !pingpong;
			if (pingpong)
			{
				AudioManager.SfxFollowTransform(SfxID.rockDebris1, base.transform, 1f, 0.8f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f);
			}
			else
			{
				AudioManager.SfxFollowTransform(SfxID.rockDebris2, base.transform, 1f, 0.8f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f);
			}
			debrisAudioTimer.Start();
		}
	}

	private void UpdateEnrage()
	{
		if (EntityUtility.GetComponentData<EnrageStateCD>(base.entity, base.world).isEnraged)
		{
			foreach (SpriteRenderer larvaPartSR in larvaPartSRs)
			{
				larvaPartSR.color = enragedColor;
			}
			return;
		}
		foreach (SpriteRenderer larvaPartSR2 in larvaPartSRs)
		{
			larvaPartSR2.color = Color.white;
		}
	}

	private void UpdateTransforms()
	{
		SnakeMovementStateCD componentData = EntityUtility.GetComponentData<SnakeMovementStateCD>(base.entity, base.world);
		DynamicBuffer<SnakeSegmentsBuffer> buffer = EntityUtility.GetBuffer<SnakeSegmentsBuffer>(base.entity, base.world);
		NativeArray<float3> nativeArray = new NativeArray<float3>(buffer.Length, Allocator.Temp);
		NativeList<float> busyZValues = new NativeList<float>(Allocator.Temp);
		int i;
		for (i = 1; i < buffer.Length && EntityUtility.EntityExists(buffer[i].segment, base.world) && EntityUtility.HasComponentData<LocalTransform>(buffer[i].segment, base.world); i++)
		{
			int index = i - 1;
			if (!segmentObjects[index].activeSelf)
			{
				segmentObjects[index].SetActive(value: true);
			}
			nativeArray[i] = EntityUtility.GetComponentData<LocalTransform>(buffer[i].segment, base.world).Position;
		}
		for (; i < buffer.Length; i++)
		{
			int index2 = i - 1;
			if (segmentObjects[index2].activeSelf)
			{
				segmentObjects[index2].SetActive(value: false);
			}
		}
		bool flag = directionAnimationUpdateTimer.isTimerElapsed || !timerBeforeAnimationUpdateCooldownStarts.isTimerElapsed;
		if (!directionAnimationUpdateTimer.isRunning || directionAnimationUpdateTimer.isTimerElapsed)
		{
			directionAnimationUpdateTimer.Start();
		}
		if (flag)
		{
			float3 currentDirection = componentData.currentDirection;
			float angleFromDirection = GetAngleFromDirection(currentDirection);
			int rotationStateFromAngle = GetRotationStateFromAngle(angleFromDirection);
			if (rotationStateFromAngle != -1)
			{
				animator.SetInteger(1985954694, rotationStateFromAngle);
			}
		}
		float3 float5 = base.WorldPosition;
		busyZValues.Add(in float5.z);
		float z = float5.z;
		for (int j = 1; j < buffer.Length; j++)
		{
			int index3 = j - 1;
			if (!segmentObjects[index3].activeInHierarchy)
			{
				continue;
			}
			float3 float6 = nativeArray[j];
			float num = math.sign(float6.z - z) * 0.001f;
			if (num == 0f)
			{
				num = 0.001f;
			}
			while (ListContainsSimilarValue(float6.z, in busyZValues))
			{
				float6 = new float3(float6.x, float6.y, float6.z + num);
			}
			busyZValues.Add(in float6.z);
			z = float6.z;
			if (flag)
			{
				float3 float7 = math.normalizesafe(((j == 1) ? float5 : nativeArray[j - 1]) - float6);
				float angleFromDirection2 = GetAngleFromDirection(float7);
				int rotationStateFromAngle2 = GetRotationStateFromAngle(angleFromDirection2);
				if (rotationStateFromAngle2 != -1)
				{
					segmentAnimators[index3].SetInteger(1985954694, rotationStateFromAngle2);
				}
			}
		}
		for (int k = 1; k < buffer.Length; k++)
		{
			int index4 = k - 1;
			if (segmentObjects[index4].activeInHierarchy)
			{
				nativeArray[k] += 2f * math.back();
				segmentObjects[index4].transform.position = (Vector3)math.round(nativeArray[k] * 16f) / 16f - Manager.camera.RenderOrigo;
			}
		}
		nativeArray.Dispose();
		busyZValues.Dispose();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!(Manager.main.player == null))
		{
			UpdateShake();
			UpdateDebris();
			UpdateTransforms();
			UpdateEnrage();
		}
	}

	private float GetAngleFromDirection(Vector3 direction)
	{
		float num = Vector3.SignedAngle(new Vector3(0f, 0f, -1f), direction, new Vector3(0f, 1f, 0f)) % 360f;
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	private int GetRotationStateFromAngle(float angle)
	{
		for (int i = 0; i < angles.Count; i++)
		{
			if (Mathf.Abs(angle - angles[i]) <= 14.5f)
			{
				if (i == 12)
				{
					return 0;
				}
				return i;
			}
		}
		return -1;
	}

	private bool ListContainsSimilarValue(float value, in NativeList<float> busyZValues)
	{
		foreach (float busyZValue in busyZValues)
		{
			if (math.abs(busyZValue - value) < 0.001f)
			{
				return true;
			}
		}
		return false;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			StopAudioLoopsAndTimers();
		}
	}

	public void AE_StartDeathExplosion()
	{
		for (int i = 0; i < segmentObjects.Count; i++)
		{
			Vector3 position = segmentObjects[i].transform.position + Vector3.up * 2.5f;
			if (DeathParticleSystems[i] != null)
			{
				DeathParticleSystems[i].transform.position = position;
				DeathParticleSystems[i].Play(withChildren: true);
			}
			AudioManager.Sfx(SfxTableID.bossDeathAnticipation, position);
		}
	}

	public void AE_DeathBurst()
	{
		Manager.camera.ShakeCameraNow(0.5f, 3f, 3f);
		for (int i = 0; i < segmentObjects.Count; i++)
		{
			Vector3 position = segmentObjects[i].transform.position + Vector3.up * 2f;
			Manager.effects.PlayPuff(PuffID.GhormDeathCarapace, position);
			Manager.effects.PlayPuff(PuffID.GhormDeathFlesh, position);
			AudioManager.Sfx(SfxTableID.slimeBigSplat, position);
		}
	}

	protected override void OnTakeDamage()
	{
		AudioManager.SfxFollowTransform(soundOptions.takeDamageSfx.value, base.transform);
	}

	protected override void OnDeath()
	{
		StopAudioLoopsAndTimers();
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}

	private void AE_EnrageSound()
	{
		AudioManager.Sfx(SfxID.slimeBossEnrage, base.transform.position, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
	}

	protected override void DeathEffect()
	{
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}

	protected override void UpdateHealEffect(int currentHealth)
	{
	}
}
