using Brewery.NPC;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	public class ThiefSpeechController : NetworkBehaviour
	{
		[SerializeField]
		private NPCSpeechBubbleController speechBubble;

		[SerializeField]
		private ThiefDialogueConfig dialogueConfig;

		private ThiefBrainBase brain;

		private int lastStateValue;

		private float nextSpeechTime;

		private const float MIN_SPEECH_INTERVAL = 8f;

		private const float MAX_SPEECH_INTERVAL = 20f;

		private const float SPEECH_DURATION = 3f;

		private static ThiefDialogueConfig fallbackConfig;

		private ThiefDialogueConfig Config => null;

		public override void OnNetworkSpawn()
		{
		}

		public void OnStateChanged(int newState)
		{
		}

		private void Update()
		{
		}

		private string GetLineForState(int state)
		{
			return null;
		}

		private string GetPeriodicLineForCurrentState()
		{
			return null;
		}

		[ClientRpc]
		private void ShowSpeechClientRpc(string text, float duration)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4019142272(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
