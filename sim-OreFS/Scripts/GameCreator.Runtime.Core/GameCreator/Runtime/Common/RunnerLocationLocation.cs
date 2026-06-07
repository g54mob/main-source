using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct RunnerLocationLocation : IRunnerLocation
	{
		[SerializeField]
		private Vector3 m_Position;

		[SerializeField]
		private Quaternion m_Rotation;

		Vector3 IRunnerLocation.Position => m_Position;

		Quaternion IRunnerLocation.Rotation => m_Rotation;

		Transform IRunnerLocation.Parent => null;

		public RunnerLocationLocation(Vector3 position, Quaternion rotation)
		{
			m_Position = position;
			m_Rotation = rotation;
		}
	}
}
