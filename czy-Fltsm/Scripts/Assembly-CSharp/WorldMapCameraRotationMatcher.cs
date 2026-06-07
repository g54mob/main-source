using PajamaLlama.Math;
using UnityEngine;

public class WorldMapCameraRotationMatcher : MonoBehaviour
{
	private WorldMapCameraController _cameraController;

	private void Awake()
	{
		_cameraController = GameManager.WorldMapManager.WorldMap.WorldCameraController;
	}

	private void Update()
	{
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		float y = _cameraController.transform.rotation.eulerAngles.y;
		base.transform.rotation = Quaternion.Euler(eulerAngles.SetY(y));
	}
}
