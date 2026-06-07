using UnityEngine;
using UnityEngine.UI;

public class MouseLineRenderer : MonoBehaviour
{
	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private Image image_ArrowHead;

	public int numOfPoints;

	public LineRenderer lineRenderer;

	public Canvas canvas;

	private bool doUpdate;

	private Transform startPointTransform;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTogglePlacementPointerArrow(bool isOn)
	{
	}

	private void OnSetPlacementPointerArrowTarget(Transform from, Transform arg2)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private Vector3 BezierCurve(Vector3 start, Vector3 end, float t)
	{
		return default(Vector3);
	}
}
