using UnityEngine;

namespace CTS
{
	public class TutorialEnabler : MonoBehaviour
	{
		public static bool Enabled { get; set; } = true;

		private void Awake()
		{
			if (Enabled)
			{
				GetComponent<QuestChain>().enabled = true;
			}
		}
	}
}
