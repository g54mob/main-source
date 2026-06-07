using System;
using UnityEngine;

namespace com.ootii.Cameras
{
	public class BaseCameraRig : MonoBehaviour, IBaseCameraRig
	{
		public bool _UseFixedUpdate;

		[NonSerialized]
		public Transform _Transform;

		[NonSerialized]
		[HideInInspector]
		public Camera _Camera;

		public int _Mode;

		protected bool mLockMode;

		public Transform _Anchor;

		protected bool mFrameLockForward;

		public bool _FrameForceToFollowAnchor;

		public bool _IsInternalUpdateEnabled;

		public bool _IsFixedUpdateEnabled;

		public float _FixedUpdateFPS;

		[NonSerialized]
		public float _DeltaTime;

		protected CameraUpdateEvent mOnPostLateUpdate;

		protected bool mIsFirstUpdate;

		protected int mUpdateCount;

		protected int mUpdateIndex;

		protected float mFixedElapsedTime;

		protected float mEditorLastTime;

		protected float mEditorDeltaTime;

		public bool UseFixedUpdate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual Transform Transform => null;

		public virtual Camera Camera => null;

		public virtual int Mode
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual bool LockMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual Transform Anchor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual bool FrameLockForward
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool FrameForceToFollowAnchor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsInternalUpdateEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsFixedUpdateEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual float FixedUpdateFPS
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float DeltaTime => 0f;

		public CameraUpdateEvent OnPostLateUpdate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public virtual void EnableMode(int rMode, bool rEnable)
		{
		}

		public virtual void ClearTargetYawPitch()
		{
		}

		public virtual void SetTargetYawPitch(float rYaw, float rPitch, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
		}

		public virtual void ClearTargetForward()
		{
		}

		public virtual void SetTargetForward(Vector3 rForward, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
		}

		public virtual void ExtrapolateAnchorPosition(out Vector3 rPosition, out Quaternion rRotation)
		{
			rPosition = default(Vector3);
			rRotation = default(Quaternion);
		}

		protected virtual void Update()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		public virtual void RigLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
		}

		protected virtual void InternalUpdate()
		{
		}

		public static BaseCameraRig ExtractCameraRig(Transform rCamera)
		{
			return null;
		}
	}
}
