using UnityEngine;

namespace Simulator.GameWorld
{
	public class CashAmount : MonoBehaviour
	{
		[SerializeField]
		private ECashAmount m_amount;

		public ECashAmount Get()
		{
			return m_amount;
		}
	}
}
