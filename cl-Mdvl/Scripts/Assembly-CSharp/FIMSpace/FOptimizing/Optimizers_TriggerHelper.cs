using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[AddComponentMenu("FImpossible Creations/Optimizers 2/Utilities/Optimizers Trigger Helper")]
	public class Optimizers_TriggerHelper : MonoBehaviour
	{
		public Optimizer_Base Optimizer;

		public int TriggerIndex = -1;

		public Optimizers_TriggerHelper Initialize(Optimizer_Base optimizer, int index)
		{
			Optimizer = optimizer;
			TriggerIndex = index;
			return this;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (Optimizer == null)
			{
				Object.Destroy(base.gameObject);
			}
			else if (!(other.transform != Optimizer.TargetCamera))
			{
				Optimizer.OnTriggerChange(this, exit: false);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (Optimizer == null)
			{
				Object.Destroy(base.gameObject);
			}
			else if (!(other.transform != Optimizer.TargetCamera))
			{
				Optimizer.OnTriggerChange(this, exit: true);
			}
		}
	}
}
