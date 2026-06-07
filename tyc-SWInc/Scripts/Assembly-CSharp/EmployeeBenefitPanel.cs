using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EmployeeBenefitPanel : MonoBehaviour
{
	public enum Style
	{
		Reset = 0,
		Override = 1
	}

	public Transform Panel;

	public GameObject SliderPrefab;

	public GameObject LabelPrefab;

	public GameObject CheckBoxPrefab;

	public GameObject ResetButton;

	[NonSerialized]
	private Dictionary<string, KeyValuePair<Slider, Toggle>> _values = new Dictionary<string, KeyValuePair<Slider, Toggle>>();

	[NonSerialized]
	public IBenefitReceiver[] Targets;

	public Style BenefitStyle;

	public UnityEvent OnChange = new UnityEvent();

	public UnityEvent BeforeChange = new UnityEvent();

	private void Start()
	{
		Init();
	}

	private void Init()
	{
		if (_values.Count != 0)
		{
			return;
		}
		foreach (KeyValuePair<string, EmployeeBenefit> benefit2 in EmployeeBenefit.Benefits)
		{
			Toggle toggle = MakeElement<Toggle>(CheckBoxPrefab);
			Text text = MakeElement<Text>(LabelPrefab);
			text.text = benefit2.Key.Loc() + ":";
			text.gameObject.AddComponent<GUIToolTipper>().TooltipDescription = benefit2.Value.Tip;
			Slider slider = MakeElement<Slider>(SliderPrefab);
			slider.wholeNumbers = true;
			slider.maxValue = Mathf.FloorToInt((benefit2.Value.Max - benefit2.Value.Min) / benefit2.Value.Increment);
			Text l = MakeElement<Text>(LabelPrefab);
			KeyValuePair<string, EmployeeBenefit> benefit1 = benefit2;
			slider.onValueChanged.AddListener(delegate(float x)
			{
				float num = benefit1.Value.Min + x * benefit1.Value.Increment;
				float valueFromTarget = GetValueFromTarget(benefit1.Key);
				if (!Mathf.Approximately(num, valueFromTarget))
				{
					l.text = benefit1.Value.AddPost(benefit1.Value.ValueToText(num) + "*") + " (" + benefit1.Value.ValueToText(valueFromTarget) + ")";
				}
				else
				{
					l.text = benefit1.Value.AddPost(benefit1.Value.ValueToText(num));
				}
			});
			slider.value = Mathf.FloorToInt((GetValueFromTarget(benefit1.Key) - benefit2.Value.Min) / benefit2.Value.Increment);
			slider.onValueChanged.Invoke(slider.value);
			toggle.onValueChanged.AddListener(delegate(bool x)
			{
				ToggleChange(benefit1.Key, x);
			});
			_values[benefit1.Key] = new KeyValuePair<Slider, Toggle>(slider, toggle);
		}
	}

	private void ToggleChange(string key, bool on)
	{
		_values[key].Key.interactable = BenefitStyle == Style.Reset || on;
	}

	private float GetValueFromTarget(string key, bool ignoreSelf = false)
	{
		if (Targets != null)
		{
			return Targets.Mode((IBenefitReceiver x) => x.GetBenefitValue(key, ignoreSelf), 0f);
		}
		return EmployeeBenefit.Benefits[key].Default;
	}

	private T MakeElement<T>(GameObject o)
	{
		GameObject obj = UnityEngine.Object.Instantiate(o);
		obj.transform.SetParent(Panel, false);
		return obj.GetComponent<T>();
	}

	public void SetTargets(Style style, params IBenefitReceiver[] targets)
	{
		Targets = targets;
		BenefitStyle = style;
		Init();
		foreach (KeyValuePair<string, KeyValuePair<Slider, Toggle>> value in _values)
		{
			SetValue(value.Key, value.Value.Key, value.Value.Value, false);
			value.Value.Value.GetComponent<GUIToolTipper>().ToolTipValue = BenefitStyle.ToString() + "Benefits";
		}
		if (ResetButton != null)
		{
			ResetButton.SetActive(BenefitStyle == Style.Override);
		}
	}

	public void SetValue(string key, Slider slider, Toggle toggle, bool ignoreSelf)
	{
		EmployeeBenefit benefit = EmployeeBenefit.Benefits[key];
		slider.value = Mathf.FloorToInt((GetValueFromTarget(key, ignoreSelf) - benefit.Min) / benefit.Increment);
		bool flag = BenefitStyle == Style.Override && Targets != null && Targets.Any((IBenefitReceiver x) => x.GetBenefits().ContainsKey(benefit.Name));
		ToggleChange(key, flag);
		toggle.isOn = flag;
	}

	public void ClearAll()
	{
		foreach (KeyValuePair<string, KeyValuePair<Slider, Toggle>> value in _values)
		{
			SetValue(value.Key, value.Value.Key, value.Value.Value, true);
		}
		_values.ForEachEnum(delegate(KeyValuePair<string, KeyValuePair<Slider, Toggle>> x)
		{
			x.Value.Value.isOn = false;
		});
	}

	public void Apply()
	{
		if (Targets == null)
		{
			return;
		}
		BeforeChange.Invoke();
		foreach (KeyValuePair<string, KeyValuePair<Slider, Toggle>> value in _values)
		{
			if (BenefitStyle == Style.Reset || value.Value.Value.isOn)
			{
				EmployeeBenefit employeeBenefit = EmployeeBenefit.Benefits[value.Key];
				IBenefitReceiver[] targets = Targets;
				for (int i = 0; i < targets.Length; i++)
				{
					targets[i].GetBenefits()[value.Key] = employeeBenefit.Min + value.Value.Key.value * employeeBenefit.Increment;
				}
				value.Value.Key.onValueChanged.Invoke(value.Value.Key.value);
			}
			if (BenefitStyle == Style.Override && !value.Value.Value.isOn)
			{
				IBenefitReceiver[] targets = Targets;
				for (int i = 0; i < targets.Length; i++)
				{
					targets[i].GetBenefits().Remove(value.Key);
				}
			}
			if (BenefitStyle != Style.Reset || !value.Value.Value.isOn)
			{
				continue;
			}
			foreach (Actor actor in GameSettings.Instance.sActorManager.Actors)
			{
				actor.employee.CustomBenefits.Remove(value.Key);
			}
			foreach (Team value2 in GameSettings.Instance.sActorManager.Teams.Values)
			{
				value2.Benefits.Remove(value.Key);
			}
		}
		if (BenefitStyle == Style.Reset)
		{
			foreach (KeyValuePair<string, KeyValuePair<Slider, Toggle>> value3 in _values)
			{
				value3.Value.Value.isOn = false;
			}
		}
		CalendarWindow.ScheduleRefresh = true;
		Revert();
		OnChange.Invoke();
	}

	public void Revert()
	{
		SetTargets(BenefitStyle, Targets);
	}
}
