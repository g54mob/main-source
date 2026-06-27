using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyTVEModule : CozyModule
	{
		public enum UpdateFrequency
		{
			everyFrame = 0,
			onAwake = 1,
			viaScripting = 2
		}

		public UpdateFrequency updateFrequency;

		[Header("Control Settings")]
		[Tooltip("Enable motion integration with TVE")]
		public bool enableMotionControl = true;

		[Tooltip("Enable season integration with TVE")]
		public bool enableSeasonControl = true;

		[Tooltip("Enable wetness integration with TVE")]
		public bool enableWetnessControl = true;

		[Tooltip("Enable snow integration with TVE")]
		public bool enableSnowControl = true;

		private void Awake()
		{
			InitializeModule();
		}

		public override void InitializeModule()
		{
			if (base.enabled)
			{
				base.InitializeModule();
				if (!base.weatherSphere)
				{
					base.enabled = false;
				}
			}
		}

		private void Update()
		{
			if ((!CozyWeather.FreezeUpdateInEditMode || Application.isPlaying) && updateFrequency == UpdateFrequency.everyFrame)
			{
				UpdateTVE();
			}
		}

		public void UpdateTVE()
		{
		}
	}
}
