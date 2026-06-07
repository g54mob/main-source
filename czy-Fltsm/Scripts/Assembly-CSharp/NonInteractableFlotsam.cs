using System.Collections;
using UnityEngine;

public class NonInteractableFlotsam : FlotsamBehaviour, IUpdateManagerLateUpdateTarget
{
	private Transform _transform;

	private Vector3 _position;

	private WaterManager.WaterHeightCalculation _waterHeightCalculation;

	private Renderer _renderer;

	private float _compositionProgress;

	private bool _buoyant = true;

	public override bool Interactable => false;

	public override bool Initialize(FlotsamProperties properties, int visualPrefabIndex = -1)
	{
		if (base.Initialize(properties, visualPrefabIndex))
		{
			InitializeVisual(removeCollider: true);
			_transform = base.transform;
			_position = _transform.position;
			_waterHeightCalculation = new WaterManager.WaterHeightCalculation(base.transform, OnWaterHeightCalculationCallback);
			_renderer = GetComponentInChildren<Renderer>();
			_waterHeightCalculation.Queue(base.transform.position);
			_buoyant = true;
			GameManager.UpdateManager.RegisterLateUpdateTarget(this);
			return true;
		}
		return false;
	}

	public void UpdateManager_LateUpdate()
	{
		if (_buoyant && _renderer.isVisible)
		{
			_waterHeightCalculation.Queue(_position);
		}
	}

	public override void InitializeComposition(CompositionInventory composition)
	{
		_compositionProgress = composition.ReturnProgress();
		if ((bool)base.VisualPrefab)
		{
			base.VisualPrefab.SetProgress(_compositionProgress);
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

	private IEnumerator ThrowCoroutine(ThrowProperties throwProperties)
	{
		yield return ThrowMovementCoroutine(throwProperties);
		base.transform.localScale = Vector3.one;
		FlotsamPool.Instance.Release(this);
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
		GameManager.UpdateManager.RegisterLateUpdateTarget(this);
	}

	public override void Deactivate()
	{
		base.Deactivate();
		_buoyant = false;
		GameManager.UpdateManager.UnregisterLateUpdateTarget(this);
	}

	public override float ReturnCompositionProgress()
	{
		return _compositionProgress;
	}
}
