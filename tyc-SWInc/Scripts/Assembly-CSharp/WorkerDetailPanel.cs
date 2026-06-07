using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerDetailPanel : MonoBehaviour
{
	public Text Header;

	public Image Prog1;

	public Image Prog2;

	public RectTransform ButtonPanel;

	public RectTransform Progress;

	public RectTransform Progress1;

	public GameObject[] Stars;

	public GUIToolTipper Tipper;

	public WorkerDetailButton ButtonPrefab;

	public Dictionary<Actor, WorkerDetailButton> Buttons = new Dictionary<Actor, WorkerDetailButton>();

	public List<WorkerDetailButton> InActiveButtons = new List<WorkerDetailButton>();

	[NonSerialized]
	public string Spec;

	public void SetProgress(float p)
	{
		Prog1.color = SpecializationChart.GetSkillColor((p > 0.999f) ? Employee.EmployeeRole.Service : Employee.EmployeeRole.Designer);
		Progress.sizeDelta = new Vector2(ButtonPanel.sizeDelta.x * p, Progress.sizeDelta.y);
		Progress1.sizeDelta = new Vector2(0f, Progress.sizeDelta.y);
	}

	public void SetProgress(float p, float a, float ratio)
	{
		Prog1.color = SpecializationChart.GetSkillColor((!(p >= 1f)) ? Employee.EmployeeRole.Programmer : Employee.EmployeeRole.Service);
		Prog2.color = SpecializationChart.GetSkillColor((a >= 1f) ? Employee.EmployeeRole.Service : Employee.EmployeeRole.Artist);
		Progress.sizeDelta = new Vector2(ButtonPanel.sizeDelta.x * p * ratio, Progress.sizeDelta.y);
		Progress1.sizeDelta = new Vector2(ButtonPanel.sizeDelta.x * a * (1f - ratio), Progress.sizeDelta.y);
	}

	public bool AddWorker(Actor a)
	{
		if (!Buttons.ContainsKey(a))
		{
			WorkerDetailButton workerDetailButton;
			if (InActiveButtons.Count > 0)
			{
				workerDetailButton = InActiveButtons[InActiveButtons.Count - 1];
				InActiveButtons.RemoveAt(InActiveButtons.Count - 1);
				workerDetailButton.gameObject.SetActive(true);
			}
			else
			{
				workerDetailButton = UnityEngine.Object.Instantiate(ButtonPrefab);
				workerDetailButton.transform.SetParent(ButtonPanel, false);
			}
			workerDetailButton.SetActor(a);
			Buttons[a] = workerDetailButton;
			return true;
		}
		return false;
	}

	public bool RemoveWorker(Actor a)
	{
		WorkerDetailButton value;
		if (!a.IsReferenceNull() && Buttons.TryGetValue(a, out value))
		{
			value.gameObject.SetActive(false);
			Buttons.Remove(a);
			InActiveButtons.Add(value);
			return true;
		}
		return false;
	}

	public void Clear()
	{
		Buttons.Values.ForEachEnum(delegate(WorkerDetailButton x)
		{
			x.gameObject.SetActive(false);
		});
		InActiveButtons.AddRange(Buttons.Values);
		Buttons.Clear();
	}
}
