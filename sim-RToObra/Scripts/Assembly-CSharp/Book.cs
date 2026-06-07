using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour, PageTemplateHost, ListHost, BookTutHost
{
	public enum State
	{
		Boot = 0,
		Normal = 1,
		InPopup = 2,
		InAnim = 3
	}

	public class BootRequest
	{
		public string watchNearMomentId;

		public string examiningFaceId;

		public void Clear()
		{
			watchNearMomentId = null;
			examiningFaceId = null;
		}
	}

	private enum BootMessage
	{
		None = 0,
		HelpZoomBook = 1,
		HelpWatchBook = 2
	}

	private enum Interactable
	{
		None = 0,
		Page = 1,
		Popup = 2
	}

	private enum RepeaterId
	{
		Left = 0,
		Right = 1,
		Back = 2
	}

	private class Repeater
	{
		public RepeaterId id;

		public int count;

		public int countMax = 3;

		public float Charge(RepeaterId id_)
		{
			if (id != id_)
			{
				count = 0;
			}
			else
			{
				count = Mathf.Min(countMax, count + 1);
			}
			id = id_;
			return Util.LerpScale(count, 0f, countMax, 0.5f, 0.1f);
		}

		public void Reset()
		{
			count = 0;
		}
	}

	private struct RevealTimings
	{
		public const float bpm = 140f;

		public const float spb = 0.42857143f;

		public const float beatDelay = 1.4142857f;

		public float waitOnDesk;

		public float waitOnFirstPage;

		public float waitOnMoment;

		public float preMusicFadeTime;

		public float chapterBleed;

		public float momentBleed;

		public float unveilGuess;

		public float disappearBleed;

		public float waitOnDisappear;
	}

	public class Snapshot
	{
		public Selectable selectable;

		public BookSpec.PageSpec pageSpec;
	}

	public List<PageTemplate> pageTemplates;

	public PageTemplate baseTemplate;

	public RectTransform pagesRootTransform;

	public RectTransform pageEdgeLTransform;

	public RectTransform pageEdgeRTransform;

	public BookAssets assets;

	public BookHelp help;

	public List<Popup> popups;

	public AudioKit audioKit;

	public Image flashImage;

	public RawImage dustImage;

	[HideInInspector]
	public List<LocalizedUi> localizedUis;

	private BookSpec bookSpec;

	private BookContent bookContent;

	private BookAction bookAction;

	private BookAnim bookAnim;

	private Bookmark bookmark;

	private BookSpec.PageSpec pageSpec;

	private BookTut bookTut;

	private FateEditor fateEditor;

	private FaceChooser faceChooser;

	private ListPanel listPanel;

	private TermDefiner termDefiner;

	private MessagePanelLogic messagePanelLogic;

	private ListPanel.OnItemSelected listOnItemSelected;

	private float clearedSelectionTime;

	private Repeater repeater = new Repeater();

	private bool blockBackUntilRelease;

	private BookSpec.PageSpec bootMomentPageSpec;

	private BootMessage bootMessage;

	private bool skipNextBagCloseSound;

	private float flashStartTime;

	private float dustStartTime;

	private bool wantHide;

	private bool wantSkipTutorial;

	private Stater<State> stater;

	private Stack<Popup> popupStack = new Stack<Popup>();

	private LinkedList<BookSpec.PageSpec> pageHistory = new LinkedList<BookSpec.PageSpec>();

	private Queue<BookAnim.Atom> atomQueue = new Queue<BookAnim.Atom>();

	private ActionGlyphNotifier glyphNotifier;

	private const float kDefaultLeafPageInterpDuration = 0.1f;

	private const float kDefaultTurnPageInterpDuration = 0.5f;

	private const float kFlashDuration = 1f;

	private const float kDustDuration = 0.5f;

	public static Book active;

	public static BootRequest bootRequest = new BootRequest();

	public bool inAnim
	{
		get
		{
			return atomQueue.Count > 0 || IsInState(State.InAnim);
		}
	}

	public Popup topPopup
	{
		get
		{
			return (popupStack.Count <= 0) ? null : popupStack.Peek();
		}
	}

	public static bool canClose
	{
		get
		{
			return active == null || (!active.inAnim && !active.bookTut.running && SaveData.it.generalRo.bookVisitedLastPage && !active.flashing);
		}
	}

	public PageTemplate topActivePageTemplate
	{
		get
		{
			if (topPopup != null && topPopup.pageTemplate != null)
			{
				return topPopup.pageTemplate;
			}
			return (pageSpec == null) ? null : GetPageTemplate(pageSpec);
		}
	}

	public bool inTutorial
	{
		get
		{
			return bookTut.running;
		}
	}

	private bool flashing
	{
		get
		{
			return flashStartTime > 0f && Clock.menu.time < flashStartTime + 1f;
		}
	}

	private bool dusting
	{
		get
		{
			return dustStartTime > 0f && Clock.menu.time < dustStartTime + 0.5f;
		}
	}

	private bool IsInState(State state)
	{
		return stater.curStateId == state;
	}

	private void OnEnable()
	{
		if (bookSpec == null)
		{
			FaceLib faceLib_ = FaceLib.Load();
			bookAnim = GetComponent<BookAnim>();
			glyphNotifier = GetComponent<ActionGlyphNotifier>();
			bookSpec = new BookSpec();
			bookmark = new Bookmark(bookSpec);
			bookContent = new BookContent(bookSpec, bookmark, faceLib_, assets);
			fateEditor = new FateEditor(faceLib_, this, bookmark, bookContent.mod);
			faceChooser = new FaceChooser(faceLib_, this, bookContent);
			termDefiner = new TermDefiner(this);
			messagePanelLogic = new MessagePanelLogic(this);
			bookTut = new BookTut(this, help, bookSpec);
			bookAction = new BookAction(this, bookSpec, bookContent, bookmark, fateEditor, faceChooser, faceLib_);
			help.gameObject.SetActive(false);
			pageSpec = bookSpec.FindPage(SaveData.it.generalRo.bookPageId);
			if (pageSpec == null)
			{
				pageSpec = bookSpec.FindPage("title");
			}
			pageHistory.AddLast(pageSpec);
			foreach (Popup popup in popups)
			{
				listPanel = popup.GetComponent<ListPanel>();
				if (listPanel != null)
				{
					break;
				}
			}
			CreateStater();
			foreach (Popup popup2 in popups)
			{
				popup2.gameObject.SetActive(false);
			}
			foreach (LocalizedUi localizedUi in localizedUis)
			{
				localizedUi.ApplyLocalization();
			}
		}
		active = this;
		stater.Go(State.Boot);
	}

	private void OnDisable()
	{
		if (active == this)
		{
			active = null;
		}
		CloseAllPopupsInstantly();
		bool flag = false;
		LinkedListNode<BookSpec.PageSpec> linkedListNode = pageHistory.Last;
		while (linkedListNode != null)
		{
			if (flag)
			{
				LinkedListNode<BookSpec.PageSpec> previous = linkedListNode.Previous;
				pageHistory.Remove(linkedListNode);
				linkedListNode = previous;
				continue;
			}
			if (linkedListNode.Value.isTurnable)
			{
				flag = true;
			}
			linkedListNode = linkedListNode.Previous;
		}
		if (Game.instance != null && !skipNextBagCloseSound)
		{
			audioKit.PlayUsingOneShot("bag-close");
		}
		skipNextBagCloseSound = false;
	}

	private void Update()
	{
		stater.Step(Clock.menu.deltaTime);
		glyphNotifier.globalHide = atomQueue.Count > 0;
		if (wantHide)
		{
			wantHide = false;
			if (!SaveData.it.generalRo.bookVisitedLastPage)
			{
				if (pageSpec.id != "cover")
				{
					OpenMessagePopup(Lang.Get("book_dontleave"));
				}
			}
			else if (Game.instance != null)
			{
				Game.instance.CloseBook();
			}
		}
		if (flashing)
		{
			float num = Util.LerpScale(Clock.menu.time - flashStartTime, 0f, 1f, 1f, 0f);
			flashImage.color = new Color(0.5f, 0f, num, 1f);
			flashImage.gameObject.SetActive(num > 0f);
		}
		else if (flashImage.gameObject.activeSelf)
		{
			flashImage.gameObject.SetActive(false);
		}
		if (dusting)
		{
			float f = Util.LerpScale(Clock.menu.time - dustStartTime, 0f, 0.5f, 0f, 1f);
			float num2 = Mathf.Lerp(1f, 1.75f, Util.PowInv(f, 2f));
			float a = 1f - Mathf.Pow(f, 2f);
			dustImage.color = new Color(1f, 1f, 1f, a);
			dustImage.rectTransform.localScale = num2 * Vector3.one;
			dustImage.gameObject.SetActive(true);
		}
		else if (dustImage.gameObject.activeSelf)
		{
			dustImage.gameObject.SetActive(false);
		}
	}

	private void LateUpdate()
	{
		if (bookTut.running)
		{
			HideUiForTutorial();
			if (wantSkipTutorial)
			{
				bookAnim.SkipEverythingForOneFrame();
				audioKit.MuteForOneFrame();
			}
			else if (bookTut.canSkip && RInput.GetButtonDownWhileMuted(10))
			{
				wantSkipTutorial = true;
				help.StartSkip(topActivePageTemplate);
				bookAnim.SkipEverythingForOneFrame();
				audioKit.MuteForOneFrame();
			}
		}
		if (bookAnim.isPlaying && Impatient.WantSkip("book"))
		{
			bookAnim.SkipEverythingForOneFrame();
			audioKit.MuteForOneFrame();
		}
	}

	private void HideUiForTutorial()
	{
		MouseCursor.HideForOneFrame();
		FolioNav.HideForOneFrame();
		HighlightEffect.SupressForOneFrame();
		SelectionHelper.ClearSelection();
	}

	private void CreateStater()
	{
		stater = new Stater<State>("Book");
		stater.AddState(State.Boot).AddFunc(StaterFunc.ENTER(delegate
		{
			RefreshPage();
			wantHide = false;
			bootMomentPageSpec = null;
			blockBackUntilRelease = true;
			audioKit.Play("bag-open");
			flashImage.gameObject.SetActive(false);
			flashStartTime = 0f;
			if (atomQueue.Count > 0)
			{
				StartQueuedAnims();
			}
			else
			{
				bool flag = pageHistory.Count > 0 && pageHistory.Last.Value.id == "folio-deck";
				if (bootRequest.examiningFaceId.HasValue())
				{
					bootMomentPageSpec = bookSpec.FindPage("folio-sketch");
					if (!SaveData.it.general.helpedZoomBook)
					{
						bootMessage = BootMessage.HelpZoomBook;
					}
				}
				else if (bootRequest.watchNearMomentId.HasValue() && bookSpec.FindPage(bootRequest.watchNearMomentId) != null && SaveData.it.HaveVisitedMoment(bootRequest.watchNearMomentId) && (!SaveData.it.general.helpedWatchBook || !flag))
				{
					bootMomentPageSpec = bookSpec.FindPage(bootRequest.watchNearMomentId);
					if (!SaveData.it.general.helpedWatchBook)
					{
						bootMessage = BootMessage.HelpWatchBook;
					}
				}
				else
				{
					bootRequest.Clear();
					bootMomentPageSpec = null;
					bootMessage = BootMessage.None;
				}
			}
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (bootMomentPageSpec != null)
			{
				if (!Monitor.blackingOut)
				{
					stater.Go(State.Normal);
					if (bootMomentPageSpec.id == "folio-sketch" && bootRequest.examiningFaceId.HasValue())
					{
						ShowInSketch(bootRequest.examiningFaceId);
					}
					else
					{
						GoToPage(bootMomentPageSpec);
					}
				}
			}
			else
			{
				stater.Go(State.Normal);
			}
		}));
		stater.AddState(State.Normal).AddFunc(StaterFunc.ENTER(delegate
		{
			SetInteractable(Interactable.Page);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!CheckAnimQueueAndTutorial())
			{
				if (bootMessage != BootMessage.None)
				{
					ShowBootMessage();
				}
				if (blockBackUntilRelease)
				{
					if (!RInput.GetButton(10))
					{
						blockBackUntilRelease = false;
					}
				}
				else if (RInput.GetButton(10))
				{
					GoBack(repeater.Charge(RepeaterId.Back));
				}
				else if (RInput.GetButton(22) || (!pageSpec.aliasPrevNextToBack && RInput.GetButton(52)))
				{
					if (pageSpec.prevPage == null && pageSpec.aliasPrevNextToBack)
					{
						GoBack(repeater.Charge(RepeaterId.Back));
					}
					else
					{
						ApplyPageDelta(1, repeater.Charge(RepeaterId.Right));
					}
				}
				else if (RInput.GetButton(21) || (!pageSpec.aliasPrevNextToBack && RInput.GetButton(51)))
				{
					if (pageSpec.prevPage == null && pageSpec.aliasPrevNextToBack)
					{
						GoBack(repeater.Charge(RepeaterId.Back));
					}
					else
					{
						ApplyPageDelta(-1, repeater.Charge(RepeaterId.Left));
					}
				}
				else if (topPopup == null && pageSpec.hasTocJump && RInput.GetButton(50))
				{
					GoToPage(bookSpec.FindPage("toc"));
				}
				else
				{
					repeater.Reset();
				}
				if (pageSpec.isTurnable && SelectionHelper.GetCurrentSelectable() == null)
				{
					float axis = RInput.GetAxis(18);
					if (Mathf.Abs(axis) > 0.001f)
					{
						FlashPageTurnGlyph((axis > 0f) ? 1 : (-1));
					}
				}
				if (RInput.GetButtonDown(28) && !SaveData.it.generalRo.bookVisitedLastPage)
				{
					OpenMessagePopup(Lang.Get("book_dontleave"));
				}
				DecaySelection();
			}
		}));
		stater.AddState(State.InPopup).AddFunc(StaterFunc.ENTER(delegate
		{
			SetInteractable(Interactable.Popup);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!CheckAnimQueueAndTutorial())
			{
				if (CheckTopPopupClose())
				{
					blockBackUntilRelease = true;
					if (topPopup.name == listPanel.name && listPanel.curSpec.manualBackHandling)
					{
						OnListItemSelected(listPanel.curSpec, null);
					}
					else
					{
						GoBack(0f);
					}
				}
				DecaySelection();
			}
		}));
		stater.AddState(State.InAnim).AddFunc(StaterFunc.ENTER(delegate
		{
			SetInteractable(Interactable.None);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			MouseCursor.HideForOneFrame();
			if (!bookAnim.isPlaying)
			{
				if (atomQueue.Count > 0)
				{
					StartQueuedAnims(true);
				}
				else if (topPopup != null)
				{
					stater.Go(State.InPopup);
				}
				else
				{
					stater.Go(State.Normal);
				}
			}
		}));
	}

	private bool CheckTopPopupClose()
	{
		if (RInput.GetButtonDown(10))
		{
			return true;
		}
		if (topPopup != null && (topPopup.name == "DefineTerm" || topPopup.name == "MessagePanel"))
		{
			return RInput.GetButtonDown(17);
		}
		return false;
	}

	private void ShowBootMessage()
	{
		if (bootMessage == BootMessage.HelpZoomBook)
		{
			OpenMessagePopup(Lang.Get("help_zoombook"));
			SaveData.it.general.helpedZoomBook = true;
		}
		else if (bootMessage == BootMessage.HelpWatchBook)
		{
			OpenMessagePopup(Lang.Get("help_watchbook"));
			SaveData.it.general.helpedWatchBook = true;
		}
		bootMessage = BootMessage.None;
	}

	private bool CheckAnimQueueAndTutorial()
	{
		if (atomQueue.Count > 0)
		{
			stater.Go(State.InAnim);
			return true;
		}
		if (bookTut.running)
		{
			if (bookTut.Step())
			{
				RInput.MuteForOneFrame();
				HideUiForTutorial();
			}
			else
			{
				audioKit.UnMute();
				RefreshAll();
				StartFlash();
				wantHide = false;
			}
			return true;
		}
		return false;
	}

	private void DecaySelection()
	{
		if (clearedSelectionTime > 0f && Clock.menu.time > clearedSelectionTime + 0.5f)
		{
			clearedSelectionTime = 0f;
			RefreshPage(BookContent.RefreshMode.SelectionChanged);
		}
	}

	private void RefreshPage(BookContent.RefreshMode refreshMode = BookContent.RefreshMode.Normal)
	{
		glyphNotifier.AbortAll();
		switch (refreshMode)
		{
		case BookContent.RefreshMode.Normal:
			if (atomQueue.Count > 0)
			{
				refreshMode = BookContent.RefreshMode.Animating;
			}
			break;
		case BookContent.RefreshMode.SelectionChanged:
			if ((bool)topPopup && topPopup.name == "ChooseFace")
			{
				RefreshPopup(topPopup, true);
			}
			break;
		}
		if (pageSpec.id == "last")
		{
			SaveData.it.general.bookVisitedLastPage = true;
		}
		if (pageSpec.transitionType == BookSpec.TransitionType.Turn)
		{
			int num = -9 + 2 * (20 * pageSpec.index / (bookSpec.numNavigablePages - 1) / 2);
			pagesRootTransform.anchoredPosition = new Vector2(num, 0f);
		}
		else
		{
			pagesRootTransform.anchoredPosition = Vector2.zero;
		}
		pageEdgeLTransform.gameObject.SetActive(pageSpec.index > 1);
		pageEdgeRTransform.gameObject.SetActive(pageSpec.nextPage != null);
		foreach (PageTemplate pageTemplate in pageTemplates)
		{
			bool flag = pageSpec.templateIdStr == pageTemplate.name;
			pageTemplate.gameObject.SetActive(flag);
			if (flag)
			{
				bookContent.RefreshPage(pageSpec, pageTemplate, refreshMode);
				pageTemplate.UpdateTextFitters();
			}
		}
		if (!baseTemplate.isActiveAndEnabled)
		{
			baseTemplate.gameObject.SetActive(true);
		}
		bookContent.RefreshPage(pageSpec, baseTemplate, refreshMode);
		if (pageSpec.isTurnable)
		{
			SaveData.it.general.bookPageId = pageSpec.id;
		}
	}

	private void DumpRectSizes(GameObject go)
	{
		DebugLogger debugLogger = new DebugLogger();
		RectTransform[] componentsInChildren = go.GetComponentsInChildren<RectTransform>(true);
		foreach (RectTransform rectTransform in componentsInChildren)
		{
			debugLogger.LogFormat("{0} {1}", rectTransform.name, rectTransform.rect);
		}
		debugLogger.Flush();
	}

	private void RefreshPopup(Popup popup, bool forSelectionChanged = false)
	{
		PageTemplate component = popup.GetComponent<PageTemplate>();
		if (!(component == null))
		{
			Dictionary<string, PageItem> pageItemDict = component.pageItemDict;
			component.BeginRefresh();
			if (component.id == BookSpec.TemplateId.EditFate)
			{
				fateEditor.Refresh(pageItemDict);
			}
			else if (component.id == BookSpec.TemplateId.ChooseFace)
			{
				faceChooser.Refresh(pageItemDict, forSelectionChanged);
			}
			else if (component.id == BookSpec.TemplateId.DefineTerm)
			{
				termDefiner.Refresh(pageItemDict);
			}
			else if (component.id == BookSpec.TemplateId.MessagePanel)
			{
				messagePanelLogic.Refresh(pageItemDict);
			}
			component.EndRefresh();
		}
	}

	public void ShowGlossaryDefinition(BookSpec.GlossaryEntry glossaryEntry)
	{
		termDefiner.Show(glossaryEntry);
	}

	public void RefreshAll()
	{
		RefreshPage();
		foreach (Popup item in popupStack)
		{
			RefreshPopup(item);
		}
	}

	public bool GoBack(float interpDuration)
	{
		if (topPopup != null)
		{
			if (popupStack.Count > 1)
			{
				QueueAndStartAnim(BookAnim.MakeClosePopup(topPopup, PeekAt(popupStack, 1)));
			}
			else
			{
				QueueAndStartAnim(BookAnim.MakeClosePopup(topPopup, pageSpec));
			}
			return true;
		}
		if (pageHistory.Count > 1)
		{
			pageHistory.RemoveLast();
			GoToPage(pageHistory.Last.Value, Mathf.Min(0.5f, interpDuration), true);
			return true;
		}
		wantHide = true;
		return false;
	}

	private void DumpPageHistory()
	{
		DebugLogger debugLogger = new DebugLogger();
		debugLogger.Log("PAGE HISTORY");
		foreach (BookSpec.PageSpec item in pageHistory)
		{
			debugLogger.Log(item.id);
		}
		debugLogger.Flush();
	}

	private void ApplyPageDelta(int delta, float interpDuration = 0.5f)
	{
		Selectable currentSelectable = SelectionHelper.GetCurrentSelectable();
		PageTemplate pageTemplate = GetPageTemplate(pageSpec);
		if (delta > 0 && pageSpec.nextPage != null)
		{
			GoToPage(pageSpec.nextPage, interpDuration);
		}
		else if (delta < 0 && pageSpec.prevPage != null)
		{
			GoToPage(pageSpec.prevPage, interpDuration);
		}
		PageTemplate pageTemplate2 = GetPageTemplate(pageSpec);
		pageTemplate2.SetInitialFocus((!(pageTemplate != null)) ? pageTemplate2.initialFocusPreferredSide : pageTemplate.GetSelectableSide(currentSelectable), (pageTemplate.GetSelectablePriority(currentSelectable) < 0) ? null : currentSelectable);
	}

	private static T PeekAt<T>(Stack<T> stack, int depth)
	{
		int num = 0;
		foreach (T item in stack)
		{
			if (num == depth)
			{
				return item;
			}
			num++;
		}
		throw new UnityException("Peeking past beginning of stack");
	}

	public void GoToPage(BookSpec.PageSpec targetPageSpec, string targetPageSelectable)
	{
		GoToPage(targetPageSpec, 0.5f, false, targetPageSelectable);
	}

	public void GoToPage(BookSpec.PageSpec targetPageSpec, float interpDuration = 0.5f, bool goingBack = false, string targetPageSelectable = null)
	{
		glyphNotifier.AbortAll(interpDuration + 0.25f);
		if (topPopup != null)
		{
			if (popupStack.Count == 1)
			{
				QueueAnim(BookAnim.MakeClosePopup(topPopup, pageSpec));
			}
			else
			{
				for (int i = 0; i < popupStack.Count - 1; i++)
				{
					Popup fromPopup = PeekAt(popupStack, i);
					Popup toPopup = PeekAt(popupStack, i + 1);
					QueueAnim(BookAnim.MakeClosePopup(fromPopup, toPopup));
				}
				QueueAnim(BookAnim.MakeClosePopup(PeekAt(popupStack, popupStack.Count - 1), pageSpec));
			}
		}
		Debug.Log("GOTO: " + targetPageSpec.id);
		if (targetPageSpec == pageSpec)
		{
			RefreshPage();
			return;
		}
		BookSpec.PageSpec value = pageSpec;
		if (!goingBack && pageHistory.Count > 1 && value.isRollable)
		{
			pageHistory.RemoveLast();
			QueueAnim(BookAnim.MakeChangePage(value, pageHistory.Last.Value, 0.375f));
			value = pageHistory.Last.Value;
		}
		if (value != targetPageSpec)
		{
			bool flag = value.isTurnable && targetPageSpec.isTurnable;
			int num = Mathf.Abs(value.index - targetPageSpec.index);
			if (flag && num > 1)
			{
				QueueLeafing(value, targetPageSpec, (num <= 3) ? 1 : 100);
			}
			else
			{
				QueueAnim(BookAnim.MakeChangePage(value, targetPageSpec, interpDuration));
			}
		}
		if (pageHistory.Last.Value != targetPageSpec)
		{
			if (pageHistory.Count > 20)
			{
				pageHistory.RemoveFirst();
			}
			pageHistory.AddLast(targetPageSpec);
		}
		StartQueuedAnims();
		if (targetPageSelectable.HasValue())
		{
			PageTemplate pageTemplate = GetPageTemplate(targetPageSpec);
			PageItem pageItem = pageTemplate.FindPageItem(targetPageSelectable);
			if (pageItem != null && pageItem.selectable != null)
			{
				pageTemplate.SetInitialFocus(pageItem.buttonSettings.side, pageItem.selectable);
			}
		}
	}

	public void ChooseFace(string nameId, FaceChooser.OnFaceChosen onFaceChosen)
	{
		faceChooser.Prep(nameId, onFaceChosen);
		OpenPopup("ChooseFace");
	}

	public void OpenPopup(string name)
	{
		Popup popup = FindPopup(name);
		if (!(popup == null))
		{
			if (topPopup != null)
			{
				QueueAndStartAnim(BookAnim.MakeOpenPopup(topPopup, popup, (!(popup == topPopup)) ? (-1) : 0));
			}
			else
			{
				QueueAndStartAnim(BookAnim.MakeOpenPopup(pageSpec, popup));
			}
		}
	}

	private bool IsClosingPopup(Popup popup)
	{
		foreach (BookAnim.Atom item in atomQueue)
		{
			if (item.kind == BookAnim.Kind.ClosePopup && item.popup == popup)
			{
				return true;
			}
		}
		return false;
	}

	public void ClosePopupsUntil(string name)
	{
		while (topPopup != null && topPopup.name != name)
		{
			CloseTopPopupInstantly();
		}
	}

	private Popup FindPopup(string name)
	{
		Popup popup = null;
		foreach (Popup popup2 in popups)
		{
			if (popup2.name == name)
			{
				popup = popup2;
				break;
			}
		}
		if (popup == null)
		{
			Debug.LogError("Popup not found: " + name);
		}
		return popup;
	}

	public void OpenList(ListPanel.Spec spec)
	{
		listOnItemSelected = spec.onItemSelected;
		spec.onItemSelected = OnListItemSelected;
		Popup popup = FindPopup("ListPanel");
		if (bookAnim.isClosingPopup(popup))
		{
			bookAnim.EndInstantly();
			popup.gameObject.SetActive(false);
			SelectionHelper.ClearSelection();
			popup.gameObject.SetActive(true);
		}
		OpenPopup("ListPanel");
		listPanel.Open(spec, ListPanel.Mode.Controlled);
	}

	private void OnListItemSelected(ListPanel.Spec spec, ListPanel.Item item)
	{
		if (!bookTut.running)
		{
			GoBack(0f);
			if (listOnItemSelected != null)
			{
				listOnItemSelected(spec, item);
			}
			RefreshAll();
		}
	}

	private void QueueAnim(BookAnim.Atom atom)
	{
		atomQueue.Enqueue(atom);
	}

	private float QueueLeafing(BookSpec.PageSpec fromPageSpec, BookSpec.PageSpec toPageSpec, int maxStep = 4)
	{
		float num = 0f;
		BookSpec.PageSpec pageSpec = fromPageSpec;
		for (int i = 0; i < 1000; i++)
		{
			if (Mathf.Abs(toPageSpec.index - pageSpec.index) == 1)
			{
				QueueAnim(BookAnim.MakeChangePage(pageSpec, toPageSpec, 0.5f));
				num += 0.5f;
				break;
			}
			int num2 = Mathf.Clamp((toPageSpec.index - pageSpec.index) / 2, -maxStep, maxStep);
			if (num2 == 0)
			{
				break;
			}
			BookSpec.PageSpec pageSpec2 = bookSpec.pageSpecs[pageSpec.index + num2];
			QueueAnim(BookAnim.MakeChangePage(pageSpec, pageSpec2, 0.1f));
			num += 0.1f;
			pageSpec = pageSpec2;
		}
		return num;
	}

	private void QueueAndStartAnim(BookAnim.Atom atom)
	{
		QueueAnim(atom);
		StartQueuedAnims();
	}

	private void StartQueuedAnims(bool ignoreCurrentState = false)
	{
		if (atomQueue.Count > 0 && (ignoreCurrentState || !IsInState(State.InAnim)))
		{
			SetInteractable(Interactable.None);
			BookAnim.Atom atom_ = atomQueue.Dequeue();
			bookAnim.Play(atom_);
			stater.Go(State.InAnim);
		}
	}

	private void CloseAllPopupsInstantly(bool blackout = true)
	{
		if (blackout)
		{
			Monitor.BlackOut(2);
		}
		while (popupStack.Count > 0)
		{
			Popup popup = popupStack.Pop();
			popup.gameObject.SetActive(false);
		}
		PageTemplate pageTemplate = GetPageTemplate(pageSpec);
		pageTemplate.interactable = true;
	}

	private void CloseTopPopupInstantly()
	{
		if (topPopup != null)
		{
			Popup popup = popupStack.Pop();
			popup.gameObject.SetActive(false);
			atomQueue.Clear();
			if (topPopup != null)
			{
				topPopup.gameObject.SetActive(true);
				RefreshPopup(topPopup);
			}
		}
	}

	private static float CalcQueueDuration(Queue<BookAnim.Atom> q)
	{
		float num = 0f;
		foreach (BookAnim.Atom item in q)
		{
			num += item.duration;
		}
		return num;
	}

	public void OnAnimBegin(BookAnim.Atom atom)
	{
		if (atom.startFunc != null)
		{
			atom.startFunc();
		}
		if (atom.pageSpec != null)
		{
			pageSpec = atom.pageSpec;
			if (atom.kind == BookAnim.Kind.BleedIn)
			{
				bookContent.mod.RemoveHiddenPageSpec(pageSpec);
			}
			if (atom.kind == BookAnim.Kind.ClosePopup)
			{
				RefreshPage(BookContent.RefreshMode.PopupJustClosed);
			}
			else
			{
				RefreshPage();
			}
		}
		if (atom.kind != BookAnim.Kind.OpenPopup)
		{
			return;
		}
		if (!(atom.popup == topPopup))
		{
			if (topPopup != null)
			{
				topPopup.interactable = false;
			}
			popupStack.Push(atom.popup);
		}
		atom.popup.gameObject.SetActive(true);
		RefreshPopup(atom.popup);
	}

	public void OnAnimEnd(BookAnim.Atom atom)
	{
		if (atom.endFunc != null)
		{
			atom.endFunc();
		}
		if (atom.kind == BookAnim.Kind.ClosePopup)
		{
			if (atom.popup.isActiveAndEnabled)
			{
				Popup popup = popupStack.Pop();
				popup.gameObject.SetActive(false);
				if (topPopup != null)
				{
					RefreshPopup(topPopup);
				}
			}
		}
		else if (atom.kind == BookAnim.Kind.OpenPopup && atom.popup == FindPopup("ListPanel"))
		{
			listPanel.SetCurrentSelection();
		}
	}

	public void MoveOffPage(int dir, PageItem sourcePageItem)
	{
		if (!(topPopup != null) && !GetPageTemplate(pageSpec).MoveSelectionIfPossible(sourcePageItem, dir))
		{
			FlashPageTurnGlyph(dir);
		}
	}

	private void FlashPageTurnGlyph(int dir)
	{
		if (dir < 0 && pageSpec.prevPage != null)
		{
			glyphNotifier.Charge(21, 18);
		}
		else if (dir > 0 && pageSpec.nextPage != null)
		{
			glyphNotifier.Charge(22, 18);
		}
	}

	private PageTemplate GetPageTemplate(BookSpec.PageSpec pageSpec)
	{
		foreach (PageTemplate pageTemplate in pageTemplates)
		{
			if (pageSpec.templateId == pageTemplate.id)
			{
				return pageTemplate;
			}
		}
		return null;
	}

	public void OnPageButtonClick(PageItem pageItem)
	{
		OnPageButtonClick_Execute(pageItem);
	}

	public void ShowInSketch(string crewId)
	{
		bookContent.SetFolioRemap("folio-sketch", new BookContent.FolioAddress(BookSpec.FolioSource.GlobalSketch, crewId));
		GoToPage(bookSpec.FindPage("folio-sketch"));
	}

	public void ShowFocusDeck(string crewId)
	{
		bookContent.SetFocusDeckCrewId(crewId);
		bookContent.SetFolioRemap("folio-deck", new BookContent.FolioAddress(BookSpec.FolioSource.FocusDeck, pageSpec.id));
		GoToPage(bookSpec.FindPage("folio-deck"));
	}

	public void OnFolioPinClicked(PageItem folioPageItem, FolioSpec.PinSpec folioPinSpec)
	{
		if (!bookTut.running)
		{
			ClearSelection(true);
			RefreshPage(BookContent.RefreshMode.SelectionChanged);
			if (folioPageItem.id == "folio-chooseface")
			{
				faceChooser.OnFolioPinClicked(folioPinSpec);
			}
			else
			{
				bookAction.Execute(pageSpec, folioPageItem, folioPinSpec);
			}
		}
	}

	public void OnPageButtonClick_Execute(PageItem pageItem)
	{
		if (!bookTut.running)
		{
			bookAction.Execute(pageSpec, pageItem);
		}
	}

	public void SetSelection(string itemId, Vector2 posInCanvas)
	{
		if (bookContent.SetSelection(new BookContent.Selection(pageSpec.id, itemId, posInCanvas)))
		{
			clearedSelectionTime = 0f;
			RefreshPage(BookContent.RefreshMode.SelectionChanged);
			audioKit.Play("selchange");
		}
	}

	public void ClearSelection(bool instant = false)
	{
		if (bookContent.SetSelection(new BookContent.Selection(null, null, Vector2.zero)))
		{
			clearedSelectionTime = ((!instant) ? Clock.menu.time : (-1000f));
		}
	}

	private void SetInteractable(Interactable interactable)
	{
		bool interactable2 = interactable == Interactable.Page;
		bool flag = interactable == Interactable.Popup;
		baseTemplate.interactable = interactable2;
		foreach (PageTemplate pageTemplate in pageTemplates)
		{
			if (pageTemplate.isActiveAndEnabled)
			{
				pageTemplate.interactable = interactable2;
			}
		}
		int num = 0;
		foreach (Popup item in popupStack)
		{
			item.interactable = num == 0 && flag;
			num++;
		}
		if (interactable != Interactable.Page)
		{
			ClearSelection(true);
		}
	}

	public float GetGlyphFlashNoticeStartTime(int actionId)
	{
		return glyphNotifier.GetStartTime(actionId);
	}

	public void OpenMessagePopup(string message)
	{
		messagePanelLogic.Show(Lang.GetGenderedForPlayer(message));
	}

	private void StartFlash()
	{
		flashStartTime = Clock.menu.time;
		audioKit.Play("flash");
	}

	private void StartDust()
	{
		dustStartTime = Clock.menu.time;
		audioKit.Play("bookdrop");
	}

	private void PrepForShowAndReveal()
	{
		bootMomentPageSpec = null;
		bootMessage = BootMessage.None;
		audioKit.Abort("bag-open");
	}

	public void RevealBook()
	{
		PrepForShowAndReveal();
		BookSpec.PageSpec fromPageSpec = bookSpec.FindPage("air");
		BookSpec.PageSpec toPageSpec = bookSpec.FindPage("cover");
		pageSpec = fromPageSpec;
		RefreshPage();
		QueueAnim(BookAnim.MakeWait(0.5f));
		QueueAnim(BookAnim.MakeChangePage(fromPageSpec, toPageSpec));
		QueueAnim(BookAnim.MakeWait(1f));
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			RefreshPage();
		}));
	}

	public void RevealBookInOffice()
	{
		PrepForShowAndReveal();
		BookSpec.PageSpec fromPageSpec = bookSpec.FindPage("desk");
		BookSpec.PageSpec pageSpec = bookSpec.FindPage("cover");
		BookSpec.PageSpec toPageSpec = bookSpec.FindPage("title");
		this.pageSpec = fromPageSpec;
		RefreshPage();
		QueueAnim(BookAnim.MakeChangePage(fromPageSpec, pageSpec));
		QueueAnim(BookAnim.MakeChangePage(pageSpec, toPageSpec));
	}

	public void RevealNewPages(string momentId)
	{
		PrepForShowAndReveal();
		skipNextBagCloseSound = true;
		bookAnim.DisableAllTransitions();
		Story.Moment moment = Story.it.GetMoment(momentId);
		Story.Disaster disaster = moment.disaster;
		SaveData.MomentData momentData = SaveData.it.moment[momentId];
		SaveData.DisasterData disasterData = SaveData.it.disaster[disaster.id];
		BookSpec.PageSpec pageSpec = bookSpec.FindPage(momentId);
		BookSpec.PageSpec chapterStartPage = bookSpec.FindPage(disaster.id);
		BookSpec.PageSpec fromPageSpec = bookSpec.FindPage("desk");
		BookSpec.PageSpec pageSpec2 = bookSpec.FindPage("cover");
		BookSpec.PageSpec pageSpec3 = bookSpec.FindPage("title");
		momentData.revealedPageInBook = true;
		bookContent.mod.AddHiddenPageSpec(pageSpec);
		RevealTimings revealTimings = default(RevealTimings);
		if (!disasterData.revealedChartInBook)
		{
			revealTimings.waitOnFirstPage = 1f;
			revealTimings.preMusicFadeTime = 2f;
			revealTimings.chapterBleed = 6f;
			revealTimings.momentBleed = 6f;
			revealTimings.unveilGuess = ((disaster.index != 9) ? 0f : 2f);
			this.pageSpec = fromPageSpec;
			RefreshPage();
			QueueAnim(BookAnim.MakeChangePage(fromPageSpec, pageSpec2));
			QueueAnim(BookAnim.MakePlayAudio(assets.revealLeadinAudioClip, 0.1f));
			QueueAnim(BookAnim.MakeChangePage(pageSpec2, pageSpec3));
			QueueAnim(BookAnim.MakeWait(revealTimings.waitOnFirstPage));
			QueueLeafing(pageSpec3, chapterStartPage);
			QueueAnim(BookAnim.MakeStopAudio(revealTimings.preMusicFadeTime));
			QueueAnim(BookAnim.MakePlayAudio(assets.revealAudioClip));
			QueueAnim(BookAnim.MakeWait(1.4142857f));
			QueueAnim(BookAnim.MakeBleedIn(chapterStartPage, revealTimings.chapterBleed));
			QueueLeafing(chapterStartPage, pageSpec);
			QueueAnim(BookAnim.MakeBleedIn(pageSpec, revealTimings.momentBleed));
			QueueGuessReveal(moment, pageSpec, revealTimings.unveilGuess);
			disasterData.revealedChartInBook = true;
			bookContent.mod.AddHiddenPageSpec(chapterStartPage);
		}
		else
		{
			revealTimings.waitOnDesk = 1f;
			revealTimings.waitOnFirstPage = 1f;
			revealTimings.waitOnMoment = 1f;
			revealTimings.momentBleed = 5f;
			this.pageSpec = fromPageSpec;
			RefreshPage();
			QueueAnim(BookAnim.MakePlayAudio(assets.revealLeadinAudioClip, 0.1f));
			QueueAnim(BookAnim.MakeWait(revealTimings.waitOnDesk));
			QueueAnim(BookAnim.MakeFunc(delegate
			{
				this.pageSpec = chapterStartPage;
				RefreshPage();
				StartDust();
			}));
			QueueAnim(BookAnim.MakeWait(revealTimings.waitOnFirstPage));
			QueueLeafing(chapterStartPage, pageSpec);
			QueueAnim(BookAnim.MakeWait(0.25f * revealTimings.waitOnMoment));
			QueueAnim(BookAnim.MakeStopAudio(1f * revealTimings.waitOnMoment, 0f));
			QueueAnim(BookAnim.MakeWait(0.75f * revealTimings.waitOnMoment));
			QueueAnim(BookAnim.MakePlayAudio(assets.revealVeryShortAudioClip));
			QueueAnim(BookAnim.MakeBleedIn(pageSpec, revealTimings.momentBleed));
		}
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			bookContent.mod.Reset();
			bookmark.Refresh();
			RefreshPage();
			pageHistory.Clear();
			pageHistory.AddLast(this.pageSpec);
			StartFlash();
		}));
	}

	public void RevealCompleteChapter(string disasterId)
	{
		Story.Disaster disaster = Story.it.GetDisaster(disasterId);
		if (disaster == null)
		{
			return;
		}
		PrepForShowAndReveal();
		bootMomentPageSpec = null;
		SaveData.DisasterData disasterData = SaveData.it.disaster[disaster.id];
		disasterData.revealedDisappearancesInBook = true;
		bookContent.mod.forceChapterTallyId = disaster.id;
		bookContent.mod.forceChapterTallyCount = 0;
		BookSpec.PageSpec fromPageSpec = bookSpec.FindPage("air");
		BookSpec.PageSpec pageSpec = bookSpec.FindPage("cover");
		BookSpec.PageSpec pageSpec2 = bookSpec.FindPage("title");
		BookSpec.PageSpec pageSpec3 = bookSpec.FindPage(disaster.id);
		BookSpec.PageSpec pageSpec4 = bookSpec.FindPage(disaster.id + "-disappear");
		BookSpec.PageSpec pageSpec5 = bookSpec.FindPage(disaster.id + "-disappear2");
		List<BookSpec.PageSpec> list = new List<BookSpec.PageSpec>();
		if (pageSpec4 != null)
		{
			list.Add(pageSpec4);
		}
		if (pageSpec5 != null)
		{
			list.Add(pageSpec5);
		}
		RevealTimings revealTimings = new RevealTimings
		{
			waitOnDesk = 1f,
			waitOnMoment = 1f,
			preMusicFadeTime = 2f,
			disappearBleed = 1f,
			waitOnDisappear = 2f,
			chapterBleed = 2f
		};
		this.pageSpec = fromPageSpec;
		RefreshPage();
		QueueAnim(BookAnim.MakeWait(0.5f));
		QueueAnim(BookAnim.MakeChangePage(fromPageSpec, pageSpec));
		QueueAnim(BookAnim.MakeChangePage(pageSpec, pageSpec2));
		QueueLeafing(pageSpec2, pageSpec3);
		QueueAnim(BookAnim.MakeWait(revealTimings.chapterBleed));
		int numTicks = disaster.numDead + disaster.numDisappear;
		float duration = 4f / (float)numTicks;
		for (int i = 0; i < numTicks; i++)
		{
			int tickIndex = i;
			QueueAnim(BookAnim.MakeFunc(delegate
			{
				bookContent.mod.forceChapterTallyCount = tickIndex + 1;
				RefreshPage();
				if (tickIndex == numTicks - 1)
				{
					audioKit.Play("tally2");
				}
				else if (tickIndex < disaster.numDead)
				{
					audioKit.Play("tally0");
				}
				else
				{
					audioKit.Play("tally1");
				}
			}, duration));
		}
		if (list.Count > 0)
		{
			BookSpec.PageSpec fromPageSpec2 = pageSpec3;
			QueueAnim(BookAnim.MakeWait(revealTimings.waitOnMoment));
			for (int num = list.Count - 1; num >= 0; num--)
			{
				BookSpec.PageSpec disappearPage = list[num];
				bookContent.mod.AddHiddenPageSpec(disappearPage);
				QueueLeafing(fromPageSpec2, disappearPage);
				QueueAnim(BookAnim.MakeWait(revealTimings.disappearBleed));
				QueueAnim(BookAnim.MakeFunc(delegate
				{
					bookContent.mod.RemoveHiddenPageSpec(disappearPage);
					RefreshPage();
					audioKit.Play("stamp");
				}, revealTimings.waitOnDisappear));
				fromPageSpec2 = disappearPage;
			}
		}
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			bookContent.mod.Reset();
			RefreshPage();
			pageHistory.Clear();
			pageHistory.AddLast(this.pageSpec);
			StartFlash();
		}));
	}

	private void QueueGuessReveal(Story.Moment moment, BookSpec.PageSpec momentPage, float duration)
	{
		if (duration <= 0f)
		{
			return;
		}
		PageItem momentGuessPageItem0 = null;
		PageItem momentGuessPageItem1 = null;
		Dictionary<string, PageItem> pageItemDict = GetPageTemplate(momentPage).pageItemDict;
		if (moment.deathType == Story.DeathType.Crew1)
		{
			momentGuessPageItem0 = pageItemDict["main-crew1-guess0"];
		}
		else if (moment.deathType == Story.DeathType.Crew2)
		{
			momentGuessPageItem0 = pageItemDict["main-crew2-guess0"];
			momentGuessPageItem1 = pageItemDict["main-crew2-guess1"];
		}
		else if (moment.deathType == Story.DeathType.CrewOther)
		{
			momentGuessPageItem0 = pageItemDict["main-crewother-guess0"];
		}
		bookContent.mod.AddHiddenGuessPageSpec(momentPage);
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			bookContent.mod.RemoveHiddenGuessPageSpec(momentPage);
			RefreshPage();
			if (momentGuessPageItem0 != null)
			{
				momentGuessPageItem0.textUnveilT = 0f;
			}
			if (momentGuessPageItem1 != null)
			{
				momentGuessPageItem1.textUnveilT = 0f;
			}
		}, duration).SetInterpFunc(delegate(float t)
		{
			if (momentGuessPageItem1 != null)
			{
				momentGuessPageItem0.textUnveilT = Util.LerpScale(t, 0f, 0.5f, 0f, 1f);
				momentGuessPageItem1.textUnveilT = Util.LerpScale(t, 0.5f, 1f, 0f, 1f);
			}
			else if (momentGuessPageItem0 != null)
			{
				momentGuessPageItem0.textUnveilT = t;
			}
		}));
	}

	public void RevealCorrectGuesses(List<string> crewIds)
	{
		string firstCrewId = crewIds[0];
		crewIds.Sort(delegate(string a, string b)
		{
			if (a == firstCrewId)
			{
				return -1;
			}
			if (b == firstCrewId)
			{
				return 1;
			}
			BookSpec.PageSpec pageSpec5 = bookSpec.FindFinalPage(a);
			BookSpec.PageSpec pageSpec6 = bookSpec.FindFinalPage(b);
			if (pageSpec5 == this.pageSpec)
			{
				return -1;
			}
			return (pageSpec6 == this.pageSpec) ? 1 : (pageSpec5.index - pageSpec6.index);
		});
		int num = 0;
		string[] array = ((crewIds.Count != 2) ? new string[3] { "correct1", "correct2", "correct3" } : new string[2] { "correct1", "correct3" });
		string welldoneId = string.Empty;
		Story.Zone deathOrDisappearZone = Story.it.GetDeathOrDisappearZone(crewIds[0]);
		int zoneSolvedCount = SaveData.it.GetZoneSolvedCount(deathOrDisappearZone);
		int zoneUnsolvedCount = SaveData.it.GetZoneUnsolvedCount(deathOrDisappearZone);
		bool flag = false;
		if (zoneUnsolvedCount == 0)
		{
			welldoneId = ((deathOrDisappearZone != Story.Zone.Ship) ? "welldone_last" : "welldone_solvable");
			flag = deathOrDisappearZone == Story.Zone.Ship;
		}
		else if (zoneSolvedCount == crewIds.Count)
		{
			welldoneId = ((crewIds.Count != 2) ? "welldone_3_first" : "welldone_2_first");
		}
		else
		{
			welldoneId = ((crewIds.Count != 2) ? "welldone_3_more" : "welldone_2_more");
		}
		BookSpec.PageSpec pageSpec = bookSpec.FindPage("message");
		bookContent.mod.message = null;
		QueueAnim(BookAnim.MakeWait(1f));
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			CloseAllPopupsInstantly();
		}));
		QueueAnim(BookAnim.MakePlayAudio("correct0"));
		QueueAnim(BookAnim.MakeChangePage(this.pageSpec, pageSpec, 2.4f));
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			bookContent.mod.message = Lang.Get("welldone");
			RefreshPage();
		}, 0.6f));
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			bookContent.mod.message = Lang.Get(welldoneId);
			RefreshPage();
		}, 1.8000001f));
		BookSpec.PageSpec pageSpec2 = this.pageSpec;
		if (this.pageSpec.transitionType == BookSpec.TransitionType.Roll)
		{
			while (pageHistory.Count > 1 && pageHistory.Last.Value.transitionType == BookSpec.TransitionType.Roll)
			{
				pageHistory.RemoveLast();
			}
			pageSpec2 = pageHistory.Last.Value;
		}
		QueueAnim(BookAnim.MakeChangePage(pageSpec, pageSpec2, 0.6f));
		foreach (string crewId2 in crewIds)
		{
			string crewId = crewId2;
			bookContent.mod.AddMaskedCorrectFaceId(crewId);
			BookSpec.PageSpec pageSpec3 = bookSpec.FindFinalPage(crewId);
			if (pageSpec3 != pageSpec2)
			{
				QueueLeafing(pageSpec2, pageSpec3);
				pageSpec2 = pageSpec3;
				pageHistory.AddLast(pageSpec3);
			}
			QueueAnim(BookAnim.MakePlayAudio(array[num]));
			QueueAnim(BookAnim.MakeWait(0.6f));
			QueueAnim(BookAnim.MakeFunc(delegate
			{
				bookContent.mod.hiddenFateCrewId = crewId;
				RefreshPage();
			}, 0.6f, delegate
			{
				bookContent.mod.hiddenFateCrewId = null;
				bookContent.mod.RemoveMaskedCorrectFaceId(crewId);
				RefreshPage();
			}));
			QueueAnim(BookAnim.MakeWait(2f));
			num++;
		}
		int num2 = SaveData.it.GetNumFatesCorrect() - crewIds.Count;
		bookContent.mod.forceFateSealCount = num2;
		BookSpec.PageSpec pageSpec4 = bookSpec.FindPage("last");
		QueueLeafing(pageSpec2, pageSpec4);
		QueueAnim(BookAnim.MakePlayAudio("correct4"));
		QueueAnim(BookAnim.MakeWait(2.4f));
		for (int num3 = 0; num3 < crewIds.Count - 1; num3++)
		{
			int sealCount = num2 + num3 + 1;
			QueueAnim(BookAnim.MakeFunc(delegate
			{
				bookContent.mod.forceFateSealCount = sealCount;
				RefreshPage();
			}, 1.2f));
		}
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			bookContent.mod.Reset();
			RefreshPage();
		}, 2f));
		if (flag)
		{
			QueueAnim(BookAnim.MakeWait(1f));
			QueueAnim(BookAnim.MakeFunc(delegate
			{
				help.PlayNextAudioClip();
			}));
			QueueAnim(BookAnim.MakeChangePage(this.pageSpec, pageSpec));
			QueueAnim(BookAnim.MakeFunc(delegate
			{
				help.PlayNextAudioClip();
				bookContent.mod.message = Lang.Get("welldone_shipdone");
				RefreshPage();
			}, 5f));
			QueueAnim(BookAnim.MakeChangePage(pageSpec, pageSpec4, 0f));
		}
		QueueAnim(BookAnim.MakeFunc(delegate
		{
			StartFlash();
		}));
		pageHistory.AddLast(pageSpec4);
	}

	public void DebugSkipAnimsForOneFrame()
	{
		bookAnim.SkipEverythingForOneFrame();
	}

	void BookTutHost.TutQueueAnim(BookAnim.Atom atom)
	{
		QueueAnim(atom);
	}

	void BookTutHost.TutGoBack()
	{
		bool flag = topPopup == null && (pageSpec.isTurnable || pageSpec.isRollable);
		GoBack((!flag) ? 0f : 0.5f);
	}

	void BookTutHost.TutOpenFateEditor(string crewId)
	{
		fateEditor.OpenFromFace(crewId);
	}

	void BookTutHost.TutShowFolio(BookSpec.FolioSource source, string pageId, string folioId, bool resetScrollToTop)
	{
		bookContent.SetFolioRemap(folioId, new BookContent.FolioAddress(source, pageId));
		GoToPage(bookSpec.FindPage(folioId));
		if (resetScrollToTop)
		{
			GetPageTemplate(bookSpec.FindPage(pageId)).pageItemDict[folioId].folio.focus = Vector2.zero;
		}
	}

	int BookTutHost.TutGetListItemsCount()
	{
		return listPanel.curSpec.items.Count;
	}

	void BookTutHost.TutExecuteAction(string pageItemId)
	{
		PageTemplate pageTemplate = ((!(topPopup != null)) ? GetPageTemplate(pageSpec) : topPopup.pageTemplate);
		PageItem pageItem = pageTemplate.FindPageItem(pageItemId);
		if (pageItem == null)
		{
			Debug.LogError("Page item not found: " + pageItemId);
		}
		else
		{
			bookAction.Execute(pageSpec, pageItem);
		}
	}

	BookSpec.PageSpec BookTutHost.TutGetCurPageSpec()
	{
		return pageSpec;
	}

	bool BookTutHost.TutCanHelpFace()
	{
		return (popupStack.Count > 1 && PeekAt(popupStack, 0).name == "ListPanel" && PeekAt(popupStack, 1).name == "EditFate") || (popupStack.Count > 0 && PeekAt(popupStack, 0).name == "EditFate");
	}

	void BookTutHost.TutClearBookmark()
	{
		bookmark.Clear();
	}

	void BookTutHost.TutSetBookmark(string crewId)
	{
		bookmark.MarkCrewMember(crewId);
		listPanel.audioKit.Play("tap");
		if (topPopup != null)
		{
			RefreshPopup(topPopup);
		}
		else
		{
			RefreshPage();
		}
	}

	public Snapshot MakeSnapshot()
	{
		Snapshot snapshot = new Snapshot();
		snapshot.selectable = SelectionHelper.GetCurrentSelectable();
		snapshot.pageSpec = pageSpec;
		return snapshot;
	}

	public void RestoreSnapshot(Snapshot snapshot)
	{
		if (snapshot.pageSpec != pageSpec)
		{
			GoToPage(pageSpec);
		}
		if (snapshot.selectable != null && snapshot.selectable.isActiveAndEnabled)
		{
			SelectionHelper.SetCurrent(snapshot.selectable);
		}
	}

	public void RunTutorial(BookTut.Kind kind, string crewId)
	{
		wantSkipTutorial = false;
		bookTut.Start(kind, crewId);
	}
}
