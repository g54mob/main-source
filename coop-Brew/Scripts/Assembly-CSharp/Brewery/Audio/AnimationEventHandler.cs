using System;
using System.Runtime.CompilerServices;
using Brewery.CombatSystem;
using Brewery.DrinkingSystem;
using UnityEngine;

namespace Brewery.Audio
{
	public class AnimationEventHandler : MonoBehaviour
	{
		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Audio Override (Optional)")]
		[Tooltip("If set, use this AudioSource instead of creating temporary ones")]
		[SerializeField]
		private AudioSource audioSourceOverride;

		[Header("Hammer Effect")]
		[Tooltip("Transform of the hammer for spawning particle effects (assign in inspector)")]
		[SerializeField]
		private Transform hammerTransform;

		private SimpleCombatController combatController;

		private DrinkingController drinkingController;

		private SimpleCombatController CombatController => null;

		private DrinkingController DrinkingController => null;

		public event Action OnDrinkStartEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnDrinkFinishedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void OnSwingSound()
		{
		}

		public void OnHitSound()
		{
		}

		public void OnFootstep()
		{
		}

		public void OnCustomSound(string soundName)
		{
		}

		public void OnSwingSoundVariant(int variantIndex)
		{
		}

		public void OnDrinkStart()
		{
		}

		public void OnDrinkFinished()
		{
		}

		public void OnHit()
		{
		}

		public void OnAttackStart()
		{
		}

		public void OnCanChangeHand()
		{
		}

		public void OnBottleThrowRelease()
		{
		}

		public void OnBottleThrowFinished()
		{
		}

		public void OnUnarmedAttackComplete()
		{
		}

		public void OnArmedAttackComplete()
		{
		}

		public void OnHammerHit()
		{
		}

		private void SpawnHammerSpark()
		{
		}
	}
}
