using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIPanelBase : MonoBehaviour
{
	private CanvasGroup canvasGroup;

	[HideInInspector]
	public bool isPanelOpen;

	public List<UIPanelBase> connectedPanels = new List<UIPanelBase>();

	public CanvasGroup CanvasGroup
	{
		get
		{
			if (!(canvasGroup == null))
			{
				return canvasGroup;
			}
			return GetComponent<CanvasGroup>();
		}
	}

	public virtual void ShowPanel()
	{
		isPanelOpen = true;
		CanvasGroup.interactable = true;
		CanvasGroup.alpha = 1f;
		CanvasGroup.blocksRaycasts = true;
	}

	public void ShowPanel(CanvasGroup cg)
	{
		isPanelOpen = true;
		cg.interactable = true;
		cg.alpha = 1f;
		cg.blocksRaycasts = true;
	}

	public virtual void HidePanel()
	{
		isPanelOpen = false;
		CanvasGroup.interactable = false;
		CanvasGroup.alpha = 0f;
		CanvasGroup.blocksRaycasts = false;
	}

	public void HidePanel(CanvasGroup cg)
	{
		isPanelOpen = false;
		cg.interactable = false;
		cg.alpha = 0f;
		cg.blocksRaycasts = false;
	}

	public virtual void ShowPanelWithFade(float duration = 0.5f, Action onComplete = null)
	{
		isPanelOpen = true;
		CanvasGroup.DOKill();
		CanvasGroup.interactable = false;
		CanvasGroup.blocksRaycasts = true;
		CanvasGroup.alpha = 0f;
		CanvasGroup.DOFade(1f, duration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			CanvasGroup.interactable = true;
			onComplete?.Invoke();
		});
	}

	public virtual void HidePanelWithFade(float duration = 0.5f, Action onComplete = null)
	{
		isPanelOpen = false;
		CanvasGroup.DOKill();
		CanvasGroup.interactable = false;
		CanvasGroup.DOFade(0f, duration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			CanvasGroup.blocksRaycasts = false;
			onComplete?.Invoke();
		});
	}
}
