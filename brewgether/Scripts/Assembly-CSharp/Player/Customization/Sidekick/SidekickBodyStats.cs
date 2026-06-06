using UnityEngine;

namespace Player.Customization.Sidekick
{
	public class SidekickBodyStats : MonoBehaviour
	{
		[Header("Health from Body Size")]
		[Tooltip("Health at maximum skinny (-100 body size)")]
		[SerializeField]
		private float minHealth;

		[Tooltip("Health at maximum fat (+100 body size)")]
		[SerializeField]
		private float maxHealth;

		[Header("Stamina from Body Size")]
		[Tooltip("Stamina at maximum fat (+100 body size)")]
		[SerializeField]
		private float minStamina;

		[Tooltip("Stamina at maximum skinny (-100 body size)")]
		[SerializeField]
		private float maxStamina;

		[Header("Gender Modifiers")]
		[Tooltip("Health bonus for male characters")]
		[SerializeField]
		private float maleHealthBonus;

		[Tooltip("Stamina bonus for male characters (negative = penalty)")]
		[SerializeField]
		private float maleStaminaBonus;

		[Tooltip("Health bonus for female characters (negative = penalty)")]
		[SerializeField]
		private float femaleHealthBonus;

		[Tooltip("Stamina bonus for female characters")]
		[SerializeField]
		private float femaleStaminaBonus;

		[Header("Damage from Weight + Muscles")]
		[Tooltip("Max damage bonus/penalty from body size (0.075 = ±7.5%)")]
		[SerializeField]
		private float maxWeightDamageBonus;

		[Tooltip("Max damage bonus from muscles (0.075 = +7.5%)")]
		[SerializeField]
		private float maxMuscleDamageBonus;

		[Header("Stamina from Muscles (trade-off)")]
		[Tooltip("Stamina bonus at zero muscles (0 = no bonus, 15 = +15 stamina when not muscular)")]
		[SerializeField]
		private float noMuscleStaminaBonus;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public float ComputedMaxHealth { get; private set; }

		public float ComputedMaxStamina { get; private set; }

		public float ComputedDamageMultiplier { get; private set; }

		public void ApplyStats(SidekickSaveData saveData)
		{
		}
	}
}
