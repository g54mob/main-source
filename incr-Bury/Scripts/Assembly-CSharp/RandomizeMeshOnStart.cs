using UnityEngine;

public class RandomizeMeshOnStart : MonoBehaviour
{
	public Mesh[] meshes;

	private void Start()
	{
		try
		{
			base.gameObject.GetComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
		}
		catch
		{
			Debug.Log("Failed to find the mesh renderer of this object, ignoring!");
		}
	}
}
