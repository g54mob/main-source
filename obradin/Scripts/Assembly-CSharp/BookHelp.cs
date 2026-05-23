using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookHelp : MonoBehaviour
{
	[Serializable]
	public class CustomRect
	{
		public string id;

		public RectTransform rectTransform;
	}

	public enum Side
	{
		OnLeft = 0,
		OnRight = 1,
		Above = 2,
		Below = 3
	}

	public Text text;

	public RectTransform focusRect;

	public List<CustomRect> customRects;

	public ShuffleAudioClips shuffledAudioClips;

	[Readonly]
	public RectTransform rt;

	[Readonly]
	public RectTransform textRt;

	private Rect segmentRect0;

	private Rect segmentRect1;

	private Vector3[] corners = new Vector3[4]
	{
		default(Vector3),
		default(Vector3),
		default(Vector3),
		default(Vector3)
	};

	public float segmentT
	{
		set
		{
			Rect rect = Lerp(segmentRect0, segmentRect1, Util.SmoothStepEdges(0f, 1f, value));
			focusRect.anchoredPosition = rect.center;
			focusRect.sizeDelta = rect.size;
			focusRect.gameObject.SetActive(true);
		}
	}

	public void InitShow()
	{
		segmentRect0 = new Rect(0f, 0f, 0f, 0f);
		segmentRect0.size = new Vector2(Resolution.bufferW, Resolution.bufferH);
		segmentRect0.center = Vector2.zero;
		segmentRect1 = segmentRect0;
		text.text = string.Empty;
		focusRect.anchoredPosition = Vector2.zero;
		focusRect.sizeDelta = segmentRect0.size;
		focusRect.gameObject.SetActive(false);
		base.gameObject.SetActive(true);
	}

	public void PlayNextAudioClip()
	{
		AudioOneShot.Play(shuffledAudioClips.next, false, 0.5f);
	}

	public void StartSegment(PageTemplate pageTemplate, string message, Side messageSide, string rectName, float rectExpand)
	{
		segmentRect0 = segmentRect1;
		if (rectName.HasValue())
		{
			segmentRect1 = GetRect(pageTemplate, rectName, rectExpand);
		}
		else
		{
			segmentRect1 = segmentRect0;
		}
		if (text.text != message)
		{
			text.text = message;
		}
		PositionText(segmentRect1, messageSide);
	}

	public void StartSkip(PageTemplate pageTemplate)
	{
		PlayNextAudioClip();
		StartSegment(pageTemplate, "...", Side.Above, "@skipping", 0f);
		segmentT = 1f;
	}

	private void PositionText(Rect f, Side side)
	{
		Rect rect = new Rect(0f, 0f, 0f, 0f);
		rect.size = new Vector2((float)Resolution.bufferW - 160f, (float)Resolution.bufferH - 4f);
		rect.center = Vector2.zero;
		switch (side)
		{
		case Side.OnLeft:
			rect.xMax = f.xMin - 20f;
			text.alignment = TextAnchor.MiddleRight;
			break;
		case Side.OnRight:
			rect.xMin = f.xMax + 20f;
			text.alignment = TextAnchor.MiddleLeft;
			break;
		case Side.Above:
			rect.yMin = f.yMax + 20f;
			text.alignment = TextAnchor.LowerCenter;
			break;
		case Side.Below:
			rect.yMax = f.yMin - 20f;
			text.alignment = TextAnchor.UpperCenter;
			break;
		}
		textRt.anchoredPosition = rect.center;
		textRt.sizeDelta = rect.size;
	}

	private Rect GetRect(PageTemplate pageTemplate, string name, float expand)
	{
		RectTransform rectTransform = null;
		if (name.StartsWith("@"))
		{
			foreach (CustomRect customRect in customRects)
			{
				if (name == customRect.id)
				{
					rectTransform = customRect.rectTransform;
					break;
				}
			}
		}
		else
		{
			PageItem pageItem = pageTemplate.pageItemDict[name];
			rectTransform = pageItem.transform as RectTransform;
		}
		if (rectTransform == null)
		{
			throw new UnityException("Help rect not found: " + name);
		}
		rectTransform.GetWorldCorners(corners);
		Vector3 point = corners[0];
		Vector3 point2 = corners[2];
		point = rt.worldToLocalMatrix.MultiplyPoint(point);
		point2 = rt.worldToLocalMatrix.MultiplyPoint(point2);
		if (name == "@fate-editor-short")
		{
			point.y += 60f;
			point.x += 3f;
			point2.x -= 3f;
		}
		else if (name == "@fate-editor-right")
		{
			point2.y -= 40f;
			point.y += 40f;
		}
		return new Rect(point.x - expand, point.y - expand, point2.x - point.x + 2f * expand, point2.y - point.y + 2f * expand);
	}

	private static Rect Lerp(Rect a, Rect b, float t)
	{
		return new Rect(Mathf.Lerp(a.x, b.x, t), Mathf.Lerp(a.y, b.y, t), Mathf.Lerp(a.width, b.width, t), Mathf.Lerp(a.height, b.height, t));
	}
}
