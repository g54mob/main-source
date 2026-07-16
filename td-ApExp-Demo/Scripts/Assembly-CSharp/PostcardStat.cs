using TMPro;
using UnityEngine;

public class PostcardStat : MonoBehaviour
{
	[Header("UI Elements")]
	[SerializeField]
	protected TextMeshProUGUI _statNameTxt;

	[SerializeField]
	protected TextMeshProUGUI _statValueTxt;

	[Header("Other")]
	[SerializeField]
	protected Animator valueAnim;

	protected string _measureUnit;

	protected float _finalValue;

	protected float _currentValue;

	protected float _timer;

	protected bool setStatValue;

	public void SetupStat(string name, float value, string unitOfMeasurement = "")
	{
		_statNameTxt.text = name + ":";
		_measureUnit = unitOfMeasurement;
		_statValueTxt.text = value + _measureUnit;
	}

	public void DisplayValue()
	{
		if ((bool)valueAnim)
		{
			valueAnim.Play("PostcardStatAppear");
		}
	}
}
