using System;
using AudioSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorldMapZone : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator chainsAnimator;

	[SerializeField]
	private SoundData unlockSound;

	[Header("Sprites")]
	[SerializeField]
	private Sprite zoneUndiscoveredSprite;

	[SerializeField]
	private Sprite zoneDiscoveredSprite;

	[SerializeField]
	private Sprite zoneBorder;

	[Header("Hover Elements")]
	[SerializeField]
	private GameObject outline;

	[SerializeField]
	private GameObject glow;

	[NonSerialized]
	public bool isDiscovered;

	[NonSerialized]
	public bool isUnlocked;

	[NonSerialized]
	public bool readyToUnlock;

	[field: SerializeField]
	public ZoneDefinition Zone { get; private set; }

	[field: SerializeField]
	public Image Background { get; private set; }

	[field: SerializeField]
	public Image Border { get; private set; }

	[field: SerializeField]
	public Image Chains { get; private set; }

	private void OnEnable()
	{
		if (readyToUnlock)
		{
			PrepareZoneForUnlock();
		}
		else if (isDiscovered)
		{
			DiscoverZone();
		}
		else if (isUnlocked)
		{
			Unlock();
		}
		outline.SetActive(value: false);
		glow.SetActive(value: false);
	}

	public void DiscoverZone()
	{
		Background.sprite = zoneDiscoveredSprite;
		Border.sprite = zoneBorder;
		isDiscovered = true;
		isUnlocked = true;
		readyToUnlock = false;
		Chains.gameObject.SetActive(value: false);
	}

	private void PrepareZoneForUnlock()
	{
		isUnlocked = true;
		readyToUnlock = false;
		PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder().Play(unlockSound);
		chainsAnimator.Play("WorldMapZoneLockBreak");
	}

	public void Unlock()
	{
		if (!isDiscovered)
		{
			Background.sprite = zoneUndiscoveredSprite;
			Chains.gameObject.SetActive(value: false);
			isUnlocked = true;
			readyToUnlock = false;
			WorldMap.Instance.SetUnlockAsLast();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		outline.SetActive(value: true);
		glow.SetActive(value: true);
		if ((bool)Zone)
		{
			if (isUnlocked)
			{
				WorldMap.Instance.SetHeader(Zone.DisplayName);
			}
			else
			{
				WorldMap.Instance.SetHeader("???");
			}
		}
		else
		{
			WorldMap.Instance.SetHeader("Currently Unavailable");
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		outline.SetActive(value: false);
		glow.SetActive(value: false);
		WorldMap.Instance.SetHeader("World Map");
	}

	public void AddToNewUnlocks()
	{
		if (!GameManager.Instance.isDemo)
		{
			MenuManager.Instance.GetMenu(MenuType.GameOver).gameObject.GetComponent<PostcardMenu>().AddNewUnlock(Zone.Icon, "NEW ZONE", Zone.DisplayName, Rarity.Legendary);
		}
	}
}
