using System.Collections.Generic;
using UnityEngine;

public class CreationButtonsView : MonoBehaviourBaseView
{
	private List<GameObject> allRecyclableObjects;

	private Dictionary<string, GameObject> buttonsObjectsMap;

	public bool ShouldIncludeOnlyOutputKeys { get; set; }

	private void Awake()
	{
		allRecyclableObjects = new List<GameObject>();
		buttonsObjectsMap = new Dictionary<string, GameObject>();
		ShouldIncludeOnlyOutputKeys = false;
	}

	public void SetVisibility(bool isVisible)
	{
		base.gameObject.SetActive(isVisible);
	}

	public void SetPositions(Vector3 position, Quaternion rotation)
	{
		base.transform.localPosition = position;
		base.transform.localRotation = rotation;
	}

	public void AddHingeJointButton(BlockModel blockModel)
	{
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			foreach (HingeJointModel item in allBlockBodyModel.GetAllHingeJointModel())
			{
				Vector3 position = item.Position;
				Vector3 axisDirection = item.AxisDirection;
				GameObject gameObject = AddGenericButtonObject(blockModel, "HingeJointParent", position, axisDirection, "hinge_joint_button_3d");
				HingeJointButton3D component = gameObject.GetComponent<HingeJointButton3D>();
				component.Id = blockModel.Id + "-" + allBlockBodyModel.Index + "-" + item.Index;
				component.HingeJointModel = item;
				component.Initialize();
				new HingeJointButton3DController(component, item);
				allRecyclableObjects.Add(gameObject);
				buttonsObjectsMap.Add($"{blockModel.Id}.{allBlockBodyModel.Index}.{item.Index}", gameObject);
			}
		}
	}

	public void AddAllJointsButton(BlockModel blockModel)
	{
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			foreach (FixedJointModel item in allBlockBodyModel.GetAllFixedJointModel())
			{
				Vector3 position = item.Position;
				Vector3 axisDirection = item.AxisDirection;
				GameObject gameObject = AddGenericButtonObject(blockModel, "AllJointsParent", position, axisDirection, "all_joints_button_3d");
				AllJointsButton3D component = gameObject.GetComponent<AllJointsButton3D>();
				component.Id = blockModel.Id + "-" + allBlockBodyModel.Index + "-f" + item.Index;
				component.FixedJointModel = item;
				component.SetJointType((!item.IsFullJoint) ? AllJointsButton3D.JointTypeEnum.LessInfoFixed : AllJointsButton3D.JointTypeEnum.FullInfoFixed);
				if (item.IsFullJoint)
				{
					component.SetFirstAndSecondLinePositions(blockModel.Position, item.ConnectedBlockBodyModel.ParentBlockModel.Position);
				}
				else
				{
					component.SetLineFixedConnectorPositions(item.ConnectedBlockBodyModel.ParentBlockModel.Position);
				}
				allRecyclableObjects.Add(gameObject);
			}
			foreach (HingeJointModel item2 in allBlockBodyModel.GetAllHingeJointModel())
			{
				Vector3 position2 = item2.Position;
				Vector3 axisDirection2 = item2.AxisDirection;
				GameObject gameObject2 = AddGenericButtonObject(blockModel, "AllJointsParent", position2, axisDirection2, "all_joints_button_3d");
				AllJointsButton3D component2 = gameObject2.GetComponent<AllJointsButton3D>();
				component2.Id = blockModel.Id + "-" + allBlockBodyModel.Index + "-h" + item2.Index;
				component2.HingeJointModel = item2;
				component2.SetJointType(AllJointsButton3D.JointTypeEnum.Hinge);
				component2.SetFirstAndSecondLinePositions(blockModel.Position, item2.ConnectedBlockBodyModel.ParentBlockModel.Position);
				allRecyclableObjects.Add(gameObject2);
			}
		}
	}

	private GameObject AddGenericButtonObject(BlockModel blockModel, string name, Vector3 position, Vector3 direction, string objectPoolId)
	{
		GameObject gameObject = new GameObject(name);
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localPosition = blockModel.Position;
		gameObject.transform.localRotation = blockModel.Rotation;
		GameObject instance = ObjectPools.Instance.GetInstance(objectPoolId);
		instance.transform.SetParent(gameObject.transform);
		instance.transform.localPosition = position;
		instance.transform.localRotation = Quaternion.FromToRotation(Vector3.down, direction);
		return instance;
	}

	public void AddComponentButton(BlockModel blockModel)
	{
		if (blockModel.HasUserEditableProperties(ShouldIncludeOnlyOutputKeys))
		{
			AddBlockModelButton3D(blockModel);
		}
	}

	public void AddLogicIOsButton(BlockModel blockModel)
	{
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			if (blockModel.HasAnyDefaultKeyIO() && !allBlockBodyModel.HasOnlyHiddenDefaultKeyIOs())
			{
				AddComponentButton(blockModel);
				AddHingeJointButton(blockModel);
				break;
			}
		}
	}

	public void AddMotorBlockButton(BlockModel blockModel)
	{
		if (blockModel.HasAnyMotorComponent())
		{
			AddBlockModelButton3D(blockModel);
		}
	}

	private void AddBlockModelButton3D(BlockModel blockModel)
	{
		GameObject instance = ObjectPools.Instance.GetInstance(ObjectNames.SchematicIdForButton(blockModel.Schematic.Id));
		instance.transform.SetParent(base.transform);
		instance.transform.localPosition = blockModel.Position;
		instance.transform.localRotation = blockModel.Rotation;
		BlockView component = instance.GetComponent<BlockView>();
		component.Id = blockModel.Id;
		int num = 0;
		foreach (BlockBodyView allBlockBodyView in component.GetAllBlockBodyViews())
		{
			BlockBodyModelButton3D component2 = allBlockBodyView.gameObject.GetComponent<BlockBodyModelButton3D>();
			component2.Id = blockModel.Id.ToString();
			component2.BlockBodyModel = blockModel.GetBlockBodyModel(allBlockBodyView.Index);
			foreach (BaseComponentView allComponentView in allBlockBodyView.GetAllComponentViews())
			{
				ComponentModel componentModel = blockModel.GetBlockBodyModel(num).GetComponentModel(allComponentView.GetComponentName());
				allComponentView.ComponentModel = componentModel;
				allComponentView.InitializeModel();
			}
			num++;
		}
		allRecyclableObjects.Add(instance);
		buttonsObjectsMap.Add(blockModel.Id.ToString(), instance);
	}

	public void RecycleAllObjectsBeforeDestroying()
	{
		foreach (GameObject allRecyclableObject in allRecyclableObjects)
		{
			ObjectPools.Instance.ReturnInstance(allRecyclableObject);
		}
		allRecyclableObjects.Clear();
		buttonsObjectsMap.Clear();
	}

	public void SetButton3DHighlight(string buttonId, bool isHighlight)
	{
		if (buttonsObjectsMap.ContainsKey(buttonId))
		{
			OutlineButton3D componentInChildren = buttonsObjectsMap[buttonId].GetComponentInChildren<OutlineButton3D>();
			if (isHighlight)
			{
				componentInChildren.SetHighlightedColor();
			}
			else
			{
				componentInChildren.SetOriginalColor();
			}
		}
	}
}
