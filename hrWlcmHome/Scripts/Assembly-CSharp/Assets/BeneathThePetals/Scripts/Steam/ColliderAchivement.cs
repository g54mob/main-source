using UnityEngine;

namespace Assets.BeneathThePetals.Scripts.Steam
{
	public class ColliderAchivement : MonoBehaviour
	{
		[SerializeField]
		private AchivementEnums.Achivement achivement;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.name == "Player")
			{
				SteamManager.Instance.UnlockAchievement(achivement.ToString());
				Debug.Log("Unlocking achievement: " + achivement);
			}
		}
	}
}
