using DV.Utils;
using UnityEngine;
using UnityEngine.UI;

public class UITutorialHighlighter : SingletonBehaviour<UITutorialHighlighter>
{
	public float heightFrom;

	public float heightTo;

	public float speed;

	private Image image;

	private float time;

	private RectTransform target;

	private void Start()
	{
		image = GetComponentInChildren<Image>();
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		image.enabled = target.gameObject.activeInHierarchy;
		time += Time.unscaledDeltaTime;
		Vector3 position = target.TransformPoint(target.rect.center + Vector2.up * Mathf.Lerp(heightFrom, heightTo, Mathf.Abs(Mathf.Sin(time * speed))));
		base.transform.position = position;
		if (base.transform.GetSiblingIndex() != base.transform.parent.childCount - 1)
		{
			base.transform.SetAsLastSibling();
		}
	}

	public void Highlight(RectTransform target)
	{
		this.target = target;
		time = 0f;
		base.transform.SetAsLastSibling();
		base.gameObject.SetActive(value: true);
		image.enabled = target.gameObject.activeInHierarchy;
		Vector3 position = target.TransformPoint(target.rect.center + Vector2.up * Mathf.Lerp(heightFrom, heightTo, Mathf.Abs(Mathf.Sin(time * speed))));
		base.transform.position = position;
	}

	public void Unhighlight()
	{
		base.gameObject.SetActive(value: false);
		image.enabled = false;
	}
}
