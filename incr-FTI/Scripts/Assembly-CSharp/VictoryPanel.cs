using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MenuPanel
{
	public TextMeshProUGUI victoryText;

	public LabelButton confirmButton;

	public Image crownImage;

	public float timer;

	public CanvasGroup footerCanvasGroup;

	private Tween scaleInTween;

	private Tween buttonFadeInTween;

	public override void Initialize()
	{
		base.Initialize();
		confirmButton.AddPointerClickTrigger(OnConfirmPressed);
	}

	public override void Show()
	{
		base.Show();
		timer = 0f;
		ReloadLabels();
		SoundManager.PlayVictory();
		confirmButton.gameObject.SetActive(value: false);
		footerCanvasGroup.alpha = 0f;
		buttonFadeInTween?.Kill(complete: true);
		UpdateDynamicDisplay();
		MenuPanel.gm.recentQuestRewards.RemoveAll(ItemType.UtilityVictory);
		StartupManager.Instance.renderTextureParticlesCamera.gameObject.SetActive(value: true);
		victoryText.transform.localScale = new Vector3(2f, 2f, 2f);
		scaleInTween?.Kill(complete: true);
		scaleInTween = victoryText.transform.DOScale(Vector3.one, 2f);
	}

	public override void Hide()
	{
		bool num = IsVisible();
		base.Hide();
		StartupManager.Instance.renderTextureParticlesCamera.gameObject.SetActive(value: false);
		MenuPanel.gm.recentQuestRewards.RemoveAll(ItemType.UtilityVictory);
		if (num)
		{
			MenuPanel.gm.EndTrackingUnlocks();
		}
	}

	protected override void Update()
	{
		timer += TimeManager.MenuDelta;
		base.Update();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		victoryText.text = "Victory".Localized();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		float a = Mathf.InverseLerp(0f, 3f, timer);
		float a2 = Mathf.InverseLerp(2f, 5f, timer);
		crownImage.color = new Color(1f, 1f, 1f, a2);
		victoryText.color = new Color(1f, 1f, 1f, a);
		if (!confirmButton.gameObject.activeInHierarchy && timer > 8f)
		{
			confirmButton.gameObject.SetActive(value: true);
			confirmButton.buttonState = CustomButtonState.BlueFlashing;
			buttonFadeInTween = footerCanvasGroup.DOFade(1f, 2f);
		}
		crownImage.rectTransform.SetPosY(112f + Mathf.Sin(timer) * 5f);
	}

	private void OnConfirmPressed()
	{
		Hide();
	}
}
