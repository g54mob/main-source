using UnityEngine;

public class HingeJointButton3D : OutlineButton3D, IRecyclableObject
{
	private enum SpecializedJointTypeEnum
	{
		None = 0,
		Motor = 1,
		Steerable = 2,
		Stepper = 3
	}

	private GameObject arcArrowObject;

	private GameObject singleArcArrowObject;

	private LineComponent transmissionLine;

	private LineComponent anchorLine;

	private SpriteRenderer gearIcon;

	private SteerableIndicators steerableIndicators;

	private float degreesPerSecond;

	private SpecializedJointTypeEnum specializedJointType;

	private bool isClockwiseRotation;

	private bool isLogicInverted;

	public HingeJointModel HingeJointModel { get; set; }

	public string ObjectTypeId { get; set; }

	private void Awake()
	{
		arcArrowObject = base.transform.Find("ArcArrow").gameObject;
		singleArcArrowObject = base.transform.Find("SingleArcArrow").gameObject;
		steerableIndicators = base.transform.FindComponent<SteerableIndicators>("SteerableIndicators");
		transmissionLine = base.transform.FindComponent<LineComponent>("TransmissionLine");
		transmissionLine.Initialize(base.transform, GameManager.Instance.CameraManager.OrbitCamera.transform.GetChild(0).transform);
		anchorLine = base.transform.FindComponent<LineComponent>("AnchorLine");
		anchorLine.Initialize(base.transform);
		gearIcon = transmissionLine.transform.FindComponent<SpriteRenderer>("StartLinePoint");
	}

	protected override void Start()
	{
		base.Start();
	}

	public void Initialize()
	{
		arcArrowObject.SetActive(value: false);
		transmissionLine.SetVisibility(isVisible: false);
		steerableIndicators.SetVisibility(isVisible: false);
		specializedJointType = SpecializedJointTypeEnum.None;
		isClockwiseRotation = false;
		isLogicInverted = false;
	}

	public void UpdateAnchorLinePosition(Vector3 blockPosition)
	{
		Vector3 endPosition = base.transform.parent.parent.TransformPoint(blockPosition);
		anchorLine.SetPositions(base.transform.position, endPosition);
	}

	public void UpdateConnectedMotorLine(Vector3 blockPosition)
	{
		Vector3 endPosition = base.transform.parent.parent.TransformPoint(blockPosition);
		transmissionLine.SetPositions(base.transform.position, endPosition);
		transmissionLine.SetVisibility(isVisible: true);
	}

	public void HideConnectedMotorLine()
	{
		transmissionLine.SetVisibility(isVisible: false);
	}

	public void UpdateMotorJointGizmos(bool isClockwiseRotation)
	{
		arcArrowObject.SetActive(value: true);
		singleArcArrowObject.SetActive(value: false);
		steerableIndicators.SetVisibility(isVisible: false);
		SetArchArrowDirection(isClockwiseRotation);
		specializedJointType = SpecializedJointTypeEnum.Motor;
	}

	public void UpdateSteerableJointGizmos(float forwardTargetAngle, float backwardTargetAngle, float angleOffset)
	{
		arcArrowObject.SetActive(value: false);
		singleArcArrowObject.SetActive(value: false);
		steerableIndicators.SetVisibility(isVisible: true);
		steerableIndicators.SetParameters(forwardTargetAngle, backwardTargetAngle, angleOffset);
		specializedJointType = SpecializedJointTypeEnum.Steerable;
	}

	public void UpdateStepperJointGizmos(bool isClockwiseRotation, float degreesPerSecond)
	{
		arcArrowObject.SetActive(value: false);
		singleArcArrowObject.SetActive(value: true);
		steerableIndicators.SetVisibility(isVisible: false);
		SetArchArrowDirection(isClockwiseRotation);
		this.degreesPerSecond = degreesPerSecond;
		specializedJointType = SpecializedJointTypeEnum.Stepper;
	}

	public void HideSpecializedJointsGizmos()
	{
		arcArrowObject.SetActive(value: false);
		singleArcArrowObject.SetActive(value: false);
		steerableIndicators.SetVisibility(isVisible: false);
		specializedJointType = SpecializedJointTypeEnum.None;
	}

	public void InvertRotationalIndicatorsLogic(bool isLogicInverted)
	{
		this.isLogicInverted = isLogicInverted;
		steerableIndicators.transform.SetLocalEulerRotationX(isLogicInverted ? (-90) : 90);
		SetArchArrowDirection(isClockwiseRotation);
	}

	public void UpdateConnectionPathIndicator(bool isTherePath)
	{
		gearIcon.color = (isTherePath ? Color.white : Color.red);
	}

	protected void Update()
	{
		if (specializedJointType == SpecializedJointTypeEnum.Motor)
		{
			arcArrowObject.transform.Rotate(Vector3.forward, Time.deltaTime * -50f, Space.Self);
		}
		else if (specializedJointType == SpecializedJointTypeEnum.Stepper)
		{
			singleArcArrowObject.transform.Rotate(Vector3.forward, Time.deltaTime * (0f - degreesPerSecond), Space.Self);
		}
	}

	private void SetArchArrowDirection(bool isClockwise)
	{
		isClockwiseRotation = isClockwise;
		if (isLogicInverted)
		{
			isClockwise = !isClockwise;
		}
		arcArrowObject.transform.SetLocalEulerRotationX(isClockwise ? (-90) : 90);
		singleArcArrowObject.transform.SetLocalEulerRotationX(isClockwise ? 90 : (-90));
	}

	public void OnInstantiation()
	{
	}

	public void OnUnistantiation()
	{
		DetachController();
	}
}
