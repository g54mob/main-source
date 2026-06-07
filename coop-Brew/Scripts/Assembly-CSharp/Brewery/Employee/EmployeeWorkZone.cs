using UnityEngine;

namespace Brewery.Employee
{
	public class EmployeeWorkZone : MonoBehaviour
	{
		[Header("Visualization")]
		[SerializeField]
		private Color gizmoColor;

		[SerializeField]
		private float gizmoRadius;

		[SerializeField]
		private float arrowLength;

		[SerializeField]
		private float arrowHeadSize;

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void DrawArrow(Vector3 position, Vector3 direction, Color color, float length, float headSize)
		{
		}
	}
}
