using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementPopupController : MonoBehaviour
{
	private RectTransform content;

	private int scrolling;

	private const float scrollSpeed = 2f;

	private const float eps = 0.001f;

	private const float popupDelay = 3f;

	private Vector3 positionBuffer;

	private Queue<RectTransform> popups = new Queue<RectTransform>();

	private AchivementBlockInstancer achivementBlockPrefab;

	private void Start()
	{
		content = base.gameObject.GetComponentInChildren<VerticalLayoutGroup>().GetComponent<RectTransform>();
		Vector2 sizeDelta = content.sizeDelta;
		sizeDelta.y = 0f;
		content.sizeDelta = sizeDelta;
	}

	public void AddAchivement(RectTransform achivement)
	{
		popups.Enqueue(achivement);
	}

	private bool PopFromQueue()
	{
		if (popups.Count > 0)
		{
			scrolling = 1;
			RectTransform rectTransform = popups.Dequeue();
			rectTransform.transform.SetParent(content, worldPositionStays: false);
			Vector2 sizeDelta = content.sizeDelta;
			sizeDelta.y += rectTransform.sizeDelta.y + content.GetComponent<VerticalLayoutGroup>().spacing;
			content.sizeDelta = sizeDelta;
			Logic.GetSound().Play("Monokanal/WhileTrueLearn_Achivement");
			return true;
		}
		return false;
	}

	private void ClearContent()
	{
		Transform[] componentsInChildren = content.GetComponentsInChildren<Transform>();
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			Object.Destroy(componentsInChildren[i].gameObject);
		}
		Vector2 sizeDelta = content.sizeDelta;
		sizeDelta.y = 0f;
		content.sizeDelta = sizeDelta;
	}

	private IEnumerator WaitAndPopDown()
	{
		yield return new WaitForSeconds(3f);
		if (scrolling == 0)
		{
			scrolling = -1;
		}
	}

	private void Update()
	{
		if (scrolling != 0 || PopFromQueue())
		{
			positionBuffer = content.anchoredPosition;
			positionBuffer.y += 2f * (float)scrolling;
			if (positionBuffer.y + 0.001f >= content.sizeDelta.y)
			{
				positionBuffer.y = content.sizeDelta.y;
				scrolling = 0;
				StartCoroutine(WaitAndPopDown());
			}
			else if (positionBuffer.y - 0.001f <= 0f)
			{
				positionBuffer.y = 0f;
				scrolling = 0;
				ClearContent();
			}
			content.anchoredPosition = positionBuffer;
		}
	}
}
