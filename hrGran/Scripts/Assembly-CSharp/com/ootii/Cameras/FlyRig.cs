using UnityEngine;
using com.ootii.Actors;
using com.ootii.Input;

namespace com.ootii.Cameras
{
	[AddComponentMenu("ootii/Camera Rigs/Fly Rig")]
	public class FlyRig : BaseCameraRig
	{
		public GameObject _InputSourceOwner;

		public float _MoveSpeed;

		public float _FastFactor;

		public float _SlowFactor;

		public float _ScrollFactor;

		public bool _InvertPitch;

		public float _RotationSpeed;

		protected float mDegreesPer60FPSTick;

		protected Vector3 mToCameraDirection;

		protected Quaternion mTilt;

		protected IInputSource mInputSource;

		private float mYaw;

		private float mPitch;

		public GameObject InputSourceOwner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Transform Anchor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float MoveSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FastFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SlowFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScrollFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool InvertPitch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual float RotationSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		public override void RigLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
		}

		private void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
		}
	}
}
