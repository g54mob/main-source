using System;
using UnityEngine;
using UnityEngine.Localization;

public class BrokenHubStation : MonoBehaviour
{
	protected Interactable interactable;

	protected AudioSource audioSource;

	public bool isFixed;

	public int coresRequired;

	[SerializeField]
	protected SpriteRenderer sr;

	[SerializeField]
	protected Sprite fixedSprite;

	[SerializeField]
	protected Sprite Icon;

	[SerializeField]
	protected bool canBeBought;

	[SerializeField]
	protected bool isInDemo;

	[SerializeField]
	public bool isStartingStation;

	[SerializeField]
	protected MenuType menuToOpen;

	[SerializeField]
	protected AudioClip stationFixSound;

	[SerializeField]
	protected LevelDialogueSO dialogue;

	[SerializeField]
	protected NPCDialogue bobbyGuide;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString stationName;

	[SerializeField]
	protected LocalizedString useStationLocalizedKey;

	[SerializeField]
	protected LocalizedString fixStationLocalizedKey;

	public event Action<PlayerController> onFix;

	protected void Awake()
	{
		interactable = GetComponent<Interactable>();
		audioSource = GetComponent<AudioSource>();
		Interactable obj = interactable;
		obj.CanInteract = (Func<bool>)Delegate.Combine(obj.CanInteract, new Func<bool>(CanInteract));
		interactable.OnInteractStart += UseStation;
	}

	protected void Start()
	{
		CheckIfStationIsFixed();
	}

	public virtual void UnlockStation()
	{
		if (!GameManager.Instance.isDemo)
		{
			canBeBought = true;
			if (!isFixed)
			{
				MenuManager.Instance.GetMenu(MenuType.GameOver).gameObject.GetComponent<PostcardMenu>().AddNewUnlock(Icon, "NEW STATION", stationName.GetLocalizedString(), Rarity.Legendary);
			}
		}
	}

	public virtual void Fix(PlayerController player, bool withSfx, bool isNewUnlock = true)
	{
		if (!isFixed)
		{
			this.onFix?.Invoke(player);
			if (withSfx && stationFixSound != null)
			{
				audioSource.PlayOneShot(stationFixSound);
			}
			SetupFixedStation();
			if (dialogue != null)
			{
				DialogueManager.Instance.StartDialogue(dialogue);
			}
		}
	}

	protected virtual void CheckIfStationIsFixed()
	{
		if (isFixed)
		{
			SetupFixedStation();
		}
		else
		{
			SetupBrokenStation();
		}
	}

	protected virtual void SetupFixedStation()
	{
		sr.sprite = fixedSprite;
		interactable.actionNameLocalized = useStationLocalizedKey;
		isFixed = true;
		if ((bool)bobbyGuide)
		{
			bobbyGuide.blockInteract = true;
		}
		base.gameObject.GetComponent<Outline>().Animate(play: false);
	}

	protected virtual void SetupBrokenStation()
	{
		interactable.actionNameLocalized = fixStationLocalizedKey;
		if (canBeBought && menuToOpen != MenuType.Radar && menuToOpen != MenuType.ReadyUp)
		{
			base.gameObject.GetComponent<Outline>().Animate(play: true);
		}
	}

	protected virtual bool CanInteract()
	{
		if (GameManager.Instance.isDemo)
		{
			return true;
		}
		if (!isStartingStation && !canBeBought && !isFixed)
		{
			return false;
		}
		return true;
	}

	protected virtual void UseStation(Interactor interactor)
	{
		if (!isInDemo && GameManager.Instance.isDemo)
		{
			return;
		}
		if (!isStartingStation && canBeBought && !isFixed)
		{
			if (ResourceManager.Instance.Cores.Value < (float)coresRequired)
			{
				Debug.Log("You will need " + coresRequired + " cores to fix this");
				return;
			}
			if (!(this is FixRadar))
			{
				ResourceManager.Instance.Cores.TrySpend(coresRequired);
			}
			Fix(interactor.playerController, withSfx: false);
		}
		else
		{
			OnUse();
		}
	}

	protected virtual void OnUse()
	{
		audioSource.Play();
		MenuManager.Instance.OpenMenu(menuToOpen);
	}
}
