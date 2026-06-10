using NSMedieval;
using UnityEngine;

public class SinglePlacementPreviewGridRuler : MonoBehaviour
{
	[SerializeField]
	private GameObject miniGrid;

	[SerializeField]
	private GameObject linePositiveX;

	[SerializeField]
	private GameObject lineNegativeX;

	[SerializeField]
	private GameObject linePositiveZ;

	[SerializeField]
	private GameObject lineNegativeZ;

	private Vector3 miniGridStartLocalScale;

	private Vector3 miniGridStartPosition;

	private Vector3 linePositiveXstartPos;

	private Vector3 lineNegativeXstartPos;

	private Vector3 linePositiveZstartPos;

	private Vector3 lineNegativeZstartPos;

	public void Scale(Vec3Int size)
	{
		Transform obj = miniGrid.transform;
		Vector3 position = obj.position;
		float x = position.x;
		float z = position.z;
		Vector3 lossyScale = obj.lossyScale;
		Vector3 position2 = linePositiveX.transform.position;
		position2 = new Vector3(position2.x + (float)size.x, position2.y, position2.z);
		linePositiveX.transform.position = position2;
		Vector3 position3 = linePositiveZ.transform.position;
		position3 = new Vector3(position3.x, position3.y, position3.z + (float)size.z);
		linePositiveZ.transform.position = position3;
		x += ((float)size.x - 1f) / 2f;
		z += ((float)size.z - 1f) / 2f;
		obj.position = new Vector3(x, 0.1f, z);
		obj.localEulerAngles = Vector3.zero;
		obj.localScale = new Vector3(size.x, lossyScale.y, size.z);
	}

	public void ResetRulers()
	{
		miniGrid.transform.localScale = miniGridStartLocalScale;
		miniGrid.transform.localPosition = miniGridStartPosition;
		linePositiveX.transform.localPosition = linePositiveXstartPos;
		lineNegativeX.transform.localPosition = lineNegativeXstartPos;
		linePositiveZ.transform.localPosition = linePositiveZstartPos;
		lineNegativeZ.transform.localPosition = lineNegativeZstartPos;
		base.transform.localEulerAngles = Vector3.zero;
	}

	private void Start()
	{
		miniGridStartLocalScale = miniGrid.transform.localScale;
		miniGridStartPosition = miniGrid.transform.localPosition;
		linePositiveXstartPos = linePositiveX.transform.localPosition;
		lineNegativeXstartPos = lineNegativeX.transform.localPosition;
		linePositiveZstartPos = linePositiveZ.transform.localPosition;
		lineNegativeZstartPos = lineNegativeZ.transform.localPosition;
	}
}
