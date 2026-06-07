using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Cartel
{
	public class CartelDealer : Dealer
	{
		public const float DEALER_DEFEATED_INFLUENCE_CHANGE = -0.1f;

		public const int PRODUCT_COUNT_MIN = 2;

		public const int PRODUCT_COUNT_MAX = 4;

		public const int PRODUCT_QUANTITY_MIN = 1;

		public const int PRODUCT_QUANTITY_MAX = 10;

		[Header("Cartel Dealer Inventory Settings")]
		public ProductDefinition[] RandomProducts;

		public EQuality ProductQuality;

		public PackagingDefinition DefaultPackaging;

		private CartelGoonAppearance appearance;

		private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelDealerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelDealerAssembly_002DCSharp_002Edll_Excuted;

		public bool IsAcceptingDeals { get; private set; }

		private GoonPool GoonPool => null;

		protected override void Start()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public void RandomizeInventory()
		{
		}

		public void RandomizeAppearance()
		{
		}

		[ObserversRpc(RunLocally = true)]
		[TargetRpc]
		private void ConfigureGoonSettings(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed)
		{
		}

		public void SetIsAcceptingDeals(bool accepting)
		{
		}

		public bool CanCurrentlyAcceptDeal()
		{
			return false;
		}

		private void DiedOrKnockedOut()
		{
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Observers_ConfigureGoonSettings_3427656873(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed)
		{
		}

		private void RpcLogic___ConfigureGoonSettings_3427656873(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed)
		{
		}

		private void RpcReader___Observers_ConfigureGoonSettings_3427656873(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_ConfigureGoonSettings_3427656873(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed)
		{
		}

		private void RpcReader___Target_ConfigureGoonSettings_3427656873(PooledReader PooledReader0, Channel channel)
		{
		}

		public override void Awake()
		{
		}
	}
}
