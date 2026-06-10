using System.Collections.Generic;
using UnityEngine;

public class ChecklistButtonController : ButtonController
{
	public Objective objective;

	public CanvasRenderer bgRend;

	public CanvasRenderer textRend;

	public CanvasRenderer progressBGrend;

	public CanvasRenderer barRend;

	public CanvasRenderer iconRend;

	public float fadeInProgress;

	public bool fadeOut;

	public float strikeThroughProgress;

	public Vector2 desiredAnchoredPosition;

	public Sprite checkedSprite;

	public RectTransform progressRect;

	public FlashController flash;

	public List<CanvasRenderer> childRendereres;

	public void Setup(Objective newObjective)
	{
	}

	public void OnObjectiveProgressChange()
	{
	}

	public void OnComplete()
	{
	}

	public void Remove()
	{
	}
}
