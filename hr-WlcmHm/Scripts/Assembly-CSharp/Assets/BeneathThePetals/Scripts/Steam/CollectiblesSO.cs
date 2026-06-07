using System.Collections.Generic;
using UnityEngine;

namespace Assets.BeneathThePetals.Scripts.Steam
{
	[CreateAssetMenu(fileName = "CollectiblesSO", menuName = "Scriptable Objects/CollectiblesSO")]
	public class CollectiblesSO : ScriptableObject
	{
		public int goal;

		public AchivementEnums.Achivement achivement;

		public HashSet<string> collectibles = new HashSet<string>();

		public void CompleteAchievement()
		{
			SteamManager.Instance.UnlockAchievement(achivement.ToString());
			Debug.Log("Achived: " + achivement);
		}
	}
}
