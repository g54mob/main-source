using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubWorkItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public class FakeTaskNotification : NotificationMessage
	{
		public WorkItem Item;

		public List<string> Actions;

		public FakeTaskNotification(WorkItem item)
		{
			Item = item;
			Actions = (from x in item.GetButtons()
				select x.Key into x
				where !_promoteActions.Contains(x) && !_cancelActions.Contains(x)
				select x).ToList();
			if (GUIWorkItem.HasDetails(Item))
			{
				Actions.Insert(0, "Details");
			}
		}

		public override int GetCount()
		{
			return Actions.Count;
		}

		public override IEnumerable GetItems()
		{
			foreach (string action in Actions)
			{
				yield return action.Loc();
			}
		}

		public override void Goto(int idx = -1)
		{
			if (GUIWorkItem.HasDetails(Item) && Actions[idx].Equals("Details"))
			{
				HUD.Instance.workerDetailWindow.Show(Item as SoftwareWorkItem);
				return;
			}
			Action action = Item.GetButtons().FirstOrDefaultOf((KeyValuePair<string, Action> x) => x.Key.Equals(Actions[idx]), (KeyValuePair<string, Action> x) => x.Value);
			if (action != null)
			{
				action();
			}
		}
	}

	public Text MainLabel;

	public Text Priority;

	public RectTransform Self;

	public RectTransform ProgressBar;

	public RectTransform ProgressPanel;

	public RectTransform Indicator;

	public Image PlayThumb;

	public Image ProgressImage;

	public Image BackProgImage;

	public Image PlayBack;

	public Button FinishButton;

	public Button DropButton;

	public Button CancelButton;

	public Sprite PlaySprite;

	public Sprite PauseSprite;

	public GameObject PauseImage;

	[NonSerialized]
	public string Label;

	[NonSerialized]
	public WorkItem Work;

	[NonSerialized]
	private bool _updateLabel;

	[NonSerialized]
	private float? _changePrio;

	private static List<string> _promoteActions = new List<string> { "Promote", "Develop", "Finish", "Release", "Patent", "Buy" };

	private static List<string> _cancelActions = new List<string> { "Cancel", "End", "CancelSupport", "MarketingStop" };

	public void Init(WorkItem item, WorkGroupManager.GroupType type)
	{
		Work = item;
		MainLabel.text = (Label = WorkGroupManager.GetGroupingLabel(type, item));
		RefreshButtons();
		_updateLabel = false;
	}

	public float GetY()
	{
		Camera camera = UICamSize.GetUICam() ?? CameraScript.Instance.mainCam;
		Vector3 vector = camera.WorldToScreenPoint(base.transform.position);
		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(WindowManager.Instance.Canvas.GetComponent<RectTransform>(), new Vector2(vector.x, vector.y), camera, out localPoint);
		return localPoint.y;
	}

	public void RefreshButtons()
	{
		HashSet<string> hashSet = (from x in Work.GetButtons()
			select x.Key).ToHashSet();
		FinishButton.gameObject.SetActive(_promoteActions.Any(hashSet.Contains));
		CancelButton.gameObject.SetActive(_cancelActions.Any(hashSet.Contains));
		if (GUIWorkItem.HasDetails(Work))
		{
			DropButton.gameObject.SetActive(true);
			return;
		}
		hashSet.RemoveRange(_promoteActions);
		hashSet.RemoveRange(_cancelActions);
		DropButton.gameObject.SetActive(hashSet.Count > 0);
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		ProgressBar.sizeDelta = new Vector2(Work.GetProgress() * ProgressPanel.rect.width, 0f);
		ProgressImage.color = Work.GetProgressColor();
		BackProgImage.color = Work.GetLastPhaseProgress() ?? Color.white;
		PlayThumb.sprite = (Work.Paused ? PauseSprite : PlaySprite);
		PauseImage.SetActive(Work.Paused);
		PlayBack.color = ((Work.HightlightButton() != null) ? Utilities.Blink(Color.white, Color.red, 1f) : Color.white);
		Priority.text = Work.Priority.ToString();
		float max = Work.GetMax();
		if (max > 0f && max < 1f)
		{
			Indicator.gameObject.SetActive(true);
			Indicator.anchoredPosition = new Vector2(max * ProgressPanel.rect.width, 0f);
		}
		else
		{
			Indicator.gameObject.SetActive(false);
		}
		if (Label == null || _updateLabel)
		{
			MainLabel.text = Work.CollapseLabel();
		}
		if (_changePrio.HasValue)
		{
			float y = Input.mousePosition.y;
			if (Mathf.Abs(y - _changePrio.Value) > 32f)
			{
				Work.Priority = Mathf.Clamp(Work.Priority + Mathf.RoundToInt((y - _changePrio.Value) / 32f), 1, 10);
				_changePrio = y;
			}
			if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
			{
				_changePrio = null;
			}
		}
	}

	public void PlayClick()
	{
		Work.Paused = !Work.Paused;
		if (Work.guiItem != null)
		{
			Work.guiItem.UpdatePauseButton();
		}
	}

	private void TryActions(List<string> actions, GameObject button)
	{
		Dictionary<string, Action> dictionary = Work.GetButtons().ToDictionary((KeyValuePair<string, Action> x) => x.Key, (KeyValuePair<string, Action> x) => x.Value);
		for (int num = 0; num < actions.Count; num++)
		{
			string key = actions[num];
			Action value;
			if (dictionary.TryGetValue(key, out value))
			{
				value();
				return;
			}
		}
		button.SetActive(false);
	}

	public void FinishClick()
	{
		TryActions(_promoteActions, FinishButton.gameObject);
	}

	public void DropDownClick()
	{
		HUD.Instance.GroupTaskManager.ActionDropdown.Drop(this);
	}

	public void CancelClick()
	{
		TryActions(_cancelActions, CancelButton.gameObject);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_updateLabel = true;
		GroupWorkDetailPanel.Instance.Show(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_updateLabel = false;
		MainLabel.text = Label;
		if (!GroupWorkDetailPanel.Instance.CheckSelf())
		{
			GroupWorkDetailPanel.Instance.HideNow();
		}
	}

	public void ChangePriority(BaseEventData e)
	{
		PointerEventData pointerEventData;
		if ((pointerEventData = e as PointerEventData) != null)
		{
			Work.Priority = Mathf.Clamp(Work.Priority + Mathf.RoundToInt(pointerEventData.scrollDelta.y), 1, 10);
		}
	}

	public void StartChangePriority()
	{
		_changePrio = Input.mousePosition.y;
	}
}
