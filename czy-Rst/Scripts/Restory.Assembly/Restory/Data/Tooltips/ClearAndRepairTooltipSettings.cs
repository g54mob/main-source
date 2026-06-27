using DG.Tweening;
using UnityEngine;

namespace Restory.Data.Tooltips
{
	[CreateAssetMenu(menuName = "Restory/Tooltips/ClearAndRepairTooltipSettings", fileName = "ClearAndRepairTooltipSettings")]
	public class ClearAndRepairTooltipSettings : ScriptableObject
	{
		[SerializeField]
		private float projectionHoldDuration = 1f;

		[SerializeField]
		private float markerFadeInDuration = 0.2f;

		[SerializeField]
		private float markerHoldDuration = 0.6f;

		[SerializeField]
		private float markerFadeOutDuration = 0.2f;

		[SerializeField]
		private Ease markerFadeInEase = Ease.OutQuad;

		[SerializeField]
		private Ease markerFadeOutEase = Ease.InQuad;

		public float ProjectionHoldDuration => projectionHoldDuration;

		public float MarkerFadeInDuration => markerFadeInDuration;

		public float MarkerHoldDuration => markerHoldDuration;

		public float MarkerFadeOutDuration => markerFadeOutDuration;

		public Ease MarkerFadeInEase => markerFadeInEase;

		public Ease MarkerFadeOutEase => markerFadeOutEase;
	}
}
