using UnityEngine;

public class ComponentPropertiesState : State<GameManager>
{
	private CreationButtonsController componentButtonsController;

	private ComponentPropertiesController componentPropertiesController;

	private ComponentPropertiesView componentPropertiesView;

	private Button3DEvents button3DEvents;

	private TopButtonsView topButtonsView;

	private StepByStepView stepByStepView;

	public static ComponentPropertiesState Instance { get; }

	static ComponentPropertiesState()
	{
		Instance = new ComponentPropertiesState();
	}

	private ComponentPropertiesState()
	{
	}

	public override void Start(GameManager GAME)
	{
		CreationButtonsView view = new GameObject("ComponentButtonsObject").AddComponent<CreationButtonsView>();
		componentButtonsController = new CreationButtonsController(view, null, CreationButtonsController.ButtonTypeEnum.Component);
		componentPropertiesController = GAME.GUIManager.ComponentPropertiesController;
		componentPropertiesView = GAME.GUIManager.ComponentPropertiesView;
		topButtonsView = GAME.GUIManager.TopButtonsView;
		stepByStepView = GAME.GUIManager.StepByStepView;
		button3DEvents = new Button3DEvents(shouldCheckButtonId: true);
		button3DEvents.OnButton3DSelected += delegate(Button3D button)
		{
			componentPropertiesView.OnComponentSelected(button);
		};
		button3DEvents.OnButton3DDeselected += delegate
		{
			componentPropertiesView.OnComponentDeselected();
		};
		button3DEvents.OnOverRestrictedZone += () => componentPropertiesView.IsMouseOverUI || topButtonsView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
	}

	public override void Enter(GameManager GAME)
	{
		GAME.MainCreationController.view.MakeCreationTransparent();
		GAME.MainCreationController.SetUserEditableBlocksVisibility(isVisible: false);
		GAME.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Button3D);
		componentButtonsController.view.transform.SetParent(GAME.MainCreationController.view.transform.parent);
		componentButtonsController.SetModel(GAME.MainCreationController.model);
		componentButtonsController.view.SetVisibility(isVisible: true);
		componentPropertiesView.SetVisibility(isVisible: true);
		button3DEvents.Start();
	}

	public override void Execute(GameManager GAME)
	{
		bool isTranslating = GAME.CameraManager.OrbitCamera.IsTranslating;
		bool isRotating = GAME.CameraManager.OrbitCamera.IsRotating;
		if (!isTranslating && !isRotating)
		{
			button3DEvents.Run();
		}
		if (Input.GetKeyDown(KeyCode.Space) && !componentPropertiesController.IsKeyboardInUse)
		{
			GAME.ResetCameraPosition();
		}
		if (Input.GetKeyDown(KeyCode.P) && !componentPropertiesController.IsKeyboardInUse)
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
		GAME.MainCreationController.SetUserEditableBlocksVisibility(isVisible: true);
		GAME.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Default);
		componentButtonsController.view.SetVisibility(isVisible: false);
		componentPropertiesView.OnComponentDeselected();
		componentPropertiesView.SetVisibility(isVisible: false);
	}

	public void UnSelectButton3D()
	{
		button3DEvents.UnSelectButton3D();
	}
}
