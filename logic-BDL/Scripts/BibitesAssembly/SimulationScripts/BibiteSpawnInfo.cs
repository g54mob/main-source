using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using Utility;

namespace SimulationScripts
{
	public class BibiteSpawnInfo
	{
		public BibiteSettings settings;

		public BibiteTemplate template;

		public Species species;

		private int descendantCount;

		public bool oneTimeSpawned;

		public float spawnShare;

		public float spawnProgress;

		public Zone zone => settings.spawnZone.zone;

		public int missingToMinimumBibites => settings.minimumNumber.val - lastDescendantCount;

		public int lastDescendantCount => descendantCount;

		public bool oneTimeSpawn => settings.spawnType.val == SpawnType.OneTime;

		public bool minimumMet => lastDescendantCount >= settings.minimumNumber.val;

		public float UpdateDescendantCount()
		{
			return descendantCount = species.GetDescendantCount();
		}

		public BibiteSpawnInfo(BibiteSettings fromSettings)
		{
			settings = fromSettings;
			if (settings.spawnType.val == SpawnType.OneTime)
			{
				spawnProgress = (float)settings.minimumNumber.val + 0.1f;
			}
			template = new BibiteTemplate(settings.filePath, settings.isExternal);
			species = GlobalLineageManager.Instance.FindSpeciesFromTemplate(template, onlyLookUp: true);
		}
	}
}
