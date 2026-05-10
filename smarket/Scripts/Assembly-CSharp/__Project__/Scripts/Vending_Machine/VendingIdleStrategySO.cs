using UnityEngine;

namespace __Project__.Scripts.Vending_Machine
{
	[CreateAssetMenu(fileName = "VendingIdleStrategy", menuName = "Vending", order = 0)]
	public class VendingIdleStrategySO : ScriptableObject
	{
		public Vector2Int LevelRange;

		public Vector2 IdleCollectionIntervalRange;
	}
}
