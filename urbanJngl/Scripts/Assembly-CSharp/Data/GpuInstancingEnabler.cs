using UnityEngine;

namespace Data
{
	[RequireComponent(typeof(MeshRenderer))]
	public class GpuInstancingEnabler : MonoBehaviour
	{
		private void Awake()
		{
			MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
			GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
		}
	}
}
