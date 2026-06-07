using UnityEngine;

namespace DV.TerrainTools
{
	[CreateAssetMenu(menuName = "DV/Connectables Config asset")]
	public class ConnectablesConfig : ScriptableObject
	{
		public ConnectablePrefab[] prefabs;

		public GameObject[] attachments;
	}
}
