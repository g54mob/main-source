using UnityEngine;

namespace Simulator.GameWorld
{
	public class GroundTypeHolder : MonoBehaviour
	{
		[SerializeField]
		private EGroundType m_type;

		public EGroundType Get()
		{
			return m_type;
		}
	}
}
