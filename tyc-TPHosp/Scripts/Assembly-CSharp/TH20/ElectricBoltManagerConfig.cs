using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Electric Bolt Manager", order = 1113)]
	public class ElectricBoltManagerConfig : ScriptableObjectWithID
	{
		public int Capacity;

		public Material ElectricBoltMaterial;

		public Vector3 DefaultScale = Vector3.one;
	}
}
