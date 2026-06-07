using TMPro;
using UnityEngine;

public class EggMeter : MonoBehaviour
{
	public TextMeshProUGUI lowerText;

	public TextMeshProUGUI upperText;

	public TextMeshProUGUI currentText;

	public RectTransform currentPointer;

	public GameObject lower;

	public GameObject upper;

	private float lastLower;

	private float lastUpper;

	private float lastCurrent;

	private bool _lowerLit;

	private bool _upperLit;

	private bool lowerLit
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool upperLit
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void LateUpdate()
	{
	}

	private void Refresh()
	{
	}

	private void SetPointerPosition()
	{
	}
}
