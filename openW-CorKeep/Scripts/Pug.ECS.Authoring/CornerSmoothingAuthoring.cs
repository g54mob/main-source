using UnityEngine;

public class CornerSmoothingAuthoring : MonoBehaviour
{
	public float forwardSensorDistVertical = 0.4f;

	public float forwardSensorDistHorizontal = 0.4f;

	public Vector3 forwardSensorSize = new Vector3(0.25f, 0.25f, 0.25f);

	public float escapeSensorSpreadVertical = 0.6f;

	public float escapeSensorSpreadHorizontal = 0.6f;

	public float escapeSensorSizeVertical = 0.25f;

	public float escapeSensorSizeHorizontal = 0.25f;

	[Header("Corner/wall smoothing settings:")]
	public float cornerMovementBlend = 0.185f;

	public bool experimentalWallSmoothingEnabled = true;

	public float wallMovementBlend = 0.985f;
}
