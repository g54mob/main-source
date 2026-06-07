using Synty.AnimationBaseLocomotion.Samples;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Player
{
	public class PlayerHeadLookSync : NetworkBehaviour
	{
		[Header("Sync Settings")]
		[Tooltip("How often to send updates per second")]
		[SerializeField]
		private float sendRate;

		private readonly NetworkVariable<Vector3> syncedLookForward;

		private readonly NetworkVariable<float> syncedLookTilt;

		private static readonly int HeadLookXHash;

		private static readonly int HeadLookYHash;

		private static readonly int BodyLookXHash;

		private static readonly int BodyLookYHash;

		private SampleCameraController cameraController;

		private Animator animator;

		private float sendTimer;

		private float smoothedHeadLookX;

		private float smoothedBodyLookX;

		private float smoothedLookY;

		public Vector3 SyncedLookForward => default(Vector3);

		public float SyncedLookTilt => 0f;

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private void UpdateOwner()
		{
		}

		private void UpdateRemote()
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
