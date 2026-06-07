using EasyRoads3Dv3;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class RoadDebugScript : MonoBehaviour
	{
		[SerializeField]
		private Vector3[] _connectorPositions;

		[SerializeField]
		private int _selectedConnectionId;

		protected void OnDrawGizmosSelected()
		{
			if (TryGetComponent<ERCrossingPrefabs>(out var component))
			{
				if (_connectorPositions == null)
				{
					_connectorPositions = new Vector3[component.crossingElements.Count];
				}
				for (int i = 0; i < component.crossingElements.Count; i++)
				{
					Gizmos.color = ((_selectedConnectionId == i) ? Color.blue : Color.white);
					Gizmos.DrawSphere(base.transform.TransformPoint(component.crossingElements[i].centerPoint), 1f);
					_connectorPositions[i] = component.crossingElements[i].centerPoint;
				}
			}
		}
	}
}
