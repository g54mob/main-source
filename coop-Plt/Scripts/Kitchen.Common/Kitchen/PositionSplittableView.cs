using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class PositionSplittableView : SplittableItemView
	{
		[SerializeField]
		[Header("Configuration")]
		private Vector3 EmptyPosition;

		[SerializeField]
		private Vector3 FullPosition;

		[Header("References")]
		[SerializeField]
		private List<GameObject> Objects;

		protected override void UpdateData(ViewData data)
		{
			Vector3 localPosition = EmptyPosition + (FullPosition - EmptyPosition) * data.Remaining / data.Total;
			foreach (GameObject @object in Objects)
			{
				@object.transform.localPosition = localPosition;
			}
		}
	}
}
