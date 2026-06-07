using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.NPC.Simple;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Bar.Brawl
{
	public class BarBrawlManager : NetworkBehaviour
	{
		[Header("Config")]
		[SerializeField]
		private BarBrawlConfig config;

		[SerializeField]
		private SimpleBarLocation barLocation;

		private NetworkVariable<bool> isBrawlActive;

		private NetworkVariable<int> participantCount;

		private int nextSessionId;

		private BarBrawlSession activeSession;

		private float globalCooldownUntil;

		private Dictionary<ulong, ulong> attackerToTarget;

		private Dictionary<ulong, int> attackerCounts;

		public bool IsBrawlActive => false;

		public int ParticipantCount => 0;

		public BarBrawlConfig Config => null;

		private bool ShowDebugLogs => false;

		public event Action OnBrawlStarted
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

		public event Action OnBrawlEnded
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

		public event Action<NPCBrawlAgent> OnParticipantAdded
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

		public event Action<NPCBrawlAgent> OnParticipantRemoved
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

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public bool TryStartBrawl(NPCBrawlAgent initiator, out NPCBrawlAgent target)
		{
			target = null;
			return false;
		}

		public void TryStartBrawl(NPCBrawlAgent initiator)
		{
		}

		public bool TryJoinBrawl(NPCBrawlAgent joiner, out NPCBrawlAgent target)
		{
			target = null;
			return false;
		}

		public void TryJoinBrawlAsDefender(NPCBrawlAgent npc)
		{
		}

		public void RegisterSpectator(NPCBrawlAgent spectator)
		{
		}

		private void AddParticipant(NPCBrawlAgent npc)
		{
		}

		public void UnregisterParticipant(NPCBrawlAgent participant)
		{
		}

		private void CheckBrawlEnd()
		{
		}

		public void EndBrawl()
		{
		}

		public void UnregisterSpectator(NPCBrawlAgent spectator)
		{
		}

		public bool TryFindNewTarget(NPCBrawlAgent seeker, out NPCBrawlAgent newTarget)
		{
			newTarget = null;
			return false;
		}

		private NPCBrawlAgent FindBestTarget(NPCBrawlAgent seeker)
		{
			return null;
		}

		private bool IsAtThisBar(NPCBrawlAgent agent)
		{
			return false;
		}

		private bool ShouldSkipSameFaction(NPCBrawlAgent seeker, NPCBrawlAgent candidate)
		{
			return false;
		}

		private float ScoreTarget(NPCBrawlAgent seeker, NPCBrawlAgent candidate)
		{
			return 0f;
		}

		public void RegisterAttackerMapping(ulong attackerId, ulong targetId)
		{
		}

		public void ClearAttackerMapping(ulong attackerId)
		{
		}

		public ulong GetAttackerTarget(ulong attackerId)
		{
			return 0uL;
		}

		public int GetAttackerCount(ulong targetNetworkId)
		{
			return 0;
		}

		private void IncrementAttackerCount(ulong targetNetworkId)
		{
		}

		private void DecrementAttackerCount(ulong targetNetworkId)
		{
		}

		private void DecrementAllAttackerCounts(NPCBrawlAgent attacker)
		{
		}

		public Dictionary<ulong, ulong> GetAttackerMappings()
		{
			return null;
		}

		private bool IsBrawlsEnabled()
		{
			return false;
		}

		private int GetMaxParticipants()
		{
			return 0;
		}

		private void ResetBrawlState()
		{
		}

		public BrawlSessionSnapshot GetSessionSnapshot()
		{
			return null;
		}

		private void OnDrawGizmosSelected()
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
