using System;
using System.Runtime.CompilerServices;
using Unity.Netcode;

namespace Brewery.Voice
{
	public class VivoxPlayerTracker : NetworkBehaviour
	{
		public NetworkVariable<VoiceState> CurrentVoiceState;

		public event Action<VoiceState> OnVoiceStateChanged
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

		private void HandleVoiceStateChanged(VoiceState previousValue, VoiceState newValue)
		{
		}

		private void Update()
		{
		}

		private void UpdatePosition(VivoxVoiceManager manager)
		{
		}

		private void UpdateVoiceState(VivoxVoiceManager manager)
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
