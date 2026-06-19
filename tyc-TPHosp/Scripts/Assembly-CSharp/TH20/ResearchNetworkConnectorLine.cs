using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ResearchNetworkConnectorLine : ResearchNetworkConnector
	{
		[SerializeField]
		private UILineRenderer _lineRenderer;

		private readonly List<Vector2> _pointsList = new List<Vector2>();

		public override void Setup(Vector3 startPosition, Vector3 endPosition)
		{
			base.Setup(startPosition, endPosition);
			_pointsList.Clear();
			_pointsList.Add(startPosition);
			_pointsList.Add(endPosition);
			_lineRenderer.Points = _pointsList.ToArray();
			_lineRenderer.SetAllDirty();
		}

		public void SetColor(Color color)
		{
			_lineRenderer.color = color;
		}
	}
}
