using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Camera Preset")]
public class CameraPresetProperties : ScriptableObject
{
	[Header("Position")]
	[Tooltip("Position to place camera at.")]
	public Vector3 Position = Vector3.zero;

	[Header("Zoom")]
	[Tooltip("Zoom level for camera.")]
	[Range(0f, 1f)]
	public float ZoomLevel = 0.5f;

	[Header("Rotations")]
	[Tooltip("Rotation for the camera controller. This is used for the horizontal angle.")]
	public Vector3 Rotation = Vector3.zero;

	[Tooltip("Rotation for the camera swivel. This is used for the vertical angle.")]
	public Vector3 SwivelRotation = Vector3.zero;

	[Header("Other")]
	[Tooltip("FOV of the camera.")]
	public float FOV = 60f;
}
