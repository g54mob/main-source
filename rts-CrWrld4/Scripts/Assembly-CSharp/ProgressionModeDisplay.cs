using TMPro;
using UnityEngine;

public class ProgressionModeDisplay : MonoBehaviour
{
	public TextMeshProUGUI statusText;

	public TextMeshProUGUI maxText;

	public TextMeshProUGUI nullifierFail;

	public GameObject container;

	private int lastTime;

	private int lastMax;

	private int lastNullifierOff;

	public void LateUpdate()
	{
	}
}
