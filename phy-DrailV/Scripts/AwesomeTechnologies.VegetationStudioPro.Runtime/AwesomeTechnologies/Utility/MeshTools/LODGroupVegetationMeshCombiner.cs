using UnityEngine;

namespace AwesomeTechnologies.Utility.MeshTools
{
	public class LODGroupVegetationMeshCombiner : MonoBehaviour
	{
		public GameObject TargetGameObject;

		public bool MergeSubmeshesWitEquialMaterial = true;

		private void Reset()
		{
			TargetGameObject = base.gameObject;
		}
	}
}
