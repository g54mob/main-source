using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class ModifierLavaVisualManager : EntityBehaviourBase
{
	private static readonly int LavaAmount = Shader.PropertyToID("_lavaAmount");

	public GameObject lavaVisualPrefab;

	private List<PoolableEntityReference> _lavaVisuals = new List<PoolableEntityReference>();

	private List<Vector3> _lavaPositions = new List<Vector3>();

	public ModifierLava.State state;

	private float _currentScale;

	private float _currentLavaAmount;

	public float scaleSpeed = 0.5f;

	public float lavaSpeed = 0.5f;

	public float normalizedWarningTime;

	protected override void OnUpdatePresentation()
	{
		float num = 0f;
		float num2 = 0f;
		switch (state)
		{
		case ModifierLava.State.Waiting:
			num = -1f;
			num2 = -1f;
			break;
		case ModifierLava.State.Warning:
			num = 1f;
			num2 = -1f;
			break;
		case ModifierLava.State.Lava:
			num = 1f;
			num2 = 1f;
			break;
		case ModifierLava.State.CoolingDown:
			num = -1f;
			num2 = -1f;
			break;
		}
		_currentScale += num * Time.deltaTime;
		_currentScale = Mathf.Clamp(_currentScale, 0f, 1f);
		_currentLavaAmount += num2 * Time.deltaTime;
		_currentLavaAmount = Mathf.Clamp(_currentLavaAmount, 0f, 1f);
		Shader.SetGlobalFloat(LavaAmount, _currentLavaAmount);
		foreach (PoolableEntityReference lavaVisual in _lavaVisuals)
		{
			lavaVisual.gameObject.transform.localScale = new Vector3(_currentScale, _currentScale, _currentScale);
		}
	}

	public void UpdateSpawnPositions()
	{
		for (int i = 0; i < _lavaVisuals.Count; i++)
		{
			_lavaVisuals[i].gameObject.transform.position = _lavaPositions[i];
		}
	}

	public void AddLavaVisual(Vector3 lavaPosition)
	{
		PoolableEntityReference entityFromPrefabPool = lavaVisualPrefab.GetEntityFromPrefabPool();
		entityFromPrefabPool.entity.GetObject<LavaVisual>().modifierLavaVisualManager = this;
		entityFromPrefabPool.gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		_lavaPositions.Add(lavaPosition);
		_lavaVisuals.Add(entityFromPrefabPool);
		UpdateSpawnPositions();
	}

	public void ClearLavaVisuals()
	{
		foreach (PoolableEntityReference lavaVisual in _lavaVisuals)
		{
			lavaVisual.Release();
		}
		_lavaVisuals.Clear();
		_lavaPositions.Clear();
	}
}
