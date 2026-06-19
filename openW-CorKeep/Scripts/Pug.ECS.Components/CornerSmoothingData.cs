using Unity.Mathematics;

public struct CornerSmoothingData
{
	public bool experimentalWallSmoothingEnabled;

	public float wallMovementBlend;

	public float cornerMovementBlend;

	public float forwardSensorDistVertical;

	public float forwardSensorDistHorizontal;

	public float3 forwardSensorSize;

	public float escapeSensorSpreadVertical;

	public float escapeSensorSpreadHorizontal;

	public float escapeSensorSizeVertical;

	public float escapeSensorSizeHorizontal;
}
