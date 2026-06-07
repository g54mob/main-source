using System;
using Data.FactoryFloor;
using JobSystem;
using NaughtyAttributes;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.Culling;
using Presentation.FactoryFloor.FactoryObjectViews;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

[ExecuteAlways]
public class FactoryObjectViewCullingController : MonoBehaviour, ICullable
{
	[ValidateInput("NormalIsntLOD", "One of your LOD versions is also assigned as a normal version, not allowed >:(\nInstead use this toggle!")]
	[SerializeField]
	private bool _normalIsAlsoLOD;

	[SerializeField]
	private bool _autoFillRefs;

	[SerializeField]
	private Transform _normalParent;

	[SerializeField]
	private Transform _lowDetailParent;

	[Space]
	[SerializeField]
	private MeshRenderer[] _normalMeshRenderers;

	[SerializeField]
	private MeshRenderer[] _lowDetailMeshRenderers;

	[SerializeField]
	private ParticleSystemRenderer[] _normalParticleSystems;

	[SerializeField]
	private ParticleSystemRenderer[] _lowDetailParticleSystems;

	[SerializeField]
	private Animator[] _normalAnimators;

	[SerializeField]
	private Animator[] _lowDetailAnimators;

	[SerializeField]
	private VisualEffect[] _normalVisualEffects;

	[SerializeField]
	private VisualEffect[] _lowDetailVisualEffects;

	[SerializeField]
	private Canvas[] _normalCanvases = new Canvas[0];

	[SerializeField]
	private FactoryObjectViewAudioData[] _loopingAudioEventData;

	[SerializeField]
	private bool _keepLoopingAudioAtLOD;

	[SerializeField]
	private CullableSettingsSO _cullableSettings;

	[SerializeField]
	private FactoryObjectView _factoryObjectView;

	[SerializeField]
	private HologramVFXController _hologramVFXController;

	private FactoryObject _factoryObject;

	private CullableObjectState _currentState;

	private CullablePositionInfo _cachedPosition;

	private bool _hasLODState;

	private Vector3 _overriddenBounds;

	private bool _overrideBounds;

	public Action<CullableObjectState, CullableObjectState> OnNewCullState { get; set; } = delegate
	{
	};

	public CullableObjectState CurrentState => _currentState;

	public bool IsCulledOrShadowsOnly
	{
		get
		{
			if (_currentState != CullableObjectState.Culled)
			{
				return _currentState == CullableObjectState.ShadowsOnly;
			}
			return true;
		}
	}

	public void Awake()
	{
		SetCullState(CullableObjectState.Normal);
		if (Application.isPlaying)
		{
			_factoryObjectView.FactoryObjectSet += OnFactoryObjectSet;
			_factoryObjectView.FactoryObjectReset += OnFactoryObjectReset;
			if (_hologramVFXController != null)
			{
				_hologramVFXController.NormalVersionShown += RefreshCullingPosition;
			}
			_hasLODState = _lowDetailMeshRenderers.Length != 0 || _lowDetailParticleSystems.Length != 0 || _lowDetailAnimators.Length != 0 || _lowDetailVisualEffects.Length != 0;
		}
	}

	public void OnDestroy()
	{
		if (Application.isPlaying)
		{
			if (CullingJobManager.Instance != null)
			{
				CullingJobManager.UnRegisterCullable(this);
			}
			_factoryObjectView.FactoryObjectSet -= OnFactoryObjectSet;
			_factoryObjectView.FactoryObjectReset -= OnFactoryObjectReset;
			if (_hologramVFXController != null)
			{
				_hologramVFXController.NormalVersionShown -= RefreshCullingPosition;
			}
		}
	}

	private void OnEnable()
	{
		if (Application.isPlaying)
		{
			RefreshCullingPosition();
			SetCullState(CullableObjectState.Normal);
		}
	}

	public void SetCullingFactoryObject(FactoryObject factoryObject)
	{
		_factoryObject = factoryObject;
		CullingJobManager.RegisterCullable(this);
		RefreshCullingPosition();
	}

	private void OnFactoryObjectSet(FactoryObject factoryObject, bool __)
	{
		SetCullingFactoryObject(factoryObject);
	}

	private void OnFactoryObjectReset(FactoryObjectView factoryObjectView)
	{
		CullingJobManager.UnRegisterCullable(this);
	}

	public void RefreshCullingPosition()
	{
		_cachedPosition = new CullablePositionInfo
		{
			Position = base.gameObject.transform.position,
			Bounds = (_overrideBounds ? new Vector3?(_overriddenBounds) : ((Vector3?)_factoryObject?.FactoryObjectData.GetRelativeBounds())),
			Island = _factoryObject?.GetIsland()
		};
		CullingJobManager.RefreshCullablePosition(this);
	}

	CullableSettings ICullable.GetSettings()
	{
		return _cullableSettings.ToCullableSettings();
	}

	CullablePositionInfo ICullable.GetPosition()
	{
		return _cachedPosition;
	}

	public void SetAudioCullingState(bool canEmit)
	{
		FactoryObjectViewAudioData[] loopingAudioEventData = _loopingAudioEventData;
		for (int i = 0; i < loopingAudioEventData.Length; i++)
		{
			loopingAudioEventData[i].SetAudioEmitState(canEmit);
		}
	}

	public void SetMeshRenderersState(bool cullNorm, bool cullLod, bool shadowsOnly)
	{
		bool forceRenderingOff = (_normalIsAlsoLOD ? (cullNorm && cullLod) : cullNorm);
		MeshRenderer[] normalMeshRenderers = _normalMeshRenderers;
		foreach (MeshRenderer obj in normalMeshRenderers)
		{
			obj.forceRenderingOff = forceRenderingOff;
			obj.shadowCastingMode = ((!shadowsOnly) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
		}
		normalMeshRenderers = _lowDetailMeshRenderers;
		foreach (MeshRenderer obj2 in normalMeshRenderers)
		{
			obj2.forceRenderingOff = cullLod;
			obj2.shadowCastingMode = ((!shadowsOnly) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
		}
	}

	public void SetParticleSystemsCullingState(bool cullNorm, bool cullLod)
	{
		bool forceRenderingOff = (_normalIsAlsoLOD ? (cullNorm && cullLod) : cullNorm);
		ParticleSystemRenderer[] normalParticleSystems = _normalParticleSystems;
		for (int i = 0; i < normalParticleSystems.Length; i++)
		{
			normalParticleSystems[i].forceRenderingOff = forceRenderingOff;
		}
		normalParticleSystems = _lowDetailParticleSystems;
		for (int i = 0; i < normalParticleSystems.Length; i++)
		{
			normalParticleSystems[i].forceRenderingOff = cullLod;
		}
	}

	public void SetAnimatorsCullingState(bool cullNorm, bool cullLod)
	{
		bool flag = (_normalIsAlsoLOD ? (cullNorm && cullLod) : cullNorm);
		Animator[] normalAnimators = _normalAnimators;
		for (int i = 0; i < normalAnimators.Length; i++)
		{
			normalAnimators[i].enabled = !flag;
		}
		normalAnimators = _lowDetailAnimators;
		for (int i = 0; i < normalAnimators.Length; i++)
		{
			normalAnimators[i].enabled = !cullLod;
		}
	}

	public void SetVisualEffectsCullingState(bool cullNorm, bool cullLod)
	{
		VisualEffect[] normalVisualEffects = _normalVisualEffects;
		for (int i = 0; i < normalVisualEffects.Length; i++)
		{
			normalVisualEffects[i].enabled = !cullNorm;
		}
		normalVisualEffects = _lowDetailVisualEffects;
		for (int i = 0; i < normalVisualEffects.Length; i++)
		{
			normalVisualEffects[i].enabled = !cullLod;
		}
	}

	public void SetCanvasesCullingState(bool cullNorm)
	{
		Canvas[] normalCanvases = _normalCanvases;
		for (int i = 0; i < normalCanvases.Length; i++)
		{
			normalCanvases[i].enabled = !cullNorm;
		}
	}

	public void SetCullState(CullableObjectState nextState)
	{
		bool flag = nextState switch
		{
			CullableObjectState.LOD => _hasLODState, 
			CullableObjectState.Culled => true, 
			_ => false, 
		};
		bool cullLod = nextState == CullableObjectState.Culled || nextState == CullableObjectState.Normal;
		bool shadowsOnly = nextState == CullableObjectState.ShadowsOnly;
		SetMeshRenderersState(flag, cullLod, shadowsOnly);
		SetParticleSystemsCullingState(flag, cullLod);
		SetAnimatorsCullingState(flag, cullLod);
		SetVisualEffectsCullingState(flag, cullLod);
		SetCanvasesCullingState(flag);
		bool audioCullingState = (_keepLoopingAudioAtLOD ? (nextState != CullableObjectState.Culled) : (nextState == CullableObjectState.Normal));
		SetAudioCullingState(audioCullingState);
		_currentState = nextState;
		OnNewCullState(nextState, _currentState);
	}

	void ICullable.UpdateCullState(CullableObjectState nextState)
	{
		SetCullState(nextState);
	}

	public void SetCullingBoundsOverride(Vector3 bounds)
	{
		_overrideBounds = true;
		_overriddenBounds = bounds;
	}

	public void DisableCullingBoundsOverride()
	{
		_overrideBounds = false;
	}
}
