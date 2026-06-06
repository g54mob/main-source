using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Extensions
{
	public static class GizmoExtensions
	{
		public static void DrawPolygon(IEnumerable<Vector2> vertices, Color color)
		{
			IEnumerator<Vector2> enumerator = vertices.GetEnumerator();
			if (enumerator.MoveNext())
			{
				Vector3 vector = enumerator.Current.Vector3TopDown();
				Vector3 vector2 = vector;
				_ = Vector3.zero;
				Gizmos.color = color;
				while (enumerator.MoveNext())
				{
					Vector3 vector3 = vector;
					vector = enumerator.Current.Vector3TopDown();
					Gizmos.DrawLine(vector3, vector);
				}
				if (!(vector == vector2))
				{
					Gizmos.DrawLine(vector, vector2);
				}
			}
		}
	}
}
