using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	private static SoundManager _instance;

	public AudioClip buttonClick;

	public AudioClip rewardGain;

	public AudioClip menuOpen;

	public AudioClip menuClose;

	public AudioClip notificationPop;

	public AudioClip questReadySound;

	public AudioClip levelUpSound;

	public AudioClip purchase;

	public AudioClip openLootBox;

	public AudioClip openTreasureChest;

	public AudioClip bigImpact;

	public AudioClip coinRattle;

	public AudioClip victory;

	public List<AudioClip> itemGain;

	public List<AudioClip> menuChangeSounds;

	public List<AudioClip> buttonClicks;

	public List<AudioClip> heavyButtonSounds;

	public List<AudioClip> buildSounds;

	public List<AudioClip> woodChopSounds;

	public List<AudioClip> cropHarvestSounds;

	public List<AudioClip> fishingSounds;

	public List<AudioClip> waterSounds;

	public List<AudioClip> rockChopSounds;

	public List<AudioClip> coinSounds;

	public List<AudioClip> woodCrateOpenSounds;

	public List<AudioClip> woodCrateOpenSounds2;

	public List<AudioClip> rockSmashSounds;

	public List<AudioClip> crateThudSounds;

	public List<AudioClip> rewardHarps;

	private float buildCooldown;

	public static bool isNotificationSoundQueued;

	public static float notificationPopCountdown;

	protected void Update()
	{
		buildCooldown -= TimeManager.MenuDelta;
		if (isNotificationSoundQueued)
		{
			if (notificationPopCountdown > 0f)
			{
				notificationPopCountdown -= TimeManager.MenuDelta;
			}
			else
			{
				PlayNotification();
			}
		}
	}

	public void Init()
	{
		_instance = this;
	}

	public static void PlayNotification()
	{
		notificationPopCountdown = 0.05f;
		isNotificationSoundQueued = false;
		PlayInterfaceClip(_instance.notificationPop, 1f);
	}

	public static void PlayMenuOpen()
	{
		PlayInterfaceClip(_instance.menuOpen, 1f);
	}

	public static void PlayMenuClose()
	{
		PlayInterfaceClip(_instance.menuClose, 1f);
	}

	public static void PlayQuestReady()
	{
		PlayInterfaceClip(_instance.questReadySound, 0.5f);
	}

	public static void PlayBigImpact()
	{
		PlayInterfaceClip(_instance.bigImpact, 1f);
	}

	public static void PlayCoinRattle()
	{
		PlayInterfaceClip(_instance.coinRattle, 1f);
	}

	public static void PlayVictory()
	{
		PlayInterfaceClip(_instance.victory, 1f);
	}

	public static void PlayCrateThud()
	{
		PlayRandomFrom(_instance.crateThudSounds, 0.5f);
	}

	public static void PlayCrateBreak1()
	{
		PlayRandomFrom(_instance.woodCrateOpenSounds);
	}

	public static void PlayRockSmash()
	{
		PlayRandomFrom(_instance.rockSmashSounds);
	}

	public static void PlayCrateBreak2()
	{
		PlayRandomFrom(_instance.woodCrateOpenSounds2);
	}

	public static void PlayItemGain(EntityId earnedEntity)
	{
		if (earnedEntity.TryAsItem(out var i))
		{
			PlayItemGain(i);
		}
		else
		{
			PlayRandomFrom(_instance.woodChopSounds);
		}
	}

	public static void PlayLevelUp()
	{
		PlayInterfaceClip(_instance.levelUpSound, 1f);
	}

	public static void PlayOpenLootBox()
	{
		PlayInterfaceClip(_instance.openLootBox, 0.5f);
	}

	public static void PlayOpenTreasureChest()
	{
		PlayInterfaceClip(_instance.openTreasureChest, 0.5f);
	}

	public static void PlayItemGain(ItemType earnedItem)
	{
		if (Item.IsCurrency(earnedItem))
		{
			PlayRandomFrom(_instance.coinSounds);
			return;
		}
		switch (earnedItem)
		{
		case ItemType.Wood:
			PlayRandomFrom(_instance.woodChopSounds);
			break;
		case ItemType.Fish:
			PlayRandomFrom(_instance.fishingSounds);
			break;
		case ItemType.Water:
			PlayRandomFrom(_instance.waterSounds, 0.65f);
			break;
		case ItemType.Stone:
		case ItemType.IronOre:
		case ItemType.GoldOre:
		case ItemType.Coal:
		case ItemType.Mana:
		case ItemType.RedRuby:
		case ItemType.BlueSapphire:
		case ItemType.PurpleAmethyst:
		case ItemType.CopperOre:
		case ItemType.SilverOre:
		case ItemType.TopazCrown:
			PlayRandomFrom(_instance.rockChopSounds);
			break;
		default:
			PlayRandomFrom(_instance.cropHarvestSounds);
			break;
		}
	}

	public static void PlayRewardGain()
	{
		PlayInterfaceClip(_instance.rewardGain, 1f);
		PlayRandomFrom(_instance.rewardHarps);
	}

	public static void PlayBuildSound()
	{
		if (_instance.buildCooldown <= 0f)
		{
			PlayRandomFrom(_instance.buildSounds, 0.35f);
			_instance.buildCooldown = 3f;
		}
	}

	public static void PlayButtonClickSmall()
	{
		PlayInterfaceClip(_instance.buttonClick, 1f);
	}

	public static void PlayHeavyButton()
	{
		PlayRandomFrom(_instance.heavyButtonSounds);
	}

	public static void PlayPurchaseSound()
	{
		PlayRandomFrom(_instance.itemGain);
	}

	public static void PlayMenuChange()
	{
		PlayRandomFrom(_instance.menuChangeSounds);
	}

	private static void PlayRandomFrom(List<AudioClip> clips, float volumneAdjustment = 1f)
	{
		int count = clips.Count;
		switch (count)
		{
		case 0:
			break;
		case 1:
			PlayInterfaceClip(clips[0], volumneAdjustment);
			break;
		default:
		{
			int index = Random.Range(0, count);
			PlayInterfaceClip(clips[index], volumneAdjustment);
			break;
		}
		}
	}

	private static void PlayInterfaceClip(AudioClip clip, float adj)
	{
		if (null != clip)
		{
			MenuManager.Instance.audioSource.PlayOneShot(clip, Preferences.interfaceVolume * Preferences.masterVolume * adj);
		}
	}
}
