using System;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Quest
{
	[RequireComponent(typeof(NetworkObject))]
	public class GlobalReputationManager : NetworkBehaviour
	{
		[Header("Configuration")]
		[Tooltip("NPC unlock chain configuration")]
		public GlobalReputationConfig config;

		public static GlobalReputationManager Instance { get; private set; }

		public event Action OnNPCUnlockChanged
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

		public override void OnNetworkDespawn()
		{
		}

		public override void OnDestroy()
		{
		}

		public bool IsNPCQuestUnlocked(string npcId)
		{
			return false;
		}

		public bool AreAllNPCQuestsCompleted(string npcId)
		{
			return false;
		}

		private void OnQuestStateChanged()
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
