using UnityEngine;

public class DistanceSensor : BaseComponentView
{
	private LogicIO obstacleOutput;

	private LogicIO distanceOutput;

	private float maxDistance;

	private Renderer thisRenderer;

	private void Awake()
	{
		thisRenderer = GetComponentInChildren<Renderer>(includeInactive: true);
		SetMaterialEmission(isOn: false);
	}

	private void Update()
	{
		if (Physics.Raycast(base.transform.position, base.transform.up, out var hitInfo, maxDistance, LayerNames.BlockMask | LayerNames.LevelMask))
		{
			float signal = hitInfo.distance / maxDistance;
			obstacleOutput.SetSignal(digitalSignal: true);
			distanceOutput.SetSignal(signal);
			SetMaterialEmission(isOn: true);
		}
		else
		{
			obstacleOutput.SetSignal(digitalSignal: false);
			distanceOutput.SetSignal(1f);
			SetMaterialEmission(isOn: false);
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		maxDistance = base.BlockBodyView.OverridableProperties.GetPropertyAsFloat("ds_max_range", 3f);
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
		obstacleOutput = base.BlockBodyView.AddLogicIO(new LogicIO("ds_obstacle_out", LogicIODirection.Output, 0f));
		distanceOutput = base.BlockBodyView.AddLogicIO(new LogicIO("ds_distance_out", LogicIODirection.Output, 0f));
	}

	protected override void InternalInitializeGizmos<DistanceSensorModel>(DistanceSensorModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		InstantiateGizmoObject("DistanceSensorGizmo");
	}

	protected override void InternalInitializeModel()
	{
		base.InternalInitializeModel();
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
		return typeof(DistanceSensor).Name;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(base.transform.position, base.transform.up);
	}
}
