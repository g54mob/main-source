using UnityEngine;

namespace Cinemachine
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class CinemachineDollyCart : MonoBehaviour
	{
		public enum UpdateMethod
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		public CinemachinePathBase m_Path;

		public UpdateMethod m_UpdateMethod;

		public CinemachinePathBase.PositionUnits m_PositionUnits;

		public float m_Speed;

		public float m_Position;

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void SetCartPosition(float distanceAlongPath)
		{
		}
	}
}
