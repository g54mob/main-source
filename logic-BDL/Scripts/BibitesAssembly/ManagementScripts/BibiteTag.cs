using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;

namespace ManagementScripts
{
	public class BibiteTag
	{
		public bool isInherited = true;

		public string tag;

		public List<BibiteBody> bibites = new List<BibiteBody>();

		public List<EggHatching> eggs = new List<EggHatching>();

		public int count => bibites.Count + eggs.Count;

		public float energy => bibites.Sum((BibiteBody b) => b.totalEnergy) + eggs.Sum((EggHatching e) => (!e.aborting) ? e.energy : 0f);

		public BibiteTag(string val)
		{
			tag = val;
		}

		public void AddToTag(BibiteBody bibite)
		{
			if (!bibites.Contains(bibite))
			{
				bibites.Add(bibite);
			}
		}

		public void AddToTag(EggHatching bibite)
		{
			if (!eggs.Contains(bibite))
			{
				eggs.Add(bibite);
			}
		}

		public void RemoveFromTag(BibiteBody bibite)
		{
			bibites.Remove(bibite);
		}

		public void RemoveFromTag(EggHatching bibite)
		{
			eggs.Remove(bibite);
		}
	}
}
