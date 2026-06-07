using System.IO;

public class StartLevelState : State<GameManager>
{
	public static StartLevelState Instance { get; }

	static StartLevelState()
	{
		Instance = new StartLevelState();
	}

	private StartLevelState()
	{
	}

	public override void Start(GameManager GAME)
	{
	}

	public override void Enter(GameManager GAME)
	{
		if (GAME.GameMode == GameManager.GameModeState.Attacker)
		{
			CreationModel creationModel = ((GAME.LevelController.model.Place == LevelModel.LevelPlace.Tutorial) ? GAME.TutorialManager.GetClonedCreationModel(GAME.LevelController.model.GetId()) : ((!File.Exists(PathNames.CurrentCreationDataAES)) ? new CreationModel("", "", "") : CreationModelBuilder.LoadXml(PathNames.CurrentCreationDataAES, GAME.SchematicCollection, isFileEncrypted: true)));
			GAME.MainCreationsManager.MainCreationController = GAME.AttackerCreationController;
			if (creationModel != null)
			{
				GAME.AttackerCreationController.SetModel(creationModel);
			}
			if (GAME.LevelManager.HasDefenderZone)
			{
				GAME.DefenderCreationController.SetModel(GAME.LevelController.model.DefenderCreationModel);
				GAME.DefenderCreationController.view.SetEditableAndPlayable(isEditable: false, isPlayable: false);
			}
		}
		else if (GAME.GameMode == GameManager.GameModeState.Defender)
		{
			CreationModel model = CreationCloner.Clone(GAME.LevelController.model.DefenderCreationModel);
			GAME.MainCreationsManager.MainCreationController = GAME.DefenderCreationController;
			GAME.DefenderCreationController.SetModel(model);
		}
		GAME.MainCreationController.view.SetEditableAndPlayable(isEditable: true, isPlayable: true);
		GAME.ConstructionCommandManager.ClearAllCommands();
		QuickInventoryModel quickInventoryModel = ((GAME.LevelController.model.Place != LevelModel.LevelPlace.Tutorial) ? GAME.MainQuickInventoryModel : GAME.TutorialManager.GetClonedQuickInventoryModel(GAME.LevelController.model.GetId()));
		if (quickInventoryModel != null && quickInventoryModel != GAME.QuickInventoryController.model)
		{
			GAME.QuickInventoryController.SetModel(quickInventoryModel);
		}
		if (GAME.LevelController.model.Place == LevelModel.LevelPlace.Tutorial)
		{
			GAME.GUIManager.StepByStepController.view.SetTutorialPage(GAME.LevelController.model.GetId());
			GAME.GUIManager.StepByStepController.view.ResetWindowPosition();
		}
		LevelUtil.SetLevelMusic(GAME.LevelController.model);
		GAME.VisualEffectsManager.DestroyAllEffects();
	}

	public override void Execute(GameManager GAME)
	{
		GAME.ChangeState(LevelPreviewState.Instance);
	}

	public override void Exit(GameManager GAME)
	{
	}
}
