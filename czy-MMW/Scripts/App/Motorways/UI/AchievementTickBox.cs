using UnityEngine;

namespace Motorways.UI
{
	public class AchievementTickBox : MonoBehaviour
	{
		public GameObject tick;

		public LocalizedTextUI achievementDescription;

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public void SetCompleted(bool completed)
		{
			tick.SetActive(completed);
		}
	}
}
