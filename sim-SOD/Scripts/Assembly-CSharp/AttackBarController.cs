using System.Collections.Generic;
using UnityEngine;

public class AttackBarController : MonoBehaviour
{
	public NewAIController ai;

	public RectTransform rect;

	public RectTransform barAnchor;

	public RectTransform attackProgress;

	public RectTransform blockPoint;

	public RectTransform perfectBlockPoint;

	public float barProgress;

	public bool displayOnScreen;

	public float distance;

	[Header("Graphic Elements")]
	public List<CanvasRenderer> allGraphics;

	public List<CanvasRenderer> backgroundGraphics;

	public List<CanvasRenderer> blockGraphics;

	public List<CanvasRenderer> hitGraphics;

	[Header("Removal")]
	public float removalProgress;

	public bool removeHit;

	public bool removeBlocked;

	public bool removeAbort;

	public float abortProgress;

	public void Setup(NewAIController newAi)
	{
	}

	private void Update()
	{
	}
}
