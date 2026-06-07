using UnityEngine;

public class PiggyBankHandler : MonoBehaviour
{
	[SerializeField]
	private GameObject vacuumTrigger;

	private void Update()
	{
		if (PlayerStats.Singleton.piggyBank_CurrentlyStored < PlayerStats.Singleton.piggyBank_Limit || PlayerStats.Singleton.piggyBank_Limit == -1)
		{
			if (!vacuumTrigger.activeSelf)
			{
				vacuumTrigger.SetActive(value: true);
			}
		}
		else if (vacuumTrigger.activeSelf)
		{
			vacuumTrigger.SetActive(value: false);
		}
	}
}
