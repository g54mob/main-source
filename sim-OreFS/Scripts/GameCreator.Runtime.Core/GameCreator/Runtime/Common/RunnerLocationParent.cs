using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct RunnerLocationParent : IRunnerLocation
	{
		[SerializeField]
		private Vector3 m_Position;

		[SerializeField]
		private Quaternion m_Rotation;

		[SerializeField]
		private Transform m_Parent;

		Vector3 IRunnerLocation.Position => m_Position;

		Quaternion IRunnerLocation.Rotation => m_Rotation;

		Transform IRunnerLocation.Parent => m_Parent;

		public RunnerLocationParent(Transform parent)
		{
			m_Position = Vector3.zero;
			m_Rotation = Quaternion.identity;
			m_Parent = parent;
		}

		public RunnerLocationParent(Vector3 position, Quaternion rotation, Transform parent)
		{
			m_Position = position;
			m_Rotation = rotation;
			m_Parent = parent;
		}
	}
}
