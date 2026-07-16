using System.Linq;
using UnityEngine;

public class StationMapTooltip : MonoBehaviour
{
	[SerializeField]
	private float fadeInDistance = 0.5f;

	[SerializeField]
	private float fadeOutDistance = 1f;

	[SerializeField]
	private CanvasGroup canvasGroup;

	private int tweenId = -1;

	private void Start()
	{
		Bounce();
	}

	private void Update()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		if (!LevelManager.Instance.IsAtDestination)
		{
			FadeTo(0f);
			return;
		}
		if (PlayerManager.Instance.Players == null || PlayerManager.Instance.Players.Count == 0)
		{
			FadeTo(0f);
			return;
		}
		float distance = Mathf.Min(PlayerManager.Instance.Players.Select((PlayerController p) => Vector3.Distance(p.transform.position, canvasGroup.transform.position)).ToArray());
		UpdateAlpha(distance);
	}

	private void Bounce()
	{
		Vector3 vector = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y + 5f, base.transform.localPosition.z);
		LeanTween.moveLocalY(base.gameObject, vector.y, 1f).setEase(LeanTweenType.easeInOutQuad).setLoopPingPong()
			.setRepeat(-1);
	}

	private void UpdateAlpha(float distance)
	{
		if (distance <= fadeOutDistance)
		{
			FadeTo(0f);
		}
		else if (distance >= fadeInDistance)
		{
			FadeTo(1f);
		}
	}

	private void FadeTo(float targetAlpha)
	{
		if (tweenId != -1)
		{
			LeanTween.cancel(tweenId);
		}
		tweenId = LeanTween.alphaCanvas(canvasGroup, targetAlpha, 0.5f).id;
	}

	public void ForceHide()
	{
		if (tweenId != -1)
		{
			LeanTween.cancel(tweenId);
		}
		canvasGroup.alpha = 0f;
	}
}
