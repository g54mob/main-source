using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Achievements;
using UnityEngine;
using UnityEngine.UI;

public class WageWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView List;

	public RawImage Portrait;

	public Button CloseButton;

	public Button AcceptButton;

	public InputField SalaryLabel;

	public Text CloseText;

	public Text MinRaise;

	public Text Demand1Label;

	public Text Demand2Label;

	public GUIToolTipper Demand1Tip;

	public GUIToolTipper Demand2Tip;

	public Toggle Demand1;

	public Toggle Demand2;

	public GameObject Panel;

	public GameObject DemandPanel;

	public GameObject RejectButton;

	public Slider Wage;

	public RectTransform CurrentSalary;

	public RectTransform WagePanel;

	public bool Forced = true;

	public Color Red;

	public Color Black;

	public Color Green;

	private bool _canUpdateSalary = true;

	public Actor[] employees
	{
		get
		{
			return List.GetSelected<Actor>();
		}
	}

	public float CurrentWage
	{
		get
		{
			return GetWageChange(employees[0], Wage.value);
		}
	}

	private float GetWageChange(Actor act, float percent)
	{
		float num = act.employee.Worth(-2);
		return GetMinSalary(act, (percent > 0.5f) ? percent.MapRange(0.5f, 1f, num, GetMaximumSlider(act)) : percent.MapRange(0f, 0.5f, GetMinimumSlider(act), num), Forced);
	}

	public float GetWageDiff(Actor[] emps, float percent)
	{
		float num = 0f;
		foreach (Actor actor in emps)
		{
			num += (float)actor.GetWorkHours(true) * GetWageChange(actor, percent);
		}
		return num;
	}

	public float GetMinimumSlider(Actor act)
	{
		float num = act.employee.Worth(-2);
		float num2 = num - act.employee.Salary;
		if (num2 > 10f)
		{
			return Mathf.Max(act.employee.Salary - num2, Mathf.Min(act.employee.Salary, num * 0.5f));
		}
		return num * 0.5f;
	}

	public float GetMaximumSlider(Actor act)
	{
		return act.employee.Worth(-2) * 1.5f;
	}

	public float GetMinimum(Actor[] emps)
	{
		float num = 0f;
		for (int i = 0; i < emps.Length; i++)
		{
			num += emps[i].GetBenefitValue("Minimum raise");
		}
		return num;
	}

	public void OnEndSalaryEdit()
	{
		Actor[] array = employees;
		if (array.Length != 1)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < SalaryLabel.text.Length; i++)
		{
			char c = SalaryLabel.text[i];
			if (char.IsDigit(c) || c == '.')
			{
				stringBuilder.Append(c);
			}
		}
		try
		{
			float x = (float)Convert.ToDouble(stringBuilder.ToString());
			float minimumSlider = GetMinimumSlider(array[0]);
			float maximumSlider = GetMaximumSlider(array[0]);
			x = Mathf.Clamp(x.FromCurrency() / (float)array[0].GetWorkHours(true), minimumSlider, maximumSlider);
			float num = array[0].employee.Worth(-2);
			x = ((x < num) ? x.MapRange(minimumSlider, num, 0f, 0.5f) : x.MapRange(num, maximumSlider, 0.5f, 1f));
			Wage.value = x;
		}
		catch (Exception)
		{
		}
		UpdateSalary();
	}

	public void UpdateSalary()
	{
		if (!_canUpdateSalary)
		{
			return;
		}
		_canUpdateSalary = false;
		Actor[] array = employees;
		MinRaise.text = "";
		if (array.Length == 1)
		{
			float num = array[0].employee.Worth(-2);
			float minimumSlider = GetMinimumSlider(array[0]);
			float maximumSlider = GetMaximumSlider(array[0]);
			float salary = array[0].employee.Salary;
			if (salary >= minimumSlider && salary < maximumSlider && Mathf.Abs(salary - num) > 10f)
			{
				CurrentSalary.gameObject.SetActive(true);
				float x = ((salary < num) ? salary.MapRange(minimumSlider, num, 0f, 0.5f) : salary.MapRange(num, maximumSlider, 0.5f, 1f));
				CurrentSalary.anchorMin = new Vector2(x, 1f);
				CurrentSalary.anchorMax = new Vector2(x, 1f);
				CurrentSalary.anchoredPosition = new Vector2(0f, CurrentSalary.anchoredPosition.y);
			}
			else
			{
				CurrentSalary.gameObject.SetActive(false);
			}
			int workHours = array[0].GetWorkHours(true);
			SalaryLabel.text = ((float)workHours * CurrentWage).Currency();
			if (Wage.value < 0.5f)
			{
				SalaryLabel.textComponent.color = Color.Lerp(Red, Black, Wage.value / 0.5f);
			}
			else if (Wage.value > 0.5f)
			{
				SalaryLabel.textComponent.color = Color.Lerp(Black, Green, (Wage.value - 0.5f) / 0.5f);
			}
			else
			{
				SalaryLabel.textComponent.color = Black;
			}
			float num2 = (CurrentWage - array[0].GetRealSalary()) * (float)workHours;
			MinRaise.text = ((num2 > 0f) ? "+" : "") + num2.Currency() + " (" + (CurrentWage / array[0].employee.Salary - 1f).ToPercent(true, true) + ")";
		}
		else if (array.Length > 1)
		{
			CurrentSalary.gameObject.SetActive(false);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].NegotiateSalary = false;
			}
			float wageDiff = GetWageDiff(array, Wage.value);
			SalaryLabel.text = Mathf.Lerp(50f, 150f, Wage.value).ToString("N2") + "% (" + wageDiff.Currency() + ")";
			if (Wage.value < 0.5f)
			{
				SalaryLabel.textComponent.color = Color.Lerp(Red, Black, Wage.value / 0.5f);
			}
			else if (Wage.value > 0.5f)
			{
				SalaryLabel.textComponent.color = Color.Lerp(Black, Green, (Wage.value - 0.5f) / 0.5f);
			}
			else
			{
				SalaryLabel.textComponent.color = Black;
			}
			float num3 = wageDiff - array.SumSafe((Actor actor) => (float)actor.GetWorkHours(true) * actor.GetRealSalary());
			MinRaise.text = ((num3 > 0f) ? "+" : "") + num3.Currency();
		}
		float minimum = GetMinimum(array);
		if (minimum > 0f)
		{
			minimum *= array.Average((Actor actor) => actor.GetWorkHours(true));
			if (Forced)
			{
				Text minRaise = MinRaise;
				minRaise.text = minRaise.text + " (" + "Minimumraise".Loc() + ": " + minimum.Currency() + ")";
			}
			else
			{
				Text minRaise2 = MinRaise;
				minRaise2.text = minRaise2.text + " (" + "Minimumraise".Loc() + ")";
			}
		}
		_canUpdateSalary = true;
	}

	public void RejectSalary()
	{
		Actor[] array = employees;
		HashList<Actor> r = new HashList<Actor>();
		foreach (Actor actor in array)
		{
			if (actor.employee.DemandsRequested == 0)
			{
				actor.NegotiateSalary = false;
				actor.employee.ChangeSalary(actor.employee.Salary, actor.employee.Worth(-2), actor, true);
				r.Add(actor);
			}
		}
		List.Items.RemoveAll((object x) => r.Contains(x));
		List.Selected.Clear();
		if (List.Items.Count > 0)
		{
			List.Select(0);
		}
		else
		{
			Window.Close();
		}
	}

	public void AcceptSalary()
	{
		Actor[] array = employees;
		if (array.Length == 1)
		{
			bool flag = false;
			Actor actor = employees[0];
			if (actor.employee.DemandsRequested != 0)
			{
				int num = -1;
				if (Demand1.isOn)
				{
					num = 0;
				}
				else if (Demand2.isOn)
				{
					num = 1;
				}
				if (num == -1)
				{
					WindowManager.Instance.ShowMessageBox("LeadDemandError".Loc(actor), true, DialogWindow.DialogType.Error);
					return;
				}
				flag = AcceptDemand(actor, num);
			}
			if (!flag)
			{
				actor.NegotiateSalary = false;
				actor.employee.ChangeSalary(CurrentWage, actor.employee.Worth(-2), actor, true);
				List.Selected.Clear();
				List.Items.Remove(actor);
			}
			if (List.Items.Count > 0)
			{
				List.Select(0);
			}
			else
			{
				Window.Close();
			}
		}
		else if (array.Length > 1)
		{
			List<Actor> es = array.Where((Actor x) => x.employee.DemandsRequested == 0).ToList();
			for (int num2 = 0; num2 < es.Count; num2++)
			{
				Actor actor2 = es[num2];
				actor2.NegotiateSalary = false;
				actor2.employee.ChangeSalary(GetWageChange(actor2, Wage.value), actor2.employee.Worth(-2), actor2, true);
			}
			List.Items.RemoveAll((object x) => es.Contains(x));
			List.Selected.Clear();
			if (List.Items.Count > 0)
			{
				List.Select(0);
			}
			else
			{
				Window.Close();
			}
		}
	}

	public void Show(bool forced)
	{
		Forced = forced;
		Window.Show();
		if (Forced)
		{
			GameSettings.ForcePause = true;
			GameSettings.FreezeGame = true;
		}
		List.Initialize();
		List.Selected.Clear();
		List.Select(0);
		CloseButton.gameObject.SetActive(List.Items.OfType<Actor>().Any((Actor x) => x.employee.DemandsRequested == 0));
	}

	public void UpdateAcceptButton()
	{
		AcceptButton.interactable = !DemandPanel.activeSelf || Demand1.isOn || Demand2.isOn;
	}

	private void Start()
	{
		List.OnSelectChange = delegate
		{
			Actor[] array = employees;
			SalaryLabel.interactable = false;
			Demand1.isOn = false;
			Demand2.isOn = false;
			float value = 0.5f;
			if (array.Length == 1)
			{
				SalaryLabel.interactable = true;
				KeyValuePair<Texture2D, Rect> keyValuePair = array[0].Snapshot();
				Portrait.texture = keyValuePair.Key;
				Portrait.uvRect = keyValuePair.Value;
				Portrait.gameObject.SetActive(true);
				WagePanel.offsetMin = new Vector2(142.5f, WagePanel.offsetMin.y);
				float benefitValue = array[0].GetBenefitValue("Minimum raise");
				if (benefitValue > 0f)
				{
					float a = array[0].employee.Worth(-2);
					value = Mathf.Max(a, array[0].employee.Salary + benefitValue).MapRange(a, GetMaximumSlider(array[0]), 0.5f, 1f, true);
				}
				if (array[0].employee.DemandsRequested != 0)
				{
					RejectButton.gameObject.SetActive(false);
					LeadDesignDemands.DemandChoice choice = LeadDesignDemands.GetChoice(array[0].employee.DemandsRequested);
					if (choice != null)
					{
						DemandPanel.SetActive(true);
						Demand1Label.text = ("LeadDemand" + choice.Choice1).Loc();
						Demand2Label.text = ("LeadDemand" + choice.Choice2).Loc();
						Demand1Tip.TooltipDescription = "LeadDemand" + choice.Choice1.ToString() + "Tip";
						Demand2Tip.TooltipDescription = "LeadDemand" + choice.Choice2.ToString() + "Tip";
					}
					else
					{
						DemandPanel.SetActive(false);
					}
				}
				else
				{
					DemandPanel.SetActive(false);
					RejectButton.gameObject.SetActive(true);
				}
			}
			else if (array.Length > 1)
			{
				Portrait.gameObject.SetActive(false);
				WagePanel.offsetMin = new Vector2(2f, WagePanel.offsetMin.y);
				DemandPanel.SetActive(false);
				RejectButton.gameObject.SetActive(array.Any((Actor x) => x.employee.DemandsRequested == 0));
			}
			Wage.value = value;
			UpdateSalary();
			UpdateAcceptButton();
		};
		Window.OnClose = delegate
		{
			List.Items.Clear();
			if (Forced)
			{
				GameSettings.ForcePause = false;
				if (Options.ShouldAutoSave)
				{
					SaveGameManager.Instance.AutoSave();
				}
			}
		};
	}

	public static float GetMinSalary(Actor act, float wanted, bool forced)
	{
		float benefitValue = act.GetBenefitValue("Minimum raise");
		if (benefitValue > 0f)
		{
			if (!forced)
			{
				return Mathf.Max(act.GetRealSalary(), wanted);
			}
			return Mathf.Max(act.GetRealSalary() + benefitValue, wanted);
		}
		return wanted;
	}

	public void Close()
	{
		if (Forced && List.Items.Count > 0)
		{
			List<Actor> elligible = (from x in List.Items.OfType<Actor>()
				where x.employee.DemandsRequested == 0
				select x).ToList();
			if (elligible.Count > 0)
			{
				float[] array = elligible.Select((Actor x) => (float)x.GetWorkHours(true) * (GetMinSalary(x, x.employee.Worth(-2), Forced) - x.employee.Salary)).ToArray();
				if (array.Sum().CurrencyMul() > 0.999f)
				{
					DialogWindow dialogWindow = WindowManager.Instance.ShowMessageBox("AcceptAllWagesWarning".Loc(array.Average().Currency(), array.Sum().Currency()), true, DialogWindow.DialogType.Warning, delegate
					{
						for (int i = 0; i < elligible.Count; i++)
						{
							Actor actor2 = elligible[i];
							float minSalary2 = GetMinSalary(actor2, actor2.employee.Worth(-2), Forced);
							actor2.employee.ChangeSalary(minSalary2, minSalary2, actor2, true);
							actor2.NegotiateSalary = false;
							List.Items.Remove(actor2);
						}
						if (List.Items.Count == 0)
						{
							Window.Close();
						}
						else
						{
							CloseButton.gameObject.SetActive(false);
						}
					}, "AcceptAllWages");
					if (dialogWindow != null)
					{
						dialogWindow.Window.SetParentWindow(Window);
					}
				}
				else
				{
					for (int num = 0; num < elligible.Count; num++)
					{
						Actor actor = elligible[num];
						float minSalary = GetMinSalary(actor, actor.employee.Worth(-2), Forced);
						actor.employee.ChangeSalary(minSalary, minSalary, actor, true);
						actor.NegotiateSalary = false;
						List.Items.Remove(actor);
					}
					if (List.Items.Count == 0)
					{
						Window.Close();
					}
					else
					{
						CloseButton.gameObject.SetActive(false);
					}
				}
			}
			else if (List.Items.Count > 0)
			{
				CloseButton.gameObject.SetActive(false);
			}
		}
		else
		{
			Window.Close();
		}
	}

	private void Update()
	{
		Panel.SetActive(List.Selected.Count > 0);
		if (List.Items.Count == 0)
		{
			Window.Close();
		}
		else
		{
			if (!CloseButton.gameObject.activeSelf)
			{
				return;
			}
			if (Forced && List.Items.Count > 0)
			{
				int num = List.Items.OfType<Actor>().Count((Actor x) => x.employee.DemandsRequested != 0);
				if (num > 0)
				{
					if (num == List.Items.Count)
					{
						CloseButton.gameObject.SetActive(false);
					}
					else
					{
						CloseText.text = "AcceptAllWagesNoClose".Loc();
					}
				}
				else
				{
					CloseText.text = "AcceptAllWages".Loc();
				}
			}
			else
			{
				CloseText.text = "Close".Loc();
			}
		}
	}

	public bool AcceptDemand(Actor e, int choice)
	{
		if (e.employee.DemandsRequested != 0)
		{
			LeadDesignDemands.DemandChoice choice2 = LeadDesignDemands.GetChoice(e.employee.DemandsRequested);
			if (choice2 != null)
			{
				LeadDesignDemands.Demand num = ((choice == 0) ? choice2.Choice1 : choice2.Choice2);
				e.employee.AcceptDemand(choice2, choice, true);
				AchievementController.SetInteraction(AchievementController.Mechanics.LeadDesigner);
				if (num == LeadDesignDemands.Demand.Fire)
				{
					e.Fire(false);
					return true;
				}
			}
		}
		return false;
	}

	public void SelectAll()
	{
		List.ClearSelected();
		int[] array = new int[List.Items.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i;
		}
		List.LastSelectDirect = true;
		List.Selected.AddRange(array);
		List.UpdateSelected();
	}
}
