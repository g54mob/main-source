using System;
using MLCN_Localization;
using UnityEngine;

public class CoffeeGrinder : MonoBehaviour, IInteraction
{
	[SerializeField]
	private ItemSocket fillBagSocket;

	[SerializeField]
	private Transform axis;

	[SerializeField]
	private Transform loader;

	[SerializeField]
	private AnimationCurve handleCurve;

	[SerializeField]
	private AnimationCurve loaderCurve;

	[SerializeField]
	[Range(0f, 5f)]
	private float rounds;

	[SerializeField]
	private GameObject outputBag;

	[SerializeField]
	private int componentCapacity = 1;

	[SerializeField]
	private IngredientComponent ingredientSlot;

	[SerializeField]
	private IngredientComponent emptyBagSlot;

	[SerializeField]
	private AnomalyTag tagMix;

	[SerializeField]
	private float grindDuration;

	[SerializeField]
	private ParticleSystem psCoffeeBeans;

	[SerializeField]
	private Transform transformBeanClap;

	[Header("Sound")]
	[SerializeField]
	private string soundGrinding;

	[SerializeField]
	private string soundFillEmptyBag;

	[SerializeField]
	private AudioSource soundInstanceGrinding;

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyMissingItem;

	[SerializeField]
	private string localizationKeyCoffeeBeans;

	private float remainingGrind;

	private float targetRotation;

	private bool readyForGrind;

	private bool isGrinding;

	private Transform loaderPoint1;

	private Transform loaderPoint2;

	private void Start()
	{
		loaderPoint1 = new GameObject("P1").transform;
		loaderPoint1.parent = loader.parent;
		loaderPoint1.transform.position = loader.position;
		loaderPoint1.transform.localRotation = loader.localRotation;
		loaderPoint2 = new GameObject("P2").transform;
		loaderPoint2.parent = loader.parent;
		loaderPoint2.transform.position = loader.parent.position;
		loaderPoint2.transform.localRotation = loader.localRotation;
		SoundManager.SetupExistingAudioSource(soundGrinding, soundInstanceGrinding);
	}

	private bool IsGrinderFull()
	{
		return ingredientSlot.ready;
	}

	private bool HasEmptyBagToFill()
	{
		return emptyBagSlot.ready;
	}

	private bool ReadyForGrind()
	{
		if (HasEmptyBagToFill())
		{
			return IsGrinderFull();
		}
		return false;
	}

	void IInteraction.OnPlayerInteraction(CharacterControllerComponent character)
	{
		if (character.socket.IsHoldingItem() && !readyForGrind)
		{
			if (CheckFillbag(character.socket))
			{
				CheckReadyState();
			}
			else if (CheckForIngredient(character.socket))
			{
				CheckReadyState();
			}
			else if (readyForGrind)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_grinder_ready");
			}
			else
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_common_invaliditem");
			}
		}
		else if (CheckReadyState())
		{
			readyForGrind = true;
			targetRotation = axis.eulerAngles.y + 360f * rounds;
		}
		else if (!character.socket.IsHoldingItem())
		{
			if (!fillBagSocket.IsHoldingItem())
			{
				string localizedMessage = LocalizationManager.GetLocalizedString(localizationKeyMissingItem, LocalizationDataTable.Tables.UI) + PopupMessageManager.GetHighlightBegin() + fillBagSocket.GetRequiredItemInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd();
				PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
			}
			else if (!ingredientSlot.ready)
			{
				string localizedMessage2 = LocalizationManager.GetLocalizedString(localizationKeyMissingItem, LocalizationDataTable.Tables.UI) + PopupMessageManager.GetHighlightBegin() + LocalizationManager.GetLocalizedString(localizationKeyCoffeeBeans, LocalizationDataTable.Tables.Items) + PopupMessageManager.GetHighlightEnd();
				PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage2);
			}
		}
		else if (fillBagSocket.IsHoldingItem() && !character.socket.IsHoldingItem())
		{
			character.socket.PushItem(fillBagSocket.GetItemComponent());
		}
	}

	void IInteraction.OnPlayerAction(CharacterControllerComponent character)
	{
		GetComponent<RemovableInstance>().OnPlayerAction(character);
	}

	void IInteraction.OnPlayerHoldInteraction(CharacterControllerComponent character)
	{
		if (!readyForGrind)
		{
			return;
		}
		if (remainingGrind > 0f && fillBagSocket.GetItemComponent().item.amount == 0)
		{
			remainingGrind -= Time.deltaTime;
			isGrinding = true;
			float time = Mathf.InverseLerp(grindDuration, 0f, remainingGrind);
			axis.rotation = Quaternion.Euler(axis.eulerAngles.x, Mathf.Lerp(targetRotation - 360f * rounds, targetRotation, handleCurve.Evaluate(time)), axis.eulerAngles.z);
			if (!soundInstanceGrinding.isPlaying)
			{
				soundInstanceGrinding.Play();
			}
			if (!ProgressbarManager.GetDefaultProgressBar().IsVisible())
			{
				ProgressbarManager.GetDefaultProgressBar().ShowProgressbar();
			}
			else
			{
				ProgressbarManager.GetDefaultProgressBar().UpdateBar(Mathf.InverseLerp(grindDuration, 0f, remainingGrind));
			}
			InteractionDisplayComponent component = GetComponent<InteractionDisplayComponent>();
			if (component != null)
			{
				component.UpdateDuration(remainingGrind, grindDuration);
			}
		}
		else if (remainingGrind <= 0f)
		{
			isGrinding = false;
			readyForGrind = false;
			remainingGrind = grindDuration;
			GameObject gameObject = UnityEngine.Object.Instantiate(outputBag, fillBagSocket.GetItemComponent().transform.parent);
			gameObject.transform.position = fillBagSocket.GetItemComponent().transform.position;
			if (gameObject.GetComponent<IngredientColorPicker>() != null)
			{
				gameObject.GetComponent<IngredientColorPicker>().PickColorByMask(tagMix.anomalyFlags);
			}
			UnityEngine.Object.Destroy(fillBagSocket.GetItemComponent().gameObject);
			fillBagSocket.Clear();
			fillBagSocket.PushItem(gameObject.GetComponent<ItemComponent>());
			fillBagSocket.GetItemComponent().item.tag = tagMix;
			fillBagSocket.GetItemComponent().RefillItem();
			ClearGrinder();
			TweenerManager.Tween("GrindLoaderOut", loader, loaderPoint2, loaderPoint1, 0.7f, loaderCurve);
			if (soundInstanceGrinding.isPlaying)
			{
				soundInstanceGrinding.Stop();
			}
			if (ProgressbarManager.GetDefaultProgressBar().IsVisible())
			{
				ProgressbarManager.GetDefaultProgressBar().HideProgressbar();
			}
			TutorialManager.TryCheckSectionChecklistOption("CoffeeGrinder_Grind", TutorialManager.TutorialState.MakeCoffee);
		}
	}

	void IInteraction.OnPlayerHoldInteractionStopped(CharacterControllerComponent character)
	{
		isGrinding = false;
		if (soundInstanceGrinding.isPlaying)
		{
			soundInstanceGrinding.Stop();
		}
		if (ProgressbarManager.GetDefaultProgressBar().IsVisible())
		{
			ProgressbarManager.GetDefaultProgressBar().HideProgressbar();
		}
	}

	private void ClearGrinder()
	{
		tagMix = new AnomalyTag();
		ingredientSlot.ready = false;
		emptyBagSlot.ready = false;
	}

	private bool CheckReadyState()
	{
		if (ReadyForGrind())
		{
			remainingGrind = grindDuration;
			if (Vector3.Distance(loader.localPosition, loaderPoint2.localPosition) > 0f)
			{
				TweenerManager.Tween("GrindLoaderIn", loader, loaderPoint1, loaderPoint2, 0.7f, loaderCurve);
			}
			return true;
		}
		return false;
	}

	private bool CheckFillbag(ItemSocket characterSocket)
	{
		int num;
		if (characterSocket.GetItemComponent().item.id == fillBagSocket.onlyItem.id)
		{
			num = ((characterSocket.GetItemComponent().item.amount == 0) ? 1 : 0);
			if (num != 0)
			{
				fillBagSocket.PushItem(characterSocket.GetItemComponent());
				SoundManager.PlaySoundOnce(soundFillEmptyBag);
				TutorialManager.TryCheckSectionChecklistOption("CoffeeGrinder_FillBag", TutorialManager.TutorialState.MakeCoffee);
				emptyBagSlot.ready = true;
			}
		}
		else
		{
			num = 0;
		}
		return (byte)num != 0;
	}

	private bool CheckForIngredient(ItemSocket characterSocket)
	{
		if (ingredientSlot.ready)
		{
			return false;
		}
		if (characterSocket.GetItemComponent().item.amount <= 0)
		{
			return false;
		}
		bool num = characterSocket.GetItemComponent().GetInfo().name.Contains(ingredientSlot.ingredient);
		if (num)
		{
			ingredientSlot.ready = true;
			tagMix.anomalyFlags += characterSocket.GetItemComponent().item.tag.anomalyFlags;
			characterSocket.GetItemComponent().Consume();
			TutorialManager.TryCheckSectionChecklistOption("CoffeeGrinder_FillBeans", TutorialManager.TutorialState.MakeCoffee);
			PlayFillBeans();
		}
		return num;
	}

	private void PlayFillBeans()
	{
		int id = Guid.NewGuid().GetHashCode();
		Action action = delegate
		{
			TweenerManager.TweenRotation(id + "_open", transformBeanClap, transformBeanClap.localRotation, Quaternion.Euler(0f, 0f, 0f), 0.6f, TweenerManager.GetDefaultEaseCurve(), Space.Self);
		};
		TweenerManager.TweenTimeAction(id + "_FillCoffeeBeans", 1.5f, action);
		TweenerManager.TweenTimeAction(id + "_FillCoffeeBeans", 0.5f, delegate
		{
			psCoffeeBeans.Stop();
		});
		TweenerManager.TweenRotation(id + "_open", transformBeanClap, Quaternion.identity, Quaternion.Euler(-130f, 0f, 0f), 0.6f, TweenerManager.GetDefaultEaseCurve(), Space.Self);
		psCoffeeBeans.Play();
	}
}
