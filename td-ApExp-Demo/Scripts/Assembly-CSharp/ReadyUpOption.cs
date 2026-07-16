using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public abstract class ReadyUpOption : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[SerializeField]
	protected bool isTopCard;

	[SerializeField]
	protected AudioClip cardBurnClip;

	protected Animator anim;

	protected bool bought;

	protected ReadyUpWindow readyUpWindow;

	[field: SerializeField]
	public float CoresPrice { get; protected set; }

	[field: SerializeField]
	public float Value { get; protected set; }

	[field: SerializeField]
	protected Button Button { get; set; }

	[field: SerializeField]
	protected Image Outline { get; set; }

	[field: SerializeField]
	protected ReadyUpOption NextCard { get; set; }

	[field: SerializeField]
	protected LocalizedString LocalizationString { get; set; }

	[field: SerializeField]
	protected LocalizedString CostLocalizationString { get; set; }

	[field: SerializeField]
	protected TextMeshProUGUI DescriptionTxt { get; set; }

	[field: SerializeField]
	protected TextMeshProUGUI PriceTxt { get; set; }

	protected void Awake()
	{
		anim = GetComponent<Animator>();
		if (!isTopCard)
		{
			Button.interactable = false;
		}
		readyUpWindow = MenuManager.Instance.GetMenu(MenuType.ReadyUp).gameObject.GetComponent<ReadyUpWindow>();
		CostLocalizationString.Arguments = new object[1] { CoresPrice };
		PriceTxt.text = CoresPrice + " " + CostLocalizationString.GetLocalizedString();
	}

	public void PlayFlipSFX()
	{
		GetComponent<UnitAudioController>().PlayOnChannel(0);
	}

	public virtual void OnClick()
	{
		if (ResourceManager.Instance.Cores.TrySpend(CoresPrice))
		{
			bought = true;
			anim.Play("ReadyUpCardFlip");
			Button.interactable = false;
			Object.Destroy(Outline.gameObject);
		}
	}

	protected virtual void OnEnable()
	{
		if (bought)
		{
			anim.Play("ReadyUpCardFlip");
		}
	}

	public abstract void ApplyOption();

	public virtual void CardBurned()
	{
		ApplyOption();
		ActivateNextCard();
	}

	public virtual void PlayBurnSFX()
	{
		AudioManager.Instance.SfxHelper.PlaySoundEffect(cardBurnClip, 1f, Random.Range(0.9f, 1.1f));
	}

	protected void ActivateNextCard()
	{
		if ((bool)NextCard)
		{
			NextCard.Button.interactable = true;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!Button.interactable)
		{
			return;
		}
		readyUpWindow.unitAudioController.PlayOnChannel(Random.Range(0, 2));
		if ((bool)Outline)
		{
			Outline.enabled = true;
			if (CoresPrice > ResourceManager.Instance.Cores.Value)
			{
				Outline.color = Color.red;
			}
			else
			{
				Outline.color = Color.white;
			}
		}
		if (!bought)
		{
			anim.Play("ReadyUpCardOnSelect");
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (Button.interactable)
		{
			if ((bool)Outline)
			{
				Outline.enabled = false;
			}
			if (!bought)
			{
				anim.Play("ReadyUpCardOnDeselect");
			}
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (!Button.interactable)
		{
			return;
		}
		readyUpWindow.unitAudioController.PlayOnChannel(Random.Range(0, 2));
		if ((bool)Outline)
		{
			Outline.enabled = true;
			if (CoresPrice > ResourceManager.Instance.Cores.Value)
			{
				Outline.color = Color.red;
			}
			else
			{
				Outline.color = Color.white;
			}
		}
		if (!bought)
		{
			anim.Play("ReadyUpCardOnSelect");
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		if (Button.interactable)
		{
			if ((bool)Outline)
			{
				Outline.enabled = false;
			}
			if (!bought)
			{
				anim.Play("ReadyUpCardOnDeselect");
			}
		}
	}
}
