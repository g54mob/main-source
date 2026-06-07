using Brewery.Employee.AI;
using Brewery.NPC;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	public class BreweryEmployeeSpeechController : NetworkBehaviour
	{
		[SerializeField]
		private NPCSpeechBubbleController speechBubble;

		[SerializeField]
		private BreweryEmployeeDialogueConfig dialogueConfig;

		[Header("Timing")]
		[SerializeField]
		private float minTimeBetweenSpeech;

		[SerializeField]
		private float maxTimeBetweenSpeech;

		[SerializeField]
		private float speechDuration;

		[SerializeField]
		[Range(0f, 1f)]
		private float stateChangeSpeechChance;

		private BreweryEmployeeNPCController npcController;

		private BreweryEmployeePersonality personality;

		private EmployeeState lastKnownState;

		private float nextSpeechTime;

		private string lastSpokenLine;

		private bool initialized;

		public void Initialize(BreweryEmployeePersonality employeePersonality)
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private bool IsPeriodicSpeechState(EmployeeState state)
		{
			return false;
		}

		private void TrySpeakForState(EmployeeState state)
		{
		}

		private PersonalityLines[] GetContextForState(EmployeeState state)
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

		private static void __rpc_handler_2144665490(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
