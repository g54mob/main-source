using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(NetworkObject))]
	public class StandReputationManager : NetworkBehaviour, ISaveable
	{
		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private const float RepGainPerDrink = 0.15f;

		private const float RepGainOrderComplete = 0.25f;

		private const float RepLossPatienceExpired = 0.5f;

		private const float RepLossPaymentNotCollected = 0.75f;

		private const float RepLossEmptyStand = 0.3f;

		private static readonly float[] LevelThresholds;

		private static readonly string[] LevelNames;

		private NetworkVariable<float> _reputation;

		private int _customersToday;

		private float _revenueToday;

		public float Reputation => 0f;

		public int CustomersToday => 0;

		public float RevenueToday => 0f;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<float> OnReputationChanged
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

		public event Action<int, int> OnRepLevelChanged
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

		public event Action<float> OnReputationLost
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

		public event Action<float> OnReputationGained
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

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void HandleRepChanged(float oldValue, float newValue)
		{
		}

		public int GetRepLevel()
		{
			return 0;
		}

		public string GetRepLevelName()
		{
			return null;
		}

		public float GetRepProgress()
		{
			return 0f;
		}

		public void OnDrinkServed()
		{
		}

		public void OnOrderCompleted()
		{
		}

		public void OnPatienceExpired()
		{
		}

		public void OnPaymentNotCollected()
		{
		}

		public void OnEmptyStandVisit()
		{
		}

		public void TrackCustomer(float revenue)
		{
		}

		public void ResetDailyStats()
		{
		}

		private void ChangeRep(float delta, string reason)
		{
		}

		private static int CalculateLevel(float rep)
		{
			return 0;
		}

		[ClientRpc]
		private void NotifyRepLossClientRpc(string reason)
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_975793295(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
