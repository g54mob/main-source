using TMPro;
using UnityEngine;

public class ResultsRow : MonoBehaviour
{
	public TextMeshProUGUI timeT;

	public TextMeshProUGUI ecoT;

	public TextMeshProUGUI unitsBuiltT;

	public TextMeshProUGUI unitsLostT;

	public GameObject unsubmittedIcon;

	public GameObject submittedIcon;

	public void Init(int time, int eco, int unitsBuilt, int unitsLost, bool hasSubmitted)
	{
	}
}
