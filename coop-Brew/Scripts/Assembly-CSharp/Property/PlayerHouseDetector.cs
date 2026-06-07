using Unity.Netcode;
using UnityEngine;

namespace Property
{
	public class PlayerHouseDetector : NetworkBehaviour
	{
		[Header("Detection Settings")]
		[Tooltip("Layer mask for housing floors")]
		[SerializeField]
		private LayerMask housingLayerMask;

		[Tooltip("How far down to raycast")]
		[SerializeField]
		private float raycastDistance;

		[Tooltip("How often to check (seconds)")]
		[SerializeField]
		private float checkInterval;

		[Tooltip("Offset from player position for raycast")]
		[SerializeField]
		private Vector3 raycastOffset;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[SerializeField]
		private bool showDebugGizmos;

		private PlotForSaleSignInteractable currentHouse;

		private float nextCheckTime;

		private bool isInitialized;

		public PlotForSaleSignInteractable CurrentHouse => null;

		public bool IsInsideHouse => false;

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private void CheckHouseStatus()
		{
		}

		private void OnEnterHouse(PlotForSaleSignInteractable houseSign)
		{
		}

		private void OnExitHouse(PlotForSaleSignInteractable houseSign)
		{
		}

		public void RefreshUI()
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
