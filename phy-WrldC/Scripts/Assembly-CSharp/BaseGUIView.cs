using UnityEngine;

public abstract class BaseGUIView : MonoBehaviourBaseView
{
	public GameObject mainPanel;

	private Canvas parentCanvas;

	private Animator panelAnimator;

	public bool IsMouseOverUI { get; protected set; }

	public bool IsVisible { get; private set; }

	public Canvas ParentCanvas
	{
		get
		{
			if (parentCanvas == null)
			{
				parentCanvas = mainPanel.GetComponent<Canvas>();
			}
			if (parentCanvas == null)
			{
				parentCanvas = mainPanel.GetComponentInParent<Canvas>();
			}
			if (parentCanvas == null)
			{
				parentCanvas = mainPanel.GetComponentsInParent<Canvas>(includeInactive: true)[0];
			}
			return parentCanvas;
		}
	}

	public abstract void Initialize();

	public virtual void SetVisibility(bool isVisible)
	{
		if (mainPanel != null && parentCanvas.enabled != isVisible)
		{
			base.enabled = isVisible;
			parentCanvas.enabled = isVisible;
		}
		if (!isVisible)
		{
			IsMouseOverUI = false;
		}
		IsVisible = isVisible;
	}

	public void SetVisibilityAnimation(bool isVisible)
	{
		if (panelAnimator == null)
		{
			panelAnimator = mainPanel.GetComponent<Animator>();
			if (panelAnimator == null)
			{
				return;
			}
		}
		if (isVisible)
		{
			panelAnimator.Play("Show");
		}
		else
		{
			panelAnimator.Play("Hide");
		}
	}

	protected void OnMouseOverUIHandler(bool isOver)
	{
		IsMouseOverUI = isOver;
	}
}
