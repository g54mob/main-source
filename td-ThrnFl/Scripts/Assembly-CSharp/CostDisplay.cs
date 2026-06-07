using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class CostDisplay : MonoBehaviour
{
	public Coinslot coinslotPrefab;

	public Coin coinPrefab;

	public RectTransform gridParent;

	public float horizontalSpacing;

	public int maxElementsPerRow = 5;

	public AnimationCurve yDistribution = new AnimationCurve();

	public float peakYOffset = 50f;

	public float rowYSpacing = 100f;

	public Transform amountDisplayParent;

	public TextMeshProUGUI amountDisplay;

	public MMF_Player displayCostAmountShow;

	public MMF_Player displayCostAmountHide;

	private List<Coinslot> coinslotPool = new List<Coinslot>();

	private List<Coinslot> currentlyActiveCoinslots = new List<Coinslot>();

	private float elementWidth;

	private float yCurveLeftAnchor;

	private float yCurveRightAnchor;

	private bool reUpdateBecauseFuckUnityCanvas;

	private int currentAmount;

	private int currentlyFilledCoins;

	private float completeFillDuration = 1f;

	private float minFillDurationPerCoin = 0.15f;

	private bool denied;

	private bool inDisappearAnimation;

	private const float defaultScale = 0.01f;

	private const float largeUIScale = 0.0125f;

	public static int currentlyFilledCoinsFromLastActiveDisplay;

	public bool CompletelyFilled => currentlyFilledCoins >= currentAmount;

	public bool CompletelyEmpty => currentlyFilledCoins <= 0;

	private float TotalFillTime => Mathf.Clamp((float)currentlyActiveCoinslots.Count * minFillDurationPerCoin * 0.9f, 0.8f, 1.75f);

	private void Start()
	{
		elementWidth = coinslotPrefab.GetComponent<RectTransform>().sizeDelta.x;
		float num = (float)maxElementsPerRow * elementWidth + (float)(maxElementsPerRow - 1) * horizontalSpacing;
		yCurveLeftAnchor = (0f - num) / 2f + elementWidth / 2f;
		yCurveRightAnchor = num / 2f - elementWidth / 2f;
	}

	private void Update()
	{
		if (reUpdateBecauseFuckUnityCanvas)
		{
			UpdateDisplay(currentAmount, dirty: false);
		}
	}

	public void UpdateDisplay(int amount, bool dirty = true)
	{
		base.transform.localScale = Vector3.one * 0.01f;
		inDisappearAnimation = false;
		base.gameObject.SetActive(value: true);
		StopAllCoroutines();
		currentAmount = amount;
		reUpdateBecauseFuckUnityCanvas = dirty;
		currentlyActiveCoinslots.Clear();
		currentlyFilledCoins = 0;
		denied = false;
		amountDisplayParent.gameObject.SetActive(value: false);
		if (amount < 1)
		{
			foreach (Coinslot item in coinslotPool)
			{
				item.gameObject.SetActive(value: false);
			}
			return;
		}
		int num = amount - coinslotPool.Count;
		for (int i = 0; i < num; i++)
		{
			coinslotPool.Add(Object.Instantiate(coinslotPrefab.gameObject, gridParent).GetComponent<Coinslot>());
		}
		int num2 = amount;
		int num3 = num2;
		if (num3 > maxElementsPerRow)
		{
			num3 = maxElementsPerRow;
		}
		int num4 = 0;
		int num5 = 0;
		float num6 = (0f - ((float)num3 * elementWidth + (float)(num3 - 1) * horizontalSpacing)) / 2f + elementWidth / 2f;
		for (int j = 0; j < coinslotPool.Count; j++)
		{
			Coinslot coinslot = coinslotPool[j];
			if (j < amount)
			{
				coinslot.gameObject.SetActive(value: true);
				currentlyActiveCoinslots.Add(coinslot);
				coinslot.transform.localScale = Vector3.zero;
				float num7 = num6 + ((float)num4 * elementWidth + (float)num4 * horizontalSpacing);
				float y = peakYOffset * yDistribution.Evaluate(Mathf.InverseLerp(yCurveLeftAnchor, yCurveRightAnchor, num7)) + rowYSpacing * (float)num5;
				coinslotPool[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(num7, y);
				num4++;
				num2--;
				if (num4 >= maxElementsPerRow)
				{
					num3 = num2;
					if (num3 > maxElementsPerRow)
					{
						num3 = maxElementsPerRow;
					}
					num4 = 0;
					num5++;
					num6 = (0f - ((float)num3 * elementWidth + (float)(num3 - 1) * horizontalSpacing)) / 2f + elementWidth / 2f;
				}
			}
			else
			{
				coinslot.gameObject.SetActive(value: false);
			}
		}
		foreach (Coinslot currentlyActiveCoinslot in currentlyActiveCoinslots)
		{
			currentlyActiveCoinslot.SetEmpty();
		}
		ThronefallAudioManager.SetCoinDisplayFillTime(TotalFillTime);
		StartCoroutine(AnimateShowSlots());
	}

	public bool FillUp()
	{
		currentlyFilledCoinsFromLastActiveDisplay = currentlyFilledCoins;
		if (currentlyActiveCoinslots.Count > currentlyFilledCoins)
		{
			float num = 1f / (TotalFillTime / (float)currentlyActiveCoinslots.Count);
			if (currentlyActiveCoinslots[currentlyFilledCoins].AddFill(Time.deltaTime * num, currentlyActiveCoinslots.Count - 1 == currentlyFilledCoins))
			{
				currentlyFilledCoins++;
				currentlyFilledCoinsFromLastActiveDisplay = currentlyFilledCoins;
				return true;
			}
		}
		return false;
	}

	public void Deny()
	{
		if (!denied)
		{
			currentlyActiveCoinslots[currentlyFilledCoins].PlayDeny();
			ThronefallAudioManager.Instance.MakeSureCoinFillSoundIsNotPlayingAnymore();
			denied = true;
		}
	}

	public void OnCompletion()
	{
		currentlyFilledCoins = 0;
		currentlyFilledCoinsFromLastActiveDisplay = 0;
		denied = false;
	}

	public void CancelFill(PlayerInteraction player)
	{
		foreach (Coinslot currentlyActiveCoinslot in currentlyActiveCoinslots)
		{
			if (currentlyActiveCoinslot.isFull)
			{
				Object.Instantiate(coinPrefab, currentlyActiveCoinslot.transform.position, currentlyActiveCoinslot.transform.rotation).SetTarget(player);
			}
			currentlyActiveCoinslot.SetEmpty();
		}
		ThronefallAudioManager.Oneshot(ThronefallAudioManager.AudioOneShot.CoinFillCancel);
		currentlyFilledCoins = 0;
		currentlyFilledCoinsFromLastActiveDisplay = 0;
		denied = false;
	}

	private IEnumerator AnimateShowSlots()
	{
		float waitTime = 0.2f / (float)currentAmount;
		if (currentAmount > maxElementsPerRow)
		{
			amountDisplayParent.gameObject.SetActive(value: true);
			amountDisplay.text = "x" + currentAmount;
			displayCostAmountShow.PlayFeedbacks();
			yield return new WaitForSeconds(waitTime);
		}
		foreach (Coinslot currentlyActiveCoinslot in currentlyActiveCoinslots)
		{
			currentlyActiveCoinslot.Appear();
			yield return new WaitForSeconds(waitTime);
		}
	}

	public void Hide()
	{
		if (base.gameObject.activeSelf && !inDisappearAnimation)
		{
			inDisappearAnimation = true;
			StopAllCoroutines();
			StartCoroutine(AnimateHideSlots());
		}
	}

	private IEnumerator AnimateHideSlots()
	{
		float waitTime = 0.2f / (float)currentAmount;
		if (amountDisplay.gameObject.activeInHierarchy)
		{
			displayCostAmountHide.PlayFeedbacks();
			yield return new WaitForSeconds(waitTime);
		}
		foreach (Coinslot currentlyActiveCoinslot in currentlyActiveCoinslots)
		{
			currentlyActiveCoinslot.Disappear();
			yield return new WaitForSeconds(waitTime);
		}
		yield return new WaitForSeconds(1f);
		inDisappearAnimation = false;
		base.gameObject.SetActive(value: false);
	}
}
