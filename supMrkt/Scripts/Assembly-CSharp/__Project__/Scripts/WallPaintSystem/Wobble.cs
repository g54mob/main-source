using UnityEngine;

namespace __Project__.Scripts.WallPaintSystem
{
	public class Wobble : MonoBehaviour
	{
		private Renderer m_Rend;

		private Vector3 m_LastPos;

		private Vector3 m_Velocity;

		private Vector3 m_LastRot;

		private Vector3 m_AngularVelocity;

		public float maxWobble;

		public float wobbleSpeed;

		public float recovery;

		private float m_WobbleAmountX;

		private float m_WobbleAmountZ;

		private float m_WobbleAmountToAddX;

		private float m_WobbleAmountToAddZ;

		private float m_Pulse;

		private float m_Time;

		private float m_DeltaTime;

		private void Start()
		{
		}

		public void ManualUpdate()
		{
		}
	}
}
