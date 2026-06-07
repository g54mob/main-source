using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class FakeTrailQuad : MonoBehaviour
{
	public float thickness;

	public float trailTime;

	private Vector3 previousPosition;

	private float currentLength;

	private Vector3 direction;

	private MeshRenderer mRend;

	private MaterialPropertyBlock mpb;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
