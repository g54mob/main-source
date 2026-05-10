using UnityEngine;

namespace CTS.BBT.TechTree
{
	[CreateAssetMenu(fileName = "New Resell Points Settings", menuName = "CTS/Tech Tree/New Resell Points Settings", order = 2)]
	public class TechTreePointsConverterSO : ScriptableObject
	{
		[SerializeField]
		[Range(1f, 100f)]
		public int PointsAmountToExchange;

		[SerializeField]
		[Range(1f, 50000f)]
		public int MoneyAmountToReceive;
	}
}
