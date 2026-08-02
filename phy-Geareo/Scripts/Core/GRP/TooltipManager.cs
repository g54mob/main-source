using UnityEngine;

namespace GRP
{
	public class TooltipManager : MonoBehaviour
	{
		public Tooltip tooltip;

		public Transform tooltipCorner;

		public Transform screenCorner;

		public CanvasGroup canvasGroup;

		public Vector2 offset;

		public float appearTime;

		public float disappearTime;

		public float smooth;

		private TooltipArea currentArea;

		private TooltipArea timerArea;

		private float timerTime;

		private float tooltipTime;

		private bool isTooltip;

		private Vector3 targetPosition;

		public static TooltipManager instance { get; private set; }

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		public void SetTooltip(bool value)
		{
		}

		public void RequestArea(TooltipArea area)
		{
		}

		public void CancelArea(TooltipArea area)
		{
		}
	}
}
