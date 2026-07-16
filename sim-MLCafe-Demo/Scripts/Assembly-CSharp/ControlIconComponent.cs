using TMPro;
using UnityEngine;

public class ControlIconComponent : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelControl;

	[SerializeField]
	private UIContentAnimator animator;

	private bool isVisible;

	private void Start()
	{
		animator.GetCanvasGroup().alpha = 0f;
		isVisible = false;
	}

	public bool IsVisible()
	{
		return isVisible;
	}

	public void UpdateControl(string control)
	{
		labelControl.text = control;
	}

	public void ShowControl(string control)
	{
		if (!MouseCursorInteraction.AreControlsHidden() && !CafeDataLoader.IsLoading())
		{
			labelControl.text = control;
			animator.GetCanvasGroup().alpha = 1f;
			isVisible = true;
		}
	}

	public void HideControl()
	{
		if (isVisible)
		{
			animator.GetCanvasGroup().alpha = 0f;
			isVisible = false;
		}
	}

	public void HideForced()
	{
		if (!(animator == null) && !(animator.GetCanvasGroup() == null))
		{
			animator.GetCanvasGroup().alpha = 0f;
			isVisible = false;
		}
	}
}
