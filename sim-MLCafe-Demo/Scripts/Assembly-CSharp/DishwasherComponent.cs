using System;
using System.Linq;
using MLCN_Localization;
using UnityEngine;

public class DishwasherComponent : MonoBehaviour, IInteraction
{
	public enum DishwasherType
	{
		Manual = 0,
		Automatic = 1
	}

	[SerializeField]
	private ItemSocket[] sockets;

	[SerializeField]
	private DishwasherType dishwasherType;

	[SerializeField]
	private Item kettle;

	private bool kettleRefill;

	private bool ready;

	private bool isProcessing;

	private bool takeOut;

	[SerializeField]
	private float processingDuration;

	private float remainingTime;

	[SerializeField]
	private GameObject fxWaterStream;

	[SerializeField]
	private GameObject fxSteam;

	[SerializeField]
	private ParticleSystem[] vfxs;

	[SerializeField]
	private SkinnedMeshRenderer skinnedMeshRenderer;

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyCantUseThis;

	[SerializeField]
	private string localizationKeyIsFull;

	[SerializeField]
	private string localizationKeyIsNotEmpty;

	[SerializeField]
	private string localizationKeyIsClean;

	[Header("Sound")]
	[SerializeField]
	private string soundOnWashing;

	[SerializeField]
	private string soundKettleFilling;

	[SerializeField]
	private string soundOnEmptyCoffeeCup;

	[SerializeField]
	private string soundOnStartWashing;

	[SerializeField]
	private string soundOnEndWashing;

	[SerializeField]
	private AudioSource soundInstance;

	private ItemSocket GetFreeSocket()
	{
		return sockets.FirstOrDefault((ItemSocket x) => !x.IsHoldingItem());
	}

	private ItemSocket GetOccupiedSocket()
	{
		return sockets.FirstOrDefault((ItemSocket x) => x.IsHoldingItem());
	}

	private void Start()
	{
		SoundManager.SetupExistingAudioSource(soundOnWashing, soundInstance);
	}

	private void Update()
	{
		if (dishwasherType != DishwasherType.Manual && isProcessing)
		{
			if (remainingTime > 0f)
			{
				remainingTime -= Time.deltaTime;
				isProcessing = true;
				UpdateUIInfor();
			}
			else
			{
				isProcessing = false;
				FinishWashingAutomatic();
			}
		}
	}

	void IInteraction.OnPlayerInteraction(CharacterControllerComponent character)
	{
		if (dishwasherType != DishwasherType.Manual)
		{
			if (takeOut)
			{
				TakeOut(character);
			}
			else if (sockets.Any((ItemSocket x) => x.IsHoldingItem() && !x.GetItemComponent().GetComponent<CupComponent>().IsDirty()))
			{
				TakeOut(character);
			}
			else if (CheckSocket(character) && ready && !character.socket.IsHoldingItem())
			{
				StartAutomaticWashing();
			}
		}
	}

	private bool CheckSocket(CharacterControllerComponent character)
	{
		if (!character.socket.IsHoldingItem())
		{
			if (ready)
			{
				return true;
			}
			return false;
		}
		if (dishwasherType == DishwasherType.Manual)
		{
			return CheckSocketManual(character);
		}
		if (dishwasherType == DishwasherType.Automatic)
		{
			return CheckSocketAutomatic(character);
		}
		return false;
	}

	void IInteraction.OnPlayerAction(CharacterControllerComponent character)
	{
		GetComponent<RemovableInstance>().OnPlayerAction(character);
	}

	void IInteraction.OnPlayerHoldInteraction(CharacterControllerComponent character)
	{
		if (dishwasherType == DishwasherType.Automatic || !CheckSocket(character) || !ready)
		{
			return;
		}
		if (kettleRefill)
		{
			if (!RefillKettle())
			{
				FinishRefill(character);
			}
		}
		else
		{
			WashDishesManual(character);
		}
	}

	void IInteraction.OnPlayerHoldInteractionStopped(CharacterControllerComponent character)
	{
		if (dishwasherType != DishwasherType.Automatic)
		{
			isProcessing = false;
			HideVFX();
			ProgressbarManager.GetCleaningProgressBar().HideProgressbar();
			ProgressbarManager.GetWaterFillProgressBar().HideProgressbar();
			if (soundInstance.isPlaying)
			{
				soundInstance.Stop();
			}
		}
	}

	private bool CheckSocketManual(CharacterControllerComponent character)
	{
		if (character.socket.GetItemComponent().GetInfo().itemType != ItemInfo.ItemType.Dish)
		{
			if (CheckForKettle(character))
			{
				return true;
			}
			return false;
		}
		if (character.socket.GetComponent<KettleComponent>() != null)
		{
			character.socket.GetComponent<ProductComponent>().ClearProduct();
			return false;
		}
		if (CheckFullCup(character))
		{
			return true;
		}
		if (CheckDishLoadManual(character))
		{
			return true;
		}
		return false;
	}

	private bool CheckForKettle(CharacterControllerComponent character)
	{
		if (character.socket.GetItemComponent().item.id != kettle.id)
		{
			kettleRefill = false;
			ready = false;
			return false;
		}
		if (character.socket.GetItemComponent().item.amount == character.socket.GetItemComponent().item.maxAmount)
		{
			return false;
		}
		sockets[0].PushItem(character.socket.GetItemComponent());
		remainingTime = processingDuration;
		kettleRefill = true;
		ready = true;
		return true;
	}

	private bool CheckDishLoadManual(CharacterControllerComponent character)
	{
		if (!character.socket.GetItemComponent().GetComponent<CupComponent>().IsUseable())
		{
			character.socket.GetItemComponent().DeactivateCollision();
			character.socket.GetItemComponent().GetComponent<InteractionDisplayComponent>().enabled = false;
			PushDirtyDish(character.socket.GetItemComponent());
			ready = true;
			remainingTime = processingDuration;
			return true;
		}
		return false;
	}

	private bool CheckFullCup(CharacterControllerComponent character)
	{
		CupComponent component = character.socket.GetItemComponent().GetComponent<CupComponent>();
		if (component == null)
		{
			ProductComponent productComponent = character.socket.GetItemComponent().productComponent;
			if (productComponent == null)
			{
				return false;
			}
			productComponent.ClearProduct();
			character.socket.GetItemComponent().item.amount = 0;
			SoundManager.PlaySoundOnce(character.socket.GetItemComponent().soundOnFill);
			return true;
		}
		if (component.IsUseable() && component.GetComponent<ProductComponent>().IsHoldingProduct())
		{
			component.MarkDirty();
			return true;
		}
		return false;
	}

	private bool RefillKettle()
	{
		if (remainingTime > 0f)
		{
			remainingTime -= Time.deltaTime;
			if (!soundInstance.isPlaying)
			{
				soundInstance.clip = SoundManager.GetSoundContainer(soundKettleFilling).audioClip[0];
				soundInstance.Play();
			}
			isProcessing = true;
			ShowVFX(fxWaterStream);
			if (MouseCursorInteraction.IsLookingAtObject(base.gameObject))
			{
				if (ProgressbarManager.GetWaterFillProgressBar().IsVisible())
				{
					ProgressbarManager.GetWaterFillProgressBar().UpdateBar(Mathf.InverseLerp(processingDuration, 0f, remainingTime));
				}
				else
				{
					ProgressbarManager.GetWaterFillProgressBar().ShowProgressbar();
				}
				InteractionDisplayComponent component = GetComponent<InteractionDisplayComponent>();
				if (component != null)
				{
					component.UpdateDuration(remainingTime, processingDuration);
				}
			}
			return true;
		}
		return false;
	}

	private void FinishRefill(CharacterControllerComponent character)
	{
		if (remainingTime <= 0f)
		{
			isProcessing = false;
			ready = false;
			kettleRefill = false;
			remainingTime = processingDuration;
			ProgressbarManager.GetWaterFillProgressBar().HideProgressbar();
			HideVFX();
			sockets[0].GetItemComponent().RefillItem();
			character.socket.PushItem(sockets[0].GetItemComponent());
		}
	}

	private bool WashDishesManual(CharacterControllerComponent character)
	{
		if (remainingTime > 0f)
		{
			remainingTime -= Time.deltaTime;
			isProcessing = true;
			if (!soundInstance.isPlaying)
			{
				soundInstance.clip = SoundManager.GetSoundContainer(soundOnWashing).audioClip[0];
				soundInstance.Play();
			}
			ShowVFX();
			UpdateUIInfor();
			return true;
		}
		FinishWashingManual(character);
		return false;
	}

	private void FinishWashingManual(CharacterControllerComponent character)
	{
		if (remainingTime <= 0f)
		{
			isProcessing = false;
			ready = false;
			remainingTime = processingDuration;
			ProgressbarManager.GetCleaningProgressBar().HideProgressbar();
			HideVFX();
			WashAllValidSocketsManual();
			TakeoutWashedDishes(character);
			TutorialManager.TryCheckSectionChecklistOption("CupCleaning", TutorialManager.TutorialState.RunCafe);
		}
	}

	private void WashAllValidSocketsManual()
	{
		ItemSocket[] array = sockets;
		foreach (ItemSocket itemSocket in array)
		{
			if (itemSocket.IsHoldingItem())
			{
				itemSocket.GetItemComponent().GetComponent<CupComponent>().UnmarkDirty();
				itemSocket.GetItemComponent().ActivateCollision();
				itemSocket.GetItemComponent().GetComponent<InteractionDisplayComponent>().enabled = true;
				ProgressionManager.GainXP("CleanedDishes", 1);
			}
		}
	}

	private bool CheckSocketAutomatic(CharacterControllerComponent character)
	{
		if (character.socket.GetItemComponent().GetInfo().itemType != ItemInfo.ItemType.Dish)
		{
			return CheckForServiceTray(character);
		}
		if (CheckDishLoadAutomatic(character))
		{
			return true;
		}
		return false;
	}

	private bool CheckForServiceTray(CharacterControllerComponent character, bool isTakeout = false)
	{
		if (!character.socket.IsHoldingItem())
		{
			return false;
		}
		if (character.socket.GetItemComponent().item.id != InventorySystem.GetItemLibrary().GetItemByName("Serving Tray"))
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyCantUseThis);
			return false;
		}
		SocketPackage component = character.socket.GetItemComponent().GetComponent<SocketPackage>();
		if (isTakeout)
		{
			for (int i = 0; i < sockets.Length; i++)
			{
				ItemSocket occupiedSocket = GetOccupiedSocket();
				if (!(occupiedSocket == null))
				{
					ItemComponent itemComponent = occupiedSocket.GetItemComponent();
					if (!(itemComponent == null))
					{
						itemComponent.GetComponent<InteractionDisplayComponent>().enabled = false;
						component.TryPushToPackage(character, itemComponent);
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < component.GetSocketCount(); j++)
			{
				ItemComponent itemComponent2 = component.GetSocket(j).GetItemComponent();
				if (!(itemComponent2 == null) && itemComponent2.GetInfo().itemType == ItemInfo.ItemType.Dish)
				{
					itemComponent2.DeactivateCollision();
					itemComponent2.GetComponent<InteractionDisplayComponent>().enabled = false;
					PushDirtyDish(itemComponent2);
					ready = true;
					remainingTime = processingDuration;
				}
			}
		}
		return true;
	}

	private bool CheckDishLoadAutomatic(CharacterControllerComponent character)
	{
		CupComponent component = character.socket.GetItemComponent().GetComponent<CupComponent>();
		if (!component.IsUseable())
		{
			character.socket.GetItemComponent().DeactivateCollision();
			PushDirtyDish(character.socket.GetItemComponent());
			ready = true;
			remainingTime = processingDuration;
			return false;
		}
		if (component.IsUseable() && component.GetComponent<ProductComponent>().IsHoldingProduct())
		{
			string localizedMessage = PopupMessageManager.GetHighlightBegin() + character.socket.GetItemComponent().GetInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(localizationKeyIsNotEmpty, LocalizationDataTable.Tables.UI);
			PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
			return false;
		}
		if (component.IsUseable())
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyIsClean);
		}
		return false;
	}

	private void StartAutomaticWashing()
	{
		isProcessing = true;
		SoundManager.PlaySoundOnce(soundOnStartWashing);
		Action action = delegate
		{
			soundInstance.clip = SoundManager.GetSoundContainer(soundOnWashing).audioClip[0];
			soundInstance.Play();
		};
		TweenerManager.TweenBlendShape("dishwasher_closed", skinnedMeshRenderer, 0, 0f, 100f, 1f, TweenerManager.GetDefaultEaseCurve(), action);
		ShowVFX();
	}

	private void FinishWashingAutomatic()
	{
		isProcessing = false;
		ready = false;
		takeOut = true;
		ItemSocket[] array = sockets;
		foreach (ItemSocket itemSocket in array)
		{
			if (itemSocket.IsHoldingItem())
			{
				CupComponent component = itemSocket.GetItemComponent().GetComponent<CupComponent>();
				if (!(component == null))
				{
					component.UnmarkDirty();
				}
			}
		}
		soundInstance.Stop();
		HideVFX();
		SoundManager.PlaySoundOnce(soundOnEndWashing);
		TweenerManager.TweenBlendShape("dishwasher_closed", skinnedMeshRenderer, 0, 100f, 0f, 1f, TweenerManager.GetDefaultEaseCurve(), null);
	}

	private void TakeOut(CharacterControllerComponent character)
	{
		if (!CheckForServiceTray(character, isTakeout: true) && !character.socket.IsHoldingItem())
		{
			TakeoutWashedDishes(character);
		}
		if (!sockets.Any((ItemSocket x) => x.IsHoldingItem()))
		{
			takeOut = false;
		}
		else
		{
			takeOut = true;
		}
	}

	private void PushDirtyDish(ItemComponent dirtyDish)
	{
		ItemSocket freeSocket = GetFreeSocket();
		if (freeSocket == null)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyIsFull);
		}
		else
		{
			freeSocket.PushItem(dirtyDish);
		}
	}

	private void TakeoutWashedDishes(CharacterControllerComponent character)
	{
		ItemComponent itemComponent = sockets.First((ItemSocket x) => x.IsHoldingItem()).GetItemComponent();
		character.socket.PushItem(itemComponent);
	}

	public void LoadIntoDishwasher(ItemComponent item)
	{
		if (!(item.GetComponent<CupComponent>() == null))
		{
			ItemSocket freeSocket = GetFreeSocket();
			if (!(freeSocket == null))
			{
				freeSocket.SetItemToSocket(item);
			}
		}
	}

	private void UpdateUIInfor()
	{
		if (MouseCursorInteraction.IsLookingAtObject(base.gameObject))
		{
			if (ProgressbarManager.GetCleaningProgressBar().IsVisible())
			{
				ProgressbarManager.GetCleaningProgressBar().UpdateBar(Mathf.InverseLerp(processingDuration, 0f, remainingTime));
			}
			else
			{
				ProgressbarManager.GetCleaningProgressBar().ShowProgressbar();
			}
			InteractionDisplayComponent component = GetComponent<InteractionDisplayComponent>();
			if (component != null)
			{
				component.UpdateDuration(remainingTime, processingDuration);
			}
		}
	}

	private void ShowVFX(GameObject target = null)
	{
		if (target != null)
		{
			ParticleSystem particleSystem = vfxs.FirstOrDefault((ParticleSystem x) => x.gameObject == target);
			if (!(particleSystem == null) && !particleSystem.isPlaying)
			{
				particleSystem.Play();
			}
			return;
		}
		ParticleSystem[] array = vfxs;
		foreach (ParticleSystem particleSystem2 in array)
		{
			if (!particleSystem2.isPlaying)
			{
				particleSystem2.Play();
			}
		}
	}

	private void HideVFX()
	{
		ParticleSystem[] array = vfxs;
		foreach (ParticleSystem particleSystem in array)
		{
			if (particleSystem.isPlaying)
			{
				particleSystem.Stop();
			}
		}
	}
}
