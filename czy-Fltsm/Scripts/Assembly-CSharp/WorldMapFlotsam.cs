using System.Collections;
using System.Collections.Generic;
using PajamaLlama;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;

public class WorldMapFlotsam : WorldMapPointOfInterest
{
	private PointOfInterestSpawner _spawner;

	private WorldMapCameraController _cameraController;

	private VisualPrefab _visualPrefab;

	private bool _frustumCulling;

	private Bounds _bounds;

	public void Initialize(PointOfInterestSpawner spawner)
	{
		VisualPrefab mapVisualPrefab = spawner.Properties.MapVisualPrefab;
		_spawner = spawner;
		_cameraController = GameManager.WorldMapManager.WorldMap.WorldCameraController;
		base.name = _spawner.Properties.name;
		base.transform.localPosition = _spawner.TilePosition.Vector3TopDown();
		base.transform.rotation = mapVisualPrefab.ReturnRandomRotation();
		if (mapVisualPrefab.FrustumCulling)
		{
			_frustumCulling = mapVisualPrefab.FrustumCulling;
			_bounds = mapVisualPrefab.Bounds;
			_bounds.center += base.transform.position;
		}
		base.Spawner = spawner;
		Update();
		Initialize((ISpawner)spawner);
	}

	private void Update()
	{
		if (_spawner.ScoutingState == ScoutingState.None)
		{
			return;
		}
		if (_frustumCulling && _cameraController.Frustum.IsCulled(_bounds))
		{
			RepoolVisualPrefab();
		}
		else if (_visualPrefab == null)
		{
			_visualPrefab = PrefabPool.GetInstance(_spawner.Properties.MapVisualPrefab, base.transform);
			_visualPrefab.gameObject.SetActive(value: true);
			_visualPrefab.transform.Reset();
			if ((bool)_visualPrefab.WorldMapReveal)
			{
				_visualPrefab.WorldMapReveal.Initialize(this);
			}
			_spawner.OnSalvaged.AddListener(OnSalvage);
			OnSalvage(_spawner);
		}
	}

	public override bool InitializeReveal()
	{
		if (_visualPrefab != null && _visualPrefab.WorldMapReveal != null)
		{
			return _visualPrefab.WorldMapReveal.InitializeReveal(this);
		}
		return false;
	}

	public override IEnumerator RevealRoutine()
	{
		if (_visualPrefab != null && _visualPrefab.WorldMapReveal != null)
		{
			yield return _visualPrefab.WorldMapReveal.Reveal(this);
		}
	}

	private void OnSalvage(ISpawner spawner)
	{
		float num = _spawner.ReturnSpawnerCount();
		float num2 = num / (float)_spawner.Properties.MapVisualCount;
		float num3 = _spawner.Properties.MapVisualMinimumScale + (1f - _spawner.Properties.MapVisualMinimumScale) * num2;
		_visualPrefab.transform.localScale = Vector3.one * num3;
		if (num == 0f)
		{
			RepoolVisualPrefab();
			Object.Destroy(base.gameObject);
		}
	}

	private void RepoolVisualPrefab()
	{
		if ((bool)_visualPrefab)
		{
			PrefabPool.Repool(_visualPrefab);
		}
		_visualPrefab = null;
		_spawner.OnSalvaged.RemoveListener(OnSalvage);
	}

	public IReadOnlyList<FlotsamProperties> GetAllFlotsamProperties()
	{
		return _spawner.GetAllFlotsamProperties();
	}
}
