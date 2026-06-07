using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreationModel : BaseModel
{
	public enum CreationPlace
	{
		User = 0,
		Workshop = 1
	}

	public const string NewPositionEvent = "CreationModel.NewPositionEvent";

	public const string NewRotationEvent = "CreationModel.NewRotationEvent";

	public const string AddBlockEvent = "CreationModel.AddBlockEvent";

	public const string RemoveBlockEvent = "CreationModel.RemoveBlockEvent";

	public const string MergeCreationEvent = "CreationModel.MergeCreationEvent";

	public const string ChangedBlocksCountEvent = "CreationModel.ChangedBlocksCountEvent";

	public const string AddBrainBlockEvent = "CreationModel.AddBrainBlockEvent";

	public const string RemoveBrainBlockEvent = "CreationModel.RemoveBrainBlockEvent";

	public const string FixedConnectTwoBlocksEvent = "CreationModel.FixedConnectTwoBlocksEvent";

	public const string RemoveFixedJointEvent = "CreationModel.RemoveFixedJointEvent";

	public const string HingeConnectTwoBlocksEvent = "CreationModel.HingeConnectTwoBlocksEvent";

	public const string RemoveHingeJointEvent = "CreationModel.RemoveHingeJointEvent";

	public const string AddMotorJointEvent = "CreationModel.AddMotorJointEvent";

	public const string AddSteerableJointEvent = "CreationModel.AddSteerableJointEvent";

	public const string AddStepperJointEvent = "CreationModel.AddStepperJointEvent";

	public const string RemoveSpecializedJointsEvent = "CreationModel.RemoveSpecializedJointsEvent";

	public const string UpdateMotorJointEvent = "CreationModel.UpdateMotorJointEvent";

	public const string UpdateSteerableJointEvent = "CreationModel.UpdateSteerableJointEvent";

	public const string UpdateStepperJointEvent = "CreationModel.UpdateStepperJointEvent";

	public const string ConnectMotorToHingeJointEvent = "CreationModel.ConnectMotorToHingeJointEvent";

	public const string RemoveMotorFromHingeJointEvent = "CreationModel.RemoveMotorFromHingeJointEvent";

	public const string UpdateDefaultKeyEvent = "CreationModel.UpdateDefaultKeyEvent";

	public const string UpdateOverridablePropertyEvent = "CreationModel.UpdateOverridablePropertyEvent";

	public const string UpdateInterconnectedBlocksEvent = "CreationModel.UpdateInterconnectedBlocksEvent";

	public const string UpdateInterconnectedBlocksAfterJointEvent = "CreationModel.UpdateInterconnectedBlocksAfterJointEvent";

	public const string UpdateLogicSystemEvent = "CreationModel.UpdateLogicSystemEvent";

	public const string AddTwoPointBlockEvent = "CreationModel.AddTwoPointBlockEvent";

	public const string ResetBlockIdsEvent = "CreationModel.ResetBlockIdsEvent";

	public const string SetBlockOutlineEvent = "CreationModel.SetBlockOutlineEvent";

	public const string UpdateDefaultKeysControlledByLogicEvent = "CreationModel.UpdateDefaultKeysControlledByLogicEvent";

	public const string WarningMessageEvent = "CreationModel.WarningMessageEvent";

	private Vector3 position;

	private Quaternion rotation;

	private readonly Dictionary<int, BlockModel> blockModelsMap;

	private readonly Dictionary<string, string> keysGroupLabelsMap;

	private LogicSystemModel logicSystemModel;

	public string Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public int SelectedBlockId { get; set; }

	public int SelectedBodyIndex { get; set; }

	public List<Vector3> DefaultConnectors { get; set; }

	public bool IsDeletable { get; set; }

	public string FilePath { get; set; }

	public DateTime FileLastModifiedDate { get; set; }

	public BlockModel BrainBlockModel { get; private set; }

	public LogicSystemModel LogicSystemModel
	{
		get
		{
			return logicSystemModel;
		}
		set
		{
			logicSystemModel = value;
			NotifyChange("CreationModel.UpdateLogicSystemEvent", logicSystemModel);
		}
	}

	public bool IsOriginatedFromSchematic { get; private set; }

	public CreationPlace Place { get; set; }

	public Vector3 Position
	{
		get
		{
			return position;
		}
		set
		{
			position = value;
			NotifyChange("CreationModel.NewPositionEvent", position);
		}
	}

	public Quaternion Rotation
	{
		get
		{
			return rotation;
		}
		set
		{
			rotation = value;
			NotifyChange("CreationModel.NewRotationEvent", rotation);
		}
	}

	public int BlockModelCount => blockModelsMap.Count;

	public CreationModel(string id, string name, string description, bool isOriginatedFromSchematic = false)
	{
		Id = id;
		Name = name;
		Description = description;
		IsOriginatedFromSchematic = isOriginatedFromSchematic;
		Place = CreationPlace.User;
		Position = Vector3.zero;
		Rotation = default(Quaternion);
		SelectedBlockId = 0;
		SelectedBodyIndex = 0;
		DefaultConnectors = new List<Vector3>();
		IsDeletable = false;
		FilePath = null;
		FileLastModifiedDate = DateTime.Now;
		LogicSystemModel = new LogicSystemModel();
		blockModelsMap = new Dictionary<int, BlockModel>();
		keysGroupLabelsMap = new Dictionary<string, string>();
	}

	public void ResetBlocksIds(int baseId = 0)
	{
		BlockModel[] array = blockModelsMap.Values.ToArray();
		blockModelsMap.Clear();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < array.Length; i++)
		{
			int num = i + baseId;
			dictionary.Add(array[i].Id, num);
			array[i].Id = num;
			blockModelsMap.Add(num, array[i]);
		}
		foreach (Logic allLogic in LogicSystemModel.GetAllLogics())
		{
			foreach (SocketIO allScoketIO in allLogic.GetAllScoketIOs())
			{
				if (allScoketIO.IsLogicIOAttached)
				{
					int blockId = allScoketIO.BlockId;
					allScoketIO.BlockId = dictionary[blockId];
				}
			}
		}
		if (dictionary.ContainsKey(SelectedBlockId))
		{
			SelectedBlockId = dictionary[SelectedBlockId];
		}
		NotifyChange("CreationModel.ResetBlockIdsEvent", dictionary);
	}

	public int GetHighestId()
	{
		if (blockModelsMap.Count <= 0)
		{
			return 0;
		}
		return blockModelsMap.Keys.Max();
	}

	public void SetPositions(Vector3 position, Quaternion rotation)
	{
		Position = position;
		Rotation = rotation;
	}

	public void AddBlockModel(BlockModel blockModel, bool shouldNotifyChange = true)
	{
		if (blockModelsMap.ContainsKey(blockModel.Id))
		{
			Debug.LogError("Trying add block with the same ID!\n" + $"Ori [{blockModel.Id}]:{blockModelsMap[blockModel.Id].Schematic.Id}\n" + $"New [{blockModel.Id}]:{blockModel.Schematic.Id}");
			return;
		}
		if (blockModel.Schematic.Type == "brain")
		{
			if (BrainBlockModel != null)
			{
				NotifyChange("CreationModel.WarningMessageEvent", "Only one brain block can be placed!");
				return;
			}
			BrainBlockModel = blockModel;
			NotifyChange("CreationModel.AddBrainBlockEvent", blockModel);
		}
		blockModel.ParentCreationModel = this;
		blockModelsMap.Add(blockModel.Id, blockModel);
		if (shouldNotifyChange)
		{
			NotifyChange("CreationModel.AddBlockEvent", blockModel);
		}
		NotifyChange("CreationModel.ChangedBlocksCountEvent", blockModelsMap.Count);
	}

	public void ReAddBlockModel(BlockModel blockModel)
	{
		ReAddBlockModel(new BlockModel[1] { blockModel }, isReAddingOnlyOneBlockModel: true);
	}

	public void ReAddBlockModel(ICollection<BlockModel> blockModels, bool isReAddingOnlyOneBlockModel = false)
	{
		foreach (BlockModel blockModel in blockModels)
		{
			blockModel.Id = GetHighestId() + 1;
			AddBlockModel(blockModel);
		}
		foreach (BlockModel blockModel2 in blockModels)
		{
			foreach (BlockBodyModel allBlockBodyModel in blockModel2.GetAllBlockBodyModels())
			{
				foreach (FixedJointModel item in allBlockBodyModel.GetAllFixedJointModel())
				{
					if (isReAddingOnlyOneBlockModel)
					{
						item.ConnectedBlockBodyModel.AddOutsideFixedJointModel(item);
					}
					NotifyChange("CreationModel.FixedConnectTwoBlocksEvent", item);
				}
				foreach (HingeJointModel item2 in allBlockBodyModel.GetAllHingeJointModel())
				{
					if (isReAddingOnlyOneBlockModel)
					{
						item2.ConnectedBlockBodyModel.AddOutsideHingeJointModel(item2);
					}
					NotifyChange("CreationModel.HingeConnectTwoBlocksEvent", item2);
					if (item2.MotorJointModel != null)
					{
						NotifyChange("CreationModel.AddMotorJointEvent", item2);
					}
					if (item2.SteerableJointModel != null)
					{
						NotifyChange("CreationModel.AddSteerableJointEvent", item2);
					}
					if (item2.MotorBlockBodyModel != null)
					{
						ConnectMotorToHingeJoint(item2, item2.MotorBlockBodyModel);
					}
				}
				if (isReAddingOnlyOneBlockModel)
				{
					foreach (FixedJointModel item3 in allBlockBodyModel.GetAllOutsideFixedJointModel())
					{
						item3.ParentBlockBodyModel.AddFixedJointModel(item3);
						NotifyChange("CreationModel.FixedConnectTwoBlocksEvent", item3);
					}
					foreach (HingeJointModel item4 in allBlockBodyModel.GetAllOutsideHingeJointModel())
					{
						item4.ParentBlockBodyModel.AddHingeJointModel(item4);
						NotifyChange("CreationModel.HingeConnectTwoBlocksEvent", item4);
						if (item4.MotorJointModel != null)
						{
							NotifyChange("CreationModel.AddMotorJointEvent", item4);
						}
						if (item4.SteerableJointModel != null)
						{
							NotifyChange("CreationModel.AddSteerableJointEvent", item4);
						}
						if (item4.MotorBlockBodyModel != null)
						{
							ConnectMotorToHingeJoint(item4, item4.MotorBlockBodyModel);
						}
					}
				}
				if (allBlockBodyModel.TwoPointBlockModel != null)
				{
					NotifyChange("CreationModel.AddTwoPointBlockEvent", allBlockBodyModel.TwoPointBlockModel);
				}
			}
		}
		foreach (BlockModel blockModel3 in blockModels)
		{
			foreach (BlockBodyModel allBlockBodyModel2 in blockModel3.GetAllBlockBodyModels())
			{
				ComponentModel componentModel = allBlockBodyModel2.GetComponentModel(ComponentType.Motor);
				if (componentModel != null)
				{
					foreach (HingeJointModel allHingeJointModel in (componentModel.InternalProperties[MotorModel.Name] as MotorModel).GetAllHingeJointModels())
					{
						allHingeJointModel.MotorBlockBodyModel = allBlockBodyModel2;
						NotifyChange("CreationModel.ConnectMotorToHingeJointEvent", allHingeJointModel);
					}
				}
				foreach (DefaultKeyIO allDefaultKeyIO in allBlockBodyModel2.GetAllDefaultKeyIOs())
				{
					NotifyChange("CreationModel.UpdateDefaultKeyEvent", allDefaultKeyIO);
				}
				foreach (OverridablePropertyModel allOverridableProperty in allBlockBodyModel2.GetAllOverridableProperties())
				{
					NotifyChange("CreationModel.UpdateOverridablePropertyEvent", allOverridableProperty);
				}
			}
		}
	}

	public bool MergeCreationModel(CreationModel toMergeCreationModel)
	{
		if (BrainBlockModel != null && toMergeCreationModel.BrainBlockModel != null)
		{
			NotifyChange("CreationModel.WarningMessageEvent", "Only one brain block can be placed!");
			return false;
		}
		foreach (BlockModel item in toMergeCreationModel.GetAllBlockModel())
		{
			AddBlockModel(item, shouldNotifyChange: false);
		}
		if (toMergeCreationModel.LogicSystemModel.HasContent())
		{
			foreach (Logic allLogic in toMergeCreationModel.LogicSystemModel.GetAllLogics())
			{
				LogicSystemModel.AddLogic(allLogic);
			}
		}
		string[] allKeysGroupLabelKeys = toMergeCreationModel.GetAllKeysGroupLabelKeys();
		foreach (string text in allKeysGroupLabelKeys)
		{
			if (!keysGroupLabelsMap.ContainsKey(text))
			{
				keysGroupLabelsMap.Add(text, toMergeCreationModel.GetKeysGroupLabel(text));
			}
		}
		NotifyChange("CreationModel.MergeCreationEvent", toMergeCreationModel);
		return true;
	}

	public void RemoveBlockModel(int blockId)
	{
		BlockModel blockModel = blockModelsMap[blockId];
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			ComponentModel componentModel = allBlockBodyModel.GetComponentModel(ComponentType.Motor);
			if (componentModel != null)
			{
				foreach (HingeJointModel allHingeJointModel in (componentModel.InternalProperties[MotorModel.Name] as MotorModel).GetAllHingeJointModels())
				{
					allHingeJointModel.MotorBlockBodyModel = null;
				}
			}
			foreach (FixedJointModel item in allBlockBodyModel.GetAllFixedJointModel())
			{
				item.ConnectedBlockBodyModel.RemoveOutsideFixedJointModel(item);
			}
			foreach (HingeJointModel item2 in allBlockBodyModel.GetAllHingeJointModel())
			{
				item2.ConnectedBlockBodyModel.RemoveOutsideHingeJointModel(item2);
				item2.DetachHingeOnMotorBlock();
			}
			foreach (FixedJointModel item3 in allBlockBodyModel.GetAllOutsideFixedJointModel())
			{
				item3.ParentBlockBodyModel.RemoveFixedJointModel(item3);
			}
			foreach (HingeJointModel item4 in allBlockBodyModel.GetAllOutsideHingeJointModel())
			{
				item4.ParentBlockBodyModel.RemoveHingeJointModel(item4);
				item4.DetachHingeOnMotorBlock();
			}
		}
		blockModelsMap.Remove(blockId);
		if (blockModel.Schematic.Type == "brain")
		{
			BrainBlockModel = null;
			NotifyChange("CreationModel.RemoveBrainBlockEvent", blockModel);
		}
		blockModel.ParentCreationModel = null;
		NotifyChange("CreationModel.RemoveBlockEvent", blockId);
		NotifyChange("CreationModel.ChangedBlocksCountEvent", blockModelsMap.Count);
	}

	public void RemoveGroupBlockModels(ICollection<BlockModel> blockModels)
	{
		foreach (BlockModel blockModel in blockModels)
		{
			foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
			{
				ComponentModel componentModel = allBlockBodyModel.GetComponentModel(ComponentType.Motor);
				if (componentModel != null)
				{
					foreach (HingeJointModel allHingeJointModel in (componentModel.InternalProperties[MotorModel.Name] as MotorModel).GetAllHingeJointModels())
					{
						allHingeJointModel.MotorBlockBodyModel = null;
					}
				}
				foreach (HingeJointModel item in allBlockBodyModel.GetAllHingeJointModel())
				{
					item.DetachHingeOnMotorBlock();
				}
				foreach (HingeJointModel item2 in allBlockBodyModel.GetAllOutsideHingeJointModel())
				{
					item2.DetachHingeOnMotorBlock();
				}
			}
			blockModelsMap.Remove(blockModel.Id);
			if (blockModel.Schematic.Type == "brain")
			{
				BrainBlockModel = null;
				NotifyChange("CreationModel.RemoveBrainBlockEvent", blockModel);
			}
			blockModel.ParentCreationModel = null;
			NotifyChange("CreationModel.RemoveBlockEvent", blockModel.Id);
		}
		NotifyChange("CreationModel.ChangedBlocksCountEvent", blockModelsMap.Count);
	}

	public FixedJointModel FixedConnectTwoBlocks(BlockBodyModel firstBlockBodyModel, BlockBodyModel secondBlockBodyModel)
	{
		return FixedConnectTwoBlocks(firstBlockBodyModel, secondBlockBodyModel, Vector3.zero, Vector3.zero, isFullJoint: false);
	}

	public FixedJointModel FixedConnectTwoBlocks(BlockBodyModel firstBlockBodyModel, BlockBodyModel secondBlockBodyModel, Vector3 position, Vector3 axisDirection, bool isFullJoint = true)
	{
		FixedJointModel fixedJointModel = new FixedJointModel
		{
			ParentBlockBodyModel = firstBlockBodyModel,
			ConnectedBlockBodyModel = secondBlockBodyModel,
			IsFullJoint = isFullJoint,
			Position = position,
			AxisDirection = axisDirection
		};
		return FixedConnectTwoBlocks(fixedJointModel);
	}

	public FixedJointModel FixedConnectTwoBlocks(FixedJointModel fixedJointModel)
	{
		fixedJointModel.ParentBlockBodyModel.AddFixedJointModel(fixedJointModel);
		fixedJointModel.ConnectedBlockBodyModel.AddOutsideFixedJointModel(fixedJointModel);
		NotifyChange("CreationModel.FixedConnectTwoBlocksEvent", fixedJointModel);
		return fixedJointModel;
	}

	public HingeJointModel ConvertFixedJointToHingeJoint(FixedJointModel fixedJointModel, HingeJointModel hingeJointModel = null)
	{
		RemoveFixedJoint(fixedJointModel);
		if (hingeJointModel == null)
		{
			return HingeConnectTwoBlocks(fixedJointModel.ParentBlockBodyModel, fixedJointModel.ConnectedBlockBodyModel, fixedJointModel.Position, fixedJointModel.AxisDirection);
		}
		return HingeConnectTwoBlocks(hingeJointModel);
	}

	public void RemoveFixedJoint(FixedJointModel fixedJointModel)
	{
		BlockBodyModel parentBlockBodyModel = fixedJointModel.ParentBlockBodyModel;
		fixedJointModel.ConnectedBlockBodyModel.RemoveOutsideFixedJointModel(fixedJointModel);
		parentBlockBodyModel.RemoveFixedJointModel(fixedJointModel);
		NotifyChange("CreationModel.RemoveFixedJointEvent", fixedJointModel);
	}

	public HingeJointModel HingeConnectTwoBlocks(BlockBodyModel firstBlockBodyModel, BlockBodyModel secondBlockBodyModel, Vector3 position, Vector3 axisDirection)
	{
		HingeJointModel hingeJointModel = new HingeJointModel
		{
			ParentBlockBodyModel = firstBlockBodyModel,
			ConnectedBlockBodyModel = secondBlockBodyModel,
			Position = position,
			AxisDirection = axisDirection
		};
		return HingeConnectTwoBlocks(hingeJointModel);
	}

	public HingeJointModel HingeConnectTwoBlocks(HingeJointModel hingeJointModel)
	{
		hingeJointModel.ParentBlockBodyModel.AddHingeJointModel(hingeJointModel);
		hingeJointModel.ConnectedBlockBodyModel.AddOutsideHingeJointModel(hingeJointModel);
		NotifyChange("CreationModel.HingeConnectTwoBlocksEvent", hingeJointModel);
		return hingeJointModel;
	}

	public FixedJointModel ConvertHingeJointToFixedJoint(HingeJointModel hingeJointModel, FixedJointModel fixedJointModel = null)
	{
		RemoveHingeJoint(hingeJointModel);
		if (fixedJointModel == null)
		{
			return FixedConnectTwoBlocks(hingeJointModel.ParentBlockBodyModel, hingeJointModel.ConnectedBlockBodyModel, hingeJointModel.Position, hingeJointModel.AxisDirection);
		}
		return FixedConnectTwoBlocks(fixedJointModel);
	}

	public void RemoveHingeJoint(HingeJointModel hingeJointModel)
	{
		BlockBodyModel parentBlockBodyModel = hingeJointModel.ParentBlockBodyModel;
		hingeJointModel.ConnectedBlockBodyModel.RemoveOutsideHingeJointModel(hingeJointModel);
		parentBlockBodyModel.RemoveHingeJointModel(hingeJointModel);
		NotifyChange("CreationModel.RemoveHingeJointEvent", hingeJointModel);
	}

	public HingeJointModel AddMotorJointModel(int blockId, int bodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetHingeJointModel(hingeJointIndex);
		MotorJointModel motorJointModel = new MotorJointModel(hingeJointModel);
		hingeJointModel.SetMotorJointModel(motorJointModel);
		NotifyChange("CreationModel.AddMotorJointEvent", hingeJointModel);
		return hingeJointModel;
	}

	public HingeJointModel AddSteerableJointModel(int blockId, int bodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetHingeJointModel(hingeJointIndex);
		SteerableJointModel steerableJointModel = new SteerableJointModel(hingeJointModel);
		hingeJointModel.SetSteerableJointModel(steerableJointModel);
		NotifyChange("CreationModel.AddSteerableJointEvent", hingeJointModel);
		return hingeJointModel;
	}

	public HingeJointModel AddStepperJointModel(int blockId, int bodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetHingeJointModel(hingeJointIndex);
		StepperJointModel stepperJointModel = new StepperJointModel(hingeJointModel);
		hingeJointModel.SetStepperJointModel(stepperJointModel);
		NotifyChange("CreationModel.AddStepperJointEvent", hingeJointModel);
		return hingeJointModel;
	}

	public HingeJointModel RemoveSpecializedJointsModel(int blockId, int bodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetHingeJointModel(hingeJointIndex);
		hingeJointModel.RemoveMotorJointModel();
		hingeJointModel.RemoveSteerableJointModel();
		hingeJointModel.RemoveStepperJointModel();
		NotifyChange("CreationModel.RemoveSpecializedJointsEvent", hingeJointModel);
		return hingeJointModel;
	}

	public void UpdateMotorJointModel(int blockId, int bodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetHingeJointModel(hingeJointIndex);
		NotifyChange("CreationModel.UpdateMotorJointEvent", hingeJointModel);
	}

	public void UpdateSteerableJointModel(int blockId, int bodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetHingeJointModel(hingeJointIndex);
		NotifyChange("CreationModel.UpdateSteerableJointEvent", hingeJointModel);
	}

	public void UpdateStepperJointModel(int blockId, int bodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetHingeJointModel(hingeJointIndex);
		NotifyChange("CreationModel.UpdateStepperJointEvent", hingeJointModel);
	}

	public void ConnectMotorToHingeJoint(int hingeJointBlockId, int hingeJointBodyIndex, int hingeJointIndex, int motorBlockId, int motorBodyIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[hingeJointBlockId].GetBlockBodyModel(hingeJointBodyIndex).GetHingeJointModel(hingeJointIndex);
		BlockBodyModel blockBodyModel = blockModelsMap[motorBlockId].GetBlockBodyModel(motorBodyIndex);
		ConnectMotorToHingeJoint(hingeJointModel, blockBodyModel);
	}

	public void ConnectMotorToHingeJoint(HingeJointModel hingeJointModel, BlockBodyModel motorBlockBodyModel)
	{
		if (hingeJointModel.MotorBlockBodyModel != null && hingeJointModel.MotorBlockBodyModel == motorBlockBodyModel)
		{
			hingeJointModel.MotorBlockBodyModel = null;
		}
		ComponentModel componentModel = motorBlockBodyModel.GetComponentModel(ComponentType.Motor);
		MotorModel motorModel = componentModel.InternalProperties[MotorModel.Name] as MotorModel;
		if (motorModel.HingeJointsCount() >= componentModel.Properties.GetPropertyAsInt("maxJoints"))
		{
			NotifyChange("CreationModel.WarningMessageEvent", "Can't connect more axis in this motor");
			return;
		}
		if (motorBlockBodyModel == hingeJointModel.MotorBlockBodyModel)
		{
			NotifyChange("CreationModel.WarningMessageEvent", "This motor is already connected in this axis");
			return;
		}
		motorModel.AddHingeJointModel(hingeJointModel);
		if (hingeJointModel.MotorBlockBodyModel != null)
		{
			int id = hingeJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = hingeJointModel.ParentBlockBodyModel.Index;
			int index2 = hingeJointModel.Index;
			RemoveMotorFromHingeJoint(id, index, index2);
		}
		hingeJointModel.MotorBlockBodyModel = motorBlockBodyModel;
		NotifyChange("CreationModel.ConnectMotorToHingeJointEvent", hingeJointModel);
	}

	public HingeJointModel RemoveMotorFromHingeJoint(int hingeJointBlockId, int hingeJointBodyIndex, int hingeJointIndex)
	{
		HingeJointModel hingeJointModel = blockModelsMap[hingeJointBlockId].GetBlockBodyModel(hingeJointBodyIndex).GetHingeJointModel(hingeJointIndex);
		(hingeJointModel.MotorBlockBodyModel.GetComponentModel(ComponentType.Motor).InternalProperties[MotorModel.Name] as MotorModel).RemoveHingeJointModel(hingeJointModel);
		NotifyChange("CreationModel.RemoveMotorFromHingeJointEvent", hingeJointModel);
		hingeJointModel.MotorBlockBodyModel = null;
		return hingeJointModel;
	}

	public void RemoveAllJoints(int blockModelId)
	{
		foreach (BlockBodyModel allBlockBodyModel in blockModelsMap[blockModelId].GetAllBlockBodyModels())
		{
			foreach (FixedJointModel item in allBlockBodyModel.GetAllFixedJointModel())
			{
				RemoveFixedJoint(item);
			}
			foreach (FixedJointModel item2 in allBlockBodyModel.GetAllOutsideFixedJointModel())
			{
				RemoveFixedJoint(item2);
			}
			foreach (HingeJointModel item3 in allBlockBodyModel.GetAllHingeJointModel())
			{
				RemoveHingeJoint(item3);
			}
			foreach (HingeJointModel item4 in allBlockBodyModel.GetAllOutsideHingeJointModel())
			{
				RemoveHingeJoint(item4);
			}
		}
	}

	public void UpdateDefaultKey(int blockId, int bodyIndex, string keyName, KeyCode keyValue, AxisCode axisValue)
	{
		DefaultKeyIO defaultKeyIO = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex).GetDefaultKeyIO(keyName);
		defaultKeyIO.KeyValue = keyValue;
		defaultKeyIO.AxisValue = axisValue;
		NotifyChange("CreationModel.UpdateDefaultKeyEvent", defaultKeyIO);
	}

	public void UpdateOverriblaProperty(OverridablePropertyModel property, string newValue)
	{
		property.Value = newValue;
		NotifyChange("CreationModel.UpdateOverridablePropertyEvent", property);
	}

	public void UpdateInterconnectedBlocks()
	{
		NotifyChange("CreationModel.UpdateInterconnectedBlocksEvent");
	}

	public void UpdateInterconnectedBlocksAfterJoint(BlockModel firstBlockModel, BlockModel secondBlockModel)
	{
		NotifyChange("CreationModel.UpdateInterconnectedBlocksAfterJointEvent", firstBlockModel, secondBlockModel);
	}

	public void AddTwoPointBlock(int blockId, int bodyIndex, Vector3 position, Quaternion rotation)
	{
		BlockBodyModel blockBodyModel = blockModelsMap[blockId].GetBlockBodyModel(bodyIndex);
		TwoPointBlockModel twoPointBlockModel = (blockBodyModel.TwoPointBlockModel = new TwoPointBlockModel
		{
			ParentBlockBodyModel = blockBodyModel,
			EndPointPosition = position,
			EndPointRotation = rotation
		});
		NotifyChange("CreationModel.AddTwoPointBlockEvent", twoPointBlockModel);
	}

	public BlockModel GetBlockModel(int id)
	{
		if (!blockModelsMap.ContainsKey(id))
		{
			return null;
		}
		return blockModelsMap[id];
	}

	public ICollection<BlockModel> GetAllBlockModel()
	{
		return blockModelsMap.Values;
	}

	public BlockBodyModel GetBlockBodyModel(int blockId, int bodyIndex)
	{
		return GetBlockModel(blockId)?.GetBlockBodyModel(bodyIndex);
	}

	public ICollection<BlockBodyModel> GetAllBlockBodyWith(string componentName)
	{
		List<BlockBodyModel> list = new List<BlockBodyModel>();
		foreach (BlockModel value in blockModelsMap.Values)
		{
			foreach (BlockBodyModel allBlockBodyModel in value.GetAllBlockBodyModels())
			{
				if (allBlockBodyModel.GetComponentModel(componentName) != null)
				{
					list.Add(allBlockBodyModel);
				}
			}
		}
		return list;
	}

	public BlockModel GetLastAddedBlockModel()
	{
		return blockModelsMap[GetHighestId()];
	}

	public BlockBodyModel GetSelectedBodyModel()
	{
		return blockModelsMap[SelectedBlockId].GetBlockBodyModel(SelectedBodyIndex);
	}

	public DefaultKeyIO[] GetAllDefaultKeyIOs()
	{
		List<DefaultKeyIO> list = new List<DefaultKeyIO>();
		foreach (BlockModel value in blockModelsMap.Values)
		{
			foreach (BlockBodyModel allBlockBodyModel in value.GetAllBlockBodyModels())
			{
				list.AddRange(allBlockBodyModel.GetAllDefaultKeyIOs());
			}
		}
		return list.ToArray();
	}

	public void SetDefaultKeyIOsOverwritability(int blockId, int bodyIndex, string[] defaultKeyIOids, bool shouldOverwrite)
	{
		foreach (DefaultKeyIO allDefaultKeyIO in GetBlockModel(blockId).GetBlockBodyModel(bodyIndex).GetAllDefaultKeyIOs())
		{
			for (int i = 0; i < defaultKeyIOids.Length; i++)
			{
				if (allDefaultKeyIO.Name == defaultKeyIOids[i])
				{
					allDefaultKeyIO.IsOverwriteByOtherInput = shouldOverwrite;
				}
			}
		}
	}

	public bool IsTwoPointBlock()
	{
		if (blockModelsMap.Values.Count == 1)
		{
			return blockModelsMap.FirstOrDefault().Value.GetBlockBodyModel(0).BodySchematic.IsTwoPointBlock;
		}
		return false;
	}

	public float TotalCost()
	{
		float num = 0f;
		foreach (BlockModel value in blockModelsMap.Values)
		{
			num += (float)value.Schematic.Cost;
		}
		return num;
	}

	public float TotalWeight()
	{
		float num = 0f;
		foreach (BlockModel value in blockModelsMap.Values)
		{
			num += value.Schematic.Volume * value.Schematic.MaterialSchematic.Density;
		}
		return num;
	}

	public void SetBlockOutline(int blockId, bool isEnabled, int colorLine)
	{
		NotifyChange("CreationModel.SetBlockOutlineEvent", blockId, isEnabled, colorLine);
	}

	public void UpdateInterconnectedBlocksForModel()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		List<List<int>> list = new List<List<int>>();
		foreach (BlockModel value in blockModelsMap.Values)
		{
			value.ClearInterconnectedBlocks();
		}
		foreach (BlockModel value2 in blockModelsMap.Values)
		{
			bool flag = false;
			foreach (List<int> item in list)
			{
				if (item.Contains(value2.Id))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			List<int> list2 = new List<int> { value2.Id };
			Queue<BlockModel> queue = new Queue<BlockModel>();
			queue.Enqueue(value2);
			while (queue.Count != 0)
			{
				BlockModel blockModel = queue.Dequeue();
				List<BlockModel> list3 = new List<BlockModel>();
				list3.AddRange(blockModel.GetAllDirectConnectedBlocks());
				list3.AddRange(blockModel.GetAllIndirectConnectedBlocks());
				foreach (BlockModel item2 in list3)
				{
					if (!list2.Contains(item2.Id))
					{
						list2.Add(item2.Id);
						queue.Enqueue(item2);
						value2.AddInterconnectedBlock(item2);
					}
				}
			}
			list.Add(list2);
		}
		Debug.Log("Updated interconnected block models [" + (Time.realtimeSinceStartup - realtimeSinceStartup) * 1000f + " ms]");
		list.ForEach(delegate(List<int> blockIdGroup)
		{
			Debug.Log("[" + string.Join(", ", blockIdGroup) + "]");
		});
	}

	public void AddKeysGroupLabel(string keyId, string label)
	{
		if (!keysGroupLabelsMap.ContainsKey(keyId))
		{
			keysGroupLabelsMap.Add(keyId, label);
		}
		else
		{
			keysGroupLabelsMap[keyId] = label;
		}
	}

	public void RemoveKeysGroupLabel(string keyId)
	{
		if (keysGroupLabelsMap.ContainsKey(keyId))
		{
			keysGroupLabelsMap.Remove(keyId);
		}
	}

	public string GetKeysGroupLabel(string keyId)
	{
		if (keysGroupLabelsMap.ContainsKey(keyId))
		{
			return keysGroupLabelsMap[keyId];
		}
		return "";
	}

	public string[] GetAllKeysGroupLabelKeys()
	{
		return keysGroupLabelsMap.Keys.ToArray();
	}

	public void UpdateDefaultKeysControlledByLogic()
	{
		NotifyChange("CreationModel.UpdateDefaultKeysControlledByLogicEvent");
	}
}
