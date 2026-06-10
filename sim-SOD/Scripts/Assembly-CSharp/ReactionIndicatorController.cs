using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionIndicatorController : MonoBehaviour
{
	public RectTransform rect;

	public RectTransform bubbleRect;

	public Image img;

	public float distance;

	public float fadeProgress;

	public Actor actor;

	public InterfaceController.AwarenessIcon awarenessIcon;

	private NewAIController.ReactionState previousReactionState;

	public List<CanvasRenderer> graphics;

	public Vector2 bubbleDesiredSize;

	public bool displayOnScreen;

	public Vector3 desiredPosition;

	private bool firstPositionInit;

	[Header("Removal")]
	public float removalProgress;

	public bool removeHit;

	public bool removeBlocked;

	public bool removeFade;

	public float abortProgress;

	public void Setup(Actor newActor)
	{
	}

	public void UpdateReactionType()
	{
	}

	private void Update()
	{
	}
}
