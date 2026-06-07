using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;
using UnityEngine.PajamaLlama;

public class CircadianVisuals : SceneBehaviour
{
	[Serializable]
	private class Settings
	{
		[SerializeField]
		private WorldRegionType _region;

		[SerializeField]
		[Tooltip("This setting can be ignored for the map settings.")]
		private PollutionLevels _pollutionLevel;

		[SerializeField]
		[NamedArrayElement(new string[] { "_light" })]
		private List<CircadianLighting> _lights;

		[SerializeField]
		private SkyBoxBlender _skybox;

		[SerializeField]
		private CircadianEnvironmentColors _environmentColors;

		[SerializeField]
		[NamedArrayElement(new string[] { "_renderer" })]
		private List<MaterialBlender> _materials;

		[SerializeField]
		private VolumeBlender _volume;

		public WorldRegionType Region => _region;

		public PollutionLevels PollutionLevel => _pollutionLevel;

		public void Enable()
		{
			_volume.Enable();
			foreach (MaterialBlender material in _materials)
			{
				material.Enable();
			}
		}

		public void Disable()
		{
			_volume.Disable();
		}

		public void Blend(float blendProgress)
		{
			foreach (CircadianLighting light in _lights)
			{
				light.Blend(blendProgress);
			}
			_skybox.Blend(blendProgress);
			_environmentColors.Blend(blendProgress);
			foreach (MaterialBlender material in _materials)
			{
				material.Blend(blendProgress);
			}
			_volume.Blend(blendProgress);
		}
	}

	[SerializeField]
	private Settings _mapSettings;

	[SerializeField]
	[NamedArrayElement(new string[] { "_pollutionLevel" })]
	private Settings[] _worldSettings;

	private TimeManager _timeManager;

	private Settings _activeSettings;

	private float _blendProgress;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.MapActivated, ActivateMapSettings);
		GameEventDispatcher.AddListener(GameEventType.MapDeactivated, ActivateWorldSettings);
	}

	private void Start()
	{
		if (_timeManager == null)
		{
			_timeManager = GameManager.TimeManager;
		}
		ActivateWorldSettings();
	}

	private void Update()
	{
		TryBlendVisuals(_timeManager.ReturnDayNightBlend());
	}

	private void OnDisable()
	{
		GameEventDispatcher.AddListener(GameEventType.MapActivated, ActivateMapSettings);
		GameEventDispatcher.AddListener(GameEventType.MapDeactivated, ActivateWorldSettings);
	}

	private void ActivateMapSettings(GameEvent gameEvent)
	{
		ActivateSettings(_mapSettings);
	}

	private void ActivateWorldSettings(GameEvent gameEvent = null)
	{
		ActivateSettings(ReturnWorldSettings(GameManager.WorldManager.CurrentRegion));
	}

	private void ActivateSettings(Settings settings)
	{
		if (_activeSettings != settings)
		{
			if (_activeSettings != null)
			{
				_activeSettings.Disable();
			}
			_activeSettings = settings;
			_activeSettings.Enable();
		}
		BlendVisuals(_timeManager.ReturnDayNightBlend());
	}

	private bool TryBlendVisuals(float blendProgress)
	{
		if (Mathf.Approximately(_blendProgress, blendProgress))
		{
			return false;
		}
		BlendVisuals(blendProgress);
		return true;
	}

	private void BlendVisuals(float blendProgress)
	{
		if (_activeSettings == null)
		{
			Debug.LogError("DayNightCycle (CircadianVisuals) has no active settings!");
		}
		else
		{
			_activeSettings.Blend(blendProgress);
		}
	}

	private Settings ReturnWorldSettings(IWorldRegion region)
	{
		Settings settings = null;
		Settings settings2 = null;
		for (int i = 0; i < _worldSettings.Length; i++)
		{
			settings = _worldSettings[i];
			if (settings.Region == region.Type)
			{
				if (settings.PollutionLevel == region.PollutionLevel)
				{
					return settings;
				}
				if (settings.PollutionLevel < region.PollutionLevel && (settings2 == null || settings2.PollutionLevel < settings.PollutionLevel))
				{
					settings2 = null;
				}
			}
		}
		if (settings2 != null)
		{
			Debug.LogWarning($"No 'World Settings' found for region '{region.Type}' with pollution level '{region.PollutionLevel}'. Falling back on settings for pollution level '{settings2.PollutionLevel}' (first in the list).");
			return settings2;
		}
		if (_worldSettings.Length != 0)
		{
			settings2 = _worldSettings[0];
			Debug.LogWarning($"No 'World Settings' found for region '{region.Type}' Falling back on settings for region '{settings2.Region}' with pollution level '{settings2.PollutionLevel}' (first in the list).");
			return settings2;
		}
		Debug.LogError("'World Settings' have not been setup on DayNightCycle prefab (Script: CircadianVisuals)");
		return null;
	}
}
