using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ComplaintWindow : MonoBehaviour
{
	public ComplaintBar ComplaintBarPrefab;

	public GUIWindow Window;

	public GameObject AcceptButton;

	public GameObject IgnoreButton;

	public Text ComplaintText;

	public Text AcceptLabel;

	public RawImage Portrait;

	public GUIListView ComplaintList;

	public ButtonCounter Counter;

	public RectTransform ComplaintPanel;

	public Transform ComplaintBarPanel;

	public Gradient ComplaintBarGrad;

	private Dictionary<string, HashSet<Actor>> _complaintActors = new Dictionary<string, HashSet<Actor>>();

	private List<ComplaintBar> _complaintBars = new List<ComplaintBar>();

	private int _actorOffset;

	private bool _init;

	private void UpdateBars()
	{
		float num = GameSettings.Instance.sActorManager.Actors.Count((Actor x) => x.employee.Founder);
		for (int num2 = 0; num2 < _complaintBars.Count; num2++)
		{
			ComplaintBar complaintBar = _complaintBars[num2];
			HashSet<Actor> orNull = _complaintActors.GetOrNull(complaintBar.Thought);
			float num3 = 0f;
			float num4 = 0f;
			int number = 0;
			if (orNull != null)
			{
				foreach (Actor item in orNull)
				{
					float orDefault = item.employee.Thoughts.GetOrDefault(complaintBar.Thought, (Employee.ThoughtEffect z) => z.Effect, 0f);
					num4 = Mathf.Max(num4, orDefault);
					num3 += orDefault;
				}
				number = orNull.Count;
			}
			if (num4 > 0.03f && num3 > 0f)
			{
				complaintBar.gameObject.SetActive(true);
				num3 /= Mathf.Min(5f, GameData.MoodEffects[complaintBar.Thought].Max);
				complaintBar.Prog.Value = num3 / ((float)GameSettings.Instance.sActorManager.Actors.Count - num);
				complaintBar.Value = num3;
				complaintBar.EmpLabel.text = "Employee".LocPlural(number);
				complaintBar.Tipper.TooltipDescription = (complaintBar.Thought + "Hint").LocDef(null);
			}
			else
			{
				complaintBar.gameObject.SetActive(false);
				complaintBar.Value = 0f;
			}
		}
		_complaintBars.Sort((ComplaintBar x, ComplaintBar y) => -x.Value.CompareTo(y.Value));
		for (int num5 = 0; num5 < _complaintBars.Count; num5++)
		{
			_complaintBars[num5].transform.SetSiblingIndex(num5);
		}
	}

	private void ShowClick(string thought)
	{
		HashSet<Actor> hashSet = _complaintActors[thought];
		if (hashSet.Count == 1)
		{
			HUD.Instance.DetailWindow.Show(hashSet.First());
		}
		else
		{
			HUD.Instance.employeeWindow.Show(hashSet);
		}
	}

	private void UpdateAllThoughts()
	{
		foreach (HashSet<Actor> value in _complaintActors.Values)
		{
			value.Clear();
		}
		for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors[i];
			for (int j = 0; j < actor.employee.Thoughts.List.Count; j++)
			{
				Employee.ThoughtEffect thoughtEffect = actor.employee.Thoughts.List[j];
				if (thoughtEffect.Mood.Negative)
				{
					_complaintActors.Append(thoughtEffect.Thought, actor);
				}
			}
		}
	}

	private void UpdateSelected()
	{
		Complaint[] selected = ComplaintList.GetSelected<Complaint>();
		if (selected.Length == 1)
		{
			float num = (selected[0].Target.Salary + selected[0].Demand) * (float)selected[0].Target.MyActor.GetWorkHours(true);
			float monthlySalary = selected[0].Target.MyActor.GetMonthlySalary();
			AcceptLabel.text = "ComplaintRaise".Loc(selected, num.Currency(), (num - monthlySalary).Currency());
			AcceptButton.SetActive(true);
			IgnoreButton.SetActive(true);
			ComplaintPanel.gameObject.SetActive(true);
			ComplaintPanel.offsetMin = new Vector2(140f, ComplaintPanel.offsetMin.y);
			Portrait.gameObject.SetActive(true);
			ComplaintList.rectTransform.offsetMin = new Vector2(ComplaintList.rectTransform.offsetMin.x, 180f);
			KeyValuePair<Texture2D, Rect> keyValuePair = selected[0].Target.MyActor.Snapshot();
			Portrait.texture = keyValuePair.Key;
			Portrait.uvRect = keyValuePair.Value;
			ComplaintText.text = string.Join("\n", selected[0].Complaints.SelectInPlace((string x) => x.Loc()));
		}
		else if (selected.Length > 1)
		{
			float num2 = selected.SumSafe((Complaint x) => (x.Target.Salary + x.Demand) * (float)x.Target.MyActor.GetWorkHours(true));
			float num3 = selected.SumSafe((Complaint x) => x.Target.MyActor.GetMonthlySalary());
			AcceptLabel.text = "ComplaintRaise".Loc(selected, num2.Currency(), (num2 - num3).Currency());
			AcceptButton.SetActive(true);
			IgnoreButton.SetActive(true);
			ComplaintPanel.gameObject.SetActive(true);
			ComplaintPanel.offsetMin = new Vector2(8f, ComplaintPanel.offsetMin.y);
			ComplaintList.rectTransform.offsetMin = new Vector2(ComplaintList.rectTransform.offsetMin.x, 180f);
			Portrait.gameObject.SetActive(false);
			HashSet<string> complaints = new HashSet<string>();
			selected.ForEachEnum(delegate(Complaint x)
			{
				complaints.AddRange(x.Complaints);
			});
			ComplaintText.text = string.Join("\n", complaints.SelectInPlace((string x) => x.Loc()));
		}
		else
		{
			AcceptButton.SetActive(false);
			IgnoreButton.SetActive(false);
			ComplaintPanel.gameObject.SetActive(false);
			Portrait.gameObject.SetActive(false);
			ComplaintText.text = "";
			ComplaintList.rectTransform.offsetMin = new Vector2(ComplaintList.rectTransform.offsetMin.x, 16f);
		}
	}

	public void Toggle()
	{
		Window.Toggle();
		if (Window.Shown)
		{
			UpdateShow();
		}
	}

	public void Show()
	{
		Window.Show();
		UpdateShow();
	}

	private void UpdateShow()
	{
		Init();
		if (ComplaintList.Items.Count > 0)
		{
			ComplaintList.Select(0);
		}
		UpdateSelected();
		UpdateAllThoughts();
	}

	private void Init()
	{
		if (_init)
		{
			return;
		}
		ComplaintList.OnSelectChange = delegate
		{
			UpdateSelected();
		};
		List<MoodEffect> list = GameData.MoodEffects.Values.Where((MoodEffect x) => x.Negative).ToList();
		float a = list.MinSafe((MoodEffect x) => x.Severity);
		float b = list.MaxSafe((MoodEffect x) => x.Severity);
		for (int num = 0; num < list.Count; num++)
		{
			MoodEffect moodEffect = list[num];
			if (!"TiredOfJob".Equals(moodEffect.Thought))
			{
				MoodEffect ef = moodEffect;
				ComplaintBar complaintBar = Object.Instantiate(ComplaintBarPrefab);
				complaintBar.Thought = moodEffect.Thought;
				complaintBar.MainLabel.text = moodEffect.Thought.Loc();
				complaintBar.Button.onClick.AddListener(delegate
				{
					ShowClick(ef.Thought);
				});
				complaintBar.transform.SetParent(ComplaintBarPanel, false);
				complaintBar.Prog.StartColor = ComplaintBarGrad.Evaluate(moodEffect.Severity.MapRange(a, b, 0f, 1f));
				_complaintBars.Add(complaintBar);
			}
		}
		_init = true;
	}

	public void RefreshComplaints()
	{
		SDateTime now = SDateTime.Now();
		bool flag = false;
		for (int i = 0; i < ComplaintList.Items.Count; i++)
		{
			Complaint complaint = (Complaint)ComplaintList.Items[i];
			if (SDateTime.DayHasPassed(complaint.Date, now))
			{
				complaint.Target.MyActor.HandleComplaint(complaint.Target.Salary + complaint.Demand, false, complaint.Severity);
				ComplaintList.Items.Remove(complaint);
				i--;
				flag = true;
			}
		}
		if (flag)
		{
			UpdateCounter();
		}
	}

	public void AddComplaint(Actor emp, string[] problems, float demand, float severity)
	{
		Complaint value = new Complaint(emp.employee, demand, severity, SDateTime.Now(), problems);
		ComplaintList.Items.Add(value);
		if (!NotificationManager.CheckAggregate<ComplaintNotification>(null))
		{
			NotificationManager.AddNotification(new ComplaintNotification(SDateTime.Now()));
		}
		UpdateCounter();
	}

	public void UpdateCounter()
	{
		Counter.SetNumber(ComplaintList.Items.Count);
	}

	public void Finalize(bool keep)
	{
		Complaint[] selected = ComplaintList.GetSelected<Complaint>();
		if (selected.Length != 0)
		{
			foreach (Complaint complaint in selected)
			{
				complaint.Target.MyActor.HandleComplaint(complaint.Target.Salary + complaint.Demand, keep, complaint.Severity);
				ComplaintList.Items.Remove(complaint);
			}
			UpdateCounter();
			if (ComplaintList.Items.Count > 0)
			{
				ComplaintList.Select(0);
			}
		}
	}

	public void ClearActor(Actor ac)
	{
		ComplaintList.Items.RemoveAll((object x) => ((Complaint)x).Target == ac.employee);
		UpdateCounter();
		foreach (HashSet<Actor> value in _complaintActors.Values)
		{
			value.Remove(ac);
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		EventList<Actor> actors = GameSettings.Instance.sActorManager.Actors;
		int num = Mathf.Min(50, actors.Count);
		for (int i = 0; i < num; i++)
		{
			int i2 = (i + _actorOffset) % actors.Count;
			Actor actor = actors[i2];
			foreach (KeyValuePair<string, HashSet<Actor>> complaintActor in _complaintActors)
			{
				complaintActor.Value.Remove(actor);
			}
			for (int j = 0; j < actor.employee.Thoughts.List.Count; j++)
			{
				Employee.ThoughtEffect thoughtEffect = actor.employee.Thoughts.List[j];
				if (thoughtEffect.Mood.Negative)
				{
					_complaintActors.Append(thoughtEffect.Thought, actor);
				}
			}
		}
		if (actors.Count > 0)
		{
			_actorOffset = (_actorOffset + num) % actors.Count;
		}
		else
		{
			_actorOffset = 0;
		}
		UpdateBars();
	}

	private void Start()
	{
		Init();
	}
}
