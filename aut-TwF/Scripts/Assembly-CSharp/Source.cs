using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Source : GameplayObject, ISavable
{
	[SerializeField]
	private ResourceData resource;

	[SerializeField]
	[Tooltip("maxAmount <= 0: infinito")]
	private int maxAmount = 100;

	[Savable("currentAmount", true, false)]
	private int currentAmount;

	[SerializeField]
	private GameObject sourceDepletedVFX;

	[SerializeField]
	private AudioData sourceDepletedSound;

	[Header("Mouse farming")]
	[SerializeField]
	private int clickFarmingUnits = 1;

	private int currentClickFarmingUnits;

	[SerializeField]
	private AudioData[] mouseFarmingSoftClips;

	[SerializeField]
	private AudioData[] mouseFarmingHardClips;

	private static float lastTimeClickFarmed;

	private PlacementComponent placementComponent;

	private Coroutine clickFarmingCoroutine;

	public int CurrentAmount
	{
		get
		{
			return currentAmount;
		}
		private set
		{
			if (maxAmount > 0)
			{
				currentAmount = value;
				if (currentAmount <= 0)
				{
					DestroySource(playSound: true);
				}
			}
		}
	}

	public ResourceData Resource
	{
		get
		{
			return resource;
		}
		private set
		{
			resource = value;
		}
	}

	public int ClickFarmingUnits
	{
		get
		{
			return clickFarmingUnits;
		}
		private set
		{
			clickFarmingUnits = value;
		}
	}

	public int CurrentClickFarmingUnits
	{
		get
		{
			return currentClickFarmingUnits;
		}
		private set
		{
			currentClickFarmingUnits = value;
		}
	}

	public PlacementComponent PlacementComponent => placementComponent;

	public event Action onSourceDepleted;

	public event Action<Source> onClickFarmingPerformed;

	private void Awake()
	{
		placementComponent = GetComponent<PlacementComponent>();
		objectData.CanBeSold = false;
		CurrentAmount = maxAmount;
		lastTimeClickFarmed = 0f;
	}

	private void Start()
	{
		MouseInteractive component = GetComponent<MouseInteractive>();
		component.onStartLeftClick = (Action)Delegate.Combine(component.onStartLeftClick, new Action(OnStartLeftClick));
		component.onEndLeftClick = (Action)Delegate.Combine(component.onEndLeftClick, new Action(OnEndLeftClick));
	}

	private void OnDestroy()
	{
		DOTween.Kill(base.gameObject);
		DOTween.Kill(base.transform);
	}

	public bool IsDepleted()
	{
		if (maxAmount <= 0)
		{
			return false;
		}
		return currentAmount <= 0;
	}

	public int ExtractResource(int amount = 1)
	{
		if (maxAmount > 0)
		{
			int num = CurrentAmount;
			CurrentAmount = Mathf.Max(0, CurrentAmount - amount);
			return num - CurrentAmount;
		}
		return amount;
	}

	private IEnumerator ClickFarmingCoroutine()
	{
		float holdClickFarmingSpeed = LTFunctionLibrary.GetPlayerStatsComponent().GetStat(EStats.ClickFarmingSpeed);
		float num = Mathf.Max(holdClickFarmingSpeed - 0.1f, 0.01f);
		if (Time.time - lastTimeClickFarmed < num * Time.timeScale)
		{
			yield return new WaitForSeconds(num * Time.timeScale - (Time.time - lastTimeClickFarmed));
		}
		while (true)
		{
			CurrentClickFarmingUnits++;
			if (CurrentClickFarmingUnits >= ClickFarmingUnits)
			{
				ExtractResource();
				CurrentClickFarmingUnits = 0;
				LTFunctionLibrary.GetPlayerInventory().StoreObject(Resource, 1, Storage_ResourceData.EStoreSource.Production);
				base.Model.transform.DOComplete();
				base.Model.transform.DOPunchScale(Vector3.one * 0.2f, 0.35f, 13, 0.3f);
				if (mouseFarmingHardClips != null && mouseFarmingHardClips.Length != 0)
				{
					AudioSystem.Instance.PlaySound2D(mouseFarmingHardClips[UnityEngine.Random.Range(0, mouseFarmingHardClips.Length)], AudioSystem.EAudioMixerGroup.SFX);
				}
			}
			else
			{
				base.Model.transform.DOComplete();
				base.Model.transform.DOPunchScale(Vector3.one * 0.075f, 0.125f, 10, 0.1f);
				if (mouseFarmingSoftClips != null && mouseFarmingSoftClips.Length != 0)
				{
					AudioSystem.Instance.PlaySound2D(mouseFarmingSoftClips[UnityEngine.Random.Range(0, mouseFarmingSoftClips.Length)], AudioSystem.EAudioMixerGroup.SFX);
				}
			}
			lastTimeClickFarmed = Time.time;
			this.onClickFarmingPerformed?.Invoke(this);
			yield return new WaitForSeconds(holdClickFarmingSpeed * Mathf.Max(1f, Time.timeScale));
		}
	}

	public void DestroySource(bool playSound = false)
	{
		currentAmount = 0;
		if ((bool)sourceDepletedVFX)
		{
			UnityEngine.Object.Instantiate(sourceDepletedVFX, base.transform.position, base.transform.rotation);
		}
		if (playSound && sourceDepletedSound != null)
		{
			AudioSystem.Instance.PlaySound3D(sourceDepletedSound, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f);
		}
		this.onSourceDepleted?.Invoke();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnStartLeftClick()
	{
		this.StartCoroutineCheckingVar(ClickFarmingCoroutine(), ref clickFarmingCoroutine);
	}

	private void OnEndLeftClick()
	{
		this.StopCoroutineCheckingVar(ref clickFarmingCoroutine);
	}

	public new void OnSave()
	{
	}

	public new void OnPreLoad()
	{
	}

	public new void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!hasLoadedSomething)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
