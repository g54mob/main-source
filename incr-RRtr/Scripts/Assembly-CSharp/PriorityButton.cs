using DG.Tweening;
using UnityEngine;

public class PriorityButton : MonoBehaviour
{
	public WorkerAI.Action priority;

	public int indexPosition;

	public RectTransform rectTransform;

	public PrioritySystem prioritySystem;

	public void MoveTo(Vector2 anchorPos, float seconds)
	{
		rectTransform.DOAnchorPos(anchorPos, seconds);
	}

	public void MoveTo(Vector2 anchorPos)
	{
		rectTransform.anchoredPosition = anchorPos;
	}

	public void MoveThisPriorityUp()
	{
		prioritySystem.MoveUp(indexPosition);
	}

	public void MoveThisPriorityDown()
	{
		prioritySystem.MoveDown(indexPosition);
	}

	public void CancelMove()
	{
		rectTransform.DOKill();
	}
}
