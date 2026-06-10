using NSEipix.Repository;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class HumanoidImageRepository : MonoRepository<HumanoidImageRepository, KeyGameObjectPair>
	{
		public GameObject GetPrefab(string name)
		{
			KeyGameObjectPair byID = GetByID(name);
			if (byID == null)
			{
				return null;
			}
			return byID.Value;
		}
	}
}
