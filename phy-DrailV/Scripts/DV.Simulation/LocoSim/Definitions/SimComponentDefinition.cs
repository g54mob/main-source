using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public abstract class SimComponentDefinition : MonoBehaviour
	{
		public string ID;

		public abstract SimComponent InstantiateImplementation();
	}
}
