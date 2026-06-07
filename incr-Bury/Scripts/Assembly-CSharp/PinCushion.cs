using UnityEngine;

public class PinCushion : MonoBehaviour
{
	[SerializeField]
	private int pinInput;

	[SerializeField]
	private GameObject[] pinVisuals;

	[SerializeField]
	private int correctPinAmt;

	private void Start()
	{
		UpdatePinVisuals();
	}

	public void UsePincushion()
	{
		if (Puzzle_RedString.Singleton.canSubmitAnswer && !GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			if (pinInput + 1 > pinVisuals.Length)
			{
				pinInput = 0;
			}
			else
			{
				pinInput++;
			}
			UpdatePinVisuals();
		}
	}

	public void UpdatePinVisuals()
	{
		for (int i = 0; i < pinVisuals.Length; i++)
		{
			pinVisuals[i].SetActive(i < pinInput);
		}
	}

	public void SetPinAmount(int _val)
	{
		pinInput = _val;
		UpdatePinVisuals();
	}

	public bool IsCorrectInput()
	{
		return pinInput == correctPinAmt;
	}
}
