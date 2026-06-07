using ManagementScripts;
using ScriptHelpers;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using SteamIntegrations;
using UnityEngine;

namespace UIScripts
{
	public class UserActions : MonoBehaviour
	{
		public bool triggeredThanos;

		public void KillHalfBibitesPressed()
		{
			PopupManager.DisplayChoiceDialog("Killing half the population", "You're about to kill half of all bibites (each bibites will have a 50% chance of being killed, results may vary). \n\rAre you sure???", "Cancel", "YES", null, KillHalfBibites);
		}

		public void RemoveHalfPelletsPressed()
		{
			PopupManager.DisplayChoiceDialog("Removing half of all pellets", "You're about to remove half of all pellets (each pellet will have a 50% chance of being removed, results may vary). Depending on your numbers of pellets the screen might freeze a little while doing so. \n\rAre you sure???", "Cancel", "YES", null, RemoveHalfPellets);
		}

		private void KillHalfBibites()
		{
			WorldObjectsSpawner.Instance.bibiteHolder.GetAllChilds().ForEach(delegate(GameObject b)
			{
				if (!(Random.value >= 0.5f))
				{
					BibiteBody component = b.GetComponent<BibiteBody>();
					if (component != null)
					{
						component.Die();
					}
					else
					{
						b.GetComponent<EggHatching>().Abort();
					}
				}
			});
			if (!triggeredThanos)
			{
				triggeredThanos = true;
				AchievementManager.Trigger("ACH_USER_SNAP");
			}
		}

		private void RemoveHalfPellets()
		{
			WorldObjectsSpawner.Instance.allPellets.ForEach(delegate(MatterPellet p)
			{
				if (Random.value >= 0.5f)
				{
					p.RemovePellet();
				}
			});
			ZoneManager.instance.RefreshPelletBiomassCounter();
		}
	}
}
