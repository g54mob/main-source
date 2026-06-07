using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class InletScript : PartModifierScript
	{
		public InletData Inlet { get; set; }

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				Inlet.AirIntakeMultiplier *= Mathf.Max(0f, 1f - Random.value * (float)(level - 1));
				base.PartScript.Body.CalculateIntake();
			}
		}
	}
}
