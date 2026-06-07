using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[CreateAssetMenu(menuName = "Factory/Resources/PolyRockResourceDataSO", fileName = "PolyRockResourceDataSO", order = 2)]
	public class PolyRockResourceDataSO : NonShapeResourceDataSO
	{
		[field: SerializeField]
		public int VoxelValue { get; protected set; }
	}
}
