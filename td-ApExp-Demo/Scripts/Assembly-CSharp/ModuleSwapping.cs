using System;
using System.Collections;
using System.Collections.Generic;
using AudioSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ModuleSwapping : Menu
{
	private enum Interaction
	{
		Block = 0,
		Take = 1,
		Drop = 2,
		Swap = 3
	}

	[Header("Module")]
	[SerializeField]
	private float camMoveToModuleTime = 0.1f;

	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private Image clawImage;

	[SerializeField]
	private Sprite clawClosed;

	[SerializeField]
	private Sprite clawOpened;

	[SerializeField]
	private Image arrowsImage;

	[SerializeField]
	private TextMeshProUGUI interactionTxt;

	[SerializeField]
	private Sprite block;

	[SerializeField]
	private Sprite take;

	[SerializeField]
	private Sprite drop;

	[SerializeField]
	private Sprite swap;

	[SerializeField]
	private LocalizedString blockTxt;

	[SerializeField]
	private LocalizedString takeTxt;

	[SerializeField]
	private LocalizedString dropTxt;

	[SerializeField]
	private LocalizedString swapTxt;

	private ModuleSlot[] moduleSlots;

	private int slotIndex;

	[Header("SFX")]
	[SerializeField]
	private SoundData pickUpSfx;

	[SerializeField]
	private SoundData dropSfx;

	private SoundBuilder soundBuilder;

	[Header("Other")]
	[SerializeField]
	private Image backgroundToFade;

	[SerializeField]
	[Range(0f, 1f)]
	private float startAlpha;

	[SerializeField]
	[Range(0f, 1f)]
	private float endAlpha = 0.75f;

	[SerializeField]
	private GameObject aGo;

	[SerializeField]
	private GameObject dGo;

	[SerializeField]
	private GameObject ltGo;

	[SerializeField]
	private GameObject rtGo;

	[SerializeField]
	private Image moduleSelectorImg;

	[SerializeField]
	private Sprite moduleSelectorStop;

	[SerializeField]
	private Sprite moduleSelectorMoving;

	[SerializeField]
	private AudioSource moduleSelectionAudioSource;

	private const float stickDeadZone = 0.2f;

	private bool stickReleased = true;

	private Module selectedModule;

	private Interaction currentInteraction;

	public override void Init()
	{
		InputManager.Instance.OnLT += delegate
		{
			TryNavigateSlots(Dir.Left);
		};
		InputManager.Instance.OnRT += delegate
		{
			TryNavigateSlots(Dir.Right);
		};
		InputManager.Instance.OnAPressed += delegate
		{
			InteractWithModule();
		};
		InputManager.Instance.OnXPressed += delegate
		{
			HandleModuleSwappingInput();
		};
	}

	private void Update()
	{
		if (!GameManager.Instance.IsJourneyStarted || !base.gameObject.activeSelf)
		{
			return;
		}
		Vector2 move = InputManager.Instance.GetAnyIdentifiedMoveInput().Move;
		if (move.magnitude < 0.2f)
		{
			stickReleased = true;
		}
		else if (stickReleased)
		{
			stickReleased = false;
			if (move.x < -0.2f)
			{
				TryNavigateSlots(Dir.Left);
			}
			else if (move.x > 0.2f)
			{
				TryNavigateSlots(Dir.Right);
			}
		}
	}

	protected override void OnOpen()
	{
		List<ModuleSlot> allModuleSlots = Train.Instance.GetAllModuleSlots();
		if (soundBuilder == null)
		{
			soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
		}
		moduleSlots = allModuleSlots.ToArray();
		SetSlot(moduleSlots[slotIndex]);
		moduleSelectorImg.sprite = moduleSelectorStop;
		Color c = backgroundToFade.color;
		backgroundToFade.color = new Color(c.r, c.g, c.b, 0f);
		GetComponent<AudioSource>().Play();
		LeanTween.value(backgroundToFade.gameObject, startAlpha, endAlpha, 0.5f).setIgnoreTimeScale(useUnScaledTime: true).setOnUpdate(delegate(float alpha)
		{
			backgroundToFade.color = new Color(c.r, c.g, c.b, alpha);
		});
		if (InputManager.Instance.IsLastInputGamepad)
		{
			aGo.SetActive(value: false);
			dGo.SetActive(value: false);
			rtGo.SetActive(value: true);
			ltGo.SetActive(value: true);
		}
		else
		{
			aGo.SetActive(value: true);
			dGo.SetActive(value: true);
			rtGo.SetActive(value: false);
			ltGo.SetActive(value: false);
		}
	}

	protected override void OnClose()
	{
		if (!selectedModule)
		{
			return;
		}
		foreach (SpriteRenderer moduleSr in selectedModule.ModuleSlot.Module.moduleSrs)
		{
			moduleSr.enabled = true;
		}
	}

	private void TryNavigateSlots(Dir dir)
	{
		if (base.gameObject.activeSelf)
		{
			int num = ((dir != Dir.Right) ? 1 : (-1));
			int num2 = slotIndex;
			int num3 = moduleSlots.Length;
			do
			{
				slotIndex = (slotIndex + num + num3) % num3;
			}
			while (moduleSlots[slotIndex] == null && slotIndex != num2);
			if (moduleSlots[slotIndex] != null)
			{
				SetSlot(moduleSlots[slotIndex]);
			}
		}
	}

	private void SetSlot(ModuleSlot slot)
	{
		LeanTween.cancel(CameraController.Instance.gameObject);
		LeanTween.move(CameraController.Instance.gameObject, slot.transform.position, camMoveToModuleTime).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(useUnScaledTime: true)
			.setOnStart(delegate
			{
				moduleSelectorImg.sprite = moduleSelectorMoving;
			})
			.setOnComplete((Action)delegate
			{
				moduleSelectorImg.sprite = moduleSelectorStop;
			});
		moduleSelectionAudioSource.Play();
		UpdateInteraction(slot);
		UpdateArrows();
	}

	private void UpdateInteraction(ModuleSlot slot)
	{
		if (slot.Module == Train.Instance.DirectionLever || slot.Module == Train.Instance.furnace || slot == Train.Instance.GetCannonModuleSlot() || slot == Train.Instance.GetClawModuleSlot())
		{
			currentInteraction = Interaction.Block;
		}
		else if (selectedModule == null)
		{
			if (slot.Module == null)
			{
				currentInteraction = Interaction.Block;
			}
			else if (slot.Module != null)
			{
				currentInteraction = Interaction.Take;
			}
		}
		else if (selectedModule != null)
		{
			if (slot.Module == null || slot == selectedModule.ModuleSlot)
			{
				currentInteraction = Interaction.Drop;
			}
			else if (slot.Module != null)
			{
				currentInteraction = Interaction.Swap;
			}
		}
	}

	private void UpdateArrows()
	{
		switch (currentInteraction)
		{
		case Interaction.Block:
			arrowsImage.sprite = block;
			interactionTxt.text = blockTxt.GetLocalizedString();
			break;
		case Interaction.Take:
			arrowsImage.sprite = take;
			interactionTxt.text = takeTxt.GetLocalizedString();
			break;
		case Interaction.Drop:
			arrowsImage.sprite = drop;
			interactionTxt.text = dropTxt.GetLocalizedString();
			break;
		case Interaction.Swap:
			arrowsImage.sprite = swap;
			interactionTxt.text = swapTxt.GetLocalizedString();
			break;
		}
		if (selectedModule == null)
		{
			iconImage.gameObject.SetActive(value: false);
			clawImage.sprite = clawClosed;
		}
		else
		{
			iconImage.gameObject.SetActive(value: true);
			clawImage.sprite = clawOpened;
		}
	}

	private void InteractWithModule()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		Menu currentMenu = MenuManager.Instance.CurrentMenu;
		if ((object)currentMenu == null || currentMenu.MenuType != MenuType.ModuleSwapping)
		{
			return;
		}
		switch (currentInteraction)
		{
		case Interaction.Take:
			foreach (SpriteRenderer moduleSr in moduleSlots[slotIndex].Module.moduleSrs)
			{
				moduleSr.enabled = false;
			}
			selectedModule = moduleSlots[slotIndex].Module;
			iconImage.sprite = selectedModule.Enhancement.Icon;
			soundBuilder.Play(pickUpSfx);
			break;
		case Interaction.Drop:
			if (selectedModule != moduleSlots[slotIndex].Module)
			{
				selectedModule.ModuleSlot.TransferModule(moduleSlots[slotIndex]);
			}
			foreach (SpriteRenderer moduleSr2 in selectedModule.ModuleSlot.Module.moduleSrs)
			{
				moduleSr2.enabled = true;
			}
			selectedModule = null;
			iconImage.sprite = null;
			soundBuilder.Play(dropSfx);
			break;
		case Interaction.Swap:
			if (selectedModule != moduleSlots[slotIndex].Module)
			{
				selectedModule.ModuleSlot.SwapModules(moduleSlots[slotIndex]);
			}
			foreach (SpriteRenderer moduleSr3 in selectedModule.ModuleSlot.Module.moduleSrs)
			{
				moduleSr3.enabled = true;
			}
			selectedModule = null;
			iconImage.sprite = null;
			StartCoroutine(DropWithDelay());
			break;
		}
		UpdateInteraction(moduleSlots[slotIndex]);
		UpdateArrows();
	}

	private IEnumerator DropWithDelay()
	{
		soundBuilder.Play(dropSfx);
		yield return new WaitForSecondsRealtime(0.2f);
		soundBuilder.Play(dropSfx);
	}

	public void HandleModuleSwappingInput()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		Level? currentLevel = LevelManager.Instance.CurrentLevel;
		if (currentLevel != null && currentLevel.LevelType == LevelType.Hub && ZoneManager.Instance.CurrentZoneIndex >= 2)
		{
			Menu currentMenu = MenuManager.Instance.CurrentMenu;
			if ((object)currentMenu != null && currentMenu.MenuType == MenuType.ModuleSwapping)
			{
				MenuManager.Instance.CloseCurrentMenu();
				return;
			}
			MenuManager.Instance.CloseAllMenus();
			MenuManager.Instance.OpenMenu(MenuType.ModuleSwapping);
		}
	}

	private void OnDestroy()
	{
	}
}
