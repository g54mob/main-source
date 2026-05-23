using TMPro;
using UnityEngine;

public class CableSpinner : UsableObject
{
	[SerializeField]
	private float cableLenght;

	private float cableLenghtInUse;

	[SerializeField]
	private TextMeshProUGUI txtLength;

	[SerializeField]
	private Material cableMaterial;

	public bool isFiberCable;

	private void Start()
	{
	}

	public override void InteractOnClick()
	{
	}

	public void LowerAmountOfCable(float length)
	{
	}

	private void UpdateText()
	{
	}

	public void UpdateCurrentLength(float length)
	{
	}

	public bool IsCableLenghtEnough()
	{
		return false;
	}

	public override void DropObject()
	{
	}
}
