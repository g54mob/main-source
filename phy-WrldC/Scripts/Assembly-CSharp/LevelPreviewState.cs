using System.Collections;
using UnityEngine;

public class LevelPreviewState : State<GameManager>
{
	private LevelPreviewView levelPreviewView;

	private Coroutine levelPreviewCoroutine;

	private bool wasAnyKeyPressed;

	private bool isExiting;

	public static LevelPreviewState Instance { get; }

	static LevelPreviewState()
	{
		Instance = new LevelPreviewState();
	}

	private LevelPreviewState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		levelPreviewView = gameManager.GUIManager.LevelPreviewView;
	}

	public override void Enter(GameManager gameManager)
	{
		gameManager.CameraManager.SetLockMainCamera(isLocked: true);
		levelPreviewCoroutine = gameManager.StartCoroutine(OnLevelPreviewCoroutine(gameManager));
		wasAnyKeyPressed = false;
		isExiting = false;
	}

	public override void Execute(GameManager gameManager)
	{
		if (!isExiting)
		{
			if (Input.anyKey)
			{
				wasAnyKeyPressed = true;
			}
			if (!Input.anyKey && wasAnyKeyPressed)
			{
				gameManager.StopCoroutine(levelPreviewCoroutine);
				gameManager.StartCoroutine(ExitByKeyPress());
				isExiting = true;
			}
		}
		IEnumerator ExitByKeyPress()
		{
			yield return new WaitForEndOfFrame();
			Vector3 position = LevelManager.Instance.SelectedZone.transform.position;
			gameManager.CameraManager.OrbitCamera.SetTargetPosition(position);
			gameManager.ChangeState(ConstructionState.Instance);
		}
	}

	public override void Exit(GameManager gameManager)
	{
		levelPreviewView.SetVisibility(isVisible: false);
		gameManager.CameraManager.SetLockMainCamera(isLocked: false);
		gameManager.CameraManager.OrbitCamera.TargetMovementDuration = 0.5f;
		gameManager.MainCreationsManager.RestoreLastCameraPositionWhenBuilt();
	}

	private IEnumerator OnLevelPreviewCoroutine(GameManager gameManager)
	{
		levelPreviewView.SetVisibility(isVisible: true);
		levelPreviewView.SetLevelModel(gameManager.LevelController.model);
		Vector3 position = LevelManager.Instance.goalZone.transform.position;
		Vector3 startZonePosition = LevelManager.Instance.SelectedZone.transform.position;
		if (LevelManager.Instance.customStartPreviewPoint != null)
		{
			position = LevelManager.Instance.customStartPreviewPoint.position;
		}
		if (LevelManager.Instance.customEndPreviewPoint != null)
		{
			startZonePosition = LevelManager.Instance.customEndPreviewPoint.position;
		}
		float num = Vector3.Distance(startZonePosition, position);
		float zoneDistanceFactor = Mathf.Clamp(num / 30f, 1f, 4f);
		Debug.Log("Zones Distance: " + num + " Factor: " + zoneDistanceFactor);
		gameManager.CameraManager.OrbitCamera.SetAngles(25f, 45f, isMoveImmediately: true);
		gameManager.CameraManager.OrbitCamera.SetZoomDistance(-12f);
		gameManager.CameraManager.OrbitCamera.SetTargetPosition(position, isMoveImmediately: true);
		yield return new WaitForSeconds(2f);
		gameManager.CameraManager.OrbitCamera.TargetMovementDuration = 5f * zoneDistanceFactor;
		gameManager.CameraManager.OrbitCamera.SetTargetPosition(startZonePosition);
		yield return new WaitForSeconds(5f * zoneDistanceFactor);
		gameManager.CameraManager.OrbitCamera.TargetMovementDuration = 0.5f;
		gameManager.CameraManager.OrbitCamera.SetTargetPosition(LevelManager.Instance.SelectedZone.transform.position);
		yield return new WaitForSeconds(1f);
		gameManager.ChangeState(ConstructionState.Instance);
	}
}
