using InventorySystem;
using UnityEngine;

namespace Brewery.CombatSystem
{
	[CreateAssetMenu(fileName = "New Weapon", menuName = "Combat/Weapon", order = 100)]
	public class WeaponItem : Item
	{
		[Header("Combat Animations")]
		[Tooltip("2-attack loop animation clips (Attack 1, Attack 2)")]
		public AnimationClip[] comboClips;

		[Tooltip("Block loop animation")]
		public AnimationClip blockClip;

		[Tooltip("Hit reaction animations (front, back, etc.)")]
		public AnimationClip[] hitReactions;

		[Tooltip("Animation to enter combat idle stance")]
		public AnimationClip combatIdleEnter;

		[Tooltip("Animation to exit combat idle and return to normal")]
		public AnimationClip combatIdleExit;

		[Header("Hit Window Timing")]
		[Tooltip("Normalized time (0-1) when hit detection starts for each attack")]
		[Range(0f, 1f)]
		public float[] hitStartPercent;

		[Tooltip("Normalized time (0-1) when hit detection ends for each attack")]
		[Range(0f, 1f)]
		public float[] hitEndPercent;

		[Header("Combat Stats")]
		[Tooltip("Base damage per hit")]
		public int damage;

		[Tooltip("Knockback force applied on hit")]
		public float knockback;

		[Tooltip("Stamina cost per attack")]
		public float staminaCost;

		[Tooltip("Radius for hit detection sphere cast")]
		[Range(0.5f, 3f)]
		public float hitRadius;

		[Header("Visual & Audio")]
		[Tooltip("Prefab to spawn in player's right hand when equipped")]
		public GameObject handPrefab;

		[Tooltip("Whoosh sounds played during swing")]
		public AudioClip[] whooshSounds;

		[Tooltip("Impact sounds played on successful hit")]
		public AudioClip[] hitSounds;

		[Tooltip("VFX trail effect prefab attached to weapon")]
		public GameObject trailEffectPrefab;

		[Tooltip("VFX played on successful hit")]
		public GameObject hitEffectPrefab;

		[Header("Combat Behavior")]
		[Tooltip("Can this weapon block attacks?")]
		public bool canBlock;

		[Tooltip("Damage reduction when blocking (0.5 = 50% damage blocked)")]
		[Range(0f, 1f)]
		public float blockDamageReduction;

		[Tooltip("Movement speed multiplier while blocking (0.5 = 50% slower)")]
		[Range(0.1f, 1f)]
		public float blockMovementSpeed;

		[Tooltip("Stamina cost per blocked hit")]
		[Range(10f, 50f)]
		public float blockStaminaCost;

		[Tooltip("Front arc in degrees that can block attacks (120 = 60° left + 60° right)")]
		[Range(60f, 180f)]
		public float blockArc;

		[Header("Parry System")]
		[Tooltip("Perfect block window in seconds (block within this time before hit = parry)")]
		[Range(0.1f, 0.5f)]
		public float perfectBlockWindow;

		[Tooltip("Poise damage dealt to attacker on perfect block (uses enemy's stagger system)")]
		public float perfectBlockPoiseDamage;

		public override ItemCarryType GetCarryType()
		{
			return default(ItemCarryType);
		}

		private void OnValidate()
		{
		}

		public (float, float) GetHitWindow(int comboStep)
		{
			return default((float, float));
		}

		public AudioClip GetRandomWhoosh()
		{
			return null;
		}

		public AudioClip GetRandomHitSound()
		{
			return null;
		}

		public AnimationClip GetRandomHitReaction()
		{
			return null;
		}
	}
}
