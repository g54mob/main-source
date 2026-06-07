using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtonToTarget : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private Camera cam;

	public Transform target;

	public Vector3 offset;

	public AnimationCurve highlightCurve;

	public SpriteRenderer pageHighlight;

	private bool isHighlighting;

	private bool hoveringButton;

	private void Awake()
	{
		cam = Camera.main;
		pageHighlight.color = new Color(pageHighlight.color.r, pageHighlight.color.g, pageHighlight.color.b, highlightCurve[0].value);
	}

	private void Update()
	{
		if (target != null)
		{
			base.transform.position = Camera.main.WorldToScreenPoint(target.position) + offset;
		}
		if (!RuleBookScreenManager.isAttemptingCheatGuess)
		{
			UpdateHighlight();
		}
	}

	public void UpdateHighlight()
	{
		if (hoveringButton && !isHighlighting)
		{
			StartCoroutine(HighlightButton());
		}
	}

	public IEnumerator HighlightButton()
	{
		isHighlighting = true;
		float highlightSeconds = 0f;
		while (highlightSeconds < highlightCurve[highlightCurve.length - 1].time)
		{
			highlightSeconds += Time.deltaTime;
			pageHighlight.color = new Color(pageHighlight.color.r, pageHighlight.color.g, pageHighlight.color.b, highlightCurve.Evaluate(highlightSeconds));
			yield return null;
		}
		pageHighlight.color = new Color(pageHighlight.color.r, pageHighlight.color.g, pageHighlight.color.b, highlightCurve[highlightCurve.length - 1].value);
		isHighlighting = false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		hoveringButton = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hoveringButton = false;
	}
}
