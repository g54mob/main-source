using UnityEngine;

public class JointEditorState : State<GameManager>
{
	private CreationButtonsController allJointsButtonsController;

	private JointEditorView jointEditorView;

	private Button3DEvents button3DEvents;

	private TopButtonsView topButtonsView;

	private StepByStepView stepByStepView;

	public static JointEditorState Instance { get; }

	static JointEditorState()
	{
		Instance = new JointEditorState();
	}

	private JointEditorState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		CreationButtonsView view = new GameObject("HingeJointButtonsObject").AddComponent<CreationButtonsView>();
		allJointsButtonsController = new CreationButtonsController(view, null, CreationButtonsController.ButtonTypeEnum.AllJoints);
		jointEditorView = gameManager.GUIManager.JointEditorView;
		topButtonsView = gameManager.GUIManager.TopButtonsView;
		stepByStepView = gameManager.GUIManager.StepByStepView;
		button3DEvents = new Button3DEvents(shouldCheckButtonId: true);
		button3DEvents.OnButton3DSelected += jointEditorView.AllJointsButtonSelectedHandler;
		button3DEvents.OnButton3DDeselected += jointEditorView.AllJointsButtonDeselectedHandler;
		button3DEvents.OnOverRestrictedZone += () => jointEditorView.IsMouseOverUI || topButtonsView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
	}

	public override void Enter(GameManager gameManager)
	{
		gameManager.MainCreationController.view.MakeCreationTransparent();
		gameManager.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Button3D);
		allJointsButtonsController.view.transform.SetParent(gameManager.MainCreationController.view.transform.parent);
		allJointsButtonsController.SetModel(gameManager.MainCreationController.model);
		allJointsButtonsController.view.SetVisibility(isVisible: true);
		jointEditorView.SetVisibility(isVisible: true);
		button3DEvents.Start();
	}

	public override void Execute(GameManager gameManager)
	{
		bool isTranslating = gameManager.CameraManager.OrbitCamera.IsTranslating;
		bool isRotating = gameManager.CameraManager.OrbitCamera.IsRotating;
		if (!isTranslating && !isRotating)
		{
			button3DEvents.Run();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			gameManager.ResetCameraPosition();
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			gameManager.PlayLevel();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameManager.ChangeState(ConstructionState.Instance);
		}
	}

	public override void Exit(GameManager gameManager)
	{
		button3DEvents.Stop();
		gameManager.MainCreationController.view.MakeCreationNormal();
		gameManager.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Default);
		allJointsButtonsController.view.SetVisibility(isVisible: false);
		jointEditorView.AllJointsButtonDeselectedHandler();
		jointEditorView.SetVisibility(isVisible: false);
	}

	public void UnSelectButton3D()
	{
		button3DEvents.UnSelectButton3D();
	}
}
