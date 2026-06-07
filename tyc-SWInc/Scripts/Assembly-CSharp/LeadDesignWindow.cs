using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using UnityEngine;
using UnityEngine.UI;

public class LeadDesignWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Scrollbar Scroll;

	public RectTransform ContentPanel;

	public InputField SearchBar;

	public GUIComplexList EmpList;

	[NonSerialized]
	private Action<Employee> _onClick;

	[NonSerialized]
	private SoftwareType _relevantType;

	[NonSerialized]
	private bool _init;

	[NonSerialized]
	private List<Employee> _employees = new List<Employee>();

	private void Init()
	{
		if (!_init)
		{
			EmpList.OnInitContent += OnInit;
			_init = true;
		}
	}

	private void OnInit(object sender, ComplexListItem e)
	{
		LeadDesignControl obj = (LeadDesignControl)e;
		obj.Checkable = true;
		SoftwareType relevantType = _relevantType;
		obj.SetSpec((relevantType != null) ? relevantType.Name : null);
	}

	public void Show(IEnumerable<Employee> emps, Employee active, SoftwareType relevantType, Action<Employee> onFinish, bool allowNull = false)
	{
		_employees.Clear();
		_employees.AddRange(emps);
		if (_employees.Count == 0)
		{
			WindowManager.Instance.ShowMessageBox("LeadDesignerNonApplicable".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		_relevantType = relevantType;
		Init();
		EmpList.CanDeselect = allowNull;
		EmpList.Init(_employees.OrderByDescending((Employee x) => (x != active) ? x.GetLeadDesignPriority(relevantType) : 100f), active);
		TutorialSystem.Instance.StartTutorial("Lead Designers");
		_onClick = onFinish;
		Window.Show();
		SearchBar.text = "";
		SearchBar.Select();
		OnSearchChanged();
		Scroll.value = 0f;
		AchievementController.SetInteraction(AchievementController.Mechanics.LeadDesigner);
	}

	public void OnSearchChanged()
	{
		string value = SearchBar.text.ToLower();
		if (string.IsNullOrWhiteSpace(value))
		{
			_employees.ForEach(delegate(Employee x)
			{
				EmpList.SetHidden(x, false);
			});
			return;
		}
		foreach (Employee employee in _employees)
		{
			EmpList.SetHidden(employee, !employee.ExtraName.ToLower().Contains(value));
		}
	}

	public void SearchEnd()
	{
		if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
		{
			List<Employee> list = EmpList.GetVisible<Employee>().ToList();
			if (list.Count == 1)
			{
				EmpList.SetSelected(list[0], true);
				OKClick();
			}
		}
	}

	public void OKClick()
	{
		List<Employee> list = EmpList.GetSelected<Employee>().ToList();
		_onClick((list.Count > 0) ? list[0] : null);
		Window.Close();
	}
}
