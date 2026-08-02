using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class RecoilForce
	{
		[Serializable]
		public struct ForceJitter
		{
			[Range(0f, 1f)]
			public float xJitter;

			[Range(0f, 1f)]
			public float yJitter;

			[Range(0f, 1f)]
			public float zJitter;
		}

		[SerializeField]
		private Vector3 m_RotForce;

		[SerializeField]
		private Vector3 m_PosForce;

		[Range(0f, 20f)]
		public int Distribution;

		[Space]
		[Tooltip("max randomness for each axis")]
		[Group]
		public ForceJitter JitterForce;

		public Vector3 RotationForce => Vector3Utils.JitterVector(m_RotForce, JitterForce.xJitter, JitterForce.yJitter, JitterForce.zJitter);

		public Vector3 PositionForce => Vector3Utils.JitterVector(m_PosForce, JitterForce.xJitter, JitterForce.yJitter, JitterForce.zJitter) / 100f;
	}
}
