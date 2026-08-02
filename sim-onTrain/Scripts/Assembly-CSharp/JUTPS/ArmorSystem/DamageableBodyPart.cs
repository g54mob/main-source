using UnityEngine;

namespace JUTPS.ArmorSystem
{
	[AddComponentMenu("JU TPS/Armor System/Damageable Body Part")]
	public class DamageableBodyPart : MonoBehaviour
	{
		public JUHealth Health;

		public float DamageMultiplier = 1f;

		[HideInInspector]
		public Armor ArmorProtecting;

		private void Start()
		{
			if (Health == null)
			{
				Health = GetComponentInParent<JUHealth>();
			}
		}

		public float DoDamage(float Damage)
		{
			if (Health == null)
			{
				Debug.LogWarning("Could not do damage as the Health variable is null");
				return 0f;
			}
			Health.DoDamage(DamageMultiplier * Damage);
			if (ArmorProtecting != null)
			{
				ArmorProtecting.DoDamageOnArmor(Damage);
			}
			return DamageMultiplier * Damage;
		}
	}
}
