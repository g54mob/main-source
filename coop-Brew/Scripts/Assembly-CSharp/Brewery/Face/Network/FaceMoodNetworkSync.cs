using Unity.Netcode;
using UnityEngine;

namespace Brewery.Face.Network
{
	public class FaceMoodNetworkSync : NetworkBehaviour
	{
		[Tooltip("The component on this GameObject that produces / consumes FaceMoodSet values. Must implement both IFaceMoodProducer and IFaceMoodConsumer. Leave null to auto-resolve via GetComponent.")]
		[SerializeField]
		private MonoBehaviour moodSourceBehaviour;

		public NetworkVariable<FaceMoodSet> MoodSet;

		private IFaceMoodProducer _producer;

		private IFaceMoodConsumer _consumer;

		private void Awake()
		{
		}

		private void Resolve()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void HandleProducerChanged(FaceMoodSet set)
		{
		}

		private void HandleNetVarChanged(FaceMoodSet prev, FaceMoodSet cur)
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
