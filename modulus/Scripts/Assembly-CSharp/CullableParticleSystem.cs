using System;
using JobSystem;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.Culling;
using UnityEngine;

public class CullableParticleSystem : MonoBehaviour, ICullable
{
	[SerializeField]
	private CullableSettingsSO _cullableParticleSettings;

	[SerializeField]
	private ParticleSystem _particleSystem;

	[SerializeField]
	private FactoryObjectView _factoryObjectView;

	private CullablePositionInfo _cachedPosition;

	private bool _culled;

	private bool _positionDirty;

	private CullableObjectState _cullableState;

	public Action<CullableObjectState, CullableObjectState> OnNewCullState { get; set; } = delegate
	{
	};

	public CullableObjectState CurrentState => _cullableState;

	public bool IsCulledOrShadowsOnly
	{
		get
		{
			if (_cullableState != CullableObjectState.Culled)
			{
				return _cullableState == CullableObjectState.ShadowsOnly;
			}
			return true;
		}
	}

	public void Awake()
	{
		_positionDirty = true;
		CullingJobManager.RegisterCullable(this);
		if (_factoryObjectView == null)
		{
			_factoryObjectView = GetComponentInParent<FactoryObjectView>();
		}
		if (_factoryObjectView != null)
		{
			_factoryObjectView.OnShowView += RefreshCullingPosition;
		}
	}

	public void OnCull()
	{
		if (!_culled)
		{
			_particleSystem.gameObject.SetActive(value: false);
			_culled = true;
		}
	}

	public void OnVisible()
	{
		if (_culled)
		{
			_particleSystem.gameObject.SetActive(value: true);
			_culled = false;
		}
	}

	public void OnDestroy()
	{
		if (CullingJobManager.Instance != null)
		{
			CullingJobManager.UnRegisterCullable(this);
		}
		if (_factoryObjectView != null)
		{
			_factoryObjectView.OnShowView -= RefreshCullingPosition;
		}
		_factoryObjectView = null;
	}

	public CullableSettings GetSettings()
	{
		return _cullableParticleSettings.ToCullableSettings();
	}

	public CullablePositionInfo GetPosition()
	{
		if (_positionDirty)
		{
			_cachedPosition = new CullablePositionInfo
			{
				Position = _particleSystem.gameObject.transform.position,
				Bounds = _particleSystem.GetComponent<ParticleSystemRenderer>().localBounds.size,
				Island = ((_factoryObjectView != null && _factoryObjectView.FactoryObject != null) ? _factoryObjectView.FactoryObject.GetIsland() : null)
			};
			_positionDirty = false;
		}
		return _cachedPosition;
	}

	public void RefreshCullingPosition(bool isLoading)
	{
		_positionDirty = true;
	}

	public void UpdateCullState(CullableObjectState cull)
	{
		if (_cullableState != cull)
		{
			if (cull >= CullableObjectState.LOD && !_culled)
			{
				OnCull();
			}
			else if (cull == CullableObjectState.Normal && _culled)
			{
				OnVisible();
			}
			OnNewCullState(cull, _cullableState);
			_cullableState = cull;
		}
	}
}
