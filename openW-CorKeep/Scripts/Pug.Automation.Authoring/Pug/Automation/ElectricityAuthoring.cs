using NaughtyAttributes;
using UnityEngine;

namespace Pug.Automation
{
	public class ElectricityAuthoring : MonoBehaviour
	{
		public CircuitType circuitType;

		public Vector2Int direction;

		public bool blocksElectricity;

		public int sourceEnergy;

		public bool isLever;

		[ShowIf("circuitType", CircuitType.None)]
		public CircuitConnectionMode circuitConnectionMode;

		[Tooltip("only used to deprioritize these when put on same spot")]
		public bool isWire;
	}
}
