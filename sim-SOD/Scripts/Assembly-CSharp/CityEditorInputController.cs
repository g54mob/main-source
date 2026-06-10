using Rewired;
using UnityEngine;
using UnityEngine.Serialization;

public class CityEditorInputController : MonoBehaviour
{
	[Header("Editor Camera Settings")]
	public Camera editorCam;

	public Transform cameraPitch;

	public Transform cameraPivot;

	[FormerlySerializedAs("movementSpeed")]
	public float rotateSpeed;

	public float flySpeed;

	public float minZoom;

	public float maxZoom;

	public float zoomFactor;

	public float zoomSpeed;

	private Rewired.Player _player;

	private Vector3 targetZoomPos;

	private Vector3 curZoomPos;

	public Vector3 curRot;

	public Vector3 tgtRot;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void HandleCameraInputs()
	{
	}

	private void ConstrainCameraPivotPosition()
	{
	}

	private void ConstrainCameraZoom()
	{
	}
}
