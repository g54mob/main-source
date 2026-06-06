using Brewery.Core;
using Unity.Netcode;

namespace Brewery.Items
{
	public class BarrelItemData : NetworkBehaviour
	{
		public const int MaxBottleCount = 10;

		public const int MaxBonusBottleCount = 23;

		private readonly NetworkVariable<BarrelState> state;

		private readonly NetworkVariable<BeverageType> beverageType;

		private readonly NetworkVariable<double> fermentationStartTime;

		private readonly NetworkVariable<double> agingStartTime;

		private readonly NetworkVariable<int> remainingBottles;

		private readonly NetworkVariable<float> effectiveFermentationDuration;

		private readonly NetworkVariable<float> effectiveAgingDuration;

		private readonly NetworkVariable<float> effectiveSpoilDuration;

		private readonly NetworkVariable<double> spoilStartTime;

		public static float FermentationDurationSeconds => 0f;

		public static float WineAgingDurationSeconds => 0f;

		public static float SpoilDurationSeconds => 0f;

		public BarrelState State => default(BarrelState);

		public BeverageType CurrentBeverageType => default(BeverageType);

		public double FermentationStartTime => 0.0;

		public double AgingStartTime => 0.0;

		public int RemainingBottles => 0;

		public float EffectiveFermentationDuration => 0f;

		public float EffectiveAgingDuration => 0f;

		public float EffectiveSpoilDuration => 0f;

		public bool IsEmpty => false;

		public bool IsFermenting => false;

		public bool IsFermented => false;

		public bool IsAging => false;

		public bool IsAged => false;

		public bool IsReady => false;

		public bool IsSpoiled => false;

		public double SpoilStartTime => 0.0;

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public float GetFermentationProgress()
		{
			return 0f;
		}

		public float GetRemainingFermentationTime()
		{
			return 0f;
		}

		public float GetWineAgingProgress()
		{
			return 0f;
		}

		public float GetRemainingAgingTime()
		{
			return 0f;
		}

		public float GetSpoilProgress()
		{
			return 0f;
		}

		public float GetRemainingSpoilTime()
		{
			return 0f;
		}

		[ServerRpc(RequireOwnership = false)]
		public void StartFermentationServerRpc(int initialBottleCount)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void CompleteFermentationServerRpc()
		{
		}

		public void CompleteFermentationImmediate()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void StartWineAgingServerRpc(int initialBottleCount)
		{
		}

		public void CompleteWineAgingImmediate()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void SetSpiritsReadyServerRpc(int initialBottleCount)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RemoveBottlesServerRpc(int count)
		{
		}

		public BarrelMetadata GetMetadata()
		{
			return default(BarrelMetadata);
		}

		public void ApplyMetadataImmediate(BarrelMetadata metadata)
		{
		}

		public void ApplyMetadata(BarrelMetadata metadata)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void ApplyMetadataServerRpc(BarrelMetadata metadata)
		{
		}

		private static bool IsBottlingState(BarrelState currentState)
		{
			return false;
		}

		private void ResetBarrel()
		{
		}

		private void CompleteFermentationInternal()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1678912602(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3933772140(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_979639048(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2683637102(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_125687954(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2046283003(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
