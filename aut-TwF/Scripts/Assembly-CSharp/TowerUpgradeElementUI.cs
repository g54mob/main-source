using System;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class TowerUpgradeElementUI : UIListElement
{
	public Action<GameplayObjectData> onBuyUpgradePressed;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Image lockImage;

	[SerializeField]
	private Image frame;

	[SerializeField]
	private Image selectedFrame;

	[SerializeField]
	private Color disabledColor = Color.gray;

	[SerializeField]
	private Color cannotUpgradeColor = Color.red;

	[SerializeField]
	private AudioClip lockedAudioClip;

	private Color defaultFrameColor;

	private ButtonAnimation buttonAnimation;

	private AudioClip defaultAudioClip;

	public GameplayObjectData TowerData { get; private set; }

	public Tower Tower { get; set; }

	private void Update()
	{
		if ((bool)buttonAnimation)
		{
			UpdateFrameColor();
		}
	}

	private void UpdateFrameColor()
	{
		if ((base.Data as PlayerData.PlayerBuilding).IsUnlocked)
		{
			if (!Tower.IsFullExperience() || !LTFunctionLibrary.GetLTGameManager().CanAfford(TowerData.Cost))
			{
				frame.color = cannotUpgradeColor;
				buttonAnimation.OnClickSound = null;
			}
			else
			{
				frame.color = defaultFrameColor;
				buttonAnimation.OnClickSound = defaultAudioClip;
			}
		}
	}

	public void BuyUpgrade()
	{
		if (!((PlayerData.PlayerBuilding)base.Data).IsUnlocked)
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_towerUpgradeLocked", null, FallbackBehavior.UseProjectSettings);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
		}
		else if (!Tower.IsFullExperience())
		{
			string localizedString2 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_towerNotEnoughtExp", null, FallbackBehavior.UseProjectSettings);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString2, ENotificationType.Error, 0.75f);
		}
		else if (!LTFunctionLibrary.GetLTGameManager().CanAfford(TowerData.Cost))
		{
			string localizedString3 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantAfford", null, FallbackBehavior.UseProjectSettings);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString3, ENotificationType.Error, 0.75f);
		}
		else
		{
			onBuyUpgradePressed?.Invoke(((PlayerData.PlayerBuilding)base.Data).BuildingData);
		}
	}

	public void SetSelected(bool selected)
	{
		selectedFrame.gameObject.SetActive(selected);
		image.color = Color.white;
	}

	public void SetEnabled(bool enabled)
	{
		if ((base.Data as PlayerData.PlayerBuilding).IsUnlocked)
		{
			image.color = (enabled ? Color.white : disabledColor);
		}
		GetComponent<Button>().interactable = enabled;
		GetComponent<ButtonAnimation>().enabled = enabled;
	}

	public override void LoadData()
	{
		PlayerData.PlayerBuilding playerBuilding = (PlayerData.PlayerBuilding)base.Data;
		TowerData = playerBuilding.BuildingData;
		defaultFrameColor = frame.color;
		buttonAnimation = GetComponent<ButtonAnimation>();
		defaultAudioClip = buttonAnimation?.OnClickSound;
		if (playerBuilding.IsUnlocked)
		{
			image.sprite = playerBuilding.BuildingData.Image;
			image.color = Color.white;
			lockImage.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(GetComponent<TooltipComponent_text>());
			return;
		}
		image.sprite = null;
		lockImage.gameObject.SetActive(value: true);
		UnityEngine.Object.Destroy(GetComponent<TooltipComponent_towerUpgrade>());
		if ((bool)buttonAnimation)
		{
			buttonAnimation.OnClickSound = null;
		}
	}
}
