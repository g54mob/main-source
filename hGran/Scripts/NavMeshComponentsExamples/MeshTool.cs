using System.Collections.Generic;
using UnityEngine;

public class MeshTool : MonoBehaviour
{
	public enum ExtrudeMethod
	{
		Vertical = 0,
		MeshNormal = 1
	}

	public List<MeshFilter> m_Filters;

	public float m_Radius;

	public float m_Power;

	public ExtrudeMethod m_Method;

	private RaycastHit m_HitInfo;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void ModifyMesh(Vector3 displacement, Vector3 center)
	{
	}

	private static float Gaussian(Vector3 pos, Vector3 mean, float dev)
	{
		return 0f;
	}
}
