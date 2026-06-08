using UnityEngine;

[RequireComponent(typeof(GameCameraBinding))]
[RequireComponent(typeof(Character))]
public class GameCameraFollow : MonoBehaviour
{
	public bool followX = true;

	public bool followY = true;

	public bool followZ = true;

	private Character myCharacter;

	private GameCameraBinding cameraBinding;

	private GameCamera gameCam;

	private bool bound;

	private void Awake()
	{
		myCharacter = GetComponent<Character>();
		cameraBinding = GetComponent<GameCameraBinding>();
		myCharacter.OnUpdateTic += HandleOnUpdateTic;
	}

	private void OnDestroy()
	{
		myCharacter.OnUpdateTic -= HandleOnUpdateTic;
		if (gameCam != null)
		{
			gameCam.OnPosChanged -= HandleOnCameraPosChanged;
		}
	}

	private void HandleOnUpdateTic(Character character)
	{
		if (!bound && cameraBinding.gameCamera != null)
		{
			bound = true;
			gameCam = cameraBinding.gameCamera;
			myCharacter.OnUpdateTic -= HandleOnUpdateTic;
			gameCam.OnPosChanged += HandleOnCameraPosChanged;
		}
	}

	private void HandleOnCameraPosChanged(GameCamera gameCamera)
	{
		if (followX)
		{
			myCharacter.PositionX = gameCamera.PositionX;
		}
		if (followY)
		{
			myCharacter.PositionY = gameCamera.PositionY;
		}
		if (followZ)
		{
			myCharacter.PositionZ = gameCamera.PositionZ;
		}
	}
}
