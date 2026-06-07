using System.Collections.Generic;
using UnityEngine;

namespace DV.Spline
{
	public class Catmul : MonoBehaviour
	{
		public GameObject[] points;

		private List<Vector2> newPoints = new List<Vector2>();

		private float amountOfPoints = 10f;

		public float alpha = 0.5f;

		private void Update()
		{
			CatmulRom();
		}

		private void CatmulRom()
		{
			newPoints.Clear();
			Vector2 vector = new Vector2(points[0].transform.position.x, points[0].transform.position.y);
			Vector2 vector2 = new Vector2(points[1].transform.position.x, points[1].transform.position.y);
			Vector2 vector3 = new Vector2(points[2].transform.position.x, points[2].transform.position.y);
			Vector2 vector4 = new Vector2(points[3].transform.position.x, points[3].transform.position.y);
			float num = 0f;
			float t = GetT(num, vector, vector2);
			float t2 = GetT(t, vector2, vector3);
			float t3 = GetT(t2, vector3, vector4);
			for (float num2 = t; num2 < t2; num2 += (t2 - t) / amountOfPoints)
			{
				Vector2 vector5 = (t - num2) / (t - num) * vector + (num2 - num) / (t - num) * vector2;
				Vector2 vector6 = (t2 - num2) / (t2 - t) * vector2 + (num2 - t) / (t2 - t) * vector3;
				Vector2 vector7 = (t3 - num2) / (t3 - t2) * vector3 + (num2 - t2) / (t3 - t2) * vector4;
				Vector2 vector8 = (t2 - num2) / (t2 - num) * vector5 + (num2 - num) / (t2 - num) * vector6;
				Vector2 vector9 = (t3 - num2) / (t3 - t) * vector6 + (num2 - t) / (t3 - t) * vector7;
				Vector2 item = (t2 - num2) / (t2 - t) * vector8 + (num2 - t) / (t2 - t) * vector9;
				newPoints.Add(item);
			}
		}

		private float GetT(float t, Vector2 p0, Vector2 p1)
		{
			return Mathf.Pow(Mathf.Pow(Mathf.Pow(p1.x - p0.x, 2f) + Mathf.Pow(p1.y - p0.y, 2f), 0.5f), alpha) + t;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			foreach (Vector2 newPoint in newPoints)
			{
				Gizmos.DrawSphere(new Vector3(newPoint.x, newPoint.y, 0f), 0.3f);
			}
		}
	}
}
