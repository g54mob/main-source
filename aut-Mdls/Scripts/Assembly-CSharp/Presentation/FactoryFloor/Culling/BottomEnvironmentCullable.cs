using System;
using System.Collections.Generic;
using Events;
using JobSystem;
using UnityEngine;

namespace Presentation.FactoryFloor.Culling
{
	public class BottomEnvironmentCullable : MonoBehaviour, ICullable
	{
		[SerializeField]
		private CullableSettingsSO _bottomCullingSettings;

		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		private CullableObjectState _cullingState;

		private CullablePositionInfo _cachedPositionInfo;

		private Vector3 _boundsMin = Vector3.one * 10000f;

		private Vector3 _boundsMax = Vector3.one * -10000f;

		private List<MeshRenderer> _meshRenderersToToggle = new List<MeshRenderer>();

		public CullableObjectState CurrentState => _cullingState;

		public bool IsCulledOrShadowsOnly
		{
			get
			{
				if (_cullingState != CullableObjectState.Culled)
				{
					return _cullingState == CullableObjectState.ShadowsOnly;
				}
				return true;
			}
		}

		public Action<CullableObjectState, CullableObjectState> OnNewCullState { get; set; }

		public CullableSettings GetSettings()
		{
			return _bottomCullingSettings.ToCullableSettings();
		}

		public void Awake()
		{
			if (!(CullingJobManager.Instance == null))
			{
				_preLoadingSaveEvent.Register(InitializeForCulling);
			}
		}

		public void InitializeForCulling()
		{
			_preLoadingSaveEvent.UnRegister(InitializeForCulling);
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				_meshRenderersToToggle.Add(meshRenderer);
				_boundsMax = Vector3.Max(_boundsMax, meshRenderer.bounds.max);
				_boundsMin = Vector3.Min(_boundsMin, meshRenderer.bounds.min);
			}
			CullingJobManager.RegisterCullable(this);
			RefreshCullingPosition();
		}

		public void OnDestroy()
		{
			_meshRenderersToToggle.Clear();
			_preLoadingSaveEvent.UnRegister(InitializeForCulling);
			if (!(CullingJobManager.Instance == null))
			{
				CullingJobManager.UnRegisterCullable(this);
			}
		}

		public void RefreshCullingPosition()
		{
			_cachedPositionInfo = new CullablePositionInfo
			{
				Position = base.gameObject.transform.position,
				Bounds = _boundsMax - _boundsMin,
				Island = null
			};
			CullingJobManager.RefreshCullablePosition(this);
		}

		public CullablePositionInfo GetPosition()
		{
			return _cachedPositionInfo;
		}

		public void UpdateCullState(CullableObjectState cull)
		{
			_cullingState = cull;
			foreach (MeshRenderer item in _meshRenderersToToggle)
			{
				item.forceRenderingOff = _cullingState == CullableObjectState.Culled;
			}
		}
	}
}
