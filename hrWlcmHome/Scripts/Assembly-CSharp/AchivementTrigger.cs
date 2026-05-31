using Assets.BeneathThePetals.Scripts.Steam;
using UnityEngine;

public class AchivementTrigger : MonoBehaviour
{
	[SerializeField]
	private AchivementEnums.Achivement achivementToUnlock;

	[SerializeField]
	private FirstPersonController player;

	public void OnTriggerEnter(Collider other)
	{
		player.isInTAGSarea = true;
	}

	public void OnTriggerExit(Collider other)
	{
		player.isInTAGSarea = false;
	}
}
