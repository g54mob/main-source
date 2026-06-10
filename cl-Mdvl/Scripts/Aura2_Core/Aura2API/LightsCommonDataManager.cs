using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aura2API
{
	public class LightsCommonDataManager
	{
		private List<AuraLight> _registeredDirectionalLightsList;

		private DirectionalLightsManager _directionalLightsManager;

		private ShadowmapsCollector _directionalLightsShadowMapsCollector;

		private DirectionalShadowDataCollector _directionalLightsShadowDataCollector;

		private int _directionalShadowsCasterCount;

		private Texture2DArrayComposer _directionalLightsCookieMapsCollector;

		private static int _cascadesCount;

		private List<AuraLight> _registeredSpotLightsList;

		private ShadowmapsCollector _spotLightsShadowMapsCollector;

		private Texture2DArrayComposer _spotLightsCookieMapsCollector;

		private List<AuraLight> _registeredPointLightsList;

		private ShadowmapsCollector _pointLightsShadowMapsCollector;

		private Texture2DArrayComposer _pointLightsCookieMapsCollector;

		public List<AuraLight> RegisteredDirectionalLightsList
		{
			get
			{
				if (_registeredDirectionalLightsList == null)
				{
					_registeredDirectionalLightsList = new List<AuraLight>();
				}
				return _registeredDirectionalLightsList;
			}
		}

		public DirectionalLightsManager DirectionalLightsManager
		{
			get
			{
				if (_directionalLightsManager == null)
				{
					_directionalLightsManager = new DirectionalLightsManager();
				}
				return _directionalLightsManager;
			}
		}

		public bool HasRegisteredDirectionalLights => RegisteredDirectionalLightsList.Count > 0;

		public bool HasDirectionalShadowCasters
		{
			get
			{
				if (_directionalLightsShadowMapsCollector == null)
				{
					return false;
				}
				return _directionalLightsShadowMapsCollector.HasTexture;
			}
		}

		public Texture2DArray DirectionalShadowMapsArray => _directionalLightsShadowMapsCollector.ArrayTexture;

		public Texture2DArray DirectionalShadowDataArray => _directionalLightsShadowDataCollector.ArrayTexture;

		public int DirectionalShadowsCasterCount => _directionalShadowsCasterCount;

		public bool HasDirectionalCookieCasters
		{
			get
			{
				if (_directionalLightsCookieMapsCollector == null)
				{
					return false;
				}
				return _directionalLightsCookieMapsCollector.HasTexture;
			}
		}

		public Texture2DArray DirectionalCookieMapsArray => _directionalLightsCookieMapsCollector.ArrayTexture;

		public List<AuraLight> RegisteredSpotLightsList
		{
			get
			{
				if (_registeredSpotLightsList == null)
				{
					_registeredSpotLightsList = new List<AuraLight>();
				}
				return _registeredSpotLightsList;
			}
		}

		public bool HasRegisteredSpotLights => RegisteredSpotLightsList.Count > 0;

		public bool HasSpotShadowCasters
		{
			get
			{
				if (_spotLightsShadowMapsCollector == null)
				{
					return false;
				}
				return _spotLightsShadowMapsCollector.HasTexture;
			}
		}

		public Texture2DArray SpotShadowMapsArray => _spotLightsShadowMapsCollector.ArrayTexture;

		public bool HasSpotCookieCasters
		{
			get
			{
				if (_spotLightsCookieMapsCollector == null)
				{
					return false;
				}
				return _spotLightsCookieMapsCollector.HasTexture;
			}
		}

		public Texture2DArray SpotCookieMapsArray => _spotLightsCookieMapsCollector.ArrayTexture;

		public List<AuraLight> RegisteredPointLightsList
		{
			get
			{
				if (_registeredPointLightsList == null)
				{
					_registeredPointLightsList = new List<AuraLight>();
				}
				return _registeredPointLightsList;
			}
		}

		public bool HasRegisteredPointLights => RegisteredPointLightsList.Count > 0;

		public bool HasPointShadowCasters
		{
			get
			{
				if (_pointLightsShadowMapsCollector == null)
				{
					return false;
				}
				return _pointLightsShadowMapsCollector.HasTexture;
			}
		}

		public Texture2DArray PointShadowMapsArray => _pointLightsShadowMapsCollector.ArrayTexture;

		public bool HasPointCookieCasters
		{
			get
			{
				if (_pointLightsCookieMapsCollector == null)
				{
					return false;
				}
				return _pointLightsCookieMapsCollector.HasTexture;
			}
		}

		public Texture2DArray PointCookieMapsArray => _pointLightsCookieMapsCollector.ArrayTexture;

		public event Action OnShadowsSettingsChanged;

		public event Action<AuraLight> OnRegisterSpotLight;

		public event Action<AuraLight> OnUnregisterSpotLight;

		public event Action<AuraLight> OnRegisterPointLight;

		public event Action<AuraLight> OnUnregisterPointLight;

		public LightsCommonDataManager()
		{
			_cascadesCount = QualitySettings.shadowCascades;
			_directionalShadowsCasterCount = 0;
		}

		public void Dispose()
		{
			ReleaseLightsManagers();
			ReleaseDirectionalRenderTexturesCollectors();
			ReleaseSpotRenderTexturesCollectors();
			ReleasePointRenderTexturesCollectors();
		}

		private void ReleaseLightsManagers()
		{
			if (_directionalLightsManager != null)
			{
				DirectionalLightsManager.Dispose();
			}
		}

		private void ReleaseDirectionalRenderTexturesCollectors()
		{
			if (_directionalLightsShadowMapsCollector != null)
			{
				_directionalLightsShadowMapsCollector.Release();
				_directionalLightsShadowMapsCollector = null;
			}
			if (_directionalLightsShadowDataCollector != null)
			{
				_directionalLightsShadowDataCollector.Release();
				_directionalLightsShadowDataCollector = null;
			}
			if (_directionalLightsCookieMapsCollector != null)
			{
				_directionalLightsCookieMapsCollector.Release();
				_directionalLightsCookieMapsCollector = null;
			}
		}

		private void ReleaseSpotRenderTexturesCollectors()
		{
			if (_spotLightsShadowMapsCollector != null)
			{
				_spotLightsShadowMapsCollector.Release();
				_spotLightsShadowMapsCollector = null;
			}
			if (_spotLightsCookieMapsCollector != null)
			{
				_spotLightsCookieMapsCollector.Release();
				_spotLightsCookieMapsCollector = null;
			}
		}

		private void ReleasePointRenderTexturesCollectors()
		{
			if (_pointLightsShadowMapsCollector != null)
			{
				_pointLightsShadowMapsCollector.Release();
				_pointLightsShadowMapsCollector = null;
			}
			if (_pointLightsCookieMapsCollector != null)
			{
				_pointLightsCookieMapsCollector.Release();
				_pointLightsCookieMapsCollector = null;
			}
		}

		private void CreateDirectionalShadowsCollectors()
		{
			if (_directionalLightsShadowMapsCollector == null)
			{
				_directionalLightsShadowMapsCollector = new ShadowmapsCollector(DirectionalLightsManager.ShadowMapSize.x, DirectionalLightsManager.ShadowMapSize.y);
			}
			if (_directionalLightsShadowDataCollector == null)
			{
				_directionalLightsShadowDataCollector = new DirectionalShadowDataCollector();
			}
		}

		public void Update()
		{
			bool flag = false;
			if (_directionalShadowsCasterCount > 0 && _cascadesCount != QualitySettings.shadowCascades)
			{
				ReleaseDirectionalRenderTexturesCollectors();
				_cascadesCount = QualitySettings.shadowCascades;
				if (this.OnShadowsSettingsChanged != null)
				{
					this.OnShadowsSettingsChanged();
				}
				flag = true;
			}
			if (!flag)
			{
				GenerateLightsMaps();
			}
			DirectionalLightsManager.Update();
		}

		public void RegisterLight(AuraLight auraLight)
		{
			switch (auraLight.Type)
			{
			case LightType.Directional:
				if (RegisteredDirectionalLightsList.Contains(auraLight))
				{
					break;
				}
				RegisteredDirectionalLightsList.Add(auraLight);
				if (auraLight.CastsShadows)
				{
					CreateDirectionalShadowsCollectors();
					_directionalLightsShadowMapsCollector.AddTexture(auraLight.shadowMapRenderTexture);
					SetDirectionalShadowMapsId();
					_directionalLightsShadowDataCollector.AddTexture(auraLight.shadowDataRenderTexture);
					_directionalShadowsCasterCount++;
				}
				if (auraLight.CastsCookie)
				{
					if (_directionalLightsCookieMapsCollector == null)
					{
						_directionalLightsCookieMapsCollector = new Texture2DArrayComposer(DirectionalLightsManager.cookieMapSize.x, DirectionalLightsManager.cookieMapSize.y, TextureFormat.R8, bypassSrgb: true);
					}
					_directionalLightsCookieMapsCollector.AddTexture(auraLight.cookieMapRenderTexture);
					SetDirectionalCookieMapsId();
				}
				break;
			case LightType.Spot:
				if (RegisteredSpotLightsList.Contains(auraLight))
				{
					break;
				}
				RegisteredSpotLightsList.Add(auraLight);
				if (auraLight.CastsShadows)
				{
					if (_spotLightsShadowMapsCollector == null)
					{
						_spotLightsShadowMapsCollector = new ShadowmapsCollector(SpotLightsManager.shadowMapSize.x, SpotLightsManager.shadowMapSize.y);
					}
					_spotLightsShadowMapsCollector.AddTexture(auraLight.shadowMapRenderTexture);
					SetSpotShadowMapsId();
				}
				if (auraLight.CastsCookie)
				{
					if (_spotLightsCookieMapsCollector == null)
					{
						_spotLightsCookieMapsCollector = new Texture2DArrayComposer(SpotLightsManager.cookieMapSize.x, SpotLightsManager.cookieMapSize.y, TextureFormat.R8, bypassSrgb: true);
					}
					_spotLightsCookieMapsCollector.AddTexture(auraLight.cookieMapRenderTexture);
					SetSpotCookieMapsId();
				}
				if (this.OnRegisterSpotLight != null)
				{
					this.OnRegisterSpotLight(auraLight);
				}
				break;
			case LightType.Point:
				if (RegisteredPointLightsList.Contains(auraLight))
				{
					break;
				}
				RegisteredPointLightsList.Add(auraLight);
				if (auraLight.CastsShadows)
				{
					if (_pointLightsShadowMapsCollector == null)
					{
						_pointLightsShadowMapsCollector = new ShadowmapsCollector(PointLightsManager.shadowMapSize.x, PointLightsManager.shadowMapSize.y);
					}
					_pointLightsShadowMapsCollector.AddTexture(auraLight.shadowMapRenderTexture);
					SetPointShadowMapsId();
				}
				if (auraLight.CastsCookie)
				{
					if (_pointLightsCookieMapsCollector == null)
					{
						_pointLightsCookieMapsCollector = new Texture2DArrayComposer(PointLightsManager.cookieMapSize.x, PointLightsManager.cookieMapSize.y, TextureFormat.R8, bypassSrgb: true);
						_pointLightsCookieMapsCollector.alwaysGenerateOnUpdate = true;
					}
					_pointLightsCookieMapsCollector.AddTexture(auraLight.cookieMapRenderTexture);
					SetPointCookieMapsId();
				}
				if (this.OnRegisterPointLight != null)
				{
					this.OnRegisterPointLight(auraLight);
				}
				break;
			}
			auraLight.OnUninitialize += AuraLight_OnUninitialize;
		}

		private void AuraLight_OnUninitialize(AuraLight auraLight, LightType typeBeforeUninitialize)
		{
			switch (typeBeforeUninitialize)
			{
			case LightType.Directional:
				if (RegisteredDirectionalLightsList.Contains(auraLight))
				{
					if (_directionalLightsShadowMapsCollector != null && _directionalLightsShadowMapsCollector.RemoveTexture(auraLight.shadowMapRenderTexture))
					{
						_directionalLightsShadowDataCollector.RemoveTexture(auraLight.shadowDataRenderTexture);
						SetDirectionalShadowMapsId();
					}
					if (auraLight.CastsShadows)
					{
						_directionalShadowsCasterCount--;
					}
					if (_directionalLightsCookieMapsCollector != null && _directionalLightsCookieMapsCollector.RemoveTexture(auraLight.cookieMapRenderTexture))
					{
						SetDirectionalCookieMapsId();
					}
					RegisteredDirectionalLightsList.Remove(auraLight);
				}
				break;
			case LightType.Spot:
				if (RegisteredSpotLightsList.Contains(auraLight))
				{
					if (_spotLightsShadowMapsCollector != null && _spotLightsShadowMapsCollector.RemoveTexture(auraLight.shadowMapRenderTexture))
					{
						SetSpotShadowMapsId();
					}
					if (_spotLightsCookieMapsCollector != null && _spotLightsCookieMapsCollector.RemoveTexture(auraLight.cookieMapRenderTexture))
					{
						SetSpotCookieMapsId();
					}
					RegisteredSpotLightsList.Remove(auraLight);
					if (this.OnUnregisterSpotLight != null)
					{
						this.OnUnregisterSpotLight(auraLight);
					}
				}
				break;
			case LightType.Point:
				if (RegisteredPointLightsList.Contains(auraLight))
				{
					if (_pointLightsShadowMapsCollector != null && _pointLightsShadowMapsCollector.RemoveTexture(auraLight.shadowMapRenderTexture))
					{
						SetPointShadowMapsId();
					}
					if (_pointLightsCookieMapsCollector != null && _pointLightsCookieMapsCollector.RemoveTexture(auraLight.cookieMapRenderTexture))
					{
						SetPointCookieMapsId();
					}
					RegisteredPointLightsList.Remove(auraLight);
					if (this.OnUnregisterPointLight != null)
					{
						this.OnUnregisterPointLight(auraLight);
					}
				}
				break;
			}
			auraLight.OnUninitialize -= AuraLight_OnUninitialize;
		}

		private void SetDirectionalShadowMapId(AuraLight auraLight)
		{
			if (auraLight.CastsShadows)
			{
				auraLight.SetShadowMapIndex(_directionalLightsShadowMapsCollector.GetTextureIndex(auraLight.shadowMapRenderTexture));
			}
		}

		private void SetDirectionalShadowMapsId()
		{
			for (int i = 0; i < RegisteredDirectionalLightsList.Count; i++)
			{
				SetDirectionalShadowMapId(RegisteredDirectionalLightsList[i]);
			}
		}

		private void SetDirectionalCookieMapId(AuraLight auraLight)
		{
			if (auraLight.CastsCookie)
			{
				auraLight.SetCookieMapIndex(_directionalLightsCookieMapsCollector.GetTextureIndex(auraLight.cookieMapRenderTexture));
			}
		}

		private void SetDirectionalCookieMapsId()
		{
			for (int i = 0; i < RegisteredDirectionalLightsList.Count; i++)
			{
				SetDirectionalCookieMapId(RegisteredDirectionalLightsList[i]);
			}
		}

		private void SetSpotShadowMapId(AuraLight auraLight)
		{
			if (auraLight.CastsShadows)
			{
				auraLight.SetShadowMapIndex(_spotLightsShadowMapsCollector.GetTextureIndex(auraLight.shadowMapRenderTexture));
			}
		}

		private void SetSpotShadowMapsId()
		{
			for (int i = 0; i < RegisteredSpotLightsList.Count; i++)
			{
				SetSpotShadowMapId(RegisteredSpotLightsList[i]);
			}
		}

		private void SetSpotCookieMapId(AuraLight auraLight)
		{
			if (auraLight.CastsCookie)
			{
				auraLight.SetCookieMapIndex(_spotLightsCookieMapsCollector.GetTextureIndex(auraLight.cookieMapRenderTexture));
			}
		}

		private void SetSpotCookieMapsId()
		{
			for (int i = 0; i < RegisteredSpotLightsList.Count; i++)
			{
				SetSpotCookieMapId(RegisteredSpotLightsList[i]);
			}
		}

		private void SetPointShadowMapId(AuraLight auraLight)
		{
			if (auraLight.CastsShadows)
			{
				auraLight.SetShadowMapIndex(_pointLightsShadowMapsCollector.GetTextureIndex(auraLight.shadowMapRenderTexture));
			}
		}

		private void SetPointShadowMapsId()
		{
			for (int i = 0; i < RegisteredPointLightsList.Count; i++)
			{
				SetPointShadowMapId(RegisteredPointLightsList[i]);
			}
		}

		private void SetPointCookieMapId(AuraLight auraLight)
		{
			if (auraLight.CastsCookie)
			{
				auraLight.SetCookieMapIndex(_pointLightsCookieMapsCollector.GetTextureIndex(auraLight.cookieMapRenderTexture));
			}
		}

		private void SetPointCookieMapsId()
		{
			for (int i = 0; i < RegisteredPointLightsList.Count; i++)
			{
				SetPointCookieMapId(RegisteredPointLightsList[i]);
			}
		}

		private void GenerateLightsMaps()
		{
			if (_directionalLightsShadowMapsCollector != null)
			{
				_directionalLightsShadowMapsCollector.Generate();
				_directionalLightsShadowDataCollector.Generate();
			}
			if (_directionalLightsCookieMapsCollector != null)
			{
				_directionalLightsCookieMapsCollector.alwaysGenerateOnUpdate = true;
				_directionalLightsCookieMapsCollector.Generate();
			}
			if (_spotLightsShadowMapsCollector != null)
			{
				_spotLightsShadowMapsCollector.Generate();
			}
			if (_spotLightsCookieMapsCollector != null)
			{
				_spotLightsCookieMapsCollector.Generate();
			}
			if (_pointLightsShadowMapsCollector != null)
			{
				_pointLightsShadowMapsCollector.Generate();
			}
			if (_pointLightsCookieMapsCollector != null)
			{
				_pointLightsCookieMapsCollector.Generate();
			}
		}
	}
}
