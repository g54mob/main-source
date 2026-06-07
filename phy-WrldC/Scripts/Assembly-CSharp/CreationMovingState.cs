using UnityEngine;

public class CreationMovingState : State<GameManager>
{
	private ConstructionToolsModel constructionToolsModel;

	private TransformGizmoEvents transformGizmoEvents;

	public static CreationMovingState Instance { get; }

	static CreationMovingState()
	{
		Instance = new CreationMovingState();
	}

	private CreationMovingState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		GameObject gameObject = Object.Instantiate(gameManager.transformGizmo3DPrefab);
		gameObject.SetActive(value: false);
		transformGizmoEvents = new TransformGizmoEvents(gameObject, gameManager.CameraManager.OrbitCamera.gameObject);
		transformGizmoEvents.IsWithoutDelimitationZone = gameManager.CheatModel.IsWithoutDelimitationZone;
		transformGizmoEvents.OnPositionChanged += OnCreationPositionChanged;
		constructionToolsModel = gameManager.ConstructionToolsModel;
		constructionToolsModel.NotifyChangeEvent += ConstructionTooslModelChangeHandler;
		gameManager.CheatModel.NotifyChangeEvent += CheatModelNotifyChangeHandler;
	}

	public override void Enter(GameManager gameManager)
	{
		transformGizmoEvents.Start(gameManager.MainCreationController, gameManager.LevelManager.SelectedZone);
	}

	public override void Execute(GameManager gameManager)
	{
		transformGizmoEvents.Run();
		bool flag = Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape);
		if (flag || !constructionToolsModel.IsMovingToolEnabled)
		{
			if (flag)
			{
				gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.toolKeyPressedClip, gameManager.GameStylesData.volumeStylesData.uiVolume);
			}
			GameManager.Instance.ChangeState(ConstructionState.Instance);
		}
	}

	public override void Exit(GameManager gameManager)
	{
		transformGizmoEvents.Stop();
		if (constructionToolsModel.IsMovingToolEnabled)
		{
			constructionToolsModel.IsMovingToolEnabled = false;
		}
	}

	private void OnCreationPositionChanged(Vector3 newPosition, Quaternion newRotation)
	{
		GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(new NewPositionCommand(GameManager.Instance.MainCreationController.model, newPosition, newRotation));
	}

	private void ConstructionTooslModelChangeHandler(string eventName, object[] data)
	{
		if (GameManager.Instance.GetCurrentState() == this && (eventName == "ConstructionToolsModel.UndoCommandEvent" || eventName == "ConstructionToolsModel.RedoCommandEvent") && constructionToolsModel.IsMovingToolEnabled)
		{
			constructionToolsModel.IsMovingToolEnabled = false;
		}
	}

	private void CheatModelNotifyChangeHandler(string eventName, object[] data)
	{
		if (eventName == "CheatModel.DelimitationZoneChangedEvent")
		{
			bool isWithoutDelimitationZone = (bool)data[0];
			transformGizmoEvents.IsWithoutDelimitationZone = isWithoutDelimitationZone;
		}
	}
}
