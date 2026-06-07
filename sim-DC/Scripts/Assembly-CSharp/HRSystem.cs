using UnityEngine;
using UnityEngine.UI;

public class HRSystem : MonoBehaviour
{
	[SerializeField]
	private GameObject confirmHireOverlay;

	[SerializeField]
	private GameObject confirmFireOverlay;

	[SerializeField]
	private ButtonExtended buttonReturn;

	[SerializeField]
	private ButtonExtended[] buttonsHireEmployees;

	[SerializeField]
	private ButtonExtended[] buttonsFireEmployees;

	[SerializeField]
	private Transform employeeOneSpawnPoint;

	[SerializeField]
	private int eployeeOneRequiredReputation;

	[SerializeField]
	private Transform employeeTwoSpawnPoint;

	[SerializeField]
	private int employeeTwoRequiredReputation;

	[SerializeField]
	private Transform employeeThreeSpawnPoint;

	[SerializeField]
	private int employeeThreeRequiredReputation;

	private int selectedEmployeeIndex;

	private void OnEnable()
	{
	}

	public void ButtonHireEmployee(int i)
	{
	}

	public void ButtonCancelBuying()
	{
	}

	public void ButtonConfirmHire()
	{
	}

	public void ButtonFireEmployee(int i)
	{
	}

	public void ButtonConfirmFireEmployee()
	{
	}
}
