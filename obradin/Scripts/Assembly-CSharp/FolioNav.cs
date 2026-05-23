using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Folio))]
public class FolioNav : MonoBehaviour
{
	private struct LostFocus
	{
		public bool lost;

		public Vector2 cursorPos;
	}

	public Image cursorImage;

	private Folio folio;

	private RectTransform holderRt;

	private int hideCursorUntilFrame;

	private Book book;

	private Canvas canvas;

	private PageItem pageItem;

	private PageTemplate pageTemplate;

	private UiDitherHelper uiDitherHelper;

	private RectTransform rt;

	private float cursorWiggleDuration;

	private const float kCursorWiggleDurationMax = 0.4f;

	private LostFocus lostFocus = default(LostFocus);

	public const float kWindowEdge = 80f;

	public const float kWheelScrollPixelsPerSecond = 300f;

	private static FolioNav it;

	public static void HideForOneFrame()
	{
		if (it != null)
		{
			it.hideCursorUntilFrame = Time.frameCount + 1;
			it.cursorImage.enabled = false;
		}
	}

	private void Awake()
	{
		book = GetComponentInParent<Book>();
		canvas = GetComponentInParent<Canvas>();
		uiDitherHelper = GetComponentInParent<UiDitherHelper>();
		rt = base.transform as RectTransform;
	}

	private void OnEnable()
	{
		if (folio == null)
		{
			folio = GetComponent<Folio>();
			holderRt = base.transform.parent as RectTransform;
			pageItem = GetComponent<PageItem>();
			pageTemplate = GetComponentInParent<PageTemplate>();
		}
		lostFocus.lost = false;
		hideCursorUntilFrame = Time.frameCount + 1;
		cursorImage.enabled = false;
		cursorWiggleDuration = 0.4f;
		it = this;
	}

	private void OnDisable()
	{
		if (it == this)
		{
			it = null;
		}
	}

	private void Update()
	{
		if (!pageTemplate.interactable)
		{
			return;
		}
		if (lostFocus.lost)
		{
			MouseCursor.SetPosInTransform(base.transform, lostFocus.cursorPos);
			lostFocus.lost = false;
			cursorWiggleDuration = 0.4f;
		}
		MouseCursor.HideForOneFrame();
		RInput.EnableControllerMouseForOneFrame();
		if (Time.frameCount > hideCursorUntilFrame)
		{
			cursorImage.enabled = true;
		}
		float delta = -300f * Clock.menu.deltaTime * Mathf.Clamp(RInput.GetAxis(49) + RInput.GetAxis(37) - RInput.GetAxis(38), -1f, 1f);
		ApplyWheelMovement(delta);
		ApplyCursorMovement();
		Vector2 posInTransform = MouseCursor.GetPosInTransform(base.transform);
		Vector2 anchoredPosition = new Vector2(Mathf.RoundToInt(posInTransform.x), Mathf.RoundToInt(posInTransform.y));
		if (cursorWiggleDuration > 0f && !Monitor.blackingOut)
		{
			cursorWiggleDuration = Mathf.Max(0f, cursorWiggleDuration - Mathf.Min(0.1f, Clock.menu.deltaTime));
			anchoredPosition.x += 3f * Mathf.Sin(cursorWiggleDuration / 0.4f * 8f * (float)Math.PI);
		}
		cursorImage.rectTransform.anchoredPosition = anchoredPosition;
		FolioPin pinUnder = folio.GetPinUnder(new Vector2(posInTransform.x, 0f - posInTransform.y));
		if (pinUnder != null)
		{
			book.SetSelection(pinUnder.spec.id, canvas.transform.worldToLocalMatrix.MultiplyPoint(pinUnder.transform.position));
			if ((RInput.GetButtonDown(17) || (RInput.mouseIsActive && RInput.GetButtonDown(44))) && pageItem.buttonSettings.actionId.HasValue())
			{
				book.OnFolioPinClicked(pageItem, pinUnder.spec);
				if (!pageTemplate.interactable)
				{
					lostFocus.lost = true;
					lostFocus.cursorPos = posInTransform;
				}
			}
		}
		else
		{
			book.ClearSelection();
		}
	}

	private void ApplyCursorMovement()
	{
		float height = holderRt.rect.height;
		float y = rt.anchoredPosition.y;
		float y2 = y;
		float num = height / 2f - 80f;
		float num2 = 0f - (height / 2f - 80f);
		Vector2 posInCanvas = MouseCursor.GetPosInCanvas();
		if (posInCanvas.y > num)
		{
			y2 = Mathf.Max(0f - folio.extraBorder, y - (posInCanvas.y - num));
		}
		if (posInCanvas.y < num2)
		{
			y2 = Mathf.Min(folio.spec.size.y * rt.localScale.y - height + folio.extraBorder, y + (num2 - posInCanvas.y));
		}
		rt.anchoredPosition = new Vector2(0f, y2);
		uiDitherHelper.QuantizeAndMatchAnchoredPosition(rt);
		y2 = rt.anchoredPosition.y;
		posInCanvas.y += y2 - y;
		MouseCursor.SetPosInCanvas(posInCanvas);
	}

	private void ApplyWheelMovement(float delta)
	{
		if (delta != 0f)
		{
			float height = holderRt.rect.height;
			float y = rt.anchoredPosition.y;
			y = Mathf.Max(0f - folio.extraBorder, Mathf.Min(folio.spec.size.y - height + folio.extraBorder, y + delta));
			rt.anchoredPosition = new Vector2(0f, y);
			uiDitherHelper.QuantizeAndMatchAnchoredPosition(rt);
		}
	}

	public void SetFocusInFolio(Vector2 pos)
	{
		if (uiDitherHelper != null)
		{
			Vector2 vector = uiDitherHelper.QuantizeAndMatchAnchoredPosition(rt);
			pos += vector;
		}
		MouseCursor.SetPosInTransform(folio.transform, new Vector2(pos.x, 0f - pos.y));
	}
}
