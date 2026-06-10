using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FishLogSpeciesEntry : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("TRAILER SETTINGS")]
	public bool trailerMode;

	[Header("UI References")]
	public Image icon;

	public Image borderImage;

	public Image crackerImage;

	public TMP_Text speciesNameText;

	public Button selectButton;

	public Image glowImage;

	[Header("Notifications")]
	public GameObject newIndicator;

	[Header("Visuals")]
	public Material silhouetteMaterial;

	public Sprite[] rarityBorders;

	public Color[] rarityColors;

	public Material[] RarityMaterials;

	[Header("Animations")]
	[SerializeField]
	private float hoverScale = 1.05f;

	[SerializeField]
	private float selectedScale = 1.1f;

	[SerializeField]
	private float animDuration = 0.15f;

	private Fish speciesData;

	private FishLogPanel parentPanel;

	public void Setup(Fish data, FishLogPanel panel)
	{
		speciesData = data;
		parentPanel = panel;
		if (glowImage != null)
		{
			glowImage.canvasRenderer.SetAlpha(0f);
			glowImage.color = new Color(glowImage.color.r, glowImage.color.g, glowImage.color.b, 0f);
		}
		base.transform.localScale = Vector3.one;
		if (data.availableRarities.Count > 0)
		{
			icon.sprite = data.availableRarities[0].artwork;
		}
		bool flag = FishLogManager.Instance.HasCaughtSpecies(data.speciesName);
		if (newIndicator != null)
		{
			bool flag2 = !trailerMode && FishLogManager.Instance.IsFishNew(data.speciesName);
			newIndicator.SetActive(flag && flag2);
		}
		if (flag)
		{
			speciesNameText.text = data.LocalizedName;
			icon.material = null;
			UpdateBorderVisuals();
		}
		else
		{
			speciesNameText.text = "?????";
			icon.material = silhouetteMaterial;
			if (data.isBossFish && data.bossBorderSprite != null)
			{
				borderImage.sprite = data.bossBorderSprite;
				borderImage.material = data.bossBorderMaterial;
				crackerImage.color = data.bossAccentColor;
			}
			else if (rarityBorders.Length != 0)
			{
				borderImage.material = RarityMaterials[0];
				borderImage.sprite = rarityBorders[0];
				crackerImage.color = rarityColors[0];
			}
		}
		if (trailerMode)
		{
			icon.material = silhouetteMaterial;
			speciesNameText.text = "?????";
			if (rarityBorders.Length != 0)
			{
				int num = UnityEngine.Random.Range(0, rarityBorders.Length);
				borderImage.sprite = rarityBorders[num];
				if (num < RarityMaterials.Length)
				{
					borderImage.material = RarityMaterials[num];
				}
				if (num < rarityColors.Length)
				{
					crackerImage.color = rarityColors[num];
				}
			}
		}
		selectButton.onClick.AddListener(OnClicked);
		FishLogPanel fishLogPanel = parentPanel;
		fishLogPanel.newFishSelected = (Action)Delegate.Combine(fishLogPanel.newFishSelected, new Action(NewFishSelectedInPanel));
		if (parentPanel.selectedFish == speciesData)
		{
			if (glowImage != null)
			{
				glowImage.color = new Color(glowImage.color.r, glowImage.color.g, glowImage.color.b, 1f);
			}
			base.transform.localScale = Vector3.one * selectedScale;
		}
		else
		{
			if (glowImage != null)
			{
				glowImage.color = new Color(glowImage.color.r, glowImage.color.g, glowImage.color.b, 0f);
			}
			base.transform.localScale = Vector3.one;
		}
	}

	public void HideNewIndicator(bool animate, Action onComplete = null)
	{
		if (newIndicator == null || !newIndicator.activeSelf)
		{
			onComplete?.Invoke();
		}
		else if (animate)
		{
			newIndicator.transform.DOKill();
			newIndicator.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
			{
				newIndicator.SetActive(value: false);
				onComplete?.Invoke();
			});
		}
		else
		{
			newIndicator.transform.DOKill();
			newIndicator.SetActive(value: false);
			onComplete?.Invoke();
		}
	}

	private void UpdateBorderVisuals()
	{
		if (speciesData.isBossFish && speciesData.bossBorderSprite != null)
		{
			borderImage.sprite = speciesData.bossBorderSprite;
			borderImage.material = speciesData.bossBorderMaterial;
			crackerImage.color = speciesData.bossAccentColor;
			return;
		}
		int num = 0;
		foreach (RarityData availableRarity in speciesData.availableRarities)
		{
			if (FishLogManager.Instance.GetCatchCount(speciesData.speciesName, availableRarity.rarity.ToString()) > 0)
			{
				int rarity = (int)availableRarity.rarity;
				if (rarity > num)
				{
					num = rarity;
				}
			}
		}
		int num2 = Mathf.Clamp(num, 0, rarityBorders.Length - 1);
		borderImage.sprite = rarityBorders[num2];
		borderImage.material = RarityMaterials[num2];
		crackerImage.color = rarityColors[num2];
	}

	private void NewFishSelectedInPanel()
	{
		base.transform.DOKill();
		if (glowImage != null)
		{
			glowImage.DOKill();
		}
		if (parentPanel.selectedFish == speciesData)
		{
			if (glowImage != null && glowImage.color.a < 0.99f)
			{
				glowImage.DOFade(1f, animDuration);
			}
			if (base.transform.localScale.x < selectedScale - 0.01f)
			{
				base.transform.DOScale(selectedScale, animDuration).SetEase(Ease.OutBack);
			}
		}
		else
		{
			if (glowImage != null && glowImage.color.a > 0.01f)
			{
				glowImage.DOFade(0f, animDuration);
			}
			if (base.transform.localScale.x > 1.01f)
			{
				base.transform.DOScale(1f, animDuration);
			}
		}
	}

	private void OnDestroy()
	{
		if (selectButton != null)
		{
			selectButton.onClick.RemoveListener(OnClicked);
		}
		if (parentPanel != null)
		{
			FishLogPanel fishLogPanel = parentPanel;
			fishLogPanel.newFishSelected = (Action)Delegate.Remove(fishLogPanel.newFishSelected, new Action(NewFishSelectedInPanel));
		}
		base.transform.DOKill();
		if (glowImage != null)
		{
			glowImage.DOKill();
		}
	}

	private void OnClicked()
	{
		if (FishLogManager.Instance.IsFishNew(speciesData.speciesName))
		{
			FishLogManager.Instance.MarkFishAsSeen(speciesData.speciesName, notify: false);
			HideNewIndicator(animate: true, delegate
			{
				FishLogManager.Instance.RefreshLogEvents();
			});
		}
		parentPanel.OnSpeciesSelected(speciesData);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (parentPanel.selectedFish != speciesData)
		{
			glowImage.DOFade(0.5f, animDuration);
			base.transform.DOScale(hoverScale, animDuration).SetEase(Ease.OutBack);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (parentPanel.selectedFish != speciesData)
		{
			glowImage.DOFade(0f, animDuration);
			base.transform.DOScale(1f, animDuration);
		}
	}
}
