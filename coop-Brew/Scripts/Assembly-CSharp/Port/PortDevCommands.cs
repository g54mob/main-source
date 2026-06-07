using UnityEngine;
using UnityEngine.InputSystem;

namespace Port
{
	public class PortDevCommands : MonoBehaviour
	{
		[Header("Dev Hotkeys")]
		[Tooltip("Enable developer hotkeys for port testing")]
		[SerializeField]
		private bool enableDevHotkeys;

		[Header("Keys")]
		[SerializeField]
		private Key spawnShipKey;

		[SerializeField]
		private Key departAllKey;

		[SerializeField]
		private Key printStateKey;

		private Keyboard keyboard;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void SpawnShip()
		{
		}

		public void DepartAll()
		{
		}

		public void AddReputation(int amount)
		{
		}

		public void SetTier(int tier)
		{
		}

		public void CompleteContract(int contractId)
		{
		}

		public void GiveMaterials(int amount)
		{
		}

		public void ListContracts()
		{
		}

		public void ResetAll()
		{
		}

		public void PrintState()
		{
		}
	}
}
