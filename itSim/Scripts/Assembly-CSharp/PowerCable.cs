using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PowerCable : MonoBehaviour
{
	public enum LengthMode
	{
		ManualTotalLength = 0,
		FitToAnchorsWithSlack = 1
	}

	[Header("Ends (anchors on your plug/PC)")]
	public Transform startAnchor;

	public Transform endAnchor;

	[Range(4f, 100f)]
	[Header("Cable Build")]
	public int segmentCount;

	[Range(0.005f, 0.2f)]
	public float cableRadius;

	[Range(0.02f, 0.5f)]
	public float segmentLength;

	public float segmentMass;

	public PhysicMaterial colliderMaterial;

	[Header("Joint Tuning")]
	public float linearLimit;

	public float linearSpring;

	public float linearDamper;

	[Range(0f, 180f)]
	public float swingLimit;

	[Range(0f, 180f)]
	public float twistLimit;

	public float projectionDistance;

	public float projectionAngle;

	[Header("Rendering")]
	public float lineWidth;

	public Material lineMaterial;

	public bool smoothPolyline;

	[Range(0f, 4f)]
	public int smoothness;

	private readonly List<Rigidbody> rbs;

	private LineRenderer lr;

	private Transform segmentsRoot;

	[Tooltip("Jeśli pola anchorów są puste, skrypt spróbuje znaleźć je po tych nazwach (child Transforms).")]
	public string startAnchorName;

	public string endAnchorName;

	public LengthMode lengthMode;

	[Min(0.05f)]
	public float desiredSegmentLength;

	[Min(0.1f)]
	public float totalCableLength;

	[Range(1f, 2f)]
	public float slackFactor;

	public bool renderAsTube;

	[Range(0.005f, 0.05f)]
	public float tubeRadius;

	[Range(6f, 24f)]
	public int tubeSides;

	private void Awake()
	{
	}

	private void Reset()
	{
	}

	private void OnValidate()
	{
	}

	private static Transform FindChildRecursive(Transform root, string name)
	{
		return null;
	}

	public void RebuildCable()
	{
	}

	private GameObject CreateSegment(int index, Vector3 position)
	{
		return null;
	}

	private void EnsureKinematicRB(GameObject go)
	{
	}

	private void LateUpdate()
	{
	}

	private void UpdateLineRendererPositions()
	{
	}

	private List<Vector3> CatmullRomSpline(List<Vector3> points, int level)
	{
		return null;
	}
}
