using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public class LODHittable : MonoBehaviour, IHittable
	{
		public void Hitted(Ray ray, RaycastHit hitInfo)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
