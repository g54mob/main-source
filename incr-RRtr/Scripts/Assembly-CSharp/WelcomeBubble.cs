using DG.Tweening;
using UnityEngine;

public class WelcomeBubble : MonoBehaviour
{
	[SerializeField]
	private GameObject[] firstObjs;

	[SerializeField]
	private GameObject[] finalObjs;

	private RectTransform rect;

	private void Start()
	{
		rect = GetComponent<RectTransform>();
		rect.localScale = Vector3.zero;
		rect.DOScale(1f, 0.25f).SetEase(Ease.OutBack).SetDelay(0.5f);
	}

	public void ClickedNextButton()
	{
		for (int i = 0; i < firstObjs.Length; i++)
		{
			firstObjs[i].SetActive(value: false);
		}
		for (int j = 0; j < finalObjs.Length; j++)
		{
			finalObjs[j].SetActive(value: true);
		}
		rect.DOPunchScale(Vector3.up * 0.125f, 0.15f).SetEase(Ease.OutBack);
	}

	public void ClickedCloseButton()
	{
		for (int i = 0; i < finalObjs.Length; i++)
		{
			finalObjs[i].SetActive(value: false);
		}
	}
}
