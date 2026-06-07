using System;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class RotatorPortReader : AGenericPortReader
	{
		[Serializable]
		public class RotationData
		{
			public Transform transformToRotate;

			public Vector3 rotationAxis = Vector3.forward;

			public float maxRps = 10f;
		}

		private const float ROTATIONS_PER_S_TO_DEGREES_PER_S = 360f;

		[PortId(null, null, false)]
		public string portId;

		public RotationData[] transformsToRotate;

		private Port port;

		public override bool ExternalTickCall => port.Value > 0f;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(portId, out port))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find port for portId: " + portId + ". RotatorPortReader won't function properly!");
			}
		}

		public override void Tick()
		{
			float value = port.Value;
			RotationData[] array = transformsToRotate;
			foreach (RotationData rotationData in array)
			{
				rotationData.transformToRotate.Rotate(rotationData.rotationAxis, value * rotationData.maxRps * 360f * Time.deltaTime, Space.Self);
			}
		}

		public override void Deinit()
		{
		}
	}
}
