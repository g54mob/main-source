using System;
using Dhs5.Utility.Databases;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class GrabbableData : BaseDataContainerScriptableElement
	{
		[Serializable]
		public struct Anchor
		{
			[SerializeField]
			private Vector3 m_localPosition;

			[SerializeField]
			private Vector3 m_locationRotation;

			public Vector3 LocalPosition => m_localPosition;

			public Vector3 LocationRotationEuler => m_locationRotation;

			public Quaternion LocalRotation => Quaternion.Euler(m_locationRotation);
		}

		[field: SerializeField]
		public Anchor GrabAnchor { get; private set; }
	}
}
