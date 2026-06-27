using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tooltips
{
	public abstract class TooltipActivatorBase : MonoBehaviour
	{
		[SerializeField]
		private GUI_CommonTooltip tooltipPrefab;

		[SerializeField]
		private Transform targetPoint;

		public GUI_CommonTooltip TooltipPrefab => tooltipPrefab;

		public Transform TargetPoint => targetPoint;
	}
}
