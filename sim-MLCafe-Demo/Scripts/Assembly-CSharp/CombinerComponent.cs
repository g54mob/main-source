using System.Linq;
using TMPro;
using UnityEngine;

public class CombinerComponent : WorkstationCore
{
	[SerializeField]
	private Item[] validItems;

	[SerializeField]
	private Transform[] loaderInputs;

	[SerializeField]
	private Transform loaderOuput;

	[SerializeField]
	private AnimationCurve loaderCurve;

	[SerializeField]
	[Range(0f, 10f)]
	private float rounds;

	[SerializeField]
	private Transform axisHandle;

	[SerializeField]
	private AnimationCurve handleCurve;

	[SerializeField]
	private Item mixedBeans;

	[SerializeField]
	private TMP_Text labelInput_1;

	[SerializeField]
	private TMP_Text labelInput_2;

	[SerializeField]
	private TMP_Text labelOutput;

	[Header("Sound")]
	[SerializeField]
	private string soundProcessing;

	[SerializeField]
	private AudioSource soundInstanceProcessing;

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyInvalidSimiliarFlavour = "ui_popup_invalid_msg_combiner_nosimiliarflavours";

	[SerializeField]
	private string localizationKeyInvalidItem = "ui_popup_invalid_msg_combiner_invaliditem";

	private float loaderOpenPos = 0.15f;

	private float loaderClosedPos;

	private float targetRotation;

	private bool readyToCombine;

	private int flavourMix;

	public override void OnInit()
	{
		SoundManager.SetupExistingAudioSource(soundProcessing, soundInstanceProcessing);
		if (readyToCombine)
		{
			CloseLoaders();
		}
		else
		{
			OpenLoaders();
		}
	}

	public override void OnPlayerInteraction(CharacterControllerComponent character)
	{
		CheckReadyState();
		if (readyToCombine && !character.socket.IsHoldingItem())
		{
			if (processingType == WorkstationProcessingType.Automatic && !isProcessing)
			{
				isProcessing = true;
			}
			return;
		}
		WorkstationComponent[] array;
		if (character.socket.IsHoldingItem())
		{
			ItemComponent itemComponent = character.socket.GetItemComponent();
			if (!validItems.Any((Item x) => x.id == itemComponent.item.id))
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidItem);
				return;
			}
			if (AnomalyTag.HasAnySameBits(flavourMix, itemComponent.item.tag.anomalyFlags))
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidSimiliarFlavour);
				return;
			}
			array = workstationComponents;
			foreach (WorkstationComponent workstationComponent in array)
			{
				if (!workstationComponent.IsReady() && workstationComponent.IsRequiredItem(itemComponent))
				{
					workstationComponent.OnProcessItemComponent.Invoke(itemComponent, workstationComponent.GetTag());
					break;
				}
			}
			return;
		}
		array = workstationComponents;
		foreach (WorkstationComponent workstationComponent2 in array)
		{
			if (workstationComponent2.IsReady())
			{
				flavourMix -= workstationComponent2.GetSocket().GetItemComponent().item.tag.anomalyFlags;
				workstationComponent2.UnmarkReady();
				character.socket.PushItem(workstationComponent2.GetSocket().GetItemComponent());
				if (workstationComponent2.GetTag() == "Input1")
				{
					labelInput_1.text = "";
				}
				if (workstationComponent2.GetTag() == "Input2")
				{
					labelInput_2.text = "";
				}
				break;
			}
		}
		if (!workstationComponents.Any((WorkstationComponent x) => x.IsReady()))
		{
			flavourMix = 0;
			labelOutput.text = "";
		}
	}

	public override void OnPlayerHoldingInteraction(CharacterControllerComponent character)
	{
		if (processingType != WorkstationProcessingType.Automatic && readyToCombine)
		{
			OnProcessingManual();
		}
	}

	protected override void OnProcessingManual()
	{
		if (remainingProcessingTime > 0f)
		{
			if (!ProgressbarManager.GetDefaultProgressBar().IsVisible())
			{
				ProgressbarManager.GetDefaultProgressBar().ShowProgressbar();
			}
			else
			{
				ProgressbarManager.GetDefaultProgressBar().UpdateBar(Mathf.InverseLerp(processingDuration, 0f, remainingProcessingTime));
			}
			InteractionDisplayComponent component = GetComponent<InteractionDisplayComponent>();
			if (component != null)
			{
				component.UpdateDuration(remainingProcessingTime, processingDuration);
			}
		}
		if (remainingProcessingTime <= 0f && ProgressbarManager.GetDefaultProgressBar().IsVisible())
		{
			ProgressbarManager.GetDefaultProgressBar().HideProgressbar();
		}
		CombineProcessing();
	}

	protected override void OnProcessingAutomatic()
	{
		CombineProcessing();
	}

	private void CombineProcessing()
	{
		if (remainingProcessingTime > 0f)
		{
			remainingProcessingTime -= Time.deltaTime;
			isProcessing = true;
			float time = Mathf.InverseLerp(processingDuration, 0f, remainingProcessingTime);
			axisHandle.localRotation = Quaternion.Euler(axisHandle.localEulerAngles.x, axisHandle.localEulerAngles.y, Mathf.Lerp(targetRotation - 360f * rounds, targetRotation, handleCurve.Evaluate(time)));
			if (!soundInstanceProcessing.isPlaying)
			{
				soundInstanceProcessing.Play();
			}
		}
		else if (remainingProcessingTime <= 0f)
		{
			isProcessing = false;
			readyToCombine = false;
			remainingProcessingTime = processingDuration;
			FinishCombiner();
			if (soundInstanceProcessing.isPlaying)
			{
				soundInstanceProcessing.Stop();
			}
		}
	}

	private void CheckReadyState()
	{
		bool flag = workstationComponents.Any((WorkstationComponent x) => !x.IsReady());
		readyToCombine = !flag;
		if (readyToCombine && !isProcessing)
		{
			CloseLoaders();
		}
	}

	public void PushIngredient(ItemComponent itemComponent, string workstationComponentTag)
	{
		WorkstationComponent workstationComponent = workstationComponents.FirstOrDefault((WorkstationComponent x) => x.GetTag() == workstationComponentTag);
		workstationComponent.GetSocket().PushItem(itemComponent);
		workstationComponent.MarkReady();
		flavourMix += itemComponent.item.tag.anomalyFlags;
		if (workstationComponentTag == "Input1")
		{
			labelInput_1.text = itemComponent.item.tag.GetFormattedLocalizedTags();
		}
		if (workstationComponentTag == "Input2")
		{
			labelInput_2.text = itemComponent.item.tag.GetFormattedLocalizedTags();
		}
		if (!workstationComponents.Any((WorkstationComponent x) => !x.IsReady()))
		{
			AnomalyTag anomalyTag = new AnomalyTag();
			anomalyTag.anomalyFlags = flavourMix;
			labelOutput.text = anomalyTag.GetFormattedLocalizedTags();
		}
	}

	public void FinishCombiner()
	{
		ItemComponent component = Object.Instantiate(InventorySystem.GetItemLibrary().itemInfos[mixedBeans.id].prefab, loaderOuput).GetComponent<ItemComponent>();
		component.item.tag.anomalyFlags = flavourMix;
		loaderOuput.GetComponentInChildren<ItemSocket>().PushItem(component);
		if (component.GetComponent<IngredientColorPicker>() != null)
		{
			component.GetComponent<IngredientColorPicker>().PickColorByMask(flavourMix);
		}
		OpenLoaders();
		WorkstationComponent[] array = workstationComponents;
		foreach (WorkstationComponent obj in array)
		{
			Object.Destroy(obj.GetSocket().GetItemComponent().gameObject);
			obj.GetSocket().Clear();
			obj.Reset();
		}
		flavourMix = 0;
		labelInput_1.text = "";
		labelInput_2.text = "";
		labelOutput.text = "";
	}

	private void OpenLoaders()
	{
		TweenerManager.TweenPosition(start: new Vector3(0f, loaderOuput.transform.localPosition.y, 0f), end: new Vector3(0f, loaderOuput.transform.localPosition.y, loaderOpenPos), key: "Combiner_OpenOutput_1", value: loaderOuput, duration: 0.7f, curve: loaderCurve, space: Space.Self);
		for (int i = 0; i < loaderInputs.Length; i++)
		{
			TweenerManager.TweenPosition(start: new Vector3(0f, 0f - loaderOpenPos, 0f), end: new Vector3(0f, 0f, 0f), key: "Combiner_Open_Input_" + i, value: loaderInputs[i], duration: 0.7f, curve: loaderCurve, space: Space.Self);
		}
	}

	private void CloseLoaders()
	{
		TweenerManager.TweenPosition(start: new Vector3(0f, loaderOuput.transform.localPosition.y, loaderOpenPos), end: new Vector3(0f, loaderOuput.transform.localPosition.y, 0f), key: "Combiner_Ready", value: loaderOuput, duration: 0.7f, curve: loaderCurve, space: Space.Self);
		for (int i = 0; i < loaderInputs.Length; i++)
		{
			TweenerManager.TweenPosition(start: new Vector3(0f, 0f, 0f), end: new Vector3(0f, 0f - loaderOpenPos, 0f), key: "Combiner_Load_Input_" + i, value: loaderInputs[i], duration: 0.7f, curve: loaderCurve, space: Space.Self);
		}
	}
}
