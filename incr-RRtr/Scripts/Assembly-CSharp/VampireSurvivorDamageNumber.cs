using System.Collections;
using DG.Tweening;
using UnityEngine;

public class VampireSurvivorDamageNumber : MonoBehaviour
{
	private Transform trans;

	[SerializeField]
	private SpriteRenderer[] numbers;

	[SerializeField]
	private Sprite[] numberSprites;

	private Coroutine coroutine;

	public void DisplayNumber(int amount)
	{
		AnimateTransform(amount);
		numbers[0].transform.localPosition = new Vector3(-0.3125f, 0f, 0f);
		numbers[1].transform.localPosition = new Vector3(0f, 0f, 0f);
		numbers[2].transform.localPosition = new Vector3(0.3125f, 0f, 0f);
		if (amount < 10)
		{
			numbers[0].gameObject.SetActive(value: false);
			numbers[1].sprite = numberSprites[amount];
			numbers[2].gameObject.SetActive(value: false);
			RandomizeColor(1f, 0.9f);
		}
		else if (amount < 100)
		{
			numbers[0].sprite = numberSprites[amount / 10];
			numbers[1].sprite = numberSprites[amount % 10];
			numbers[2].gameObject.SetActive(value: false);
			RandomizeColor(0.8f, 0.7f);
			numbers[0].transform.localPosition += new Vector3(5f / 32f, 0f, 0f);
			numbers[1].transform.localPosition += new Vector3(5f / 32f, 0f, 0f);
		}
		else
		{
			numbers[0].sprite = numberSprites[amount / 100];
			numbers[1].sprite = numberSprites[amount % 100 / 10];
			numbers[2].sprite = numberSprites[amount % 10];
			RandomizeColor(0.6f, 0.5f);
		}
	}

	private void AnimateTransform(int amount)
	{
		if (trans == null)
		{
			trans = GetComponent<Transform>();
		}
		trans.DOKill();
		StopAllCoroutines();
		coroutine = StartCoroutine(Sequence(amount));
	}

	private void RandomizeColor(float min, float max)
	{
		float num = Random.Range(min, max);
		Color color = new Color(1f, num, num, 1f);
		for (int i = 0; i < numbers.Length; i++)
		{
			numbers[i].color = color;
		}
	}

	private IEnumerator Sequence(int amount)
	{
		float endValue = 1.25f;
		if (amount > 10)
		{
			endValue = 1.5f;
		}
		else if (amount > 100)
		{
			endValue = 1.75f;
		}
		trans.DOKill();
		trans.DOMoveY(trans.position.y + 1.25f, 1f).SetEase(Ease.OutSine);
		trans.DOScale(endValue, 0.5f).SetEase(Ease.OutSine);
		yield return new WaitForSeconds(0.55f);
		trans.DOScale(0f, 0.5f).SetEase(Ease.InSine).OnComplete(DestroyObj);
	}

	private void DestroyObj()
	{
		base.gameObject.SetActive(value: false);
	}
}
