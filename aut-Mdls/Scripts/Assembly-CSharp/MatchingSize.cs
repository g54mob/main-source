using UnityEngine;

public class MatchingSize : MonoBehaviour
{
	[SerializeField]
	private RectTransform sourceRect;

	[SerializeField]
	private RectTransform targetRect;

	[SerializeField]
	private float _scaleup = 1.1f;

	private void Start()
	{
		CopySize();
	}

	private void Update()
	{
		CopySize();
	}

	private void OnEnable()
	{
		CopySize();
	}

	public void CopySize()
	{
		if (sourceRect != null && targetRect != null)
		{
			float width = sourceRect.rect.width;
			float height = sourceRect.rect.height;
			targetRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * _scaleup);
			targetRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height * _scaleup);
		}
		else
		{
			Debug.LogWarning("Le RectTransform source ou cible n'est pas d\ufffdfini !");
		}
	}
}
