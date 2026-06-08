using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Icon : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
	[SerializeField]
	public const float CLICK_SECONDS = 0.5f;

	[SerializeField]
	protected GameObject windowPanel;

	[SerializeField]
	protected PanelManager tableManager;

	[SerializeField]
	protected Sprite icon1;

	[SerializeField]
	protected Sprite icon2;

	[SerializeField]
	protected Sprite taskbarIcon;

	[SerializeField]
	protected Vector2Int position = new Vector2Int(-1, -1);

	[SerializeField]
	public bool hasNotifications;

	protected GameObject iconBackground;

	public static readonly string[] SKIP_ENDING_ICONS = new string[2] { "Clue Explorer Icon", "Arrest Icon" };

	protected Canvas canvas;

	protected float lastClick = -1f;

	protected bool hasName;

	protected string tableName;

	protected ClosePanelAudio audioPlayer;

	protected IconClick sfxPlayer;

	protected Animator animator;

	protected GameObject notificationIcon;

	protected IconNotificationManager iconNotificationManager;

	protected string iconName;

	public static DateTime timeClicked;

	private bool isSelected;

	protected ClickDrag clickDrag;

	protected TaskbarManager taskbarManager;

	protected Transform baseIcon;

	protected virtual void Awake()
	{
		clickDrag = GetComponentInParent<ClickDrag>();
		if (IsGameOverSkipIcon(base.transform.parent))
		{
			RemoveIcon();
			return;
		}
		audioPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		tableManager = canvas.GetComponent<PanelManager>();
		baseIcon = base.transform.parent;
		animator = baseIcon.GetComponent<Animator>();
		Transform parent = baseIcon.parent;
		iconNotificationManager = parent.GetComponent<IconNotificationManager>();
		iconBackground = baseIcon.Find("Selected Name").gameObject;
		taskbarManager = parent.GetComponent<TaskbarManager>();
		if (hasNotifications)
		{
			notificationIcon = base.transform.GetChild(0).gameObject;
		}
		iconName = baseIcon.gameObject.name;
		if (LevelManager.IsCredits() || Save.IsIconClicked(GetIconName()))
		{
			StopAnimation(save: false);
		}
	}

	public static string GetName(Icon icon)
	{
		return icon.transform.parent.Find("Table Name").GetComponent<TextMeshProUGUI>().text;
	}

	public static bool IsGameOverSkipIcon(Transform iconTransform)
	{
		if (LevelManager.IsCredits())
		{
			return SKIP_ENDING_ICONS.Contains(iconTransform.name);
		}
		return false;
	}

	private void RemoveIcon()
	{
		Transform parent = base.transform.parent;
		ThomasGridLayoutGroup.RemoveIconPos(parent.localPosition);
		ThomasGridLayoutGroup.ShiftIconsUp(parent.localPosition, parent.parent);
		UnityEngine.Object.Destroy(parent.gameObject);
	}

	public virtual void SetName(string name)
	{
		hasName = true;
		tableName = name;
	}

	public void SetSprites(Sprite icon1, Sprite icon2)
	{
		this.icon1 = icon1;
		this.icon2 = icon2;
	}

	public void OnPointerEnter(PointerEventData data)
	{
		GetComponent<Image>().sprite = icon2;
	}

	public void OnPointerExit(PointerEventData data)
	{
		GetComponent<Image>().sprite = icon1;
	}

	public void SetTaskbarIcon(Sprite taskbarIcon)
	{
		this.taskbarIcon = taskbarIcon;
	}

	public virtual void StopAnimation(bool save = true)
	{
		if (hasNotifications)
		{
			if (save)
			{
				Save.SaveIconClick(GetIconName());
			}
			notificationIcon.GetComponent<Image>().enabled = false;
			animator.Play("Default");
		}
	}

	public virtual void PlayAnimation()
	{
		if (hasNotifications && !Save.IsIconClicked(GetIconName()))
		{
			Debug.Log("Calling PlayAnimation for " + iconName);
			if (notificationIcon != null)
			{
				notificationIcon.GetComponent<Image>().enabled = true;
				animator.Play("Icon Wiggle");
			}
		}
	}

	public bool IsTable()
	{
		return hasName;
	}

	public bool HasPosition()
	{
		if (GetRow() != -1)
		{
			return GetColumn() != -1;
		}
		return false;
	}

	public int GetRow()
	{
		return position.x;
	}

	public int GetColumn()
	{
		return position.y;
	}

	public string GetIconName()
	{
		if (!hasName)
		{
			return iconName;
		}
		return tableName;
	}

	public void SetPosition(Vector2Int pos, bool save = true)
	{
		position = pos;
		Debug.Log($"Saving position {pos}");
		if (save)
		{
			Save.SaveIconPosition(GetIconName(), pos);
		}
	}

	public virtual void OnPointerClick(PointerEventData data)
	{
		if (data.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		if (sfxPlayer == null)
		{
			sfxPlayer = SoundEffectUtils.GetIconClickPlayer();
		}
		float num = data.clickTime - lastClick;
		if (lastClick > 0f && num < 0.5f)
		{
			if (taskbarManager.IsMaximumTaskbarButtons((hasName && tableManager.Contains(tableName)) ? tableManager.GetPanel(tableName) : windowPanel))
			{
				return;
			}
			audioPlayer.PlayOpen();
			StopAnimation();
			timeClicked = DateTime.Now;
			string title = GetName(this);
			Sprite sprite = GetTaskbarIcon();
			if (hasName)
			{
				if (tableManager.OpenPanel(tableName))
				{
					GameObject panel = tableManager.GetPanel(tableName);
					taskbarManager.AddTaskbar(panel, sprite, title);
				}
			}
			else
			{
				SetHint();
				PanelManager.OpenWindow(windowPanel);
				taskbarManager.AddTaskbar(windowPanel, sprite, UIUtils.ToTitleCase(title));
			}
			sfxPlayer.PlayDoubleClick(1f);
			if (iconBackground != null)
			{
				UnselectIcons();
			}
		}
		else
		{
			sfxPlayer.PlayDoubleClick(0.8f);
		}
		lastClick = data.clickTime;
	}

	public Sprite GetTaskbarIcon()
	{
		if (!taskbarIcon)
		{
			return icon1;
		}
		return taskbarIcon;
	}

	public void SelectIcon()
	{
		iconBackground.SetActive(value: true);
		float size = Math.Min(base.transform.parent.Find("Table Name").GetComponent<TextMeshProUGUI>().preferredWidth + 10f, 110f);
		iconBackground.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
		isSelected = true;
		GetComponent<PlayerInput>().actions["Click"].performed += CheckUnselect;
		GetComponentInParent<ClickDrag>().AddSelectedIcon(this);
	}

	private void OnDestroy()
	{
		UnselectIcon();
	}

	public bool IsSelected()
	{
		return isSelected;
	}

	public void CheckUnselect(InputAction.CallbackContext context)
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		MonoBehaviour.print("CheckUnselect " + GetIconName());
		float width = GetComponent<RectTransform>().rect.width;
		float height = GetComponent<RectTransform>().rect.height;
		bool flag = false;
		foreach (Icon selectedIcon in clickDrag.GetSelectedIcons())
		{
			Vector3 vector2 = Camera.main.WorldToScreenPoint(selectedIcon.transform.position) + new Vector3((0f - width) / 2f, height / 2f) * canvas.scaleFactor;
			Vector3 vector3 = vector2 + new Vector3(width, 0f - height) * canvas.scaleFactor;
			flag = flag || (vector.x >= vector2.x && vector.x <= vector3.x && vector.y <= vector2.y && vector.y >= vector3.y);
		}
		Debug.Log($"clickedDropdown for {GetIconName()}? {flag}");
		if (!flag)
		{
			UnselectIcon();
		}
	}

	public void UnselectIcons()
	{
		foreach (Icon item in (IEnumerable<Icon>)new List<Icon>(clickDrag.GetSelectedIcons()))
		{
			item.UnselectIcon();
		}
	}

	public void UnselectIcon()
	{
		GetComponent<PlayerInput>().actions["Click"].performed -= CheckUnselect;
		clickDrag.RemoveSelectedIcon(this);
		if (iconBackground != null)
		{
			iconBackground.SetActive(value: false);
		}
		isSelected = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		SelectIcon();
	}

	public void SetHint()
	{
		if (windowPanel.name == "Clue Explorer" && HintManager.GetHintState() < 1)
		{
			HintManager.SetHintState(1);
		}
		if (LevelManager.GetCurrLevel() == 4)
		{
			if (windowPanel.name == "Instruction Manual")
			{
				if (HintManager.GetQueryState() == 0)
				{
					HintManager.SetQueryState(2);
				}
				else if (HintManager.GetQueryState() == 1)
				{
					HintManager.SetQueryState(3);
				}
			}
		}
		else if (LevelManager.GetCurrLevel() >= 1 && LevelManager.GetCurrLevel() <= 6 && windowPanel.name == "Instruction Manual")
		{
			if (HintManager.GetQueryState() == 0)
			{
				HintManager.SetQueryState(2);
			}
			else if (HintManager.GetQueryState() == 1)
			{
				HintManager.SetQueryState(3);
			}
		}
	}
}
