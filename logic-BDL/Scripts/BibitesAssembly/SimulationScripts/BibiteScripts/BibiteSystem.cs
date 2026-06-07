using Newtonsoft.Json.Linq;
using ScriptHelpers;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public abstract class BibiteSystem : ISaveable
	{
		public GameObject bibite;

		public float activityPeriod;

		public float activityProgress;

		public abstract void StartSystem();

		public abstract void ResumeSystem();

		private void Update()
		{
			if (!(Time.deltaTime <= 0f))
			{
				if (activityPeriod < activityProgress)
				{
					activityPeriod += Time.deltaTime;
					return;
				}
				activityPeriod -= activityProgress;
				SystemActivity();
			}
		}

		public abstract void SystemActivity();

		public abstract JObject SaveState();

		public abstract void LoadState(JObject state);
	}
}
