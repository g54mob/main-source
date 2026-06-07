using UnityEngine;

[CreateAssetMenu]
public class CameraSettingsSO : ScriptableObject
{
	public float fieldOfViewMax;

	public float fieldOfViewMin;

	public float followOffsetMin;

	public float followOffsetMax;

	public float followOffsetMinY;

	public float followOffsetMaxY;

	public float xMin;

	public float xMax;

	public float zMin;

	public float zMax;

	public float minRotation;

	public float maxRotation;

	public float rotationSpeed;
}
