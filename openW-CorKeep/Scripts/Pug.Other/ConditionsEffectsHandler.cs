using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class ConditionsEffectsHandler : PoolableSimple
{
	private struct LightSource
	{
		public Color color;

		public float range;

		public LightSource(Color color, float range)
		{
			this.color = color;
			this.range = range;
		}
	}

	[Serializable]
	public struct AffixEffect
	{
		public AffixID affixID;

		[ParticleEffectIDDropdown]
		public int activateParticleEffect;

		public ParticleEffectSpawner effectSpawner;
	}

	public GameObject container;

	public bool updateEveryFrame;

	public ManagedLight glowLight;

	public GameObject snareEffect;

	public Animator snareAnimator;

	public ParticleEffectSpawner healEffect;

	public ParticleEffectSpawner poisonEffect;

	public ParticleEffectSpawner slimeEffect;

	public ParticleEffectSpawner slipperyEffect;

	public ParticleEffectSpawner loveEffect;

	public ParticleEffectSpawner burnEffect;

	public ParticleEffectSpawner snowEffect;

	public ParticleEffectSpawner radiationEffect;

	public ParticleEffectSpawner voidBreachEffect;

	public ParticleEffectSpawner oilEffect;

	public ParticleEffectSpawner amassEffect;

	public List<AffixEffect> affixSpawners;

	public Transform affixRotatorTransform;

	public float affixRotatorSpeedAngle;

	public GameObject stunEffect;

	public Animator stunAnimator;

	private Vector3 defaultStunEffectPosition;

	private float timeUntilUpdate;

	private const float snareDestroyTimer = 0.4f;

	private float snareDestroyCurrentTime;

	public const float regenerateTimer = 1f;

	public float regenerateCurrentTime;

	private bool isSnareBeingDestroyed;

	private bool m_hadLight;

	private bool m_wasHoldingLightSource;

	private List<LightSource> m_lightSources = new List<LightSource>();

	private PoolableAudioSource _voidLoop;

	private Dictionary<AffixID, int> _affixDictionaryCached = new Dictionary<AffixID, int>();

	private static Array _affixIDArray = Enum.GetValues(typeof(AffixID));

	private Color blueGlowColor => Manager.effects.GetGlowColor(ConditionID.BlueGlow);

	private Color orangeGlowColor => Manager.effects.GetGlowColor(ConditionID.OrangeGlow);

	private Color pinkGlowColor => Manager.effects.GetGlowColor(ConditionID.PinkGlow);

	private Color greenGlowColor => Manager.effects.GetGlowColor(ConditionID.GreenGlow);

	private Color voidGlowColor => Manager.effects.GetGlowColor(ConditionID.VoidGlow);

	public override void OnOccupied()
	{
		container.SetActive(value: false);
		timeUntilUpdate = 0f;
		m_hadLight = false;
		glowLight.gameObject.SetActive(value: false);
		affixRotatorTransform.localEulerAngles += new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f);
		base.OnOccupied();
	}

	private void Awake()
	{
		foreach (AffixID item in _affixIDArray)
		{
			_affixDictionaryCached[item] = 0;
		}
		DisableEffects();
	}

	private void OnDisable()
	{
		DisableEffects();
	}

	private void DisableEffects()
	{
		defaultStunEffectPosition = stunEffect.transform.localPosition;
		EnableEffect(healEffect, value: false);
		EnableEffect(poisonEffect, value: false);
		EnableEffect(slimeEffect, value: false);
		EnableEffect(slipperyEffect, value: false);
		EnableEffect(loveEffect, value: false);
		EnableEffect(burnEffect, value: false);
		EnableEffect(snowEffect, value: false);
		EnableEffect(voidBreachEffect, value: false);
		EnableEffect(oilEffect, value: false);
		EnableEffect(amassEffect, value: false);
		for (int i = 0; i < affixSpawners.Count; i++)
		{
			EnableEffect(affixSpawners[i].effectSpawner, value: false);
		}
	}

	public void UpdateConditionsVisuals(EntityMonoBehaviour entityMono, bool hasEntityPart, in EntityPartCD entityPartCD, DynamicBuffer<SummarizedConditionsBuffer> conditions, DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffects, DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixesBuffer)
	{
		snareDestroyCurrentTime -= Time.deltaTime;
		regenerateCurrentTime -= Time.deltaTime;
		UpdateAffixRotator(activeAffixesBuffer);
		if (!updateEveryFrame)
		{
			timeUntilUpdate -= Time.deltaTime;
			if (timeUntilUpdate > 0f)
			{
				return;
			}
			timeUntilUpdate = UnityEngine.Random.Range(0.33f, 0.66f);
		}
		Entity entity = (hasEntityPart ? entityPartCD.mainEntity : entityMono.entity);
		if (!(entity == Entity.Null))
		{
			UpdateCombinedLight(entityMono, conditionEffects);
			UpdateSnareEffect(conditions);
			UpdateHealEffect(entity, entityMono, conditions);
			UpdateStunEffect(entityMono, conditions);
			UpdateVoidBreachEffect(entityMono, conditions);
			bool value = conditions[47].value > 0 || conditions[215].value != 0;
			EnableEffect(loveEffect, value);
			bool value2 = conditions[208].value > 0;
			EnableEffect(snowEffect, value2);
			bool value3 = conditions[14].value > 0;
			EnableEffect(poisonEffect, value3);
			bool flag = conditions[336].value > 0;
			bool value4 = conditions[2].value < 0 || (conditions[302].value < 0 && !flag) || (!(entityMono is PlayerController) && (conditions[39].value < 0 || conditionEffects[2].value < 0));
			bool value5 = conditions[339].value > 0;
			EnableEffect(slimeEffect, value4);
			bool value6 = conditionEffects[48].value > 0;
			EnableEffect(slipperyEffect, value6);
			bool value7 = conditions[29].value != 0 || conditions[164].value != 0;
			EnableEffect(burnEffect, value7);
			bool value8 = conditions[207].value != 0;
			EnableEffect(radiationEffect, value8);
			EnableAffixEffects(activeAffixesBuffer);
			EnableEffect(oilEffect, flag);
			EnableEffect(amassEffect, value5);
		}
	}

	private void EnableAffixEffects(DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixesBuffer)
	{
		if (activeAffixesBuffer.IsCreated)
		{
			foreach (AffixID item in _affixIDArray)
			{
				_affixDictionaryCached[item] = 0;
			}
			for (int i = 0; i < activeAffixesBuffer.Length; i++)
			{
				ActiveAffixConditionsBuffer activeAffixConditionsBuffer = activeAffixesBuffer[i];
				_affixDictionaryCached[(AffixID)activeAffixConditionsBuffer.conditionData.conditionID] += activeAffixConditionsBuffer.conditionData.value;
			}
			int num = 0;
			foreach (KeyValuePair<AffixID, int> item2 in _affixDictionaryCached)
			{
				num += ((item2.Value > 0) ? 1 : 0);
			}
			int num2 = 0;
			for (int j = 0; j < affixSpawners.Count; j++)
			{
				_affixDictionaryCached.TryGetValue(affixSpawners[j].affixID, out var value);
				bool flag = value != 0;
				EnableEffect(affixSpawners[j].effectSpawner, flag);
				if (flag)
				{
					affixSpawners[j].effectSpawner.transform.localEulerAngles = new Vector3(0f, (float)(360 * num2) / (float)num, 0f);
					num2++;
				}
			}
		}
		else
		{
			for (int k = 0; k < affixSpawners.Count; k++)
			{
				EnableEffect(affixSpawners[k].effectSpawner, value: false);
			}
		}
	}

	private void UpdateAffixRotator(DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixesBuffer)
	{
		if (activeAffixesBuffer.IsCreated)
		{
			affixRotatorTransform.localEulerAngles += new Vector3(0f, affixRotatorSpeedAngle * Time.deltaTime, 0f);
		}
	}

	public void PlayAffixActivationEffect(AffixID affixID)
	{
		for (int i = 0; i < affixSpawners.Count; i++)
		{
			AffixEffect affixEffect = affixSpawners[i];
			if (affixEffect.affixID == affixID)
			{
				Manager.effects.StartParticleEffect(affixEffect.activateParticleEffect, affixEffect.effectSpawner.gameObject, 3f);
				break;
			}
		}
	}

	public bool TryGetAffixRenderPos(AffixID affixID, out Vector3 affixRenderPos)
	{
		for (int i = 0; i < affixSpawners.Count; i++)
		{
			AffixEffect affixEffect = affixSpawners[i];
			if (affixEffect.affixID == affixID)
			{
				affixRenderPos = affixEffect.effectSpawner.transform.position;
				return true;
			}
		}
		affixRenderPos = Vector3.zero;
		return false;
	}

	private void EnableEffect(ParticleEffectSpawner effect, bool value)
	{
		if (value && !effect.enabled)
		{
			effect.enabled = true;
		}
		else if (!value)
		{
			effect.enabled = false;
		}
	}

	public void UpdateShowing(bool shouldShow)
	{
		if (container.activeSelf != shouldShow)
		{
			container.SetActive(shouldShow);
		}
	}

	private void UpdateCombinedLight(EntityMonoBehaviour entityMono, DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffects)
	{
		m_lightSources.Clear();
		bool flag = conditionEffects[1].value > 0;
		bool flag2 = false;
		ActAsLightSourceWhenHeldInHandCD actAsLightSourceWhenHeldInHandCD = default(ActAsLightSourceWhenHeldInHandCD);
		if (entityMono is PlayerController { visuallyEquippedContainedObject: var visuallyEquippedContainedObject } playerController)
		{
			flag2 = PugDatabase.HasComponent<ActAsLightSourceWhenHeldInHandCD>(visuallyEquippedContainedObject.objectID, playerController.visuallyEquippedContainedObject.variation);
			if (flag2)
			{
				actAsLightSourceWhenHeldInHandCD = PugDatabase.GetComponent<ActAsLightSourceWhenHeldInHandCD>(playerController.visuallyEquippedContainedObject.objectID, playerController.visuallyEquippedContainedObject.variation);
				flag = true;
			}
			NativeList<ObjectID> smallGlowSourceObjects = new NativeList<ObjectID>(10, Allocator.Temp);
			playerController.GetSmallGlowSourceObjects(ref smallGlowSourceObjects);
			foreach (ObjectID item in smallGlowSourceObjects)
			{
				if (TryExtractSmallGlowLight(item, out var color, out var intensity))
				{
					m_lightSources.Add(new LightSource(color, intensity));
				}
			}
		}
		if (flag)
		{
			DynamicBuffer<SummarizedConditionsBuffer> conditionValues = EntityUtility.GetConditionValues(entityMono.entity, entityMono.world);
			float range = conditionValues[1].value;
			float range2 = conditionValues[45].value;
			float range3 = conditionValues[217].value;
			float range4 = conditionValues[321].value;
			float range5 = conditionValues[355].value;
			m_lightSources.Add(new LightSource(blueGlowColor, range));
			m_lightSources.Add(new LightSource(orangeGlowColor, range2));
			m_lightSources.Add(new LightSource(pinkGlowColor, range3));
			m_lightSources.Add(new LightSource(greenGlowColor, range4));
			m_lightSources.Add(new LightSource(voidGlowColor, range5));
			if (flag2)
			{
				m_lightSources.Add(new LightSource(actAsLightSourceWhenHeldInHandCD.color, actAsLightSourceWhenHeldInHandCD.range));
			}
		}
		bool flag3 = m_lightSources.Count > 0;
		if (flag3)
		{
			CombineLightSources(m_lightSources, out var radiance, out var range6);
			glowLight.lightToOptimize.color = radiance;
			glowLight.lightToOptimize.range = range6;
		}
		if (!flag3 && m_hadLight && !m_wasHoldingLightSource)
		{
			entityMono.SpawnFadeOutLight(glowLight.lightToOptimize, 1f);
		}
		m_hadLight = flag3;
		m_wasHoldingLightSource = flag2;
		glowLight.gameObject.SetActive(flag3);
	}

	private static bool TryExtractSmallGlowLight(ObjectID glowSourceObject, out Color color, out float intensity)
	{
		color = Color.black;
		intensity = 0f;
		if (PugDatabase.HasComponent<SmallGlowLightCD>(glowSourceObject))
		{
			SmallGlowLightCD component = PugDatabase.GetComponent<SmallGlowLightCD>(glowSourceObject);
			intensity = component.intensity;
			color = component.color;
			return true;
		}
		return false;
	}

	private void UpdateVoidBreachEffect(EntityMonoBehaviour entityMono, DynamicBuffer<SummarizedConditionsBuffer> conditions)
	{
		bool flag = conditions[328].value > 0;
		if (flag && !voidBreachEffect.gameObject.activeSelf)
		{
			voidBreachEffect.gameObject.SetActive(value: true);
			_voidLoop = AudioManager.Sfx(SfxID.VoidLoop, base.transform.position, 0.6f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: false, loop: true);
		}
		else if (!flag && voidBreachEffect.gameObject.activeSelf)
		{
			EnableEffect(voidBreachEffect, value: false);
			if (_voidLoop != null)
			{
				_voidLoop.FadeOutAndStop(1f);
				_voidLoop = null;
			}
			voidBreachEffect.gameObject.SetActive(value: false);
		}
	}

	private void UpdateSnareEffect(DynamicBuffer<SummarizedConditionsBuffer> conditions)
	{
		bool flag = conditions[27].value > 0;
		if (flag && !snareEffect.activeSelf)
		{
			snareEffect.SetActive(value: true);
		}
		else if (!flag && snareEffect.activeSelf && !isSnareBeingDestroyed)
		{
			isSnareBeingDestroyed = true;
			snareDestroyCurrentTime = 0.4f;
			if ((bool)snareAnimator)
			{
				snareAnimator.SetTrigger(16528305);
				AudioManager.Sfx(SfxTableID.snarePlantDestroyed, snareEffect.transform.position);
			}
			else
			{
				snareEffect.SetActive(value: false);
			}
		}
		if (isSnareBeingDestroyed && snareDestroyCurrentTime <= 0f && snareEffect.activeSelf)
		{
			snareEffect.SetActive(value: false);
			isSnareBeingDestroyed = false;
		}
	}

	private void UpdateHealEffect(Entity mainEntity, EntityMonoBehaviour entityMono, DynamicBuffer<SummarizedConditionsBuffer> conditions)
	{
		bool flag = EntityUtility.HasComponentData<HealthRegenerationCD>(mainEntity, entityMono.world) && regenerateCurrentTime > 0f;
		bool flag2 = conditions[5].value > 0 || conditions[211].value > 0 || (EntityUtility.HasComponentData<IsBeingBeHealedByOtherEntitiesCD>(mainEntity, entityMono.world) && EntityUtility.GetComponentData<IsBeingBeHealedByOtherEntitiesCD>(mainEntity, entityMono.world).isBeingHealed) || flag;
		if (flag2 && entityMono is PlayerController playerController && playerController.currentHealth >= playerController.GetMaxHealth())
		{
			flag2 = false;
		}
		if (!healEffect.enabled && flag2 && !(entityMono is PlayerController))
		{
			AudioManager.Sfx(SfxTableID.heal, base.transform.position);
		}
		EnableEffect(healEffect, flag2);
	}

	private void UpdateStunEffect(EntityMonoBehaviour entityMono, DynamicBuffer<SummarizedConditionsBuffer> conditions)
	{
		bool flag = conditions[104].value > 0;
		if (flag && !stunEffect.activeSelf)
		{
			stunAnimator.SetTrigger(16528305);
			stunEffect.transform.localPosition = defaultStunEffectPosition + entityMono.conditionsEffectsSettings.stunEffectOffset;
			stunEffect.SetActive(value: true);
		}
		else if (!flag && stunEffect.activeSelf)
		{
			stunEffect.SetActive(value: false);
		}
	}

	private static void CombineLightSources(List<LightSource> lightSources, out Color radiance, out float range)
	{
		range = 0f;
		radiance = Color.clear;
		foreach (LightSource lightSource in lightSources)
		{
			range = Mathf.Max(range, lightSource.range);
			radiance += lightSource.color * (lightSource.range * lightSource.range);
		}
		radiance /= range * range;
		float num = (radiance.r + radiance.g + radiance.b) * 0.333f;
		if (num > 1f)
		{
			radiance /= num;
			range *= num;
		}
		if (range < 2f)
		{
			radiance *= range / 2f;
			range = 2f;
		}
	}
}
