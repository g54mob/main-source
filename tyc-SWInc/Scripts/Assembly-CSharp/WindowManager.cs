using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Achievements;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
	[NonSerialized]
	private List<GUIWindow> ActiveWindows = new List<GUIWindow>();

	[NonSerialized]
	private List<GUIWindow> ModalWindows = new List<GUIWindow>();

	[NonSerialized]
	private bool _hasModal;

	public GameObject DialogPrefab;

	public GameObject ColorDialogPrefab;

	public GameObject InputDialogPrefab;

	public GameObject TableInfoPrefab;

	public GameObject FileReaderPrefab;

	public CustomDifficultyWindow DifficultyWindowPrefab;

	public GameObject Canvas;

	public CanvasScaler ExtraScaler;

	public GameObject MainPanel;

	public GameObject BlockPanel;

	public GameObject WindowPrefab;

	public GameObject LabelPrefab;

	public GameObject PanelPrefab;

	public GameObject ButtonPrefab;

	public GameObject InputPrefab;

	public GameObject CheckboxPrefab;

	public GameObject ScrollbarPrefab;

	public GameObject ScrollViewPrefab;

	public GameObject ProgressbarPrefab;

	public GameObject GUIListPrefab;

	public GameObject SliderPrefab;

	public GameObject ComboPrefab;

	public RectTransform BlockPrefab;

	public RectToRectFade Fader;

	public MultiSelectWindow MultiWindow;

	public GameObject FullScreenMessageBlock;

	public RectTransform AchievementPanel;

	public Text FullScreenMessage;

	public GUIProgressBar FullScreenProgressBar;

	public InspectorWindow InspectorWindowPrefab;

	public static WindowManager Instance;

	public int StartIndex = 1;

	public bool MainScene;

	private Vector2 Corner = new Vector2(64f, 64f);

	[NonSerialized]
	private Dictionary<string, GUIWindow> InfoTableOpen = new Dictionary<string, GUIWindow>();

	[NonSerialized]
	private string _overrideCursor;

	private static readonly List<RaycastResult> CastResult = new List<RaycastResult>();

	private GUIWindow _lastActive;

	[NonSerialized]
	private Sequence _activeSequence;

	private static Dictionary<string, Func<string, ValueTuple<UnityEngine.Component, GameObject>>> _objectTags = new Dictionary<string, Func<string, ValueTuple<UnityEngine.Component, GameObject>>>
	{
		{
			"empty",
			delegate
			{
				GameObject gameObject = new GameObject("Empty");
				return new ValueTuple<UnityEngine.Component, GameObject>(gameObject.AddComponent<RectTransform>(), gameObject);
			}
		},
		{
			"panel",
			delegate
			{
				RectTransform rectTransform = SpawnPanel();
				return new ValueTuple<UnityEngine.Component, GameObject>(rectTransform, rectTransform.gameObject);
			}
		},
		{
			"button",
			delegate(string x)
			{
				Button button = SpawnButton();
				button.GetComponentInChildren<Text>().text = x;
				return new ValueTuple<UnityEngine.Component, GameObject>(button, button.gameObject);
			}
		},
		{
			"label",
			delegate(string x)
			{
				Text text = SpawnLabel();
				text.text = x;
				return new ValueTuple<UnityEngine.Component, GameObject>(text, text.gameObject);
			}
		},
		{
			"list",
			delegate
			{
				GUIListView gUIListView = SpawnList();
				return new ValueTuple<UnityEngine.Component, GameObject>(gUIListView, gUIListView.gameObject);
			}
		},
		{
			"input",
			delegate(string x)
			{
				InputField inputField = SpawnInputbox();
				inputField.text = x;
				return new ValueTuple<UnityEngine.Component, GameObject>(inputField, inputField.gameObject);
			}
		},
		{
			"checkbox",
			delegate(string x)
			{
				Toggle toggle = SpawnCheckbox();
				toggle.GetComponentInChildren<Text>().text = x;
				return new ValueTuple<UnityEngine.Component, GameObject>(toggle, toggle.gameObject);
			}
		},
		{
			"progressbar",
			delegate
			{
				GUIProgressBar gUIProgressBar = SpawnProgressbar();
				return new ValueTuple<UnityEngine.Component, GameObject>(gUIProgressBar, gUIProgressBar.gameObject);
			}
		},
		{
			"slider",
			delegate
			{
				Slider slider = SpawnSlider();
				return new ValueTuple<UnityEngine.Component, GameObject>(slider, slider.gameObject);
			}
		},
		{
			"combo",
			delegate(string x)
			{
				GUICombobox gUICombobox = SpawnComboBox();
				gUICombobox.UpdateContent(SplitXMLValue(x));
				return new ValueTuple<UnityEngine.Component, GameObject>(gUICombobox, gUICombobox.gameObject);
			}
		},
		{
			"scrollbar",
			delegate
			{
				Scrollbar scrollbar = SpawnScrollBar();
				return new ValueTuple<UnityEngine.Component, GameObject>(scrollbar, scrollbar.gameObject);
			}
		},
		{
			"scrollview",
			delegate
			{
				ScrollRect scrollRect = SpawnScrollView();
				return new ValueTuple<UnityEngine.Component, GameObject>(scrollRect, scrollRect.content.gameObject);
			}
		},
		{
			"window",
			delegate
			{
				GUIWindow gUIWindow = SpawnWindow();
				return new ValueTuple<UnityEngine.Component, GameObject>(gUIWindow, gUIWindow.MainPanel);
			}
		},
		{
			"image",
			delegate
			{
				GameObject gameObject = new GameObject("Image");
				return new ValueTuple<UnityEngine.Component, GameObject>(gameObject.AddComponent<Image>(), gameObject);
			}
		},
		{
			"rawimage",
			delegate
			{
				GameObject gameObject = new GameObject("RawImage");
				return new ValueTuple<UnityEngine.Component, GameObject>(gameObject.AddComponent<RawImage>(), gameObject);
			}
		}
	};

	private static Dictionary<string, Func<GameObject, UnityEngine.Component>> _layoutTags = new Dictionary<string, Func<GameObject, UnityEngine.Component>>
	{
		{
			"horizontallayout",
			(GameObject x) => x.AddComponent<HorizontalLayoutGroup>()
		},
		{
			"verticallayout",
			(GameObject x) => x.AddComponent<VerticalLayoutGroup>()
		},
		{
			"gridlayout",
			(GameObject x) => x.AddComponent<GridLayoutGroup>()
		},
		{
			"contentfitter",
			(GameObject x) => x.AddComponent<ContentSizeFitter>()
		},
		{
			"layoutelement",
			(GameObject x) => x.AddComponent<LayoutElement>()
		}
	};

	private static HashSet<string> _ignoreAttributes = new HashSet<string> { "position", "width", "height", "anchor", "size", "id", "fitcontent" };

	public static bool HasModal
	{
		get
		{
			if (Instance != null)
			{
				return Instance._hasModal;
			}
			return false;
		}
	}

	public static bool FullScreenMessageActive()
	{
		if (Instance != null && Instance.FullScreenMessageBlock != null)
		{
			return Instance.FullScreenMessageBlock.activeSelf;
		}
		return false;
	}

	public static void ShowFullScreenMessage(string msg, float prog = -1f)
	{
		if (!(Instance != null) || !(Instance.FullScreenMessageBlock != null))
		{
			return;
		}
		if (msg == null)
		{
			Instance.FullScreenMessageBlock.SetActive(false);
			return;
		}
		Instance.FullScreenMessageBlock.SetActive(true);
		Instance.FullScreenMessage.text = msg;
		if (Instance.FullScreenProgressBar != null)
		{
			if (prog >= 0f)
			{
				Instance.FullScreenProgressBar.gameObject.SetActive(true);
				Instance.FullScreenProgressBar.Value = prog;
			}
			else
			{
				Instance.FullScreenProgressBar.gameObject.SetActive(false);
			}
		}
	}

	public static void UpdateUIPP()
	{
		if (Instance != null && Instance.Canvas != null)
		{
			Instance.Canvas.GetComponent<Canvas>().pixelPerfect = Options.UIPP;
		}
	}

	private void OnApplicationQuit()
	{
		GameSettings.IsQuitting = true;
		GameSettings.Instance = null;
	}

	public static void BlockWindow(GUIWindow w, bool hide)
	{
		if (Instance != null && w.BlockPanel == null)
		{
			RectTransform rectTransform = UnityEngine.Object.Instantiate(Instance.BlockPrefab);
			rectTransform.SetParent(w.rectTransform, false);
			rectTransform.offsetMax = Vector2.zero;
			rectTransform.offsetMin = Vector2.zero;
			if (hide)
			{
				rectTransform.GetComponent<Image>().color = new Color32(0, 0, 0, 1);
			}
			w.BlockPanel = rectTransform.gameObject;
		}
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		if (Canvas != null)
		{
			Canvas.GetComponent<CanvasScaler>().scaleFactor = Options.UISize;
		}
		if (ExtraScaler != null)
		{
			ExtraScaler.scaleFactor = Options.UISize;
		}
		Instance = this;
		UpdateUIPP();
		ObjectDatabase.Instance.SetCursor("Default");
	}

	public static void SetCursorOverride(string cursor)
	{
		if (Instance != null)
		{
			Instance._overrideCursor = cursor;
		}
	}

	private void Update()
	{
		AchievementController.CheckAchievements();
		if (InputController.GetKeyUp(InputController.Keys.CloseActiveWindow))
		{
			GUIWindow gUIWindow = ((TutorialSystem.Instance != null) ? GetFrontMostWindow(TutorialSystem.Instance.Window) : GetFrontMostWindow());
			if (gUIWindow != null && gUIWindow.CloseButton != null && gUIWindow.CloseButton.activeInHierarchy)
			{
				gUIWindow.Close();
			}
		}
		if (!HasModal && ComboboxPanel.OpenCombo == null && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
		{
			float num = Input.mousePosition.x / Options.UISize;
			float num2 = ((float)Screen.height - Input.mousePosition.y) / Options.UISize;
			for (int num3 = ActiveWindows.Count - 1; num3 >= 0; num3--)
			{
				GUIWindow gUIWindow2 = ActiveWindows[num3];
				if (gUIWindow2 == null || gUIWindow2.gameObject == null)
				{
					ActiveWindows.RemoveAt(num3);
					num3--;
				}
				else
				{
					float x = gUIWindow2.rectTransform.anchoredPosition.x;
					float num4 = 0f - gUIWindow2.rectTransform.anchoredPosition.y;
					float num5 = x + gUIWindow2.rectTransform.rect.width;
					float num6 = num4 + gUIWindow2.rectTransform.rect.height;
					if (num >= x && num <= num5 && num2 >= num4 && num2 <= num6)
					{
						if (gUIWindow2.Child != null)
						{
							gUIWindow2.Child.Focus();
						}
						else
						{
							gUIWindow2.Focus();
						}
						break;
					}
				}
			}
		}
		int num7;
		object obj;
		if (!GUICheck.OverGUI)
		{
			num7 = ((_overrideCursor != null) ? 1 : 0);
			if (num7 != 0)
			{
				obj = _overrideCursor;
				goto IL_01d7;
			}
		}
		else
		{
			num7 = 0;
		}
		obj = "Default";
		goto IL_01d7;
		IL_01d7:
		string cursor = (string)obj;
		if (num7 == 0 && Options.CustomCursor)
		{
			if (SelectorController.Instance != null && SelectorController.Instance.MouseOverSelectable())
			{
				cursor = "Finger";
			}
			else
			{
				CastResult.Clear();
				EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current).PopulateDefault(), CastResult);
				if (CastResult.Count > 0)
				{
					Transform parent = CastResult[0].gameObject.transform;
					while (parent != null)
					{
						ICursorOverride component = parent.GetComponent<ICursorOverride>();
						if (component != null)
						{
							if (component.CursorOverrideName != null)
							{
								cursor = component.CursorOverrideName;
								break;
							}
							parent = parent.parent;
							continue;
						}
						UnityEngine.UI.Selectable component2 = parent.GetComponent<UnityEngine.UI.Selectable>();
						if (component2 != null)
						{
							if (component2.interactable)
							{
								Scrollbar scrollbar;
								Slider slider;
								cursor = (((object)(scrollbar = component2 as Scrollbar) == null) ? (((object)(slider = component2 as Slider) == null) ? ((!(component2 is InputField)) ? "Finger" : "Text") : ((slider.direction == Slider.Direction.BottomToTop || slider.direction == Slider.Direction.TopToBottom) ? "VerticalStretch" : "HorizontalStretch")) : ((scrollbar.direction == Scrollbar.Direction.BottomToTop || scrollbar.direction == Scrollbar.Direction.TopToBottom) ? "VerticalStretch" : "HorizontalStretch"));
							}
							break;
						}
						ScrollRect component3 = parent.GetComponent<ScrollRect>();
						if (component3 != null)
						{
							RectTransform content = component3.content;
							RectTransform rectTransform = ((component3.viewport == null) ? component3.GetComponent<RectTransform>() : component3.viewport);
							if (content.rect.height > rectTransform.rect.height || content.rect.width > rectTransform.rect.width)
							{
								cursor = "Grab";
							}
							break;
						}
						if (parent.GetComponent<IPointerClickHandler>() != null)
						{
							EventTrigger component4 = parent.GetComponent<EventTrigger>();
							if (component4 == null || component4.triggers.Any((EventTrigger.Entry entry) => entry.eventID == EventTriggerType.PointerClick))
							{
								cursor = "Finger";
							}
							break;
						}
						parent = parent.parent;
					}
				}
			}
		}
		ObjectDatabase.Instance.SetCursor(cursor);
	}

	private IEnumerator Start()
	{
		if (!AudioManager.VolumeLoaded)
		{
			foreach (KeyValuePair<string, float> initVolume in AudioManager.InitVolumes)
			{
				AudioManager.SetVolume(initVolume.Key, initVolume.Value, false);
			}
			AudioManager.VolumeLoaded = true;
		}
		if (!Options.UIPP && Canvas != null)
		{
			yield return new WaitForEndOfFrame();
			while (SelectorController.Instance != null && !SelectorController.Instance.DoneLoading)
			{
				yield return new WaitForEndOfFrame();
			}
			Canvas.SetActive(false);
			Canvas.SetActive(true);
		}
	}

	public static string GetPathToObject(Transform sel, HashSet<Transform> visited = null)
	{
		if (Instance == null)
		{
			return null;
		}
		if (sel.parent == null)
		{
			return null;
		}
		string text = GetNameWithIndex(sel);
		if (visited != null)
		{
			visited.Add(sel);
		}
		sel = sel.parent;
		while (sel.gameObject != Instance.Canvas)
		{
			if (visited != null)
			{
				visited.Add(sel);
			}
			text = GetNameWithIndex(sel) + "/" + text;
			sel = sel.parent;
			if (sel == null)
			{
				return null;
			}
		}
		return text;
	}

	private static string GetNameWithIndex(Transform t)
	{
		string text = t.name;
		Transform parent = t.parent;
		int num = 0;
		if (parent != null)
		{
			for (int i = 0; i < parent.childCount; i++)
			{
				Transform child = parent.GetChild(i);
				if (child == t)
				{
					break;
				}
				if (child.name.Equals(t.name))
				{
					num++;
				}
			}
		}
		if (num > 0)
		{
			text = text + "[" + num + "]";
		}
		return text;
	}

	public static RectTransform FindElementPath(string path, Transform startFrom = null)
	{
		if (Instance == null)
		{
			return null;
		}
		Transform transform = Utilities.FindTransformPath(path, startFrom ?? Instance.Canvas.transform);
		if (!(transform == null))
		{
			return transform.GetComponent<RectTransform>();
		}
		return null;
	}

	public static void AddElementToWindow(GameObject element, GUIWindow window, Rect position, Rect anchors)
	{
		AddElementToElement(element, window.MainPanel, position, anchors);
	}

	public static void AddElementToElement(GameObject element, GameObject parent, Rect position, Rect anchors)
	{
		element.transform.SetParent(parent.transform, false);
		SetElementDimension(element.GetComponent<RectTransform>(), position, anchors);
	}

	public static void SetElementDimension(RectTransform er, Rect position, Rect anchors)
	{
		er.anchorMin = new Vector2(anchors.xMin, 1f - anchors.yMax);
		er.anchorMax = new Vector2(anchors.xMax, 1f - anchors.yMin);
		er.offsetMin = new Vector2(position.xMin, 0f - position.yMax);
		er.offsetMax = new Vector2(position.xMax, 0f - position.yMin);
	}

	public bool IsActiveWindow(GUIWindow window)
	{
		return window == GetFrontMostWindow();
	}

	public GUIWindow GetFrontMostWindow()
	{
		if (HasModal && ModalWindows.Count > 0)
		{
			return ModalWindows[ModalWindows.Count - 1];
		}
		if (ActiveWindows.Count > 0)
		{
			return ActiveWindows[ActiveWindows.Count - 1];
		}
		return null;
	}

	public GUIWindow GetFrontMostWindow(GUIWindow excluding)
	{
		if (HasModal && ModalWindows.Count > 0)
		{
			for (int num = ModalWindows.Count - 1; num >= 0; num--)
			{
				if (ModalWindows[num] != excluding)
				{
					return ModalWindows[num];
				}
			}
		}
		if (ActiveWindows.Count > 0)
		{
			for (int num2 = ActiveWindows.Count - 1; num2 >= 0; num2--)
			{
				if (ActiveWindows[num2] != excluding)
				{
					return ActiveWindows[num2];
				}
			}
		}
		return null;
	}

	public static GUIWindow SpawnWindow()
	{
		if (Instance == null)
		{
			return null;
		}
		GUIWindow gUIWindow = SpawnObject<GUIWindow>(Instance.WindowPrefab);
		gUIWindow.transform.SetParent(Instance.Canvas.transform, false);
		return gUIWindow;
	}

	public static Text SpawnLabel()
	{
		if (!(Instance == null))
		{
			return SpawnObject<Text>(Instance.LabelPrefab);
		}
		return null;
	}

	public static GUIListView SpawnList()
	{
		if (!(Instance == null))
		{
			return SpawnObject<GUIListView>(Instance.GUIListPrefab);
		}
		return null;
	}

	public static InputField SpawnInputbox()
	{
		if (!(Instance == null))
		{
			return SpawnObject<InputField>(Instance.InputPrefab);
		}
		return null;
	}

	public static RectTransform SpawnPanel()
	{
		if (!(Instance == null))
		{
			return SpawnObject<RectTransform>(Instance.PanelPrefab);
		}
		return null;
	}

	public static Button SpawnButton()
	{
		if (!(Instance == null))
		{
			return SpawnObject<Button>(Instance.ButtonPrefab);
		}
		return null;
	}

	public static Toggle SpawnCheckbox()
	{
		if (!(Instance == null))
		{
			return SpawnObject<Toggle>(Instance.CheckboxPrefab);
		}
		return null;
	}

	public static GUIProgressBar SpawnProgressbar()
	{
		if (!(Instance == null))
		{
			return SpawnObject<GUIProgressBar>(Instance.ProgressbarPrefab);
		}
		return null;
	}

	public static Scrollbar SpawnScrollBar()
	{
		if (!(Instance == null))
		{
			return SpawnObject<Scrollbar>(Instance.ScrollbarPrefab);
		}
		return null;
	}

	public static ScrollRect SpawnScrollView()
	{
		if (!(Instance == null))
		{
			return SpawnObject<ScrollRect>(Instance.ScrollViewPrefab);
		}
		return null;
	}

	public static Slider SpawnSlider()
	{
		if (!(Instance == null))
		{
			return SpawnObject<Slider>(Instance.SliderPrefab);
		}
		return null;
	}

	public static GUICombobox SpawnComboBox()
	{
		if (!(Instance == null))
		{
			return SpawnObject<GUICombobox>(Instance.ComboPrefab);
		}
		return null;
	}

	private static T SpawnObject<T>(GameObject o)
	{
		if (o == null)
		{
			return default(T);
		}
		return UnityEngine.Object.Instantiate(o).GetComponent<T>();
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public static DialogWindow SpawnDialog()
	{
		GameObject obj = UnityEngine.Object.Instantiate(Instance.DialogPrefab);
		obj.transform.SetParent(Instance.Canvas.transform, false);
		return obj.GetComponent<DialogWindow>();
	}

	public static void SpawnDialog(string msg, bool modal, DialogWindow.DialogType type)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Instance.DialogPrefab);
		gameObject.transform.SetParent(Instance.Canvas.transform, false);
		DialogWindow diag = gameObject.GetComponent<DialogWindow>();
		diag.Show(msg, !modal, type, new KeyValuePair<string, Action>("OK", delegate
		{
			diag.Window.Close();
		}));
	}

	public static InputDialog SpawnInputDialog(string prompt, string title, string defaultText, Action<string> onFinish, Action onCancel = null, int characterLimit = 0, GUIWindow parent = null)
	{
		GameObject obj = UnityEngine.Object.Instantiate(Instance.InputDialogPrefab);
		obj.transform.SetParent(Instance.Canvas.transform, false);
		InputDialog component = obj.GetComponent<InputDialog>();
		component.Init(prompt, title, defaultText, onFinish, onCancel, characterLimit);
		if (parent != null)
		{
			component.Window.SetParentWindow(parent);
		}
		return component;
	}

	public static GUIWindow GetTableInfoWindow(string ID)
	{
		return Instance.InfoTableOpen.GetOrNull(ID);
	}

	public static void SpawnTableInfoWindow(string title, string header, string[] var, string[] value, string ID = null, Dictionary<string, float> pie = null, IManufacturable cat = null, List<FeatureBase> features = null, List<uint> factors = null, List<SoftwareWorkItem> addons = null)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Instance.TableInfoPrefab);
		gameObject.transform.SetParent(Instance.Canvas.transform, false);
		gameObject.GetComponent<TableInfoWindow>().Init(title, header, var, value, ID, pie, cat, features, factors, addons);
		if (ID != null)
		{
			GUIWindow value2;
			if (Instance.InfoTableOpen.TryGetValue(ID, out value2))
			{
				value2.Close();
			}
			Instance.InfoTableOpen[ID] = gameObject.GetComponent<GUIWindow>();
		}
	}

	public static void DeregisterTableInfoWindow(string ID)
	{
		Instance.InfoTableOpen.Remove(ID);
	}

	public static bool ModalMessageDialogOpen()
	{
		if (Instance != null && Instance.ModalWindows.Count > 0)
		{
			return Instance.ModalWindows.Any((GUIWindow x) => x.GetComponent<DialogWindow>() != null);
		}
		return false;
	}

	public static List<T> FindWindowType<T>()
	{
		if (Instance != null)
		{
			List<T> list = Instance.ActiveWindows.SelectNotNull((GUIWindow x) => x.GetComponent<T>()).ToList();
			list.AddRange(Instance.ModalWindows.SelectNotNull((GUIWindow x) => x.GetComponent<T>()));
			return list;
		}
		return null;
	}

	public static T FindFirstWindowType<T>()
	{
		if (Instance != null)
		{
			for (int i = 0; i < Instance.ActiveWindows.Count; i++)
			{
				T component = Instance.ActiveWindows[i].GetComponent<T>();
				if (component != null)
				{
					return component;
				}
			}
			for (int j = 0; j < Instance.ModalWindows.Count; j++)
			{
				T component2 = Instance.ModalWindows[j].GetComponent<T>();
				if (component2 != null)
				{
					return component2;
				}
			}
		}
		return default(T);
	}

	public static IEnumerable<T> FindWindowTypeEnum<T>()
	{
		if (!(Instance != null))
		{
			yield break;
		}
		for (int i = 0; i < Instance.ActiveWindows.Count; i++)
		{
			T component = Instance.ActiveWindows[i].GetComponent<T>();
			if (component != null)
			{
				yield return component;
			}
		}
		for (int i = 0; i < Instance.ModalWindows.Count; i++)
		{
			T component2 = Instance.ModalWindows[i].GetComponent<T>();
			if (component2 != null)
			{
				yield return component2;
			}
		}
	}

	public static bool AnyWindowsOfType<T>()
	{
		if (Instance == null)
		{
			return false;
		}
		for (int i = 0; i < Instance.ActiveWindows.Count; i++)
		{
			if (Instance.ActiveWindows[i].GetComponent<T>() != null)
			{
				return true;
			}
		}
		for (int j = 0; j < Instance.ModalWindows.Count; j++)
		{
			if (Instance.ModalWindows[j].GetComponent<T>() != null)
			{
				return true;
			}
		}
		return false;
	}

	public static ColorWindow SpawnColorDialog(Action<Color> action, Color startColor, HashSet<Color> defaults = null, Action extraClose = null, bool continualUpdates = true, GUIWindow parent = null)
	{
		return SpawnColorDialog(new string[1] { "" }, new Action<Color>[1] { action }, new Color[1] { startColor }, defaults, extraClose, continualUpdates, parent);
	}

	public static ColorWindow SpawnColorDialog(IList<string> tabs, IList<Action<Color>> actions, IList<Color> startColors, HashSet<Color> defaults = null, Action extraClose = null, bool continualUpdates = true, GUIWindow parent = null, Action onApply = null)
	{
		GameObject obj = UnityEngine.Object.Instantiate(Instance.ColorDialogPrefab);
		obj.transform.SetParent(Instance.Canvas.transform, false);
		RectTransform component = obj.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2((float)(Screen.width / 2) - component.rect.width / 2f, (float)(-Screen.height / 2) + component.rect.height / 2f);
		ColorWindow component2 = obj.GetComponent<ColorWindow>();
		component2.ContinualUpdates = continualUpdates;
		component2.Init(tabs, actions, startColors, defaults, extraClose, onApply);
		if (parent != null)
		{
			component2.Window.SetParentWindow(parent);
		}
		return component2;
	}

	public CustomDifficultyWindow SpawnDifficultyDialog(DifficultyValues.DifficultySetting setting, Action<DifficultyValues.DifficultySetting> onAccept, GUIWindow parent)
	{
		CustomDifficultyWindow customDifficultyWindow = UnityEngine.Object.Instantiate(DifficultyWindowPrefab);
		customDifficultyWindow.transform.SetParent(Canvas.transform, false);
		customDifficultyWindow.Show(setting, onAccept);
		customDifficultyWindow.Window.SetParentWindow(parent);
		return customDifficultyWindow;
	}

	private void UpdateCorner(Vector2 size)
	{
		Vector2 vector = Options.MainPanelOffset ?? Vector2.zero;
		float num = (float)Screen.width / Options.UISize - size.x - vector.x - vector.y;
		float num2 = (float)Screen.height / Options.UISize - size.y;
		Corner = new Vector2((num <= 0f) ? 0f : ((Corner.x + 64f) % num), (num2 <= 0f) ? 0f : ((Corner.y + 64f) % num2));
	}

	public static void RegisterWindow(GUIWindow window)
	{
		if (Instance == null)
		{
			throw new Exception("Tried to register a window before WindowManager was ready");
		}
		bool flag = false;
		bool flag2 = window.ForcePosition || window.ShowCentered;
		if (!window.IsCollapsed && !string.IsNullOrEmpty(window.WindowSizeID))
		{
			SVector3 windowSize = Options.GetWindowSize(window.WindowSizeID);
			if (windowSize != null && windowSize.z > 0f && windowSize.w > 0f)
			{
				if (!window.ShowCentered && window.SavePosition)
				{
					window.rectTransform.anchoredPosition = new Vector2(windowSize.x, windowSize.y);
					flag2 = true;
				}
				if (window.CanSize)
				{
					window.rectTransform.sizeDelta = new Vector2(Mathf.Max(window.rectTransform.sizeDelta.x, windowSize.z), Mathf.Max(window.rectTransform.sizeDelta.y, windowSize.w));
				}
			}
			else if (windowSize == null && !window.HasBeenShown && window.CanSize)
			{
				float num = Mathf.Min((float)Screen.width / 1024f, (float)Screen.height / 768f) / Options.UISize;
				if (num > 1f)
				{
					window.rectTransform.sizeDelta = new Vector2(Mathf.Max(window.MinSize.x, window.rectTransform.sizeDelta.x * num), Mathf.Max(window.MinSize.y, window.rectTransform.sizeDelta.y * num));
					flag = true;
				}
			}
		}
		if (!flag2 && !window.HasBeenShown)
		{
			Instance.UpdateCorner(window.rectTransform.sizeDelta);
			Vector2 vector = Options.MainPanelOffset ?? Vector2.zero;
			window.rectTransform.anchoredPosition = new Vector2(Instance.Corner.x + vector.x, 0f - Instance.Corner.y);
		}
		window.rectTransform.sizeDelta = new Vector2(Mathf.RoundToInt(Mathf.Clamp(window.rectTransform.sizeDelta.x, window.MinSize.x, (float)Screen.width / Options.UISize)), Mathf.RoundToInt(Mathf.Clamp(window.rectTransform.sizeDelta.y, window.MinSize.y, (float)Screen.height / Options.UISize)));
		if (window.ShowCentered)
		{
			window.rectTransform.anchoredPosition = new Vector2(Mathf.RoundToInt((float)(Screen.width / 2) / Options.UISize - window.rectTransform.sizeDelta.x / 2f), Mathf.RoundToInt((float)(-Screen.height / 2) / Options.UISize + window.rectTransform.sizeDelta.y / 2f));
		}
		else if (!window.ForcePosition)
		{
			window.rectTransform.anchoredPosition = new Vector2(Mathf.RoundToInt(Mathf.Clamp(window.rectTransform.anchoredPosition.x, 0f - window.rectTransform.sizeDelta.x + 96f, (float)Screen.width / Options.UISize - 64f)), Mathf.RoundToInt(Mathf.Clamp(window.rectTransform.anchoredPosition.y, (float)(-Screen.height) / Options.UISize + window.rectTransform.sizeDelta.y, 0f)));
		}
		if (window.Modal)
		{
			if (Instance.ActiveWindows.Contains(window))
			{
				Instance.ActiveWindows.Remove(window);
			}
			if (!Instance.ModalWindows.Contains(window))
			{
				Instance.ModalWindows.Add(window);
				Instance._hasModal = true;
			}
		}
		else
		{
			if (Instance.ModalWindows.Contains(window))
			{
				Instance.ModalWindows.Remove(window);
			}
			if (!Instance.ActiveWindows.Contains(window))
			{
				Instance.AddWindow(window);
			}
		}
		Focus(window);
		if (HasModal)
		{
			GUIWindow gUIWindow = Instance.ModalWindows[Instance.ModalWindows.Count - 1];
			Focus(gUIWindow);
			ActivateBlockPanel(true, !gUIWindow.HideBlockPanel);
		}
		Instance.MakeTopMostActive();
		if (flag)
		{
			window.SaveSize();
		}
	}

	public static void Focus(GUIWindow window)
	{
		if (!(Instance != null))
		{
			return;
		}
		int num = Instance.ActiveWindows.IndexOf(window);
		if (num > -1)
		{
			if (num < Instance.ActiveWindows.Count - 1)
			{
				Instance.ActiveWindows.RemoveAt(num);
				Instance.AddWindow(window);
			}
		}
		else
		{
			num = Instance.ModalWindows.IndexOf(window);
			if (num > -1 && num < Instance.ModalWindows.Count - 1)
			{
				Instance.ModalWindows.RemoveAt(num);
				Instance.ModalWindows.Add(window);
			}
		}
		Instance.ReorderWindows();
		Instance.MakeTopMostActive();
	}

	private void AddWindow(GUIWindow window)
	{
		if (window.AlwaysOnTop)
		{
			ActiveWindows.Add(window);
		}
		else if (ActiveWindows.Any((GUIWindow x) => x.AlwaysOnTop))
		{
			int num;
			for (num = 0; num < ActiveWindows.Count && !ActiveWindows[num].AlwaysOnTop; num++)
			{
			}
			ActiveWindows.Insert(num, window);
		}
		else
		{
			ActiveWindows.Add(window);
		}
	}

	private void ReorderWindows()
	{
		int num = Instance.StartIndex;
		for (int i = 0; i < ActiveWindows.Count; i++)
		{
			GUIWindow gUIWindow = ActiveWindows[i];
			if (gUIWindow == null || gUIWindow.gameObject == null)
			{
				ActiveWindows.RemoveAt(i);
				i--;
			}
			else if (!gUIWindow.AlwaysOnTop)
			{
				gUIWindow.transform.SetSiblingIndex(num);
				num++;
			}
		}
		if (Instance.BlockPanel != null)
		{
			Instance.BlockPanel.transform.SetSiblingIndex(num);
			num++;
		}
		for (int j = 0; j < ModalWindows.Count; j++)
		{
			GUIWindow gUIWindow2 = ModalWindows[j];
			if (gUIWindow2 == null || gUIWindow2.gameObject == null)
			{
				ModalWindows.RemoveAt(j);
				j--;
			}
			else
			{
				gUIWindow2.transform.SetSiblingIndex(num);
				num++;
			}
		}
		for (int k = 0; k < ActiveWindows.Count; k++)
		{
			GUIWindow gUIWindow3 = ActiveWindows[k];
			if (gUIWindow3.AlwaysOnTop)
			{
				gUIWindow3.transform.SetSiblingIndex(num);
				num++;
			}
		}
	}

	private static void ActivateMainPanel(bool activate)
	{
		if (Instance != null && Instance.MainPanel != null)
		{
			Instance.MainPanel.SetActive(activate);
		}
	}

	private static void ActivateBlockPanel(bool activate, bool visible)
	{
		if (Instance == null || Instance.BlockPanel == null || Instance.BlockPanel.gameObject == null)
		{
			return;
		}
		if (Instance.BlockPanel == null)
		{
			ActivateMainPanel(!activate);
			return;
		}
		Instance.BlockPanel.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)((!visible) ? 1u : 91u));
		if (!GameSettings.IsQuitting && !ErrorLogging.SceneChanging)
		{
			Instance.BlockPanel.gameObject.SetActive(activate);
		}
	}

	public void CloseAll(GUIWindow exempt = null)
	{
		List<GUIWindow> list = ActiveWindows.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			GUIWindow gUIWindow = list[i];
			if (gUIWindow.Shown && gUIWindow != exempt)
			{
				gUIWindow.Close();
			}
		}
	}

	public static List<GUIWindow> DisableAll(bool mainPanel, bool buildMode = false)
	{
		List<GUIWindow> list = new List<GUIWindow>();
		if (Instance == null)
		{
			return list;
		}
		for (int i = 0; i < Instance.ActiveWindows.Count; i++)
		{
			GUIWindow gUIWindow = Instance.ActiveWindows[i];
			if (gUIWindow.gameObject.activeSelf && (!buildMode || !gUIWindow.IgnoreBuildMode))
			{
				list.Add(gUIWindow);
				gUIWindow.gameObject.SetActive(false);
			}
		}
		for (int j = 0; j < Instance.ModalWindows.Count; j++)
		{
			GUIWindow gUIWindow2 = Instance.ModalWindows[j];
			if (gUIWindow2.gameObject.activeSelf && (!buildMode || !gUIWindow2.IgnoreBuildMode))
			{
				list.Add(gUIWindow2);
				gUIWindow2.gameObject.SetActive(false);
			}
		}
		if (mainPanel)
		{
			ActivateMainPanel(false);
		}
		return list;
	}

	public static void EnableAll(List<GUIWindow> windows)
	{
		if (Instance == null)
		{
			return;
		}
		if (windows == null)
		{
			if (Instance.ModalWindows.Count > 0)
			{
				Instance.ModalWindows[Instance.ModalWindows.Count - 1].gameObject.SetActive(true);
			}
			else
			{
				Instance.ActiveWindows.ForEach(delegate(GUIWindow x)
				{
					x.gameObject.SetActive(true);
				});
				ActivateMainPanel(true);
			}
		}
		else
		{
			for (int num = 0; num < windows.Count; num++)
			{
				GUIWindow gUIWindow = windows[num];
				if (gUIWindow != null)
				{
					gUIWindow.gameObject.SetActive(true);
				}
			}
		}
		ActivateMainPanel(true);
	}

	public static void DeregisterWindow(GUIWindow window)
	{
		if (Instance == null)
		{
			return;
		}
		window.ChangeActive(false);
		if (window.Modal)
		{
			Instance.ModalWindows.Remove(window);
			if (Instance.ModalWindows.Count > 0)
			{
				ActivateBlockPanel(true, !Instance.ModalWindows[Instance.ModalWindows.Count - 1].HideBlockPanel);
			}
			else
			{
				Instance._hasModal = false;
				ActivateBlockPanel(false, true);
			}
		}
		else
		{
			Instance.ActiveWindows.Remove(window);
		}
		Instance.MakeTopMostActive();
	}

	public int GetIndex(GUIWindow window)
	{
		if (window.Modal)
		{
			return ModalWindows.IndexOf(window);
		}
		return ActiveWindows.IndexOf(window);
	}

	private void MakeTopMostActive()
	{
		for (int num = ModalWindows.Count - 1; num >= 0; num--)
		{
			GUIWindow gUIWindow = ModalWindows[num];
			if (!gUIWindow.AlwaysOnTop)
			{
				ChangeLastActive(gUIWindow);
				return;
			}
		}
		for (int num2 = ActiveWindows.Count - 1; num2 >= 0; num2--)
		{
			GUIWindow gUIWindow2 = ActiveWindows[num2];
			if (!gUIWindow2.AlwaysOnTop)
			{
				ChangeLastActive(gUIWindow2);
				return;
			}
		}
		_lastActive = null;
	}

	private void ChangeLastActive(GUIWindow w)
	{
		if (w != _lastActive)
		{
			if (_lastActive != null)
			{
				_lastActive.ChangeActive(false);
				_lastActive.OnLostFocus.Invoke();
				_lastActive = null;
			}
			w.ChangeActive(true);
			_lastActive = w;
			w.OnGainedFocus.Invoke();
		}
	}

	public DialogWindow ShowMessageBox(string msg, bool pausing, DialogWindow.DialogType type, GUIWindow parent = null)
	{
		if (pausing && !GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.ForcePause = true;
			GameSettings.FreezeGame = true;
		}
		DialogWindow dialog = SpawnDialog();
		dialog.Show(msg, false, type, new KeyValuePair<string, Action>("OK", delegate
		{
			if (pausing)
			{
				GameSettings.ForcePause = false;
			}
			dialog.Window.Close();
		}));
		if (parent != null)
		{
			dialog.Window.SetParentWindow(parent);
		}
		return dialog;
	}

	public DialogWindow ShowMessageBox(string msg, bool pausing, DialogWindow.DialogType type, Action yesAction, string questionID = null, Action extraNoAction = null, bool defaultYes = true)
	{
		return ShowMessageBox(msg, pausing, new DialogWindow.DialogParams(type), yesAction, questionID, extraNoAction, defaultYes);
	}

	public DialogWindow ShowMessageBox(string msg, bool pausing, string icon, DialogWindow.DialogType color, DialogWindow.DialogType sound, Action yesAction, string questionID = null, Action extraNoAction = null, bool defaultYes = true)
	{
		return ShowMessageBox(msg, pausing, new DialogWindow.DialogParams(sound, color, icon), yesAction, questionID, extraNoAction, defaultYes);
	}

	public DialogWindow ShowMessageBox(string msg, bool pausing, DialogWindow.DialogParams p, Action yesAction, string questionID = null, Action extraNoAction = null, bool defaultYes = true)
	{
		if (questionID != null && Options.IgnoreQuestions.Contains(questionID))
		{
			if (defaultYes)
			{
				yesAction();
			}
			else if (extraNoAction != null)
			{
				extraNoAction();
			}
			return null;
		}
		if (pausing && !GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.ForcePause = true;
			GameSettings.FreezeGame = true;
		}
		DialogWindow dialog = SpawnDialog();
		if (questionID == null)
		{
			dialog.Show(msg, false, p, new KeyValuePair<string, Action>("Yes", delegate
			{
				if (pausing)
				{
					GameSettings.ForcePause = false;
				}
				yesAction();
				dialog.Window.Close();
			}), new KeyValuePair<string, Action>("No", delegate
			{
				if (pausing)
				{
					GameSettings.ForcePause = false;
				}
				if (extraNoAction != null)
				{
					extraNoAction();
				}
				dialog.Window.Close();
			}));
		}
		else
		{
			dialog.Show(msg, false, p, new KeyValuePair<string, Action>("Yes", delegate
			{
				if (pausing)
				{
					GameSettings.ForcePause = false;
				}
				yesAction();
				dialog.Window.Close();
			}), new KeyValuePair<string, Action>("DontAskAgain", delegate
			{
				if (pausing)
				{
					GameSettings.ForcePause = false;
				}
				if (defaultYes)
				{
					yesAction();
				}
				else if (extraNoAction != null)
				{
					extraNoAction();
				}
				Options.IgnoreQuestions.Add(questionID);
				Options.SaveToFile();
				dialog.Window.Close();
			}), new KeyValuePair<string, Action>("No", delegate
			{
				if (pausing)
				{
					GameSettings.ForcePause = false;
				}
				if (extraNoAction != null)
				{
					extraNoAction();
				}
				dialog.Window.Close();
			}));
		}
		return dialog;
	}

	public DialogWindow ShowMessageBox(string msg, bool pausing, DialogWindow.DialogType type, GUIWindow parent, params KeyValuePair<string, Action>[] actions)
	{
		if (pausing && !GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.ForcePause = true;
			GameSettings.FreezeGame = true;
		}
		DialogWindow dialog = SpawnDialog();
		KeyValuePair<string, Action>[] buttons = actions.SelectInPlace((KeyValuePair<string, Action> x) => new KeyValuePair<string, Action>(x.Key, delegate
		{
			if (pausing)
			{
				GameSettings.ForcePause = false;
			}
			x.Value();
			dialog.Window.Close();
		}));
		dialog.Show(msg, false, type, buttons);
		if (parent != null)
		{
			dialog.Window.SetParentWindow(parent);
		}
		return dialog;
	}

	public DialogWindow ShowMessageBox(string msg, bool pausing, DialogWindow.DialogType type, params KeyValuePair<string, Action>[] actions)
	{
		return ShowMessageBox(msg, pausing, type, null, actions);
	}

	public static void SpawnFader(RectTransform start, RectTransform end)
	{
		if (Instance != null)
		{
			RectToRectFade rectToRectFade = UnityEngine.Object.Instantiate(Instance.Fader);
			rectToRectFade.Begin = start;
			rectToRectFade.End = end;
			rectToRectFade.Self.SetParent(Instance.Canvas.transform, false);
			rectToRectFade.Self.SetSiblingIndex(Instance.StartIndex);
		}
	}

	public void AchievementAchieved(AchievementController.Achievement ac)
	{
		if (_activeSequence != null)
		{
			_activeSequence.Kill();
			_activeSequence = null;
		}
		UISoundFX.PlaySFX("Reward", -1f, 0.5f);
		ValueTuple<string, string> achievementLoc = AchievementController.GetAchievementLoc(ac);
		string item = achievementLoc.Item1;
		string item2 = achievementLoc.Item2;
		InitAchievementUI(AchievementPanel.gameObject, ac.Achieved, item, item2, true, 1);
		AchievementPanel.gameObject.SetActive(true);
		AchievementPanel.localScale = new Vector3(1f, 0f, 1f);
		_activeSequence = DOTween.Sequence();
		_activeSequence.Append(AchievementPanel.DOScaleY(1f, 1f).SetEase(Ease.OutElastic));
		_activeSequence.AppendInterval(5f);
		_activeSequence.Append(AchievementPanel.DOScaleY(0f, 0.5f).SetEase(Ease.OutCubic));
		_activeSequence.AppendCallback(delegate
		{
			_activeSequence = null;
			AchievementPanel.gameObject.SetActive(false);
		});
	}

	public static void InitAchievementUI(GameObject panel, Texture2D icon, string name, string desc, bool achieved, int imgSkip = 0)
	{
		panel.GetComponentInChildren<RawImage>().texture = icon;
		Text[] componentsInChildren = panel.GetComponentsInChildren<Text>();
		componentsInChildren[0].text = name;
		componentsInChildren[1].text = desc;
		Image[] componentsInChildren2 = panel.GetComponentsInChildren<Image>();
		componentsInChildren2[imgSkip].color = (achieved ? ((Color)new Color32(126, 207, 112, byte.MaxValue)) : Color.white);
		componentsInChildren2[1 + imgSkip].color = (achieved ? Color.white : Color.gray);
		componentsInChildren2[2 + imgSkip].color = (achieved ? ((Color)new Color32(126, 207, 112, byte.MaxValue)) : new Color(0.25f, 0.25f, 0.25f));
	}

	public void RemoveAchievement()
	{
		if (_activeSequence != null)
		{
			_activeSequence.Kill();
			_activeSequence = null;
		}
		AchievementPanel.gameObject.SetActive(false);
	}

	public static Dictionary<string, UnityEngine.Component> GenerateUI(List<XMLParser.XMLNode> nodes, GameObject parent, ModBehaviour callback)
	{
		Dictionary<string, UnityEngine.Component> dictionary = new Dictionary<string, UnityEngine.Component>();
		if (parent == null)
		{
			parent = Instance.Canvas;
		}
		foreach (XMLParser.XMLNode node in nodes)
		{
			CreateUI(node, parent, callback, dictionary);
		}
		return dictionary;
	}

	private static string[] SplitXMLValue(string v, bool lower = false)
	{
		string[] array = v.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Trim();
			if (lower)
			{
				array[i] = array[i].ToLower();
			}
		}
		return array;
	}

	private static Vector4 GetVectorFromXML(string v)
	{
		string[] array = SplitXMLValue(v);
		Vector4 zero = Vector4.zero;
		int num = Mathf.Min(array.Length, 4);
		for (int i = 0; i < num; i++)
		{
			zero[i] = array[i].ConvertToFloatDef(0f);
		}
		return zero;
	}

	private static string GetFunctionCall(string v, out string[] args)
	{
		int num = v.IndexOf('(');
		if (num == -1)
		{
			throw new Exception("Function call: " + v + " was not formatted correct, expected Function(Arguments)");
		}
		string result = v.Substring(0, num);
		string text = v.Substring(num + 1, v.Length - num - 2).Trim();
		args = ((text.Length > 0) ? SplitXMLValue(text) : Array.Empty<string>());
		return result;
	}

	private static ValueTuple<Rect, Rect> GetPositionFromNode(XMLParser.XMLNode node, out bool any)
	{
		any = false;
		Rect zero = Rect.zero;
		Rect item = Rect.zero;
		string value;
		if (node.Attributes.TryGetValue("position", out value))
		{
			zero.position = GetVectorFromXML(value);
			any = true;
		}
		if (node.Attributes.TryGetValue("size", out value))
		{
			zero.size = GetVectorFromXML(value);
			any = true;
		}
		if (node.Attributes.TryGetValue("width", out value))
		{
			zero.width = value.Trim().ConvertToFloatDef(0f);
			any = true;
		}
		if (node.Attributes.TryGetValue("height", out value))
		{
			zero.height = value.Trim().ConvertToFloatDef(0f);
			any = true;
		}
		if (node.Attributes.TryGetValue("anchor", out value))
		{
			any = true;
			string[] array = SplitXMLValue(value, true);
			if (array.Length == 4)
			{
				item = Rect.MinMaxRect(array[0].ConvertToFloatDef(0f), array[1].ConvertToFloatDef(0f), array[2].ConvertToFloatDef(0f), array[3].ConvertToFloatDef(0f));
			}
			else if (array.Length == 2)
			{
				float x = 0f;
				float y = 0f;
				string text = array[0];
				if (!(text == "middle"))
				{
					if (text == "bottom")
					{
						x = 1f;
					}
				}
				else
				{
					x = 0.5f;
				}
				text = array[0];
				if (!(text == "center"))
				{
					if (text == "right")
					{
						y = 1f;
					}
				}
				else
				{
					y = 0.5f;
				}
				item.position = new Vector2(x, y);
			}
			else if (array.Length == 1)
			{
				if (array[0].Equals("fill"))
				{
					item.size = Vector2.one;
				}
				else if (array[0].Equals("top"))
				{
					item = new Rect(0f, 0f, 1f, 0f);
				}
				else if (array[0].Equals("left"))
				{
					item = new Rect(0f, 0f, 0f, 1f);
				}
				else if (array[0].Equals("right"))
				{
					item = new Rect(1f, 0f, 0f, 1f);
				}
				else if (array[0].Equals("bottom"))
				{
					item = new Rect(0f, 1f, 1f, 0f);
				}
			}
		}
		return new ValueTuple<Rect, Rect>(zero, item);
	}

	private static object[] ConvertArgs(string[] args, MethodInfo m, UnityEngine.Component self)
	{
		object[] array = new object[args.Length];
		ParameterInfo[] parameters = m.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			if (args[i].Equals("this"))
			{
				array[i] = self;
			}
			else
			{
				array[i] = TryConvert(args[i], parameters[i].ParameterType);
			}
		}
		return array;
	}

	private static object TryConvert(string value, Type type)
	{
		Color color;
		if (type == typeof(Color))
		{
			return ColorUtility.TryParseHtmlString("#" + value.Replace("#", ""), out color) ? color : Color.white;
		}
		if (type == typeof(RectOffset))
		{
			Vector4 vectorFromXML = GetVectorFromXML(value);
			return new RectOffset((int)vectorFromXML.x, (int)vectorFromXML.y, (int)vectorFromXML.z, (int)vectorFromXML.w);
		}
		if (type == typeof(Vector2))
		{
			return (Vector2)GetVectorFromXML(value);
		}
		if (type == typeof(Vector3))
		{
			return (Vector3)GetVectorFromXML(value);
		}
		if (type == typeof(Vector4))
		{
			return GetVectorFromXML(value);
		}
		if (type == typeof(Rect))
		{
			Vector4 vectorFromXML2 = GetVectorFromXML(value);
			return new Rect((int)vectorFromXML2.x, (int)vectorFromXML2.y, (int)vectorFromXML2.z, (int)vectorFromXML2.w);
		}
		return TypeDescriptor.GetConverter(type).ConvertFrom(value);
	}

	private static bool IsEvent(Type t)
	{
		Type typeFromHandle = typeof(UnityEvent);
		if (!(t == typeFromHandle))
		{
			return t.IsSubclassOf(typeFromHandle);
		}
		return true;
	}

	private static void CreateUI(XMLParser.XMLNode node, GameObject parent, ModBehaviour callback, Dictionary<string, UnityEngine.Component> components)
	{
		Func<string, ValueTuple<UnityEngine.Component, GameObject>> value;
		UnityEngine.Component component;
		GameObject parent2;
		if (_objectTags.TryGetValue(node.Name.ToLower(), out value))
		{
			ValueTuple<UnityEngine.Component, GameObject> valueTuple = value(node.Value);
			bool any;
			ValueTuple<Rect, Rect> positionFromNode = GetPositionFromNode(node, out any);
			if (!(valueTuple.Item1 is GUIWindow))
			{
				AddElementToElement(valueTuple.Item1.gameObject, parent.gameObject, positionFromNode.Item1, positionFromNode.Item2);
			}
			component = valueTuple.Item1;
			parent2 = valueTuple.Item2;
		}
		else
		{
			Func<GameObject, UnityEngine.Component> value2;
			if (!_layoutTags.TryGetValue(node.Name.ToLower(), out value2))
			{
				throw new Exception("Found unknown tag: " + node.Name + " while trying to create UI from XML");
			}
			parent2 = parent;
			component = value2(parent);
			bool any2;
			ValueTuple<Rect, Rect> positionFromNode2 = GetPositionFromNode(node, out any2);
			if (any2)
			{
				SetElementDimension(parent.GetComponent<RectTransform>(), positionFromNode2.Item1, positionFromNode2.Item2);
			}
		}
		string value3;
		if (node.Attributes.TryGetValue("id", out value3))
		{
			components[value3] = component;
		}
		foreach (KeyValuePair<string, string> attribute in node.Attributes)
		{
			if (_ignoreAttributes.Contains(attribute.Key))
			{
				continue;
			}
			Type type = component.GetType();
			FieldInfo field = type.GetField(attribute.Key, BindingFlags.Instance | BindingFlags.Public);
			if (field != null)
			{
				if (IsEvent(field.FieldType))
				{
					SetFunctionCallback((UnityEvent)field.GetValue(component), callback, attribute.Value, component);
				}
				else
				{
					field.SetValue(component, TryConvert(attribute.Value, field.FieldType));
				}
				continue;
			}
			PropertyInfo property = type.GetProperty(attribute.Key, BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				if (IsEvent(property.PropertyType))
				{
					SetFunctionCallback((UnityEvent)property.GetValue(component), callback, attribute.Value, component);
				}
				else
				{
					property.SetValue(component, TryConvert(attribute.Value, property.PropertyType));
				}
			}
		}
		foreach (XMLParser.XMLNode child in node.Children)
		{
			CreateUI(child, parent2, callback, components);
		}
	}

	private static void SetFunctionCallback(UnityEvent ev, ModBehaviour callback, string functionString, UnityEngine.Component self)
	{
		string[] args;
		string fCall = GetFunctionCall(functionString, out args);
		Type type = callback.GetType();
		MethodInfo m = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo x) => x.Name.Equals(fCall) && x.GetParameters().Length == args.Length);
		if (m == null)
		{
			throw new Exception("Could not find function call: " + functionString + " for " + type.Name);
		}
		object[] fArgs = ((args.Length == 0) ? null : ConvertArgs(args, m, self));
		ev.AddListener(delegate
		{
			m.Invoke(callback, fArgs);
		});
	}
}
