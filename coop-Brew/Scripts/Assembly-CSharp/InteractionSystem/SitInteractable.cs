using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace InteractionSystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class SitInteractable : NetworkBehaviour, IInteractable
	{
		[Serializable]
		public class SeatSpot
		{
			[Tooltip("Transform where the player sits (position + rotation)")]
			public Transform seatTransform;

			[Tooltip("Optional: Transform where player moves when standing up. If null, uses position in front of seat.")]
			public Transform exitTransform;

			[Tooltip("Optional: Custom offset from seat when no exit transform specified")]
			public Vector3 exitOffset;
		}

		private class StoredPlayerState
		{
			public Vector3 originalPosition;

			public Quaternion originalRotation;

			public NetworkObject originalParent;

			public Behaviour[] components;

			public bool[] componentStates;

			public int seatIndex;
		}

		[Header("Seat Settings")]
		[SerializeField]
		private List<SeatSpot> seats;

		[SerializeField]
		private float interactionDistance;

		[Header("WC Mode")]
		[Tooltip("When true, sitting here drains the pee meter (no particle FX). Player can stand up anytime.")]
		[SerializeField]
		private bool isWC;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkList<ulong> seatOccupants;

		private Dictionary<ulong, StoredPlayerState> storedPlayerStates;

		private static readonly int IsSittingHash;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void LateUpdate()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		private bool IsSeatDataSynced()
		{
			return false;
		}

		public int GetAvailableSeatCount()
		{
			return 0;
		}

		public int GetTotalSeatCount()
		{
			return 0;
		}

		public int GetSeatIndexForPlayer(ulong clientId)
		{
			return 0;
		}

		private int GetFirstAvailableSeatIndex()
		{
			return 0;
		}

		public bool IsSeatOccupied(int seatIndex)
		{
			return false;
		}

		public ulong GetSeatOccupant(int seatIndex)
		{
			return 0uL;
		}

		private void SitDown(ulong clientId, int seatIndex)
		{
		}

		private void StandUp(ulong clientId, int seatIndex)
		{
		}

		private void ForceStand(ulong clientId)
		{
		}

		[ClientRpc]
		private void SitOnSeatClientRpc(ulong clientId, int seatIndex, Vector3 position, Quaternion rotation)
		{
		}

		[ClientRpc]
		private void StandFromSeatClientRpc(ulong clientId, Vector3 position, Quaternion rotation)
		{
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

		private static void __rpc_handler_2670787593(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1440297313(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
