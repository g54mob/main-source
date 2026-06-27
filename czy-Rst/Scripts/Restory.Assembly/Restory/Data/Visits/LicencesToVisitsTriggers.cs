using System;
using Mandragora.Utils;
using Restory.Data.Licenses;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Data.Visits
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/Triggers/VisitsFromLicenses", fileName = "LicencesToVisitsTriggers")]
	public class LicencesToVisitsTriggers : ScriptableObject
	{
		[Serializable]
		private class Entry
		{
			public LicenseInfo License;

			public StoryNpcInfo NpcToVisit;

			public int GameMinutesBeforeVisit;

			[BoolButton(25, 0, Red = false)]
			public bool SetMandatoryDelayAfterVisit;

			public int GameMinutesDelayAfterVisit;
		}

		[SerializeField]
		private Entry[] npcVisitsToTriggerWhenLicensesAreAdded = new Entry[0];

		public bool TryToGetNpcToVisitForAddedLicense(LicenseInfo license, out StoryNpcInfo npcToVisit, out TimeSpan delayBeforeVisit, out TimeSpan? delayAfterVisit)
		{
			Entry[] array = npcVisitsToTriggerWhenLicensesAreAdded;
			foreach (Entry entry in array)
			{
				if (entry != null && entry.License.ID == license.ID)
				{
					npcToVisit = entry.NpcToVisit;
					delayBeforeVisit = TimeSpan.FromMinutes(entry.GameMinutesBeforeVisit);
					delayAfterVisit = (entry.SetMandatoryDelayAfterVisit ? new TimeSpan?(TimeSpan.FromMinutes(entry.GameMinutesDelayAfterVisit)) : ((TimeSpan?)null));
					return true;
				}
			}
			npcToVisit = null;
			delayBeforeVisit = TimeSpan.Zero;
			delayAfterVisit = null;
			return false;
		}
	}
}
