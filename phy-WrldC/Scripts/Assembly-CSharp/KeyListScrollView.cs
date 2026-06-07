using System;
using UnityEngine;

public class KeyListScrollView : MonoBehaviour
{
	[SerializeField]
	private RectTransform scrollView;

	[SerializeField]
	private RectTransform contentPanel;

	[SerializeField]
	private float viewPortMaxHeight = 400f;

	public bool IsScrollActive { get; private set; }

	public event Action<bool> OnChangedScrollActivation;

	private void Update()
	{
		if (contentPanel.rect.height <= viewPortMaxHeight)
		{
			if (scrollView.rect.height != contentPanel.rect.height)
			{
				scrollView.sizeDelta = new Vector2(scrollView.sizeDelta.x, contentPanel.sizeDelta.y);
			}
			if (IsScrollActive)
			{
				this.OnChangedScrollActivation?.Invoke(obj: false);
			}
			IsScrollActive = false;
		}
		else
		{
			if (scrollView.rect.height != viewPortMaxHeight)
			{
				scrollView.sizeDelta = new Vector2(scrollView.sizeDelta.x, viewPortMaxHeight);
			}
			if (!IsScrollActive)
			{
				this.OnChangedScrollActivation?.Invoke(obj: true);
			}
			IsScrollActive = true;
		}
	}
}
