using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/leaderboard-ui-list")]
	public class LeaderboardUIList : MonoBehaviour
	{
		public Transform collection;

		public GameObject template;

		[Header("Events")]
		public UnityEvent Enabled;

		private List<GameObject> createdRecords = new List<GameObject>();

		private void OnEnable()
		{
			Enabled.Invoke();
		}

		public void Display(LeaderboardEntry[] entries)
		{
			foreach (GameObject createdRecord in createdRecords)
			{
				Object.Destroy(createdRecord);
			}
			createdRecords.Clear();
			foreach (LeaderboardEntry entry in entries)
			{
				GameObject gameObject = Object.Instantiate(template, collection);
				createdRecords.Add(gameObject);
				ILeaderboardEntryDisplay component = gameObject.GetComponent<ILeaderboardEntryDisplay>();
				if (component != null)
				{
					component.Entry = entry;
				}
			}
		}
	}
}
