using System.Collections;
using System.Collections.Generic;
using Pug.Sprite;
using Unity.Transforms;
using UnityEngine;

public class CoreBossOrb : EntityMonoBehaviour
{
	[Header("Components:")]
	public MeshRenderer orb;

	public MeshRenderer spinner;

	public MeshRenderer eye;

	[Header("Spinning animation:")]
	private Animator _animator;

	private static readonly int FeignDeathLoop = Animator.StringToHash("feignDeathLoop");

	private readonly float _spinAcceleration = 1f;

	private readonly float _spinDrag = 4f;

	private float _spinVelocity;

	private float _spinAngle;

	[Header("Materials:")]
	public SpriteObject indirectLight;

	[ColorUsage(false, true)]
	public Color emissiveColor = Color.white;

	[ColorUsage(false, true)]
	public Color indirectColor = Color.white;

	public bool animatedGlow = true;

	private List<Material> _materials;

	private float _glowAlpha;

	private static readonly int EmissiveColor = Shader.PropertyToID("_EmissiveColor");

	public ParticleSystem downZap;

	public float downZapStartPaddingDistanceFraction;

	public float downZapEndPaddingDistanceFraction;

	public ParticleSystem vulnerableParticles;

	public float timeUntilHideOnDeath;

	protected override void Awake()
	{
		base.Awake();
		_animator = GetComponent<Animator>();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		XScaler.gameObject.SetActive(value: true);
		shadow.SetActive(value: true);
	}

	private void InstantiateMaterialForRenderer(MeshRenderer meshRenderer)
	{
		Material item = (meshRenderer.sharedMaterial = Object.Instantiate(meshRenderer.sharedMaterial));
		_materials.Add(item);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!base.entityExist)
		{
			return;
		}
		if (EntityUtility.TryGetComponentData<HealthCD>(base.entity, base.world, out var value) && value.health > 0)
		{
			_spinVelocity -= _spinVelocity * Mathf.Clamp01(Time.deltaTime * _spinDrag);
			_spinVelocity += Time.deltaTime * _spinAcceleration;
			if (_spinVelocity * 360f > 20f)
			{
				_spinAngle += _spinVelocity * 360f * Time.deltaTime;
			}
			spinner.transform.localEulerAngles = Vector3.right * Mathf.Round(_spinAngle % 360f / 5f) * 5f;
			Vector3 localPosition = orb.transform.localPosition;
			localPosition.x = Mathf.Round(localPosition.x * 16f) / 16f;
			localPosition.y = Mathf.Round(localPosition.y * 16f) / 16f;
			localPosition.z = Mathf.Round(localPosition.z * 16f) / 16f;
			orb.transform.localPosition = localPosition;
		}
		if (_materials == null)
		{
			_materials = new List<Material>();
			InstantiateMaterialForRenderer(spinner);
			InstantiateMaterialForRenderer(eye);
		}
		_glowAlpha = Mathf.Lerp(_glowAlpha, animatedGlow ? 1 : 0, 4f * Time.deltaTime);
		Color value2 = emissiveColor;
		value2.a *= _glowAlpha;
		for (int i = 0; i < _materials.Count; i++)
		{
			_materials[i].SetColor(EmissiveColor, value2);
		}
		indirectLight.emissiveColor = indirectColor * _glowAlpha;
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		Vector3 position = particleOptions.particleSpawnLocations[1].position;
		Manager.effects.PlayPuff(PuffID.CoreOrbHitDebris, position, 5);
	}

	protected override void HandleInitialAnimationTrigger(int animID)
	{
		base.HandleInitialAnimationTrigger(animID);
		HandleAnimationTrigger(animID);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		bool flag = false;
		if (base.entityExist && EntityUtility.TryGetComponentData<HealthCD>(base.entity, base.world, out var value))
		{
			flag = value.health > 0;
		}
		if (animID == -601574123 && lastAnim != 2053665356 && lastAnim != -350899940)
		{
			if (flag)
			{
				_animator.SetTrigger(animID);
			}
			else
			{
				_animator.SetTrigger(FeignDeathLoop);
			}
			return;
		}
		if (lastAnim != 2053665356 && animID == -1014102059)
		{
			_animator.SetTrigger(FeignDeathLoop);
			return;
		}
		if (lastAnim != 2053665356 && animID == 2053665356)
		{
			_animator.SetTrigger(animID);
			return;
		}
		switch (animID)
		{
		case -350899940:
			_animator.SetTrigger(animID);
			break;
		case -414722770:
			StartCoroutine(Death_Coroutine());
			break;
		case -1878077465:
			_animator.SetTrigger(-601574123);
			AudioManager.Sfx(SfxTableID.spawnCreature, base.transform.position);
			Manager.effects.PlayPuff(PuffID.CoreOrbSpawn, base.transform.position, 1);
			break;
		}
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (base.ShouldPlayAnimTrigger(animID))
		{
			return animID != -601574123;
		}
		return false;
	}

	public IEnumerator Death_Coroutine()
	{
		Vector3 position = particleOptions.particleSpawnLocations[1].position;
		Manager.effects.PlayPuff(PuffID.EnergyExplosion, position, 1);
		Manager.effects.PlayPuff(PuffID.CoreBossArmorChunk, position, 80);
		Manager.effects.PlayPuff(PuffID.CrystalDebris, position, 1);
		yield return new WaitForSeconds(timeUntilHideOnDeath);
		vulnerableParticles.Stop();
		XScaler.gameObject.SetActive(value: false);
		shadow.SetActive(value: false);
	}

	public void AE_PowerDown()
	{
		if (EntityUtility.TryGetComponentData<CoreBossOrbCD>(base.entity, base.world, out var value) && EntityUtility.TryGetComponentData<LocalTransform>(value.boss, base.world, out var value2))
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(value2.Position);
			float num = Vector3.Distance(base.RenderPosition, vector) / 2f;
			bool num2 = downZapStartPaddingDistanceFraction + downZapEndPaddingDistanceFraction > 1f;
			if (num2)
			{
				Debug.LogWarning("Fractions are too large. Start and end distance fractions added together should not be greater than 1.0. Defaulting to 0.5 for both fractions.");
			}
			float num3 = (num2 ? 0.5f : downZapStartPaddingDistanceFraction);
			float num4 = (num2 ? 0.5f : downZapEndPaddingDistanceFraction);
			float num5 = num * num3;
			float num6 = num * num4;
			float num7 = num - num5 - num6;
			ParticleSystem.ShapeModule shape = downZap.shape;
			Vector3 scale = shape.scale;
			scale.x = num7;
			shape.scale = scale;
			Vector3 position = shape.position;
			position.z = num7 + num5 * 0.5f - num6 * 0.5f;
			shape.position = position;
			downZap.transform.LookAt(vector);
		}
		downZap.gameObject.SetActive(value: true);
		if (flashable != null)
		{
			flashable.FlashLinearNoCurve(Color.red);
		}
		AudioManager.SfxFollowTransform(SfxTableID.coreBossOrbPowerDown, base.transform);
	}

	public void AE_PowerUp()
	{
		downZap.gameObject.SetActive(value: false);
		AudioManager.SfxFollowTransform(SfxTableID.coreBossOrbPowerUp, base.transform);
	}

	protected override void OnHide()
	{
		downZap.gameObject.SetActive(value: false);
	}

	public void PlayVulnerableParticles()
	{
		vulnerableParticles.Play();
		AudioManager.Sfx(SfxTableID.coreBossGroundCrashArmsThud, base.transform.position);
	}

	public void StopVulnerableParticles()
	{
		vulnerableParticles.Stop();
	}
}
