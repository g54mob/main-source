using UnityEngine;

namespace AwesomeTechnologies.Grass
{
	public class WindBaker : MonoBehaviour
	{
		public Mesh Mesh;

		public Vector3 Rotation;

		public AnimationCurve BendCurve = new AnimationCurve();

		private void Reset()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			if ((bool)component)
			{
				Mesh = component.sharedMesh;
			}
		}
	}
}
