using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(WorldObjectUI))]
public class IdleDetectorUI : MonoBehaviour
{
	[SerializeField]
	private Image icon;

	private IdleDetector idleDetector;

	private Tween currentTween;

	public IdleDetector IdleDetector
	{
		get
		{
			return idleDetector;
		}
		set
		{
			idleDetector = value;
			idleDetector.onStopIdle += OnStopIdle;
			GetComponent<WorldObjectUI>().SetFollowTarget(idleDetector.gameObject);
			Show();
		}
	}

	private void OnDestroy()
	{
		if (currentTween != null)
		{
			currentTween.Kill();
		}
		if ((bool)idleDetector)
		{
			idleDetector.onStopIdle -= OnStopIdle;
		}
	}

	private void OnStopIdle(IdleDetector idleDetector)
	{
		Hide();
	}

	private void Show()
	{
		StopAllCoroutines();
		StartCoroutine(ShowCoroutine());
	}

	private void Hide()
	{
		Object.Destroy(base.gameObject);
	}

	private IEnumerator ShowCoroutine()
	{
		Color auxColor = icon.color;
		auxColor.a = 0f;
		icon.color = auxColor;
		WorldObjectUI worldObjectUI = GetComponent<WorldObjectUI>();
		worldObjectUI.Offset += idleDetector.GetComponent<PlacementComponent>().GetCenter(localSpace: true);
		Vector3 startOffset = worldObjectUI.Offset + Vector3.down * 0.25f;
		Vector3 finalOffest = worldObjectUI.Offset;
		worldObjectUI.Offset = startOffset;
		float totalDuration = 0.2f;
		float timer = 0f;
		yield return new WaitForSeconds(1f);
		while (timer <= totalDuration)
		{
			timer += Time.deltaTime;
			auxColor.a = Mathf.Lerp(0f, 1f, timer / totalDuration);
			icon.color = auxColor;
			worldObjectUI.Offset = Vector3.Lerp(startOffset, finalOffest, timer / totalDuration);
			yield return null;
		}
		auxColor.a = 1f;
		icon.color = auxColor;
		worldObjectUI.Offset = finalOffest;
		currentTween = (icon.transform as RectTransform).DOLocalJump((icon.transform as RectTransform).anchoredPosition, 20f, 1, 0.125f).SetLoops(-1).SetDelay(1.5f);
	}
}
