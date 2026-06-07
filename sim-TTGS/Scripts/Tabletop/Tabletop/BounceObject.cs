using UnityEngine;

namespace Tabletop
{
	public class BounceObject : MonoBehaviour
	{
		[SerializeField]
		private BounceData m_bounce = new BounceData(0.2f, 0.2f);

		public void BounceTest()
		{
			m_bounce.PlayBounceCall(base.transform);
		}

		public void GetManagerCurve()
		{
			m_bounce.GetManagerCurve();
		}
	}
}
