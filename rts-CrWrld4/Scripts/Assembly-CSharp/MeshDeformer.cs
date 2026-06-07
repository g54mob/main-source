using UnityEngine;

public class MeshDeformer : MonoBehaviour
{
	public float springForce;

	public float damping;

	public float autoDeformForce;

	private Mesh deformingMesh;

	private Vector3[] originalVertices;

	private Vector3[] displacedVertices;

	private Vector3[] vertexVelocities;

	private float uniformScale;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void UpdateVertex(int i)
	{
	}

	public void AddDeformingForceLocal(Vector3 point, float force)
	{
	}

	public void AddDeformingForce(Vector3 point, float force)
	{
	}

	private void AddForceToVertex(int i, Vector3 point, float force)
	{
	}
}
