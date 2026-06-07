using UnityEngine;

public class jiggleBones : MonoBehaviour
{
	public bool debugMode;

	public Transform targetBone;

	private Vector3 targetPos;

	private Vector3 dynamicPos;

	public Vector3 boneAxis;

	public Vector3 upAxis;

	public float targetDistance;

	public float bStiffness;

	public float bMass;

	public float bDamping;

	public float bGravity;

	private Vector3 force;

	private Vector3 acc;

	private Vector3 vel;

	public bool SquashAndStretch;

	public float sideStretch;

	public float frontStretch;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}
}
