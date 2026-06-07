using Data.FactoryFloor.Behaviours;
using Data.Operator;
using Data.Variables;
using TMPro;
using UnityEngine;

public class OperatorUpdateFrequencyText : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _frequencyText;

	[SerializeField]
	[LocaKey]
	private string _updateFrequencyLoc = "Factory.UpdateFrequency";

	[SerializeField]
	private IntVariableSO _factoryStepsPerSecond;

	[SerializeField]
	private IntVariableSO _globalUpdateMultiplier;

	private float _speedPerSecond;

	public float SpeedPerSecond => _speedPerSecond;

	public void Populate(FactoryObjectUIData uiData)
	{
		Populate((uiData != null) ? uiData.FactoryObjectBehaviour : null);
	}

	public void UpdateLocalization()
	{
		if (_updateFrequencyLoc == "Factory.UpdateFrequency")
		{
			_frequencyText.SetText(LocalizationUtility.GetLocalizedText(_updateFrequencyLoc).Replace("\\n", "\n"), _speedPerSecond * 60f);
		}
		else
		{
			_frequencyText.SetText(string.Format(LocalizationUtility.GetLocalizedText(_updateFrequencyLoc), _speedPerSecond * 60f, "FrequencyUnit"));
		}
	}

	public void Populate(FactoryObjectBehaviour factoryObjectBehaviour)
	{
		if (factoryObjectBehaviour == null)
		{
			_frequencyText.gameObject.SetActive(value: false);
			return;
		}
		IntVariableSO variableUpdateFrequency = factoryObjectBehaviour.VariableUpdateFrequency;
		if (variableUpdateFrequency != null)
		{
			Populate(variableUpdateFrequency.Value);
		}
	}

	public void Populate(float updateFrequency)
	{
		if (updateFrequency <= 0f || updateFrequency > 999f)
		{
			_frequencyText.gameObject.SetActive(value: false);
			return;
		}
		_speedPerSecond = (float)_factoryStepsPerSecond.Value * (float)_globalUpdateMultiplier.Value / updateFrequency;
		_speedPerSecond = Mathf.Floor(_speedPerSecond * 60f);
		if (_updateFrequencyLoc == "Factory.UpdateFrequency")
		{
			_frequencyText.SetText(LocalizationUtility.GetLocalizedText(_updateFrequencyLoc).Replace("\\n", "\n"), _speedPerSecond);
		}
		else
		{
			_frequencyText.SetText(string.Format(LocalizationUtility.GetLocalizedText(_updateFrequencyLoc), _speedPerSecond, "FrequencyUnit"));
		}
		_frequencyText.gameObject.SetActive(value: true);
	}

	public void Populate(int updateFrequency)
	{
		Populate((float)updateFrequency);
	}
}
