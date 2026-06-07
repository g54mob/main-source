using System;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class WorldmapTimeOfDayAndZoomLevelAdjustmentBase : MonoBehaviour
	{
		public AnimationCurve dayTimeCurve;

		[Tooltip("0 is zoomed in, 1 is zoomed out")]
		public AnimationCurve zoomLevelCurve;

		private bool _isDirty;

		private void Start()
		{
		}

		private void ActiveCameraChanged(object sender, EventArgs e)
		{
		}

		private void VisualDayFChanged(object sender, EventArgs e)
		{
		}

		protected virtual void OnStart()
		{
		}

		private void OnDestroy()
		{
		}

		private void ZoomChanged(object sender, EventArgs e)
		{
		}

		private void MarkAsDirty()
		{
		}

		private void LateUpdate()
		{
		}

		protected abstract void Recalculate();
	}
}
