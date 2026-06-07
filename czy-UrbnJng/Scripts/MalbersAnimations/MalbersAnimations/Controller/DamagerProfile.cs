using System;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public struct DamagerProfile
	{
		public enum DamageProfileModif
		{
			Damage = 1,
			Interact = 2,
			Reaction = 4,
			CriticalChance = 8,
			Force = 0x10,
			ElementalDamage = 0x20,
			MissChance = 0x40
		}

		[Tooltip("Name of the Profile")]
		public string Name;

		[Flag]
		public DamageProfileModif modify;

		[Tooltip("Damager can activate interactables")]
		public BoolReference interact;

		[Tooltip("Interactor ID to enable with who interactable the Interactor can react")]
		public IntReference interactorID;

		[Tooltip("Damager allows the Damagee to apply an animal reaction")]
		public BoolReference react;

		[Tooltip("If true the Damage Receiver will not apply its Default Multiplier")]
		public BoolReference pureDamage;

		[Tooltip("Stat to modify on the Damagee")]
		[ContextMenuItem("Set Default Damage", "Set_DefaultDamage")]
		public StatModifier statModifier;

		[Tooltip("Critical Change (0 - 1)\n1 means it will be always critical")]
		public FloatReference m_cChance;

		[Tooltip("Miss Chance (0 - 1)\n1 means it will always Miss")]
		public FloatReference m_MissChance;

		[Tooltip("If the Damage is critical, the Stat modifier value will be multiplied by the Critical Multiplier")]
		public FloatReference cMultiplier;

		[SerializeField]
		[Tooltip("MAX Force to Apply to RigidBodies when the Damager hit them")]
		public FloatReference maxForce;

		[SerializeField]
		[Tooltip("MIN Force to Apply to RigidBodies when the Damager hit them")]
		public FloatReference minForce;

		[Tooltip("Force mode to apply to the Object that the Damager Hits")]
		public ForceMode forceMode;

		[Tooltip("This Gameobject will be enabled on Impact, if its a Prefab it will be instantiated")]
		public GameObjectReference m_HitEffect;

		[Tooltip("Don't use the Default Reaction of the Damageable Component")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction CustomReaction;

		[Tooltip("Type of element damage the Damager can do")]
		public StatElement element;

		public void Modify(MDamager damager)
		{
			if (modify != 0)
			{
				if (Modify(DamageProfileModif.Damage))
				{
					damager.statModifier = new StatModifier(statModifier);
					damager.pureDamage = pureDamage;
				}
				if (Modify(DamageProfileModif.Interact))
				{
					damager.interact = interact;
					damager.interactorID = interactorID;
				}
				if (Modify(DamageProfileModif.Reaction))
				{
					damager.react = react;
					damager.CustomReaction = CustomReaction;
				}
				if (Modify(DamageProfileModif.CriticalChance))
				{
					damager.CriticalChance = m_cChance;
					damager.CriticalMultiplier = cMultiplier.Value;
				}
				if (Modify(DamageProfileModif.Force))
				{
					damager.MaxForce = maxForce;
					damager.MinForce = minForce;
				}
				if (Modify(DamageProfileModif.ElementalDamage))
				{
					damager.element = element;
				}
			}
		}

		private bool Modify(DamageProfileModif modifier)
		{
			return (modify & modifier) == modifier;
		}
	}
}
