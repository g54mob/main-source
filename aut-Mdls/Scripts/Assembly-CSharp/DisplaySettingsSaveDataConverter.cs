using System;
using Data.SaveData;
using Data.SaveData.PersistentSOs;

public class DisplaySettingsSaveDataConverter : SaveDataConverter<DisplaySettingsSaveData>
{
	private class Version0 : IPreviousSaveVersion, ISaveVersion
	{
		public int _qualityLevel;

		public int _renderScale;

		public bool _limitFrameRate;

		public int _targetFrameRate;

		public bool _vSync;

		public ISaveVersion ToNextVersion()
		{
			return new Version2(_qualityLevel, _renderScale, _limitFrameRate, _targetFrameRate, _vSync, tiltShift: true, 0);
		}
	}

	private class Version1 : IPreviousSaveVersion, ISaveVersion
	{
		public int _qualityLevel;

		public int _renderScale;

		public bool _limitFrameRate;

		public int _targetFrameRate;

		public bool _vSync;

		public int _maxZoomLevelModifier;

		public ISaveVersion ToNextVersion()
		{
			return new Version2(_qualityLevel, _renderScale, _limitFrameRate, _targetFrameRate, _vSync, tiltShift: true, _maxZoomLevelModifier);
		}
	}

	private class Version2 : IPreviousSaveVersion, ISaveVersion
	{
		public int _qualityLevel;

		public int _renderScale;

		public bool _limitFrameRate;

		public int _targetFrameRate;

		public bool _vSync;

		public bool _tiltShift;

		public int _maxZoomLevelModifier;

		public Version2(int qualityLevel, int renderScale, bool limitFrameRate, int targetFrameRate, bool vSync, bool tiltShift, int maxZoomLevel)
		{
			_qualityLevel = qualityLevel;
			_renderScale = renderScale;
			_limitFrameRate = limitFrameRate;
			_targetFrameRate = targetFrameRate;
			_vSync = vSync;
			_tiltShift = tiltShift;
			_maxZoomLevelModifier = maxZoomLevel;
		}

		public ISaveVersion ToNextVersion()
		{
			return new DisplaySettingsSaveData(_qualityLevel, _renderScale, _limitFrameRate, _targetFrameRate, _vSync, _tiltShift, _maxZoomLevelModifier, modulesOutline: true);
		}
	}

	public DisplaySettingsSaveDataConverter()
		: base(3)
	{
	}

	public override Type GetPreviousVersion(int version)
	{
		return version switch
		{
			0 => typeof(Version0), 
			1 => typeof(Version1), 
			2 => typeof(Version2), 
			_ => null, 
		};
	}
}
