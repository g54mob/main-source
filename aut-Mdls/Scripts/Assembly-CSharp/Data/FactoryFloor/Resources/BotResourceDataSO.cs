using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[CreateAssetMenu(menuName = "Factory/Resources/BotResourceDataSO", fileName = "BotResourceDataSO", order = 2)]
	public class BotResourceDataSO : NonShapeResourceDataSO
	{
		[field: SerializeField]
		public int BotValue { get; protected set; }
	}
}
