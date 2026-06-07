using Borodar.FarlandSkies.Core.Helpers;
using UnityEngine;

namespace Borodar.FarlandSkies.NebulaOne
{
	[ExecuteInEditMode]
	public class SkyboxAnimator : Singleton<SkyboxAnimator>
	{
		[SerializeField]
		private Vector3 _rotationSpeed;

		[SerializeField]
		private float _distortionSpeed;

		[SerializeField]
		private float _maxDistortionValue;

		[SerializeField]
		private BackgroundParamsList _backgroundParamsList;

		[SerializeField]
		private StarsParamsList _starsParamsList;

		[SerializeField]
		private NebulaParamsList _nebulaParamsList;

		[SerializeField]
		private int _framesInterval;

		private SkyboxController _skyboxController;

		private float _cycleProgress;

		private int _framesToSkip;

		public float CycleProgress
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 RotationSpeed
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float DistortionSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxDistortionValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BackgroundParam CurrentBackgroundParam { get; private set; }

		public StarsParam CurrentStarsParam { get; private set; }

		public NebulaParam CurrentNebulaParam { get; private set; }

		protected void Awake()
		{
		}

		protected void Start()
		{
		}

		protected void Update()
		{
		}

		protected void OnValidate()
		{
		}

		private static Vector3 Modulo360(Vector3 input)
		{
			return default(Vector3);
		}
	}
}
