using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTimed : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI objectiveText;

	[SerializeField]
	private TextMeshProUGUI objectiveTime;

	[SerializeField]
	private Image customerLogo;

	[SerializeField]
	private Image appLogo;

	[SerializeField]
	private TextMeshProUGUI textIops;

	private int maxTime;

	private int requiredIOPS;

	public void SetupObjectiveTimed(int _maxTime, string _objectiveText, int customerID, int appID, int _requiredIOPS)
	{
	}

	public void UpdateDisplay(int currentIOPS, int remainingTime)
	{
	}
}
