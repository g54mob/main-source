using Coffee.UIExtensions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BiomeUnlockPanel : MenuPanel
{
	public TextMeshProUGUI biomeUnlockLabel;

	public TextMeshProUGUI biomeNameLabel;

	public UIParticle cloudParticles;

	public LabelButton actionButton;

	public Image biomeBackgroundImage;

	private float revealTimer;

	private float buttonRevealTimer;

	private BiomeType biomeType;

	public CustomAnimation textRevealAnimation;

	public UnityAction dismissDelegate;

	public override void Initialize()
	{
		base.Initialize();
		actionButton.AddPointerClickTrigger(OnActionButtonPressed);
		actionButton.buttonState = CustomButtonState.Default;
		textRevealAnimation = new CustomAnimation(0f, 1f, 0.5f, Ease.InQuad);
	}

	public override void Hide()
	{
		base.Hide();
		if (dismissDelegate != null)
		{
			dismissDelegate();
			dismissDelegate = null;
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (revealTimer > 0f)
		{
			revealTimer -= TimeManager.MenuDelta;
			if (revealTimer <= 0f)
			{
				OnRevealTimerElapsed();
			}
		}
		if (buttonRevealTimer > 0f)
		{
			buttonRevealTimer -= TimeManager.MenuDelta;
			if (buttonRevealTimer <= 0f)
			{
				actionButton.gameObject.SetActive(value: true);
			}
		}
		textRevealAnimation.UpdateAnimation();
		biomeUnlockLabel.maxVisibleCharacters = Mathf.CeilToInt(textRevealAnimation.EasedValue() * (float)biomeUnlockLabel.text.Length);
	}

	public void RevealBiome(BiomeType t)
	{
		Show();
		biomeType = t;
		cloudParticles.StartEmission();
		cloudParticles.Play();
		foreach (ParticleSystem particle in cloudParticles.particles)
		{
			particle.Simulate(1f);
		}
		SoundManager.PlayRewardGain();
		revealTimer = 0.1f;
		buttonRevealTimer = 1.5f;
		actionButton.gameObject.SetActive(value: false);
		biomeBackgroundImage.sprite = IconManager.MediumSpriteForBiome(t);
		biomeNameLabel.text = string.Empty;
		biomeBackgroundImage.enabled = false;
		biomeUnlockLabel.text = Strings.Def("New Biome Unlocked!", TextDisplay.FormattedKeyValue("MenuFunctionUnlock", "Biome".Localized()));
		textRevealAnimation.Run();
		biomeUnlockLabel.maxVisibleCharacters = 0;
	}

	public void OnBackgroundClick()
	{
		OnActionButtonPressed();
	}

	public void Debug()
	{
		RevealBiome(BiomeType.Forest);
	}

	private void OnRevealTimerElapsed()
	{
		revealTimer = 0f;
		biomeBackgroundImage.enabled = true;
		cloudParticles.StopEmission();
		biomeNameLabel.text = TextDisplay.LabelForBiome(biomeType);
	}

	private void OnActionButtonPressed()
	{
		if (buttonRevealTimer > 0f)
		{
			buttonRevealTimer = 0f;
			actionButton.gameObject.SetActive(value: true);
		}
		else
		{
			Hide();
		}
	}
}
