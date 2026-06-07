using UnityEngine;

public class SpeedSensor : BaseComponentView
{
	private LogicIO globalSpeedOutput;

	private LogicIO xSpeedOutput;

	private LogicIO ySpeedOutput;

	private LogicIO zSpeedOutput;

	private Rigidbody rb;

	private void Update()
	{
		Vector3 vector = base.transform.InverseTransformVector(rb.velocity);
		globalSpeedOutput.SetSignal(rb.velocity.magnitude);
		xSpeedOutput.SetSignal(vector.x);
		ySpeedOutput.SetSignal(vector.y);
		zSpeedOutput.SetSignal(vector.z);
	}

	public override string GetComponentName()
	{
		return typeof(SpeedSensor).Name;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		rb = base.BlockBodyView.BlockRigidbody;
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		globalSpeedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("ss_global_out", LogicIODirection.Output, 0f)
		{
			ValueType = LogicIOValueType.Raw
		});
		xSpeedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("ss_x_out", LogicIODirection.Output, 0f)
		{
			ValueType = LogicIOValueType.Raw
		});
		ySpeedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("ss_y_out", LogicIODirection.Output, 0f)
		{
			ValueType = LogicIOValueType.Raw
		});
		zSpeedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("ss_z_out", LogicIODirection.Output, 0f)
		{
			ValueType = LogicIOValueType.Raw
		});
	}

	protected override void InternalInitializeGizmos<SpeedSensorModel>(SpeedSensorModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		InstantiateGizmoObject("SpeedSensorGizmo");
	}
}
