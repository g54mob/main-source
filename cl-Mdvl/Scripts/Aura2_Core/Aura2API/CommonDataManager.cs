namespace Aura2API
{
	public class CommonDataManager
	{
		private LightsCommonDataManager _lightsCommonDataManager;

		private VolumesCommonDataManager _volumesCommonDataManager;

		private AmbientLightingCommonDataManager _ambientLightingCommonDataManager;

		public LightsCommonDataManager LightsCommonDataManager
		{
			get
			{
				if (_lightsCommonDataManager == null)
				{
					_lightsCommonDataManager = new LightsCommonDataManager();
				}
				return _lightsCommonDataManager;
			}
		}

		public VolumesCommonDataManager VolumesCommonDataManager
		{
			get
			{
				if (_volumesCommonDataManager == null)
				{
					_volumesCommonDataManager = new VolumesCommonDataManager();
				}
				return _volumesCommonDataManager;
			}
		}

		public AmbientLightingCommonDataManager AmbientLightingCommonDataManager
		{
			get
			{
				if (_ambientLightingCommonDataManager == null)
				{
					_ambientLightingCommonDataManager = new AmbientLightingCommonDataManager();
				}
				return _ambientLightingCommonDataManager;
			}
		}

		public void Dispose()
		{
			LightsCommonDataManager.Dispose();
			VolumesCommonDataManager.Dispose();
		}

		public void UpdateData()
		{
			if (_lightsCommonDataManager != null)
			{
				LightsCommonDataManager.Update();
			}
			if (_ambientLightingCommonDataManager != null)
			{
				AmbientLightingCommonDataManager.Update();
			}
		}
	}
}
