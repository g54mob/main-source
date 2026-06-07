using UnityEngine;

namespace UMA
{
	[ExecuteInEditMode]
	public class SeamRemoval : MonoBehaviour
	{
		public bool runScript;

		public float threshold;

		public Transform separatedMesh;

		public Transform unifiedMesh;

		private void Update()
		{
		}

		public static Mesh PerformSeamRemoval(SkinnedMeshRenderer originalMesh, SkinnedMeshRenderer referenceMesh, float threshold, bool calcTangents)
		{
			return null;
		}

		public static void calculateMeshTangents(Mesh mesh)
		{
		}
	}
}
