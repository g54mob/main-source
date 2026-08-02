using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMContextEvaluation : MonoBehaviour
	{
		protected static int instancesCount;

		public static int InstancesCount => instancesCount;
	}
}
