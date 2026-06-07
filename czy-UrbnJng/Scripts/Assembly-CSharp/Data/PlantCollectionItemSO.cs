using UnityEngine;

namespace Data
{
	[CreateAssetMenu]
	public class PlantCollectionItemSO : ScriptableObject
	{
		public int ID;

		public string Description;

		public ObjectSO objectSo;
	}
}
