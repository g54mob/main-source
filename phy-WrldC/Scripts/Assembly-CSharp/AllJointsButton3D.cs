using UnityEngine;

public class AllJointsButton3D : OutlineButton3D, IRecyclableObject
{
	public enum JointTypeEnum
	{
		FullInfoFixed = 0,
		LessInfoFixed = 1,
		Hinge = 2
	}

	private GameObject fixedConnectorObject;

	private GameObject hingeConnectorObject;

	private LineComponent fixedConnectorLine;

	private LineComponent firstBlockLine;

	private LineComponent secondBlockLine;

	public string ObjectTypeId { get; set; }

	public JointTypeEnum JointType { get; private set; }

	public HingeJointModel HingeJointModel { get; set; }

	public FixedJointModel FixedJointModel { get; set; }

	private void Awake()
	{
		fixedConnectorObject = base.transform.Find("FixedConnector").gameObject;
		hingeConnectorObject = base.transform.Find("HingeConnector").gameObject;
		fixedConnectorLine = base.transform.FindComponent<LineComponent>("LineFixedConnector", isRecursively: true);
		fixedConnectorLine.Initialize(base.transform);
		firstBlockLine = base.transform.FindComponent<LineComponent>("FirstBlockLine", isRecursively: true);
		firstBlockLine.Initialize(base.transform);
		secondBlockLine = base.transform.FindComponent<LineComponent>("SecondBlockLine", isRecursively: true);
		secondBlockLine.Initialize(base.transform);
		fixedConnectorObject.SetActive(value: false);
		hingeConnectorObject.SetActive(value: false);
		fixedConnectorLine.SetVisibility(isVisible: false);
		firstBlockLine.SetVisibility(isVisible: false);
		secondBlockLine.SetVisibility(isVisible: false);
	}

	public void SetJointType(JointTypeEnum jointType)
	{
		JointType = jointType;
		switch (JointType)
		{
		case JointTypeEnum.FullInfoFixed:
			fixedConnectorObject.SetActive(value: true);
			hingeConnectorObject.SetActive(value: false);
			fixedConnectorLine.SetVisibility(isVisible: false);
			firstBlockLine.SetVisibility(isVisible: true);
			secondBlockLine.SetVisibility(isVisible: true);
			break;
		case JointTypeEnum.LessInfoFixed:
			fixedConnectorObject.SetActive(value: false);
			hingeConnectorObject.SetActive(value: false);
			fixedConnectorLine.SetVisibility(isVisible: true);
			firstBlockLine.SetVisibility(isVisible: false);
			secondBlockLine.SetVisibility(isVisible: false);
			break;
		case JointTypeEnum.Hinge:
			fixedConnectorObject.SetActive(value: false);
			hingeConnectorObject.SetActive(value: true);
			fixedConnectorLine.SetVisibility(isVisible: false);
			firstBlockLine.SetVisibility(isVisible: true);
			secondBlockLine.SetVisibility(isVisible: true);
			break;
		}
	}

	public void SetFirstAndSecondLinePositions(Vector3 endFirstPostion, Vector3 endSecondPosition)
	{
		Vector3 endPosition = base.transform.parent.parent.TransformPoint(endFirstPostion);
		Vector3 endPosition2 = base.transform.parent.parent.TransformPoint(endSecondPosition);
		firstBlockLine.SetPositions(base.transform.position, endPosition);
		secondBlockLine.SetPositions(base.transform.position, endPosition2);
	}

	public void SetLineFixedConnectorPositions(Vector3 endBlockPosition)
	{
		Vector3 endPosition = base.transform.parent.parent.TransformPoint(endBlockPosition);
		fixedConnectorLine.SetPositions(base.transform.position, endPosition);
	}

	public void OnInstantiation()
	{
	}

	public void OnUnistantiation()
	{
		if (base.Controller != null)
		{
			base.Controller = null;
		}
	}
}
