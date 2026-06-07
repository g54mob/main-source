using System.Collections.Generic;
using UnityEngine;

namespace BuoyancyToolkit
{
	[RequireComponent(typeof(Collider))]
	public class FluidVolume : MonoBehaviour
	{
		public float density = 1000f;

		public float waveAmplitude;

		public float rigidbodyDrag = 1f;

		public float rigidbodyAngularDrag = 1f;

		private Dictionary<int, BuoyancyForce> _buoyancyForceScripts = new Dictionary<int, BuoyancyForce>();

		private void SendFluidVolumeEnter(Component receiver, FluidVolumeMessage message)
		{
		}

		private void SendFluidVolumeStay(Component receiver, FluidVolumeMessage message)
		{
		}

		private void SendFluidVolumeExit(Component receiver, FluidVolumeMessage message)
		{
		}

		public Vector3 ProjectPointOntoSurface(Vector3 worldPoint)
		{
			return new Vector3(worldPoint.x, GetComponent<Collider>().bounds.max.y + waveAmplitude * (WaveFunction(worldPoint) - 1f), worldPoint.z);
		}

		public float RelativeHeightAtPoint(Vector3 worldPoint)
		{
			return GetComponent<Collider>().bounds.size.y + waveAmplitude * (WaveFunction(worldPoint) - 1f);
		}

		public virtual float WaveFunction(Vector3 worldPoint)
		{
			return 0f;
		}

		public void OnTriggerEnter(Collider collider)
		{
			int instanceID = collider.GetInstanceID();
			if (!_buoyancyForceScripts.TryGetValue(instanceID, out var value))
			{
				value = collider.GetComponent<BuoyancyForce>();
				_buoyancyForceScripts.Add(instanceID, value);
			}
			if (value != null)
			{
				value.OnFluidVolumeEnter();
			}
		}

		public void OnTriggerExit(Collider collider)
		{
			if (_buoyancyForceScripts.TryGetValue(collider.GetInstanceID(), out var value) && value != null)
			{
				value.OnFluidVolumeExit();
			}
		}
	}
}
