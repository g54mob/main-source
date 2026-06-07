using DG.Tweening;
using UnityEngine;

public class PulsingLight : MonoBehaviour
{
	[SerializeField]
	private float scaleUp = 1.5f;

	[SerializeField]
	private float scaleDown = 0.5f;

	private RectTransform rectTransform;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		PulseUp();
	}

	private void PulseUp()
	{
		rectTransform.DOScale(Vector3.one * scaleUp, 0.5f).OnComplete(delegate
		{
			Invoke("PulseDown", 0.5f);
		});
	}

	private void PulseDown()
	{
		rectTransform.DOScale(Vector3.one * scaleDown, 0.5f).OnComplete(delegate
		{
			Invoke("PulseUp", 0.5f);
		});
	}
}
