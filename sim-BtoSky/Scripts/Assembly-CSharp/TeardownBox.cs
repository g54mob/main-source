using System;
using UnityEngine;

public class TeardownBox : MonoBehaviour
{
	public GameObject pcb;

	public GameObject chip;

	public static event Action OnPcbInBox;

	public static event Action OnPcbNotInBox;

	public static event Action OnChipInBox;

	public static event Action OnChipNotInBox;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (pcb != null && other.gameObject == pcb)
		{
			TeardownBox.OnPcbInBox?.Invoke();
		}
		if (chip != null && other.gameObject == chip)
		{
			TeardownBox.OnChipInBox?.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (pcb != null && other.gameObject == pcb)
		{
			TeardownBox.OnPcbNotInBox?.Invoke();
		}
		if (chip != null && other.gameObject == chip)
		{
			TeardownBox.OnChipNotInBox?.Invoke();
		}
	}
}
