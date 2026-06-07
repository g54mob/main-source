using UnityEngine;

public static class CreationCloner
{
	public static CreationModel Clone(CreationModel creationModel, bool shouldIncludeLogicSystem = true)
	{
		CreationModel creationModel2 = new CreationModel(creationModel.Id, creationModel.Name, creationModel.Description, creationModel.IsOriginatedFromSchematic)
		{
			Position = creationModel.Position,
			Rotation = creationModel.Rotation,
			SelectedBlockId = creationModel.SelectedBlockId,
			SelectedBodyIndex = creationModel.SelectedBodyIndex,
			IsDeletable = creationModel.IsDeletable,
			FilePath = creationModel.FilePath,
			Place = creationModel.Place
		};
		foreach (Vector3 defaultConnector in creationModel.DefaultConnectors)
		{
			creationModel2.DefaultConnectors.Add(defaultConnector);
		}
		foreach (BlockModel item in creationModel.GetAllBlockModel())
		{
			BlockModel blockModel = CloneBlockModel(item);
			creationModel2.AddBlockModel(blockModel);
		}
		foreach (BlockModel item2 in creationModel.GetAllBlockModel())
		{
			foreach (BlockBodyModel allBlockBodyModel in item2.GetAllBlockBodyModels())
			{
				BlockBodyModel blockBodyModel = creationModel2.GetBlockModel(item2.Id).GetBlockBodyModel(allBlockBodyModel.Index);
				CloneFixedJointModel(allBlockBodyModel, blockBodyModel, creationModel2);
				CloneHingeJointModel(allBlockBodyModel, blockBodyModel, creationModel2);
				CloneTwoPointBlock(allBlockBodyModel, blockBodyModel);
			}
		}
		foreach (BlockModel item3 in creationModel.GetAllBlockModel())
		{
			foreach (BlockBodyModel allBlockBodyModel2 in item3.GetAllBlockBodyModels())
			{
				BlockBodyModel blockBodyModel2 = creationModel2.GetBlockModel(item3.Id).GetBlockBodyModel(allBlockBodyModel2.Index);
				CloneComponent(creationModel2, allBlockBodyModel2, blockBodyModel2);
				CloneDefaultKeys(allBlockBodyModel2, blockBodyModel2);
				CloneOverridableProperties(allBlockBodyModel2, blockBodyModel2);
			}
		}
		if (shouldIncludeLogicSystem)
		{
			creationModel2.LogicSystemModel = CloneLogicSystemModel(creationModel.LogicSystemModel);
		}
		string[] allKeysGroupLabelKeys = creationModel.GetAllKeysGroupLabelKeys();
		foreach (string keyId in allKeysGroupLabelKeys)
		{
			string keysGroupLabel = creationModel.GetKeysGroupLabel(keyId);
			creationModel2.AddKeysGroupLabel(keyId, keysGroupLabel);
		}
		return creationModel2;
	}

	private static BlockModel CloneBlockModel(BlockModel blockModel)
	{
		BlockModel blockModel2 = new BlockModel(blockModel.Schematic)
		{
			Id = blockModel.Id,
			Position = blockModel.Position,
			Rotation = blockModel.Rotation
		};
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			_ = allBlockBodyModel;
			BlockBodyModel blockBodyModel = new BlockBodyModel();
			blockModel2.AddBlockBodyModel(blockBodyModel);
		}
		return blockModel2;
	}

	private static void CloneFixedJointModel(BlockBodyModel blockBodyModel, BlockBodyModel newBlockBodyModel, CreationModel newCreationModel)
	{
		foreach (FixedJointModel item in blockBodyModel.GetAllFixedJointModel())
		{
			int id = item.ConnectedBlockBodyModel.ParentBlockModel.Id;
			int index = item.ConnectedBlockBodyModel.Index;
			BlockBodyModel blockBodyModel2 = newCreationModel.GetBlockModel(id).GetBlockBodyModel(index);
			FixedJointModel fixedJointModel = new FixedJointModel
			{
				ConnectedBlockBodyModel = blockBodyModel2,
				IsFullJoint = item.IsFullJoint,
				Position = item.Position,
				AxisDirection = item.AxisDirection
			};
			newBlockBodyModel.AddFixedJointModel(fixedJointModel);
			blockBodyModel2.AddOutsideFixedJointModel(fixedJointModel);
		}
	}

	private static void CloneHingeJointModel(BlockBodyModel blockBodyModel, BlockBodyModel newBlockBodyModel, CreationModel newCreationModel)
	{
		foreach (HingeJointModel item in blockBodyModel.GetAllHingeJointModel())
		{
			int id = item.ConnectedBlockBodyModel.ParentBlockModel.Id;
			int index = item.ConnectedBlockBodyModel.Index;
			BlockBodyModel blockBodyModel2 = newCreationModel.GetBlockModel(id).GetBlockBodyModel(index);
			HingeJointModel hingeJointModel = new HingeJointModel
			{
				ConnectedBlockBodyModel = blockBodyModel2,
				Position = item.Position,
				AxisDirection = item.AxisDirection,
				IsThisAnchorPoint = item.IsThisAnchorPoint
			};
			newBlockBodyModel.AddHingeJointModel(hingeJointModel);
			blockBodyModel2.AddOutsideHingeJointModel(hingeJointModel);
			if (item.MotorBlockBodyModel != null)
			{
				int id2 = item.MotorBlockBodyModel.ParentBlockModel.Id;
				int index2 = item.MotorBlockBodyModel.Index;
				hingeJointModel.MotorBlockBodyModel = newCreationModel.GetBlockModel(id2).GetBlockBodyModel(index2);
			}
			if (item.MotorJointModel != null)
			{
				MotorJointModel motorJointModel = new MotorJointModel(hingeJointModel)
				{
					IsClockwiseRotation = item.MotorJointModel.IsClockwiseRotation
				};
				hingeJointModel.SetMotorJointModel(motorJointModel);
			}
			if (item.SteerableJointModel != null)
			{
				SteerableJointModel steerableJointModel = new SteerableJointModel(hingeJointModel)
				{
					IsToggleActivationType = item.SteerableJointModel.IsToggleActivationType,
					ForwardTarget = item.SteerableJointModel.ForwardTarget,
					BackwardTarget = item.SteerableJointModel.BackwardTarget,
					AngleOffset = item.SteerableJointModel.AngleOffset
				};
				hingeJointModel.SetSteerableJointModel(steerableJointModel);
			}
			if (item.StepperJointModel != null)
			{
				StepperJointModel stepperJointModel = new StepperJointModel(hingeJointModel)
				{
					DegreesPerSecond = item.StepperJointModel.DegreesPerSecond,
					IsClockwiseRotation = item.StepperJointModel.IsClockwiseRotation
				};
				hingeJointModel.SetStepperJointModel(stepperJointModel);
			}
		}
	}

	private static void CloneTwoPointBlock(BlockBodyModel blockBodyModel, BlockBodyModel newBlockBodyModel)
	{
		if (blockBodyModel.TwoPointBlockModel != null)
		{
			TwoPointBlockModel twoPointBlockModel = new TwoPointBlockModel
			{
				ParentBlockBodyModel = newBlockBodyModel,
				EndPointPosition = blockBodyModel.TwoPointBlockModel.EndPointPosition,
				EndPointRotation = blockBodyModel.TwoPointBlockModel.EndPointRotation
			};
			newBlockBodyModel.TwoPointBlockModel = twoPointBlockModel;
		}
	}

	private static void CloneComponent(CreationModel newCreationModel, BlockBodyModel blockBodyModel, BlockBodyModel newBlockBodyModel)
	{
		foreach (ComponentModel item in blockBodyModel.GetAllComponentModel())
		{
			ComponentModel componentModel = ComponentModel.Instantiate(item.ComponentSchematic);
			if (item.Type == ComponentType.Motor)
			{
				MotorModel obj = item.InternalProperties[MotorModel.Name] as MotorModel;
				MotorModel motorModel = new MotorModel();
				foreach (HingeJointModel allHingeJointModel in obj.GetAllHingeJointModels())
				{
					int id = allHingeJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
					int index = allHingeJointModel.ParentBlockBodyModel.Index;
					int index2 = allHingeJointModel.Index;
					motorModel.AddHingeJointModel(newCreationModel.GetBlockModel(id).GetBlockBodyModel(index).GetHingeJointModel(index2));
				}
				componentModel.InternalProperties.Add(MotorModel.Name, motorModel);
			}
			newBlockBodyModel.AddComponentModel(componentModel);
		}
	}

	private static void CloneDefaultKeys(BlockBodyModel blockBodyModel, BlockBodyModel newBlockBodyModel)
	{
		foreach (DefaultKeyIO allDefaultKeyIO in blockBodyModel.GetAllDefaultKeyIOs())
		{
			newBlockBodyModel.SetDefaultKeyIO(allDefaultKeyIO.Name, allDefaultKeyIO.KeyValue, allDefaultKeyIO.AxisValue);
		}
	}

	private static void CloneOverridableProperties(BlockBodyModel blockBodyModel, BlockBodyModel newBlockBodyModel)
	{
		foreach (OverridablePropertyModel allOverridableProperty in blockBodyModel.GetAllOverridableProperties())
		{
			newBlockBodyModel.SetOverridableProperty(allOverridableProperty.Key, allOverridableProperty.Value);
		}
	}

	public static LogicSystemModel CloneLogicSystemModel(LogicSystemModel logicSystemModel)
	{
		return LogicSystemModelBuilder.LoadXml(LogicSystemModelBuilder.SaveXml(logicSystemModel));
	}
}
