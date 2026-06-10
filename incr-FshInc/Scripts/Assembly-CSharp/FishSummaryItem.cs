using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishSummaryItem : MonoBehaviour
{
	[Header("Core References")]
	public Image fishIcon;

	public TMP_Text fishCountText;

	[Header("Discovery Indicator")]
	public GameObject newDiscoveryIndicator;

	[Header("XP UI References")]
	public Image xpBar;

	public TMP_Text levelText;

	public GameObject levelUpVfxPrefab;

	private CaughtFish caughtFishData;

	private Fish fishSpeciesData;

	private int caughtCount;

	private int startOfDayLevel;

	public CaughtFish GetCaughtFish()
	{
		return caughtFishData;
	}

	public void Setup(CaughtFish firstCatch, int count, bool isNewDiscovery, int xpGainedToday)
	{
		caughtFishData = firstCatch;
		fishSpeciesData = firstCatch.fish;
		if (fishIcon != null)
		{
			fishIcon.sprite = firstCatch.artwork;
		}
		if (fishCountText != null)
		{
			fishCountText.text = $"x{count}";
		}
		if (newDiscoveryIndicator != null)
		{
			newDiscoveryIndicator.SetActive(isNewDiscovery);
		}
		int num = fishSpeciesData.currentXp - xpGainedToday;
		startOfDayLevel = fishSpeciesData.currentLevel;
		int xpForNextLevel = fishSpeciesData.GetXpForNextLevel(startOfDayLevel - 1);
		int num2 = 0;
		while (num < 0 && startOfDayLevel > 1 && num2 < 2000)
		{
			num += xpForNextLevel;
			startOfDayLevel--;
			xpForNextLevel = fishSpeciesData.GetXpForNextLevel(startOfDayLevel - 1);
			num2++;
		}
		UpdateXpUI(num, startOfDayLevel);
	}

	public IEnumerator AnimateXPGain()
	{
		if (fishSpeciesData == null)
		{
			yield break;
		}
		Sequence sequence = DOTween.Sequence();
		sequence.Append(xpBar.DOFillAmount((float)fishSpeciesData.currentXp / (float)fishSpeciesData.GetXpForNextLevel(), 0.1f));
		sequence.OnPlay(delegate
		{
			SoundManager.PlaySound("SmallUI_Pop");
		});
		yield return sequence.WaitForCompletion();
		if (fishSpeciesData.currentLevel <= startOfDayLevel)
		{
			yield break;
		}
		SoundManager.PlaySound("LevelUp");
		if (levelUpVfxPrefab != null)
		{
			GameObject vfx = Object.Instantiate(levelUpVfxPrefab, levelText.transform.position, Quaternion.identity, base.transform);
			vfx.transform.DOPunchScale(Vector3.one * 0.3f, 0.5f);
			vfx.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).SetDelay(0.2f)
				.OnComplete(delegate
				{
					Object.Destroy(vfx);
				});
		}
		yield return new WaitForSeconds(0.1f);
		UpdateXpUI(fishSpeciesData.currentXp, fishSpeciesData.currentLevel);
	}

	private void UpdateXpUI(int xp, int level)
	{
		if (!(fishSpeciesData == null))
		{
			levelText.text = $"LVL {level}";
			xpBar.fillAmount = (float)xp / (float)fishSpeciesData.GetXpForNextLevel(level);
		}
	}
}
