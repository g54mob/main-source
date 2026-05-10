using UnityEngine;

namespace CW.Common
{
	[ExecuteInEditMode]
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwFollow")]
	[AddComponentMenu("Common/CW Follow")]
	public class CwFollow : MonoBehaviour
	{
		public enum FollowType
		{
			TargetTransform = 0,
			MainCamera = 1
		}

		public enum UpdateType
		{
			Update = 0,
			LateUpdate = 1
		}

		[SerializeField]
		private FollowType follow;

		[SerializeField]
		private Transform target;

		[SerializeField]
		private float damping;

		[SerializeField]
		private bool rotate;

		[SerializeField]
		private bool ignoreZ;

		[SerializeField]
		private UpdateType followIn;

		[SerializeField]
		private Vector3 localPosition;

		[SerializeField]
		private Vector3 localRotation;

		public FollowType Follow
		{
			get
			{
				return default(FollowType);
			}
			set
			{
			}
		}

		public Transform Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Damping
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Rotate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IgnoreZ
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UpdateType FollowIn
		{
			get
			{
				return default(UpdateType);
			}
			set
			{
			}
		}

		public Vector3 LocalPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 LocalRotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[ContextMenu("UpdatePosition")]
		public void UpdatePosition()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void LateUpdate()
		{
		}
	}
}
