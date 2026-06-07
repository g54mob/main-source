using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogicEditorState : State<GameManager>
{
	private LogicEditorView logicEditorView;

	private LogicEditorController logicEditorController;

	private CreationButtonsController logicIOButtonsController;

	private Button3DEvents button3DEvents;

	private PointerEventData slotPointerEventData;

	private InstructionSlotBase currentInstructionSlot;

	private LogicSlot currentLogicSlot;

	public static LogicEditorState Instance { get; }

	static LogicEditorState()
	{
		Instance = new LogicEditorState();
	}

	private LogicEditorState()
	{
	}

	public override void Start(GameManager GAME)
	{
		logicEditorView = GAME.GUIManager.LogicEditorView;
		logicEditorController = GAME.GUIManager.LogicEditorController;
		GameObject gameObject = new GameObject("Logic-ComponentButtonsObject");
		gameObject.transform.SetParent(GAME.MainCreationController.view.transform.parent);
		CreationButtonsView creationButtonsView = gameObject.AddComponent<CreationButtonsView>();
		creationButtonsView.ShouldIncludeOnlyOutputKeys = true;
		logicIOButtonsController = new CreationButtonsController(creationButtonsView, null, CreationButtonsController.ButtonTypeEnum.LogicIO);
		GAME.GUIManager.LogicEditorController.CreationButtonsController = logicIOButtonsController;
		TopButtonsView topButtonsView = GAME.GUIManager.TopButtonsView;
		StepByStepView stepByStepView = GAME.GUIManager.StepByStepView;
		button3DEvents = new Button3DEvents(shouldCheckButtonId: true);
		button3DEvents.OnButton3DSelected += delegate(Button3D button)
		{
			logicEditorView.LogicEditorBlockIOView.OnBlockSelected(button);
		};
		button3DEvents.OnButton3DDeselected += delegate
		{
			logicEditorView.LogicEditorBlockIOView.OnBlockDeselected();
		};
		button3DEvents.OnOverRestrictedZone += () => logicEditorView.IsMouseOverUI || topButtonsView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
		slotPointerEventData = new PointerEventData(EventSystem.current);
		currentInstructionSlot = null;
		currentLogicSlot = null;
	}

	public override void Enter(GameManager GAME)
	{
		GAME.MainCreationController.view.MakeCreationTransparent();
		GAME.MainCreationController.SetUserLogicEditableBlocksVisibility(isVisible: false);
		GAME.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Button3D);
		logicIOButtonsController.view.transform.SetParent(GAME.MainCreationController.view.transform.parent);
		logicIOButtonsController.SetModel(GAME.MainCreationController.model);
		logicIOButtonsController.view.SetVisibility(isVisible: true);
		GAME.GUIManager.LogicEditorController.SetModel(GAME.MainCreationController.model.LogicSystemModel);
		logicEditorView.SetVisibility(isVisible: true);
		logicEditorView.SelectUserLogic(0);
		logicEditorView.LogicEditorBlockIOView.OnBlockDeselected();
		button3DEvents.Start();
	}

	public override void Execute(GameManager GAME)
	{
		button3DEvents.Run();
		bool isKeyboardInUse = logicEditorController.IsKeyboardInUse;
		bool isBeingDrag = logicEditorController.IsBeingDrag;
		if (!isBeingDrag && (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.L) && !isKeyboardInUse)))
		{
			GAME.ChangeState(ConstructionState.Instance);
		}
		bool flag = logicEditorView.LogicEditorSelectedLogicView.IsMouseOverInstructionsPanel || logicEditorView.LogicEditorUserLogicView.IsMouseOverLogicsPanel;
		if (Input.GetKey(KeyCode.LeftControl) && flag && !isKeyboardInUse && !isBeingDrag)
		{
			CopyOrDuplicateSlots();
			if (GAME.CameraManager.OrbitCamera.IsKeyboardTranslationActive)
			{
				GAME.CameraManager.OrbitCamera.SetKeyboardTranslationActive(value: false);
			}
		}
		else
		{
			if (currentInstructionSlot != null)
			{
				currentInstructionSlot.SetSlotHighlight(isHighlighted: false);
				currentInstructionSlot = null;
			}
			if (currentLogicSlot != null)
			{
				currentLogicSlot.SetSlotHighlight(isHighlighted: false);
				currentLogicSlot = null;
			}
			if (!GAME.CameraManager.OrbitCamera.IsKeyboardTranslationActive && !isKeyboardInUse)
			{
				GAME.CameraManager.OrbitCamera.SetKeyboardTranslationActive(value: true);
			}
		}
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V) && !isKeyboardInUse && !isBeingDrag)
		{
			Logic selectedLogic = logicEditorView.LogicEditorSelectedLogicView.GetSelectedLogic();
			Instruction clipboardInstruction = logicEditorController.ClipboardInstruction;
			if (selectedLogic != null && clipboardInstruction != null)
			{
				logicEditorView.LogicEditorSelectedLogicView.ShouldBlinkNextNewSlot = true;
				Instruction instruction = LogicSystemModelBuilder.CloneInstruction(clipboardInstruction);
				selectedLogic.InstructionsList.AddInstruction(instruction);
				logicEditorView.LogicEditorSelectedLogicView.AddInstructionSlots(instruction, selectedLogic.InstructionsList, null);
				AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
				GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
			}
		}
	}

	public override void Exit(GameManager GAME)
	{
		button3DEvents.Stop();
		GAME.MainCreationController.view.MakeCreationNormal();
		GAME.MainCreationController.SetUserLogicEditableBlocksVisibility(isVisible: true);
		GAME.MainCreationController.SetGizmosLayerForAllComponentViews(LayerNames.Default);
		GAME.MainCreationController.model.UpdateDefaultKeysControlledByLogic();
		logicIOButtonsController.view.SetVisibility(isVisible: false);
		logicEditorView.SetVisibility(isVisible: false);
	}

	public void CopyOrDuplicateSlots()
	{
		slotPointerEventData.position = Input.mousePosition;
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(slotPointerEventData, list);
		if (list.Count <= 0)
		{
			return;
		}
		if (logicEditorView.LogicEditorSelectedLogicView.IsMouseOverInstructionsPanel)
		{
			InstructionSlotBase componentInParent = list[0].gameObject.GetComponentInParent<InstructionSlotBase>();
			if (componentInParent != null)
			{
				if (currentInstructionSlot != componentInParent)
				{
					if (currentInstructionSlot != null)
					{
						currentInstructionSlot.SetSlotHighlight(isHighlighted: false);
					}
					componentInParent.SetSlotHighlight(isHighlighted: true);
				}
				currentInstructionSlot = componentInParent;
				if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.C))
				{
					Instruction instruction = componentInParent.GetInstruction();
					Instruction instruction2 = LogicSystemModelBuilder.CloneInstruction(instruction);
					if (Input.GetKeyDown(KeyCode.D))
					{
						logicEditorView.LogicEditorSelectedLogicView.ShouldBlinkNextNewSlot = true;
						instruction.ParentInstructionList.AddInstruction(instruction2);
						logicEditorView.LogicEditorSelectedLogicView.AddInstructionSlots(instruction2, instruction.ParentInstructionList, componentInParent.transform.parent);
					}
					else if (Input.GetKeyDown(KeyCode.C))
					{
						logicEditorController.ClipboardInstruction = instruction2;
					}
					AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
					GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
				}
			}
		}
		if (!logicEditorView.LogicEditorUserLogicView.IsMouseOverLogicsPanel)
		{
			return;
		}
		LogicSlot componentInParent2 = list[0].gameObject.GetComponentInParent<LogicSlot>();
		if (!(componentInParent2 != null))
		{
			return;
		}
		if (currentInstructionSlot != componentInParent2)
		{
			if (currentLogicSlot != null)
			{
				currentLogicSlot.SetSlotHighlight(isHighlighted: false);
			}
			componentInParent2.SetSlotHighlight(isHighlighted: true);
		}
		currentLogicSlot = componentInParent2;
		if (Input.GetKeyDown(KeyCode.D))
		{
			logicEditorView.LogicEditorUserLogicView.ShouldBlinkNextNewSlot = true;
			Logic logic = LogicSystemModelBuilder.CloneLogic(componentInParent2.Logic);
			GameManager.Instance.MainCreationsManager.MainCreationController.model.LogicSystemModel.AddLogic(logic);
			AudioClip slotDropInClip2 = GameManager.Instance.GameStylesData.slotDropInClip;
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip2, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
	}
}
