using UnityEngine;

namespace TEST
{
	public class FrameRateSetter : MonoBehaviour
	{
		[SerializeField]
		private bool m_activated;

		[SerializeField]
		private int m_frameRate;

		private void Awake()
		{
		}
	}
}
