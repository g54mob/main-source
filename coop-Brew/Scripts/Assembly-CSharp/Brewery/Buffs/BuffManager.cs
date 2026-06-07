using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.Items;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Buffs
{
	public class BuffManager : NetworkBehaviour
	{
		[Header("Catalyst Effect Definitions")]
		[Tooltip("All CatalystEffectData assets. Assign all 15 catalyst effects here.")]
		[SerializeField]
		private List<CatalystEffectData> catalystEffects;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<string, CatalystEffectData> effectLookup;

		private Dictionary<ulong, List<ActiveBuff>> playerBuffs;

		public static BuffManager Instance { get; private set; }

		public event Action<ulong, ActiveBuff> OnBuffApplied
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

		public event Action<ulong, ActiveBuff> OnBuffRefreshed
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

		public event Action<ulong, string> OnBuffExpired
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

		public override void OnDestroy()
		{
		}

		private void BuildEffectLookup()
		{
		}

		private void Update()
		{
		}

		public void ApplyCatalystEffects(ulong clientId, BeerDataSnapshot snapshot)
		{
		}

		private void ApplyCatalystEffect(ulong clientId, string catalystId)
		{
		}

		private void CheckAllBuffsAchievement(ulong clientId, List<ActiveBuff> buffs)
		{
		}

		private void TickBuffTimers()
		{
		}

		private void TickClientBuffTimers()
		{
		}

		public float GetBuffMultiplier(ulong clientId, BuffType type)
		{
			return 0f;
		}

		public float GetBuyDiscountMultiplier(ulong clientId)
		{
			return 0f;
		}

		public float GetBuffFlatBonus(ulong clientId, BuffType type)
		{
			return 0f;
		}

		public bool HasBuff(ulong clientId, BuffType type)
		{
			return false;
		}

		public List<ActiveBuff> GetActiveBuffs(ulong clientId)
		{
			return null;
		}

		public CatalystEffectData GetEffectData(string catalystId)
		{
			return null;
		}

		[ClientRpc]
		private void NotifyBuffAppliedClientRpc(ulong clientId, ActiveBuff buff)
		{
		}

		[ClientRpc]
		private void NotifyBuffRefreshedClientRpc(ulong clientId, ActiveBuff buff)
		{
		}

		[ClientRpc]
		private void NotifyBuffExpiredClientRpc(ulong clientId, string catalystId)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		public void ApplyEffectForTestingRpc(string catalystId, float overrideDuration = 0f, RpcParams rpcParams = default(RpcParams))
		{
		}

		private void ApplyEffectForTestingInternal(ulong clientId, string catalystId, float overrideDuration)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		public void ClearAllBuffsRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		private void ClearBuffsForPlayer(ulong clientId)
		{
		}

		public IReadOnlyList<CatalystEffectData> GetAllEffectData()
		{
			return null;
		}

		[ContextMenu("Debug: Apply Test Buff")]
		private void DebugApplyTestBuff()
		{
		}

		[ContextMenu("Debug: Clear All Buffs")]
		private void DebugClearAllBuffs()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2668836667(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1226796095(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_567042886(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2190530498(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2871036986(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
