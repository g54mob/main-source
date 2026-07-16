using System;
using System.Collections.Generic;
using AudioSystem;
using TMPro;
using UnityEngine;

public class TrainSelectionWindow : Menu
{
	[Header("UI Elements")]
	[SerializeField]
	private GameObject EnhancementContentHolder;

	[SerializeField]
	private TextMeshProUGUI TrainNameTxt;

	[SerializeField]
	private TextMeshProUGUI TrainDescriptionTxt;

	[SerializeField]
	private TextMeshProUGUI TrainStatsTxt;

	[SerializeField]
	private TextMeshProUGUI PassiveHeaderTxt;

	[SerializeField]
	private TextMeshProUGUI PassiveDescriptionTxt;

	[SerializeField]
	private GameObject EnhancementPreviewPrefab;

	[SerializeField]
	private GameObject QuestionMarksTxt;

	[SerializeField]
	private List<TrainVariantIcon> trainVariants;

	private List<GameObject> enhancements;

	[NonSerialized]
	public NewTrainBase lastSelectedAvailableTrain;

	[Header("SFX")]
	[SerializeField]
	private SoundData trainSwapSfx;

	private SoundBuilder soundBuilder;

	private Vector3 cameraTargetPos;

	public override void Init()
	{
		base.Init();
		if (enhancements == null || enhancements.Count == 0)
		{
			enhancements = new List<GameObject>();
		}
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
		cameraTargetPos = new Vector3(Train.Instance.furnace.transform.position.x + 0.5f, Train.Instance.furnace.transform.position.y + 0.015f, Train.Instance.furnace.transform.position.z);
	}

	public void RemoveAll()
	{
		Train.Instance.currentTrain.RemoveTrain();
		foreach (NewTrainBase key in Train.Instance.trains.Keys)
		{
			key.RemoveTrain(isRemoveAll: true);
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			wagon.SetHardening(isHardened: false);
		}
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		CameraController.Instance.SetPosition(cameraTargetPos);
		SelectTrainIcon(Train.Instance.currentTrain.trainType);
		ApplyTrainText();
	}

	private void ApplyTrainByType(TrainType trainType)
	{
		switch (trainType)
		{
		case TrainType.Regular:
			ApplyRegularTrain();
			break;
		case TrainType.Warp:
			ApplyWrapTrain();
			break;
		case TrainType.Cannon:
			ApplyCannonTrain();
			break;
		case TrainType.Armored:
			ApplyArmoredTrain();
			break;
		case TrainType.Fire:
			ApplyFireTrain();
			break;
		}
	}

	private void SelectTrainIcon(TrainType trainType)
	{
		switch (trainType)
		{
		case TrainType.Regular:
			OutlineToEnable(0);
			break;
		case TrainType.Warp:
			OutlineToEnable(1);
			break;
		case TrainType.Cannon:
			OutlineToEnable(2);
			break;
		case TrainType.Armored:
			OutlineToEnable(3);
			break;
		case TrainType.Fire:
			OutlineToEnable(4);
			break;
		}
	}

	private void ApplyTrainText()
	{
		QuestionMarksTxt.SetActive(value: false);
		foreach (GameObject enhancement in enhancements)
		{
			UnityEngine.Object.Destroy(enhancement);
		}
		enhancements.Clear();
		if (Train.Instance.currentTrain.additionalStartingModules != null)
		{
			foreach (EnhancementModule additionalStartingModule in Train.Instance.currentTrain.additionalStartingModules)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(EnhancementPreviewPrefab, EnhancementContentHolder.transform);
				gameObject.GetComponent<EnhancementPreview>().SetPreview(additionalStartingModule);
				enhancements.Add(gameObject);
			}
		}
		if (Train.Instance.currentTrain.additionalStartingRelics != null)
		{
			foreach (EnhancementUpgrade additionalStartingRelic in Train.Instance.currentTrain.additionalStartingRelics)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(EnhancementPreviewPrefab, EnhancementContentHolder.transform);
				gameObject2.GetComponent<EnhancementPreview>().SetPreview(additionalStartingRelic);
				enhancements.Add(gameObject2);
			}
		}
		if (Train.Instance.currentTrain.additionalStartingUpgrades != null)
		{
			foreach (EnhancementUpgrade additionalStartingUpgrade in Train.Instance.currentTrain.additionalStartingUpgrades)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(EnhancementPreviewPrefab, EnhancementContentHolder.transform);
				gameObject3.GetComponent<EnhancementPreview>().SetPreview(additionalStartingUpgrade);
				enhancements.Add(gameObject3);
			}
		}
		TrainNameTxt.text = Train.Instance.currentTrain.NameTxt.GetLocalizedString();
		TrainDescriptionTxt.text = Train.Instance.currentTrain.TrainDescriptionTxt.GetLocalizedString();
		TrainStatsTxt.text = "Journeys started: \nJourneys finished: ";
		PassiveHeaderTxt.text = Train.Instance.currentTrain.PassiveNameTxt.GetLocalizedString();
		PassiveDescriptionTxt.text = Train.Instance.currentTrain.PassiveDescriptionTxt.GetLocalizedString();
		if (Train.Instance.currentTrain.statUpgrades == null)
		{
			return;
		}
		foreach (StatsUpgrade statUpgrade in Train.Instance.currentTrain.statUpgrades)
		{
			if (PassiveDescriptionTxt.text.Length > 0)
			{
				TextMeshProUGUI passiveDescriptionTxt = PassiveDescriptionTxt;
				passiveDescriptionTxt.text = passiveDescriptionTxt.text + "\n- " + statUpgrade.Description;
			}
			else
			{
				TextMeshProUGUI passiveDescriptionTxt2 = PassiveDescriptionTxt;
				passiveDescriptionTxt2.text = passiveDescriptionTxt2.text + "- " + statUpgrade.Description;
			}
		}
	}

	public void ApplyRegularTrain()
	{
		ApplyTrain(TrainType.Regular);
	}

	public void ApplyArmoredTrain()
	{
		ApplyTrain(TrainType.Armored);
	}

	public void ApplyFireTrain()
	{
		ApplyTrain(TrainType.Fire);
	}

	public void ApplyWrapTrain()
	{
		ApplyTrain(TrainType.Warp);
	}

	public void ApplyCannonTrain()
	{
		ApplyTrain(TrainType.Cannon);
	}

	public void ApplyTrain(TrainType type)
	{
		if (!Train.Instance.isSwapping)
		{
			lastSelectedAvailableTrain = Train.Instance.currentTrain;
			if (Train.Instance.currentTrain.trainType != type || (QuestionMarksTxt.activeSelf && type == TrainType.Regular))
			{
				soundBuilder.Play(trainSwapSfx);
				Train.Instance.DriveOut(type);
			}
		}
	}

	public void SwapTrains(TrainType type)
	{
		foreach (NewTrainBase key in Train.Instance.trains.Keys)
		{
			if (key.trainType != type)
			{
				continue;
			}
			RemoveAll();
			if (Train.Instance.trains[key])
			{
				foreach (NewTrainBase key2 in Train.Instance.trains.Keys)
				{
					if (key2.trainType == TrainType.Regular)
					{
						key2.ApplyNewTrain();
						Train.Instance.SetNewTrain(key2);
						SetLockedTrainText(key);
					}
				}
				break;
			}
			key.ApplyNewTrain();
			Train.Instance.SetNewTrain(key);
			ApplyTrainText();
			lastSelectedAvailableTrain = key;
			break;
		}
	}

	public void SwappingFinished(TrainType type)
	{
		SelectTrainIcon(type);
		LockAllButtons(isLocked: false);
	}

	private void SetLockedTrainText(NewTrainBase lockedTrain)
	{
		foreach (GameObject enhancement in enhancements)
		{
			UnityEngine.Object.Destroy(enhancement);
		}
		enhancements.Clear();
		TrainNameTxt.text = "Unknown Train";
		TrainDescriptionTxt.text = "";
		TrainStatsTxt.text = "";
		QuestionMarksTxt.SetActive(value: true);
		PassiveHeaderTxt.text = "Unlock Requirement";
		PassiveDescriptionTxt.text = lockedTrain.UnlockRequirementTxt.GetLocalizedString();
	}

	private void OutlineToEnable(int outline)
	{
		trainVariants[outline].Outline.enabled = true;
		for (int i = 0; i < trainVariants.Count; i++)
		{
			if (i != outline)
			{
				trainVariants[i].Outline.enabled = false;
			}
		}
	}

	private bool IsTrainTypeLocked(TrainType type)
	{
		foreach (NewTrainBase key in Train.Instance.trains.Keys)
		{
			if (key.trainType == type)
			{
				return Train.Instance.trains[key];
			}
		}
		return true;
	}

	public void LockAllButtons(bool isLocked)
	{
		foreach (TrainVariantIcon trainVariant in trainVariants)
		{
			trainVariant.Button.interactable = !isLocked;
		}
	}
}
