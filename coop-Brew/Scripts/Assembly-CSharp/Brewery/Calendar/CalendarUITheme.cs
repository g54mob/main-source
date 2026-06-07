using UnityEngine;

namespace Brewery.Calendar
{
	[CreateAssetMenu(fileName = "CalendarUITheme", menuName = "Brewery/Calendar/UI Theme", order = 12)]
	public class CalendarUITheme : ScriptableObject
	{
		[Header("Row colours")]
		[SerializeField]
		private Color m_PositiveColor;

		[SerializeField]
		private Color m_NegativeColor;

		[SerializeField]
		private Color m_NeutralColor;

		[Header("Access badges")]
		[SerializeField]
		private Color m_ExclusiveAccessBadgeColor;

		[SerializeField]
		private Color m_BlockedAccessBadgeColor;

		[Header("Cards")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_CardTintOpacity;

		[Header("Animation")]
		[Tooltip("Panel open/close transition duration in milliseconds.")]
		[Min(0f)]
		[SerializeField]
		private int m_AnimationDurationMs;

		[Header("Formatting")]
		[Tooltip(".NET format string for multiplier percentages. Default shows +40% / -30% / 0%.")]
		[SerializeField]
		private string m_PercentageFormat;

		[Header("Mini-card (on clock hover)")]
		[Tooltip("How many headline modifiers to show on the clock hover peek.")]
		[Min(1f)]
		[SerializeField]
		private int m_MiniCardHeadlineCount;

		public Color PositiveColor => default(Color);

		public Color NegativeColor => default(Color);

		public Color NeutralColor => default(Color);

		public Color ExclusiveAccessBadgeColor => default(Color);

		public Color BlockedAccessBadgeColor => default(Color);

		public float CardTintOpacity => 0f;

		public int AnimationDurationMs => 0;

		public string PercentageFormat => null;

		public int MiniCardHeadlineCount => 0;
	}
}
