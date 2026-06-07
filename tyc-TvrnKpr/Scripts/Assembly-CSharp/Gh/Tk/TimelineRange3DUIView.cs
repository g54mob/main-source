using System;
using UnityEngine;

namespace Gh.Tk
{
	public class TimelineRange3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private Material _noOverlapMat;

		[SerializeField]
		private Material _singleOverlapMat;

		[SerializeField]
		private Material _doubleOverlapMat;

		[SerializeField]
		private Renderer _rangeRenderer;

		public TimelineHelper.TimeRange TimeRange { get; private set; }

		protected override void Start()
		{
		}

		private void OnTooltipChanged(object sender, EventArgs e)
		{
		}

		protected override void OnDestroy()
		{
		}

		public void UpdatePosition(float positionX, float dayPercentage)
		{
		}

		public void UpdateLocalPosition(float positionX, float dayPercentage)
		{
		}

		public override Vector3 GetTooltipPosition()
		{
			return default(Vector3);
		}

		public void Kill()
		{
		}

		public void SetData(TimelineHelper.TimeRange range)
		{
		}
	}
}
