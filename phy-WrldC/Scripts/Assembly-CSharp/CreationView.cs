using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreationView : MonoBehaviourBaseView
{
	public enum CreationRoleState
	{
		None = 0,
		Attacker = 1,
		Defender = 2
	}

	public enum CreationRendererTypeEnum
	{
		None = 0,
		Placeholder = 1,
		Model = 2,
		Rigid = 3
	}

	public const string BlockDestroyedEvent = "CreationView.BlockDestroyedEvent";

	public const string DefaultKeyIOsOverwritabilityEvent = "CreationView.DefaultKeyIOsOverwritabilityEvent";

	private Dictionary<int, BlockView> blockViewsMap;

	private bool shouldCheckInterconnections;

	private float timeCounter;

	public string Id { get; set; }

	public bool IsGroupCentered { get; set; }

	public bool IsEditable { get; set; }

	public bool IsPlayable { get; set; }

	public bool IsBrainBlockDestroyed { get; set; }

	public bool IsInAction { get; private set; }

	public BlockView BrainBlockView { get; private set; }

	public CreationRoleState CreationRole { get; set; }

	public CreationRendererTypeEnum CreationRendererType { get; set; }

	public LogicSystemView LogicSystemView { get; set; }

	public bool IsUnbreakableCreation { get; set; }

	public bool IsUnlimitedAmmo { get; set; }

	private void Update()
	{
		if (IsInAction && shouldCheckInterconnections)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter > 2f)
			{
				UpdateInterconnectedBlocksForAction();
				shouldCheckInterconnections = false;
			}
		}
	}

	public void OrderAnInterconnectionsUpdate()
	{
		timeCounter = 0f;
		shouldCheckInterconnections = true;
	}

	public void ResetView()
	{
		if (blockViewsMap != null)
		{
			RecycleAllBlocksBeforeDestroying();
		}
		Id = string.Empty;
		blockViewsMap = new Dictionary<int, BlockView>();
		BrainBlockView = null;
		IsBrainBlockDestroyed = false;
		IsInAction = false;
		timeCounter = 0f;
		shouldCheckInterconnections = false;
		IsUnbreakableCreation = false;
		IsUnlimitedAmmo = false;
		base.transform.RemoveAllChildren(GameManager.Instance);
	}

	public void SetPositions(Vector3 position, Quaternion rotation)
	{
		base.transform.localPosition = position;
		base.transform.localRotation = rotation;
	}

	public void SetEditableAndPlayable(bool isEditable, bool isPlayable)
	{
		IsEditable = isEditable;
		IsPlayable = isPlayable;
	}

	public BlockView AddBlockView(BlockModel blockModel, bool isComponentGizmoVisible)
	{
		GameObject gameObject = ((CreationRendererType == CreationRendererTypeEnum.Model || CreationRendererType == CreationRendererTypeEnum.None) ? ObjectPools.Instance.GetInstance(ObjectNames.SchematicIdForModel(blockModel.Schematic.Id), base.transform) : ((CreationRendererType != CreationRendererTypeEnum.Placeholder) ? ObjectPools.Instance.GetInstance(ObjectNames.SchematicIdForRigid(blockModel.Schematic.Id), base.transform) : ObjectPools.Instance.GetInstance(ObjectNames.SchematicIdForPlaceholder(blockModel.Schematic.Id), base.transform)));
		gameObject.name = "BlockView_" + blockModel.Id;
		gameObject.transform.localPosition = blockModel.Position;
		gameObject.transform.localRotation = blockModel.Rotation;
		BlockView blockView = gameObject.GetComponent<BlockView>();
		blockView.Id = blockModel.Id;
		blockView.ParentCreationView = this;
		blockViewsMap.Add(blockModel.Id, blockView);
		if (blockModel.Schematic.Type == "brain")
		{
			BrainBlockView = blockView;
		}
		if (CreationRendererType == CreationRendererTypeEnum.Rigid)
		{
			blockView.BlockDestroyedEvent += delegate
			{
				BlockDestroyedHandler(blockView);
			};
		}
		if (CreationRendererType == CreationRendererTypeEnum.Rigid || CreationRendererType == CreationRendererTypeEnum.Placeholder || CreationRendererType == CreationRendererTypeEnum.Model)
		{
			foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
			{
				foreach (ComponentModel item in allBlockBodyModel.GetAllComponentModel())
				{
					BaseComponentView componentView = blockView.GetBlockBodyView(allBlockBodyModel.Index).GetComponentView(item.Name);
					componentView.ComponentModel = item;
					if (CreationRendererType == CreationRendererTypeEnum.Rigid)
					{
						componentView.Initialize(item.ComponentSchematic.Properties);
					}
					if (CreationRendererType == CreationRendererTypeEnum.Rigid || CreationRendererType == CreationRendererTypeEnum.Placeholder)
					{
						componentView.InitializeGizmos(item);
					}
					if (CreationRendererType == CreationRendererTypeEnum.Model || CreationRendererType == CreationRendererTypeEnum.Placeholder)
					{
						componentView.InitializeModel();
					}
					if (CreationRendererType == CreationRendererTypeEnum.Rigid && !isComponentGizmoVisible)
					{
						componentView.SetGizmosVisibility(isVisible: false);
					}
				}
			}
		}
		return blockView;
	}

	public void AddMotorJointView(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		MotorJointView motorJointView = new MotorJointView(hingeJointView);
		MotorJointModel motorJointModel = hingeJointModel.MotorJointModel;
		motorJointView.ForwardInput.DefaultKey = motorJointModel.DefaultForward.KeyValue;
		motorJointView.BackwardInput.DefaultKey = motorJointModel.DefaultBackward.KeyValue;
		motorJointView.BrakeInput.DefaultKey = motorJointModel.DefaultBrake.KeyValue;
		motorJointView.IsClockwiseRotation = motorJointModel.IsClockwiseRotation;
		hingeJointView.SetMotorJointView(motorJointView);
	}

	public void AddSteerableJointView(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		SteerableJointView steerableJointView = new SteerableJointView(hingeJointView);
		SteerableJointModel steerableJointModel = hingeJointModel.SteerableJointModel;
		steerableJointView.ForwardInput.DefaultKey = steerableJointModel.DefaultForward.KeyValue;
		steerableJointView.BackwardInput.DefaultKey = steerableJointModel.DefaultBackward.KeyValue;
		steerableJointView.IsToggleActivationType = steerableJointModel.IsToggleActivationType;
		steerableJointView.forwardTarget = steerableJointModel.ForwardTarget;
		steerableJointView.backwardTarget = steerableJointModel.BackwardTarget;
		hingeJointView.SetSteerableJointView(steerableJointView);
	}

	public void AddStepperJointView(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		StepperJointView stepperJointView = new StepperJointView(hingeJointView);
		StepperJointModel stepperJointModel = hingeJointModel.StepperJointModel;
		stepperJointView.ForwardInput.DefaultKey = stepperJointModel.DefaultForward.KeyValue;
		stepperJointView.BackwardInput.DefaultKey = stepperJointModel.DefaultBackward.KeyValue;
		stepperJointView.degreesPerSecond = stepperJointModel.DegreesPerSecond;
		stepperJointView.isClockwiseRotation = stepperJointModel.IsClockwiseRotation;
		hingeJointView.SetStepperJointView(stepperJointView);
	}

	public void RemoveSpecializedJointsView(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		if (hingeJointView.MotorJointView != null)
		{
			hingeJointView.RemoveMotorJointView();
			hingeJointView.HingeJoint.useMotor = false;
		}
		if (hingeJointView.SteerableJointView != null)
		{
			hingeJointView.RemoveSteerableJointView();
			hingeJointView.HingeJoint.useSpring = false;
		}
		if (hingeJointView.StepperJointView != null)
		{
			hingeJointView.RemoveStepperJointView();
			hingeJointView.HingeJoint.useSpring = false;
		}
	}

	public void UpdateMotorJointView(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		MotorJointModel motorJointModel = hingeJointModel.MotorJointModel;
		MotorJointView motorJointView = hingeJointView.MotorJointView;
		motorJointView.ForwardInput.DefaultKey = motorJointModel.DefaultForward.KeyValue;
		motorJointView.ForwardInput.DefaultAxis = motorJointModel.DefaultForward.AxisValue;
		motorJointView.BackwardInput.DefaultKey = motorJointModel.DefaultBackward.KeyValue;
		motorJointView.BackwardInput.DefaultAxis = motorJointModel.DefaultBackward.AxisValue;
		motorJointView.BrakeInput.DefaultKey = motorJointModel.DefaultBrake.KeyValue;
		motorJointView.BrakeInput.DefaultAxis = motorJointModel.DefaultBrake.AxisValue;
		motorJointView.IsClockwiseRotation = motorJointModel.IsClockwiseRotation;
	}

	public void UpdateSteerableJointView(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		SteerableJointModel steerableJointModel = hingeJointModel.SteerableJointModel;
		SteerableJointView steerableJointView = hingeJointView.SteerableJointView;
		steerableJointView.ForwardInput.DefaultKey = steerableJointModel.DefaultForward.KeyValue;
		steerableJointView.ForwardInput.DefaultAxis = steerableJointModel.DefaultForward.AxisValue;
		steerableJointView.BackwardInput.DefaultKey = steerableJointModel.DefaultBackward.KeyValue;
		steerableJointView.BackwardInput.DefaultAxis = steerableJointModel.DefaultBackward.AxisValue;
		steerableJointView.IsToggleActivationType = steerableJointModel.IsToggleActivationType;
		steerableJointView.forwardTarget = steerableJointModel.ForwardTarget;
		steerableJointView.backwardTarget = steerableJointModel.BackwardTarget;
	}

	public void UpdateStepperJointView(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		StepperJointModel stepperJointModel = hingeJointModel.StepperJointModel;
		StepperJointView stepperJointView = hingeJointView.StepperJointView;
		stepperJointView.ForwardInput.DefaultKey = stepperJointModel.DefaultForward.KeyValue;
		stepperJointView.ForwardInput.DefaultAxis = stepperJointModel.DefaultForward.AxisValue;
		stepperJointView.BackwardInput.DefaultKey = stepperJointModel.DefaultBackward.KeyValue;
		stepperJointView.BackwardInput.DefaultAxis = stepperJointModel.DefaultBackward.AxisValue;
		stepperJointView.degreesPerSecond = stepperJointModel.DegreesPerSecond;
		stepperJointView.isClockwiseRotation = stepperJointModel.IsClockwiseRotation;
	}

	public void ConnectMotorToHingeJoint(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		BlockBodyView blockBodyView = (hingeJointView.MotorBodyBlockView = GetBlockBodyView(hingeJointModel.MotorBlockBodyModel));
		blockBodyView.GetComponent<MotorView>().AddHingeJointViews(hingeJointView);
	}

	public void RemoveMotorFromHingeJoint(HingeJointModel hingeJointModel)
	{
		HingeJointView hingeJointView = GetBlockBodyView(hingeJointModel).GetHingeJointView(hingeJointModel.Index);
		GetBlockBodyView(hingeJointModel.MotorBlockBodyModel).GetComponent<MotorView>().RemoveHingeJointView(hingeJointView);
		hingeJointView.MotorBodyBlockView = null;
	}

	public void MergeNewRigidCreation(CreationModel toMergeCreationModel)
	{
		CreationController creationController = CreationControllerBuilder.BuildRigidController(toMergeCreationModel, isGroupCentered: false);
		GameObject obj = creationController.view.gameObject;
		foreach (BlockView allBlockView in creationController.view.GetAllBlockViews())
		{
			allBlockView.transform.SetParent(base.transform, worldPositionStays: false);
			allBlockView.ParentCreationView = this;
			blockViewsMap.Add(allBlockView.Id, allBlockView);
		}
		Object.Destroy(obj);
	}

	public void RemoveBlockView(int blockId)
	{
		BlockView blockView = blockViewsMap[blockId];
		foreach (BlockBodyView allBlockBodyView in blockView.GetAllBlockBodyViews())
		{
			allBlockBodyView.DetachAllLogicIOs();
			MotorView component = allBlockBodyView.GetComponent<MotorView>();
			if (component != null)
			{
				foreach (HingeJointView allHingeJointView in component.GetAllHingeJointViews())
				{
					allHingeJointView.MotorBodyBlockView = null;
				}
			}
			allBlockBodyView.RemoveAllJoints();
		}
		blockViewsMap.Remove(blockId);
		ObjectPools.Instance.ReturnInstance(blockView.gameObject);
	}

	public void FixedConnectTwoBlocks(FixedJointModel fixedJointModel)
	{
		int index = fixedJointModel.ParentBlockBodyModel.Index;
		int index2 = fixedJointModel.ConnectedBlockBodyModel.Index;
		int id = fixedJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
		int id2 = fixedJointModel.ConnectedBlockBodyModel.ParentBlockModel.Id;
		BlockBodyView blockBodyView = blockViewsMap[id].GetBlockBodyView(index);
		BlockBodyView blockBodyView2 = blockViewsMap[id2].GetBlockBodyView(index2);
		FixedJoint fixedJoint = BlockViewBuilder.FixedJointTwoBlocks(blockBodyView, blockBodyView2);
		FixedJointView fixedJointView = new FixedJointView
		{
			FixedJoint = fixedJoint,
			ConnectedBlockBodyView = blockBodyView2
		};
		blockBodyView.AddFixedJointView(fixedJointView);
		blockBodyView2.AddOutsideFixedJoint(fixedJointView);
	}

	public void RemoveFixedJoint(FixedJointModel fixedJointModel)
	{
		int index = fixedJointModel.ParentBlockBodyModel.Index;
		int index2 = fixedJointModel.ConnectedBlockBodyModel.Index;
		int id = fixedJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
		int id2 = fixedJointModel.ConnectedBlockBodyModel.ParentBlockModel.Id;
		BlockBodyView blockBodyView = blockViewsMap[id].GetBlockBodyView(index);
		BlockBodyView blockBodyView2 = blockViewsMap[id2].GetBlockBodyView(index2);
		FixedJointView fixedJointView = blockBodyView.GetFixedJointView(fixedJointModel.Index);
		blockBodyView2.RemoveOutsideFixedJoint(fixedJointView);
		blockBodyView.RemoveFixedJointView(fixedJointView);
	}

	public void HingeConnectTwoBlocks(HingeJointModel hingeJointModel)
	{
		int index = hingeJointModel.ParentBlockBodyModel.Index;
		int index2 = hingeJointModel.ConnectedBlockBodyModel.Index;
		int id = hingeJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
		int id2 = hingeJointModel.ConnectedBlockBodyModel.ParentBlockModel.Id;
		BlockBodyView blockBodyView = blockViewsMap[id].GetBlockBodyView(index);
		BlockBodyView blockBodyView2 = blockViewsMap[id2].GetBlockBodyView(index2);
		HingeJoint hingeJoint = BlockViewBuilder.HingeJointTwoBlocks(blockBodyView, blockBodyView2, hingeJointModel.Position, hingeJointModel.AxisDirection);
		HingeJointView hingeJointView = new HingeJointView
		{
			HingeJoint = hingeJoint,
			ConnectedBlockBodyView = blockBodyView2
		};
		blockBodyView.AddHingeJointView(hingeJointView);
		blockBodyView2.AddOutsideHingeJoint(hingeJointView);
	}

	public void RemoveHingeJoint(HingeJointModel hingeJointModel)
	{
		int index = hingeJointModel.ParentBlockBodyModel.Index;
		int index2 = hingeJointModel.ConnectedBlockBodyModel.Index;
		int id = hingeJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
		int id2 = hingeJointModel.ConnectedBlockBodyModel.ParentBlockModel.Id;
		BlockBodyView blockBodyView = blockViewsMap[id].GetBlockBodyView(index);
		BlockBodyView blockBodyView2 = blockViewsMap[id2].GetBlockBodyView(index2);
		HingeJointView hingeJointView = blockBodyView.GetHingeJointView(hingeJointModel.Index);
		blockBodyView2.RemoveOutsideHingeJoint(hingeJointView);
		blockBodyView.RemoveHingeJointView(hingeJointView);
	}

	public void UpdateComponentKey(DefaultKeyIO defaultKey)
	{
		int id = defaultKey.ParentBlockBodyModel.ParentBlockModel.Id;
		int index = defaultKey.ParentBlockBodyModel.Index;
		LogicIO logicIO = blockViewsMap[id].GetBlockBodyView(index).GetLogicIO(defaultKey.Name);
		if (logicIO != null)
		{
			logicIO.DefaultKey = defaultKey.KeyValue;
			logicIO.DefaultAxis = defaultKey.AxisValue;
		}
	}

	public void UpdateOverridableProperty(OverridablePropertyModel property)
	{
		int id = property.ParentBlockBodyModel.ParentBlockModel.Id;
		int index = property.ParentBlockBodyModel.Index;
		blockViewsMap[id].GetBlockBodyView(index).OverridableProperties.SetProperty(property.Key, property.Value);
	}

	public void AddTwoPointBlock(TwoPointBlockModel twoPointBlockModel)
	{
		int id = twoPointBlockModel.ParentBlockBodyModel.ParentBlockModel.Id;
		int index = twoPointBlockModel.ParentBlockBodyModel.Index;
		BlockBodyView blockBodyView = blockViewsMap[id].GetBlockBodyView(index);
		GameObject gameObject = blockBodyView.gameObject;
		TwoPointBlock twoPointBlock = gameObject.GetComponent<TwoPointBlock>();
		if (twoPointBlock == null)
		{
			twoPointBlock = gameObject.AddComponent<TwoPointBlock>();
		}
		twoPointBlock.ParentBlockBodyView = blockBodyView;
		twoPointBlock.Place = TwoPointBlockType(CreationRendererType);
		twoPointBlock.endPointPosition = twoPointBlockModel.EndPointPosition;
		twoPointBlock.endPointRotation = twoPointBlockModel.EndPointRotation;
		twoPointBlock.MakeMesh();
		if (CreationRendererType == CreationRendererTypeEnum.Placeholder)
		{
			ObjectsInCollision componentInChildren = blockViewsMap[id].transform.GetComponentInChildren<ObjectsInCollision>(includeInactive: true);
			if (componentInChildren != null)
			{
				componentInChildren.RefreshForTwoPointBlock(twoPointBlockModel.EndPointPosition, twoPointBlockModel.EndPointRotation);
			}
		}
		TwoPointBlock.PlaceEnum TwoPointBlockType(CreationRendererTypeEnum creationRenderer)
		{
			switch (creationRenderer)
			{
			case CreationRendererTypeEnum.Rigid:
				return TwoPointBlock.PlaceEnum.Rigid;
			case CreationRendererTypeEnum.Model:
				return TwoPointBlock.PlaceEnum.Model;
			case CreationRendererTypeEnum.Placeholder:
				return TwoPointBlock.PlaceEnum.PlaceholderModel;
			default:
				return TwoPointBlock.PlaceEnum.Model;
			}
		}
	}

	public void SetLogicSystem(LogicSystemModel logicSystemModel)
	{
		if (LogicSystemView != null)
		{
			LogicSystemView.enabled = false;
			LogicSystemView.LogicSystemModel = logicSystemModel;
		}
	}

	public void ResetBlockIds(Dictionary<int, int> idConverterMap)
	{
		BlockView[] array = blockViewsMap.Values.ToArray();
		blockViewsMap.Clear();
		BlockView[] array2 = array;
		foreach (BlockView blockView in array2)
		{
			int key = (blockView.Id = idConverterMap[blockView.Id]);
			blockViewsMap.Add(key, blockView);
		}
	}

	public void ActiveCreation()
	{
		UpdateInterconnectedBlocksForAction();
		foreach (BlockView value in blockViewsMap.Values)
		{
			if (!value.CompareTag("Block"))
			{
				continue;
			}
			foreach (BlockBodyView allBlockBodyView in value.GetAllBlockBodyViews())
			{
				allBlockBodyView.SetUpToAction();
				if (!IsUnbreakableCreation)
				{
					continue;
				}
				value.Health = float.PositiveInfinity;
				foreach (FixedJointView allFixedJointView in allBlockBodyView.GetAllFixedJointViews())
				{
					allFixedJointView.FixedJoint.breakForce = float.PositiveInfinity;
					allFixedJointView.FixedJoint.breakTorque = float.PositiveInfinity;
				}
				foreach (HingeJointView allHingeJointView in allBlockBodyView.GetAllHingeJointViews())
				{
					allHingeJointView.HingeJoint.breakForce = float.PositiveInfinity;
					allHingeJointView.HingeJoint.breakTorque = float.PositiveInfinity;
				}
			}
		}
		LogicSystemView.enabled = true;
		IsInAction = true;
	}

	public void UpdateInterconnectedBlocksAfterJoint(int firstBlockId, int secondBlockId)
	{
		BlockView blockView = blockViewsMap[firstBlockId];
		BlockView blockView2 = blockViewsMap[secondBlockId];
		if (!(blockView.GroupLeaderBlockView == blockView2.GroupLeaderBlockView))
		{
			ICollection<BlockView> allInterconnectedBlocks = blockView2.GroupLeaderBlockView.GetAllInterconnectedBlocks();
			blockView2.GroupLeaderBlockView.ClearInterconnectedBlocks();
			blockView.GroupLeaderBlockView.AddInterconnectedBlockRange(allInterconnectedBlocks);
			Debug.Log("Updated interconnected blocks after joint");
		}
	}

	public void UpdateInterconnectedBlocksForBuild()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		List<List<int>> list = new List<List<int>>();
		foreach (BlockView value in blockViewsMap.Values)
		{
			value.ClearInterconnectedBlocks();
		}
		foreach (BlockView value2 in blockViewsMap.Values)
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
			Queue<BlockView> queue = new Queue<BlockView>();
			queue.Enqueue(value2);
			while (queue.Count != 0)
			{
				BlockView blockView = queue.Dequeue();
				List<BlockView> list3 = new List<BlockView>();
				list3.AddRange(blockView.GetAllDirectConnectedBlocks());
				list3.AddRange(blockView.GetAllIndirectConnectedBlocks());
				foreach (BlockView item2 in list3)
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
		Debug.Log("Updated interconnected blocks [" + (Time.realtimeSinceStartup - realtimeSinceStartup) * 1000f + " ms]");
		list.ForEach(delegate(List<int> blockIdGroup)
		{
			Debug.Log("[" + string.Join(", ", blockIdGroup) + "]");
		});
	}

	public void UpdateInterconnectedBlocksForAction()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		List<List<int>> list = new List<List<int>>();
		foreach (BlockView value in blockViewsMap.Values)
		{
			foreach (BlockBodyView allBlockBodyView in value.GetAllBlockBodyViews())
			{
				allBlockBodyView.ClearInterconnectedBlockBodies();
			}
		}
		foreach (BlockView value2 in blockViewsMap.Values)
		{
			foreach (BlockBodyView allBlockBodyView2 in value2.GetAllBlockBodyViews())
			{
				bool flag = false;
				int item = value2.Id * 100 + allBlockBodyView2.Index;
				foreach (List<int> item3 in list)
				{
					if (item3.Contains(item))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				List<int> list2 = new List<int> { item };
				Queue<BlockBodyView> queue = new Queue<BlockBodyView>();
				queue.Enqueue(allBlockBodyView2);
				while (queue.Count != 0)
				{
					BlockBodyView blockBodyView = queue.Dequeue();
					List<BlockBodyView> list3 = new List<BlockBodyView>();
					list3.AddRange(blockBodyView.GetAllDirectConnectedBlockBodies());
					list3.AddRange(blockBodyView.GetAllIndirectConnectedBlockBodies());
					list3.AddRange(blockBodyView.GetAllComponentConnectedBlockBodies());
					foreach (BlockBodyView item4 in list3)
					{
						int item2 = item4.ParentBlockView.Id * 100 + item4.Index;
						if (!list2.Contains(item2))
						{
							list2.Add(item2);
							queue.Enqueue(item4);
							allBlockBodyView2.AddInterconnectedBlockBodyView(item4);
						}
					}
				}
				list.Add(list2);
			}
		}
		Debug.Log("Updated interconnected blocks [" + (Time.realtimeSinceStartup - realtimeSinceStartup) * 1000f + " ms]");
		list.ForEach(delegate(List<int> blockBodyIdGroup)
		{
			Debug.Log("[" + string.Join(", ", blockBodyIdGroup) + "]");
		});
	}

	public void CentralizeCreation()
	{
		CreationUtil.CentralizeCreationView(this);
		base.transform.localPosition = Vector3.zero;
	}

	public Vector3 GetGeometricCenter()
	{
		return CreationUtil.CreationGeometricCenter(this);
	}

	public Vector3 GetMassCenter()
	{
		return CreationUtil.CreationMassCenter(this);
	}

	public Bounds GetCreationBounds()
	{
		return CreationUtil.CreationBounds(this);
	}

	public Vector3 GetCreationBoundsCenter()
	{
		return CreationUtil.CreationBoundsCenter(this);
	}

	public void MakeCreationNormal()
	{
		foreach (BlockView value in blockViewsMap.Values)
		{
			foreach (BlockBodyView allBlockBodyView in value.GetAllBlockBodyViews())
			{
				allBlockBodyView.SetMaterial(allBlockBodyView.BodySchematic.MainMaterial);
			}
		}
	}

	public void MakeCreationTransparent()
	{
		foreach (BlockView value in blockViewsMap.Values)
		{
			foreach (BlockBodyView allBlockBodyView in value.GetAllBlockBodyViews())
			{
				allBlockBodyView.SetMaterial(allBlockBodyView.BodySchematic.TransparentMaterial);
			}
		}
	}

	public void SetCreationTransparency(float value)
	{
		value = Mathf.Clamp(value, 0f, 1f);
		BlockView[] array = blockViewsMap.Values.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			BlockBodyView[] array2 = array[i].GetAllBlockBodyViews().ToArray();
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].SetMaterialTransparency(value);
			}
		}
	}

	public void SetBlockOutline(int blockId, bool isEnabled, int colorLine = 0)
	{
		if (blockViewsMap.ContainsKey(blockId))
		{
			blockViewsMap[blockId].SetOutline(isEnabled, colorLine);
		}
	}

	public void SetAllOutlines(bool isEnabled, int colorLine = 1)
	{
		foreach (BlockView value in blockViewsMap.Values)
		{
			value.SetOutline(isEnabled, colorLine);
		}
	}

	public void SetVisibility(bool isVisible)
	{
		foreach (BlockView value in blockViewsMap.Values)
		{
			value.SetVisibility(isVisible);
		}
	}

	public BlockView GetBlockView(int blockId)
	{
		return blockViewsMap[blockId];
	}

	public ICollection<BlockView> GetAllBlockViews()
	{
		return blockViewsMap.Values;
	}

	public BlockBodyView GetBlockBodyView(BlockBodyModel blockBodyModel)
	{
		int id = blockBodyModel.ParentBlockModel.Id;
		int index = blockBodyModel.Index;
		return blockViewsMap[id].GetBlockBodyView(index);
	}

	public BlockBodyView GetBlockBodyView(HingeJointModel hingeJointModel)
	{
		int id = hingeJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
		int index = hingeJointModel.ParentBlockBodyModel.Index;
		return blockViewsMap[id].GetBlockBodyView(index);
	}

	public ICollection<BaseComponentView> GetAllComponentViews()
	{
		List<BaseComponentView> list = new List<BaseComponentView>();
		foreach (BlockView allBlockView in GetAllBlockViews())
		{
			foreach (BlockBodyView allBlockBodyView in allBlockView.GetAllBlockBodyViews())
			{
				list.AddRange(allBlockBodyView.GetAllComponentViews());
			}
		}
		return list;
	}

	public int BlockViewsCount()
	{
		return blockViewsMap.Values.Count;
	}

	public void SetIOKeysOverwritability(int blockId, int bodyIndex, string[] defaultKeyIOIds, bool shouldOverwrite)
	{
		NotifyChange("CreationView.DefaultKeyIOsOverwritabilityEvent", blockId, bodyIndex, defaultKeyIOIds, shouldOverwrite);
	}

	private void BlockDestroyedHandler(BlockView destroyedBlockView)
	{
		NotifyChange("CreationView.BlockDestroyedEvent", destroyedBlockView);
	}

	public void RecycleAllBlocksBeforeDestroying()
	{
		foreach (BlockView value in blockViewsMap.Values)
		{
			ObjectPools.Instance.ReturnInstance(value.gameObject);
		}
	}

	public Rigidbody[] GetAllRigidbodies()
	{
		List<Rigidbody> list = new List<Rigidbody>();
		foreach (BlockView allBlockView in GetAllBlockViews())
		{
			foreach (BlockBodyView allBlockBodyView in allBlockView.GetAllBlockBodyViews())
			{
				list.Add(allBlockBodyView.BlockRigidbody);
				foreach (BaseComponentView allComponentView in allBlockBodyView.GetAllComponentViews())
				{
					list.AddRange(allComponentView.GetAllComponentRigidbodies());
				}
			}
		}
		return list.ToArray();
	}
}
