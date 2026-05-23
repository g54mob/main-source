using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Barmetler.RoadSystem.Util
{
	[ExecuteAlways]
	[RequireComponent(typeof(LineRenderer))]
	public class NavigationLineUpdater : MonoBehaviour
	{
		[SerializeField]
		private RoadSystemNavigator navigator;

		[SerializeField]
		private float Tolerance = 0.1f;

		[SerializeField]
		private float LineWidth = 2f;

		[SerializeField]
		[HideInInspector]
		private LineRenderer lineRenderer;

		private AsyncUpdater<Vector3[]> _pathPoints;

		private void OnValidate()
		{
			lineRenderer = GetComponent<LineRenderer>();
		}

		private void Awake()
		{
			OnValidate();
		}

		private void Update()
		{
			if (_pathPoints == null)
			{
				_pathPoints = new AsyncUpdater<Vector3[]>(this, UpdateData, new Vector3[0], 1f / 144f);
			}
			_pathPoints.Update();
			Vector3[] data = _pathPoints.GetData();
			lineRenderer.positionCount = data.Length;
			lineRenderer.SetPositions(data);
			lineRenderer.widthMultiplier = LineWidth;
		}

		private Vector3[] UpdateData()
		{
			if (!navigator)
			{
				return new Vector3[0];
			}
			List<Vector3> list = navigator.CurrentPoints.Select((Bezier.OrientedPoint e) => e.position).ToList();
			LineUtility.Simplify(list.ToList(), Tolerance, list);
			return list.Select((Vector3 e) => Vector3.Scale(e, Vector3.forward + Vector3.right) + Vector3.up * 100f).ToArray();
		}
	}
}
