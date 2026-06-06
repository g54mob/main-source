using System;
using System.Collections.Generic;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public struct MDamageableProfile
	{
		[Tooltip("Name of the Profile. This is used for Setting a New Damageable Profile. E.g. When the Animal is blocking or Parrying")]
		public string name;

		[Tooltip("Type of surface the Damageable is. (Flesh, Metal, Wood,etc)")]
		public SurfaceID surface;

		[Tooltip("Animal Reaction to apply when the damage is done")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction reaction;

		[Tooltip("Animal Reaction when it receives a critical damage")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction criticalReaction;

		[Tooltip("Animal Reaction to apply when the damage is done")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction DamagerReaction;

		[Tooltip("Multiplier for the Stat modifier Value. Use this to increase or decrease the final value of the Stat")]
		public FloatReference multiplier;

		[Tooltip("When Enabled the animal will rotate towards the Damage direction")]
		public BoolReference AlignToDamage;

		public BoolReference ignoreDamagerReaction;

		[Tooltip("Elements that affect the MDamageable")]
		public List<ElementMultiplier> elements;

		public MDamageableProfile(string Name, SurfaceID surface, Reaction reaction, Reaction criticalReaction, Reaction DamagerReaction, BoolReference ignoreDamagerReaction, FloatReference multiplier, BoolReference AlignToDamage, List<ElementMultiplier> elements)
		{
			name = Name;
			this.surface = surface;
			this.reaction = reaction;
			this.DamagerReaction = DamagerReaction;
			this.multiplier = multiplier;
			this.criticalReaction = criticalReaction;
			this.AlignToDamage = AlignToDamage;
			this.elements = elements;
			this.ignoreDamagerReaction = ignoreDamagerReaction;
		}
	}
}
