using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class BlowbackParticlePortReader : AParticlePortReader
	{
		private const float BLOWBACK_SPEED_THRESHOLD = 6f;

		public float blowbackAirflowThreshold = 1.5f;

		public GameObject blowbackParticlesPrefab;

		public float particlesLifetime = 4f;

		public Transform spawnAnchor;

		[PortId(null, null, false)]
		public string forwardSpeedId;

		[PortId(null, null, false)]
		public string airflowId;

		[PortId(null, null, false)]
		public string fireOnId;

		[PortId(null, null, false)]
		public string fireboxDoorId;

		private Port forwardSpeed;

		private Port airflow;

		private Port fireOn;

		private Port fireboxDoor;

		public override void Init(SimulationFlow simFlow)
		{
			if (blowbackParticlesPrefab == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BlowbackParticlePortReader not initialized properly (blowbackParticlesPrefab is null");
			}
			else if (spawnAnchor == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BlowbackParticlePortReader not initialized properly (spawnAnchor is null");
			}
			else if (!simFlow.TryGetPort(forwardSpeedId, out forwardSpeed))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BlowbackParticlePortReader not initialized properly");
			}
			else if (!simFlow.TryGetPort(airflowId, out airflow))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BlowbackParticlePortReader not initialized properly");
			}
			else if (!simFlow.TryGetPort(fireOnId, out fireOn))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BlowbackParticlePortReader not initialized properly");
			}
			else if (!simFlow.TryGetPort(fireboxDoorId, out fireboxDoor))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BlowbackParticlePortReader not initialized properly");
			}
		}

		public override void Deinit()
		{
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.isTrigger && other.TryGetComponent<TunnelCollisionIgnore>(out var component) && !(fireOn.Value < 1f) && !(fireboxDoor.Value < 0.2f) && !(Vector3.Dot(base.transform.forward, component.transform.forward) >= 0f) && !(forwardSpeed.Value < 6f) && !(airflow.Value > blowbackAirflowThreshold))
			{
				Object.Destroy(Object.Instantiate(blowbackParticlesPrefab, spawnAnchor.position, spawnAnchor.rotation, spawnAnchor), particlesLifetime);
			}
		}
	}
}
