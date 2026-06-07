using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class NewPackCard : MonoBehaviour
{
	[Serializable]
	public struct PackContents
	{
		public CropType type;

		[Range(1f, 99f)]
		public int dropChance;
	}

	public PackManager packManager;

	public int quantity;

	public TMP_Text quantityText;

	private RectTransform rectTrans;

	private bool canOpenPack = true;

	[Header("Seeds available")]
	public PackContents[] packContents;

	[Header("Sounds")]
	[SerializeField]
	private AudioClip[] openAudioClip;

	private void OnEnable()
	{
		if (rectTrans == null)
		{
			rectTrans = GetComponent<RectTransform>();
			rectTrans.localScale = new Vector3(0f, 0f, 0f);
		}
		rectTrans.DOComplete();
		rectTrans.DOScale(1f, 0.3f).SetEase(Ease.OutElastic, 0.05f);
		InvokeRepeating("VisualWiggle", 5f, 3f);
	}

	private void OnDisable()
	{
		CancelInvoke("VisualWiggle");
	}

	public void OpenPack()
	{
		TooltipSystem.HideIcontip();
		StartCoroutine(OpenPackStep());
		rectTrans.DOComplete();
		rectTrans.DOPunchScale(Vector3.up * 0.33f, 0.2f);
		UpdateQuantityTo(quantity - 1);
		if (quantity <= 0)
		{
			HideCard();
		}
	}

	private IEnumerator OpenPackStep()
	{
		for (int i = 0; i < packManager.newSeedPacks.Count; i++)
		{
			if (!packManager.newSeedPacks[i].collected)
			{
				packManager.newSeedPacks[i].AddSeedToInventory(instant: true);
			}
		}
		packManager.newSeedPacks.Clear();
		yield return null;
		SoundManager.ins.PlaySound(openAudioClip);
		for (int j = 0; j < 6; j++)
		{
			if (packManager.newSeedsParent[j].gameObject.activeInHierarchy)
			{
				NewSeedCard newSeedCard = UnityEngine.Object.Instantiate(packManager.seedCardPrefab, packManager.newSeedsParent[j]);
				packManager.newSeedPacks.Add(newSeedCard);
				newSeedCard.SetCropType(getRandomCrop());
				yield return null;
			}
		}
	}

	private CropType getRandomCrop()
	{
		int num = 0;
		for (int i = 0; i < packContents.Length; i++)
		{
			num += packContents[i].dropChance;
		}
		int num2 = UnityEngine.Random.Range(0, num);
		int num3 = 0;
		for (int j = 0; j < packContents.Length; j++)
		{
			num3 += packContents[j].dropChance;
			if (num2 < num3)
			{
				return packContents[j].type;
			}
		}
		return CropType.None;
	}

	public void UpdateQuantityTo(int n)
	{
		quantity = n;
		if (quantity <= 0)
		{
			quantityText.text = "";
			quantity = 0;
		}
		else
		{
			quantityText.text = "x" + quantity;
			SoundManager.ins.PlaySound(openAudioClip);
		}
	}

	public void VisualBump()
	{
		rectTrans.DOComplete();
		rectTrans.DOPunchScale(Vector3.up * 0.33f, 0.2f);
	}

	private void VisualWiggle()
	{
		float num = 10f;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(rectTrans.DOLocalRotate(new Vector3(0f, 0f, num), 0.1f).SetEase(Ease.OutSine));
		sequence.Append(rectTrans.DOLocalRotate(new Vector3(0f, 0f, 0f - num), 0.2f).SetEase(Ease.InOutSine));
		sequence.Append(rectTrans.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.1f).SetEase(Ease.InSine));
		sequence.Play();
	}

	private void HideCard()
	{
		rectTrans.DOScale(0f, 0.2f).SetEase(Ease.Linear);
		rectTrans.DOLocalRotate(new Vector3(0f, 0f, -180f), 0.2f).OnComplete(Deactivate);
	}

	private void Deactivate()
	{
		base.gameObject.SetActive(value: false);
		rectTrans.localEulerAngles = Vector3.zero;
	}
}
