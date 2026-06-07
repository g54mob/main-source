using System;
using UnityEngine;

namespace Gh.Tk
{
	public class LineRendererAdjustTimeOfDayOnWorldmap : MonoBehaviour
	{
		[SerializeField]
		private LineRenderer _lineRenderer;

		public Gradient dayTimeGradient;

		private void Start()
		{
		}

		private void ActiveMapChanged(object sender, EventArgs e)
		{
		}

		private void VisualDayFChanged(object sender, EventArgs e)
		{
		}

		private void Invalidate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
