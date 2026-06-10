using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public interface IHittable
	{
		void Hitted(Ray ray, RaycastHit hitInfo);
	}
}
