using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationController : BaseController<CreationView, CreationModel>
{
	private Coroutine rebuildCreationCoroutine;

	public bool IsAsyncBuild { get; set; }

	public event Action OnSyncViewWithModelStarted;

	public event Action OnSyncViewWithModelCompleted;

	public event Action<int> OnChangedBlocksCountEvent;

	public CreationController(CreationView view, CreationModel model, bool isAsyncBuild = false)
		: base(view, model, false)
	{
		IsAsyncBuild = isAsyncBuild;
		base.OnModelChanged += delegate(CreationModel creationModel, CreationModel lastModel)
		{
			this.OnChangedBlocksCountEvent?.Invoke(creationModel.BlockModelCount);
		};
	}

	public void StopRebuildCreationAsync()
	{
		if (rebuildCreationCoroutine != null)
		{
			view.StopCoroutine(rebuildCreationCoroutine);
		}
	}

	protected override void SyncViewWithModel()
	{
		IEnumerator enumerator = RebuildCreation();
		if (IsAsyncBuild)
		{
			if (this.OnSyncViewWithModelStarted != null)
			{
				this.OnSyncViewWithModelStarted();
			}
			rebuildCreationCoroutine = view.StartCoroutine(enumerator);
		}
		else
		{
			while (enumerator.MoveNext())
			{
			}
		}
	}

	private IEnumerator RebuildCreation()
	{
		view.ResetView();
		view.Id = model.Id;
		foreach (BlockModel item in model.GetAllBlockModel())
		{
			ModelChangeHandler("CreationModel.AddBlockEvent", item);
			foreach (BlockBodyModel allBlockBodyModel in item.GetAllBlockBodyModels())
			{
				if (allBlockBodyModel.TwoPointBlockModel != null)
				{
					ModelChangeHandler("CreationModel.AddTwoPointBlockEvent", allBlockBodyModel.TwoPointBlockModel);
				}
			}
			if (IsAsyncBuild)
			{
				yield return new WaitForEndOfFrame();
			}
		}
		foreach (BlockModel item2 in model.GetAllBlockModel())
		{
			foreach (BlockBodyModel allBlockBodyModel2 in item2.GetAllBlockBodyModels())
			{
				if (view.CreationRendererType != CreationView.CreationRendererTypeEnum.Rigid)
				{
					continue;
				}
				foreach (FixedJointModel item3 in allBlockBodyModel2.GetAllFixedJointModel())
				{
					ModelChangeHandler("CreationModel.FixedConnectTwoBlocksEvent", item3);
				}
				foreach (HingeJointModel item4 in allBlockBodyModel2.GetAllHingeJointModel())
				{
					ModelChangeHandler("CreationModel.HingeConnectTwoBlocksEvent", item4);
					if (item4.MotorJointModel != null)
					{
						ModelChangeHandler("CreationModel.AddMotorJointEvent", item4);
					}
					if (item4.SteerableJointModel != null)
					{
						ModelChangeHandler("CreationModel.AddSteerableJointEvent", item4);
					}
					if (item4.StepperJointModel != null)
					{
						ModelChangeHandler("CreationModel.AddStepperJointEvent", item4);
					}
					if (item4.MotorBlockBodyModel != null)
					{
						ModelChangeHandler("CreationModel.ConnectMotorToHingeJointEvent", item4);
					}
				}
			}
		}
		if (view.CreationRendererType == CreationView.CreationRendererTypeEnum.Rigid)
		{
			foreach (BlockModel item5 in model.GetAllBlockModel())
			{
				foreach (BlockBodyModel allBlockBodyModel3 in item5.GetAllBlockBodyModels())
				{
					foreach (DefaultKeyIO allDefaultKeyIO in allBlockBodyModel3.GetAllDefaultKeyIOs())
					{
						ModelChangeHandler("CreationModel.UpdateDefaultKeyEvent", allDefaultKeyIO);
					}
					foreach (OverridablePropertyModel allOverridableProperty in allBlockBodyModel3.GetAllOverridableProperties())
					{
						ModelChangeHandler("CreationModel.UpdateOverridablePropertyEvent", allOverridableProperty);
					}
				}
			}
			view.SetLogicSystem(model.LogicSystemModel);
			foreach (Logic allLogic in model.LogicSystemModel.GetAllLogics())
			{
				foreach (SocketIO allScoketIO in allLogic.GetAllScoketIOs())
				{
					if (allScoketIO.IsLogicIOAttached)
					{
						LogicIO logicIO = view.GetBlockView(allScoketIO.BlockId).GetBlockBodyView(allScoketIO.BodyIndex).GetLogicIO(allScoketIO.Name);
						if (logicIO != null)
						{
							allScoketIO.AttachIO(logicIO);
						}
						else
						{
							allScoketIO.DetachIO();
						}
					}
				}
			}
			ModelChangeHandler("CreationModel.UpdateInterconnectedBlocksEvent");
		}
		if (view.CreationRendererType == CreationView.CreationRendererTypeEnum.Placeholder)
		{
			view.gameObject.SetLayersRecursively(LayerNames.PlaceholderCreation);
		}
		view.SetPositions(model.Position, model.Rotation);
		if (view.IsGroupCentered)
		{
			view.CentralizeCreation();
		}
		view.SetAllOutlines(isEnabled: false);
		if (IsAsyncBuild && this.OnSyncViewWithModelCompleted != null)
		{
			this.OnSyncViewWithModelCompleted();
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "CreationModel.AddBrainBlockEvent":
			break;
		case "CreationModel.NewPositionEvent":
		{
			Vector3 localPosition = (Vector3)data[0];
			view.transform.localPosition = localPosition;
			break;
		}
		case "CreationModel.NewRotationEvent":
		{
			Quaternion localRotation = (Quaternion)data[0];
			view.transform.localRotation = localRotation;
			break;
		}
		case "CreationModel.AddBlockEvent":
		{
			BlockModel blockModel3 = (BlockModel)data[0];
			bool isGizmosVisible = GameManager.Instance.ConstructionToolsModel.IsGizmosVisible;
			view.AddBlockView(blockModel3, isGizmosVisible);
			break;
		}
		case "CreationModel.MergeCreationEvent":
		{
			CreationModel toMergeCreationModel = (CreationModel)data[0];
			view.MergeNewRigidCreation(toMergeCreationModel);
			break;
		}
		case "CreationModel.RemoveBlockEvent":
		{
			int blockId = (int)data[0];
			view.RemoveBlockView(blockId);
			break;
		}
		case "CreationModel.FixedConnectTwoBlocksEvent":
		{
			FixedJointModel fixedJointModel = (FixedJointModel)data[0];
			view.FixedConnectTwoBlocks(fixedJointModel);
			break;
		}
		case "CreationModel.RemoveFixedJointEvent":
		{
			FixedJointModel fixedJointModel = (FixedJointModel)data[0];
			view.RemoveFixedJoint(fixedJointModel);
			break;
		}
		case "CreationModel.HingeConnectTwoBlocksEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.HingeConnectTwoBlocks(hingeJointModel);
			break;
		}
		case "CreationModel.RemoveHingeJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.RemoveHingeJoint(hingeJointModel);
			break;
		}
		case "CreationModel.AddMotorJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.AddMotorJointView(hingeJointModel);
			break;
		}
		case "CreationModel.AddSteerableJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.AddSteerableJointView(hingeJointModel);
			break;
		}
		case "CreationModel.AddStepperJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.AddStepperJointView(hingeJointModel);
			break;
		}
		case "CreationModel.RemoveSpecializedJointsEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.RemoveSpecializedJointsView(hingeJointModel);
			break;
		}
		case "CreationModel.UpdateMotorJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.UpdateMotorJointView(hingeJointModel);
			break;
		}
		case "CreationModel.UpdateSteerableJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.UpdateSteerableJointView(hingeJointModel);
			break;
		}
		case "CreationModel.UpdateStepperJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.UpdateStepperJointView(hingeJointModel);
			break;
		}
		case "CreationModel.ConnectMotorToHingeJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.ConnectMotorToHingeJoint(hingeJointModel);
			break;
		}
		case "CreationModel.RemoveMotorFromHingeJointEvent":
		{
			HingeJointModel hingeJointModel = (HingeJointModel)data[0];
			view.RemoveMotorFromHingeJoint(hingeJointModel);
			break;
		}
		case "CreationModel.UpdateDefaultKeyEvent":
		{
			DefaultKeyIO defaultKey = (DefaultKeyIO)data[0];
			view.UpdateComponentKey(defaultKey);
			break;
		}
		case "CreationModel.UpdateOverridablePropertyEvent":
		{
			OverridablePropertyModel property = data[0] as OverridablePropertyModel;
			view.UpdateOverridableProperty(property);
			break;
		}
		case "CreationModel.UpdateInterconnectedBlocksEvent":
			view.UpdateInterconnectedBlocksForBuild();
			break;
		case "CreationModel.UpdateInterconnectedBlocksAfterJointEvent":
		{
			BlockModel blockModel = data[0] as BlockModel;
			BlockModel blockModel2 = data[1] as BlockModel;
			view.UpdateInterconnectedBlocksAfterJoint(blockModel.Id, blockModel2.Id);
			break;
		}
		case "CreationModel.UpdateLogicSystemEvent":
		{
			LogicSystemModel logicSystem = data[0] as LogicSystemModel;
			view.SetLogicSystem(logicSystem);
			break;
		}
		case "CreationModel.AddTwoPointBlockEvent":
		{
			TwoPointBlockModel twoPointBlockModel = (TwoPointBlockModel)data[0];
			view.AddTwoPointBlock(twoPointBlockModel);
			break;
		}
		case "CreationModel.ResetBlockIdsEvent":
		{
			Dictionary<int, int> idConverterMap = data[0] as Dictionary<int, int>;
			view.ResetBlockIds(idConverterMap);
			break;
		}
		case "CreationModel.ChangedBlocksCountEvent":
		{
			int obj = (int)data[0];
			this.OnChangedBlocksCountEvent?.Invoke(obj);
			break;
		}
		case "CreationModel.SetBlockOutlineEvent":
		{
			int blockId = (int)data[0];
			bool isEnabled = (bool)data[1];
			int colorLine = (int)data[2];
			view.SetBlockOutline(blockId, isEnabled, colorLine);
			break;
		}
		case "CreationModel.WarningMessageEvent":
			Debug.Log((string)data[0]);
			break;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "CreationView.BlockDestroyedEvent"))
		{
			if (eventName == "CreationView.DefaultKeyIOsOverwritabilityEvent")
			{
				int blockId = (int)data[0];
				int bodyIndex = (int)data[1];
				string[] defaultKeyIOids = (string[])data[2];
				bool shouldOverwrite = (bool)data[3];
				model.SetDefaultKeyIOsOverwritability(blockId, bodyIndex, defaultKeyIOids, shouldOverwrite);
			}
			return;
		}
		BlockView blockView = (BlockView)data[0];
		if (blockView.Schematic.Type == "brain")
		{
			CreationView parentCreationView = blockView.ParentCreationView;
			parentCreationView.IsBrainBlockDestroyed = true;
			parentCreationView.LogicSystemView.enabled = false;
			if (parentCreationView.CreationRole == CreationView.CreationRoleState.Attacker)
			{
				GameManager.Instance.LevelController.view.AttackerBrainDestroyedHandler();
			}
			else if (parentCreationView.CreationRole == CreationView.CreationRoleState.Defender)
			{
				GameManager.Instance.LevelController.view.DefenderBrainDestroyedHandler();
			}
		}
	}

	public void SetUserEditableBlocksVisibility(bool isVisible)
	{
		foreach (BlockView allBlockView in view.GetAllBlockViews())
		{
			if (model.GetBlockModel(allBlockView.Id).HasUserEditableProperties())
			{
				allBlockView.SetVisibility(isVisible);
			}
		}
	}

	public void SetUserLogicEditableBlocksVisibility(bool isVisible)
	{
		foreach (BlockView allBlockView in view.GetAllBlockViews())
		{
			if (model.GetBlockModel(allBlockView.Id).HasUserLogicEditableProperties())
			{
				allBlockView.SetVisibility(isVisible);
			}
		}
	}

	public void SetMotorBlocksVisibility(bool isVisible)
	{
		foreach (BlockView allBlockView in view.GetAllBlockViews())
		{
			if (model.GetBlockModel(allBlockView.Id).HasAnyMotorComponent())
			{
				allBlockView.SetVisibility(isVisible);
			}
		}
	}

	public void SetGizmosLayerForAllComponentViews(int layer)
	{
		foreach (BaseComponentView allComponentView in view.GetAllComponentViews())
		{
			allComponentView.SetGizmosLayer(layer);
		}
	}

	public void SetComponentGizmosVisibility(bool isVisible)
	{
		foreach (BaseComponentView allComponentView in view.GetAllComponentViews())
		{
			allComponentView.SetGizmosVisibility(isVisible);
		}
	}
}
