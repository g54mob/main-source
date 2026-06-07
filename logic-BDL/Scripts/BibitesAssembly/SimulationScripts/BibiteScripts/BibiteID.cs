using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteID : MonoBehaviour
	{
		public int id;

		public void CheckGetNew()
		{
			while (id == 0)
			{
				id = Random.Range(int.MinValue, int.MaxValue);
			}
		}

		public void Set(BibiteID from)
		{
			id = from.id;
		}
	}
}
