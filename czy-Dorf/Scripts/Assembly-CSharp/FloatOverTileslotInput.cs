using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FloatOverTileslotInput : MonoBehaviour
{
	[SerializeField]
	private InputActionReference pointerPosAction;

	[SerializeField]
	private InputActionReference inputAction;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private float overTileslotMultiplier = 1f;

	[SerializeField]
	private bool snapToOneOverTileslot;

	[SerializeField]
	private FloatEvent OnInputOverTileslot;

	[SerializeField]
	private float notOverTileslotMultiplier = 1f;

	[SerializeField]
	private FloatEvent OnInputNotOverTileslot;

	private Camera mainCamera;

	private TileSlot lastTileSlot;

	private TileSlot currentTileSlot;

	private bool receivingInput;

	private void UpdateInputCameraReference(Scene obj)
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		}
	}

	private void Start()
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			UpdateInputCameraReference(default(Scene));
		}
		sceneLoader.OnSceneLoaded += UpdateInputCameraReference;
	}

	private void Update()
	{
		DetermineCurrentTileSlot();
		float num = inputAction.action.ReadValue<float>();
		if (Mathf.Abs(num) > 0.1f)
		{
			receivingInput = true;
			if ((bool)currentTileSlot)
			{
				float arg = num * overTileslotMultiplier;
				if (snapToOneOverTileslot)
				{
					arg = num / Mathf.Abs(num);
				}
				OnInputOverTileslot?.Invoke(arg);
			}
			else
			{
				OnInputNotOverTileslot?.Invoke(num * notOverTileslotMultiplier);
			}
		}
		else if (receivingInput)
		{
			receivingInput = false;
		}
	}

	private void DetermineCurrentTileSlot()
	{
		if ((bool)mainCamera)
		{
			Physics.Raycast(mainCamera.ScreenPointToRay(Pointer.current.position.ReadValue()), out var hitInfo, 1000f, LayerMask.GetMask("TileSlot"));
			currentTileSlot = (hitInfo.collider ? hitInfo.collider.GetComponent<TileSlot>() : null);
			if (currentTileSlot != null && !currentTileSlot.IsValid)
			{
				currentTileSlot = null;
			}
		}
	}

	private void OnDestroy()
	{
		sceneLoader.OnSceneLoaded -= UpdateInputCameraReference;
	}
}
