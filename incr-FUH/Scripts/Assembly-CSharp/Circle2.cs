using DG.Tweening;
using UnityEngine;

public class Circle2 : MonoBehaviour
{
	private Color _originalColor;

	private void Start()
	{
		_originalColor = GetComponent<SpriteRenderer>().color;
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
	}

	public void RunExplosion()
	{
		base.gameObject.SetActive(value: true);
		GetComponent<SpriteRenderer>().color = _originalColor;
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		base.transform.DOScale(new Vector3(6f, 6f, 1f), 1f).OnComplete(delegate
		{
			base.gameObject.SetActive(value: false);
		});
		GetComponent<AnimationSprite>().Play("expolode");
	}
}
