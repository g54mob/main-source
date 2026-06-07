using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class DisplaySettingsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 3;

		public int _qualityLevel;

		public int _renderScale;

		public bool _limitFrameRate;

		public int _targetFrameRate;

		public bool _vSync;

		public bool _tiltShift;

		public bool _modulesOutline;

		public int _maxZoomLevelModifier;

		public DisplaySettingsSaveData(int qualityLevel, int renderScale, bool limitFrameRate, int targetFrameRate, bool vSync, bool tiltShift, int maxZoomLevelModifier, bool modulesOutline)
			: base(3)
		{
			_qualityLevel = qualityLevel;
			_renderScale = renderScale;
			_limitFrameRate = limitFrameRate;
			_targetFrameRate = targetFrameRate;
			_vSync = vSync;
			_tiltShift = tiltShift;
			_modulesOutline = modulesOutline;
			_maxZoomLevelModifier = maxZoomLevelModifier;
		}
	}
}
