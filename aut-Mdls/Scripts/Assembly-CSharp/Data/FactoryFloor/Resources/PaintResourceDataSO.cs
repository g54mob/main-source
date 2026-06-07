using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[CreateAssetMenu(menuName = "Factory/Resources/PaintResourceDataSO", fileName = "PaintResourceDataSO", order = 2)]
	public class PaintResourceDataSO : NonShapeResourceDataSO
	{
		[field: SerializeField]
		public Color Color { get; protected set; }
	}
}
