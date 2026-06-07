using TMPro;
using UnityEngine;

public class PlayerLogPanelRow : MonoBehaviour
{
	public TextMeshProUGUI playerNameT;

	public TextMeshProUGUI timeT;

	public TextMeshProUGUI ecoT;

	public TextMeshProUGUI unitsBuiltT;

	public TextMeshProUGUI unitsLostT;

	public void Init(string playerName, int time, int eco, int unitsBuilt, int unitsLost)
	{
	}

	public static string GetFracString(long val)
	{
		return null;
	}

	public static string GetFracStringN(double val, int dec = 3)
	{
		return null;
	}
}
