using Loxodon.Framework.ViewModels;

namespace Player.Arms
{
	public class PlayerArmsViewModel : ViewModelBase
	{
		private bool _metalCanEnabled;

		private bool _glassBottleEnabled;

		private bool _drillEnabled;

		private bool _spannerEnabled;

		private bool _screwEnabled;

		private bool _ratchetEnabled;

		private bool _canisterEnabled;

		private bool _flareGunEnabled;

		public bool MetalCanEnabled
		{
			get
			{
				return _metalCanEnabled;
			}
			set
			{
				Set(ref _metalCanEnabled, value, "MetalCanEnabled");
			}
		}

		public bool GlassBottleEnabled
		{
			get
			{
				return _glassBottleEnabled;
			}
			set
			{
				Set(ref _glassBottleEnabled, value, "GlassBottleEnabled");
			}
		}

		public bool DrillEnabled
		{
			get
			{
				return _drillEnabled;
			}
			set
			{
				Set(ref _drillEnabled, value, "DrillEnabled");
			}
		}

		public bool SpannerEnabled
		{
			get
			{
				return _spannerEnabled;
			}
			set
			{
				Set(ref _spannerEnabled, value, "SpannerEnabled");
			}
		}

		public bool ScrewEnabled
		{
			get
			{
				return _screwEnabled;
			}
			set
			{
				Set(ref _screwEnabled, value, "ScrewEnabled");
			}
		}

		public bool RatchetEnabled
		{
			get
			{
				return _ratchetEnabled;
			}
			set
			{
				Set(ref _ratchetEnabled, value, "RatchetEnabled");
			}
		}

		public bool CanisterEnabled
		{
			get
			{
				return _canisterEnabled;
			}
			set
			{
				Set(ref _canisterEnabled, value, "CanisterEnabled");
			}
		}

		public bool FlareGunEnabled
		{
			get
			{
				return _flareGunEnabled;
			}
			set
			{
				Set(ref _flareGunEnabled, value, "FlareGunEnabled");
			}
		}
	}
}
