using DV.VRTK_Extensions;
using UnityEngine;

namespace DV.Items
{
	public class ItemVelocityEstimator : VRTK_VelocityEstimator_DV
	{
		private ItemSimulationSpace simSpace;

		private void Awake()
		{
			simSpace = GetComponent<ItemSimulationSpace>();
			PlayerManager.PlayerTeleportFinished += OnTPFinished;
			simSpace.SimulationSpaceChanged += delegate(Transform oldParent, Transform newParent)
			{
				bool flag = oldParent != null;
				previousPosition = GetLocalPosition();
				previousRotation = GetLocalRotation();
				for (int i = 0; i < velocitySamples.Length; i++)
				{
					velocitySamples[i] = simSpace.InverseTransformDirection(flag ? oldParent.TransformPoint(velocitySamples[i]) : velocitySamples[i]);
				}
				for (int j = 0; j < angularVelocitySamples.Length; j++)
				{
					angularVelocitySamples[j] = simSpace.InverseTransformDirection(flag ? oldParent.TransformPoint(angularVelocitySamples[j]) : angularVelocitySamples[j]);
				}
			};
		}

		private void OnDestroy()
		{
			PlayerManager.PlayerTeleportFinished -= OnTPFinished;
		}

		private void OnTPFinished()
		{
			previousPosition = GetLocalPosition();
			previousRotation = GetLocalRotation();
		}

		protected override Vector3 TransformDirection(Vector3 value)
		{
			return simSpace.TransformDirection(value);
		}

		protected override Vector3 GetLocalPosition()
		{
			return simSpace.InverseTransformPoint(base.transform.position);
		}

		protected override Quaternion GetLocalRotation()
		{
			return simSpace.InverseTransformRotation(base.transform.rotation);
		}
	}
}
