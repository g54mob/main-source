using UnityEngine;

namespace Kitchen
{
	public class InterpolateSplittableView : SplittableItemView
	{
		[Header("Configuration")]
		[SerializeField]
		private Transform EmptyPosition;

		[SerializeField]
		private Transform FullPosition;

		[Header("References")]
		[SerializeField]
		private Transform Transform;

		protected override void UpdateData(ViewData data)
		{
			Vector3 localPosition = EmptyPosition.localPosition + (FullPosition.localPosition - EmptyPosition.localPosition) * data.Remaining / data.Total;
			Vector3 localScale = EmptyPosition.localScale + (FullPosition.localScale - EmptyPosition.localScale) * data.Remaining / data.Total;
			Transform.localPosition = localPosition;
			Transform.localScale = localScale;
		}
	}
}
