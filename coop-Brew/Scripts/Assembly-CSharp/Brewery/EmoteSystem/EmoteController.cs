using System.Collections.Generic;
using Brewery.CarryingSystem;
using Brewery.CombatSystem;
using Brewery.DrinkingSystem;
using Brewery.Pee;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.EmoteSystem
{
	[RequireComponent(typeof(Animator))]
	public class EmoteController : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private InputReader inputReader;

		[SerializeField]
		private CarryingController carryingController;

		[SerializeField]
		private DrinkingController drinkingController;

		[SerializeField]
		private SimpleCombatController combatController;

		[SerializeField]
		private PeeController peeController;

		[Header("Emote Configuration")]
		[SerializeField]
		private EmoteCategory[] emoteCategories;

		[SerializeField]
		private EmoteDefinition[] idleEmotes;

		[Header("Layer Configuration")]
		[Range(1f, 20f)]
		[SerializeField]
		private float layerFadeSpeed;

		[Header("Idle Emote Timing")]
		[SerializeField]
		private float idleMinTime;

		[SerializeField]
		private float idleMaxTime;

		private NetworkVariable<int> syncedEmoteIndex;

		private List<EmoteDefinition> allEmotes;

		private bool isEmoting;

		private EmoteDefinition currentEmote;

		private float emoteTimer;

		private float lastInputTime;

		private float nextIdleTime;

		private bool isIdleEmote;

		private EmoteRadialMenuUI radialMenu;

		private int activeLayerIndex;

		private Dictionary<int, float> layerWeights;

		private int[] cachedLayerIndices;

		private bool layerIndicesDirty;

		private static readonly int IsEmotingHash;

		public List<EmoteDefinition> AllEmotes => null;

		public EmoteCategory[] EmoteCategories => null;

		public bool IsEmoting => false;

		public EmoteDefinition CurrentEmoteDefinition => null;

		private void Awake()
		{
		}

		private void BuildAllEmotesList()
		{
		}

		private void CollectAndInitializeLayers()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void PollEmoteInput()
		{
		}

		private void OnEmoteSelected(EmoteDefinition emote)
		{
		}

		public bool CanEmote()
		{
			return false;
		}

		private void PlayEmote(int emoteIndex, bool idle)
		{
		}

		private void StartEmote(EmoteDefinition emote, bool idle)
		{
		}

		private void FireEmoteAnimation(EmoteDefinition emote)
		{
		}

		private void StopEmoteAnimation(EmoteDefinition emote)
		{
		}

		private void ResetEmoteState()
		{
		}

		public void CancelEmote()
		{
		}

		private void UpdateEmoteTimer()
		{
		}

		private void ResetIdleTimer()
		{
		}

		private void UpdateIdleDetection()
		{
		}

		private void UpdateLayerWeights()
		{
		}

		private void SetLayerWeightSafe(int index, float weight)
		{
		}

		private void OnSyncedEmoteChanged(int oldValue, int newValue)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
