using UnityEngine;

public class HingeEditorState : State<GameManager>
{
	private CreationButtonsController hingeJointButtonsController;

	private HingeEditorView hingeEditorView;

	private Button3DEvents button3DEvents;

	private HingeEditorDragAndDropEvents hingeEditorDragAndDropEvents;

	private TopButtonsView topButtonsView;

	private StepByStepView stepByStepView;

	public static HingeEditorState Instance { get; }

	static HingeEditorState()
	{
		Instance = new HingeEditorState();
	}

	private HingeEditorState()
	{
	}

	public override void Start(GameManager GAME)
	{
		CreationButtonsView view = new GameObject("HingeJointButtonsObject").AddComponent<CreationButtonsView>();
		hingeJointButtonsController = new CreationButtonsController(view, null, CreationButtonsController.ButtonTypeEnum.HingeJoint);
		hingeEditorView = GAME.GUIManager.HingeEditorView;
		topButtonsView = GAME.GUIManager.TopButtonsView;
		stepByStepView = GAME.GUIManager.StepByStepView;
		button3DEvents = new Button3DEvents(shouldCheckButtonId: true);
		button3DEvents.OnButton3DSelected += hingeEditorView.OnButton3DSelectedHandler;
		button3DEvents.OnButton3DDeselected += hingeEditorView.OnButton3DDeselectedHandler;
		button3DEvents.OnOverRestrictedZone += () => hingeEditorView.IsMouseOverUI || topButtonsView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
		hingeEditorDragAndDropEvents = new HingeEditorDragAndDropEvents(GAME);
		hingeEditorDragAndDropEvents.OnCanConnectMotorToHingeJoint += hingeEditorView.CanConnectMotorToHingeJointHandler;
		hingeEditorDragAndDropEvents.OnDisconnectHingeJointFromMotor += hingeEditorView.DisconnectMotorFromHingeJointHandler;
		hingeEditorDragAndDropEvents.OnOverRestrictedZone += () => hingeEditorView.IsMouseOverUI || topButtonsView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
	}

	public override void Enter(GameManager GAME)
	{
		GAME.MainCreationController.view.MakeCreationTransparent();
		GAME.MainCreationController.SetMotorBlocksVisibility(isVisible: false);
		GAME.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Button3D);
		GAME.MainCreationController.model.UpdateInterconnectedBlocksForModel();
		hingeJointButtonsController.view.transform.SetParent(GAME.MainCreationController.view.transform.parent);
		hingeJointButtonsController.SetModel(GAME.MainCreationController.model);
		hingeJointButtonsController.view.SetVisibility(isVisible: true);
		hingeEditorView.SetVisibility(isVisible: true);
		button3DEvents.Start();
	}

	public override void Execute(GameManager GAME)
	{
		if (!hingeEditorDragAndDropEvents.Run())
		{
			bool isTranslating = GAME.CameraManager.OrbitCamera.IsTranslating;
			bool isRotating = GAME.CameraManager.OrbitCamera.IsRotating;
			if (!isTranslating && !isRotating)
			{
				button3DEvents.Run();
			}
		}
		else
		{
			button3DEvents.Stop();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GAME.ResetCameraPosition();
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			GAME.PlayLevel();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GAME.ChangeState(ConstructionState.Instance);
		}
	}

	public override void Exit(GameManager GAME)
	{
		button3DEvents.Stop();
		GAME.MainCreationController.view.MakeCreationNormal();
		GAME.MainCreationController.SetMotorBlocksVisibility(isVisible: true);
		GAME.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Default);
		hingeJointButtonsController.view.SetVisibility(isVisible: false);
		hingeEditorView.OnButton3DDeselectedHandler();
		hingeEditorView.SetVisibility(isVisible: false);
		hingeEditorDragAndDropEvents.Stop();
	}

	public void UnSelectButton3D()
	{
		button3DEvents.UnSelectButton3D();
	}
}
