using UnityEngine;
using VerletRope;

public class CouplingHoseSolverCameraUpdater : MonoBehaviour
{
	public VerletSolver solver;

	public Camera placeholderCamera;

	private void Awake()
	{
		if (!DevSceneUtil.IsGameScene())
		{
			if (placeholderCamera == null)
			{
				placeholderCamera = Camera.main;
			}
			solver.camera = placeholderCamera;
		}
	}

	private void Start()
	{
		if ((bool)PlayerManager.ActiveCamera)
		{
			UpdateCamera();
		}
		PlayerManager.CameraChanged += UpdateCamera;
	}

	private void OnDestroy()
	{
		PlayerManager.CameraChanged -= UpdateCamera;
	}

	private void UpdateCamera()
	{
		solver.camera = PlayerManager.ActiveCamera;
		solver.enabled = true;
	}
}
