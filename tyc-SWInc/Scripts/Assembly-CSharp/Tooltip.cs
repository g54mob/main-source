using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	public Text Title;

	public Text Description;

	public GameObject TitlePanel;

	public GameObject TitleAdd;

	public GameObject OnlyTitle;

	public GameObject DescAdd;

	public GameObject OnlyDesc;

	public RectTransform Self;

	private RectTransform Rect;

	private RectTransform TRect;

	private static Tooltip Instance;

	public bool ForcePosition;

	public static bool IsShowing
	{
		get
		{
			if (Instance != null)
			{
				return Instance.gameObject.activeSelf;
			}
			return false;
		}
	}

	public static RectTransform CurrentRect
	{
		get
		{
			if (!(Instance == null))
			{
				return Instance.Rect;
			}
			return null;
		}
		set
		{
			if (Instance != null)
			{
				Instance.Rect = value;
			}
		}
	}

	public static void SetToolTip(string title, string description, RectTransform rect)
	{
		bool flag = string.IsNullOrEmpty(title);
		bool flag2 = string.IsNullOrEmpty(description);
		if (Instance != null)
		{
			if (!flag || !flag2)
			{
				Instance.ForcePosition = false;
				Instance.TitlePanel.SetActive(!flag);
				Instance.Title.text = title ?? "";
				Instance.Description.gameObject.SetActive(!flag2);
				Instance.Description.text = description ?? "";
				Instance.Rect = rect;
				Instance.gameObject.SetActive(true);
				Instance.transform.SetAsLastSibling();
				Instance.UpdatePosition();
				Instance.UpdatePanels();
			}
			else if (!Instance.gameObject.activeSelf)
			{
				Instance.Rect = rect;
			}
		}
	}

	public static void UpdateToolTip(string title, string description, Vector2 pos)
	{
		bool flag = string.IsNullOrEmpty(title);
		bool flag2 = string.IsNullOrEmpty(description);
		if (Instance != null && (!flag || !flag2))
		{
			Instance.ForcePosition = true;
			Instance.TRect.anchoredPosition = new Vector2(pos.x, pos.y);
			Instance.TitlePanel.SetActive(!flag);
			Instance.Title.text = title ?? "";
			Instance.Description.gameObject.SetActive(!flag2);
			Instance.Description.text = description ?? "";
			Instance.UpdatePanels();
		}
	}

	public static void UpdateToolTip(string title, string description)
	{
		bool flag = string.IsNullOrEmpty(title);
		bool flag2 = string.IsNullOrEmpty(description);
		if (Instance != null && (!flag || !flag2))
		{
			Instance.TitlePanel.SetActive(!flag);
			Instance.Title.text = title ?? "";
			Instance.Description.gameObject.SetActive(!flag2);
			Instance.Description.text = description ?? "";
			Instance.UpdatePanels();
		}
	}

	private void UpdatePanels()
	{
		bool flag = !string.IsNullOrEmpty(Title.text);
		bool flag2 = !string.IsNullOrEmpty(Description.text);
		TitleAdd.SetActive(flag && flag2);
		DescAdd.SetActive(flag && flag2);
		OnlyTitle.SetActive(flag && !flag2);
		OnlyDesc.SetActive(!flag && flag2);
		LayoutRebuilder.ForceRebuildLayoutImmediate(Self);
	}

	private void UpdatePosition()
	{
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		y -= (float)Screen.height;
		x = Mathf.Clamp(x / Options.UISize + 16f, 0f, (float)Screen.width / Options.UISize - TRect.rect.width);
		y = Mathf.Clamp(y / Options.UISize - 16f, (float)(-Screen.height) / Options.UISize + TRect.rect.height, 0f);
		TRect.anchoredPosition = new Vector2(x, y);
	}

	private void Update()
	{
		if (!ForcePosition)
		{
			UpdatePosition();
		}
		if (Rect == null || !Rect.gameObject.activeInHierarchy || !RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition, UICamSize.GetUICam()))
		{
			Rect = null;
			base.gameObject.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Start()
	{
		Instance = this;
		TRect = GetComponent<RectTransform>();
		base.gameObject.SetActive(false);
	}

	public static void Hide()
	{
		if (Instance != null)
		{
			Instance.gameObject.SetActive(false);
		}
	}
}
