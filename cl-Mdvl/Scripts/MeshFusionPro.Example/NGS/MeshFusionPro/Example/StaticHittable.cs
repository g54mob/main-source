using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public class StaticHittable : MonoBehaviour, IHittable
	{
		public void Hitted(Ray ray, RaycastHit hitInfo)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
