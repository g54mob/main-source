using System.Collections;
using UnityEngine;

public class ButtonSlot : MonoBehaviour
{
	private Coroutine moveCoroutine;

	public RectTransform rectTransform { get; private set; }

	public Draggable_Button currentButton { get; private set; }

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void SetDD_Button(Draggable_Button _button, bool _fixToSlot, bool p_immediat)
	{
		currentButton = _button;
		if (currentButton != null && _fixToSlot && _button.gameObject.activeSelf)
		{
			if (moveCoroutine != null)
			{
				StopCoroutine(moveCoroutine);
			}
			moveCoroutine = StartCoroutine(MoveButton(p_immediat ? 8000f : 8f));
		}
	}

	private IEnumerator MoveButton(float p_time)
	{
		float timer = 0f;
		while (timer < 1f)
		{
			timer += Time.unscaledDeltaTime * p_time;
			currentButton.dragRectTransform.position = Vector3.Lerp(currentButton.dragRectTransform.position, rectTransform.position, timer);
			yield return null;
		}
		currentButton.dragRectTransform.position = Vector3.Lerp(currentButton.dragRectTransform.position, rectTransform.position, 1f);
		moveCoroutine = null;
	}
}
