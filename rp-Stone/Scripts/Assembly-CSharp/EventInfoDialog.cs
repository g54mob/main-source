using System;
using System.Collections.Generic;
using UnityEngine;

public class EventInfoDialog : MonoBehaviour
{
	private const string PLAYER_PREFS_KEY_FTUE_NEXT = "event_carousel_next_pressed";

	public int PositionX;

	public int PositionY;

	public AsciiSprite bgTop;

	public AsciiSprite bgBottom;

	public ScrollContainer currentContainer;

	public CountdownClockUI currentClock;

	public ScrollContainer lastContainer;

	public CountdownClockUI lastClock;

	public AsciiStringRow prototypeRow;

	public AsciiSpriteRow asciiSpriteRow;

	public HyperlinkButton hyperlinkRow;

	public DialogButton nextButton;

	public DialogButton nextButtonFTUE;

	public DialogButton prevButton;

	public DialogNineSlice pageIndexIndicator;

	private bool showNextButtonFTUE = true;

	public int maxPages;

	private int totalPages;

	private int pageIndex;

	private int lastPageIndex;

	private int lastPositionY;

	private int currentPositionY;

	public float transitionDuration;

	private float transitionTimer;

	public float automaticTransitionActiveEvent;

	public float automaticTransitionInterval;

	private float automaticTransitionTimer;

	private bool automaticTransitionEnabled = true;

	private List<AsciiStringRow> _rows = new List<AsciiStringRow>();

	private Stack<AsciiStringRow> rowPool = new Stack<AsciiStringRow>();

	private List<HyperlinkButton> _hyperlinkButtons = new List<HyperlinkButton>();

	private Stack<HyperlinkButton> hyperlinkPool = new Stack<HyperlinkButton>();

	private List<AsciiObject> _customRows = new List<AsciiObject>();

	private int initialContainerHeight;

	private int initialDialogPosY;

	private string lastLanguage;

	private bool isActiveEvent;

	private List<EventController.EventData> eventList;

	private EventController.EventData currentEvent;

	private EventController.EventData lastEvent;

	private int lastDay;

	private float xCoefficient = 0.125f;

	private float yCoefficient = -0.08f;

	private float timeOffset = -2.1f;

	private float velocity = 4.1f;

	private float sheenElapsedTime;

	private float sheenDelay = 1f;

	private float sheenDuration = 2f;

	private string[] AVAILABLE_MONTH_TIDs = new string[13]
	{
		"", "tid_info_available_jan", "tid_info_available_feb", "tid_info_available_mar", "tid_info_available_apr", "tid_info_available_may", "tid_info_available_jun", "tid_info_available_jul", "tid_info_available_aug", "tid_info_available_sep",
		"tid_info_available_oct", "tid_info_available_nov", "tid_info_available_dec"
	};

	private string[] EVENT_BEGIN_MONTH_TIDs = new string[13]
	{
		"", "tid_info_event_begin_jan", "tid_info_event_begin_feb", "tid_info_event_begin_mar", "tid_info_event_begin_apr", "tid_info_event_begin_may", "tid_info_event_begin_jun", "tid_info_event_begin_jul", "tid_info_event_begin_aug", "tid_info_event_begin_sep",
		"tid_info_event_begin_oct", "tid_info_event_begin_nov", "tid_info_event_begin_dec"
	};

	public void UpdateContents()
	{
		eventList = EventController.singleton.GetEventList(maxPages);
		totalPages = eventList.Count;
		pageIndex = Math.Clamp(pageIndex, 0, Math.Max(0, totalPages - 1));
		lastPageIndex = Math.Clamp(lastPageIndex, 0, Math.Max(0, totalPages - 1));
		currentEvent = ((eventList.Count > 0) ? eventList[pageIndex] : null);
		lastEvent = ((eventList.Count > 0) ? eventList[lastPageIndex] : null);
		if (currentEvent == null)
		{
			return;
		}
		PlayMusic(currentEvent);
		if (currentEvent.info.Length == 0)
		{
			currentEvent = null;
			return;
		}
		lastContainer.Clear();
		currentContainer.Clear();
		RecycleRows();
		RecycleHyperlinks();
		CleanupCustomRows();
		lastLanguage = Te.id;
		isActiveEvent = !currentEvent.id.StartsWith("pre_") && EventSchedules.singleton.IsEventActive(currentEvent.id);
		pageIndexIndicator.Width = totalPages + 2;
		for (int i = 0; i < currentEvent.info.Length; i++)
		{
			string entry = currentEvent.info[i];
			AddEntry(currentContainer, currentEvent, entry);
		}
		if (ShowTimeRemaining(currentEvent))
		{
			DateTime now = DateTime.Now;
			DateTime dateTimeStart = EventSchedules.singleton.GetDateTimeStart(currentEvent.id);
			if (!currentEvent.id.StartsWith("pre_") && now < dateTimeStart)
			{
				currentClock.Setup(dateTimeStart);
			}
			else
			{
				DateTime dateTimeEnd = EventSchedules.singleton.GetDateTimeEnd(currentEvent.id);
				currentClock.Setup(dateTimeEnd);
			}
		}
		if (currentContainer.totalContentLength >= initialContainerHeight)
		{
			currentPositionY = initialDialogPosY;
		}
		else
		{
			currentPositionY = initialDialogPosY + initialContainerHeight - currentContainer.totalContentLength;
		}
		if (lastEvent == null)
		{
			return;
		}
		for (int j = 0; j < lastEvent.info.Length; j++)
		{
			string entry2 = lastEvent.info[j];
			AddEntry(lastContainer, lastEvent, entry2);
		}
		if (ShowTimeRemaining(lastEvent))
		{
			DateTime now2 = DateTime.Now;
			DateTime dateTimeStart2 = EventSchedules.singleton.GetDateTimeStart(lastEvent.id);
			if (!lastEvent.id.StartsWith("pre_") && now2 < dateTimeStart2)
			{
				lastClock.Setup(dateTimeStart2);
			}
			else
			{
				DateTime dateTimeEnd2 = EventSchedules.singleton.GetDateTimeEnd(lastEvent.id);
				lastClock.Setup(dateTimeEnd2);
			}
		}
		if (lastContainer.totalContentLength >= initialContainerHeight)
		{
			lastContainer.Height = initialContainerHeight;
			lastPositionY = initialDialogPosY;
		}
		else
		{
			lastContainer.Height = lastContainer.totalContentLength;
			lastPositionY = initialDialogPosY + initialContainerHeight - lastContainer.totalContentLength;
		}
	}

	private void AddEntry(ScrollContainer container, EventController.EventData eventData, string entry)
	{
		if (string.IsNullOrEmpty(entry))
		{
			AddText(container, "");
			return;
		}
		if (entry.StartsWith("?"))
		{
			int num = entry.IndexOf(':');
			if (num < 0)
			{
				return;
			}
			string condition = entry.Substring(1, num - 1);
			if (!EvaluateCondition(eventData, condition))
			{
				return;
			}
			if (num >= entry.Length - 1)
			{
				AddText(container, "");
				return;
			}
			entry = entry.Substring(num + 1);
		}
		if (entry.StartsWith("sprite:"))
		{
			AddSprite(container, entry.Substring(7), eventData.id);
		}
		else if (entry.StartsWith("title:"))
		{
			AddTitle(container, entry.Substring(6));
		}
		else if (entry.StartsWith("url:"))
		{
			int num2 = entry.LastIndexOf(':');
			string url = entry.Substring(4, num2 - 4);
			string msg = entry.Substring(num2 + 1);
			AddHyperlink(container, url, msg);
		}
		else if (entry.StartsWith("custom:"))
		{
			AddCustom(container, entry.Substring(7));
		}
		else if (entry == "start_date")
		{
			AddAvailableDate(container, eventData, AVAILABLE_MONTH_TIDs);
		}
		else if (entry == "event_begin_date")
		{
			AddAvailableDate(container, eventData, EVENT_BEGIN_MONTH_TIDs);
		}
		else
		{
			AddText(container, entry);
		}
	}

	private bool EvaluateCondition(EventController.EventData eventData, string condition)
	{
		switch (condition)
		{
		case "true":
			return true;
		case "false":
			return false;
		case "hasPremium":
			return EventController.singleton.GetEventController(eventData.id)?.HasPremiumAccess() ?? true;
		default:
			if (condition.StartsWith("!"))
			{
				condition = condition.Substring(1);
				return !EvaluateCondition(eventData, condition);
			}
			if (condition.Contains("|"))
			{
				int num = condition.IndexOf("|");
				string condition2 = condition.Substring(0, num);
				string condition3 = condition.Substring(num + 1);
				if (!EvaluateCondition(eventData, condition2))
				{
					return EvaluateCondition(eventData, condition3);
				}
				return true;
			}
			if (condition.Contains("&"))
			{
				int num2 = condition.IndexOf("&");
				string condition4 = condition.Substring(0, num2);
				string condition5 = condition.Substring(num2 + 1);
				if (EvaluateCondition(eventData, condition4))
				{
					return EvaluateCondition(eventData, condition5);
				}
				return false;
			}
			if (condition.Contains("="))
			{
				int num3 = condition.IndexOf("=");
				string text = condition.Substring(0, num3);
				string text2 = condition.Substring(num3 + 1);
				switch (text)
				{
				case "part":
					return Utils.ParseInt(text2) == EventController.singleton.GetEventPart(eventData.id);
				case "lang":
					return text2 == Te.id;
				case "os":
					return text2 == DiagnosticsUI.GetOperatingSystemGlyph();
				}
			}
			if (condition.Contains("!"))
			{
				int num4 = condition.IndexOf("!");
				string text3 = condition.Substring(0, num4);
				string text4 = condition.Substring(num4 + 1);
				switch (text3)
				{
				case "part":
					return Utils.ParseInt(text4) != EventController.singleton.GetEventPart(eventData.id);
				case "lang":
					return text4 != Te.id;
				case "os":
					return text4 != DiagnosticsUI.GetOperatingSystemGlyph();
				}
			}
			if (condition.Contains(">"))
			{
				int num5 = condition.IndexOf(">");
				string text5 = condition.Substring(0, num5);
				string str = condition.Substring(num5 + 1);
				if (text5 == "part")
				{
					int num6 = Utils.ParseInt(str);
					return EventController.singleton.GetEventPart(eventData.id) > num6;
				}
			}
			if (condition.Contains("<"))
			{
				int num7 = condition.IndexOf("<");
				string text6 = condition.Substring(0, num7);
				string str2 = condition.Substring(num7 + 1);
				if (text6 == "part")
				{
					int num8 = Utils.ParseInt(str2);
					return EventController.singleton.GetEventPart(eventData.id) < num8;
				}
			}
			return false;
		}
	}

	public void UpdateTic()
	{
		lastContainer.UpdateTic();
		lastClock.UpdateTic();
		currentContainer.UpdateTic();
		currentClock.UpdateTic();
		prevButton.UpdateTic();
		if (showNextButtonFTUE)
		{
			nextButtonFTUE.UpdateTic();
		}
		nextButton.UpdateTic();
		pageIndexIndicator.UpdateTic();
		int day = DateTime.Now.Day;
		if (lastDay != day || (ShowTimeRemaining(currentEvent) & (GetTimeRemaining(currentEvent) <= 0.0)))
		{
			lastDay = day;
			UpdateContents();
		}
		else if (currentEvent != null && lastLanguage != null && lastLanguage != Te.id)
		{
			UpdateContents();
		}
	}

	private double GetTimeRemaining(EventController.EventData eventData)
	{
		if (eventData != null && ShowTimeRemaining(eventData))
		{
			return (EventSchedules.singleton.GetDateTimeEnd(eventData.id) - DateTime.Now).TotalSeconds;
		}
		return 0.0;
	}

	private bool ShowTimeRemaining(EventController.EventData eventData)
	{
		return eventData?.showTimeRemaining ?? true;
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentEvent == null || currentContainer.Height == 0)
		{
			return;
		}
		offsetX += PositionX;
		offsetY += PositionY;
		int num = r.width - 1 - (offsetX + bgTop.width);
		if (num < 0)
		{
			offsetX += num;
		}
		for (int i = -1; i < currentContainer.Width + 2; i++)
		{
			for (int j = 0; j < currentContainer.Height; j++)
			{
				r.SetCell(i + offsetX + currentContainer.PositionX, j + offsetY + currentContainer.PositionY, ' ', ColorConstants.darkGrey);
			}
		}
		bgTop.Draw(r, offsetX, offsetY);
		bgBottom.Draw(r, offsetX, offsetY + currentContainer.PositionY + currentContainer.Height);
		if (totalPages >= 2)
		{
			if (pageIndex > 0)
			{
				prevButton.Draw(r, offsetX + 3, offsetY + currentContainer.PositionY + currentContainer.Height + 1);
			}
			if (pageIndex < totalPages - 1)
			{
				if (showNextButtonFTUE)
				{
					nextButtonFTUE.Draw(r, offsetX + currentContainer.Width - 8, offsetY + currentContainer.PositionY + currentContainer.Height + 1);
				}
				else
				{
					nextButton.Draw(r, offsetX + currentContainer.Width - 8, offsetY + currentContainer.PositionY + currentContainer.Height + 1);
				}
			}
		}
		if (totalPages > 1)
		{
			pageIndexIndicator.Draw(r, offsetX + currentContainer.Width / 2 - totalPages / 2, offsetY + currentContainer.PositionY + currentContainer.Height + 1);
		}
		DrawSheen(r, offsetX, offsetY);
		if (totalPages > 1)
		{
			r.SetCell(offsetX + currentContainer.Width / 2 - totalPages / 2 + pageIndex + 1, offsetY + currentContainer.PositionY + currentContainer.Height + 2, '•', ColorConstants.white);
		}
		if (pageIndex != lastPageIndex)
		{
			lastContainer.HideScrollbar();
			currentContainer.HideScrollbar();
			AsciiRenderProcedural.Clip c = new AsciiRenderProcedural.Clip
			{
				left = offsetX + currentContainer.PositionX,
				right = r.width - (offsetX + currentContainer.PositionX + currentContainer.Width + 2),
				top = offsetY + currentContainer.PositionY,
				bottom = r.height - (offsetY + currentContainer.PositionY + currentContainer.Height)
			};
			AsciiRenderProcedural.Clip c2 = new AsciiRenderProcedural.Clip
			{
				left = offsetX + currentContainer.PositionX + 11,
				right = r.width - (offsetX + currentContainer.PositionX + currentContainer.Width - 9),
				top = offsetY + currentContainer.PositionY + currentContainer.Height,
				bottom = r.height - (offsetY + currentContainer.PositionY + currentContainer.Height + 1)
			};
			int num2 = (int)Mathf.Round((float)currentContainer.Width * transitionTimer);
			int num3 = ((lastPageIndex > pageIndex) ? num2 : (-num2));
			r.PushClip(c, computeIntersection: false);
			lastContainer.Draw(r, offsetX + num3, offsetY + lastPositionY - PositionY);
			r.PopClip();
			if (ShowTimeRemaining(lastEvent))
			{
				r.PushClip(c2, computeIntersection: false);
				lastClock.Draw(r, offsetX + num3, offsetY + currentContainer.PositionY + currentContainer.Height);
				r.PopClip();
			}
			int num4 = ((lastPageIndex > pageIndex) ? (num2 - currentContainer.Width) : (-(num2 - currentContainer.Width)));
			r.PushClip(c, computeIntersection: false);
			currentContainer.Draw(r, offsetX + num4, offsetY + currentPositionY - PositionY);
			r.PopClip();
			if (ShowTimeRemaining(currentEvent))
			{
				r.PushClip(c2, computeIntersection: false);
				currentClock.Draw(r, offsetX + num4, offsetY + currentContainer.PositionY + currentContainer.Height);
				r.PopClip();
			}
		}
		else
		{
			lastContainer.ShowScrollbar();
			currentContainer.ShowScrollbar();
			currentContainer.Draw(r, offsetX, offsetY);
			if (ShowTimeRemaining(currentEvent))
			{
				currentClock.Draw(r, offsetX, offsetY + currentContainer.PositionY + currentContainer.Height);
			}
		}
	}

	private void Update()
	{
		if (GameStates.Singleton.CurrentState != GameStates.State.MainMenu)
		{
			return;
		}
		UpdateSheen(Time.deltaTime);
		int height = currentContainer.Height;
		if (pageIndex != lastPageIndex)
		{
			transitionTimer += Time.deltaTime / transitionDuration;
			if (transitionTimer >= 1f)
			{
				lastPageIndex = pageIndex;
				transitionTimer = 0f;
			}
			else
			{
				int num = ((lastContainer.totalContentLength >= initialContainerHeight) ? initialDialogPosY : (initialDialogPosY + initialContainerHeight - lastContainer.totalContentLength));
				int num2 = ((currentContainer.totalContentLength >= initialContainerHeight) ? initialDialogPosY : (initialDialogPosY + initialContainerHeight - currentContainer.totalContentLength));
				PositionY = (int)Math.Round(Mathf.Lerp(num, num2, 1f - Mathf.Pow(1f - transitionTimer, 3f)));
				int num3 = ((lastContainer.totalContentLength >= initialContainerHeight) ? initialContainerHeight : lastContainer.totalContentLength);
				int num4 = ((currentContainer.totalContentLength >= initialContainerHeight) ? initialContainerHeight : currentContainer.totalContentLength);
				currentContainer.Height = (int)Math.Round(Mathf.Lerp(num3, num4, 1f - Mathf.Pow(1f - transitionTimer, 3f)));
			}
		}
		else
		{
			transitionTimer = 0f;
			if (currentContainer.totalContentLength >= initialContainerHeight)
			{
				currentContainer.Height = initialContainerHeight;
				PositionY = initialDialogPosY;
			}
			else
			{
				currentContainer.Height = currentContainer.totalContentLength;
				PositionY = initialDialogPosY + initialContainerHeight - currentContainer.totalContentLength;
			}
		}
		if (currentContainer.Height != height)
		{
			currentContainer.RefreshPrecompute();
		}
		if (automaticTransitionEnabled && transitionTimer <= 0f && totalPages >= 2)
		{
			float num5 = (isActiveEvent ? automaticTransitionActiveEvent : automaticTransitionInterval);
			if (automaticTransitionTimer >= num5)
			{
				pageIndex = (pageIndex + 1) % totalPages;
				automaticTransitionTimer = 0f;
				UpdateContents();
			}
			else
			{
				automaticTransitionTimer += Time.deltaTime;
			}
		}
	}

	private void InitSheen()
	{
		sheenElapsedTime = 0f - sheenDelay;
	}

	private void UpdateSheen(float deltaTime)
	{
		if (GameStates.Singleton.CurrentState == GameStates.State.MainMenu)
		{
			sheenElapsedTime += deltaTime;
		}
	}

	private void DrawSheen(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!(sheenElapsedTime > sheenDuration) && !(sheenElapsedTime < 0f))
		{
			DrawSheen(bgTop, r, bgTop.lastDrawX, bgTop.lastDrawY);
			DrawSheen(bgBottom, r, bgBottom.lastDrawX, bgBottom.lastDrawY);
			if (showNextButtonFTUE)
			{
				DrawSheen(nextButtonFTUE, r, nextButtonFTUE.lastDrawX, nextButtonFTUE.lastDrawY);
			}
			else
			{
				DrawSheen(nextButton, r, nextButton.lastDrawX, nextButton.lastDrawY);
			}
			DrawSheen(prevButton, r, prevButton.lastDrawX, prevButton.lastDrawY);
			DrawSheen(pageIndexIndicator, r, pageIndexIndicator.lastDrawX, pageIndexIndicator.lastDrawY);
		}
	}

	private void DrawSheen(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		float p = 15f;
		float num = 1.2f;
		float t = 0.8f;
		float num2 = sheenElapsedTime * velocity;
		int[][] dataWithFlips = sprite.GetCurrentPage().GetDataWithFlips();
		for (int i = 0; i < dataWithFlips.Length; i++)
		{
			for (int j = 0; j < dataWithFlips[i].Length; j++)
			{
				if (dataWithFlips[i][j] == -1)
				{
					continue;
				}
				int num3 = i + offsetX;
				int num4 = j + offsetY;
				AsciiCellProcedural cell = r.GetCell(num3, num4);
				if (cell != null)
				{
					Color colorOverride = sprite.colorOverride;
					float num5 = num2 + timeOffset + (float)num3 * xCoefficient + (float)num4 * yCoefficient - MathF.PI * 2f;
					float num6 = ((num5 >= 0f && num5 <= MathF.PI) ? Mathf.Pow(Mathf.Sin(num5), p) : 0f);
					if (float.IsNaN(num6))
					{
						num6 = 0f;
					}
					num6 *= num;
					Color b = Color.Lerp(colorOverride * (num6 + 1f), ColorConstants.white, t);
					colorOverride = Color.Lerp(colorOverride, b, num6);
					cell.SetForeground(colorOverride);
				}
			}
		}
	}

	private void DrawSheen(DialogNineSlice sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		float p = 15f;
		float num = 1.2f;
		float t = 0.8f;
		float num2 = sheenElapsedTime * velocity;
		for (int i = 0; i < sprite.Width; i++)
		{
			for (int j = 0; j < sprite.Height; j++)
			{
				int num3 = i + offsetX;
				int num4 = j + offsetY;
				AsciiCellProcedural cell = r.GetCell(num3, num4);
				if (cell != null)
				{
					Color foregroundColor = cell.foregroundColor;
					float num5 = num2 + timeOffset + (float)num3 * xCoefficient + (float)num4 * yCoefficient - MathF.PI * 2f;
					float num6 = ((num5 >= 0f && num5 <= MathF.PI) ? Mathf.Pow(Mathf.Sin(num5), p) : 0f);
					if (float.IsNaN(num6))
					{
						num6 = 0f;
					}
					num6 *= num;
					Color b = Color.Lerp(foregroundColor * (num6 + 1f), ColorConstants.white, t);
					foregroundColor = Color.Lerp(foregroundColor, b, num6);
					cell.SetForeground(foregroundColor);
				}
			}
		}
	}

	private void AddText(ScrollContainer container, string tid)
	{
		List<string> list = null;
		while (true)
		{
			int num = tid.LastIndexOf('{');
			if (num <= 0)
			{
				break;
			}
			int num2 = tid.IndexOf('}', num + 1);
			if (num2 <= num)
			{
				break;
			}
			string text = tid.Substring(num + 1, num2 - num - 1);
			if (text.StartsWith("tid_"))
			{
				text = Te.xt(text);
			}
			if (list == null)
			{
				list = new List<string>();
			}
			list.Insert(0, text);
			tid = tid.Substring(0, num);
		}
		string text2 = ((!tid.StartsWith("tid_")) ? tid : Te.xt(tid));
		if (list != null)
		{
			string format = text2;
			object[] args = list.ToArray();
			text2 = string.Format(format, args);
		}
		string[] lines = Utils.BreakIntoLines(text2, container.Width);
		AddText(container, lines);
	}

	private void AddText(ScrollContainer container, string[] lines)
	{
		int positionX = container.Width / 2;
		foreach (string text in lines)
		{
			AsciiStringRow asciiStringRow = NewRow();
			asciiStringRow.text = text;
			asciiStringRow.asciiString.PositionX = positionX;
			container.AddRow(asciiStringRow);
			_rows.Add(asciiStringRow);
		}
	}

	private AsciiStringRow InstantiateNewLine()
	{
		AsciiStringRow asciiStringRow = UnityEngine.Object.Instantiate(prototypeRow);
		asciiStringRow.transform.parent = base.transform;
		return asciiStringRow;
	}

	private AsciiStringRow NewRow()
	{
		AsciiStringRow asciiStringRow;
		if (rowPool.Count > 0)
		{
			asciiStringRow = rowPool.Pop();
			asciiStringRow.Clear();
		}
		else
		{
			asciiStringRow = InstantiateNewLine();
		}
		return asciiStringRow;
	}

	private void RecycleRows()
	{
		for (int i = 0; i < _rows.Count; i++)
		{
			rowPool.Push(_rows[i]);
		}
		_rows.Clear();
	}

	private void AddSprite(ScrollContainer container, string prefabPath, string eventId)
	{
		GameObject gameObject = Utils.InstantiatePrefab(prefabPath);
		if (gameObject != null)
		{
			AsciiSprite component = gameObject.GetComponent<AsciiSprite>();
			AsciiSpriteRow asciiSpriteRow = UnityEngine.Object.Instantiate(this.asciiSpriteRow);
			asciiSpriteRow.sprite = component;
			component.pivotX -= container.Width / 2;
			container.AddRow(asciiSpriteRow);
			_customRows.Add(asciiSpriteRow);
			EnchantBonusEventRewardSprite enchantBonusEventRewardSprite = component as EnchantBonusEventRewardSprite;
			if (enchantBonusEventRewardSprite != null)
			{
				enchantBonusEventRewardSprite.eventId = eventId;
			}
		}
	}

	private void AddTitle(ScrollContainer container, string tid)
	{
		string tid2 = "\n▶ " + Te.xt(tid) + " ◀";
		AddText(container, tid2);
	}

	private void AddCustom(ScrollContainer container, string prefabPath)
	{
		GameObject gameObject = Utils.InstantiatePrefab(prefabPath);
		if (gameObject != null)
		{
			AsciiObject component = gameObject.GetComponent<AsciiObject>();
			if (component != null)
			{
				container.AddRow(component);
				_customRows.Add(component);
			}
		}
	}

	private void CleanupCustomRows()
	{
		foreach (AsciiObject customRow in _customRows)
		{
			UnityEngine.Object.Destroy(customRow.gameObject);
		}
		_customRows.Clear();
	}

	private void AddHyperlink(ScrollContainer container, string url, string msg)
	{
		HyperlinkButton hyperlinkButton = NewHyperlink();
		hyperlinkButton.url = url;
		if (msg.StartsWith("tid_"))
		{
			msg = Te.xt(msg);
		}
		int num = (hyperlinkButton.Width = msg.Length + 2);
		hyperlinkButton.PositionX = (container.Width - num) / 2;
		hyperlinkButton.label.SetValue(msg);
		hyperlinkButton.label.PositionX = num / 2;
		container.AddRow(hyperlinkButton);
		_hyperlinkButtons.Add(hyperlinkButton);
	}

	private HyperlinkButton NewHyperlink()
	{
		if (hyperlinkPool.Count > 0)
		{
			return hyperlinkPool.Pop();
		}
		return UnityEngine.Object.Instantiate(hyperlinkRow);
	}

	private void RecycleHyperlinks()
	{
		for (int i = 0; i < _hyperlinkButtons.Count; i++)
		{
			hyperlinkPool.Push(_hyperlinkButtons[i]);
		}
		_hyperlinkButtons.Clear();
	}

	private void AddAvailableDate(ScrollContainer container, EventController.EventData eventData, string[] monthTIDs)
	{
		if (eventData != null)
		{
			string eventId = eventData.id.Substring(4);
			EventSchedules.Schedule schedule = EventSchedules.singleton.GetSchedule(eventId);
			if (schedule != null)
			{
				DateTime dateTimeStart = schedule.GetDateTimeStart();
				int num = Mathf.Clamp(dateTimeStart.Month, 1, 12);
				string inStr = monthTIDs[num];
				inStr = Te.xt(inStr);
				inStr = string.Format(inStr, dateTimeStart.Day);
				AddText(container, inStr);
			}
		}
	}

	private void PlayMusic(EventController.EventData eventData)
	{
		if (eventData != null && !string.IsNullOrEmpty(eventData.music) && (MusicController.singleton.currentMusic == null || MusicController.singleton.currentMusic.id != eventData.music))
		{
			MusicController.singleton.Play(eventData.music);
		}
	}

	private void HandlePagePrev(DialogButton btn)
	{
		if (!(transitionTimer > 0f) && totalPages >= 2)
		{
			automaticTransitionEnabled = false;
			pageIndex--;
			if (pageIndex < 0)
			{
				pageIndex = 0;
			}
			UpdateContents();
		}
	}

	private void HandlePageNext(DialogButton btn)
	{
		if (!(transitionTimer > 0f) && totalPages >= 2)
		{
			automaticTransitionEnabled = false;
			pageIndex++;
			if (pageIndex >= totalPages)
			{
				pageIndex = totalPages - 1;
			}
			UpdateContents();
		}
	}

	private void HandlePageNextFTUE(DialogButton btn)
	{
		if (showNextButtonFTUE)
		{
			PlayerPrefs.SetInt("event_carousel_next_pressed", 1);
			showNextButtonFTUE = false;
			nextButtonFTUE.ClearOnPressed();
			HandlePageNext(btn);
		}
	}

	private void Awake()
	{
		bgTop.Load();
		bgBottom.Load();
		prevButton.OnPressed += HandlePagePrev;
		nextButton.OnPressed += HandlePageNext;
		nextButtonFTUE.OnPressed += HandlePageNextFTUE;
		initialContainerHeight = currentContainer.Height;
		initialDialogPosY = PositionY;
		hyperlinkPool.Push(hyperlinkRow);
		if (!PlayerPrefs.HasKey("event_carousel_next_pressed") || PlayerPrefs.GetInt("event_carousel_next_pressed") == 0)
		{
			showNextButtonFTUE = true;
		}
		else
		{
			showNextButtonFTUE = false;
		}
		InitSheen();
	}
}
