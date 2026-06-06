using UnityEngine;

public class LineBehaviour : MonoBehaviour
{
	[SerializeField]
	private Transform _from;

	[SerializeField]
	private Transform _to;

	[SerializeField]
	private LineBehaviour _lineToInterset;

	private void OnDrawGizmos()
	{
		Vector2 vector = _from.position;
		Vector2 vector2 = _to.position;
		Gizmos.color = Color.white;
		Gizmos.DrawLine(vector, vector2);
		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere(vector, 0.05f);
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(vector2, 0.05f);
		if (!(_lineToInterset == null))
		{
			new Polygon2DLine(vector, vector2);
			new Polygon2DLine(_lineToInterset._from.position, _lineToInterset._to.position);
		}
	}
}
