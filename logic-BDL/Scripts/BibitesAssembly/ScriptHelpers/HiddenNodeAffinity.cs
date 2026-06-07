using UnityEngine;

namespace ScriptHelpers
{
	public class HiddenNodeAffinity
	{
		public float affinity;

		public float closeness;

		public int n = 1;

		public HiddenNodeAffinity(float affinity, float closeness)
		{
			this.affinity = affinity;
			this.closeness = closeness;
		}

		public void AddAffinity(float affinityToAdd, float newCloseness)
		{
			affinity = ((float)n * affinity + affinityToAdd) / (float)(n + 1);
			closeness = Mathf.Min(closeness, newCloseness);
			n++;
		}
	}
}
