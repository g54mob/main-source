using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public abstract class GenericConnectionPool<T> : MonoBehaviour where T : ConnectionCurveBase
	{
		[SerializeField]
		private List<T> connectionCurves;

		public void AddConnection(T connectionCurve)
		{
		}

		public void RemoveConnection(T connectionCurve)
		{
		}

		public bool ContainsConnection(T connectionCurve)
		{
			return false;
		}

		public List<T> GetAllConnections()
		{
			return null;
		}

		public void VerifyAssignments()
		{
		}
	}
}
