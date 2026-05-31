using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ReaperShopUI : MonoBehaviour
{
	public ChipButton[] chipButtons;

	public Transform[] lockButtons;

	[SerializeField]
	private Transform panelObject;

	[SerializeField]
	private Transform rerollObject;

	[SerializeField]
	private ReaperAI reaperAI;

	[Space]
	[SerializeField]
	private AudioClip openAudio;

	[SerializeField]
	private AudioClip closeAudio;

	[SerializeField]
	private AudioClip uberAudio;

	private void OnEnable()
	{
		SetChips();
		StartCoroutine(SpawnUI());
	}

	public void SetReaperAI(ReaperAI reaper)
	{
		reaperAI = reaper;
	}

	private void SetChips()
	{
		List<CropType> listOfCropsFromTheLastX = Inventory.ins.GetListOfCropsFromTheLastX(6);
		int num = Random.Range(0, chipButtons.Length);
		bool flag = GameManager.ins.cropManager.cropUnlocked[GameManager.ins.cropManager.cropUnlocked.Length - 1];
		CropSO cropSO = null;
		List<CropSO> listOfCropsWithNoChip = Inventory.ins.GetListOfCropsWithNoChip();
		if (listOfCropsWithNoChip.Count > 0)
		{
			cropSO = listOfCropsWithNoChip[Random.Range(0, listOfCropsWithNoChip.Count)];
		}
		for (int i = 0; i < chipButtons.Length; i++)
		{
			if (chipButtons[i].currentCrop != null)
			{
				chipButtons[i].SetChipInfo();
			}
			else if (i == num && cropSO != null)
			{
				chipButtons[i].CreateRandomGMOfor(cropSO);
			}
			else if (i == num || flag)
			{
				CropType randomUnlockedCrop = GameManager.ins.getRandomUnlockedCrop();
				chipButtons[i].CreateRandomGMOfor(GameManager.ins.getCropSO(randomUnlockedCrop));
			}
			else
			{
				CropType cropType = listOfCropsFromTheLastX[Random.Range(0, listOfCropsFromTheLastX.Count)];
				chipButtons[i].CreateRandomGMOfor(GameManager.ins.getCropSO(cropType));
				listOfCropsFromTheLastX.Remove(cropType);
			}
		}
	}

	private IEnumerator SpawnUI()
	{
		panelObject.DOComplete();
		panelObject.transform.localScale = new Vector3(1f, 0f, 1f);
		for (int i = 0; i < chipButtons.Length; i++)
		{
			chipButtons[i].transform.DOComplete();
			chipButtons[i].transform.localScale = new Vector3(1f, 0f, 1f);
			lockButtons[i].transform.DOComplete();
			lockButtons[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
		rerollObject.transform.DOComplete();
		rerollObject.transform.localScale = new Vector3(1f, 0f, 1f);
		panelObject.DOScaleY(1f, 0.25f).SetEase(Ease.OutBack);
		SoundManager.ins.PlaySound(openAudio);
		yield return SpawnChips();
		yield return SpawnReroll();
	}

	private IEnumerator SpawnChips()
	{
		yield return new WaitForSeconds(0.25f);
		for (int i = 0; i < chipButtons.Length; i++)
		{
			if (chipButtons[i].currentGMOstats.tier != CropManager.GmoTier.None && !chipButtons[i].hidden)
			{
				yield return new WaitForSeconds(0.1f);
				chipButtons[i].transform.DOComplete();
				chipButtons[i].transform.localScale = new Vector3(1f, 0f, 1f);
				chipButtons[i].transform.DOScaleY(1f, 0.25f).SetEase(Ease.OutBack);
				lockButtons[i].transform.DOComplete();
				lockButtons[i].transform.localScale = new Vector3(1f, 0f, 1f);
				lockButtons[i].transform.DOScaleY(1f, 0.25f).SetEase(Ease.Linear);
				SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
				if (chipButtons[i].currentGMOstats.tier == CropManager.GmoTier.Uber)
				{
					chipButtons[i].transform.DOShakePosition(0.8f, 2f, 10, 90f, snapping: false, fadeOut: false);
					Invoke("PlayUberSound", 0.05f);
				}
			}
		}
	}

	private void PlayUberSound()
	{
		SoundManager.ins.PlaySound(uberAudio);
	}

	private IEnumerator SpawnReroll()
	{
		yield return new WaitForSeconds(0.1f);
		rerollObject.DOComplete();
		rerollObject.transform.localScale = new Vector3(1f, 0f, 1f);
		rerollObject.DOScaleY(1f, 0.25f).SetEase(Ease.OutBack);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void CheckIfAllChipsHaveBeenPurchased()
	{
		for (int i = 0; i < chipButtons.Length; i++)
		{
			if (!chipButtons[i].hidden)
			{
				return;
			}
		}
		ClickedReroll();
	}

	public void ClickedReroll()
	{
		CheckRerollAchievement();
		for (int i = 0; i < chipButtons.Length; i++)
		{
			chipButtons[i].Reroll();
		}
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		HideUI();
		AreYouSure.ins.No();
		reaperAI.StartDeparture();
	}

	private void CheckRerollAchievement()
	{
		bool flag = true;
		for (int i = 0; i < chipButtons.Length; i++)
		{
			if (chipButtons[i].hidden)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			AchievementManager.ins.RerollAllGMOs();
		}
	}

	public void HideUI()
	{
		SoundManager.ins.PlaySound(closeAudio);
		base.gameObject.SetActive(value: false);
	}
}
