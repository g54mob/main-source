using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class BalatroJokerHand : MonoBehaviour
{
	public JokerType jokerType;

	public Transform jokerTransform;

	public List<BalatroHandSlot> handSlots;

	public Transform handSlotsParent;

	[SerializeField]
	private Vector2 initialPosition;

	[SerializeField]
	private Vector2 jugglerPosition;

	[SerializeField]
	private Vector2 stuntmanPosition;

	private int payout;

	public Transform scoreTransform;

	public TMP_Text scoreText;

	private bool isPlayingHand;

	private HandType currentHandType;

	[Header("SFX")]
	[SerializeField]
	private AudioClip playCardSFX;

	[SerializeField]
	private AudioClip chipsSFX;

	[SerializeField]
	private AudioClip multSFX;

	[SerializeField]
	private AudioClip genericSFX;

	[SerializeField]
	private AudioClip scoreSFX;

	private void Start()
	{
		if ((bool)GameManager.ins && !GameManager.ins.jokerHands.Contains(this))
		{
			GameManager.ins.jokerHands.Add(this);
		}
		scoreTransform.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		if (!isPlayingHand)
		{
			ResetHand();
		}
		GameManager.ins.jokerHands.Remove(this);
	}

	private void OnEnable()
	{
		if ((bool)GameManager.ins && !GameManager.ins.jokerHands.Contains(this))
		{
			GameManager.ins.jokerHands.Add(this);
		}
		MoveHandSlots(jokerType);
	}

	public void TryToPlayHand()
	{
		if (jokerType == JokerType.Blueprint)
		{
			JokerType jokerToTheRight = getJokerToTheRight();
			MoveHandSlots(jokerToTheRight);
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (handSlots[i].card == null && handSlots[i].active)
			{
				return;
			}
		}
		if (!isPlayingHand)
		{
			StartPlayHand();
			isPlayingHand = true;
		}
	}

	private void StartPlayHand()
	{
		CropType crop2;
		CropType crop3;
		CropType crop4;
		CropType crop5;
		CropType crop6;
		CropType crop7;
		CropType crop8;
		CropType crop9;
		if (fiveOfAKind(out var crop))
		{
			currentHandType = HandType.FiveOfAKind;
			PlayHand(crop);
		}
		else if (fourOfAKind(out crop2))
		{
			currentHandType = HandType.FourOfAKind;
			PlayHand(crop2);
		}
		else if (fullHouse(out crop3, out crop4))
		{
			currentHandType = HandType.FullHouse;
			PlayHand(crop3, crop4);
		}
		else if (threeOfAKind(out crop5))
		{
			currentHandType = HandType.ThreeOfAKind;
			PlayHand(crop5);
		}
		else if (twoPair(out crop6, out crop7))
		{
			currentHandType = HandType.TwoPair;
			PlayHand(crop6, crop7);
		}
		else if (pair(out crop8))
		{
			currentHandType = HandType.Pair;
			PlayHand(crop8);
		}
		else if (highCard(out crop9))
		{
			currentHandType = HandType.HighCard;
			PlayHand(crop9);
		}
		else
		{
			Debug.Log("No valid hand");
			isPlayingHand = false;
		}
	}

	private void PlayHand(CropType crop1)
	{
		StartCoroutine(PlayHandAnimation(crop1, CropType.None));
	}

	private void PlayHand(CropType crop1, CropType crop2)
	{
		StartCoroutine(PlayHandAnimation(crop1, crop2));
	}

	private IEnumerator PlayHandAnimation(CropType crop1, CropType crop2)
	{
		float popuptime = 2f;
		payout = 0;
		PrintHandType();
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (!(handSlots[i].card == null) && (handSlots[i].card.cropSO.cropType == crop1 || handSlots[i].card.cropSO.cropType == crop2))
			{
				handSlots[i].card.transform.position += Vector3.up * 0.25f;
				PlayAudioClip(playCardSFX);
				yield return new WaitForSeconds(0.1f);
			}
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (!(handSlots[i].card == null) && (handSlots[i].card.cropSO.cropType == crop1 || handSlots[i].card.cropSO.cropType == crop2))
			{
				yield return new WaitForSeconds(0.4f);
				string msg = "+" + handSlots[i].card.spareParts;
				SpawnPopUp(handSlots[i].transform, msg, popuptime, Color.blue);
				PlayAudioClip(chipsSFX);
				payout += handSlots[i].card.spareParts;
				UpdateScoreTo(payout);
				Transform child = handSlots[i].card.transform.parent.GetChild(1);
				child.GetComponent<BalatroCardVisual>().enabled = false;
				PlayJumpAnimation(child, 1.3f);
			}
		}
		yield return new WaitForSeconds(0.4f);
		ApplyJokerEffect(popuptime, jokerType);
		PlayJumpAnimation(jokerTransform, 1.5f);
		yield return new WaitForSeconds(0.4f);
		ResetHand();
		PlayAudioClip(scoreSFX);
		yield return new WaitForSeconds(0.2f);
		GameManager.ins.SpawnBalatroPopUp(scoreTransform.position, "<sprite index=0>" + payout, popuptime * 1.5f, Color.yellow);
		Inventory.ins.AddSpareParts(payout);
		scoreTransform.gameObject.SetActive(value: false);
	}

	private void ApplyJokerEffect(float popuptime, JokerType joker)
	{
		if (joker == JokerType.Jimbo)
		{
			SpawnPopUp(jokerTransform, "x4 Mult", popuptime * 1.25f, Color.red);
			payout *= 4;
			UpdateScoreTo(payout);
			PlayAudioClip(multSFX);
		}
		if (joker == JokerType.Misprint)
		{
			int num = Random.Range(0, 24);
			SpawnPopUp(jokerTransform, "x" + num + " Mult", popuptime * 1.25f, Color.red);
			payout *= num;
			UpdateScoreTo(payout);
			PlayAudioClip(multSFX);
		}
		if (joker == JokerType.Abstract)
		{
			int count = GameManager.ins.jokerHands.Count;
			SpawnPopUp(jokerTransform, "x" + count * 3 + " Mult", popuptime * 1.25f, Color.red);
			payout *= count * 3;
			UpdateScoreTo(payout);
			PlayAudioClip(multSFX);
		}
		if (joker == JokerType.Juggler)
		{
			string localizedValue = LocalizationSystem.GetLocalizedValue(getHandTypeString());
			SpawnPopUp(jokerTransform, localizedValue, popuptime * 1.25f, Color.yellow);
			PlayAudioClip(genericSFX);
		}
		if (joker == JokerType.Stuntman)
		{
			SpawnPopUp(jokerTransform, "+250", popuptime * 1.25f, Color.blue);
			payout += 250;
			UpdateScoreTo(payout);
			PlayAudioClip(chipsSFX);
		}
		if (joker == JokerType.Crafty)
		{
			if (currentHandType == HandType.FiveOfAKind)
			{
				SpawnPopUp(jokerTransform, "+80", popuptime * 1.25f, Color.blue);
				payout += 80;
				UpdateScoreTo(payout);
				PlayAudioClip(chipsSFX);
			}
			else
			{
				string localizedValue2 = LocalizationSystem.GetLocalizedValue("_BALATRO_TRY_AGAIN");
				SpawnPopUp(jokerTransform, localizedValue2, popuptime * 1.25f, Color.yellow);
				PlayAudioClip(genericSFX);
			}
		}
		if (joker == JokerType.Mad)
		{
			if (currentHandType == HandType.TwoPair || currentHandType == HandType.FullHouse)
			{
				SpawnPopUp(jokerTransform, "x10 Mult", popuptime * 1.25f, Color.red);
				payout *= 10;
				UpdateScoreTo(payout);
				PlayAudioClip(multSFX);
			}
			else
			{
				string localizedValue3 = LocalizationSystem.GetLocalizedValue("_BALATRO_TRY_AGAIN");
				SpawnPopUp(jokerTransform, localizedValue3, popuptime * 1.25f, Color.yellow);
				PlayAudioClip(genericSFX);
			}
		}
		if (joker == JokerType.Blueprint)
		{
			JokerType jokerToTheRight = getJokerToTheRight();
			MoveHandSlots(jokerToTheRight);
			if (jokerToTheRight == JokerType.None)
			{
				string localizedValue4 = LocalizationSystem.GetLocalizedValue("_BALATRO_TRY_AGAIN");
				SpawnPopUp(jokerTransform, localizedValue4, popuptime * 1.25f, Color.yellow);
				PlayAudioClip(genericSFX);
			}
			else
			{
				ApplyJokerEffect(popuptime, jokerToTheRight);
			}
		}
	}

	private JokerType getJokerToTheRight()
	{
		List<BalatroJokerHand> list = new List<BalatroJokerHand>();
		for (int i = 0; i < GameManager.ins.jokerHands.Count; i++)
		{
			BalatroJokerHand balatroJokerHand = GameManager.ins.jokerHands[i];
			if (!(balatroJokerHand == this) && balatroJokerHand.transform.position.x > base.transform.position.x)
			{
				list.Add(balatroJokerHand);
			}
		}
		if (list.Count > 0)
		{
			list.Sort((BalatroJokerHand a, BalatroJokerHand b) => a.transform.position.x.CompareTo(b.transform.position.x));
			return list[0].jokerType;
		}
		return JokerType.None;
	}

	private void MoveHandSlots(JokerType joker)
	{
		switch (joker)
		{
		case JokerType.Juggler:
			handSlots[5].active = true;
			handSlotsParent.localPosition = jugglerPosition;
			break;
		case JokerType.Stuntman:
			handSlots[3].active = false;
			handSlots[4].active = false;
			handSlots[5].active = false;
			handSlotsParent.localPosition = stuntmanPosition;
			break;
		default:
			handSlots[3].active = true;
			handSlots[4].active = true;
			handSlots[5].active = false;
			handSlotsParent.localPosition = initialPosition;
			break;
		}
	}

	private bool fiveOfAKind(out CropType crop)
	{
		crop = CropType.None;
		if (handSlots.Count < 5)
		{
			return false;
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (handSlots[i].card == null)
			{
				continue;
			}
			CropType cropType = handSlots[i].card.cropSO.cropType;
			int num = 1;
			for (int j = i + 1; j < handSlots.Count; j++)
			{
				if (!(handSlots[j].card == null) && handSlots[j].card.cropSO.cropType == cropType)
				{
					num++;
					if (num == 5)
					{
						crop = cropType;
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool fourOfAKind(out CropType crop)
	{
		crop = CropType.None;
		if (handSlots.Count < 4)
		{
			return false;
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (handSlots[i].card == null)
			{
				continue;
			}
			CropType cropType = handSlots[i].card.cropSO.cropType;
			int num = 1;
			for (int j = i + 1; j < handSlots.Count; j++)
			{
				if (!(handSlots[j].card == null) && handSlots[j].card.cropSO.cropType == cropType)
				{
					num++;
					if (num == 4)
					{
						crop = cropType;
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool fullHouse(out CropType crop1, out CropType crop2)
	{
		crop1 = CropType.None;
		crop2 = CropType.None;
		if (handSlots.Count < 5)
		{
			return false;
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (handSlots[i].card == null)
			{
				continue;
			}
			CropType cropType = handSlots[i].card.cropSO.cropType;
			int num = 1;
			for (int j = i + 1; j < handSlots.Count; j++)
			{
				if (!(handSlots[j].card == null) && handSlots[j].card.cropSO.cropType == cropType)
				{
					num++;
					if (num == 3)
					{
						crop1 = cropType;
						break;
					}
				}
			}
		}
		for (int k = 0; k < handSlots.Count; k++)
		{
			if (handSlots[k].card == null)
			{
				continue;
			}
			CropType cropType2 = handSlots[k].card.cropSO.cropType;
			int num2 = 1;
			if (cropType2 == crop1)
			{
				continue;
			}
			for (int l = k + 1; l < handSlots.Count; l++)
			{
				if (!(handSlots[l].card == null) && handSlots[l].card.cropSO.cropType != crop1 && handSlots[l].card.cropSO.cropType == cropType2)
				{
					num2++;
					if (num2 == 2)
					{
						crop2 = cropType2;
						break;
					}
				}
			}
		}
		if (crop1 != CropType.None && crop2 != CropType.None)
		{
			return true;
		}
		return false;
	}

	private bool threeOfAKind(out CropType crop)
	{
		crop = CropType.None;
		if (handSlots.Count < 3)
		{
			return false;
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (handSlots[i].card == null)
			{
				continue;
			}
			CropType cropType = handSlots[i].card.cropSO.cropType;
			int num = 1;
			for (int j = i + 1; j < handSlots.Count; j++)
			{
				if (!(handSlots[j].card == null) && handSlots[j].card.cropSO.cropType == cropType)
				{
					num++;
					if (num == 3)
					{
						crop = cropType;
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool twoPair(out CropType crop1, out CropType crop2)
	{
		crop1 = CropType.None;
		crop2 = CropType.None;
		if (handSlots.Count < 4)
		{
			return false;
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (handSlots[i].card == null)
			{
				continue;
			}
			CropType cropType = handSlots[i].card.cropSO.cropType;
			int num = 1;
			for (int j = i + 1; j < handSlots.Count; j++)
			{
				if (!(handSlots[j].card == null) && handSlots[j].card.cropSO.cropType == cropType)
				{
					num++;
					if (num == 2)
					{
						crop1 = cropType;
						break;
					}
				}
			}
		}
		for (int k = 0; k < handSlots.Count; k++)
		{
			if (handSlots[k].card == null)
			{
				continue;
			}
			CropType cropType2 = handSlots[k].card.cropSO.cropType;
			int num2 = 1;
			if (cropType2 == crop1)
			{
				continue;
			}
			for (int l = k + 1; l < handSlots.Count; l++)
			{
				if (!(handSlots[l].card == null) && handSlots[l].card.cropSO.cropType != crop1 && handSlots[l].card.cropSO.cropType == cropType2)
				{
					num2++;
					if (num2 == 2)
					{
						crop2 = cropType2;
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool pair(out CropType crop)
	{
		crop = CropType.None;
		if (handSlots.Count < 2)
		{
			return false;
		}
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (handSlots[i].card == null)
			{
				continue;
			}
			CropType cropType = handSlots[i].card.cropSO.cropType;
			int num = 1;
			for (int j = i + 1; j < handSlots.Count; j++)
			{
				if (!(handSlots[j].card == null) && handSlots[j].card.cropSO.cropType == cropType)
				{
					num++;
					if (num == 2)
					{
						crop = cropType;
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool highCard(out CropType crop)
	{
		crop = CropType.None;
		int num = 0;
		for (int i = 0; i < handSlots.Count; i++)
		{
			if (!(handSlots[i].card == null) && handSlots[i].card.spareParts > num)
			{
				num = handSlots[i].card.spareParts;
				crop = handSlots[i].card.cropSO.cropType;
			}
		}
		return crop != CropType.None;
	}

	private void UpdateScoreTo(int score)
	{
		scoreTransform.gameObject.SetActive(value: true);
		PlayJumpAnimation(scoreTransform, 1.3f);
		scoreText.text = "<sprite index=0>" + score;
	}

	private void PlayJumpAnimation(Transform trans, float scale)
	{
		trans.DOKill();
		trans.localScale = Vector3.one * scale;
		trans.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
		int num = ((Random.Range(0, 2) != 0) ? 1 : (-1));
		trans.localEulerAngles = new Vector3(0f, 0f, 15 * num);
		trans.DORotate(Vector3.zero, 0.25f).SetEase(Ease.OutBack);
	}

	private void PlayAudioClip(AudioClip audio)
	{
		if (GameManager.ins.balatroSoundEffects)
		{
			SoundManager.ins.PlaySound(audio);
		}
	}

	private void SpawnPopUp(Transform trans, string msg, float time, Color color)
	{
		Vector2 position = trans.position + Vector3.up * 1.25f;
		GameManager.ins.SpawnBalatroPopUp(position, msg, time, color);
	}

	private void ResetHand()
	{
		isPlayingHand = false;
		for (int i = 0; i < handSlots.Count; i++)
		{
			handSlots[i].RemoveCard();
		}
	}

	private void PrintHandType()
	{
		string handTypeString = getHandTypeString();
		Debug.Log("Hand Type: " + handTypeString);
	}

	private string getHandTypeString()
	{
		return currentHandType switch
		{
			HandType.FiveOfAKind => "_BALATRO_FIVE_OF_A_KIND", 
			HandType.FourOfAKind => "_BALATRO_FOUR_OF_A_KIND", 
			HandType.FullHouse => "_BALATRO_FULL_HOUSE", 
			HandType.ThreeOfAKind => "_BALATRO_THREE_OF_A_KIND", 
			HandType.TwoPair => "_BALATRO_TWO_PAIR", 
			HandType.Pair => "_BALATRO_PAIR", 
			HandType.HighCard => "_BALATRO_HIGH_CARD", 
			_ => "ERROR!", 
		};
	}
}
