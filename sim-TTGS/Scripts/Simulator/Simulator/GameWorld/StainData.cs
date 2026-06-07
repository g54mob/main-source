using UnityEngine;

namespace Simulator.GameWorld
{
	public class StainData : DirtData
	{
		[SerializeField]
		private int m_dirtiness = 10;

		[SerializeField]
		private float m_minDirtiness;

		public int Dirtiness => m_dirtiness;

		public float MinDirtiness => m_minDirtiness;
	}
}
