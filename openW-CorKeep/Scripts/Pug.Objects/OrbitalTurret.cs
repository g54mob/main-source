using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class OrbitalTurret : EntityMonoBehaviour
{
	public EnergyShield energyShield;

	public Transform muzzleReference;

	public GameObject laser;

	private int m_prevShotsDone;

	private float m_showLaserTime;

	private bool m_laserAudioBeenPlayed;

	private readonly List<AudioManager.RunningSfxReference> m_gunAudio = new List<AudioManager.RunningSfxReference>();

	private bool m_gunAudioActive;

	public Flashable m_flashable;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateGraphicsFromObjectInfo(base.objectInfo);
		m_laserAudioBeenPlayed = false;
		AudioManager.SfxFollowTransform(SfxTableID.laserGunLoop, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: false, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, m_gunAudio);
		if (m_gunAudio.Count != 3)
		{
			Debug.LogWarning("Failed to acquire gun sound or number of AudioSources mismatch!");
		}
		else
		{
			foreach (AudioManager.RunningSfxReference item in m_gunAudio)
			{
				item.Stop();
			}
			m_gunAudio[0].SetLoop(value: false);
			m_gunAudio[1].SetLoop(value: true);
			m_gunAudio[2].SetLoop(value: false);
		}
		m_gunAudioActive = false;
		laser.SetActive(value: false);
	}

	public override void OnFree()
	{
		base.OnFree();
		SetGunSoundPlaying(state: false);
		foreach (AudioManager.RunningSfxReference item in m_gunAudio)
		{
			item.FadeOutAndStop(0f);
		}
		m_gunAudio.Clear();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		ShieldCD componentData = EntityUtility.GetComponentData<ShieldCD>(base.entity, base.world);
		RangeAttackStateCD componentData2 = EntityUtility.GetComponentData<RangeAttackStateCD>(base.entity, base.world);
		if (componentData.active)
		{
			energyShield.facingDirection = componentData2.aimDirection.ToFloat2();
			energyShield.arc = (float)componentData.shieldWidthDegrees / 2f;
			energyShield.deployed = true;
		}
		else
		{
			energyShield.deployed = false;
		}
		bool flag = currentHealth > 0;
		bool gunSoundPlaying = componentData2.shotsDone > 0 && flag;
		SetGunSoundPlaying(gunSoundPlaying);
		if (m_prevShotsDone != componentData2.shotsDone && componentData2.shotsDone > 0)
		{
			energyShield.Pulse();
			Manager.effects.PlayPuff(PuffID.yellowSphereFlash, muzzleReference.position);
		}
		if (componentData2.shotsDone == 0 && m_prevShotsDone != 0)
		{
			m_showLaserTime = Time.time + energyShield.deployDuration * 2f;
		}
		if (componentData2.shotsDone == 0 && Time.time > m_showLaserTime && flag && !base.world.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.simulationDisabled)
		{
			laser.transform.rotation = Quaternion.LookRotation(componentData2.aimDirection, Vector3.up);
			float num = 20f;
			if (Manager.multiMap.RaycastWalls(laser.transform.position.ToWorld().XZ(), componentData2.aimDirection.XZ(), num, out var hitInfo))
			{
				num = hitInfo.distance;
			}
			laser.transform.localScale = new Vector3(1f, 1f, num);
			float num2 = Time.time * 8f;
			float num3 = num2 - Mathf.Floor(num2);
			laser.SetActive(num3 > 0.5f);
			if (!m_laserAudioBeenPlayed)
			{
				AudioManager.Sfx(SfxTableID.orbitalTurretLaserBeep, base.RenderPosition);
				m_laserAudioBeenPlayed = true;
			}
			if (num3 > 0.65f && !m_flashable.isRunning)
			{
				m_flashable.Flash(m_flashable.curve, Color.white, 0.33f);
			}
		}
		else
		{
			laser.SetActive(value: false);
			m_laserAudioBeenPlayed = false;
		}
		m_prevShotsDone = componentData2.shotsDone;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
	}

	private void SetGunSoundPlaying(bool state)
	{
		if (m_gunAudio.Count != 3)
		{
			return;
		}
		if (state && !m_gunAudioActive)
		{
			m_gunAudio[0].Play();
			m_gunAudio[1].PlayScheduled(AudioSettings.dspTime + (double)m_gunAudio[0].ClipLength);
			m_gunAudioActive = true;
		}
		if (!state)
		{
			m_gunAudio[0].Stop();
			m_gunAudio[1].Stop();
			if (m_gunAudioActive)
			{
				m_gunAudio[2].Play();
				m_gunAudioActive = false;
			}
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770 && hasShadow)
		{
			shadow.SetActive(value: false);
		}
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
		int num = 1;
		if (Random.value < 0.5f)
		{
			num = -1;
		}
		Manager.effects.PlayTempSprite(SpriteTempEffectID.HitEffect, center + new Vector3(0f, 2f, -2f) + offset, (float)num * 0.8f);
	}

	protected override void DeathEffect()
	{
		Manager.effects.ExploDisc(center, 0.25f);
	}
}
