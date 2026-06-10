using UnityEngine;

namespace NGS.MeshFusionPro
{
	public abstract class BaseCombinedObject : MonoBehaviour
	{
		public virtual Bounds Bounds => default(Bounds);
	}
}
