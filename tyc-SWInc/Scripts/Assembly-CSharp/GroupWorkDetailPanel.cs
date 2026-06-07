using System;
using UnityEngine;
using UnityEngine.UI;

public class GroupWorkDetailPanel : MonoBehaviour
{
	public static GroupWorkDetailPanel Instance;

	public RectTransform Self;

	public RectTransform WorkPanel;

	public RectTransform SubPanel;

	public Image TitleBar;

	public Image TypeIcon;

	public Text Title;

	public Text Description;

	public Text State;

	public Text Progress;

	public Text Team;

	public GameObject DealIcon;

	public float HideSpeed = 2f;

	public bool Hide = true;

	[NonSerialized]
	private SubWorkItem _item;

	[NonSerialized]
	private bool _selfCheck;

	public void Show(SubWorkItem item)
	{
		_item = item;
		base.gameObject.SetActive(true);
		Hide = false;
		DealIcon.SetActive(_item.Work.ActiveDeal != null);
		TypeIcon.sprite = ObjectDatabase.GetIcon(_item.Work.GetIcon());
		Title.text = _item.Work.Name;
		TitleBar.color = _item.Work.BackColor;
		_selfCheck = false;
	}

	public void HideNow()
	{
		Hide = true;
	}

	private void Start()
	{
		Instance = this;
	}

	public bool CheckSelf()
	{
		if (base.gameObject.activeSelf && RectTransformUtility.RectangleContainsScreenPoint(Self, Input.mousePosition, UICamSize.GetUICam()))
		{
			_selfCheck = true;
			return true;
		}
		return false;
	}

	private void Update()
	{
		if (Hide)
		{
			Self.localScale = new Vector3(Mathf.Lerp(Self.localScale.x, 0f, Time.deltaTime * HideSpeed), 1f, 1f);
			if (Self.localScale.x < 0.01f)
			{
				Self.localScale = new Vector3(0f, 1f, 1f);
				base.gameObject.SetActive(false);
			}
			return;
		}
		if (_item == null || _item.gameObject == null || !_item.gameObject.activeSelf || _item.Work == null)
		{
			Hide = true;
			return;
		}
		if (_selfCheck && !RectTransformUtility.RectangleContainsScreenPoint(Self, Input.mousePosition, UICamSize.GetUICam()))
		{
			Hide = true;
			return;
		}
		RectTransform component = _item.GetComponent<RectTransform>();
		RectTransform component2 = component.parent.parent.GetComponent<RectTransform>();
		Self.anchoredPosition = new Vector2(0f - WorkPanel.rect.width - 1f, Mathf.Clamp(component2.anchoredPosition.y + component.anchoredPosition.y - 96f + SubPanel.anchoredPosition.y, 0f - WorkPanel.rect.height - WorkPanel.anchoredPosition.y + 74f, -96f));
		if (Self.localScale.x < 1f)
		{
			Self.localScale = new Vector3(Mathf.Lerp(Self.localScale.x, 1f, Time.deltaTime * HideSpeed), 1f, 1f);
			if (Self.localScale.x > 0.99f)
			{
				Self.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		WorkItem work = _item.Work;
		string team = work.GetTeam(Team);
		State.text = work.GetCurrentStage();
		Team.text = team ?? "Unassigned".Loc();
		Description.text = work.GetCategory();
		Progress.text = work.GetActualProgressLabel();
		if (work.GUIWorkItemType() == 0)
		{
			Progress.text = "\n" + Progress.text;
		}
	}
}
