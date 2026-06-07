using UnityEngine;

public class TargetDetector : BaseComponentView
{
	private LogicIO targetDetectedOutput;

	private Collider goalZoneCollider;

	private Renderer thisRenderer;

	private bool isInsideGoalZone;

	private void Awake()
	{
		thisRenderer = GetComponentInChildren<Renderer>(includeInactive: true);
		SetMaterialEmission(isOn: false);
	}

	private void Update()
	{
		if (goalZoneCollider == null)
		{
			return;
		}
		Vector3 center = goalZoneCollider.bounds.center;
		Vector3 extents = goalZoneCollider.bounds.extents;
		float x = base.transform.position.x;
		float y = base.transform.position.y;
		float z = base.transform.position.z;
		if (x >= center.x - extents.x && x <= center.x + extents.x && y >= center.y - extents.y && y <= center.y + extents.y && z >= center.z - extents.z && z <= center.z + extents.z)
		{
			if (!isInsideGoalZone)
			{
				targetDetectedOutput.SetSignal(digitalSignal: true);
				SetMaterialEmission(isOn: true);
				isInsideGoalZone = true;
			}
		}
		else if (isInsideGoalZone)
		{
			targetDetectedOutput.SetSignal(digitalSignal: false);
			SetMaterialEmission(isOn: false);
			isInsideGoalZone = false;
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		targetDetectedOutput.SetSignal(digitalSignal: false);
		SetMaterialEmission(isOn: false);
		isInsideGoalZone = false;
		if (LevelManager.Exist)
		{
			goalZoneCollider = LevelManager.Instance.goalZone.GetComponent<Collider>();
		}
		else
		{
			goalZoneCollider = null;
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		base.BlockBodyView.OnSetMaterialEvent += delegate
		{
			SetMaterialEmission(isOn: false);
		};
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		targetDetectedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("td_target_detected", LogicIODirection.Output, digitalSignal: false));
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		SetMaterialEmission(isOn: false);
	}

	protected override void InternalResetModel()
	{
		base.InternalResetModel();
		base.BlockBodyView.OnSetMaterialEvent += delegate
		{
			SetMaterialEmission(isOn: false);
		};
	}

	public void SetMaterialEmission(bool isOn)
	{
		thisRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
		thisRenderer.material.EnableKeyword("_EMISSION");
		thisRenderer.material.SetColor("_EmissionColor", Color.HSVToRGB(0f, 0f, isOn ? 5 : 0));
	}

	public override string GetComponentName()
	{
		return typeof(TargetDetector).Name;
	}
}
