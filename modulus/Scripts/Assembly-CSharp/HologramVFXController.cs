using System;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using Presentation.FactoryFloor.FactoryObjectViews.HologramVFX;
using UnityEngine;

public class HologramVFXController : MonoBehaviour
{
	[SerializeField]
	private Transform _normalParent;

	[SerializeField]
	private Transform _hologramParent;

	[SerializeField]
	[ReadOnly]
	private List<Collider> _normalColliders = new List<Collider>();

	[SerializeField]
	[ReadOnly]
	private List<Renderer> _hologramRenderers = new List<Renderer>();

	[SerializeField]
	[ReadOnly]
	private float _renderersTopPoint;

	[SerializeField]
	[ReadOnly]
	private float _renderersBottomPoint;

	[SerializeField]
	private HologramVFXSettings _hologramVFXSettings;

	private MaterialPropertyBlock _propBlock;

	private bool _showingValidColors = true;

	public Transform NormalParent => _normalParent;

	public event Action NormalVersionShown;

	private void Awake()
	{
		InitPropBlock();
		_propBlock.SetFloat("_BuildingAppear", _renderersBottomPoint);
		ApplyPropertyBlock();
	}

	private void InitPropBlock()
	{
		if (_propBlock == null)
		{
			_propBlock = new MaterialPropertyBlock();
		}
	}

	private void ApplyPropertyBlock()
	{
		foreach (Renderer hologramRenderer in _hologramRenderers)
		{
			hologramRenderer.SetPropertyBlock(_propBlock);
		}
	}

	[Button(null, EButtonEnableMode.Always)]
	private void OnValidate()
	{
		_normalColliders.Clear();
		_hologramRenderers.Clear();
		if (_hologramParent == null)
		{
			return;
		}
		_renderersTopPoint = 0f;
		_renderersBottomPoint = float.MaxValue;
		GetComponentsInChildren(includeInactive: true, _normalColliders);
		_hologramParent.GetComponentsInChildren(includeInactive: true, _hologramRenderers);
		foreach (Renderer hologramRenderer in _hologramRenderers)
		{
			_renderersTopPoint = Mathf.Max(_renderersTopPoint, hologramRenderer.bounds.center.y + hologramRenderer.bounds.extents.y);
			_renderersBottomPoint = Mathf.Min(_renderersBottomPoint, hologramRenderer.bounds.center.y - hologramRenderer.bounds.extents.y);
		}
		_renderersTopPoint += 0.5f;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ShowNormalVersion()
	{
		_normalParent.gameObject.SetActive(value: true);
		_hologramParent.gameObject.SetActive(value: false);
		foreach (Collider normalCollider in _normalColliders)
		{
			normalCollider.enabled = true;
		}
		this.NormalVersionShown?.Invoke();
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ShowHologramVersion()
	{
		InitPropBlock();
		_normalParent.gameObject.SetActive(value: false);
		_hologramParent.gameObject.SetActive(value: true);
		foreach (Collider normalCollider in _normalColliders)
		{
			normalCollider.enabled = false;
		}
		_propBlock.SetFloat("_BuildingAppear", _renderersBottomPoint);
		ApplyPropertyBlock();
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AnimateToNormalVersion()
	{
		InitPropBlock();
		ShowHologramVersion();
		DOVirtual.Float(_renderersBottomPoint, _renderersTopPoint, _hologramVFXSettings.AnimateTime, delegate(float time)
		{
			_propBlock.SetFloat("_BuildingAppear", time);
			ApplyPropertyBlock();
		}).SetEase(Ease.OutQuad).OnComplete(ShowNormalVersion);
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SetValidColors()
	{
		if (!_showingValidColors)
		{
			_showingValidColors = true;
			InitPropBlock();
			_propBlock.SetVector("_Color", _hologramVFXSettings.ValidOutlineColor);
			_propBlock.SetVector("_HologramHighPeakColor", _hologramVFXSettings.ValidHighPeakColor);
			_propBlock.SetVector("_HologramLowPeakColor", _hologramVFXSettings.ValidLowPeakColor);
			ApplyPropertyBlock();
		}
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SetInvalidColors()
	{
		if (_showingValidColors)
		{
			_showingValidColors = false;
			InitPropBlock();
			_propBlock.SetVector("_Color", _hologramVFXSettings.InvalidOutlineColor);
			_propBlock.SetVector("_HologramHighPeakColor", _hologramVFXSettings.InvalidHighPeakColor);
			_propBlock.SetVector("_HologramLowPeakColor", _hologramVFXSettings.InvalidLowPeakColor);
			ApplyPropertyBlock();
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(Vector3.up * _renderersTopPoint, 0.1f);
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(Vector3.up * _renderersBottomPoint, 0.1f);
	}
}
