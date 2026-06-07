using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Storage_ResourceData), typeof(StatsComponent))]
public class Extractor : GameplayObject
{
	[SerializeField]
	private List<GameplayObjectData> validSources;

	[SerializeField]
	private bool startExtractionOnSetSource = true;

	[SerializeField]
	private ConveyorBelt[] conveyorBelts;

	private Source currentSource;

	private Storage_ResourceData storage;

	private PlacementComponent placementComponent;

	private Animator animator;

	private StatsComponent statsComponent;

	private GameplayEffectsComponent gameplayEffectsComponent;

	private bool isExtracting;

	private float lastTimeStartedExtraction;

	private float resourceConsumptionProbability = 1f;

	private Coroutine extractionCoroutine;

	private Coroutine startExtractionCoroutine;

	private Coroutine stopAnimationCoroutine;

	private WaitForSeconds startExtractionWFS;

	private WaitForSeconds extractionWFS;

	public Source CurrentSource
	{
		get
		{
			return currentSource;
		}
		set
		{
			_ = currentSource;
			if ((bool)currentSource)
			{
				currentSource.onSourceDepleted -= OnCurrentSourceDepleted;
			}
			currentSource = value;
			if ((bool)currentSource)
			{
				currentSource.onSourceDepleted += OnCurrentSourceDepleted;
				if (startExtractionOnSetSource)
				{
					this.StartCoroutineCheckingVar(StartExtractionCoroutine(), ref startExtractionCoroutine, stopCoroutineIfRunning: true);
				}
			}
			this.onCurrentSourceChanged?.Invoke(currentSource);
		}
	}

	public Storage_ResourceData Storage
	{
		get
		{
			return storage;
		}
		private set
		{
			storage = value;
		}
	}

	public PlacementComponent PlacementComponent
	{
		get
		{
			return placementComponent;
		}
		private set
		{
			placementComponent = value;
		}
	}

	protected Animator Animator => animator;

	public StatsComponent StatsComponent
	{
		get
		{
			return statsComponent;
		}
		set
		{
			statsComponent = value;
		}
	}

	public bool IsExtracting
	{
		get
		{
			return isExtracting;
		}
		private set
		{
			isExtracting = value;
		}
	}

	public float ExtractionTime
	{
		get
		{
			if (!StatsComponent)
			{
				return GetComponent<StatsComponent>().GetConfigStat(EStats.Speed);
			}
			float stat = StatsComponent.GetStat(EStats.Speed);
			return 1f / ((stat > 0f) ? stat : 0.0001f);
		}
		set
		{
			if (!StatsComponent)
			{
				GetComponent<StatsComponent>().SetConfigStat(EStats.Speed, value);
			}
			else
			{
				StatsComponent.SetStat(EStats.Speed, value);
			}
		}
	}

	public List<GameplayObjectData> ValidSources
	{
		get
		{
			return validSources;
		}
		set
		{
			validSources = value;
		}
	}

	public float CurrentExtractionTime
	{
		get
		{
			if (!IsExtracting)
			{
				return 0f;
			}
			return Time.time - lastTimeStartedExtraction;
		}
	}

	public event Action onStartExtracting;

	public event Action onStopExtracting;

	public event Action<Source> onCurrentSourceChanged;

	public event Action<float> onSpeedChanged;

	private void Awake()
	{
		Storage = GetComponent<Storage_ResourceData>();
		PlacementComponent = GetComponentInParent<PlacementComponent>();
		animator = GetComponent<Animator>();
		StatsComponent = GetComponent<StatsComponent>();
		gameplayEffectsComponent = GetComponent<GameplayEffectsComponent>();
		startExtractionWFS = new WaitForSeconds(UnityEngine.Random.Range(0f, 0.75f));
	}

	protected virtual void Start()
	{
		PlacementComponent.onPlace += OnPlace;
		PlacementComponent.onUnplace += OnUnplace;
		statsComponent.onStatChanged += OnStatChanged;
		gameplayEffectsComponent.onEffectAdded += OnEffectAdded;
		gameplayEffectsComponent.onEffectRemoved += OnEffectRemoved;
		OnStatChanged(EStats.Speed, statsComponent.GetStat(EStats.Speed), statsComponent.GetStat(EStats.Speed));
		OnStatChanged(EStats.ResourceConsumptionProbability, statsComponent.GetStat(EStats.ResourceConsumptionProbability), 0f);
		if (PlacementComponent.IsPlaced)
		{
			OnPlace(PlacementComponent);
		}
	}

	protected virtual void OnDestroy()
	{
	}

	private void Extract(int amountToExtract)
	{
		if (currentSource != null && Storage.CanStore(currentSource.Resource.Id, amountToExtract))
		{
			Storage.StoreObject(currentSource.Resource, (UnityEngine.Random.value <= resourceConsumptionProbability) ? currentSource.ExtractResource(amountToExtract) : amountToExtract, Storage_ResourceData.EStoreSource.Production);
			if (currentSource == null || !Storage.CanStore(currentSource.Resource.Id, amountToExtract))
			{
				StopExtraction();
				Storage.onRemoveObject += OnStorageHasSpace;
			}
		}
		else
		{
			StopExtraction();
			Storage.onRemoveObject += OnStorageHasSpace;
		}
	}

	public IEnumerator StartExtractionCoroutine()
	{
		if ((bool)animator)
		{
			this.StopCoroutineCheckingVar(ref stopAnimationCoroutine);
			animator.ResetTrigger("Stop");
			yield return startExtractionWFS;
			animator.SetTrigger("Start");
		}
		else
		{
			yield return startExtractionWFS;
		}
		IsExtracting = true;
		this.StartCoroutineCheckingVar(ExtractionCoroutine(), ref extractionCoroutine, stopCoroutineIfRunning: true);
		this.onStartExtracting?.Invoke();
		startExtractionCoroutine = null;
	}

	public void StopExtraction()
	{
		this.StopCoroutineCheckingVar(ref startExtractionCoroutine);
		if ((bool)animator)
		{
			this.StartCoroutineCheckingVar(StopAnimationCoroutine(), ref stopAnimationCoroutine);
		}
		IsExtracting = false;
		this.StopCoroutineCheckingVar(ref extractionCoroutine);
		this.onStopExtracting?.Invoke();
	}

	public virtual int GetTotalUnitsLeft()
	{
		if (!(currentSource != null))
		{
			return 0;
		}
		return currentSource.CurrentAmount;
	}

	private void OnStorageHasSpace(Storage<ResourceData>.StoredObjectData removingObj, int removedAmount)
	{
		Storage.onRemoveObject -= OnStorageHasSpace;
		this.StartCoroutineCheckingVar(StartExtractionCoroutine(), ref startExtractionCoroutine, stopCoroutineIfRunning: true);
	}

	protected virtual void OnCurrentSourceDepleted()
	{
		Storage.onRemoveObject -= OnStorageHasSpace;
		StopExtraction();
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		switch (stat)
		{
		case EStats.Speed:
			animator.speed = newValue / statsComponent.GetStatBase(EStats.Speed);
			extractionWFS = new WaitForSeconds(ExtractionTime);
			if (IsExtracting)
			{
				this.StopCoroutineCheckingVar(ref extractionCoroutine);
				float num = 1f - (Time.time - lastTimeStartedExtraction) / (1f / oldValue);
				lastTimeStartedExtraction = Time.time - (1f - num) * ExtractionTime;
				this.StartCoroutineCheckingVar(ExtractionCoroutine(num), ref extractionCoroutine);
			}
			this.onSpeedChanged?.Invoke(newValue);
			break;
		case EStats.ResourceConsumptionProbability:
			resourceConsumptionProbability = newValue;
			break;
		}
	}

	private void OnEffectAdded(GameplayEffect effect)
	{
		ConveyorBelt[] array = conveyorBelts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GameplayEffectsComponent.ApplyEffect(effect.EffectData);
		}
	}

	private void OnEffectRemoved(GameplayEffect effect)
	{
		ConveyorBelt[] array = conveyorBelts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GameplayEffectsComponent.RemoveEffect(effect.EffectData);
		}
	}

	protected virtual void OnPlace(PlacementComponent placementComponent)
	{
	}

	protected virtual void OnUnplace(PlacementComponent placementComponent)
	{
		Storage.onRemoveObject -= OnStorageHasSpace;
		StopExtraction();
	}

	private IEnumerator ExtractionCoroutine(float firstExtractionMultiplier = 1f)
	{
		if (firstExtractionMultiplier < 1f)
		{
			yield return new WaitForSeconds(ExtractionTime * firstExtractionMultiplier);
			Extract(1);
		}
		while (true)
		{
			lastTimeStartedExtraction = Time.time;
			yield return extractionWFS;
			Extract(1);
		}
	}

	private IEnumerator StopAnimationCoroutine()
	{
		yield return null;
		animator.ResetTrigger("Start");
		animator.SetTrigger("Stop");
		stopAnimationCoroutine = null;
	}
}
