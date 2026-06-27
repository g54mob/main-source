using System.Collections;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class SetCloudPosition : MonoBehaviour
	{
		private Renderer render;

		private ParticleSystem.ShapeModule shape;

		public float density;

		public PlumeModule plume;

		public ParticleSystem system;

		public BoxCollider collider;

		public float destroyTime;

		public Vector3Int pos;

		public Vector3 closestHeavy = Vector3.zero;

		public void Init()
		{
			render = GetComponent<Renderer>();
			shape = GetComponent<ParticleSystem>().shape;
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			render.GetPropertyBlock(materialPropertyBlock);
			closestHeavy = plume.GetClosestHeavy(base.transform.position);
			materialPropertyBlock.SetVector("_CenterPoint", (closestHeavy == Vector3.zero) ? base.transform.position : closestHeavy);
			materialPropertyBlock.SetFloat("_Density", density);
			render.SetPropertyBlock(materialPropertyBlock);
		}

		public void Destroy()
		{
			system.Stop();
			StartCoroutine(DestroyTimer());
		}

		private IEnumerator DestroyTimer()
		{
			yield return new WaitForSeconds(destroyTime);
			Object.DestroyImmediate(base.gameObject);
		}
	}
}
