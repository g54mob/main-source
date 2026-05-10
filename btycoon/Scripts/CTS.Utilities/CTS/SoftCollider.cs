using UnityEngine;

namespace CTS
{
	public abstract class SoftCollider : MonoBehaviour
	{
		public abstract Vector3 Center { get; }

		public abstract int Overlap(Collider[] p_results, int p_layerMask = -1, QueryTriggerInteraction p_triggerInteraction = QueryTriggerInteraction.UseGlobal);

		public abstract bool Check(int p_layerMask = -1, QueryTriggerInteraction p_triggerInteraction = QueryTriggerInteraction.UseGlobal);
	}
}
