using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Gradient textHoverGradient;

	[SerializeField]
	private Gradient textHoverDisabledGradient;

	private Button button;

	private TextMeshProUGUI text;

	private Coroutine gradientRoutine;

	private bool selected;

	private bool pointerInside;

	private void Awake()
	{
		button = GetComponent<Button>();
		text = GetComponentInChildren<TextMeshProUGUI>();
	}

	private void OnEnable()
	{
		StartCoroutine(SelectionWatcher());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
		text.color = textHoverGradient.Evaluate(0f);
		selected = false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		pointerInside = true;
		EventSystem.current.SetSelectedGameObject(base.gameObject);
		TryStartHover();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		pointerInside = false;
		TryStopHover();
	}

	public void ForceStartHover()
	{
		if (gradientRoutine != null)
		{
			StopCoroutine(gradientRoutine);
		}
		button.interactable = true;
		gradientRoutine = StartCoroutine(FadeGradient(toSelected: true));
	}

	private void TryStartHover()
	{
		if (!selected)
		{
			if (gradientRoutine != null)
			{
				StopCoroutine(gradientRoutine);
			}
			gradientRoutine = StartCoroutine(FadeGradient(toSelected: true));
		}
	}

	private void TryStopHover()
	{
		if (!selected)
		{
			if (gradientRoutine != null)
			{
				StopCoroutine(gradientRoutine);
			}
			gradientRoutine = StartCoroutine(FadeGradient(toSelected: false));
		}
	}

	private IEnumerator SelectionWatcher()
	{
		while (true)
		{
			bool flag = EventSystem.current.currentSelectedGameObject == base.gameObject;
			if (flag != selected)
			{
				selected = flag;
				if (gradientRoutine != null)
				{
					StopCoroutine(gradientRoutine);
				}
				gradientRoutine = StartCoroutine(FadeGradient(selected));
				if (pointerInside)
				{
					TryStartHover();
				}
			}
			yield return null;
		}
	}

	private IEnumerator FadeGradient(bool toSelected)
	{
		float t = (toSelected ? 0f : 1f);
		float target = (toSelected ? 1f : 0f);
		float duration = 0.1f;
		float time = 0f;
		Gradient gradient = (button.interactable ? textHoverGradient : textHoverDisabledGradient);
		while (time < duration)
		{
			time += Time.unscaledDeltaTime;
			float time2 = Mathf.Lerp(t, target, time / duration);
			text.color = gradient.Evaluate(time2);
			yield return null;
		}
		text.color = gradient.Evaluate(target);
	}
}
