using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CustomDifficultyWindow : MonoBehaviour
{
	public class DifficultyConverter
	{
		public float[] Values;

		public float Min;

		public float Max;

		public float Discretization;

		public DifficultyConverter(FieldInfo field, DifficultyValues.DifficultyTip tip)
		{
			if (tip.Free)
			{
				Min = tip.ActualMinValue;
				Max = tip.ActualMaxValue;
				Discretization = tip.Discretization;
				{
					foreach (DifficultyValues.DifficultySetting value in DifficultyValues.Difficulties.Values)
					{
						float diffFieldValue = value.GetDiffFieldValue(field);
						Min = Mathf.Min(diffFieldValue, Min);
						Max = Mathf.Max(diffFieldValue, Max);
					}
					return;
				}
			}
			HashSet<float> hashSet = new HashSet<float>();
			foreach (DifficultyValues.DifficultySetting value2 in DifficultyValues.Difficulties.Values)
			{
				hashSet.Add(value2.GetDiffFieldValue(field));
			}
			if (tip.ActualMaxValue != float.MinValue)
			{
				hashSet.Add(tip.ActualMaxValue);
			}
			if (tip.ActualMinValue != float.MaxValue)
			{
				hashSet.Add(tip.ActualMinValue);
			}
			Values = hashSet.OrderBy((float x) => x).ToArray();
		}

		public void InitSliderSettings(Slider sl)
		{
			sl.wholeNumbers = true;
			sl.minValue = 0f;
			if (Values != null)
			{
				sl.maxValue = Values.Length - 1;
			}
			else
			{
				sl.maxValue = Mathf.FloorToInt((Max - Min) / Discretization);
			}
		}

		public float GetValue(float sliderValue)
		{
			if (Values != null)
			{
				return Values[Mathf.Clamp((int)sliderValue, 0, Values.Length - 1)];
			}
			return Min + sliderValue * Discretization;
		}

		public float ToSliderValue(float value)
		{
			if (Values != null)
			{
				int num = Array.IndexOf(Values, value);
				if (num < 0)
				{
					return 0f;
				}
				return num;
			}
			return Mathf.Clamp(Mathf.RoundToInt((value - Min) / Discretization), 0, Mathf.FloorToInt((Max - Min) / Discretization));
		}
	}

	public GUIWindow Window;

	public Slider SliderPrefab;

	public Toggle TogglePrefab;

	public Text LabelPrefab;

	public Text DescLabel;

	public RectTransform ContentPanel;

	[NonSerialized]
	private Dictionary<string, ValueTuple<UnityEngine.UI.Selectable, FieldInfo, DifficultyConverter>> _difficultyFields = new Dictionary<string, ValueTuple<UnityEngine.UI.Selectable, FieldInfo, DifficultyConverter>>();

	[NonSerialized]
	private Action<DifficultyValues.DifficultySetting> _onAccept;

	private bool _disableUpdates;

	private void Init()
	{
		_disableUpdates = true;
		List<ValueTuple<FieldInfo, DifficultyValues.DifficultyTip>> allFields = DifficultyValues.GetAllFields();
		for (int i = 0; i < allFields.Count; i++)
		{
			FieldInfo item = allFields[i].Item1;
			DifficultyValues.DifficultyTip tip = allFields[i].Item2;
			Text text = UnityEngine.Object.Instantiate(LabelPrefab);
			text.text = tip.Loc.Loc();
			text.transform.SetParent(ContentPanel, false);
			if (tip.Type == DifficultyValues.DifficultyTip.TipType.Bool)
			{
				Toggle toggle = UnityEngine.Object.Instantiate(TogglePrefab);
				toggle.transform.SetParent(ContentPanel, false);
				_difficultyFields[item.Name] = new ValueTuple<UnityEngine.UI.Selectable, FieldInfo, DifficultyConverter>(toggle, item, null);
				continue;
			}
			Slider slider = UnityEngine.Object.Instantiate(SliderPrefab);
			slider.transform.SetParent(ContentPanel, false);
			DifficultyConverter converter = new DifficultyConverter(item, tip);
			Text slLabel = slider.GetComponentInChildren<Text>();
			converter.InitSliderSettings(slider);
			slider.onValueChanged.AddListener(delegate(float x)
			{
				slLabel.text = tip.GetDescription(converter.GetValue(x), true);
				UpdateDesc();
			});
			slider.onValueChanged.Invoke(slider.value);
			_difficultyFields[item.Name] = new ValueTuple<UnityEngine.UI.Selectable, FieldInfo, DifficultyConverter>(slider, item, converter);
		}
		_disableUpdates = false;
	}

	public void Show(DifficultyValues.DifficultySetting setting, Action<DifficultyValues.DifficultySetting> onAccept)
	{
		Init();
		foreach (KeyValuePair<string, ValueTuple<UnityEngine.UI.Selectable, FieldInfo, DifficultyConverter>> difficultyField in _difficultyFields)
		{
			Slider slider;
			Toggle toggle;
			if ((object)(slider = difficultyField.Value.Item1 as Slider) != null)
			{
				slider.value = difficultyField.Value.Item3.ToSliderValue(setting.GetDiffFieldValue(difficultyField.Value.Item2));
			}
			else if ((object)(toggle = difficultyField.Value.Item1 as Toggle) != null)
			{
				toggle.isOn = setting.GetDiffFieldValue(difficultyField.Value.Item2) > 0.5f;
			}
		}
		UpdateDesc();
		_onAccept = onAccept;
		Window.Show();
	}

	public void UpdateDesc()
	{
		if (!_disableUpdates)
		{
			DescLabel.text = DifficultyValues.FindClosest(GetSetting(), DifficultyValues.Difficulties.Values).Name.Loc();
		}
	}

	public DifficultyValues.DifficultySetting GetSetting()
	{
		DifficultyValues.DifficultySetting difficultySetting = new DifficultyValues.DifficultySetting("CustomDifficulty");
		foreach (KeyValuePair<string, ValueTuple<UnityEngine.UI.Selectable, FieldInfo, DifficultyConverter>> difficultyField in _difficultyFields)
		{
			Slider slider;
			Toggle toggle;
			if ((object)(slider = difficultyField.Value.Item1 as Slider) != null)
			{
				difficultySetting.SetDiffFieldValue(difficultyField.Value.Item2, difficultyField.Value.Item3.GetValue(slider.value));
			}
			else if ((object)(toggle = difficultyField.Value.Item1 as Toggle) != null)
			{
				difficultySetting.SetDiffFieldValue(difficultyField.Value.Item2, toggle.isOn ? 1f : 0f);
			}
		}
		return difficultySetting;
	}

	public void Accept()
	{
		_onAccept(GetSetting());
		Window.Close();
	}

	public void Cancel()
	{
		Window.Close();
	}
}
