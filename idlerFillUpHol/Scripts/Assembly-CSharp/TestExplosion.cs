using DG.Tweening;
using UnityEngine;

public class TestExplosion : MonoBehaviour
{
	public GameObject Circle;

	private Color _originalColor;

	private void Start()
	{
		_originalColor = Circle.GetComponent<SpriteRenderer>().color;
		Circle.SetActive(value: false);
	}

	private void Update()
	{
	}

	public void Execute()
	{
		Circle.GetComponent<SpriteRenderer>().color = _originalColor;
		Circle.transform.localScale = new Vector3(1f, 1f, 1f);
		Circle.SetActive(value: true);
		Circle.transform.DOScale(new Vector3(20f, 20f, 1f), 1f).OnComplete(delegate
		{
			Circle.SetActive(value: false);
		});
		Circle.GetComponent<SpriteRenderer>().DOFade(0f, 1f).SetEase(Ease.InExpo);
	}
}
