using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Investigators/Leaving Vigilance Data")]
	public class VigilanceMultipliersData : ScriptableObject
	{
		[field: SerializeField]
		[field: Tooltip("Multiplied with credibility")]
		public float SewerDropCredibilityMultiplier { get; private set; } = 0.2f;

		[field: SerializeField]
		[field: Tooltip("Multiplied with credibility")]
		public float TheDipCredibilityMultiplier { get; private set; } = 1f;

		[field: SerializeField]
		[field: Tooltip("Multiplied with credibility")]
		public float KilledVigilanceMultiplier { get; private set; }

		[field: SerializeField]
		[field: Tooltip("Multiplied with credibility and sewer drop multiplier")]
		public float NotWitnessLeavingVigilanceMultiplier { get; private set; }

		[field: SerializeField]
		[field: Tooltip("Multiplied with credibility and crime strength")]
		public float WitnessLeavingVigilanceMultiplier { get; private set; } = 1f;

		[field: SerializeField]
		[field: Tooltip("Multiplied with credibility")]
		public float AbyssalDeathMultiplier { get; private set; }

		[field: SerializeField]
		[field: Tooltip("Multiplied with credibility")]
		public float EnterMachineMultiplier { get; private set; } = -0.1f;

		public int GetVigilanceForSewerDrop(Customer customer)
		{
			return GetVigilanceForSewerDrop(customer.Credibility);
		}

		public int GetVigilanceForEnterMachine(Customer customer)
		{
			return Mathf.FloorToInt((float)customer.SpawnParameters.Credibility * EnterMachineMultiplier);
		}

		public int GetVigilanceForSewerDrop(int credibility)
		{
			return Mathf.CeilToInt((float)credibility * SewerDropCredibilityMultiplier);
		}

		public int GetVigilanceForTheDip(int credibility)
		{
			return Mathf.CeilToInt((float)credibility * TheDipCredibilityMultiplier);
		}

		public int GetVigilanceForKilling(Customer customer)
		{
			return Mathf.RoundToInt((float)customer.SpawnParameters.Credibility * KilledVigilanceMultiplier);
		}

		public int GetVigilanceForAbyssalDeath(Customer customer)
		{
			return Mathf.RoundToInt((float)customer.SpawnParameters.Credibility * AbyssalDeathMultiplier);
		}

		public int GetVigilanceForLeaving(Customer customer)
		{
			if (!customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return Mathf.RoundToInt((float)GetVigilanceForSewerDrop(customer) * NotWitnessLeavingVigilanceMultiplier);
			}
			return Mathf.RoundToInt((float)customer.Credibility * WitnessLeavingVigilanceMultiplier);
		}
	}
}
