using DV.ThingTypes;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class EnvironmentDamager : MonoBehaviour
	{
		[PortId(PortType.EXTERNAL_IN, true)]
		public string damagerPortId;

		public ResourceType environmentDamageResource;

		private Port damagerPort;

		public float Damage => damagerPort?.Value ?? 0f;

		public void Init(SimulationFlow simFlow)
		{
			if (environmentDamageResource != ResourceType.EnvironmentDamageCoal && environmentDamageResource != ResourceType.EnvironmentDamageFuel)
			{
				Debug.LogError(string.Format("Unexpected value for {0}: {1}. Either update the constraint or fix the values", "environmentDamageResource", environmentDamageResource));
				Object.Destroy(this);
			}
			else if (!simFlow.TryGetPort(damagerPortId, out damagerPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: EnvironmentDamager isn't properly initialized. Destroying self!", base.gameObject);
				Object.Destroy(this);
			}
		}

		public void ResetDamage()
		{
			damagerPort?.ExternalValueUpdate(0f);
		}
	}
}
