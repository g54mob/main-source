using UnityEngine;
using UnityEngine.UI;

public class BreederSlotRow : MonoBehaviour
{
	public byte startSlot;

	public InputField dutyCycleOn;

	public InputField dutyCycleOff;

	public InputField min;

	public InputField max;

	public InputField rate;

	public InputField minAC;

	public InputField maxAC;

	public InputField rateAC;

	public Text slotText;

	private World.BreederStruct breederStruct;

	private byte _slot;

	public byte slot
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void Refresh()
	{
	}

	public void Apply()
	{
	}
}
