using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MultiSelectWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GameObject Panel;

	public GameObject ButtonPrefab;

	public GameObject TogglePrefab;

	public GameObject ToggleButton;

	public Text TitlePrefab;

	public RectTransform ScrollPanel;

	public RectTransform ContentPanel;

	public Scrollbar Scrollbar;

	public ScrollRect ScrollR;

	public InputField SearchBar;

	public Toggle AllToggle;

	private List<GameObject> buttons = new List<GameObject>();

	private List<GameObject> toggles = new List<GameObject>();

	private List<GameObject> labels = new List<GameObject>();

	private Stack<GameObject> buttonPool = new Stack<GameObject>();

	private Stack<GameObject> togglePool = new Stack<GameObject>();

	private List<string> _options = new List<string>();

	private List<int> _indices = new List<int>();

	private List<int> _previouslySelected = new List<int>();

	private int _bCount;

	private bool _toggleMode;

	private bool _inverseToggle;

	private Action<int[]> _toggleFinal;

	private int _maxSelect;

	public void UpdateScrollVisibility()
	{
		bool flag = ScrollPanel.rect.height < (float)(_bCount * 28 + 4 + (SearchBar.gameObject.activeSelf ? 28 : 0));
		ScrollR.verticalScrollbar = (flag ? Scrollbar : null);
		Scrollbar.gameObject.SetActive(flag);
		ContentPanel.offsetMax = new Vector2(flag ? (-18) : 0, ContentPanel.offsetMax.y);
		if (!flag)
		{
			ScrollR.verticalNormalizedPosition = 1f;
		}
	}

	private void DestroyButton(GameObject button)
	{
		button.transform.SetParent(null, false);
		button.SetActive(false);
		Button[] componentsInChildren = button.GetComponentsInChildren<Button>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].onClick.RemoveAllListeners();
		}
		buttonPool.Push(button);
	}

	private void DestroyToggle(GameObject toggle)
	{
		toggle.transform.SetParent(null, false);
		toggle.SetActive(false);
		toggle.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
		togglePool.Push(toggle);
	}

	public void ShowMulti(string title, IEnumerable<string> values, bool[] selected, Action<int[]> func, bool modal = true, bool Localize = false, bool inverse = false, bool titles = false, string warning = null, Color[] colors = null, int maxSelect = 0)
	{
		_previouslySelected.Clear();
		_maxSelect = maxSelect;
		_toggleFinal = func;
		_toggleMode = true;
		_inverseToggle = inverse;
		ToggleButton.SetActive(true);
		ScrollPanel.offsetMin = new Vector2(ScrollPanel.offsetMin.x, 28f);
		ScrollR.verticalNormalizedPosition = 1f;
		if (Window.OnClose != null)
		{
			Window.OnClose();
			Window.OnClose = null;
		}
		List<string> list = values.ToList();
		if (list.Count == 0)
		{
			return;
		}
		_options.Clear();
		buttons.ForEach(delegate(GameObject x)
		{
			DestroyButton(x);
		});
		buttons.Clear();
		labels.ForEach(delegate(GameObject x)
		{
			UnityEngine.Object.Destroy(x);
		});
		labels.Clear();
		toggles.ForEach(delegate(GameObject x)
		{
			DestroyToggle(x);
		});
		toggles.Clear();
		_indices.Clear();
		bool flag = list.Count > 10;
		SearchBar.gameObject.SetActive(flag);
		Window.Title = title;
		Window.Modal = modal;
		float a = Window.MinSize.x - 32f;
		float w = 0f;
		a = Mathf.Max(a, w);
		AllToggle = CreateToggle("All".Loc(), Color.white, out w).GetComponent<Toggle>();
		AllToggle.GetComponent<SelectWarning>().DisableWarning();
		bool flag2 = false;
		_bCount = 1;
		int num = 0;
		foreach (string item in list)
		{
			_bCount++;
			float w2 = 0f;
			if (titles && item.StartsWith("*"))
			{
				Text text = UnityEngine.Object.Instantiate(TitlePrefab);
				text.text = (Localize ? item.Substring(1).Loc() : item.Substring(1));
				text.transform.SetParent(ContentPanel, false);
				labels.Add(text.gameObject);
				w2 = text.GetLineWidth(text.text);
			}
			else
			{
				string text2 = (Localize ? item.Loc() : item);
				Color color = ((colors != null) ? colors[num % colors.Length] : Color.white);
				bool flag3 = false;
				if (warning != null && text2.EndsWith("^"))
				{
					flag3 = true;
					text2 = text2.Substring(0, text2.Length - 1);
				}
				_options.Add(text2.ToLower());
				Toggle component = CreateToggle(text2, color, out w2).GetComponent<Toggle>();
				if (flag3)
				{
					component.GetComponent<SelectWarning>().SetWarning(warning);
				}
				else
				{
					component.GetComponent<SelectWarning>().DisableWarning();
				}
				flag2 |= selected == null || !selected[num];
				component.isOn = selected != null && selected[num];
				int tIdx = toggles.IndexOf(component.gameObject);
				if (component.isOn)
				{
					_previouslySelected.Add(tIdx);
				}
				component.onValueChanged.AddListener(delegate(bool x)
				{
					if (tIdx >= 0 && tIdx < toggles.Count)
					{
						if (x)
						{
							if (_maxSelect > 0)
							{
								_previouslySelected.Add(tIdx);
								if (_previouslySelected.Count > _maxSelect)
								{
									toggles[_previouslySelected[0]].GetComponent<Toggle>().isOn = false;
								}
							}
						}
						else
						{
							_previouslySelected.Remove(tIdx);
						}
					}
				});
				_indices.Add(num);
			}
			a = Mathf.Max(a, w2);
			num++;
		}
		if (_maxSelect < 1)
		{
			AllToggle.isOn = !flag2;
			AllToggle.onValueChanged.AddListener(delegate(bool b)
			{
				foreach (GameObject toggle in toggles)
				{
					if (toggle != AllToggle.gameObject && toggle.activeSelf)
					{
						toggle.GetComponent<Toggle>().isOn = b;
					}
				}
			});
		}
		else
		{
			AllToggle.gameObject.SetActive(false);
			_bCount--;
		}
		Window.rectTransform.sizeDelta = new Vector2(a + 32f, Mathf.Max(Window.MinSize.y, Mathf.Min(16, _bCount) * 28 + (flag ? 92 : 64)));
		Window.Show();
		UpdateScrollVisibility();
		if (flag)
		{
			SearchBar.text = "";
			SearchBar.Select();
		}
	}

	public void ToggleOK()
	{
		if (_toggleFinal != null)
		{
			List<int> list = new List<int>();
			for (int i = 1; i < toggles.Count; i++)
			{
				if (_inverseToggle ^ toggles[i].GetComponent<Toggle>().isOn)
				{
					list.Add(_indices[i - 1]);
				}
			}
			_toggleFinal(list.ToArray());
		}
		Window.Close();
	}

	public void Show(string title, IEnumerable<string> values, Action<int> func, bool nullOption, bool closeOnChoice = true, bool modal = true, bool Localize = false, Action<int> deleteElement = null, string warning = null, Action onClose = null, bool closeActionOnChoice = true)
	{
		_previouslySelected.Clear();
		_maxSelect = 0;
		_toggleMode = false;
		ToggleButton.SetActive(false);
		ScrollPanel.offsetMin = new Vector2(ScrollPanel.offsetMin.x, 20f);
		ScrollR.verticalNormalizedPosition = 1f;
		if (Window.OnClose != null)
		{
			Window.OnClose();
			Window.OnClose = null;
		}
		List<string> list = values.ToList();
		if (list.Count == 0 && !nullOption)
		{
			return;
		}
		_options.Clear();
		buttons.ForEach(DestroyButton);
		buttons.Clear();
		labels.ForEach(delegate(GameObject x)
		{
			UnityEngine.Object.Destroy(x);
		});
		labels.Clear();
		toggles.ForEach(DestroyToggle);
		toggles.Clear();
		_indices.Clear();
		bool flag = list.Count > 10;
		SearchBar.gameObject.SetActive(flag);
		Window.Title = title;
		Window.Modal = modal;
		float num = Window.MinSize.x - 32f;
		_bCount = 0;
		if (nullOption)
		{
			_bCount++;
			float w = 0f;
			string text = "None".Loc();
			_options.Add(text.ToLower());
			GameObject obj = CreateButton(text, out w);
			Button[] componentsInChildren = obj.GetComponentsInChildren<Button>(true);
			obj.GetComponent<SelectWarning>().DisableWarning();
			num = Mathf.Max(num, w);
			componentsInChildren[0].onClick.AddListener(delegate
			{
				func(-1);
				if (closeOnChoice)
				{
					if (!closeActionOnChoice)
					{
						Window.OnClose = null;
					}
					Window.Close();
				}
			});
		}
		int num2 = 0;
		foreach (string item in list)
		{
			_bCount++;
			float w2 = 0f;
			string text2 = (Localize ? item.Loc() : item);
			bool flag2 = false;
			if (warning != null && text2.EndsWith("^"))
			{
				flag2 = true;
				text2 = text2.Substring(0, text2.Length - 1);
			}
			_options.Add(text2.ToLower());
			GameObject b = CreateButton(text2, out w2);
			if (flag2)
			{
				b.GetComponent<SelectWarning>().SetWarning(warning);
			}
			else
			{
				b.GetComponent<SelectWarning>().DisableWarning();
			}
			Button[] componentsInChildren2 = b.GetComponentsInChildren<Button>(true);
			num = Mathf.Max(num, w2);
			int j = num2;
			componentsInChildren2[0].onClick.AddListener(delegate
			{
				if (closeOnChoice)
				{
					if (!closeActionOnChoice)
					{
						Window.OnClose = null;
					}
					Window.Close();
				}
				func(j);
			});
			if (deleteElement != null)
			{
				componentsInChildren2[1].gameObject.SetActive(true);
				componentsInChildren2[1].onClick.AddListener(delegate
				{
					deleteElement(j);
					DestroyButton(b);
					buttons.Remove(b);
				});
			}
			_indices.Add(num2);
			num2++;
		}
		Window.rectTransform.sizeDelta = new Vector2(num + 32f, Mathf.Max(Window.MinSize.y, Mathf.Min(16, _bCount) * 28 + (flag ? 80 : 52)));
		Window.Show();
		UpdateScrollVisibility();
		if (flag)
		{
			SearchBar.text = "";
			SearchBar.Select();
		}
		if (onClose != null)
		{
			Window.OnClose = delegate
			{
				onClose();
				Window.OnClose = null;
			};
		}
	}

	public void Show(string title, IEnumerable<string> values, Action<int> func, bool nullOption, bool closeOnChoice, bool modal, Action OnClose, bool Localize = false)
	{
		Show(title, values, func, nullOption, closeOnChoice, modal, Localize);
		Window.OnClose = delegate
		{
			OnClose();
			Window.OnClose = null;
		};
	}

	public void SearchSubmit()
	{
		if (_toggleMode || (!Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.KeypadEnter)))
		{
			return;
		}
		bool flag = string.IsNullOrWhiteSpace(SearchBar.text);
		string[] source = (flag ? null : SearchBar.text.ToLower().Split(' '));
		for (int i = 0; i < buttons.Count; i++)
		{
			string text = _options[i];
			if (flag || source.All(text.Contains))
			{
				buttons[i].GetComponentsInChildren<Button>()[0].onClick.Invoke();
				InputController.InputEnabled = true;
				break;
			}
		}
		SearchBar.ActivateInputField();
	}

	public void SearchChanged()
	{
		_bCount = (_toggleMode ? 1 : 0);
		List<GameObject> list = (_toggleMode ? toggles : buttons);
		bool flag = string.IsNullOrWhiteSpace(SearchBar.text);
		string[] source = (flag ? null : SearchBar.text.ToLower().Split(' '));
		for (int i = (_toggleMode ? 1 : 0); i < list.Count; i++)
		{
			string text = _options[_toggleMode ? (i - 1) : i];
			bool flag2 = flag || source.All(text.Contains);
			list[i].SetActive(flag2);
			if (flag2)
			{
				_bCount++;
			}
		}
		UpdateScrollVisibility();
	}

	private GameObject CreateButton(string label, out float w)
	{
		GameObject gameObject = ((buttonPool.Count > 0) ? buttonPool.Pop() : UnityEngine.Object.Instantiate(ButtonPrefab));
		buttons.Add(gameObject);
		gameObject.GetComponentsInChildren<Button>(true)[1].gameObject.SetActive(false);
		Text componentInChildren = gameObject.GetComponentInChildren<Text>();
		componentInChildren.text = label;
		w = componentInChildren.preferredWidth;
		gameObject.transform.SetParent(Panel.transform, false);
		gameObject.SetActive(true);
		return gameObject;
	}

	private GameObject CreateToggle(string label, Color color, out float w)
	{
		GameObject gameObject = ((togglePool.Count > 0) ? togglePool.Pop() : UnityEngine.Object.Instantiate(TogglePrefab));
		toggles.Add(gameObject);
		Text componentInChildren = gameObject.GetComponentInChildren<Text>();
		componentInChildren.text = label;
		w = componentInChildren.preferredWidth + 23f;
		gameObject.transform.SetParent(Panel.transform, false);
		gameObject.SetActive(true);
		gameObject.GetComponent<SelectWarning>().ToggleBack.color = color;
		return gameObject;
	}
}
