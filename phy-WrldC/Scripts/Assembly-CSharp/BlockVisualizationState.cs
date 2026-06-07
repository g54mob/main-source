using UnityEngine;

public class BlockVisualizationState : State<GameManager>
{
	private Camera camera;

	private OrbitCamera orbitCamera;

	private CreationController creationController;

	private GameObject creationViewObject;

	private GameObject connectorsObject;

	private GameObject selectedPivotPointObject;

	private GameObject mouseOverPivotPointObject;

	private GameObject currentBlockBodyObject;

	private GameObject selectedBlockBodyObject;

	private CreationModel selectedCreationModel;

	private GameObject blockVisualizationFolder;

	private BlockVisualizationView blockVisualizationView;

	private bool isNewConnectorSelected;

	private BlockVisualizationMouseOverEvents blockVisualizationMouseOverEvents;

	public static BlockVisualizationState Instance { get; }

	static BlockVisualizationState()
	{
		Instance = new BlockVisualizationState();
	}

	private BlockVisualizationState()
	{
	}

	public override void Start(GameManager GAME)
	{
		blockVisualizationFolder = GAME.blockVisualizationFolder;
		blockVisualizationView = GAME.GUIManager.BlockVisualizationView;
		camera = blockVisualizationFolder.transform.FindComponent<Camera>("Camera", isRecursively: true);
		orbitCamera = blockVisualizationFolder.transform.FindComponent<OrbitCamera>("Block Orbit Camera");
		orbitCamera.SetMouseTranslationActive(value: false);
		orbitCamera.SetKeyboardTranslationActive(value: false);
		orbitCamera.TargetMaskLayers = LayerNames.BlockVisualizationMask;
		selectedPivotPointObject = Object.Instantiate(GAME.connectorFixedPrefab, blockVisualizationFolder.transform);
		selectedPivotPointObject.name = "SelectedConnector";
		selectedPivotPointObject.SetLayersRecursively(LayerNames.BlockVisualization);
		mouseOverPivotPointObject = Object.Instantiate(GAME.connectorFixedPrefab, blockVisualizationFolder.transform);
		mouseOverPivotPointObject.name = "MouseOverConnector";
		mouseOverPivotPointObject.GetComponent<Renderer>().material.color = new Color(0.5f, 1f, 0.5f, 0.8f);
		mouseOverPivotPointObject.SetLayersRecursively(LayerNames.BlockVisualization);
		mouseOverPivotPointObject.SetActive(value: false);
		blockVisualizationMouseOverEvents = new BlockVisualizationMouseOverEvents(camera);
		blockVisualizationMouseOverEvents.OnMouseEnterBlockBodyObject += MouseEnterBlockBodyObjectHandler;
		blockVisualizationMouseOverEvents.OnMouseExitBlockBodyObject += MouseExitBlockBodyObjectHandler;
		blockVisualizationMouseOverEvents.OnMouseEnterConnector += MouseEnterConnectorHandler;
		blockVisualizationMouseOverEvents.OnMouseOverConnector += MouseOverConnectorHandler;
		blockVisualizationMouseOverEvents.OnMouseExitConnector += MouseExitConnectorHandler;
	}

	public override void Enter(GameManager GAME)
	{
		selectedCreationModel = GAME.GetSelectedPlaceholderCreation();
		if (creationController == null)
		{
			creationController = CreationControllerBuilder.BuildModelController(selectedCreationModel, blockVisualizationFolder.transform);
		}
		else
		{
			creationController.SetModel(selectedCreationModel);
		}
		creationViewObject = creationController.view.gameObject;
		creationViewObject.SetLayersRecursively(LayerNames.BlockVisualization);
		orbitCamera.TranslationBoundaries = creationController.view.GetCreationBounds().extents;
		int selectedBlockId = selectedCreationModel.SelectedBlockId;
		int selectedBodyIndex = selectedCreationModel.SelectedBodyIndex;
		BlockView blockView = creationController.view.GetBlockView(selectedBlockId);
		currentBlockBodyObject = blockView.GetBlockBodyView(selectedBodyIndex).gameObject;
		CreationUtil.PositionConnector(selectedCreationModel, blockView.gameObject, selectedPivotPointObject);
		orbitCamera.SetTarget(creationViewObject.transform);
		orbitCamera.SetMouseTranslationActive(value: true);
		CreateConnectorsGrid(GAME);
		GAME.CameraManager.SetLockMainCamera(isLocked: true);
		blockVisualizationFolder.SetActive(value: true);
		blockVisualizationView.SetVisibility(isVisible: true);
		blockVisualizationView.FitCameraInContentPanel(camera);
		isNewConnectorSelected = false;
	}

	public override void Execute(GameManager GAME)
	{
		blockVisualizationMouseOverEvents.Run();
		if (ChangeConnectorGridSize(GAME))
		{
			CreateConnectorsGrid(GAME);
		}
		if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.Escape))
		{
			GAME.RevertToPreviousState();
		}
	}

	public override void Exit(GameManager GAME)
	{
		if (isNewConnectorSelected)
		{
			CreationUtil.SetPivotPoint(selectedCreationModel, selectedBlockBodyObject, selectedPivotPointObject);
		}
		blockVisualizationMouseOverEvents.Stop();
		if (connectorsObject != null)
		{
			Object.Destroy(connectorsObject);
		}
		GAME.CameraManager.SetLockMainCamera(isLocked: false);
		blockVisualizationFolder.SetActive(value: false);
		blockVisualizationView.SetVisibility(isVisible: false);
	}

	private void MouseEnterBlockBodyObjectHandler(GameObject blockBodyObject)
	{
		currentBlockBodyObject = blockBodyObject;
		CreateConnectorsGrid(GameManager.Instance);
	}

	private void MouseExitBlockBodyObjectHandler(GameObject blockBodyObject)
	{
		mouseOverPivotPointObject.SetActive(value: false);
	}

	private void MouseEnterConnectorHandler(GameObject blockBodyObject, Vector3 connectorPosition, Quaternion connectorRotation, Vector3 raycastHitNormal)
	{
		mouseOverPivotPointObject.transform.position = connectorPosition;
		mouseOverPivotPointObject.transform.rotation = connectorRotation;
		mouseOverPivotPointObject.SetActive(value: true);
	}

	private void MouseOverConnectorHandler(GameObject blockBodyObject, Vector3 connectorPosition, Quaternion connectorRotation, Vector3 raycastHitNormal)
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && (!(selectedPivotPointObject != null) || !(selectedPivotPointObject.transform.position == connectorPosition) || !(selectedPivotPointObject.transform.rotation == connectorRotation)))
		{
			selectedBlockBodyObject = blockBodyObject;
			selectedPivotPointObject.transform.position = connectorPosition;
			selectedPivotPointObject.transform.rotation = connectorRotation;
			isNewConnectorSelected = true;
			AudioClip buttonMouseClickClip = GameManager.Instance.GameStylesData.buttonMouseClickClip;
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(buttonMouseClickClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
	}

	private void MouseExitConnectorHandler()
	{
		mouseOverPivotPointObject.SetActive(value: false);
	}

	private bool ChangeConnectorGridSize(GameManager GAME)
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Minus))
		{
			if (Input.GetKeyDown(KeyCode.Equals))
			{
				GAME.ConstructionToolsModel.ConnectorGridSize++;
			}
			if (Input.GetKeyDown(KeyCode.Minus))
			{
				GAME.ConstructionToolsModel.ConnectorGridSize--;
			}
			GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.toolKeyPressedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
			return true;
		}
		return false;
	}

	private void CreateConnectorsGrid(GameManager GAME)
	{
		if (connectorsObject != null)
		{
			Object.Destroy(connectorsObject);
		}
		BlockBodyView blockBodyView = currentBlockBodyObject.GetBlockBodyView();
		connectorsObject = BlockDecorator.DrawBlockConnectors(blockBodyView.ParentBlockView, GAME.connectorGridPrefab, GAME.connectorColliderPrefab, GAME.ConstructionToolsModel.ConnectorGridSize);
		connectorsObject.SetLayersRecursively(LayerNames.Connector);
	}
}
