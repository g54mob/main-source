using UnityEngine;

public class NoCollisionBuoyantFlotsam : Flotsam
{
	private bool _buoyant = true;

	private Transform _transform;

	private Vector3 _position;

	private WaterManager.WaterHeightCalculation _waterHeightCalculation;

	public override bool Initialize(FlotsamProperties properties, int visualPrefabIndex)
	{
		if (!base.Initialize(properties, visualPrefabIndex))
		{
			return false;
		}
		_transform = base.transform;
		_position = _transform.position;
		_waterHeightCalculation = new WaterManager.WaterHeightCalculation(base.transform, OnWaterHeightCalculationCallback);
		_waterHeightCalculation.Queue(base.transform.position);
		_buoyant = true;
		return true;
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (_buoyant)
		{
			_waterHeightCalculation.Queue(_position);
		}
	}

	public override void UpdatePositionAndRotation(Vector3 position, Quaternion rotation)
	{
		base.UpdatePositionAndRotation(position, rotation);
		_position = position;
	}

	public override void Throw(ThrowProperties throwProperties)
	{
		_buoyant = false;
		StartCoroutine(ThrowCoroutine(throwProperties));
	}

	private void OnWaterHeightCalculationCallback(WaterManager.WaterHeightCalculation calculation)
	{
		if (_buoyant)
		{
			_position.y = calculation.PositionWaterHeight;
			_transform.position = _position;
		}
	}

	public override void Activate(Vector3 position)
	{
		base.Activate(position);
		_buoyant = true;
		_position = position;
		_waterHeightCalculation.Queue(_position);
	}

	public override void Deactivate()
	{
		base.Deactivate();
		_buoyant = false;
	}
}
