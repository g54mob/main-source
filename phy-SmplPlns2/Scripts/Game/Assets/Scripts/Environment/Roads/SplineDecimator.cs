using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Assets.Scripts.Environment.Roads
{
	[RequireComponent(typeof(SplineContainer))]
	public class SplineDecimator : MonoBehaviour
	{
		[SerializeField]
		[Header("Decimation Settings")]
		[Tooltip("Minimum distance between points (world units)")]
		private float _minDistance = 0.1f;

		[SerializeField]
		[Tooltip("Angle threshold for colinearity (degrees)")]
		[Range(0f, 180f)]
		private float _colinearAngleThreshold = 5f;

		[SerializeField]
		private SplineContainer _splineContainer;

		public void DecimateSpline()
		{
			if (_splineContainer == null || _splineContainer.Spline == null)
			{
				Debug.LogWarning("SplineContainer or Spline missing");
				return;
			}
			Spline spline = _splineContainer.Spline;
			if (spline.Closed)
			{
				Debug.LogWarning("Closed splines not supported");
				return;
			}
			int count = spline.Count;
			if (count < 3)
			{
				Debug.Log("Not enough points to decimate");
				return;
			}
			List<BezierKnot> list = new List<BezierKnot> { spline[0] };
			BezierKnot bezierKnot = spline[0];
			Vector3 vector = ((Vector3)spline[1].Position - (Vector3)spline[0].Position).normalized;
			float num = 0f;
			for (int i = 1; i < spline.Count - 1; i++)
			{
				Vector3 vector2 = spline[i].Position;
				Vector3 vector3 = spline[i + 1].Position;
				float num2 = Vector3.Distance(bezierKnot.Position, vector2);
				float num3 = Vector3.Distance(vector2, vector3);
				Vector3 normalized = (vector2 - (Vector3)bezierKnot.Position).normalized;
				Vector3 normalized2 = (vector3 - vector2).normalized;
				Vector3 normalized3 = (vector3 - (Vector3)bezierKnot.Position).normalized;
				float num4 = Vector3.Angle(vector, normalized3);
				Vector3.Angle(normalized, normalized2);
				num += num4;
				if (num2 < _minDistance || num3 < _minDistance)
				{
					vector = normalized3;
					continue;
				}
				if (num < _colinearAngleThreshold)
				{
					vector = normalized3;
					continue;
				}
				list.Add(spline[i]);
				bezierKnot = spline[i];
				vector = normalized2;
				num = 0f;
			}
			list.Add(spline[spline.Count - 1]);
			spline.Clear();
			foreach (BezierKnot item in list)
			{
				spline.Add(item);
			}
			Debug.Log($"Decimated: {count} → {list.Count} points");
		}

		[ContextMenu("DecimateEm")]
		protected void DecimateEm()
		{
			_splineContainer = GetComponent<SplineContainer>();
			DecimateSpline();
		}
	}
}
