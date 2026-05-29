using UnityEngine;

namespace VisualDesignCafe.Nature
{
	[ExecuteAlways]
	public class GlobalWind : MonoBehaviour
	{
		[SerializeField]
		private WindSettings _windSettings;

		[SerializeField]
		private WindZone _sourceWindZone;

		[SerializeField]
		private Texture2D _gustNoise;

		[HideInInspector]
		[SerializeField]
		private int _selectedPreset;

		private Quaternion _cachedRotation;

		private float _cachedWindMain;

		private float _cachedWindPulseFrequency;

		private float _cachedWindTurbulence;

		private double _smoothWindOffset;

		private double _cachedTime;

		private Vector2 _windOffset;

		private Vector2 _prevWindOffset;

		private Vector2 _direction;

		private Vector2 _directionVelocity;

		private float _strength;

		private float _strengthVelocity;

		private float _speed;

		private float _speedVelocity;

		private float _turbulence;

		private float _turbulenceVelocity;

		public static GlobalWind Instance { get; private set; }

		public WindSettings Settings
		{
			get
			{
				return default(WindSettings);
			}
			set
			{
			}
		}

		public WindZone Zone
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Texture2D GustNoise
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void SetFloatingOrigin(double x, double z)
		{
		}

		private float Wrap(double value, double range)
		{
			return 0f;
		}

		public void UpdateTime(double time)
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void CopyAndApply()
		{
		}

		private void CopyFromWindZone()
		{
		}

		private bool WindZoneHasChanged()
		{
			return false;
		}

		private void CacheWindZoneProperties()
		{
		}

		private void ValidateWindZone()
		{
		}

		private void UpdateDirection(bool useCache)
		{
		}
	}
}
