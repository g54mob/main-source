using System;
using DevConsole;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIWindow : MonoBehaviour
{
	[Serializable]
	public class CollapseEvent : UnityEvent<bool>
	{
	}

	public bool OnlyHide;

	public bool StartHidden;

	public bool Modal;

	public bool AlwaysOnTop;

	public bool ShowCentered;

	public bool ForcePosition;

	public bool HasBeenShown;

	public bool HideBlockPanel;

	public bool IgnoreBuildMode;

	public bool IgnoreWindowBorder;

	public bool ContinuallyUpdateSize;

	public Vector2 MinSize = new Vector2(128f, 128f);

	public Text TitleText;

	public string InitialTitle = "New window";

	public Action OnClose;

	public bool OnCloseAfter;

	public GameObject MainPanel;

	public GameObject CloseButton;

	public GameObject SizeButton;

	public Button HelpButton;

	public RectTransform SpawnFrom;

	public UnityEvent OnSizeChanged;

	public string WindowSizeID;

	public string ClosePrompt;

	public bool SavePosition = true;

	public string AssociatedTutorial;

	private string _title;

	private Vector2 InitMouseOffset;

	private Vector2 InitWindowOffset;

	private Vector2 InitWindowSize;

	private bool Dragging;

	private bool Sizing;

	private bool SizeHor;

	private bool SizeVert;

	private bool SizeMove;

	private bool Collapsed;

	private bool reactiveSizeButton;

	public Image TopPanel;

	private static Color _activeColor = new Color32(126, 207, 112, byte.MaxValue);

	private static Color _inactiveColor = new Color(0.6f, 0.6f, 0.6f);

	public UnityEvent OnGainedFocus;

	public UnityEvent OnLostFocus;

	public UnityEvent OnAccept;

	public CollapseEvent OnCollapse;

	[NonSerialized]
	public GameObject BlockPanel;

	[NonSerialized]
	public GUIWindow Child;

	[NonSerialized]
	public GUIWindow Parent;

	private float LastHeight;

	private float LastWidth;

	public RectTransform rectTransform;

	public bool IsActiveWindow
	{
		get
		{
			return WindowManager.Instance.IsActiveWindow(this);
		}
	}

	public bool CanSize
	{
		get
		{
			if (SizeButton != null)
			{
				return SizeButton.activeSelf;
			}
			return false;
		}
	}

	public bool IsCollapsed
	{
		get
		{
			return Collapsed;
		}
	}

	public bool Shown
	{
		get
		{
			return base.gameObject.activeSelf;
		}
	}

	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			if (_title != value)
			{
				_title = value;
				TitleText.text = _title.Loc().Capitalize();
			}
		}
	}

	public string NonLocTitle
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
			TitleText.text = _title.Capitalize();
		}
	}

	public void SetParentWindow(GUIWindow p, bool hideBlock = false)
	{
		if (p != null)
		{
			Parent = p;
			p.Child = this;
			WindowManager.BlockWindow(p, hideBlock);
		}
	}

	[ContextMenu("Fix close button")]
	public void FixCloseButton()
	{
		Transform transform = Utilities.FindTransformPath("TopPanel/CloseButton", base.transform);
		if (transform != null)
		{
			CloseButton = transform.gameObject;
		}
	}

	public void ChangeActive(bool active)
	{
		if (TopPanel != null)
		{
			if (active || AlwaysOnTop)
			{
				TopPanel.color = _activeColor;
			}
			else
			{
				TopPanel.color = _inactiveColor;
			}
		}
		if (!(MainPanel != null) || IgnoreWindowBorder)
		{
			return;
		}
		Image component = MainPanel.GetComponent<Image>();
		if (component != null)
		{
			if (active || AlwaysOnTop)
			{
				component.sprite = ObjectDatabase.Instance.ActiveWindow;
				component.color = component.color.Alpha(0.98f);
			}
			else
			{
				component.sprite = ObjectDatabase.Instance.InactiveWindow;
				component.color = component.color.Alpha(0.95f);
			}
		}
	}

	public void ToggleCollapse()
	{
		if (Collapsed)
		{
			if (reactiveSizeButton)
			{
				SizeButton.SetActive(true);
				reactiveSizeButton = false;
			}
			float num = TitleText.preferredWidth + 64f;
			rectTransform.anchoredPosition = new Vector2(Mathf.RoundToInt(rectTransform.anchoredPosition.x - (LastWidth - num)), Mathf.RoundToInt(rectTransform.anchoredPosition.y));
			rectTransform.sizeDelta = new Vector2(Mathf.RoundToInt(LastWidth), Mathf.RoundToInt(LastHeight));
			MainPanel.SetActive(true);
		}
		else
		{
			if (CanSize)
			{
				SizeButton.SetActive(false);
				reactiveSizeButton = true;
			}
			LastWidth = rectTransform.sizeDelta.x;
			LastHeight = rectTransform.sizeDelta.y;
			float num2 = TitleText.preferredWidth + 64f;
			rectTransform.anchoredPosition = new Vector2(Mathf.RoundToInt(rectTransform.anchoredPosition.x + (LastWidth - num2)), Mathf.RoundToInt(rectTransform.anchoredPosition.y));
			rectTransform.sizeDelta = new Vector2(Mathf.RoundToInt(num2), 23f);
			MainPanel.SetActive(false);
		}
		Collapsed = !Collapsed;
		OnCollapse.Invoke(Collapsed);
	}

	private void Start()
	{
		Title = Title ?? InitialTitle;
		rectTransform = GetComponent<RectTransform>();
		ChangeAssociatedTutorial(AssociatedTutorial);
		if (StartHidden)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			WindowManager.RegisterWindow(this);
		}
	}

	public void ChangeAssociatedTutorial(string tutorial)
	{
		AssociatedTutorial = tutorial;
		if (!(HelpButton != null))
		{
			return;
		}
		if (!string.IsNullOrEmpty(AssociatedTutorial))
		{
			HelpButton.gameObject.SetActive(true);
			HelpButton.onClick.RemoveAllListeners();
			HelpButton.onClick.AddListener(delegate
			{
				TutorialSystem.Instance.StartTutorial(AssociatedTutorial, true);
			});
			HelpButton.GetComponent<GUIToolTipper>().TooltipDescription = "StartTutorialTip".Loc(AssociatedTutorial.LocTry());
		}
		else
		{
			HelpButton.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (Dragging)
		{
			rectTransform.anchoredPosition = new Vector2(Mathf.RoundToInt(Mathf.Clamp(Input.mousePosition.x / Options.UISize - InitMouseOffset.x, 0f - rectTransform.sizeDelta.x + 96f, (float)Screen.width / Options.UISize - 64f)), Mathf.RoundToInt(Mathf.Clamp((Input.mousePosition.y - (float)Screen.height) / Options.UISize - InitMouseOffset.y, (float)(-Screen.height) / Options.UISize + 64f, 0f)));
			if (Input.GetMouseButtonUp(0))
			{
				Dragging = false;
				if (SavePosition)
				{
					Options.AddWindowSize(WindowSizeID, new SVector3(Collapsed ? (rectTransform.anchoredPosition.x - (LastWidth - rectTransform.sizeDelta.x)) : rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, Collapsed ? LastWidth : rectTransform.sizeDelta.x, Collapsed ? LastHeight : rectTransform.sizeDelta.y));
				}
			}
		}
		else if (Sizing)
		{
			float num = (SizeMove ? (InitMouseOffset.x - Input.mousePosition.x / Options.UISize) : (Input.mousePosition.x / Options.UISize - InitMouseOffset.x));
			float num2 = (SizeMove ? (InitMouseOffset.y - Input.mousePosition.y / Options.UISize) : (Input.mousePosition.y / Options.UISize - InitMouseOffset.y));
			float x = (SizeHor ? ((float)Mathf.RoundToInt(Mathf.Clamp(InitWindowSize.x + num, MinSize.x, (float)Screen.width / Options.UISize))) : rectTransform.sizeDelta.x);
			float y = (SizeVert ? ((float)Mathf.RoundToInt(Mathf.Clamp(InitWindowSize.y - num2, MinSize.y, (float)Screen.height / Options.UISize))) : rectTransform.sizeDelta.y);
			rectTransform.sizeDelta = new Vector2(x, y);
			if (SizeMove)
			{
				x = (SizeHor ? ((float)Mathf.RoundToInt(Mathf.Clamp(InitWindowOffset.x + (InitWindowSize.x - rectTransform.sizeDelta.x), 0f, (float)Screen.width / Options.UISize - 24f))) : rectTransform.anchoredPosition.x);
				y = (SizeVert ? ((float)Mathf.RoundToInt(Mathf.Clamp(InitWindowOffset.y + (InitWindowSize.y - rectTransform.sizeDelta.y), 0f, (float)Screen.height / Options.UISize - 24f))) : rectTransform.anchoredPosition.y);
				rectTransform.anchoredPosition = new Vector2(x, y);
			}
			if (ContinuallyUpdateSize)
			{
				OnSizeChanged.Invoke();
			}
			if (Input.GetMouseButtonUp(0))
			{
				Sizing = false;
				OnSizeChanged.Invoke();
				SaveSize();
			}
		}
		if (OnAccept != null && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && IsActiveWindow && !InputController.InputEnabled && !DevConsole.Console.isOpen)
		{
			OnAccept.Invoke();
		}
	}

	public void SaveSize()
	{
		Options.AddWindowSize(WindowSizeID, new SVector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, Collapsed ? LastWidth : rectTransform.sizeDelta.x, Collapsed ? LastHeight : rectTransform.sizeDelta.y));
	}

	public void BeginDrag()
	{
		InitMouseOffset = new Vector2(Input.mousePosition.x / Options.UISize - rectTransform.anchoredPosition.x, (Input.mousePosition.y - (float)Screen.height) / Options.UISize - rectTransform.anchoredPosition.y);
		Dragging = true;
	}

	public void BeginSize()
	{
		BeginSize(true, true, false);
	}

	public void BeginSize(bool horizontal, bool vertical, bool move)
	{
		InitMouseOffset = new Vector2(Input.mousePosition.x / Options.UISize, Input.mousePosition.y / Options.UISize);
		SizeHor = horizontal;
		SizeVert = vertical;
		SizeMove = move;
		Sizing = true;
		InitWindowOffset = rectTransform.anchoredPosition;
		InitWindowSize = rectTransform.sizeDelta;
		HelpTipPanel.DismissHint(HintController.Hints.HintResizeWindow);
	}

	private void OnDestroy()
	{
		WindowManager.DeregisterWindow(this);
		if (Parent != null && Parent.Child == this && Parent.BlockPanel != null)
		{
			UnityEngine.Object.Destroy(Parent.BlockPanel);
			Parent.Child = null;
		}
	}

	public void Toggle(bool forceRegister = false)
	{
		ToggleReturn(forceRegister);
	}

	public bool ToggleReturn(bool forceRegister = false)
	{
		if (Shown)
		{
			if (Collapsed)
			{
				ToggleCollapse();
				WindowManager.Focus(this);
			}
			else if (WindowManager.Instance.GetFrontMostWindow() != this)
			{
				WindowManager.Focus(this);
			}
			else
			{
				Close();
			}
			return false;
		}
		Show(forceRegister);
		return true;
	}

	public void Show()
	{
		Show(false);
	}

	public void Show(bool forceRegister, bool resetCollapse = true)
	{
		if (base.gameObject.activeSelf && !forceRegister)
		{
			WindowManager.Focus(this);
		}
		else
		{
			if (rectTransform == null)
			{
				rectTransform = GetComponent<RectTransform>();
			}
			WindowManager.RegisterWindow(this);
			base.gameObject.SetActive(true);
			if (!Collapsed && CanSize)
			{
				HelpTipPanel.Show(HintController.Hints.HintResizeWindow, SizeButton.GetComponent<RectTransform>());
			}
		}
		if (resetCollapse && Collapsed)
		{
			ToggleCollapse();
		}
		HasBeenShown = true;
	}

	public void CloseClick()
	{
		HintController.Show(HintController.Hints.HintCloseWindows);
		if (!string.IsNullOrWhiteSpace(ClosePrompt))
		{
			WindowManager.Instance.ShowMessageBox(ClosePrompt.Loc(), true, DialogWindow.DialogType.Question, Close).Window.SetParentWindow(this);
		}
		else
		{
			Close();
		}
	}

	public void Close()
	{
		if (OnClose != null && !OnCloseAfter)
		{
			OnClose();
		}
		if (OnlyHide)
		{
			bool shown = Shown;
			WindowManager.DeregisterWindow(this);
			base.gameObject.SetActive(false);
			if (SpawnFrom != null && shown)
			{
				WindowManager.SpawnFader(SpawnFrom, rectTransform);
			}
			if (Parent != null && Parent.Child == this && Parent.BlockPanel != null)
			{
				Parent.Child = null;
				UnityEngine.Object.Destroy(Parent.BlockPanel);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (OnClose != null && OnCloseAfter)
		{
			OnClose();
		}
	}

	public void Focus()
	{
		WindowManager.Focus(this);
	}
}
